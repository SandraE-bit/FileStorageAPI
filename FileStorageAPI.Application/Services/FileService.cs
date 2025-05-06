public class FileService
{
    private readonly IFileRepository _fileRepo;

    public FileService(IFileRepository fileRepo)
    {
        _fileRepo = fileRepo;
    }

    /// <summary>
    /// Upload a new file for a specific user
    /// </summary>
    public async Task UploadFileAsync(UploadFileDto dto, string userId)
    {
        var file = new FileItem
        {
            Name = dto.Name,
            Content = dto.Content,
            FolderId = dto.FolderId,
            UserId = userId
        };
        await _fileRepo.AddAsync(file);
    }

    /// <summary>
    /// Get all files owned by the user
    /// </summary>
    public async Task<IEnumerable<FileItem>> GetFilesForUserAsync(string userId)
    {
        return await _fileRepo.GetAllByUserAsync(userId);
    }

    /// <summary>
    /// Delete a file by ID for a specific user
    /// </summary>
    public async Task DeleteFileAsync(Guid fileId, string userId)
    {
        var file = await _fileRepo.GetByIdAsync(fileId, userId);
        if (file == null)
            throw new UnauthorizedAccessException("Cannot delete a file you do not own.");

        await _fileRepo.DeleteAsync(file);
    }

    /// <summary>
    /// Get a file by ID if it belongs to the user
    /// </summary>
    public async Task<FileItem> GetFileByIdAsync(Guid fileId, string userId)
    {
        var file = await _fileRepo.GetByIdAsync(fileId, userId);
        if (file == null)
            throw new UnauthorizedAccessException("File not found or not owned by the user.");

        return file;
    }

}
