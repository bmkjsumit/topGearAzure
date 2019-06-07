using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algo.Test
{
    [TestClass]
    public class HexFileTests
    {
        [TestMethod]
        public void HexFile_Constructor()
        {
            //https://www.youtube.com/watch?v=KKiG5NJkqXs
            //https://docs.microsoft.com/en-us/visualstudio/test/using-shims-to-isolate-your-application-from-other-assemblies-for-unit-testing?view=vs-2019
            using (ShimsContext.Create())
            {
                //Arrange
                System.IO.Fakes.ShimFile.ReadAllLinesString = s => new string[] { "1", "1", "1" };
                //System.Fakes.ShimDateTime.NowGet = () =>   { return new DateTime(fixedYear, 1, 1); };
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2000, 1, 1);
                //Act
                var target = new HexFile("fake.path");                 
                Y2KChecker.Check();
                //Assert
                Assert.AreEqual(3, target.Record.Length);

            }
        }
    }
}
