public interface IFolderRepository
{
    Task<Folder> GetByIdAsync(int id);
    Task<IEnumerable<Folder>> GetAllByUserAsync(string userId);
    Task AddAsync(Folder folder);
}