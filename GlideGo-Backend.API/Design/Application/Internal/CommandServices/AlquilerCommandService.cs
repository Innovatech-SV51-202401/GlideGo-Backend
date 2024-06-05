namespace GlideGo_Backend.API.Design.Application.Internal.CommandServices;

public class AlquilerCommandService
{
    private readonly AlquilerService _alquilerService;

    public AlquilerCommandService(AlquilerService alquilerService)
    {
        _alquilerService = alquilerService;
    }

    public void CrearAlquiler(CrearAlquilerCommand command)
    {
        _alquilerService.CrearAlquiler(command);
    }

    public void ActualizarAlquiler(int id, CrearAlquilerCommand command)
    {
        var alquiler = _alquilerService.ObtenerAlquilerPorId(id);
        alquiler.FechaInicio = command.FechaInicio;
        alquiler.FechaFin = command.FechaFin;
        alquiler.VehiculoId = command.VehiculoId;
        alquiler.PropietarioId = command.PropietarioId;
        alquiler.Precio = command.Precio;
        _alquilerService.ActualizarAlquiler(alquiler);
    }

    public void EliminarAlquiler(int id)
    {
        _alquilerService.EliminarAlquiler(id);
    }
}