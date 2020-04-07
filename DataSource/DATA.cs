using System;
using System.Xml;
using System.Xml.Serialization;

namespace DataSource
{
    /// <summary>
    /// DTO for copying data from database
    /// </summary>
    [Serializable]
    [XmlRootAttribute("DATA")]
    public class DATA : BaseData
    {
        [XmlElement("ROW")]
        public ROW[] rows { get; set; }
    }

    [Serializable]
    public class ROW
    {
        public string CustomerName { get; set; }
        public string PostName { get; set; }
        public string OriginalFileName { get; set; }
        public string ExistingFileName { get; set; }
    }
}
