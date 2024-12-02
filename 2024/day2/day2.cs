namespace _2024.day2;

public class day2 {
  public async Task part1() {
    var reports = File.ReadLines("day2/input.txt").ToList();
    int total = 0;
    foreach (var report in reports)
    {
      var splitNumbers = report.Split(" ");
      if (reportIsSafe(splitNumbers))
        total++;
    }
    Console.WriteLine("part 1: " + total);
  }

  public async Task part2() {
    var reports = File.ReadLines("day2/input.txt").ToList();
    int total = 0;
    foreach (var report in reports)
    {
      var splitNumbers = report.Split(" ");
      if (reportIsSafe(splitNumbers))
        total++;
      else
      {
        for (int i = 0; i < splitNumbers.Length; i++)
        {
          var list = new List<string>();
          list.AddRange(splitNumbers);
          list.RemoveAt(i);
          if (reportIsSafe(list.ToArray()))
          {
            total++;
            break;
          }
        }
      }
    }
    Console.WriteLine("part 2: " + total);
  }

  private bool reportIsSafe(string[] splitNumbers) {
    int first = Int32.Parse(splitNumbers[0]);
    int second = Int32.Parse(splitNumbers[1]);
    if (first == second)
      return false;
    bool shouldIncrease = first - second > 0;
    int prev = first;
    for (int i = 1; i < splitNumbers.Length; i++)
    {

      int current = Int32.Parse(splitNumbers[i]);
      if (!isSafe(prev, current, shouldIncrease))
        return false;
      prev = current;
    }

    return true;
  }


  private bool isSafe(int prev, int current, bool shouldIncrease) {
    int difference = Math.Abs(prev - current);
    if (prev - current > 0 != shouldIncrease)
      return false;



    if (difference < 1 || difference > 3)
      return false;

    return true;
  }
}
