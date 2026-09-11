using System.Globalization;

string[] elips = File.ReadAllLines(args[0]);
string[] dots = File.ReadAllLines(args[1]);

string[] buf = elips[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
double x_0 = double.Parse(buf[0], CultureInfo.InvariantCulture);
double y_0 = double.Parse(buf[1], CultureInfo.InvariantCulture);

buf = elips[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
double a = double.Parse(buf[0], CultureInfo.InvariantCulture);
double b = double.Parse(buf[1], CultureInfo.InvariantCulture);

double ans = 0.0;
double x = 0.0;
double y = 0.0;
const double eps = 1e-14;
for (int i = 0; i < dots.Length; i++)
{
  buf = dots[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

  x = double.Parse(buf[0], CultureInfo.InvariantCulture) - x_0;
  y = double.Parse(buf[1], CultureInfo.InvariantCulture) - y_0;
  ans = (x * x) / (a * a) + (y * y) / (b * b);

  if (Math.Abs(ans - 1.0) < eps) Console.WriteLine(0); 
  else if (ans > 1.0) Console.WriteLine(2);
  else Console.WriteLine(1);
}
