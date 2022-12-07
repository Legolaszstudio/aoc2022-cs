List<string> file = File.ReadLines("G:\\003_PROGRAMOZAS\\aoc2022\\Day07\\example.txt").ToList();
file.RemoveAt(0);



DirectoryItem root = new DirectoryItem(null, "/", true);
DirectoryItem currentParent = root;

int i = 0;
while (i < file.Count) {
    string line = file[i];
    if (line == "$ ls") {
        i++;
        line = file[i];
        while (!line.StartsWith('$')) {
            if (line.StartsWith("dir")) {
                currentParent.children.Add(new DirectoryItem(
                        currentParent,
                        line.Split(' ')[1],
                        true
                ));
            } else {
                DirectoryItem temp = new DirectoryItem(
                        currentParent,
                        line.Split(' ')[1],
                        false
                );
                temp.size = int.Parse(line.Split(' ')[0]);
                currentParent.children.Add(temp);
            }
            i++;
            if (i < file.Count) {
                line = file[i];
            } else {
                break;
            }
        }
    } else {
        if (line == "$ cd ..") {
            currentParent = currentParent.parent;
        } else {
            string toWhere = line.Split(' ')[2];
            DirectoryItem temp = currentParent.children.Find((x) => x.name == toWhere);
            if (temp == null) {
                Console.WriteLine("Wait a goddam minute");
                throw new Exception($"Didn't find folder {toWhere}");
            }
            currentParent = temp;
        }
        i++;
    }
}

Console.WriteLine();

class DirectoryItem {
    public DirectoryItem parent;
    public string name;
    public int size;
    public List<DirectoryItem> children;
    public bool isDir = false;

    public DirectoryItem(DirectoryItem parent, string name, bool isDir) {
        this.parent = parent;
        this.name = name;
        this.isDir = isDir;
        size = 0;
        children = new List<DirectoryItem>();
    }
}