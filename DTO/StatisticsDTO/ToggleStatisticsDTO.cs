using DTO.UserDTO;

namespace DTO.StatisticsDTO;

public class ToggleStatisticsDTO
{
    public int ArticleId { get; set; }
    //public string UserId { get; set; }
    public EmailUserDTO User { get; set; }
}