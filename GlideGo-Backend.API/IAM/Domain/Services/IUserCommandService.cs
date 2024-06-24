using GlideGo_Backend.API.IAM.Domain.Model.Aggregates;
using GlideGo_Backend.API.IAM.Domain.Model.Commands;

namespace GlideGo_Backend.API.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);

    Task<(User user, string token)> Handle(SignInCommand command);
}