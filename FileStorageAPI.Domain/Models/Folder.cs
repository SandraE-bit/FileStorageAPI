using System.ComponentModel.DataAnnotations;

public class Folder
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Name { get; set; } = string.Empty;

    public Guid? ParentFolderId { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    public Folder? ParentFolder { get; set; }
    public ICollection<Folder>? SubFolders { get; set; }
    public ICollection<FileItem>? Files { get; set; }
}
