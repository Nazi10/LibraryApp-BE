using LibraryApp.Models;

namespace LibraryApp.Infrastructure.Identity.Authentication;
public interface IAuthentication
{
    public Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
}
