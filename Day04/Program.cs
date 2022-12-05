IEnumerable<string> file = File.ReadLines("G:\\003_PROGRAMOZAS\\aoc2022\\Day04\\input.txt");
int contained = 0;
int overlap = 0;

foreach (string line in file) {
    string first = line.Split(",")[0];
    string second = line.Split(",")[1];

    int first_start = int.Parse(first.Split("-")[0]);
    int first_end = int.Parse(first.Split("-")[1]);

    int second_start = int.Parse(second.Split("-")[0]);
    int second_end = int.Parse(second.Split("-")[1]);

    if (first_start <= second_start && second_end <= first_end) {
        contained++;
    } else if (second_start <= first_start && first_end <= second_end) {
        contained++;
    }

    //Part two
    for (int i = first_start; i <= first_end; i++) {
        if (i >= second_start && i <= second_end) {
            overlap++;
            break;
        }
    }
}

Console.WriteLine($"Part one: {contained}");
Console.WriteLine($"Part two: {overlap}");