using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Graph2.Channels.Vectors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graph2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerVector Vector { get; set; }

        public CustomerController(CustomerVector vector) 
                                    => Vector = vector;

        [HttpGet]
        public async Task<IActionResult> Get() 
            => new ObjectResult(await Vector.GetAllJSON());


        }
}