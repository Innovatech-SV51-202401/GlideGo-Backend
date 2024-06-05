namespace GlideGo_Backend.API.Design.Interfaces.ACL.Services;

public interface IAlquilerService
{
    IEnumerable<Alquiler> ObtenerAlquileres();
    Alquiler ObtenerAlquilerPorId(int id);
    void CrearAlquiler(CrearAlquilerCommand command);
    void ActualizarAlquiler(Alquiler alquiler);
    void EliminarAlquiler(int id);
}