namespace GlideGo_Backend.API.Design.Interfaces.REST.Resources;

public class AlquilerResource
{
    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int VehiculoId { get; set; }
    public int PropietarioId { get; set; }
    public decimal Precio { get; set; }
}

// Interfaces/REST/AlquilerTransformer.cs
public static class AlquilerTransformer
{
    public static AlquilerResource ToResource(this Alquiler alquiler)
    {
        return new AlquilerResource
        {
            Id = alquiler.Id,
            FechaInicio = alquiler.FechaInicio,
            FechaFin = alquiler.FechaFin,
            VehiculoId = alquiler.VehiculoId,
            PropietarioId = alquiler.PropietarioId,
            Precio = alquiler.Precio
        };
    }
}