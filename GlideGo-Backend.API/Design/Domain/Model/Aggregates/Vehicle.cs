using GlideGo_Backend.API.Design.Domain.Model.Commands;
using GlideGo_Backend.API.Design.Domain.Model.Entities;

namespace GlideGo_Backend.API.Design.Domain.Model.Aggregates;

public partial class Vehicle
{
    public int Id {get; set; }
    public string Category {get; set; }
    public string SubCategory {get; set; }
    
    public int IdVehicle {get; set; }
    
    public int IdOwner {get; set; }

    protected Vehicle()
    {
        this.IdVehicle= 0;
        this.Category = String.Empty;
        this.SubCategory = String.Empty;
        this.IdOwner= 0;
    }
    public Vehicle(CreateVehicleCommand command)
    {
        this.IdVehicle= command.IdVehicle;
        this.Category = command.Category;
        this.SubCategory = command.SubCategory;
        this.IdOwner= command.IdOwner;
    }
}