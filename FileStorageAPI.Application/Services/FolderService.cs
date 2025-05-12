
using Microsoft.EntityFrameworkCore;

public class FolderService
{
    private readonly IFolderRepository _folderRepo;
    public FolderService(IFolderRepository folderRepo)
    {
        _folderRepo = folderRepo;
    }

    /// <summary>
    /// Create a new folder
    /// </summary>
    public async Task<Guid> CreateFolderAsync(CreateFolderDto dto, string userId)
    {
        var folder = new Folder
        {
            Name = dto.Name,
            UserId = userId,
            ParentFolderId = dto.ParentFolderId
        };

        await _folderRepo.AddAsync(folder);
        return folder.Id;
    }

    /// <summary>
    /// Get all folders for a user
    /// </summary>
    public async Task<IEnumerable<Folder>> GetFoldersForUserAsync(string userId)
    {
        return await _folderRepo.GetAllByUserAsync(userId);
    }
}