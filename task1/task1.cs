uint n_first = uint.Parse(args[0]);
uint m_first = uint.Parse(args[1]);
uint n_second = uint.Parse(args[2]);
uint m_second = uint.Parse(args[3]);

List<uint> Path(uint n, uint m)
{
  List<uint> result = new List<uint>();

  uint arr = 0;

  if (m == 1 || n == 1)
  {
    result.Add(1u);
    return result;
  }

  while (true)
  {
    if (arr < n)
    {
      result.Add(arr + 1);
      arr += m - 1;
    } else
    {
      arr = arr % n;
      if (arr == 0) break;
    }
  }

  return result;
}

foreach (uint x in Path(n_first, m_first)) Console.Write(x);
foreach (uint x in Path(n_second, m_second)) Console.Write(x);
