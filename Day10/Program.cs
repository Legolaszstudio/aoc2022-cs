string[] file = File.ReadLines("G:\\003_PROGRAMOZAS\\aoc2022\\Day10\\input.txt").ToArray();
int registerValue = 1;
List<int> registerValues = new List<int>();
registerValues.Add(registerValue);

foreach (string line in file) {
    if (line.StartsWith("addx ")) {
        int incrementer = int.Parse(line.Split(' ')[1]);
        registerValues.Add(registerValue);
        registerValue += incrementer;
    }
    registerValues.Add(registerValue);
}

List<int> neededVals = new List<int>();
neededVals.Add(registerValues[20-1] * 20);
neededVals.Add(registerValues[60-1] * 60);
neededVals.Add(registerValues[100-1] * 100);
neededVals.Add(registerValues[140-1] * 140);
neededVals.Add(registerValues[180-1] * 180);
neededVals.Add(registerValues[220-1] * 220);

Console.WriteLine(neededVals.Sum());


// ---------- Part Two ----------
void printCrt(List<List<int>> crt) {
    foreach (List<int> line in crt) {
        foreach (int pixel in line) {
            Console.Write(pixel == 0 ? " " : "#");
        }
        Console.WriteLine();
    }
}

List<List<int>> crt = new List<List<int>>();
for (int i = 0; i < 6; i++) {
    crt.Add(new List<int>());
    crt.Last().AddRange(Enumerable.Repeat(0, 40));
}

int crt_x = 0;
int crt_y = 0;
for (int cyc = 1; (cyc-1) < registerValues.Count; cyc++) {
    int currValue = registerValues[cyc-1];
    if (currValue == crt_x || currValue == crt_x - 1 || currValue == crt_x + 1) {
        crt[crt_y][crt_x] = 1;
    }
    crt_x++;
    if (cyc % 40 == 0) {
        crt_y += 1;
        crt_x = 0;
    }
}

printCrt(crt);