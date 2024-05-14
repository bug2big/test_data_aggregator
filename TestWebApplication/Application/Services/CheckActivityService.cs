using TestWebApplication.Application.Interfaces;
using TestWebApplication.Infrastructure.Persistence.Entities;

namespace TestWebApplication.Application.Services;

// TODO: Separete this class into processor class
public class CheckActivityService : ICheckActivityService
{
    private readonly IRepository<Customer2> _customer2Repository;
    private readonly IRepository<Customer101> _customer101Repository;
    private readonly IRepository<Customer145> _customer145Repository;

    private readonly IRepository<Events2> _events2Repository;
    private readonly IRepository<Events101> _events101Repository;
    private readonly IRepository<Events145> _events145Repository;

    private readonly IRepository<Tenant> _tenantRepository;
    private readonly IRepository<NotificationsBroker> _notificationsBrokerRepository;

    public CheckActivityService(
        IRepository<Customer2> customer2Repository,
        IRepository<Customer101> customer101Repository,
        IRepository<Customer145> customer145Repository,
        IRepository<Events2> events2Repository,
        IRepository<Events101> events101Repository,
        IRepository<Events145> events145Repository,
        IRepository<Tenant> tenantRepository,
        IRepository<NotificationsBroker> notificationsBrokerRepository)
    {
        _customer2Repository = customer2Repository;
        _customer101Repository = customer101Repository;
        _customer145Repository = customer145Repository;
        _events2Repository = events2Repository;
        _events101Repository = events101Repository;
        _events145Repository = events145Repository;
        _tenantRepository = tenantRepository;
        _notificationsBrokerRepository = notificationsBrokerRepository;
    }

    public async Task CheckActivity(DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default)
    {
        var customer2Ids = (await _events2Repository.GetByCriteriaAsync(x => x.EventDate >= fromDate && x.EventDate <= toDate))
            .GroupBy(x => x.CustomerId)
            .Where(x => x.Count() < 3)
            .Select(x => x.Key);
        var customer101Ids = (await _events101Repository.GetByCriteriaAsync(x => x.EventDate >= fromDate && x.EventDate <= toDate))
            .GroupBy(x => x.CustomerId)
            .Where(x => x.Count() < 3)
            .Select(x => x.Key);
        var customer145Ids = (await _events145Repository.GetByCriteriaAsync(x => x.EventDate >= fromDate && x.EventDate <= toDate))
            .GroupBy(x => x.CustomerId)
            .Where(x => x.Count() < 3)
            .Select(x => x.Key);

        var customers2 = await _customer2Repository.GetByCriteriaAsync(x => customer2Ids.Contains(x.Id));
        var customers101 = await _customer101Repository.GetByCriteriaAsync(x => customer101Ids.Contains(x.Id));
        var customers145 = await _customer145Repository.GetByCriteriaAsync(x => customer145Ids.Contains(x.UserId));

        await SaveCustomer2Notification(customers2.ToArray(), cancellationToken);
        await SaveCustomer101Notification(customers101.ToArray(), cancellationToken);
        await SaveCustomer145Notification(customers145.ToArray(), cancellationToken);
    }

    private async Task SaveCustomer2Notification(Customer2[] customers, CancellationToken cancellationToken)
    {
        var tenant = await _tenantRepository.GetByIdAsync(2);

        foreach (var customer in customers)
        {
            var finKey = MakeFinKey(tenant.OrganisationName, customer.GivenName, customer.FamilyName);
            await _notificationsBrokerRepository.AddAsync(new NotificationsBroker
            {
                Email = customer.Email,
                FirstName = customer.GivenName,
                LastName = customer.FamilyName,
                FinHash = finKey
            }, cancellationToken);
        }
    }

    private async Task SaveCustomer101Notification(Customer101[] customers, CancellationToken cancellationToken)
    {
        var tenant = await _tenantRepository.GetByIdAsync(101);

        foreach (var customer in customers)
        {
            var finKey = MakeFinKey(tenant.OrganisationName, customer.FirstName, customer.LastName);
            await _notificationsBrokerRepository.AddAsync(new NotificationsBroker
            {
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                FinHash = finKey
            }, cancellationToken);
        }
    }

    private async Task SaveCustomer145Notification(Customer145[] customers, CancellationToken cancellationToken)
    {
        var tenant = await _tenantRepository.GetByIdAsync(145);

        foreach (var customer in customers)
        {
            var finKey = MakeFinKey(tenant.OrganisationName, customer.Name, customer.Name);
            await _notificationsBrokerRepository.AddAsync(new NotificationsBroker
            {
                Email = customer.Email,
                FirstName = customer.Name,
                LastName = customer.Name,
                FinHash = finKey
            }, cancellationToken);
        }
    }

    private string MakeFinKey(string tenantName, string firstName, string lastName)
    {
        var part1 = firstName.Skip(1).Take(3).Reverse();
        var part2 = lastName.Skip(1).Take(3).Reverse();
        var part3 = string.Join(string.Empty, tenantName.Split(' ').Select(x => x.Take(1)));
        return $"{part1}-{part2}-{part3}";
    }
}
