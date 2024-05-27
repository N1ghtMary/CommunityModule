using DTO.AuthDTO;
using Repository.JwtRepository;

namespace Services.JwtService;

public class JwtService(IJwtRepository jwtRepository):IJwtService
{
    public async Task<AuthSignInResponse> CreateToken(AuthSignInDTO dto)
    {
        return await jwtRepository.CreateToken(dto);
    }
}