List<long> nums = new List<long>();
foreach (string num in File.ReadLines(args[0]))
{
  nums.Add(long.Parse(num));
}

nums.Sort();

long avr = nums[nums.Count / 2];
long i = 0;
int ind = 0;
while (ind < nums.Count)
{
  i += Math.Abs(nums[ind] - avr);
  ind++;
}

if (i <= 20)
{
  Console.WriteLine(i);
}
else
{
  Console.WriteLine("20 ходов недостаточно для приведения всех элементов массива к одному числу");
}
