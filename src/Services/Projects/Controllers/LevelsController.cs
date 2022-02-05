using Microsoft.AspNetCore.Mvc;
using OlSoftware.Infraestructure.Common.Entities;
using OlSoftware.Infraestructure.Data.DataContext;
using OlSoftware.Infraestructure.Data.Repositories;
using OlSoftware.Infraestructure.Generic.Utils;

namespace OlSoftware.Services.Projects.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LevelsController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IUnitOfWork<BaseDbContext> _unitOfWork;
    private readonly LevelRepository _levelRepository;

    public LevelsController(ILogger<object> logger, IUnitOfWork<BaseDbContext> unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _levelRepository = new LevelRepository(unitOfWork);
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var levels = await _levelRepository.GetAllAsync(isAsNoTracking: true);
            return Ok(levels);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Controller: {nameof(LevelsController)}; Method: {nameof(GetAllAsync)}");
            return BadRequest();
        }
    }
}