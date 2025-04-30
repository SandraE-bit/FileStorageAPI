using Microsoft.EntityFrameworkCore;
using FileStorageAPI.Infrastructure.Data;
public class FileRepository : IFileRepository
{
    private readonly AppDbContext _context;

    public FileRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(FileItem file) => await _context.Files.AddAsync(file);
    public async Task DeleteAsync(FileItem file) => _context.Files.Remove(file);
    public async Task<FileItem> GetByIdAsync(int id) => await _context.Files.FindAsync(id);
    public async Task<IEnumerable<FileItem>> GetAllByUserAsync(string userId) => await _context.Files.Where(f => f.UserId == userId).ToListAsync();
}
