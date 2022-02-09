using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OlSoftware.Infraestructure.Common.Entities;
using OlWebApp.Models;

namespace OlWebApp.Controllers;

public class HomeController : Controller
{
    private const string BASE_URL_PROJECTS = "https://localhost:5004/api/v1";

    private const string BASE_URL_REPORTS = "https://localhost:5002/api/v1";
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClientHandler clientHandler;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
    }

    [HttpGet]
    [Route("/")]
    public async Task<IActionResult> GetClients()
    {
        IEnumerable<Client> clientsList = new List<Client>();
        try
        {
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync(BASE_URL_PROJECTS + "/clients/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    clientsList = JsonConvert.DeserializeObject<IEnumerable<Client>>(apiResponse);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Conseme service");
        }
        return View(clientsList);
    }

    [HttpGet]
    [Route("/crear_cliente")]
    public IActionResult CreateClient()
    {
        return View("FormClient");
    }

    [HttpGet]
    [Route("/editar_cliente/{clientId:int}")]
    public async Task<IActionResult> EditClient(int clientId)
    {
        Client client = new Client();
        try
        {
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync(BASE_URL_PROJECTS + "/clients/" + clientId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    client = JsonConvert.DeserializeObject<Client>(apiResponse);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Conseme service");
        }
        return View("FormClient", client);
    }

    [HttpGet]
    [Route("/clientes/{clientId:int}/proyectos")]
    public async Task<IActionResult> GetProjects(int clientId)
    {
        ViewBag.clientId = clientId;
        IEnumerable<Project> listProjects = new List<Project>();
        try
        {
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync(BASE_URL_PROJECTS + "/clients/" + clientId + "/projects"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listProjects = JsonConvert.DeserializeObject<IEnumerable<Project>>(apiResponse);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Conseme service");
        }
        return View(listProjects);
    }

    [HttpGet]
    [Route("/clientes/{clientId:int}/crear_proyecto")]
    public async Task<IActionResult> CreateProject(int clientId)
    {
        ViewBag.clientId = clientId;
        try
        {
            ViewBag.listLevels = await GetLevelsAsync();
            ViewBag.listStatus = await GetStatusesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Conseme service");
        }
        return View("FormProject");
    }

    [HttpGet]
    [Route("/clientes/{clientId:int}/editar_proyecto/{projectId:int}")]
    public async Task<IActionResult> EditProject(int clientId, int projectId)
    {
        ViewBag.clientId = clientId;
        ViewBag.projectId = projectId;
        var project = new Project();
        try
        {
            ViewBag.listLevels = await GetLevelsAsync();
            ViewBag.listStatus = await GetStatusesAsync();
            using (var httpClient = new HttpClient(clientHandler, false))
            {
                using (var response = await httpClient.GetAsync($"{BASE_URL_PROJECTS}/clients/{clientId}/projects/{projectId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    project = JsonConvert.DeserializeObject<Project>(apiResponse);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Conseme service");
        }
        return View("FormProject", project);
    }

    [HttpGet]
    [Route("/clientes/reporte/{clientId:int}")]
    public async Task<IActionResult> GenerateReport(int clientId)
    {
        var arrayBytes = new List<byte>();
        try
        {
            ViewBag.listLevels = await GetLevelsAsync();
            ViewBag.listStatus = await GetStatusesAsync();
            using (var httpClient = new HttpClient(clientHandler, false))
            {
                using (var response = await httpClient.GetAsync($"{BASE_URL_REPORTS}/reports/generate?clientId={clientId}"))
                {
                    arrayBytes = (await response.Content.ReadAsByteArrayAsync()).ToList();
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error: Conseme service");
        }
        return File(arrayBytes.ToArray(), "application/json");
    }

    private async Task<IEnumerable<Level>> GetLevelsAsync()
    {
        IEnumerable<Level> listLevels = new List<Level>();
        using (var httpClient = new HttpClient(clientHandler, false))
        {
            using (var response = await httpClient.GetAsync(BASE_URL_PROJECTS + "/levels"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                listLevels = JsonConvert.DeserializeObject<IEnumerable<Level>>(apiResponse);
                return listLevels;
            }
        }
    }

    private async Task<IEnumerable<Status>> GetStatusesAsync()
    {
        IEnumerable<Status> listStatus = new List<Status>();
        using (var httpClient = new HttpClient(clientHandler, false))
        {
            using (var response = await httpClient.GetAsync(BASE_URL_PROJECTS + "/status"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                listStatus = JsonConvert.DeserializeObject<IEnumerable<Status>>(apiResponse);
                return listStatus;
            }
        }
    }
}
