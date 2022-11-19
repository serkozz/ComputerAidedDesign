public class Document
{
    public string Name { get; }
    public string FullPath { get; }
    public DateTime CreationTime { get; }

    public Document ()
    {
        Name = string.Empty;
        FullPath = string.Empty;
        CreationTime = DateTime.Now;
    }
    public Document(string name, string fullPath)
    {
        Name = name;
        FullPath = fullPath;
        CreationTime = DateTime.Now;
    }
}