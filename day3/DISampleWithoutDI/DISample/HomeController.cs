using System;
using System.Collections.Generic;
using System.Text;

namespace DISample
{
    public class HomeController
    {
        public string Index(string name)
        {
            var service = new GreetingService();
            var result = service.Greet(name);
            return result.ToUpper();
        }
    }
}
