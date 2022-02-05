using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OlSoftware.Infraestructure.Data.DataContext;
using OlSoftware.Infraestructure.Generic.Utils;

namespace OlSoftware.Infraestructure.Configuration.Middlewares;
public static class SqlServerServiceCollectionExtensions
{
    public static IServiceCollection AddSqlServerContext(this IServiceCollection services)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer("Server=localhost; Database=Projects;Trusted_Connection=True;"));
        return services;
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        return services;
    }
}
