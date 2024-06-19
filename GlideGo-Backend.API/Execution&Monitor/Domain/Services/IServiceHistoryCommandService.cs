using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Commands;
using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;

namespace GlideGo_Backend.API.Execution_Monitor.Domain.Services;

public interface IServiceHistoryCommandService
{
    Task<ServiceHistory?> Handle(CreateServiceHistoryCommand command);
}