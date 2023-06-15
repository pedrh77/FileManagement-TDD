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
                        var add_file = new Files(_query[cont][1], _query[cont][2]);
                        files.Add(add_file);
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
                cont++;
            }
            return result;
        }

        private static Files? FindFileByName(string[] name, List<Files> files)
        {
            return files.Find((file) => file.Name == name[1].ToString());
        }
    }
}
