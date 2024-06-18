namespace GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;

public class VehicleUsage
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public Guid UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double TotalDistance { get; set; }
    public decimal MoneySaved { get; set; }

    public VehicleUsage(Guid vehicleId, Guid userId, DateTime startTime, DateTime endTime, double totalDistance, decimal moneySaved)
    {
        Id = Guid.NewGuid();
        VehicleId = vehicleId;
        UserId = userId;
        StartTime = startTime;
        EndTime = endTime;
        TotalDistance = totalDistance;
        MoneySaved = moneySaved;
    }
}