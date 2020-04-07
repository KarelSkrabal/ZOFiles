using System.IO;

namespace DataSource
{
    public static class Helpers
    {
        private static readonly string _postprocesorExtension = ".cgd";
        private static readonly string _postprocesorPrefixName = "NONAME_";
        /// <summary>
        /// Designeted to rename full path of the file given as first parameter. Replaces the name of the file by the same name prefixed as
        /// the second parameter.
        /// </summary>
        /// <param name="path">String representing full file path of the file</param>
        /// <param name="prefix">String representing a prefix</param>
        /// <returns></returns>
        public static string Replace(this string path, string prefix)
        {
            FileInfo fi = new FileInfo(path);
            var fileNameWithoutExtension = fi.Name.Replace(fi.Extension, "");
            return path.Replace(fi.Name, prefix + fileNameWithoutExtension + fi.Extension);
        }

        public static string ReplaceEmptyString(this string companyName, string originalFileName)
        {
            companyName = companyName.TrimEnd();
            if (companyName == string.Empty)
            {
                return _postprocesorPrefixName + originalFileName.Replace(_postprocesorExtension, string.Empty);
            }
            else
                return companyName;
        }
    }
}
