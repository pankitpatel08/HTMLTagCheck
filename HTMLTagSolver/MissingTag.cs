using System.Collections;

namespace HTMLTagSolver
{
    public class MissingTag
    {
        /// <summary>
        /// Find the Mis Match order or tag for HTML String
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FindMisMatchOrder(string source)
        {
            Stack stck = new Stack();
            string error = string.Empty;
            var openTag = RegexSplitter.OpenTagSplit(source); // <B>, <C>
            var closeTag = RegexSplitter.CloseTagSplit(source); // </B>, </C>

            if (openTag != null)
            {
                foreach (var tagO in openTag)
                {
                    if (tagO.StartsWith("<") == true && tagO.EndsWith(">"))
                        stck.Push(tagO.Replace("<", string.Empty).Replace(">", string.Empty));
                }
            }

            if (closeTag != null)
            {
                foreach (var tagC in closeTag)
                {
                    if (tagC.StartsWith("</") == true && tagC.EndsWith(">"))
                    {
                        string tagCString = tagC.Replace("</", string.Empty).Replace(">", string.Empty);
                        if (tagCString == stck.Peek().ToString())
                        {
                            stck.Pop();
                            if (stck.Count == 0) // if stack empty then break the loop
                                break;
                        }
                        else
                        {
                            error = "Expected </" + stck.Peek().ToString() + "> found </" + tagCString + "> ";
                        }
                    }
                    if (error != string.Empty)
                    {
                        break;
                    }
                }
            }
            return error;
        }

        /// <summary>
        /// Find Missing Tag in HTML Content
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FindMissingTag(string source)
        {
            ArrayList aryLst = new ArrayList();
            string error = string.Empty;
            var openTag = RegexSplitter.OpenTagSplit(source); // <B>, <C>
            var closeTag = RegexSplitter.CloseTagSplit(source); // </B>, </C>

            if (openTag != null)
            {
                foreach (var tagO in openTag)
                {
                    if (tagO.StartsWith("<") == true && tagO.EndsWith(">"))
                        aryLst.Add(tagO);
                }
            }

            if (closeTag != null)
            {
                foreach (var tagC in closeTag)
                {
                    if (tagC.StartsWith("</") == true && tagC.EndsWith(">"))
                    {
                        if (aryLst.Contains(tagC.Replace("</", "<")))
                            aryLst.Remove(tagC.Replace("</", "<"));
                        else
                            aryLst.Add(tagC);
                    }
                }
            }

            if (aryLst.Count > 0)
            {
                // Missing Opening Tag
                if (aryLst[0].ToString().Contains("/"))
                    error = "Expected # found " + aryLst[0].ToString() + " ";
                else // Missing Closing Tag
                    error = "Expected " + aryLst[0].ToString().Substring(0, 1) + "/" + aryLst[0].ToString().Substring(1) + " found #";
            }

            return error;
        }
    }
}
