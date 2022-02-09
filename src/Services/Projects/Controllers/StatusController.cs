using Microsoft.AspNetCore.Mvc;
using OlSoftware.Infraestructure.Data.DataContext;
using OlSoftware.Infraestructure.Data.Repositories;
using OlSoftware.Infraestructure.Generic.Utils;

namespace OlSoftware.Services.Projects.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StatusController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IUnitOfWork<BaseDbContext> _unitOfWork;
    private readonly StatusRepository _statusRepository;

    public StatusController(ILogger<object> logger, IUnitOfWork<BaseDbContext> unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _statusRepository = new StatusRepository(unitOfWork);
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var status = await _statusRepository.GetAllAsync(isAsNoTracking: true);
            return Ok(status);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Controller: {nameof(LevelsController)}; Method: {nameof(GetAllAsync)}");
            return BadRequest();
        }
    }
}