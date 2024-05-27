using DTO.FavoriteArticleDTO;
using Microsoft.AspNetCore.Mvc;

namespace Repository.FavoriteArticleRepository;

public interface IFavoriteArticleRepository
{
    List<FavoriteArticleDTO> GetAll();
    List<FavoriteArticleDTO> GetUsers(string id);
    Task<IActionResult> Insert(CreateFavoriteArticleDTO dto);
    void Delete(int id);
    void SaveChanges();
}