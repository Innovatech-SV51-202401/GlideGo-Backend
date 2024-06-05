namespace GlideGo_Backend.API.Design.Domain.Model.Aggregates;

public record Alquiler(int Id, DateTime FechaInicio, DateTime FechaFin, Vehiculo Vehiculo, Propietario Propietario, decimal Precio);