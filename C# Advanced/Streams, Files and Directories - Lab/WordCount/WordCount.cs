namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var dictionary = new SortedDictionary<string, int>();
            string inputWords = File.ReadAllText(wordsFilePath);
            string[] words = inputWords.Split();
            using var writer = new StreamWriter(outputFilePath);

            using (var reader = new StreamReader(textFilePath))
            {
                string currentSentence = reader.ReadLine();

                while (currentSentence != null)
                {
                    foreach (var word in words)
                    {
                        if (currentSentence.ToLower().Contains(word))
                        {

                            if (!dictionary.ContainsKey(word))
                            {
                                dictionary.Add(word, 0);
                                dictionary[word]++;
                            }
                            else
                            {
                                dictionary[word]++;
                            }
                        }
                    }

                    currentSentence = reader.ReadLine();
                }

                foreach (var word in dictionary.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }

        }
    }
}
