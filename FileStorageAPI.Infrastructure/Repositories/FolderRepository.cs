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
    public async Task<Folder> GetByIdAsync(int id) => await _context.Folders.FindAsync(id);
    public async Task<IEnumerable<Folder>> GetAllByUserAsync(string userId) => await _context.Folders.Where(f => f.UserId == userId).ToListAsync();
}
