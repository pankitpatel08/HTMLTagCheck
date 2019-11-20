using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTMLTagSolver;

namespace UnitTest
{
    [TestClass]
    public class RegexTest
    {
        [TestMethod]
        public void OpenTagTest()
        {
            string html = "<B><C> This should be centred and in boldface, but the tags are wrongly nested </B></C>";
            string[] openTag = RegexSplitter.OpenTagSplit(html);

            bool isOpenTag = true;
            foreach (var tagO in openTag)
            {
                if (tagO.StartsWith("<") == true && tagO.EndsWith(">"))
                    isOpenTag = tagO.Contains("/") ? false : true;
            }

            // assert
            Assert.AreEqual(true, isOpenTag);
        }

        [TestMethod]
        public void CloseTagTest()
        {
            string html = "<B><C> This should be centred and in boldface, but the tags are wrongly nested </B></C>";
            string[] closeTag = RegexSplitter.CloseTagSplit(html);

            bool isCloseTag = true;
            foreach (var tagO in closeTag)
            {
                if (tagO.StartsWith("<") == true && tagO.EndsWith(">"))
                    isCloseTag = tagO.Contains("/") ? true : false;
            }
            // assert
            Assert.AreEqual(true, isCloseTag);
        }
    }
}
