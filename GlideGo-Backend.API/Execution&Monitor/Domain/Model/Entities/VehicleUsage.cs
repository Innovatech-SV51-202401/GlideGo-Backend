namespace GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;

public class VehicleUsage(
    Guid vehicleId,
    Guid userId,
    DateTime startTime,
    DateTime endTime,
    double totalDistance,
    decimal moneySaved)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid VehicleId { get; set; } = vehicleId;
    public Guid UserId { get; set; } = userId;
    public DateTime StartTime { get; set; } = startTime;
    public DateTime EndTime { get; set; } = endTime;
    public double TotalDistance { get; set; } = totalDistance;
    public decimal MoneySaved { get; set; } = moneySaved;
}