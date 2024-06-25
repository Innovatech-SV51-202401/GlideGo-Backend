namespace GlideGo_Backend.API.Design.Domain.Commands;

public record CreatePublicationVehicleCommand(string Title, string Summary, string Category, string SubCategory, int LocationId);
