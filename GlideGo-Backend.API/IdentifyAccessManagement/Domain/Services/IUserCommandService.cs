using GlideGo_Backend.API.IdentifyAccessManagement.Domain.Model.Aggregates;
using GlideGo_Backend.API.IdentifyAccessManagement.Domain.Model.Commands;
namespace GlideGo_Backend.API.IdentifyAccessManagement.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}