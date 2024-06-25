using GlideGo_Backend.API.Design.Domain.Model.Aggregates;

namespace GlideGo_Backend.API.Design.Domain.Model.Entities;

public class Location(double latitude, double longitude, string addressPickUp)
{
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string AddressPickUp { get; set; }
    
    public ICollection<PublicationVehicle> PublicationVehicles { get; }
}