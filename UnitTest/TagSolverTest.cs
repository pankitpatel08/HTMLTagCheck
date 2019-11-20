using HTMLTagSolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TagSolverTest
    {
        [TestMethod]
        public void CheckMissingTag()
        {
            string htmlSource = @"<B><C> This should be centred and in boldface, but the tags are wrongly nested </B></C>";
            // act
            string misMatchTag = MissingTag.FindMissingTag(htmlSource);

            // assert
            Assert.AreEqual(string.Empty, misMatchTag);
        }

        [TestMethod]
        public void CheckTagOrder()
        {
            string htmlSource = @"<B><C> This should be centred and in boldface, but the tags are wrongly nested </B></C>";
            // act
            string orderMissingTag = MissingTag.FindMisMatchOrder(htmlSource);

            // assert
            Assert.AreEqual(string.Empty, orderMissingTag);
        }
    }
}
