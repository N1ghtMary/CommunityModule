using DTO.UserDTO;

namespace DTO.FavoriteArticleDTO;

public class CreateFavoriteArticleDTO
{
    public int FavoriteId { get; set; }
    public int ArticleId { get; set; }
    //public string UserId { get; set; }
    public ShowUserInfoDTO User { get; set; }
}