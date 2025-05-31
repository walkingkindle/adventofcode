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
            int isSafeCount = 0;
            foreach (var report in lists)
            {
                if (CheckForSafeReportsInternal(report))
                {
                    isSafeCount++;
                }
                else
                {
                    for(int i = 0; i < report.Count; i++)
                    {
                        report.RemoveAt(i);
                        if (CheckForSafeReportsInternal(report))
                        {
                            isSafeCount++;
                        }
                    }
                }
            }
            return isSafeCount;
        }

        //I think I am onto something here. I might need recursion for this?

        //This is part 2.


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