public class FileItem
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public byte[] Content { get; set; }
    public int FolderId { get; set; }
    public Folder Folder { get; set; }
    public string UserId { get; set; }
    public AppUser User { get; set; }
}