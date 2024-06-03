using GlideGo_Backend.API.IdentifyAccessManagement.Domain.Model.Aggregates;
using GlideGo_Backend.API.Shared.Domain.Repositories;

namespace GlideGo_Backend.API.IdentifyAccessManagement.Domain.Repositories;

public interface IUserRepository: IBaseRepository<User>
{
    Task<User?> FinByUsername(string username);
    bool ExistByUsername(string username);
}