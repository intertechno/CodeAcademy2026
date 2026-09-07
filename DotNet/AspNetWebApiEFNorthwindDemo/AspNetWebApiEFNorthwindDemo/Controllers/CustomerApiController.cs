using AspNetWebApiEFNorthwindDemo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNetWebApiEFNorthwindDemo.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        public List<Customer> Get()
        {
            using NorthwindContext context = new();
            return [.. context.Customers];
        }
    }
}
