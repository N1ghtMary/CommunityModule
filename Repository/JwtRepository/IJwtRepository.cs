using DTO.AuthDTO;

namespace Repository.JwtRepository;

public interface IJwtRepository
{
    Task<AuthSignInResponse> CreateToken(AuthSignInDTO dto);
}