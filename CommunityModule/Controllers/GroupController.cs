using DTO.GroupDTO;
using Microsoft.AspNetCore.Mvc;
using Services.GroupService;

namespace CommunityModule.Controllers;

[ApiController]
[Route("groups")]
public class GroupController(IGroupService groupService):Controller
{
    [Route("{id}")]
    [HttpGet]
    public JsonResult GetGroup(int id)
    {
        var group = groupService.GetGroup(id);
        return Json(group);
    }
    
    [HttpGet]
    public JsonResult GetGroups()
    {
        var groups = groupService.GetGroups();
        return Json(groups);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateGroup(CreateGroupDTO dto)
    {
        groupService.InsertGroup(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateGroup(UpdateGroupDTO dto)
    {
        groupService.UpdateGroup(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteGroup(int id)
    {
        groupService.DeleteGroup(id);
        return Json("deleted");
    }
}