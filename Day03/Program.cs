IEnumerable<string> file = File.ReadLines("G:\\003_PROGRAMOZAS\\aoc2022\\Day03\\input.txt");
List<char> dups = new List<char>();
List<List<string>> sacks = new List<List<string>>();

int index = 0;
foreach (string line in file) {
    string firstHalf = line.Substring(0, line.Length / 2);
    string secondHalf = line.Substring(line.Length / 2);

    if (index % 3 == 0) {
        sacks.Add(new List<string>());
    }
    sacks.Last().Add(line);

    foreach (char ch in firstHalf) {
        if (secondHalf.Contains(ch)) {
            dups.Add(ch);
            break;
        }
    }

    index++;
}

int getCharValue(char input) {
    int result = ((int)char.ToUpper(input)) - 64;
    if (Char.IsUpper(input)) {
        result = result + 26;
    }
    return result;
}

int sum = 0;
foreach (char dup in dups) {
    sum += getCharValue(dup);
}

Console.WriteLine($"Part uno: {sum}");


// part 2
int resultTwo = 0;
foreach (List<string> group in sacks) {
    foreach (char ch in group[0]) {
        if (group[1].Contains(ch) && group[2].Contains(ch)) {
            resultTwo += getCharValue(ch);
            break;
        }
    }
}

Console.WriteLine($"Parto secundo: {resultTwo}");
