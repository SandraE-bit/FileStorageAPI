
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
    public async Task CreateFolderAsync(Folder folder)
    {
        await _folderRepo.AddAsync(folder);
    }

    /// <summary>
    /// Get all folders for a user
    /// </summary>
    public async Task<IEnumerable<Folder>> GetFoldersForUserAsync(string userId)
    {
        return await _folderRepo.GetAllByUserAsync(userId);
    }
}