using System.IO;
using System.Xml.Serialization;

namespace DataSource
{
    public class PostprocesorsData : BaseDataReader<BaseData>
    {
        public PostprocesorsData() { }

        public override BaseData ReadData(string path, bool mustBeBackedUp)
        {
            if (mustBeBackedUp)
                FileBackUp.BackUpFile(path);

            DATA data;

            using (TextReader reader = new StreamReader(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DATA));
                data = (DATA)serializer.Deserialize(reader);
            }

            return data;
        }
    }

}
