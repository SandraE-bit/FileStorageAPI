using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FolderController : ControllerBase
{
    private readonly FolderService _folderService;

    public FolderController(FolderService folderService)
    {
        _folderService = folderService;
    }

    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> Upload([FromBody] CreateFolderDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _folderService.CreateFolderAsync(dto, userId!);
        return Ok();
    }

}
