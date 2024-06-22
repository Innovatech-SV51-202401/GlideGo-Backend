using GlideGo_Backend.API.IAM.Domain.Model.Aggregates;

namespace GlideGo_Backend.API.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    
    Task<int?> ValidateToken(string token);
}