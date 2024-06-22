namespace GlideGo_Backend.API.Design.Domain.Model.Commands;

public record CreateVehicleCommand(int IdVehicle, string Category, string SubCategory, int IdOwner);