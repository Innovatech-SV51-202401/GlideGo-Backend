namespace GlideGo_Backend.API.Design.Application.Internal.QueryServices;

public class AlquilerQueryService
{
    private readonly AlquilerService _alquilerService;

    public AlquilerQueryService(AlquilerService alquilerService)
    {
        _alquilerService = alquilerService;
    }

    public IEnumerable<Alquiler> ObtenerAlquileres(ObtenerAlquileresQuery query)
    {
        return _alquilerService.ObtenerAlquileres();
    }

    public Alquiler ObtenerAlquilerPorId(int id)
    {
        return _alquilerService.ObtenerAlquilerPorId(id);
    }
}