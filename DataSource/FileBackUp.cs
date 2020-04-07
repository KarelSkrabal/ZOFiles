using System.IO;


namespace DataSource
{
    public static class FileBackUp
    {
        private static readonly string backUpPrefix = "backUp";
        public static string BackedUpPath { get; private set; }
        /// <summary>
        /// Creates a new name for the file by prefexing common string
        /// </summary>
        /// <param name="path">String representing full path of the file</param>
        private static void GetBackUpName(string path) => BackedUpPath = path.Replace(FileBackUp.backUpPrefix);
        /// <summary>
        /// Backs up the file in the destination past as parameter. A name of the file will be prefixed by some prefix.
        /// </summary>
        /// <param name="path">The path of the file that will be backed up with prefix</param>
        public static void BackUpFile(string path)
        {
            GetBackUpName(path);
            File.Copy(path, BackedUpPath,true);
        }
    }
}
