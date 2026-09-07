using System.Globalization;

CultureInfo fi = new("fi-FI");
CultureInfo en = new("en-US");

DateTime now = DateTime.Now;
Console.WriteLine(now.ToString(fi));
Console.WriteLine(now.ToString(en));

// ------------------------

string decimalNumber = "1234567,89";
double value = double.Parse(decimalNumber, fi);
Console.WriteLine(value.ToString(en));
