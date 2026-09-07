using AspNetWebApiCsvDemo.Models;

namespace AspNetWebApiCsvDemo.Services
{
    public class CsvPersonReader
    {
        public List<Person> ReadPersonsFromCsv(string csvFilePath)
        {
            List<Person> persons = [];
            using (StreamReader reader = new(csvFilePath))
            {
                // Skip the header line
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine() ?? "";
                    string[] values = line.Split(',');
                    if (values.Length == 3)
                    {
                        if (int.TryParse(values[0], out int number))
                        {
                            Person person = new(number, values[1], values[2]);
                            persons.Add(person);
                        }
                    }
                }
            }

            return persons;
        }
    }
}
