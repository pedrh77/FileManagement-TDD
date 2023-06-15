namespace FileManagementService
{
    public class Files
    {
        public string? Name { get; set; }
        public string? Content { get; set; } = null;

        public Files(string? name, string? content)
        {
            Name = name;
            Content = content;
        }
    }
}

