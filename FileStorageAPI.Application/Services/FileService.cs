public class FileService
{
    private readonly IFileRepository _fileRepo;
    private readonly IFolderRepository _folderRepo;

    public FileService(IFileRepository fileRepo, IFolderRepository folderRepo)
    {
        _fileRepo = fileRepo;
        _folderRepo = folderRepo;
    }

    /// <summary>
    /// Upload a new file for a specific user
    /// </summary>
    public async Task UploadFileAsync(UploadFileDto dto, string userId)
    {
        if (dto.FolderId.HasValue)
        {
            var folder = await _folderRepo.GetByIdAsync(dto.FolderId.Value, userId);
            if (folder == null)
                throw new Exception("Folder does not exist or does not belong to you.");
        }

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

    /// <summary>
    /// Get all files for the user that are not in any folder (root-level files)
    /// </summary>
    public async Task<IEnumerable<FileItem>> GetRootFilesAsync(string userId)
    {
        var allFiles = await _fileRepo.GetAllByUserAsync(userId);
        return allFiles.Where(f => f.FolderId == null);
    }

}
