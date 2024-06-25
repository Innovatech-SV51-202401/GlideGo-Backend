using GlideGo_Backend.API.Design.Domain.Model.Aggregates;
using GlideGo_Backend.API.Design.Domain.Model.Entities;
using GlideGo_Backend.API.Design.Domain.Model.ValueObjects;
using GlideGo_Backend.API.Design.Domain.Repositories;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GlideGo_Backend.API.Design.Infrastructure.Persistence.EFC.Repositorie;

public class PublicationRepository(AppDbContext context) : BaseRepository<Publication>(context) , IPublicationRepository
{
    public new async Task<PublicationVehicle?> FindByIdAsync(int id) => 
        await Context.Set<PublicationVehicle>().Include(p => p.Location)
        .Where(p => p.Id == id).FirstOrDefaultAsync();
    
    public new async Task<IEnumerable<PublicationVehicle>> ListAsync() => 
        await Context.Set<PublicationVehicle>().Include( pu=> pu.Location).ToListAsync();
    
    
    public Task AddAsync(PublicationVehicle entity)
    {
        throw new NotImplementedException();
    }
    

    public void Update(PublicationVehicle entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(PublicationVehicle entity)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<PublicationVehicle>> FindByIdOwner(int idLocation) =>
        await Context.Set<PublicationVehicle>().Include(p => p.LocationId)
            .Where(p => p.LocationId == idLocation).ToListAsync();

    public Task<IEnumerable<PublicationVehicle>> FindByStatus(EPublicStatus status)
    {
        throw new NotImplementedException();
    }
}