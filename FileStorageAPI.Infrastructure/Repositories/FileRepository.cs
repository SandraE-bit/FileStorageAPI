using Microsoft.EntityFrameworkCore;
using FileStorageAPI.Infrastructure.Data;
public class FileRepository : IFileRepository
{
    private readonly AppDbContext _context;

    public FileRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(FileItem file)
    {
        await _context.Files.AddAsync(file);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(FileItem file)
    {
        _context.Files.Remove(file);
        await _context.SaveChangesAsync();
    }

    public async Task<FileItem?> GetByIdAsync(Guid id, string userId)
    {
        return await _context.Files
            .FirstOrDefaultAsync(f => f.Id == id && f.UserId == userId);
    }

    public async Task<IEnumerable<FileItem>> GetAllByUserAsync(string userId)
    {
        return await _context.Files
            .Where(f => f.UserId == userId)
            .ToListAsync();
    }
}
