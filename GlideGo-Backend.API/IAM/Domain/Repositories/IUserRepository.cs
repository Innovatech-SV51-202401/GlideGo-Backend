using GlideGo_Backend.API.IAM.Domain.Model.Aggregates;
using GlideGo_Backend.API.Shared.Domain.Repositories;

namespace GlideGo_Backend.API.IAM.Domain.Repositories;

public interface IUserRepository: IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    
    bool ExistsByUsername(string username);
}