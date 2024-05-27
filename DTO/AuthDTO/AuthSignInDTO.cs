using System.ComponentModel.DataAnnotations;

namespace DTO.AuthDTO;

public class AuthSignInDTO
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}