using Data;
using DTO.UserDTO;

namespace DTO.SubscriptionAuthorDTO;

public class SubscriptionAuthorDTO
{
    public int SubscriptionId { get; set; }
    public bool IsActive { get; set; }
    public int AuthorId { get; set; }
    public int UserId { get; set; }
    //public User User { get; set; }
    //public User Author { get; set; }
    public ShowUserInfoDTO User { get; set; }
}

