using System.Threading.Tasks;

namespace Day5Solution
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string pairsInput = @"
            47|53
            97|13
            97|61
            97|47
            75|29
            61|13
            75|53
            29|13
            97|29
            53|29
            61|53
            97|53
            61|29
            47|13
            75|47
            97|75
            47|61
            75|61
            47|29
            75|13";
            var tupleList = RetrieveInput(pairsInput);

            var strInputList = @"75,47,61,53,29
            97,61,53,29,13
            75,29,13
            75,97,47,61,53
            61,13,29
            97,13,75,29,47";

            var orderedList = GetOrderedLists(strInputList);

            var midCount = CheckForCount(orderedList, tupleList);

            var count = CountMiddles(midCount);
        }

        private static int CountMiddles(List<List<int>> validInputs)
        {
            int count = 0;

            foreach(var input in validInputs)
            {
                count += input[input.Count / 2];
            }

            return count;

        }

        private static List<List<int>> CheckForCount(List<List<int>> input1, List<Tuple<int,int>> input2)
        {
            List<List<int>> validLists = new();
            foreach(var itemList in input1)
            {
                if(isInputListValid(itemList, input2))
                {
                    validLists.Add(itemList);
                }
            }

            return validLists;
           
        }

        private static bool OneOfTheItemsIsInTuple(Tuple<int, int> tuple, int item)
        {
            return item == tuple.Item1 || item == tuple.Item2;
        }

        private static bool OneOfTheItemsIsInList(List<int> items, Tuple<int, int> tuple)
        {
            return items.Contains(tuple.Item1) && items.Contains(tuple.Item2);
        }


        private static bool isInputListValid(List<int> itemList, List<Tuple<int, int>> input2)
        {
            List<bool> isValid = new();
            foreach (var item in itemList) {
                var allRulesThatMentionThisItem = new List<Tuple<int,int>>();
                foreach (var tupleElement in input2)
                {
                    if (OneOfTheItemsIsInTuple(tupleElement, item) && OneOfTheItemsIsInList(itemList,tupleElement))
                    {
                        allRulesThatMentionThisItem.Add(tupleElement);
                    }

                }
                bool itPassesAllRules = ItPassesAllRules(item,allRulesThatMentionThisItem,itemList);

                isValid.Add(itPassesAllRules);

            }

            return isValid.All(x => x);
        }

        private static bool ItPassesAllRules(int item,List<Tuple<int,int>> allRulesThatMentionThisItem,List<int> itemList)
        {
            List<bool> allRules = new();

            foreach(var rule in allRulesThatMentionThisItem)
            {
                bool pass = false;
                if (rule.Item1 == item)
                {
                    pass = itemList.IndexOf(item) < itemList.IndexOf(rule.Item2);
                }
                else if (rule.Item2 == item)
                {
                    pass = itemList.IndexOf(item) > itemList.IndexOf(rule.Item1);
                }
                allRules.Add(pass);
            }

            return allRules.All(x => x);

        }

        private static List<Tuple<int, int>> RetrieveInput(string pairsInput)
        {
            return pairsInput
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line =>
                {
                    var parts = line.Trim().Split('|');
                    return Tuple.Create(int.Parse(parts[0]), int.Parse(parts[1]));
                })
                .ToList();
        }

        private static List<List<int>> GetOrderedLists(string input)
        {
            char[] delimiters = [',', '\r','\n'];

            var strArr = input.Split(delimiters);

            List<List<int>> result = new();

            var current = new List<int>();

            foreach(var item in strArr)
            {
                if (item == "")
                {
                    if(current.Count > 0)
                    {
                        result.Add(new List<int>(current));
                        current.Clear();
                    }
                }
                else
                {
                    current.Add(int.Parse(item));
                }
            }

            return result;
        }

        private static string ParseRawInputFromText()
        {
            string fileName = "input1.txt";


        }
    }
}
