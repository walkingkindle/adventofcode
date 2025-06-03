

namespace Day4Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] input = ReceiveInput();
        }

        private static char[][] ReceiveInput()
        {
            string filename = "input.txt";

            var lines = File.ReadAllLines(filename);

            return lines.Select(line => line.ToCharArray()).ToArray();
        }

        private static void Traverse(char[][] input)
        {
            (int dx, int dy)[] directions = new[]
            {
                (1, 0),   // right
                (0, 1),   // down
                (1, 1),   // down-right
                (-1, 1)   // down-left
            };
            for(int y = 0; y < input.Length; y++)
            {
                for(int x = 0; x < input[y].Length; x++)
                {
                    foreach(var (dx,dy) in directions)
                    {
                        if (MatchesPattern(input, x, y, dx, dy, "XMAS"))
                        {

                        }
                    }
                }

            }

        }

        private static bool MatchesPattern(char[][] grid, int x, int y, int dx, int dy, string v)
        {
            throw new NotImplementedException();
        }
    }
}
