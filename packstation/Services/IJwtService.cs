using packstation.Entities;

namespace packstation.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        
    }
}
