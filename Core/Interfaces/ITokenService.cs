using Core.Entities.Identity;

namespace Core;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
