using System;
using DataSource;

namespace ZOFiles
{
    public interface IFileManipulator
    {
        string OutputPath { set; }
        string FileRepository { set; }
        void Manipulate();
        Tuple<string, string> GetRealFileName(ROW item);
    }
}
