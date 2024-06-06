namespace GlideGo_Backend.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}