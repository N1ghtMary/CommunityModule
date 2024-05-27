using DTO.AuthDTO;

namespace Services.JwtService;

public interface IJwtService
{
    Task<AuthSignInResponse> CreateToken(AuthSignInDTO dto);
}