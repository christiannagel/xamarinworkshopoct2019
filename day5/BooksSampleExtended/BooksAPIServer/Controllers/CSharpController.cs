using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPIServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSharpController : ControllerBase
    {
        private readonly MySampleService _mySampleService;
        public CSharpController(MySampleService mySampleService)
        {
            _mySampleService = mySampleService;
        }

        [HttpGet]
        public async Task<ActionResult> DoWork()
        {
            await _mySampleService.DoWork();
            return Ok();
        }
    }
}