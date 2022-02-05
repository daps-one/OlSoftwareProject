using Microsoft.AspNetCore.Mvc;
using OlSoftware.Infraestructure.Common.Entities;
using OlSoftware.Infraestructure.Data.DataContext;
using OlSoftware.Infraestructure.Data.Repositories;
using OlSoftware.Infraestructure.Generic.Utils;

namespace OlSoftware.Services.Projects.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IUnitOfWork<BaseDbContext> _unitOfWork;
    private readonly ClientRepository _clientRepository;

    public ClientsController(ILogger<object> logger, IUnitOfWork<BaseDbContext> unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _clientRepository = new ClientRepository(unitOfWork);
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var clients = await _clientRepository.GetAllAsync(isAsNoTracking: true);
            return Ok(clients);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Controller: {nameof(ClientsController)}; Method: {nameof(GetAllAsync)}");
            return BadRequest();
        }
    }

    [HttpGet]
    [Route("{clientId:int}")]
    public async Task<IActionResult> GetAsync(int clientId)
    {
        try
        {
            var product = await _clientRepository.GetAsync(clientId, true);
            if (product is null)
                return NotFound();

            return Ok(product);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Controller: {nameof(ClientsController)}; Method: {nameof(GetAsync)}");
            return BadRequest();
        }
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> InsertAsync([FromBody]Client client)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        try
        {
            client.Projects = null;
            client = await _clientRepository.InsertAsync(client);
            _unitOfWork.Save();
            return Ok(client);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Controller: {nameof(ClientsController)}; Method: {nameof(InsertAsync)}");
            return BadRequest();
        }
    }

    [HttpPut]
    [Route("{clientId:int}")]
    public async Task<IActionResult> UpdateAsync(int clientId, [FromBody]Client client)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        try
        {
            var currentClient = await _clientRepository.GetAsync(clientId);
            if (currentClient is null)
            {
                return NotFound();
            }
            currentClient.Name = client.Name;
            currentClient.Identification = client.Identification;
            currentClient.Address = client.Address;
            currentClient.Phone = client.Phone;
            _unitOfWork.Save();
            return Ok(currentClient);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Controller: {nameof(ClientsController)}; Method: {nameof(UpdateAsync)}");
            return BadRequest();
        }
    }

    [HttpDelete]
    [Route("{clientId:int}")]
    public async Task<IActionResult> DeleteAsync(int clientId)
    {
        try
        {
            var currentClient = await _clientRepository.GetAsync(clientId);
            if (currentClient is null)
            {
                return NotFound();
            }
            _clientRepository.Delete(currentClient);
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
