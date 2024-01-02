using System;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)   (@)   ([a-zA-Z]+([\.\-][A-Za-z]+)+))(\b|(?=\s))";  // (?<user>[A-Za-z0-9]+[-\._]*[A-Za-z0-9]+)/gm
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            if (regex.IsMatch(text))
            {
                foreach (Match email in matches)
                {
                    Console.WriteLine(email);
                }
            }

            //String regex = "^|\\s[a-z0-9][\\.\\_\\-a-z0-9]*[a-z0-9]@[a-z0-9][\\.\\-a-z0-9]*[a-z0-9]\\.[a-z]{2,}";
            //Pattern pattern = Pattern.compile(regex);
            //Matcher matcher = pattern.matcher(input);

            //while (matcher.find())
            //{
            //    sb.append(matcher.group() + "\n");
            //}

            //System.out.println(sb.toString());

            //string patternMeil = @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@[a-z]+\-?[a-z]+(?:\.[a-z]+)+)\b";
            //Regex regexMail = new Regex(patternMeil);
            //MatchCollection matches = regexMail.Matches(text);
            //Console.WriteLine("Found {0} matches", matches.Count);
            //foreach (Match name in matches)
            //{
            //    Console.WriteLine(name.Groups[0]);
            //}
        }
    }
}
