using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly FileService _fileService;

    public FileController(FileService fileService)
    {
        _fileService = fileService;
    }

    [Authorize]
    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromBody] UploadFileDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _fileService.UploadFileAsync(dto, userId!);
        return Ok();
    }
}
