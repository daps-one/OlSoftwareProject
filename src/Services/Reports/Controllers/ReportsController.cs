using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OlSoftware.Infraestructure.Data.DataContext;
using OlSoftware.Infraestructure.Data.Repositories;
using OlSoftware.Infraestructure.Generic.Utils;

namespace OlSoftware.Services.Reports.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly ILogger _logger;

    private readonly IUnitOfWork<BaseDbContext> _unitOfWork;

    private readonly ProjectRepository _projectRepository;

    private readonly string _fullPath;

    public ReportsController(ILogger<object> logger, IUnitOfWork<BaseDbContext> unitOfWork, IWebHostEnvironment env)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _projectRepository = new ProjectRepository(unitOfWork);
        _fullPath = Path.Combine(env.ContentRootPath, "Resources");
    }

    [HttpGet]
    [Route("generate")]
    public async Task<IActionResult> GenerateReportAsync([FromQuery]int clientId)
    {
        try
        {
            var report = await _projectRepository.GetProjectsByClientReportAsync(clientId);
            var outputReport = JsonConvert.SerializeObject(report);
            var bytesReport = Encoding.ASCII.GetBytes(outputReport);
            await System.IO.File.WriteAllBytesAsync(Path.Combine(_fullPath, $"{clientId}.json"), bytesReport);
            return File(bytesReport, "application/json");

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Controller: {nameof(ReportsController)}; Method: {nameof(GenerateReportAsync)}");
            return BadRequest();
        }
    }
}
