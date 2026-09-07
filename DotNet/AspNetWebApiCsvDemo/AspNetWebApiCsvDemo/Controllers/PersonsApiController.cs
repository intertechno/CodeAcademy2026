using AspNetWebApiCsvDemo.Models;
using AspNetWebApiCsvDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetWebApiCsvDemo.Controllers
{
    [Route("api/persons")]
    [ApiController]
    public class PersonsApiController : ControllerBase
    {
        public List<Person> GetAllPersons()
        {
            CsvPersonReader csvPersonReader = new();
            List<Person> persons = csvPersonReader.ReadPersonsFromCsv(@"Persons.csv");
            return persons;
        }
    }
}
