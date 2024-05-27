namespace DTO.AuthDTO;

public class AuthSignInResponse
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}