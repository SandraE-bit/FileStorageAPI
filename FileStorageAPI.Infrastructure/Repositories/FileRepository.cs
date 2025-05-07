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

    public async Task<FileItem?> GetByIdAsync(Guid fileId, string userId)
    {
        return await _context.Files
            .Where(f => f.Id == fileId && f.UserId == userId)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<FileItem>> GetAllByUserAsync(string userId)
    {
        return await _context.Files
            .Where(f => f.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<FileItem>> GetRootFilesByUserAsync(string userId)
    {
        return await _context.Files
            .Where(f => f.UserId == userId && f.FolderId == null)
            .ToListAsync();
    }

}
