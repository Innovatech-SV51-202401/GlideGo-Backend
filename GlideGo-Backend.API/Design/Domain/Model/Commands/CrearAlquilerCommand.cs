namespace GlideGo_Backend.API.Design.Domain.Model.Commands;

public record CrearAlquilerCommand(DateTime FechaInicio, DateTime FechaFin, int VehiculoId, int PropietarioId, decimal Precio);