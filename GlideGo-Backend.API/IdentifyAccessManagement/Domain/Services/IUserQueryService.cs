using GlideGo_Backend.API.IdentifyAccessManagement.Domain.Model.Aggregates;
using GlideGo_Backend.API.IdentifyAccessManagement.Domain.Model.Queries;

namespace GlideGo_Backend.API.IdentifyAccessManagement.Domain.Services;

public interface IUserQueryService
{
    Task<User> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);

}