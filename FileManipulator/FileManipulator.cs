using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataSource;

namespace FileManipulator
{
    public class FileManipulator
    {
        private DATA data;

        public FileManipulator(DATA data)
        {
            this.data = data;
        }

        public void Test()
        {
            DirectoryInfo dir = Directory.CreateDirectory(@"D:\Ahoj\Zdar\");
        }

        public void Manipulate()
        {
            foreach (var item in data.rows)
            {
                var test = item.CustomerName + "";
            }
        }
    }
}
