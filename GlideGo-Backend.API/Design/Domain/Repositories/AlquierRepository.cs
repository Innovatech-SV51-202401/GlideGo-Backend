namespace GlideGo_Backend.API.Design.Domain.Repositories;

public class AlquierRepository : IAlquilerRepository
{
    private readonly DbContext _dbContext;

    public AlquilerRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Alquiler> ObtenerAlquileres()
    {
        return _dbContext.Alquileres.ToList();
    }

    public Alquiler ObtenerAlquilerPorId(int id)
    {
        return _dbContext.Alquileres.Find(id);
    }

    public void CrearAlquiler(Alquiler alquiler)
    {
        _dbContext.Alquileres.Add(alquiler);
        _dbContext.SaveChanges();
    }

    public void ActualizarAlquiler(Alquiler alquiler)
    {
        _dbContext.Alquileres.Update(alquiler);
        _dbContext.SaveChanges();
    }

    public void EliminarAlquiler(int id)
    {
        var alquiler = ObtenerAlquilerPorId(id);
        _dbContext.Alquileres.Remove(alquiler);
        _dbContext.SaveChanges();
    }
}
