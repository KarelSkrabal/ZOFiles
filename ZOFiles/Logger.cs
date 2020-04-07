using System.IO;

namespace ZOFiles
{
    public class Logger
    {
        private static Logger instance;
        private string logPath;
        private StreamWriter writer;
        private Logger() { }

        public static void Log(string message)
        {
            try
            {
                instance.writer = new StreamWriter(instance.logPath, true, System.Text.Encoding.Default);
                instance.writer.WriteLine(message);
                instance.writer.Flush();
                instance.writer.Close();
            }
            catch (System.Exception)
            {
                throw new System.Exception();
            }
        }

        static public Logger SetPath(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            if (File.Exists(path))
                File.Delete(path);

            if (instance == null)
            {
                instance = new Logger();
                instance.logPath = path;
            }
            return instance;
        }
    }
}