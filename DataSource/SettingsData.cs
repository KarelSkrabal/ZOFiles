using System.IO;
using System.Xml.Serialization;

namespace DataSource
{
    class SettingsData : BaseDataReader<BaseData>
    {
        public override BaseData ReadData(string path, bool mustBeBackedUp)
        {
            SETTINGS data;
            using (TextReader reader = new StreamReader(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SETTINGS));
                data = (SETTINGS)serializer.Deserialize(reader);
            }
            return data;
        }
    }
}
