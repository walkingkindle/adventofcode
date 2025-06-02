



using System.Text.RegularExpressions;

namespace Day3Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> problem = GetInputValues();

            var multiplyList = Format(problem);

            //var multiPlyListFormatedMembers = FormatMembers(multiplyList);
            var skipDonts = SkipDonts(multiplyList);

            int result = Concactenate(multiplyList);

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

        private static int Concactenate(List<string> formattedMembers)
        {
            int result = 0;
            var pattern = @"mul\((\d+),(\d+)\)";
            foreach (var member in formattedMembers)
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

        //private static List<string> FormatMembers(List<string> multiplyList)
        //{
        //    List<string> formattedMembers = new();
        //    foreach(var member in multiplyList)
        //    {
        //      var formattedmember = member.Substring(member.IndexOf("m"));
        //        formattedMembers.Add(formattedmember);
        //    }

        //    return formattedMembers;

        //}

        private static List<string> Format(List<List<string>> problem)
        {
            List<string> multiplyList = new List<string>();
            List<string> dontsList = new List<string>();
            

            foreach(var list in problem)
            {
                foreach(var member in list)
                {
                    if (member.Contains("don't()mul"))
                    {
                        dontsList.Add(member);
                    }

                    if (member.Contains("mul"))
                    {
                        multiplyList.Add(member);
                    }
                }
            }
            return multiplyList;
        }

        private static List<List<string>> GetInputValues()
        {
            string fileName = "input.txt";

            List<List<string>> splitLines = new();
            foreach (var lines in File.ReadAllLines(fileName))
            {
                splitLines.Add(lines.Split("()").ToList());
            }
            return splitLines;
        }
    }
}
