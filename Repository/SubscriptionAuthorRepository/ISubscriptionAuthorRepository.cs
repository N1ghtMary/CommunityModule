using Data;
using DTO.SubscriptionAuthorDTO;
using Microsoft.AspNetCore.Mvc;

namespace Repository.SubscriptionAuthorRepository;

public interface ISubscriptionAuthorRepository
{
    List<SubscriptionAuthorDTO> GetAll();
    List<SubscriptionAuthorDTO> GetUsers(string id);
    List<SubscriptionAuthorDTO> GetAuthors(string id);
    Task<IActionResult> ToggleActive(ToggleSubscriptionAuthorDTO dto);
    void SaveChanges();
}