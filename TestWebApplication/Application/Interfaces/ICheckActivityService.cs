namespace TestWebApplication.Application.Interfaces;

public interface ICheckActivityService
{
    Task CheckActivity(DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default);
}
