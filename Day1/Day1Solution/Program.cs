using System;

namespace Day1Solution
{
    public class Program
    {
        static void Main(string[] args)
        {
            (List<int> col1, List<int> col2) lists = ExtractTextToList();

            int difference = Part1_CalculateDifferences(lists.col1, lists.col2);

            int difference2 = Part1_CalculateDifferences_MoreElegant(lists.col1, lists.col2);

            int similarityScore = Part2_SimilarityScore(lists.col1, lists.col2);

            int similarityScore2 = Part2_SimilarityScore_MorePerformant_Perhaps(lists.col1, lists.col2);


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
        

        private static int Part1_CalculateDifferences(List<int> list1, List<int> list2)
        {
            int difference = 0;

            for(int i = 0; i < list1.Count; i++)
            {
                difference += Math.Abs(list1[i] - list2[i]);
            }
            return difference;

            //I think this is O(n)

            //An Edge Case here is what if they are different lengths, these 2 collections. We might need to append 0s at the end of the shorter one, in that case?

        }

        private static int Part1_CalculateDifferences_MoreElegant(List<int> list1, List<int> list2)
        {
            return list1.Zip(list2, (a, b) => Math.Abs(a - b)).Sum();

            //I think this is also O(n) but I'm not sure.
        }

        private static int Part2_SimilarityScore(List<int> list1, List<int> list2)
        {
            int similarityScore = 0;

            for(int i = 0; i < list1.Count; i++)
            {
                similarityScore += list1[i] * list2.Where(x => x == list1[i]).Count();
            }

            return similarityScore;

            //O(n * m)


        }

        private static int Part2_SimilarityScore_MorePerformant_Perhaps(List<int> list1, List<int> list2)
        {
            var frequency = new Dictionary<int, int>();
            foreach (var num in list2)
            {
                if (frequency.ContainsKey(num))
                    frequency[num]++;
                else
                    frequency[num] = 1;
            }
             int similarityScore = 0;

            foreach (var num in list1)
            {
                if (frequency.TryGetValue(num, out int count))
                {
                    similarityScore += num * count;
                }
            }

            //O(n + m)

            return similarityScore;
        }


    }
}