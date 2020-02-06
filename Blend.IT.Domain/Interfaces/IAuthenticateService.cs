using Blend.IT.Domain.Models;

namespace Blend.IT.Domain.Interfaces
{
    public interface IAuthenticateService
    {
        User Authenticate(string username, string password);

    }
}
