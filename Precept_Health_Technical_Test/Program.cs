using HTMLTagSolver;
using System;

namespace Precept_Health_Technical_Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            string htmlText = string.Empty;
            bool isError = false;

            while (htmlText == string.Empty)
            {
                Console.WriteLine("Write HTML lines to find Tag Problem! (i.e) The following text<C><B>is centred and in boldface</B></C>");
                htmlText = Console.ReadLine();
            }

            try
            {
                string error = MissingTag.FindMisMatchOrder(htmlText);
                if (error != string.Empty)
                {
                    Console.WriteLine(error);
                    isError = true;
                }

                error = MissingTag.FindMissingTag(htmlText);
                if (error != string.Empty)
                {
                    Console.WriteLine(error);
                    isError = true;
                }

                if (!isError)
                    Console.WriteLine("Correctly tagged paragraph");

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                Console.ReadKey();
            }
        }
    }
}