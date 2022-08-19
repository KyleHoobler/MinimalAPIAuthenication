using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using MinimalAPIAuthentication.Models;
using MinimalAPIAuthentication.Models.Login;
using MinimalAPITest.Services.Authentication;

namespace MinimalAPIAuthentication.EndPoints
{
    [HttpPost("Login"), AllowAnonymous]
    public class LoginEndpoint : Endpoint<LoginRequest, User>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginEndpoint(IAuthenticationService service)
        {
            _authenticationService = service;
        }

        public async override Task HandleAsync(LoginRequest req, CancellationToken ct)
        {
            User currentUser = await _authenticationService.Authenticate(req.Email, req.Password);

            if(currentUser == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(currentUser);
        }
    }
}
