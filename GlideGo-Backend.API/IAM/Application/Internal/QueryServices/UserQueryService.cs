using GlideGo_Backend.API.IAM.Domain.Model.Aggregates;
using GlideGo_Backend.API.IAM.Domain.Model.Queries;
using GlideGo_Backend.API.IAM.Domain.Repositories;
using GlideGo_Backend.API.IAM.Domain.Services;

namespace GlideGo_Backend.API.IAM.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }
    
    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
    
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }
}