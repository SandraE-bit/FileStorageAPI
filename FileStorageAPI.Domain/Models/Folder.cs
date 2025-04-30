public class Folder
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string UserId { get; set; } 

    public List<FileItem> Files { get; set; } = new();

    public List<Folder> SubFolders { get; set; } = new(); 

    public Guid? ParentFolderId { get; set; } 
    public Folder? ParentFolder { get; set; }
}
