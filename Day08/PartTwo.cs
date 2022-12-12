namespace Day08 {
    internal class PartTwo {
        public static void PartTwoMain(List<List<Tree>> input) {
            for (int i = 0; i < input.Count; i++) {
                for (int j = 0; j < input[i].Count; j++) {
                    Tree current = input[i][j];

                    // Lefele
                    int counter = 0;
                    for (int i2 = i + 1; i2 < input.Count; i2++) {
                        Tree current2 = input[i2][j];
                        if (current2.height >= current.height) {
                            counter++;
                            break;
                        }
                        counter++;
                    }
                    current.visibleCount.Add(counter);

                    // Felfele
                    counter = 0;
                    for (int i2 = i - 1; i2 >= 0; i2--) {
                        Tree current2 = input[i2][j];
                        if (current2.height >= current.height) {
                            counter++;
                            break;
                        }
                        counter++;
                    }
                    current.visibleCount.Add(counter);

                    // Jobbra
                    counter = 0;
                    for (int j2 = j + 1; j2 < input[i].Count; j2++) {
                        Tree current2 = input[i][j2];
                        if (current2.height >= current.height) {
                            counter++;
                            break;
                        }
                        counter++;
                    }
                    current.visibleCount.Add(counter);


                    // Balra
                    counter = 0;
                    for (int j2 = j - 1; j2 >= 0; j2--) {
                        Tree current2 = input[i][j2];
                        if (current2.height >= current.height) {
                            counter++;
                            break;
                        }
                        counter++;
                    }
                    current.visibleCount.Add(counter);
                }
            }

            int max = 0;
            foreach (List<Tree> sor in input) {
                foreach (Tree t in sor) {
                    int score = t.visibleCount.Aggregate((a, b) => a * b);
                    if (score > max) {
                        max = score;
                    }
                }
            }
            Console.WriteLine(max);
        }
    }
}
