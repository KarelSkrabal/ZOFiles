using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataSource;
using ZOFiles;

namespace ZOFilesUnitTests
{
    [TestClass]
    public class FileManipulatorTests
    {
        [TestMethod]
        public void FileManipulator_GetRealFileName_OriginalFileNameAndExistingFilenName_AreNotEqual()
        {
            var testData = new ROW
            {
                CustomerName = "Avia Propeller s.r.o",
                ExistingFileName = "/Files/Upload/Edgecam/0327f9e13aac32ac7a4986b5d490d9b4.cgd",
                OriginalFileName = "VF_HA_14R1_AVIA_V3-1-1.cgd",
                PostName = "HAAS VF3 YT "
            };

            Tuple<string, string> expected = new Tuple<string, string>("VF_HA_14R1_AVIA_V3-1-1.cgd", "0327f9e13aac32ac7a4986b5d490d9b4.cgd");
            Tuple<string, string> result = new FileManipulator().GetRealFileName(testData);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FileManipulator_GetRealFileName_OriginalFileNameAndExistingFilenName_AreEqual()
        {
            var testData = new ROW
            {
                CustomerName = "Avia Propeller s.r.o",
                ExistingFileName = "/Files/Upload/Edgecam/VF_HA_14R1_AVIA_V3-1-1.cgd",
                OriginalFileName = "VF_HA_14R1_AVIA_V3-1-1.cgd",
                PostName = "HAAS VF3 YT "
            };

            Tuple<string, string> expected = new Tuple<string, string>("VF_HA_14R1_AVIA_V3-1-1.cgd", "VF_HA_14R1_AVIA_V3-1-1.cgd");
            Tuple<string, string> result = new FileManipulator().GetRealFileName(testData);
            Assert.AreEqual(expected, result);
        }
    }
}
