string[] file = File.ReadLines("G:\\003_PROGRAMOZAS\\aoc2022\\Day08\\input.txt").ToArray();

List<List<Tree>> inputMatrix = new List<List<Tree>>();

int inpI = 0;
foreach (string line in file) {
    inputMatrix.Add(new List<Tree>());
    int inpJ = 0;
    foreach (char c in line) {
        Tree temp = new Tree();
        temp.height = int.Parse(c.ToString());
        temp.visibleTop = (inpI == 0);
        temp.visibleBottom = (inpI == file.Length - 1);
        temp.visibleLeft = (inpJ == 0);
        temp.visibleRight = (inpJ == line.Length - 1);
        inputMatrix.Last().Add(temp);
        inpJ++;
    }
    inpI++;
}

// Check top
for (int i = 1; i < inputMatrix.Count; i++) {
    for (int j = 0; j < inputMatrix[i].Count; j++) {
        Tree current = inputMatrix[i][j];
        Tree above = inputMatrix[i - 1][j];
        current.valsBefore = above.valsBefore.ToList();
        current.valsBefore.Add(above.height);
        if (!current.valsBefore.Any((x) => x >= current.height)) {
            current.visibleBottom = true;
        }
    }
}

// Check bottom
for (int j = 0; j < inputMatrix[0].Count; j++) {
    inputMatrix[inputMatrix.Count - 1][j].valsBefore = new List<int>();
}
for (int i = inputMatrix.Count - 2; i >= 0; i--) {
    for (int j = 0; j < inputMatrix[i].Count; j++) {
        Tree current = inputMatrix[i][j];
        Tree below = inputMatrix[i + 1][j];
        current.valsBefore = below.valsBefore.ToList();
        current.valsBefore.Add(below.height);
        if (!current.valsBefore.Any((x) => x >= current.height)) {
            current.visibleBottom = true;
        }
    }
}

// Check left
for (int i = 0; i < inputMatrix.Count; i++) {
    inputMatrix[i][0].valsBefore = new List<int>();
    for (int j = 1; j < inputMatrix[i].Count; j++) {
        Tree current = inputMatrix[i][j];
        Tree left = inputMatrix[i][j - 1];
        current.valsBefore = left.valsBefore.ToList();
        current.valsBefore.Add(left.height);
        if (!current.valsBefore.Any((x) => x >= current.height)) {
            current.visibleLeft = true;
        }
    }
}

// Check right
for (int i = 0; i < inputMatrix.Count; i++) {
    inputMatrix[i][inputMatrix[0].Count - 1].valsBefore = new List<int>();
    for (int j = inputMatrix[i].Count - 2; j >= 0; j--) {
        Tree current = inputMatrix[i][j];
        Tree right = inputMatrix[i][j + 1];
        current.valsBefore = right.valsBefore.ToList();
        current.valsBefore.Add(right.height);
        if (!current.valsBefore.Any((x) => x >= current.height)) {
            current.visibleRight = true;
        }
    }
}

// GET ANSWER
int count = 0;
foreach (List<Tree> sor in inputMatrix) {
    foreach (Tree fa in sor) {
        if (fa.visibleTop || fa.visibleBottom || fa.visibleLeft || fa.visibleRight) {
            count++;
        }
    }
}

Console.WriteLine(count);

Day08.PartTwo.PartTwoMain(
   inputMatrix.ConvertAll(x => x.ConvertAll(s => s.Clone())).ToList()
);

public class Tree {
    public bool visibleTop;
    public bool visibleBottom;
    public bool visibleLeft;
    public bool visibleRight;

    public int height;

    public List<int> valsBefore = new List<int>();
    public List<int> visibleCount = new List<int>();

    public Tree Clone() {
        return new Tree {
            visibleTop = this.visibleTop,
            visibleBottom = this.visibleBottom,
            visibleLeft = this.visibleLeft,
            visibleRight = this.visibleRight,
            height = this.height,
        };
    }
}