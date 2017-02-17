using System;

namespace Utils
{
    public static class Helper
    {
        public static void WriteSuccess(string text)
        {
            //Console.WriteLine($"SUCCESS: {text}");
            Console.WriteLine(string.Format("SUCCESS: {0}", text));
        }
        public static void WriteError(string text)
        {
            //Console.WriteLine($"ERROR: {text}");
            Console.WriteLine(string.Format("ERROR: {0}", text));
        }
        public static void WriteInfo(string text)
        {
            //Console.WriteLine($"INFO: {text}");
            Console.WriteLine(string.Format("INFO: {0}", text));
        }
        public static void WriteChild(string text)
        {
            //Console.WriteLine($"  ---  {text}");
            Console.WriteLine(string.Format("  ---  {0}", text));
        }
        public static void WriteCheck(string text)
        {
            //Console.WriteLine($"  ---  {text}");
            Console.WriteLine(string.Format("CHECK: {0}", text));
        }
    }
}
