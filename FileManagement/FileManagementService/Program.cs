using FileManagementService;

internal class Program
{
    private static void Main(string[] args)
    {
        string[][] fileArray = new string[][] {
            new string[] { "ADD_FILE","/src/main.cpp","20" },
            new string[] { "COPY_FILE", "/src/main.cpp", "/src/main-copy.cpp" },
             new string[] { "GET_FILE_SIZE", "/src/main.cpp" },
              new string[] { "DELETE_FILE", "/src/main-copy.cpp" },
               new string[] { "GET_FILE_SIZE", "/src/main-copy.cpp" },
        };
        var result = FileService.FileInputManagment(fileArray);
        foreach (var i in result)
        {
            Console.WriteLine($"{i} \n");
        }

    }
}