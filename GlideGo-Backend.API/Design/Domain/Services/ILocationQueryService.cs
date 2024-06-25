using GlideGo_Backend.API.Design.Domain.Model.Entities;
using GlideGo_Backend.API.Design.Domain.Queries;

namespace GlideGo_Backend.API.Design.Domain.Services;

public interface ILocationQueryService
{
    Task<Location?> Handle(GetAllLocationByIdQuery byIdQuery);
    Task<Location?> Handle(GetAllLocationQuery query);
}