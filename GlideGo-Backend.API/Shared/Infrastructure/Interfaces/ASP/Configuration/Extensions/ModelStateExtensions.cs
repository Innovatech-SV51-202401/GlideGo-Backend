using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GlideGo_Backend.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public static class ModelStateExtensions
{
    public static List<string> GetErrorsMessages(this ModelStateDictionary dictionary)
    {
        return dictionary
            .SelectMany(m => m.Value!.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
}