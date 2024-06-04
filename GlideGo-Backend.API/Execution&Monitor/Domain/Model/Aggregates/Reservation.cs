using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Commands;
namespace GlideGo_Backend.API.Execution_Monitor.Domain.Model.Aggregates;

public partial class Reservation
{
    public int Id { get; set; }
    public string ClientId { get; set; }
    public string VehicleId { get; set; }
    
    protected Reservation()
    {
        this.ClientId = string.Empty;
        this.VehicleId = string.Empty;
    }
    public Reservation(CreateReservationCommand command)
    {
        this.ClientId = command.ClientId;
        this.VehicleId = command.VehicleId;
    }
}