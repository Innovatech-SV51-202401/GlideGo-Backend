namespace GlideGo_Backend.API.Design.Domain.Services;

public class AlquilerService : IAlquilerService
{
    private readonly IAlquilerRepository _alquilerRepository;

    public AlquilerService(IAlquilerRepository alquilerRepository)
    {
        _alquilerRepository = alquilerRepository;
    }

    public IEnumerable<Alquiler> ObtenerAlquileres()
    {
        return _alquilerRepository.ObtenerAlquileres();
    }

    public Alquiler ObtenerAlquilerPorId(int id)
    {
        return _alquilerRepository.ObtenerAlquilerPorId(id);
    }

    public void CrearAlquiler(CrearAlquilerCommand command)
    {
        var alquiler = new Alquiler
        {
            FechaInicio = command.FechaInicio,
            FechaFin = command.FechaFin,
            VehiculoId = command.VehiculoId,
            PropietarioId = command.PropietarioId,
            Precio = command.Precio
        };
        _alquilerRepository.CrearAlquiler(alquiler);
    }

    public void ActualizarAlquiler(Alquiler alquiler)
    {
        _alquilerRepository.ActualizarAlquiler(alquiler);
    }

    public void EliminarAlquiler(int id)
    {
        _alquilerRepository.EliminarAlquiler(id);
    }
}
