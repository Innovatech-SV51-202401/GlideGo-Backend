using GlideGo_Backend.API.Design.Domain.Commands;
using GlideGo_Backend.API.Design.Domain.Model.Entities;

namespace GlideGo_Backend.API.Design.Domain.Services;

public interface ILocationCommandService
{
    Task<Location?> Handle(CreateLocationCommand command);
}