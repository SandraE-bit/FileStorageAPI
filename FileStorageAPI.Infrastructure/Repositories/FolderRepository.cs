using Microsoft.EntityFrameworkCore;
using FileStorageAPI.Infrastructure.Data;
public class FolderRepository : IFolderRepository
{
    private readonly AppDbContext _context;

    public FolderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Folder folder) => await _context.Folders.AddAsync(folder);
    public async Task<Folder?> GetByIdAsync(Guid folderId, string userId)
    {
        return await _context.Folders
            .FirstOrDefaultAsync(f => f.Id == folderId && f.UserId == userId);
    }
    public async Task<IEnumerable<Folder>> GetAllByUserAsync(string userId) => await _context.Folders.Where(f => f.UserId == userId).ToListAsync();
}
