public class FileItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public byte[] Content { get; set; } = Array.Empty<byte>();

    public Guid? FolderId { get; set; }
    public Folder? Folder { get; set; }

    public string UserId { get; set; } = string.Empty;
    public AppUser? User { get; set; }
}
