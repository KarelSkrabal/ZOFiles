using DataSource;
using System;
using System.IO;

namespace ZOFiles
{
    class Program
    {
        public enum FileType { settingFile, dataFile };
        static void Main(string[] args)
        {
            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(appPath);

            BaseDataReader<BaseData> reader = Factory.GetReader((int)FileType.settingFile);
            SETTINGS setting = (SETTINGS)reader.ReadData(Path.Combine(directory, @"SETTING.xml"));

            var dataFilePath = Path.Combine(setting.settingrows[0].ZODataPath, setting.settingrows[0].DataFileName);

            reader = Factory.GetReader((int)FileType.dataFile);
            DATA data = (DATA)reader.ReadData(dataFilePath, true);

            FileManipulator fileManipulator = new FileManipulator(data, setting.settingrows[0].LogFilePath)
            {
                OutputPath = setting.settingrows[0].OutputPath,
                FileRepository = setting.settingrows[0].FileRepositoryPath
            };

            fileManipulator.Manipulate();
        }
    }
}
