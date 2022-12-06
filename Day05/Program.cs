string[] file = File.ReadLines("G:\\003_PROGRAMOZAS\\aoc2022\\Day05\\input.txt").ToArray();
List<List<string>> tempCrates = new List<List<string>>();
List<List<int>> moves = new List<List<int>>();

// Could be used for debugging, I guess ¯\_(ツ)_/¯
void printMatrix(List<List<string>> matrix) {
    foreach (var line in matrix) {
        foreach (var item in line) {
            Console.Write((item ?? " ") + " ");
        }
        Console.WriteLine();
    }
}

bool crateIns = true;
for (int i = 0; i < file.Count(); i++) {
    string line = file[i];

    if (line == "" || (crateIns && (i < (file.Count() - 1) && file[i + 1] == ""))) {
        crateIns = false;
        continue;
    }

    if (crateIns) {
        tempCrates.Insert(0, new List<string>());
        int cols = (line.Length + 1) / 4;
        for (int col = 0; col < cols; col++) {
            tempCrates[0].Add(null);
            string split = (line + " ").Substring(col * 4, 4);
            string[] crateSplit = split.Split('[');
            string crateLetter;
            if (crateSplit.Length > 1) {
                crateLetter = crateSplit[1];
                crateLetter = crateLetter.Split(']')[0];
                tempCrates[0][col] = crateLetter;
            }
        }
    } else {
        string[] split = line.Split(" ");
        moves.Add(new List<int>() {
            int.Parse(split[1]),
            int.Parse(split[3]),
            int.Parse(split[5]),
        });
    }
}


// Rotate matrix; it is easier to work like this
List<List<string>> crates = new List<List<string>>();
List<List<string>> originalCrates = new List<List<string>>();
int columns = (file[0].Length + 1) / 4;
for (int i = 0; i < columns; i++) {
    crates.Add(new List<string>());
    originalCrates.Add(new List<string>());
    for (int j = 0; j < tempCrates.Count; j++) {
        crates[i].Add(tempCrates[j][i]);
        originalCrates[i].Add(tempCrates[j][i]);
    }

}


foreach (List<int> move in moves) {
    int howMany = move[0];
    int fromWhere = move[1] - 1;
    int toWhere = move[2] - 1;

    for (int i = 0; i < howMany; i++) {
        //Find top
        int topIndexFrom = crates[fromWhere].IndexOf(null) - 1;
        if (topIndexFrom == -2) {
            topIndexFrom = crates[fromWhere].Count - 1;
        }
        string toMoveLetter = crates[fromWhere][topIndexFrom];
        crates[fromWhere][topIndexFrom] = null;

        //Find top where to put
        int topIndexTo = crates[toWhere].IndexOf(null);
        if (topIndexTo == -1) {
            topIndexTo = crates[toWhere].Count;
            // add empty space at top
            foreach (List<string> col in crates) {
                col.Add(null);
            }
        }

        crates[toWhere][topIndexTo] = toMoveLetter;
    }
}

string output = "";
for (int i = 0; i < crates.Count; i++) {
    int topI = crates[i].IndexOf(null) - 1;
    if (topI == -2) {
        topI = crates[i].Count - 1;
    }

    output += crates[i][topI];
}

Console.WriteLine(output);


// ------------- Part 2 ------------
crates = originalCrates;
foreach (List<int> move in moves) {
    int howMany = move[0];
    int fromWhere = move[1] - 1;
    int toWhere = move[2] - 1;

    //Find top index
    int topIndexFrom = crates[fromWhere].IndexOf(null);
    if (topIndexFrom == -1) {
        topIndexFrom = crates[fromWhere].Count;
    }
    topIndexFrom = topIndexFrom - howMany;

    //Find top where to put
    int topIndexTo = crates[toWhere].IndexOf(null);
    if (topIndexTo == -1) {
        topIndexTo = crates[toWhere].Count;
        // add empty space at top
        foreach (List<string> col in crates) {
            col.Add(null);
        }
    }

    for (int i = topIndexFrom; i < topIndexFrom + howMany; i++) {
        string toMoveLetter = crates[fromWhere][i];
        crates[fromWhere][i] = null;

        if (topIndexTo >= crates[toWhere].Count) {
            foreach (List<string> col in crates) {
                col.Add(null);
            }
        }
        crates[toWhere][topIndexTo] = toMoveLetter;
        topIndexTo++;
    }
}

output = "";
for (int i = 0; i < crates.Count; i++) {
    int topI = crates[i].IndexOf(null) - 1;
    if (topI == -2) {
        topI = crates[i].Count - 1;
    }

    output += crates[i][topI];
}

Console.WriteLine(output);