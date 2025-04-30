using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class FolderController : ControllerBase
{
    private readonly FolderService _folderService;
    public FolderController(FolderService folderService)
    {
        _folderService = folderService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] Folder folder)
    {
        await _folderService.CreateFolderAsync(folder);
        return Ok();
    }
}
