using Microsoft.AspNetCore.Mvc;
using OlSoftware.Infraestructure.Common.Entities;
using OlSoftware.Infraestructure.Data.DataContext;
using OlSoftware.Infraestructure.Data.Repositories;
using OlSoftware.Infraestructure.Generic.Utils;

namespace OlSoftware.Services.Projects.Controllers;

[ApiController]
[Route("api/v1/clients/{clientId:int}/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IUnitOfWork<BaseDbContext> _unitOfWork;
    private readonly ProjectRepository _projectRepository;

    public ProjectsController(ILogger<object> logger, IUnitOfWork<BaseDbContext> unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _projectRepository = new ProjectRepository(unitOfWork);
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllAsync(int clientId)
    {
        try
        {
            var projects = await _projectRepository.GetProjectsByClientAsync(clientId);
            return Ok(projects);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Controller: {nameof(ProjectsController)}; Method: {nameof(GetAllAsync)}");
            return BadRequest();
        }
    }

    [HttpGet]
    [Route("{projectId:int}")]
    public async Task<IActionResult> GetAsync(int clientId, int projectId)
    {
        try
        {
            var project = await _projectRepository.GetProjectsByClientAsync(clientId, projectId);
            return Ok(project);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Controller: {nameof(ProjectsController)}; Method: {nameof(GetAsync)}");
            return BadRequest();
        }
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> InsertAsync(int clientId, [FromBody]Project project)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        try
        {
            project.Client = null;
            project.Status = null;
            project.ClientId = clientId;
            project = await _projectRepository.InsertAsync(project);
            _unitOfWork.Save();
            return Ok(project);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Controller: {nameof(ProjectsController)}; Method: {nameof(InsertAsync)}");
            return BadRequest();
        }
    }

    [HttpPut]
    [Route("{projectId:int}")]
    public async Task<IActionResult> UpdateAsync(int clientId, int projectId, [FromBody]Project project)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        try
        {
            _unitOfWork.CreateTransaction();

            var currentProject = await _projectRepository.GetProjectsByClientAsync(clientId, projectId);
            if (currentProject is null)
            {
                return NotFound();
            }
            currentProject.Name = project.Name;
            currentProject.StartDate = project.StartDate;
            currentProject.EndDate = project.EndDate;
            currentProject.Price = project.Price;
            currentProject.TotalHours = project.TotalHours;
            currentProject.StatusId = project.StatusId;
            _unitOfWork.Save();

            currentProject.Languages = project.Languages;
            _unitOfWork.Save();

            _unitOfWork.Commit();
            return Ok(currentProject);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Controller: {nameof(ProjectsController)}; Method: {nameof(UpdateAsync)}");
            return BadRequest();
        }
    }

    [HttpDelete]
    [Route("{projectId:int}")]
    public async Task<IActionResult> DeleteAsync(int clientId, int projectId)
    {
        try
        {
            var currentProject = await _projectRepository.GetAsync(projectId);
            if (currentProject is null || currentProject.ClientId != clientId)
            {
                return NotFound();
            }
            _projectRepository.Delete(currentProject);
            _unitOfWork.Save();
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Controller: {nameof(ClientsController)}; Method: {nameof(DeleteAsync)}");
            return BadRequest();
        }
    }
}
