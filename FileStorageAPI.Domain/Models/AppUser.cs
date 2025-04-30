using Microsoft.AspNetCore.Identity;


public class AppUser : IdentityUser
{
    public ICollection<Folder> Folders { get; set; }
    public ICollection<FileItem> Files { get; set; }
}