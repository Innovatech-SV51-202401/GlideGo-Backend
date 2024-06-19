using GlideGo_Backend.API.IAM.Domain.Model.Commands;
using GlideGo_Backend.API.IAM.Interfaces.REST.Resources;

namespace GlideGo_Backend.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    } 
}