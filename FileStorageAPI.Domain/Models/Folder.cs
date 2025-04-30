public class Folder
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public ICollection<FileItem> Files { get; set; }
}