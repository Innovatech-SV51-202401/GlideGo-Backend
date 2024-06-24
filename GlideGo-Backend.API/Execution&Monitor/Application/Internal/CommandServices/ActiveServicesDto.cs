namespace GlideGo_Backend.API.Execution_Monitor.Application.Internal.CommandServices;

public class ActiveServicesDto
{
    public Guid VehicleId { get; set; }
    
    public Guid DistanceToUse { get; set; }
    
    public Guid DurationToUse { get; set; }
    
    public Guid Location { get; set; }
}