    public class UploadFileDto
    {
        public string Name { get; set; } = string.Empty;
        public byte[] Content { get; set; } = Array.Empty<byte>();
        public Guid? FolderId { get; set; }
    }

