using System;

namespace code_life_tools
{
   /// <summary>
   /// Main Program of the project
   /// </summary>
    public class Program
    {
        /// <summary>
        /// Main program entry point.s
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("LKR. " + StringTools.ParseIntToCurrency(100000000, StringTools.DigitSeperationType.European).ToString());
            Console.ReadLine();
        }
      
        /// <summary>s
        /// Language Integrated Queries vs Loops test. Loops win, because LINQ is slower (sometimes, most of the time)
        /// </summary>
        public static void LINQvsLoops(string text)
        {
            TimeCapsule.Start();
            Console.WriteLine("LINQ: " + StringTools.numberOfVowelsUsingLINQ(text).ToString());
            Console.WriteLine(TimeCapsule.End().ToString() + " ms");

            TimeCapsule.Start();
            Console.WriteLine("Loops: " + StringTools.numberOfVowelsUsingLoops(text).ToString());
            Console.WriteLine(TimeCapsule.End().ToString() + " ms");

            Console.ReadLine();
        }
    }
}
