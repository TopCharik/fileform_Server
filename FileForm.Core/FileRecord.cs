namespace FileForm.Core;

public class FileRecord
{
    public Stream Stream { get; set; }
    public string Filename { get; set; }
    public string ContentType { get; set; } = "application/octet-stream";
    public Dictionary<string, string> Metadata { get; set; }
}