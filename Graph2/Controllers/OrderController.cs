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
    public class OrderController : ControllerBase
    {
        public OrderVector Vector { get; set; }

        public OrderController(OrderVector vector) 
            => Vector = vector;

        [HttpGet]
        public async Task<IActionResult> Get() 
            => new ObjectResult(await Vector.GetAllJSON());

    }
}