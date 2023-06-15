namespace FileManagementService
{
    public class FileService
    {
        public static string[] FileInputManagment(string[][] _query)
        {

            var result = new string[_query.Length];
            var files = new List<Files>();
            var cont = 0;

            foreach (var item in _query)
            {
                if (item[0] == "ADD_FILE")
                {

                    if (FindFileByName(item, files) != null) result[cont] = "null";
                    else
                    {
                       AddNewFile(item[1], item[2], files);
                        result[cont] = "true";

                    }
                }
                else if (item[0] == "GET_FILE_SIZE")
                {
                    var file = FindFileByName(item, files);
                    if (file == null) result[cont] = "null";
                    else result[cont] = file?.Content;
                }
                else if (item[0] == "DELETE_FILE")
                {
                    var file = FindFileByName(item, files);
                    if (file == null) result[cont] = "null";
                    else
                    {
                        files.Remove(file);
                        result[cont] = "deleted";
                    }
                }
                else if (item[0] == "COPY_FILE")
                {
                    var file = FindFileByName(item, files);
                    if (file == null) result[cont] = "null";
                    else
                    {
                       var copy = AddNewFile(item[2], file.Content, files);
                        result[cont] = $"{copy.Name}";
                    }
                }
                cont++;
            }
            return result;
        }

        private static Files? FindFileByName(string[] name, List<Files> files)
        {
            return files.Find((file) => file.Name == name[1].ToString());
        }

        private static Files? AddNewFile(string name, string content,  List<Files> files)
        {
            var add_file = new Files(name, content);
            files.Add(add_file);
            return add_file;
        }
    }
}
