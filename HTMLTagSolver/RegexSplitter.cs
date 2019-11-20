using System.Linq;
using System.Text.RegularExpressions;

namespace HTMLTagSolver
{
    public class RegexSplitter
    {
        /// <summary>
        /// Open Tag Splitter
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string[] OpenTagSplit(string source)
        {
            // For string with lowercase tag such as <b>
            if (Regex.IsMatch(source, @"(<[A-Z]*>)"))
            {
                string[] openTag = Regex.Split(source, @"(<[A-Z]+[A-Z]*>)").Where(l => l != string.Empty).ToArray(); // <B>, <C>
                return openTag;
            }
            else
                return null;
        }

        /// <summary>
        /// Close Tag Splitter
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string[] CloseTagSplit(string source)
        {
            if (Regex.IsMatch(source, @"(<[A-Z]*>)"))
            {
                string[] closeTag = Regex.Split(source, @"(</[A-Z]+[A-Z]*>)").Where(l => l != string.Empty).ToArray(); // </B>, </C>
                return closeTag;
            }
            else
                return null;
        }
    }
}
