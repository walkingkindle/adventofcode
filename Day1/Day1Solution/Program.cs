using System;

namespace Day1Solution
{
    public class Program
    {
        static void Main(string[] args)
        {
            (List<int> col1, List<int> col2) lists = ExtractTextToList();

            int difference = CalculateDifferences(lists.col1, lists.col2);
        }


        private static (List<int>,List<int>) ExtractTextToList()
        {
            string filePath = "input.txt";

            List<int> column1 = new();
            List<int> column2 = new();

            foreach (string line in File.ReadLines(filePath))
            {
                var parts = line
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 2 &&
                    int.TryParse(parts[0], out int col1) &&
                    int.TryParse(parts[1], out int col2))
                {
                    column1.Add(col1);
                    column2.Add(col2);
                }
            }

            column1.Sort();
            column2.Sort();

            return (column1, column2);

        }
        

        private static int CalculateDifferences(List<int> list1, List<int> list2)
        {
            int difference = 0;

            for(int i = 0; i < list1.Count; i++)
            {
                difference += Math.Abs(list1[i] - list2[i]);
            }
            return difference;

        }


    }
}