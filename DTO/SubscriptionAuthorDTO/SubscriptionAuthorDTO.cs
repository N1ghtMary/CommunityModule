using Data;
using DTO.UserDTO;

namespace DTO.SubscriptionAuthorDTO;

public class SubscriptionAuthorDTO
{
    public int SubscriptionId { get; set; }
    public bool IsActive { get; set; }
    public string AuthorId { get; set; }
    public string UserId { get; set; }
    //public User User { get; set; }
    //public User Author { get; set; }
    public ShowUserInfoDTO User { get; set; }
    public ShowUserInfoDTO Author { get; set; }
}

