using System;
using System.Xml;
using System.Xml.Serialization;

namespace DataSource
{
    /// <summary>
    /// DTO for settings
    /// </summary>
    [Serializable]
    [XmlRoot("SETTINGS")]
    public class SETTINGS : BaseData
    {
        [XmlElement("SETTINGROW")]
        public SETTINGROW[] settingrows { get; set; }
    }

    public class SETTINGROW
    {
        public string ZODataPath { get; set; }
        public string OutputPath { get; set; }
        public string LogFilePath { get; set; }
        public string FileRepositoryPath { get; set; }
        public string DataFileName { get; set; }
    }
}
