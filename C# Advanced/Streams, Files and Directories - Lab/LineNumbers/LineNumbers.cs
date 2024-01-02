namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamReader sr = new StreamReader(inputFilePath))
            {
                using (StreamWriter sw = new StreamWriter(outputFilePath))
                {
                    int i = 1;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        
                            sw.WriteLine($"{i}. {line}");
                        
                        i++;
                    }
                }
            }
        }
    }
}
