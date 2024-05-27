using DTO.AuthDTO;
using Microsoft.AspNetCore.Mvc;
using Services.JwtService;

namespace CommunityModule.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IJwtService jwtService):Controller
{
    [Route("signin")]
    public async Task<ActionResult> SignIn(AuthSignInDTO dto)
    {
        var authData = await jwtService.CreateToken(dto);
        if (authData == null) return Json("User not found or entered invalid password");
        return Json(authData);
    }
}