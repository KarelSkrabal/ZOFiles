using DataSource;
using System;
using System.IO;

namespace ZOFiles
{
    public class FileManipulator:IFileManipulator
    {
        private DATA data;
        private string _outputPath = string.Empty;
        private string _fileRepository = string.Empty;

        public string OutputPath
        {
            set => _outputPath = value;
        }

        public string FileRepository
        {
            set
            {
                if (Directory.Exists(value))
                    _fileRepository = value;
            }
        }

        public FileManipulator() { }

        public FileManipulator(DATA data, string path)
        {
            this.data = data;
            Logger.SetPath(path);
            Logger.Log("Run .. " + DateTime.Now.ToString());
        }

        public void Manipulate()
        {
            int counter = 0;
            foreach (var item in data.rows)
            {
                Console.Clear();
                Console.WriteLine("Total files : {0}", data.rows.Length);
                Console.WriteLine("Progress : {0}%", (int)Math.Round((double)(100 * ++counter) / data.rows.Length));
                string logMessage = string.Empty;
                try
                {
                    var customerFolder = item.CustomerName.ReplaceEmptyString(item.OriginalFileName);
                    logMessage = customerFolder;
                    customerFolder = Path.Combine(_outputPath, customerFolder);
                    Directory.CreateDirectory(customerFolder);
                    if (Directory.Exists(customerFolder))
                    {
                        Tuple<string, string> fileNames = GetRealFileName(item);
                        CopyRenameFile(fileNames, customerFolder);
                        Logger.Log("OK..." + logMessage + "#" + fileNames.Item2 + "#" + fileNames.Item1);
                    }
                }
                catch (Exception e)
                {
                    Logger.Log("Erorr : " + logMessage + "..." + e.Message);
                }
            }
        }

        public Tuple<string, string> GetRealFileName(ROW item)
        {
            Tuple<string, string> ret;
            string originalFileName = string.Empty;
            string existingFileName = string.Empty;

            int? lastOccuranceSlash = item.ExistingFileName.LastIndexOf('/');

            if (lastOccuranceSlash.HasValue)
            {
                existingFileName = item.ExistingFileName.Substring(lastOccuranceSlash.Value + 1).TrimEnd();
                if (existingFileName.Equals(item.OriginalFileName))
                {
                    return ret = new Tuple<string, string>(item.OriginalFileName, item.OriginalFileName);
                }

                return ret = new Tuple<string, string>(item.OriginalFileName, existingFileName);
            }
            throw new Exception();
        }

        private void CopyRenameFile(Tuple<string, string> fileNames, string customerFolder)
        {
            File.Copy(Path.Combine(_fileRepository, fileNames.Item2), Path.Combine(customerFolder, fileNames.Item1), true);
        }
    }
}
