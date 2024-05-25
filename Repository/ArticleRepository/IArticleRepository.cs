using DTO.ArticleDTO;
using Microsoft.AspNetCore.Mvc;

namespace Repository.ArticleRepository;

public interface IArticleRepository
{
    ArticleDTO Get(int id);
    List<ArticleDTO> GetAll(); 
    Task<IActionResult> Insert(CreateArticleDTO dto);
    Task<IActionResult> Update(UpdateArticleDTO dto);
    Task<IActionResult> Views(int id);
    Task<IActionResult> Delete(int id);
    void SaveChanges();
}