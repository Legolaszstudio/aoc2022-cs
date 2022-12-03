IEnumerable<string> file = File.ReadLines("G:\\003_PROGRAMOZAS\\aoc2022\\Day02\\input_my.txt");

void Part1()
{
    int sum = 0;
    foreach (string line in file)
    {
        string enemy = line.Split(' ')[0];
        //A: Rock
        //B: Paper
        //C: Scissors
        string me = line.Split(' ')[1];
        //X: Rock
        //Y: Paper
        //Z: Scissors

        switch (me)
        {
            case "X":
                sum += 1;
                break;
            case "Y":
                sum += 2;
                break;
            case "Z":
                sum += 3;
                break;
        }

        // Rock VS Scissors
        if (me == "X" && enemy == "C")
        {
            sum += 6;
            // Rock VS Paper
        }
        else if (me == "X" && enemy == "B")
        {
            sum += 0;
            // Rock VS Rock
        }
        else if (me == "X" && enemy == "A")
        {
            sum += 3;
        }

        // Paper VS Scissors
        if (me == "Y" && enemy == "C")
        {
            sum += 0;
            // Paper VS Paper
        }
        else if (me == "Y" && enemy == "B")
        {
            sum += 3;
            // Paper VS Rock
        }
        else if (me == "Y" && enemy == "A")
        {
            sum += 6;
        }

        // Scissors VS Scissors
        if (me == "Z" && enemy == "C")
        {
            sum += 3;
            // Scissors VS Paper
        }
        else if (me == "Z" && enemy == "B")
        {
            sum += 6;
            // Scissors VS Rock
        }
        else if (me == "Z" && enemy == "A")
        {
            sum += 0;
        }
    }

    Console.WriteLine($"Part1: A pontok összege: {sum}");
}

void Part2()
{
    int sum = 0;
    foreach (string line in file)
    {
        string enemy = line.Split(' ')[0];
        //A: Rock
        //B: Paper
        //C: Scissors
        string me = line.Split(' ')[1];
        //X: lose
        //Y: draw
        //Z: win
        string meChoose = "";

        switch (me)
        {
            // Lose
            case "X":
                // Rock kils scissors 
                if (enemy == "A")
                {
                    meChoose = "C";
                }
                // Paper kills rock
                else if (enemy == "B")
                {
                    meChoose = "A";
                }
                // Scissors kills paper
                else if (enemy == "C")
                {
                    meChoose = "B";
                }
                break;
            case "Y":
                // Draw
                meChoose = enemy;
                sum += 3;
                break;
            case "Z":
                // Win
                sum += 6;
                // Rock killed by paper 
                if (enemy == "A")
                {
                    meChoose = "B";
                }
                // Paper killed by scissors
                else if (enemy == "B")
                {
                    meChoose = "C";
                }
                // Scissors killed by rock
                else if (enemy == "C")
                {
                    meChoose = "A";
                }
                break;
        }

        switch (meChoose)
        {
            case "A":
                sum += 1;
                break;
            case "B":
                sum += 2;
                break;
            case "C":
                sum += 3;
                break;
        }
    }
    Console.WriteLine($"Part2: A pontok összege: {sum}");
}

Part1();
Part2();