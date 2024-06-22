using GlideGo_Backend.API.IAM.Domain.Model.Aggregates;
using GlideGo_Backend.API.IAM.Domain.Model.Queries;

namespace GlideGo_Backend.API.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    
    Task<User?> Handle(GetUserByUsernameQuery query);
    
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
}