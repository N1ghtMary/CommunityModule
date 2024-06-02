using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data;
using DTO.AuthDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Repository.JwtRepository;

public class JwtRepository(
    IConfiguration configuration,
    UserManager<User> userManager):IJwtRepository
{
    private const int EXPIRATION_MINUTES = 60;
   // private readonly IConfiguration _configuration = configuration;

    private  const string KEY = "02614b771edf7c516e6a8a43aacb26f086f9a21d2a75f833ac7c65437ac924bab29f86f7960d43d7d5d41e7e8e9bad009d465676a72c568fbc3aaea3432b36d27b578c20b0387f07651f4bb651208f2570ba1bb38521b12f722128cc48b182e6978788cc0f59abd854bb8d286acecad6a86866d04552061fefe85a46a3fdceb7f80d1fd66c96826e200c5866b95bba385477df008ab39b49dd6000df2cc5ad15951f333e961ab98aa87759086f49707df912e780119fce9dafecaa23f1e3084d2bf465f59caf41cc092a355482a184c20e74ed3e20f0594a58557a0c4fb09ad02dc06289f11ed6ff4e0cb41295366da84c8001fcb523d5713208c32f59bd5881";
    private  const string ISSUE = "commodul.lan";
    private  const string AUDIENCE = "commodul.lan";
    private  const string SUBJECT = "JWT for commodul.lan";
    
    private JwtSecurityToken CreateJwtToken(
        Claim[] claims,
        SigningCredentials credentials,
        DateTime expiration
    ) => new JwtSecurityToken(
        ISSUE,
        AUDIENCE,
        claims,
        expires:expiration,
        signingCredentials:credentials);

    private Claim[] CreateClaims(User user) => new[]
    {
        new Claim(JwtRegisteredClaimNames.Sub, SUBJECT),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email)
    };

    private SigningCredentials CreateSigningCredentials() => new SigningCredentials(
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY)),
        SecurityAlgorithms.HmacSha256);

    public async Task<AuthSignInResponse> CreateToken(AuthSignInDTO dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);
        if (user == null) return null;
        var isValidPassword = await userManager.CheckPasswordAsync(user, dto.Password);
        if (!isValidPassword) return null;
        var expiration = DateTime.UtcNow.AddMinutes(EXPIRATION_MINUTES);

        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigningCredentials(),
            expiration
            );
        var tokenHandler = new JwtSecurityTokenHandler();

        return new AuthSignInResponse
        {
            Token = tokenHandler.WriteToken(token),
            Expiration = expiration
        };
    }
}