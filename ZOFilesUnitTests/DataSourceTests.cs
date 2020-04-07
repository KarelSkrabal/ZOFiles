using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataSource;

namespace ZOFilesUnitTests
{
    [TestClass]
    public class DataSourceTests
    {
        [TestMethod]
        public void FileBackUp_GetBackUpName_ReturnsBackedUpName()
        {
            var path = @"d:\Nexnet\ZákaznickýPortál\DatapDvornik150318\POSTPROCESORY\TEST1.xml";
            FileBackUp.BackUpFile(path);
            Assert.AreEqual(@"d:\Nexnet\ZákaznickýPortál\DatapDvornik150318\POSTPROCESORY\backUpTEST1.xml", FileBackUp.BackedUpPath);
            }
        }
}
