using DTO.UserDTO;

namespace DTO.SubscriptionAuthorDTO;

public class ToggleSubscriptionAuthorDTO
{
    public EmailUserDTO Author { get; set; }
    public EmailUserDTO User { get; set; }
}