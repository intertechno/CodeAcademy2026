// LINQ demo
using LinqDemo;

int[] numbers = [6, 4, 1, 10, 7, 2, 5, 8, 0, 9, 3];

var bigNumbers = from n in numbers
                 where n > 5
                 orderby n
                 select n;

foreach (int n in bigNumbers)
{
    Console.WriteLine(n);
}

// *******************************************

List<Person> people =
[
    new() { Name = "Emma Virtanen", Address = "Kalevankatu 12 A 3, 00100 Helsinki", Country = "Finland" },
    new() { Name = "Liam O'Connor", Address = "45 Abbey Road, London NW8 9AY", Country = "United Kingdom" },
    new() { Name = "Sofia Rossi", Address = "Via Roma 22, 00184 Rome", Country = "Italy" },
    new() { Name = "Noah Müller", Address = "Hauptstrasse 78, 10115 Berlin", Country = "Germany" },
    new() { Name = "Ava Dubois", Address = "14 Rue de Rivoli, 75001 Paris", Country = "France" },
    new() { Name = "Elias Jensen", Address = "Nørrebrogade 56, 2200 Copenhagen", Country = "Denmark" },
    new() { Name = "Mia Svensson", Address = "Storgatan 10, 114 51 Stockholm", Country = "Sweden" },
    new() { Name = "Lucas Silva", Address = "Av. Paulista 1578, São Paulo", Country = "Brazil" },
    new() { Name = "Olivia Johnson", Address = "742 Evergreen Terrace, Springfield, IL", Country = "United States" },
    new() { Name = "William Brown", Address = "23 George Street, Sydney NSW 2000", Country = "Australia" },
    new() { Name = "Isabella Garcia", Address = "Calle Gran Vía 45, 28013 Madrid", Country = "Spain" },
    new() { Name = "James Wilson", Address = "12 Queen Street, Auckland 1010", Country = "New Zealand" },
    new() { Name = "Charlotte Martin", Address = "8 Rue Sainte-Catherine, 33000 Bordeaux", Country = "France" },
    new() { Name = "Benjamin Lee", Address = "101 Orchard Road, Singapore 238840", Country = "Singapore" },
    new() { Name = "Amelia Novak", Address = "Václavské náměstí 15, 110 00 Prague", Country = "Czech Republic" },
    new() { Name = "Henry Kowalski", Address = "ul. Marszałkowska 99, 00-693 Warsaw", Country = "Poland" },
    new() { Name = "Maija Renkomäki", Address = "Mäkikatu 551, 46800 Seinäjoki", Country = "Finland" },
    new() { Name = "Ella Papadopoulos", Address = "Leoforos Vasilissis Sofias 25, Athens 106 74", Country = "Greece" },
    new() { Name = "Daniel Chen", Address = "88 Nathan Road, Tsim Sha Tsui, Kowloon", Country = "Hong Kong" },
    new() { Name = "Freja Hansen", Address = "Vestergade 12, 8000 Aarhus", Country = "Denmark" },
    new() { Name = "Jack Thompson", Address = "55 Bloor Street West, Toronto, ON M4W 1A5", Country = "Canada" }
];

// Query syntax: people living in Finland
List<Person> peopleInFinland = [.. from p in people
                               where p.Country == "Finland"
                               select p];

// Using method syntax
List<Person> peopleInFinland2 = [.. people.Where(p => p.Country == "Finland")];

foreach (Person person in peopleInFinland)
{
    Console.WriteLine(person.Name);
}
