using System;
using System.Collections.Generic;
using System.Text;

namespace DISample
{
    public class HomeController
    {
        private readonly IGreetingService _greetingService;

        public HomeController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        public string Index(string name)
        {
            var result = _greetingService.Greet(name);
            return result.ToUpper();
        }
    }
}
