using System.Text.RegularExpressions;

namespace _2024.day2;

public class day3 {
  public async Task part1() {
    var memory = File.ReadAllText("day3/input.txt");
    var mulEntries = Regex.Matches((string)memory, @"mul\([0-9]+,[0-9]+\)").ToList();
    int total = 0;
    foreach (Match mul in mulEntries)
    {
      string replaced = mul.Value.Replace("mul(", "").Replace(")", "");
      List<int> numbers = replaced.Split(",").Select(Int32.Parse).ToList();
      total += numbers[0] * numbers[1];
    }

    Console.WriteLine("part 1: " + total);
  }

  public async Task part2() {
    var memory = File.ReadAllText("day3/input.txt");
    var mulEntries = Regex.Matches((string)memory, @"mul\([0-9]+,[0-9]+\)|do\(\)|don't\(\)").ToList();
    int total = 0;
    bool dont = false;
    foreach (Match mul in mulEntries)
    {
      if (mul.Value == "do()")
      {
        dont = false;
        continue;
      }

      if (mul.Value == "don't()")
      {
        dont = true;
        continue;
      }
        if (!dont)
        {
          string replaced = mul.Value.Replace("mul(", "").Replace(")", "");
          List<int> numbers = replaced.Split(",").Select(Int32.Parse).ToList();
          total += numbers[0] * numbers[1];
        }
    }

    Console.WriteLine("part 2: " + total);
  }
}
