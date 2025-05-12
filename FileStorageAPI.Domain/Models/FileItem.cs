using System.ComponentModel.DataAnnotations;

public class FileItem
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public byte[] Content { get; set; } = Array.Empty<byte>();

    [Required]
    public Guid FolderId { get; set; }

    public Folder? Folder { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;
}
