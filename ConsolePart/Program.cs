using System;

namespace ConsolePart
{
    class Program
    {
        static void Main(string[] args)
        {
            string workText;
            int widthText;
            Console.WriteLine("Input Text:");
            workText=Console.ReadLine();
            Console.WriteLine("Input Width Text Needed:");
            widthText=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Justification.doJust(workText,widthText));
            Console.ReadKey();
        }
    }
}
