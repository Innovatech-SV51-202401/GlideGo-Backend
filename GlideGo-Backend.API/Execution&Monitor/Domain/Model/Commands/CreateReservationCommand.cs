namespace GlideGo_Backend.API.Execution_Monitor.Domain.Model.Commands;

public record CreateReservationCommand(string ClientId, string VehicleId);