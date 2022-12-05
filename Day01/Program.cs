IEnumerable<string> file = File.ReadLines("G:\\003_PROGRAMOZAS\\aoc2022\\Day01\\input.txt");
List<int> manok = new List<int>();
int sum = 0;

foreach (string line in file) {
    if (line == "") {
        manok.Add(sum);
        sum = 0;
    } else {
        sum += int.Parse(line);
    }
}

Console.WriteLine($"A legtöbbet cipelő manó {manok.Max()} kalóriát cipel");

manok.Sort();
manok.Reverse();
Console.WriteLine($"A top3 manó összege {manok[0] + manok[1] + manok[2]}");