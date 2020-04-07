using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace DataSource
{
    public class XmlFileFormatter : IxmlDataReader
    {
        private readonly string _path;
        private readonly Regex rgx = new Regex("&(?![a-zA-Z]{2,6};|#[0-9]{2,4};)");
        private readonly string goodString = "&amp;";

        public XmlFileFormatter(string path) => this._path = path;

        public void FormatFile()
        {
            string[] originalLines = File.ReadAllLines(this._path);
            StringBuilder formatedLines = new StringBuilder();

            foreach (var line in originalLines)
            {
                formatedLines.AppendLine(rgx.Replace(line, goodString));
            }

            File.WriteAllText(this._path, formatedLines.ToString());
        }
    }
}
