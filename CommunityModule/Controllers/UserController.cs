using DTO.UserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.UserService;

namespace CommunityModule.Controllers;

[ApiController]
[Route("users")]
public class UserController(IUserService userService):Controller
{
    [Route("{id}")]
    [HttpGet]
    public async Task<JsonResult> GetUser(Guid id)
    {
        var user = await userService.GetUser(id.ToString());
        return  Json(user);
    }
    
    [Authorize]
    [HttpGet]
    public async Task<JsonResult> GetUsers()
    {
        var users = await userService.GetUsers();
        return Json(users);
    }
    
    [Route("create")]
    [HttpPost]
    public async Task<JsonResult> CreateUser(CreateUserDTO dto)
    {
        var result = await userService.InsertUser(dto);
        return Json(result);
    }
    
    [Route("update/updateUserInfo")]
    [HttpPatch]
    public async Task<JsonResult> UpdateUser(UpdateUserDTO dto)
    {
        var result = await userService.UpdateUser(dto);
        return Json(result);
    }

    [Route("update/updatePassword")]
    [HttpPatch]
    public async Task<JsonResult> UpdatePassword(ChangePasswordUserDTO dto)
    {
        var result = await userService.ChangePassword(dto);
        return Json(result);
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteUser(string id)
    {
        userService.DeleteUser(id);
        return Json("deleted");
    }
}