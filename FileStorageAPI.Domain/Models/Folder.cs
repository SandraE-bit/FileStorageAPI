public class Folder
{
    public string UserId { get; set; } = string.Empty;
    public Guid? ParentFolderId { get; set; }
    public Folder? ParentFolder { get; set; }
    public AppUser? User { get; set; }
    public string Name { get; set; } = string.Empty;
   
}