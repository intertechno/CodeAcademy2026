using System.Globalization;
using System.Text.Json;
using FileProcessing;

CultureInfo fi = new("fi-FI");
string filename = @"C:\Academy\Code2026\Numbers.txt";
string[] lines = File.ReadAllLines(filename);

int lineCounter = 1;
int numberCount = 0;
double sum = 0;
foreach (string line in lines)
{
	try
	{
		double number = double.Parse(line, fi);
		sum += number;
		numberCount++;
    }
	catch
	{
        Console.WriteLine($"Error on line {lineCounter}.");
	}

	lineCounter++;
}

// calculate sum and average
double average = sum / numberCount;

CalculationResults results = new()
{
	Filename = filename,
	Sum = sum,
	Average = average
};

string json = JsonSerializer.Serialize(results,
	new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText("Results.json", json);
