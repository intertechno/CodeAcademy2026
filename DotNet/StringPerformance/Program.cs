using System.Text;

Console.WriteLine("Starting string performance tests...");

DateTime startTime = DateTime.Now;

StringBuilder sb = new();
for (int i = 0; i < 500_000; i++)
{
    sb.Append('A');
}
string s = sb.ToString();
Console.WriteLine($"Length of string: {s.Length}");

/*
string s = "";
for (int i = 0; i < 600_000; i++)
{
    s += "A";
}
*/

DateTime endTime = DateTime.Now;
TimeSpan duration = endTime - startTime;
Console.WriteLine($"String performance test duration: {duration.TotalMilliseconds} ms");

Console.WriteLine("String performance tests completed.");
