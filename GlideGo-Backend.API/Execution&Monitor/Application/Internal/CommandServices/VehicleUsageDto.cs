namespace GlideGo_Backend.API.Execution_Monitor.Application.Internal.CommandServices;

public class VehicleUsageDto
{
    public Guid VehicleId { get; set; }
    public Guid UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double TotalDistance { get; set; }
    public decimal MoneySaved { get; set; }
}