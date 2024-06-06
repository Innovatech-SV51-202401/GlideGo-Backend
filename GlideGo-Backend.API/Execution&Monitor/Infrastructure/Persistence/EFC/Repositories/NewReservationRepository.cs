using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Aggregates;
using GlideGo_Backend.API.Execution_Monitor.Domain.Repositories;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;


namespace GlideGo_Backend.API.Execution_Monitor.Infrastructure.Persistence.EFC.Repositories
{
    public class NewReservationRepository : BaseRepository<Reservation>, INewReservationRepository
    {
        public NewReservationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Reservation?> FindByVehicleIdAsync(string vehicleId)
        {
            return await Context.Set<Reservation>().FirstOrDefaultAsync(r => r.VehicleId == vehicleId);
        }

        public async Task<IEnumerable<Reservation>> FindAllByVehicleIdAsync(string vehicleId)
        {
            return await Context.Set<Reservation>().Where(r => r.VehicleId == vehicleId).ToListAsync();
        }
    }
}