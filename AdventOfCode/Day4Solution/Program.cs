

namespace Day4Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] input = ReceiveInput();

            //int occurences = Traverse(input);
            int occurences = TraverseMAS(input);
        }

        private static char[][] ReceiveInput()
        {
            string filename = "input.txt";

            var lines = File.ReadAllLines(filename);

            return lines.Select(line => line.ToCharArray()).ToArray();
        }

        private static int TraverseMAS(char[][] input)
        {
            (int dx, int dy)[] directions = new[]
            {
                (1, 1),    // ️down-right
                (-1, -1),  // ️up-left
                (-1, 1),   // ️down-left
                (1, -1)    // ️up-right
            };
            int foundCount = 0;

            for(int y = 0; y < input.Length; y++)
            {
                for(int x = 0; x < input[y].Length; x++)
                {
                    if (!(input[y][x] == 'A')) continue;
                    List<bool> matchesDiagonal = new();
                    
                    foreach (var (dx, dy) in directions)
                    {
                        int x1 = x + dx, y1 = y + dy;

                        int x2 = x - dx, y2 = y - dy;

                        if(IsIndexInBounds(x1,x2,y1,y2,input))
                        {
                            matchesDiagonal.Add(LettersMatch(input[y1][x1], input[y2][x2]));
                        }
                    }
                    if(matchesDiagonal.Count() == 4 && matchesDiagonal.All(x => x == true))
                    {
                        foundCount++;
                    }
                }
            }

            return foundCount;
        }


        static bool LettersMatch(char letter1, char letter2)
        {
            return (letter1 == 'M' && letter2 == 'S') || (letter1 == 'S' && letter2 == 'M');
        }


        static bool IsIndexInBounds(int x1, int x2, int y1, int y2, char[][] input)
        {
            if (y1 < 0 || y1 >= input.Length || y2 < 0 || y2 >= input.Length)
                return false;

            if (x1 < 0 || x1 >= input[y1].Length || x2 < 0 || x2 >= input[y2].Length)
                return false;

            return true;
        }

        private static int Traverse(char[][] input)
        {
            (int dx, int dy)[] directions = new[]
            {
                (1, 0),    // ️right
                (-1, 0),   // ️left
                (0, 1),    // ️down
                (0, -1),   // ️up
                (1, 1),    // ️down-right
                (-1, -1),  // ️up-left
                (-1, 1),   // ️down-left
                (1, -1)    // ️up-right
            };
            int foundCount = 0;
            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    foreach (var (dx, dy) in directions)
                    {
                        if (MatchesPattern(input, x, y, dx, dy,"XMAS"))
                        {
                            foundCount++;
                        }
                    }
                }

            }
            return foundCount;

        }

        private static bool MatchesPattern(char[][] grid, int x, int y, int dx, int dy, string word)
        {
            for(int i = 0; i < word.Length; i++)
            {
                var nx = x + dx * i;

                var ny = y + dy * i;


                if (ny < 0 || ny >= grid.Length || nx < 0 || nx >= grid[0].Length)
                {
                    return false;
                }

                if (grid[ny][nx] != word[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
