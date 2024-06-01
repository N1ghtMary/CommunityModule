namespace DTO.UserDTO;

public class ChangePasswordUserDTO
{
    public string Email { get; set; }
    public string NewPassword { get; set; }
    public string OldPassword { get; set; }
}