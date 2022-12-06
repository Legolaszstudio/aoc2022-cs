string input = File.ReadAllText("G:\\003_PROGRAMOZAS\\aoc2022\\Day06\\input.txt");
List<char> fourLast = new List<char>();

int i = 1;
foreach (char ch in input) {
    fourLast.Add(ch);
    if (fourLast.Count == 4) {
        if (fourLast.Count == fourLast.Distinct().Count()) {
            Console.WriteLine(i);
            break;
        }
        fourLast.RemoveAt(0);
    }
    i++;
}

fourLast = new List<char>();
i = 1;
foreach (char ch in input) {
    fourLast.Add(ch);
    if (fourLast.Count == 14) {
        if (fourLast.Count == fourLast.Distinct().Count()) {
            Console.WriteLine(i);
            break;
        }
        fourLast.RemoveAt(0);
    }
    i++;
}