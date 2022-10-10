public class Document
{
    public string Name { get; private set; }
    public string FullPath { get; private set; }
    public DateTime CreationTime { get; private set; }

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