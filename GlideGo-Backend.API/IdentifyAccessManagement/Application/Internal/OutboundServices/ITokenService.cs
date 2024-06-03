namespace GlideGo_Backend.API.IdentifyAccessManagement.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    
    Task<int?> validateToken(string token);
}