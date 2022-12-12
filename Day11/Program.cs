string[] monkeysIn = File.ReadAllText("G:\\003_PROGRAMOZAS\\aoc2022\\Day11\\example.txt").Split("\r\n\r\n");
List<Monkey> monkeys = new List<Monkey>();

foreach (string monkey in monkeysIn) {
    string[] lines = monkey.Split("\r\n");
    Monkey temp = new Monkey();

    temp.items = lines[1].Split("Starting items: ")[1].Split(", ").Select(ulong.Parse).ToList();
    temp.operation = lines[2].Split("new = old")[1];
    temp.divisor = int.Parse(lines[3].Split("divisible by ")[1]);
    temp.tMonkey = int.Parse(lines[4].Split("throw to monkey ")[1]);
    temp.fMonkey = int.Parse(lines[5].Split("throw to monkey ")[1]);

    monkeys.Add(temp);
}

for (int round = 1; round <= 1000; round++) {
    foreach (Monkey monke in monkeys) {
        for (int i = 0; i < monke.items.Count; i++) {
            monke.items[i] = Eval($"{monke.items[i]}{monke.operation.Replace("old", monke.items[i].ToString())}");
            monke.items[i] = (ulong)Math.Floor(monke.items[i] / 3.0);
            if (monke.items[i] % (ulong)monke.divisor == 0) {
                monkeys[monke.tMonkey].items.Add(monke.items[i]);
            } else {
                monkeys[monke.fMonkey].items.Add(monke.items[i]);
            }
            monke.inspects += 1;
        }
        monke.items = new List<ulong>();
    }
}

monkeys.Sort((x, y) => (int)(y.inspects - x.inspects));
Console.WriteLine(monkeys[0].inspects * monkeys[1].inspects);

ulong Eval(String expression) {
    string[] parts = expression.Split(" ");
    if (parts[1] == "*") {
        return ulong.Parse(parts[0]) * ulong.Parse(parts[2]);
    } else if (parts[1] == "+") {
        return ulong.Parse(parts[0]) + ulong.Parse(parts[2]);
    }

    throw new Exception($"Invalid operand {parts[1]}");
}

class Monkey {
    public List<ulong> items = new List<ulong>();
    public string operation = "";

    public int divisor = 0;
    public int tMonkey = 0;
    public int fMonkey = 0;
    public ulong inspects = 0;
}