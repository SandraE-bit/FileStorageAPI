
public class FileService
{
    private readonly IFileRepository _fileRepo;
    public FileService(IFileRepository fileRepo)
    {
        _fileRepo = fileRepo;
    }

    /// <summary>
    /// Upload a new file
    /// </summary>
    public async Task UploadFileAsync(FileItem file)
    {
        await _fileRepo.AddAsync(file);
    }

    /// <summary>
    /// Get all files for a user
    /// </summary>
    public async Task<IEnumerable<FileItem>> GetFilesForUserAsync(string userId)
    {
        return await _fileRepo.GetAllByUserAsync(userId);
    }

    /// <summary>
    /// Delete a file
    /// </summary>
    public async Task DeleteFileAsync(FileItem file)
    {
        await _fileRepo.DeleteAsync(file);
    }
}