namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            string[] inputOne = File.ReadAllText(firstInputFilePath).Split("\r\n",StringSplitOptions.RemoveEmptyEntries);
            string[] inputTwo = File.ReadAllText(secondInputFilePath).Split("\r\n",StringSplitOptions.RemoveEmptyEntries);
            File.WriteAllText(outputFilePath, "");
            for (int i = 0; i < inputOne.Length; i++)
            {
                File.AppendAllText(outputFilePath, inputOne[i] + Environment.NewLine + inputTwo[i] + Environment.NewLine);
            }
        }
    }
}
