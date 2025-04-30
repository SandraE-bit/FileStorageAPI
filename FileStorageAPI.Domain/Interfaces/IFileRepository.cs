public interface IFileRepository
{
    Task<IEnumerable<FileItem>> GetAllByUserAsync(string userId);
    Task AddAsync(FileItem file);
    Task DeleteAsync(FileItem file);
    Task<FileItem?> GetByIdAsync(Guid id, string userId);

}
