using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPIServer.Controllers
{
    [Route("api/Calculator")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        [HttpGet("add/{x}/{y}")]
        public int Add(int x, int y) => x + y;

        [HttpGet("subtract/{x}/{y}")]
        public int Abc(int x, int y) => x - y;

        [HttpGet("theansweroftheuniverse")]
        public int TheAnswer() => 42;
    }
}