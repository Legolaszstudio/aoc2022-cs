string[] file = File.ReadLines("G:\\003_PROGRAMOZAS\\aoc2022\\Day10\\bExample.txt").ToArray();
int registerValue = 1;
List<int> registerValues = new List<int>();

foreach (string line in file) {
    if (line.StartsWith("addx ")) {
        int incrementer = int.Parse(line.Split(' ')[1]);
        registerValues.Add(registerValue);
        registerValue += incrementer;
    }
    registerValues.Add(registerValue);
    Console.WriteLine(registerValue);
}

List<int> neededVals = new List<int>();
neededVals.Add(registerValues[20-2] * 20);
neededVals.Add(registerValues[60-2] * 60);
neededVals.Add(registerValues[100-2] * 100);
neededVals.Add(registerValues[140-2] * 140);
neededVals.Add(registerValues[180-2] * 180);
neededVals.Add(registerValues[220-2] * 220);

Console.WriteLine(neededVals.Sum());


// ---------- Part Two ----------
