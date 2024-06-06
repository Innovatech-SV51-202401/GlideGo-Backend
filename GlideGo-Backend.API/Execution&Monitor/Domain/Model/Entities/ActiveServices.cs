namespace GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;

public class ActiveServices(int vehicleId, Guid distanceToUse, Guid durationToUse, Guid location)
{
    public int VehicleId { get; set; } = vehicleId;

    public Guid DistanceToUse { get; set; } = distanceToUse;

    public Guid DurationToUse { get; set; } = durationToUse;

    public Guid Location { get; set; } = location;
}