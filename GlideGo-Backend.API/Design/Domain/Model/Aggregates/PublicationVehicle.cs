using GlideGo_Backend.API.Design.Domain.Model.Entities;

namespace GlideGo_Backend.API.Design.Domain.Model.Aggregates;

public partial class PublicationVehicle
{
    public int Id { get; }
    public string Title { get; private set; }
    public string Summary { get; private set; }
    public string Category { get; set; }
    public string SubCategory { get; set; }
    
    public Location Location { get; set; } 
    
    public int LocationId { get; private set; }

    public PublicationVehicle(string title, string summary, string category, string subCategory, int locationId)
    {
        Title = title;
        Summary = summary;
        Category = category;
        SubCategory = subCategory;
        LocationId = locationId;
    }
    
}