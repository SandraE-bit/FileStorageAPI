public interface IFolderRepository
{
    Task<Folder?> GetByIdAsync(Guid folderId, string userId);
    Task<IEnumerable<Folder>> GetAllByUserAsync(string userId);
    Task AddAsync(Folder folder);
}