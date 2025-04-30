public interface IFileRepository
{
    Task<FileItem> GetByIdAsync(int id);
    Task<IEnumerable<FileItem>> GetAllByUserAsync(string userId);
    Task AddAsync(FileItem file);
    Task DeleteAsync(FileItem file);
}
