using OlSoftware.Infraestructure.Common.Entities;
using OlSoftware.Infraestructure.Data.DataContext;
using OlSoftware.Infraestructure.Generic.Utils;
using OlSoftware.Infraestructure.Generic.Utils.BaseRepository;
using Microsoft.EntityFrameworkCore;
using OlSoftware.Infraestructure.Common.Entities.NoMapped;
using Microsoft.Data.SqlClient;

namespace OlSoftware.Infraestructure.Data.Repositories;

public class ProjectRepository : GenericRepository<BaseDbContext, Project>
{
    public ProjectRepository(IUnitOfWork<BaseDbContext> unitOfWork) : base(unitOfWork) { }

    public async Task<IEnumerable<Project>> GetProjectsByClientAsync(int clientId)
    {
        return await _unitOfWork.Context.Projects.AsNoTracking()
            .Include(x => x.Status)
            .Include(x => x.Languages)
            .ThenInclude(x => x.Level)
            .Where(x => x.ClientId == clientId)
            .ToListAsync();
    }

    public async Task<Project> GetProjectsByClientAsync(int clientId, int projectId)
    {
        return await _unitOfWork.Context.Projects
            .Include(x => x.Status)
            .Include(x => x.Languages)
            .ThenInclude(x => x.Level)
            .Where(x => x.ClientId == clientId && x.ProjectId == projectId)
            .SingleOrDefaultAsync();
    }

    public async Task<ClientReport> GetProjectsByClientReportAsync(int clientId)
    {
        var clientReport = new ClientReport();
        var tempProjectsList = new List<TemporalLanguagesReport>();

        var connection = _unitOfWork.Context.Database.GetDbConnection();

        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();

        using (var command = connection.CreateCommand())
        {
            command.CommandText = "EXEC [dbo].[GetProjectsClient] @clientId";
            command.Connection = connection;

            command.Parameters.Add(new SqlParameter("@clientId", clientId));

            using (var dataReader = await command.ExecuteReaderAsync())
            {
                if (dataReader.HasRows)
                {
                    while (await dataReader.ReadAsync())
                    {
                        clientReport.ClientId = (int)dataReader["ClientId"];
                        clientReport.Name = (string)dataReader["Name"];
                        clientReport.Identification = (string)dataReader["Identification"];
                        clientReport.Address = (string)dataReader["Address"];
                        clientReport.Phone = (string)dataReader["Phone"];
                    }
                    await dataReader.NextResultAsync();
                    while (await dataReader.ReadAsync())
                    {
                        tempProjectsList.Add(new TemporalLanguagesReport
                        {
                            ProjectId = (int)dataReader["ProjectId"],
                            ProjectName = (string)dataReader["ProjectName"],
                            StartDate = (DateTime)dataReader["StartDate"],
                            EndDate = (DateTime)dataReader["EndDate"],
                            Price = (int)dataReader["Price"],
                            TotalHours = (int)dataReader["TotalHours"],
                            Status = (string)dataReader["Status"],
                            Language = (string)dataReader["Language"],
                            Level = (string)dataReader["Level"]
                        });
                    }

                    var groupedTempList = tempProjectsList.GroupBy(x => x.ProjectId);
                    foreach (var item in groupedTempList)
                    {
                        var currentProject = item.FirstOrDefault();
                        clientReport.Projects.Add(new ProjectReport
                        {
                            ProjectId = item.Key,
                            ProjectName = currentProject.ProjectName,
                            StartDate = currentProject.StartDate,
                            EndDate = currentProject.EndDate,
                            Price = currentProject.Price,
                            TotalHours = currentProject.TotalHours,
                            Status = currentProject.Status,
                            Languages = item.Select(x => new LanguageReport
                            {
                                Language = x.Language,
                                Level = x.Level
                            })
                        });
                    }
                }
            }
        }

        return clientReport;
    }
}