namespace GlideGo_Backend.API.Design.Domain.Model.Queries;

public record ObtenerAlquileresQuery(DateTime? FechaInicio, DateTime? FechaFin, int? VehiculoId, int? PropietarioId);