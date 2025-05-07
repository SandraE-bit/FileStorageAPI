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

    [Authorize]
    [HttpGet("download/{id}")]
    public async Task<IActionResult> Download(Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var file = await _fileService.GetFileByIdAsync(id, userId!);

        return File(file.Content, "application/octet-stream", file.Name);
    }

    [Authorize]
    [HttpGet("root")]
    public async Task<ActionResult<IEnumerable<FileItem>>> GetRootFiles()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var files = await _fileService.GetRootFilesAsync(userId!);
        return Ok(files);
    }

    [Authorize]
    [HttpDelete("delete/{fileId}")]
    public async Task<IActionResult> DeleteFile(Guid fileId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        try
        {
            await _fileService.DeleteFileAsync(fileId, userId!);
            return Ok("File deleted successfully.");
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
    }

}
