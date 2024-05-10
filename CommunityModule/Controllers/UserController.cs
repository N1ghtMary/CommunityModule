using DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Services.UserService;

namespace CommunityModule.Controllers;

[ApiController]
[Route("users")]
public class UserController(IUserService userService):Controller
{
    [Route("{id}")]
    [HttpGet]
    public JsonResult GetUser(int id)
    {
        var user = userService.GetUser(id);
        return Json(user);
    }
    
    [HttpGet]
    public JsonResult GetUsers()
    {
        var users = userService.GetUsers();
        return Json(users);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateUser(CreateUserDTO dto)
    {
        userService.InsertUser(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateUser(UpdateUserDTO dto)
    {
        userService.UpdateUser(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteUser(int id)
    {
        userService.DeleteUser(id);
        return Json("deleted");
    }
}