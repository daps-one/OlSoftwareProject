using OlSoftware.Infraestructure.Common.Entities;
using OlSoftware.Infraestructure.Data.DataContext;
using OlSoftware.Infraestructure.Generic.Utils;
using OlSoftware.Infraestructure.Generic.Utils.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace OlSoftware.Infraestructure.Data.Repositories;

public class ClientRepository : GenericRepository<BaseDbContext, Client>
{
    public ClientRepository(IUnitOfWork<BaseDbContext> unitOfWork) : base(unitOfWork) { }
}