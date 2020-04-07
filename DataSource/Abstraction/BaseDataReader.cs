using System.IO;
using System.Xml.Serialization;

namespace DataSource
{
    /// <summary>
    /// Base class to read data from data source file
    /// </summary>
    public abstract class BaseDataReader<T> where T: class
    {
        public BaseDataReader() { }

        public virtual T ReadData(string path,bool mustBeBackedUp = false)
        {
            if (mustBeBackedUp)
                FileBackUp.BackUpFile(path);

            T data;
            using (TextReader reader = new StreamReader(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DATA));
                data = (T)serializer.Deserialize(reader);
            }
            return data;
        }
    }
}
