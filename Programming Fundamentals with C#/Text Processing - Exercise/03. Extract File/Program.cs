using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("\\");
            string file = input[input.Length - 1];
        
            int indexOfFileExtension = file.IndexOf(".");
            string fileName = file.Substring(0, indexOfFileExtension);
            string fileExtension = file.Substring(indexOfFileExtension+1, file.Length-(indexOfFileExtension+1));
            Console.WriteLine($"File name: {fileName}\nFile extension: {fileExtension}");
        }
    }
}
