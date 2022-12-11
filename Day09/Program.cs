string[] file = File.ReadLines("G:\\003_PROGRAMOZAS\\aoc2022\\Day09\\input.txt").ToArray();
List<Coor> visitedPositions = new List<Coor>();
Head currHead = new Head();
Tail currTail = new Tail();

foreach (string line in file) {
    char movement = line[0];
    int repeat = int.Parse(line.Split(' ')[1]);
    for (int i = 0; i < repeat; i++) {
        switch (movement) {
            case 'U':
                currHead.position.y += 1;
                break;
            case 'D':
                currHead.position.y -= 1;
                break;
            case 'L':
                currHead.position.x -= 1;
                break;
            case 'R':
                currHead.position.x += 1;
                break;
        }
        currTail.updateTail(currHead);
        addToVisitedSet(currTail.position);
        //Console.WriteLine(currTail);
    }
}

Console.WriteLine(visitedPositions.Count);

void addToVisitedSet(Coor point) {
    int res = visitedPositions.FindIndex((item) => item.x == point.x && item.y == point.y);
    if (res == -1) {
        visitedPositions.Add(new Coor(point.x, point.y));
    }
}

class Tail {
    public Coor position = new Coor(0,0);

    public override string ToString() {
        return $"T({position.x};{position.y})";
    }

    public void updateTail(Head head) {
        int x_diff = head.position.x - this.position.x;
        int y_diff = head.position.y - this.position.y;

        if ((-1 <= x_diff && x_diff <= 1) && (-1 <= y_diff && y_diff <= 1)) {
            return;
        }

        if (x_diff == 0) {
            // Y change only
            if (y_diff > 0) {
                this.position.y += 1;
            } else {
                this.position.y -= 1;
            }
        } else if (y_diff == 0) {
            // Y change only
            if (x_diff > 0) {
                this.position.x += 1;
            } else {
                this.position.x -= 1;
            }
        } else if (x_diff == 1 && y_diff == 2) {
            // Up right
            this.position.x += 1;
            this.position.y += 1;
        } else if (x_diff == -1 && y_diff == 2) {
            // Up left
            this.position.x -= 1;
            this.position.y += 1;
        } else if (x_diff == 1 && y_diff == -2) {
            // Down right
            this.position.x += 1;
            this.position.y -= 1;
        } else if (x_diff == -1 && y_diff == -2) {
            // Down left
            this.position.x -= 1;
            this.position.y -= 1;
        } else if (x_diff == -2 && y_diff == 1) {
            // Far up left
            this.position.x -= 1;
            this.position.y += 1;
        } else if (x_diff == 2 && y_diff == 1) {
            // Far up right
            this.position.x += 1;
            this.position.y += 1;
        } else if (x_diff == -2 && y_diff == -1) {
            // Far down left
            this.position.x -= 1;
            this.position.y -= 1;
        } else if (x_diff == 2 && y_diff == -1) {
            // Far down right
            this.position.x += 1;
            this.position.y -= 1;
        }
    }
}

class Head {
    public Coor position = new Coor(0, 0);
}

class Coor {
    public int x;
    public int y;

    public Coor(int x, int y) {
        this.x = x;
        this.y = y;
    }
}