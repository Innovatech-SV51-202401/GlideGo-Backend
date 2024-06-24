using GlideGo_Backend.API.IAM.Domain.Model.Aggregates;
using GlideGo_Backend.API.IAM.Domain.Repositories;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GlideGo_Backend.API.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context):BaseRepository<User>(context),IUserRepository 
{
    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username));
    }
    
    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>().Any(user => user.Username.Equals(username));
    }
}