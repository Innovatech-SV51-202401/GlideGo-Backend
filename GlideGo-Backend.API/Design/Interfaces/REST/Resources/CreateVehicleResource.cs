namespace GlideGo_Backend.API.Design.Interfaces.REST.Resources;

public record CreateVehicleResource(int IdVehicle, string Category, string Subcategory, int IdOwner);