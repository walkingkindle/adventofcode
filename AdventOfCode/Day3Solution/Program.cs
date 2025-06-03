



using System.Text.RegularExpressions;

namespace Day3Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string problem = GetInputValues();

            //var multiplyList = Format(problem);
            //string formattedInput = Format(problem);

            //var multiPlyListFormatedMembers = FormatMembers(multiplyList);
            //var skipDonts = SkipDonts(multiplyList);

            int result = Concactenate(problem);

        }

        private static int SkipDonts(List<string> multiplyList)
        {
            var pattern = @"don't\(\)mul\((\d+),(\d+)\)";
            int result = 0;

            foreach (var member in multiplyList)
            {
                var matches = Regex.Matches(member, pattern);
                foreach (Match match in matches)
                {
                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);

                    result += x * y;
                }
            }
            return result;
        }

        private static int Concactenate(string input)
        {
            int result = 0;
            bool enabled = true;

            var pattern = @"(do\(\)|don't\(\)|mul\(\d+,\d+\))";
            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string token = match.Value;

                if (token == "don't()")
                {
                    enabled = false;
                }
                else if (token == "do()")
                {
                    enabled = true;
                }
                else if (token.StartsWith("mul(") && enabled)
                {
                    var parts = token.Substring(4, token.Length - 5).Split(',');
                    int x = int.Parse(parts[0]);
                    int y = int.Parse(parts[1]);
                    result += x * y;
                }
            }

            return result;
        }


        private static string Format(string input)
        {
            var stringToReplace = new List<string>() { "what()", "who()", "why()", "what()", "when()" };
            foreach (var member in stringToReplace)
            {
                input.Replace(member, "");
            }

            return input;

        }

        //private static List<string> Format(List<List<string>> problem)
        //{
        //    List<string> multiplyList = new List<string>();
        //    foreach(var list in problem)
        //    {
        //        foreach(var member in list)
        //        {
        //            if (member.Contains("mul"))
        //            {
        //                multiplyList.Add(member);
        //            }
        //        }
        //    }
        //    return multiplyList;
        //}

        private static string GetInputValues()
        {
            string fileName = "input.txt";

            List<List<string>> splitLines = new();

            string input = File.ReadAllText("input.txt");
            return input;
        }
    }
}
