namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> lists = GetListsFromInput();

            int isSafeCount = CheckSafeReports(lists);
        }


        private static List<List<int>> GetListsFromInput()
        {
            string filename = "input.txt";

            var levelsList = new List<List<int>>();

            foreach (var line in File.ReadAllLines(filename))
            {
                var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var partsList = parts.Select(int.Parse).ToList();

                levelsList.Add(partsList);
            }

            return levelsList;
        }

        private static int CheckSafeReports(List<List<int>> lists)
        {
            return lists.Count(report => CheckForSafeReportsInternal(report) || TryCheckForSafeReportsDampener(report));
        }

        private static bool TryCheckForSafeReportsDampener(List<int> report)
        {
            for (int i = 0; i < report.Count; i++)
            {
                List<int> reportCopy = new List<int>(report);
                reportCopy.RemoveAt(i);
                if (CheckForSafeReportsInternal(reportCopy))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckForSafeReportsInternal(List<int> report)
        {
            var isIncreasing = report.OrderBy(b => b).Distinct().SequenceEqual(report);

            var isDecreasing = report.OrderByDescending(b => b).Distinct().SequenceEqual(report);


            var isSafeConditionTwo = report
                .Zip(report.Skip(1), (a, b) => Math.Abs(a - b))
                .All(diff => diff <= 3);


            return (isIncreasing || isDecreasing) && isSafeConditionTwo;
        }
    }
}