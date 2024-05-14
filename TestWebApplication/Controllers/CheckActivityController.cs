using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Application.Interfaces;

namespace TestWebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class CheckActivityController : ControllerBase
{
    private readonly ILogger<CheckActivityController> _logger;
    private readonly ICheckActivityService _checkActivityService;

    public CheckActivityController(
        ILogger<CheckActivityController> logger,
        ICheckActivityService checkActivityService)
    {
        _logger = logger;
        _checkActivityService = checkActivityService;
    }

    [HttpGet()]
    public void Get(CancellationToken cancellationToken = default)
    {
        _checkActivityService.CheckActivity(new DateTime(2024, 4, 1), new DateTime(2024, 4, 30), default);
    }
}
