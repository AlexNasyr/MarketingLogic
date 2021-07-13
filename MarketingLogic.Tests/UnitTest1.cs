using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLogicLib;

namespace MarketingLogic.Tests {
    [TestClass]
    public class MarketingLogicTests {
        void TestExec(string path, string file, int width, int[] expected) {
            MLogic ml = new(path, file);
            var result = ml.GetMedian(width);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod1() {
            TestExec(@"_in\", @"test.txt", 4, new int[] { 123, 123, 88, 11 });
        }
    }
}
