using System.Text.RegularExpressions;

namespace _2024.day5;

public class day5 {
  public async Task part1() {
    var lines = File.ReadAllLines("day5/input.txt");
    long total = 0;
    int linecount;
    IList<Rule> rules = new List<Rule>();
    for (linecount = 0; linecount < lines.Length; linecount++)
    {
      if (lines[linecount] == "") break;
      string[] nums = lines[linecount].Split('|');
      rules.Add(new Rule(Int32.Parse(nums[0]), Int32.Parse(nums[1])));
    }

    linecount++;
    for (int i = linecount; i < lines.Length; i++)
    {
      int[] order = lines[i].Split(",").Select(Int32.Parse).ToArray();
      int current = 0;
      List<int> results = new List<int>();
      for (int j = 0; j < order.Length; j++)
      {
        for (int k = current; k < order.Length; k++)
        {
          if (k == current) continue;
          var selectedRules = rules.Where(rule =>
              (rule.X == order[current] || rule.X == order[k]) && (rule.Y == order[current] || rule.Y == order[k]))
            .Select(rule => rule.CompareTo((order[current], order[k])));

          results.AddRange(selectedRules);
        }
      }

      if (!results.Contains(-1))
      {
        var mid = order.Length / 2;
        total += order[mid];
      }
    }


    Console.WriteLine("part 1: " + total);
  }

  public async Task part2() {
    var memory = File.ReadAllLines("day5/input.txt");
    int total = 0;


    Console.WriteLine("part 2: " + total);
  }

  private class Rule :IComparable<(int, int)> {
    public int X;
    public int Y;
    public int CompareTo((int, int )order) {
      if (X == order.Item2 || Y == order.Item1)
      {
        return -1;
      }

      return 1;
    }

    public Rule(int x, int y) {
      X = x;
      Y = y;
    }
  }
}