using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly FileService _fileService;
    public FileController(FileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromBody] FileItem file)
    {
        await _fileService.UploadFileAsync(file);
        return Ok();
    }
}
