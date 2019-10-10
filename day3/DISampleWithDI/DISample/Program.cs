using System;

namespace DISample
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new HomeController(new GreetingService());
            var result = controller.Index("Katharina");
            Console.WriteLine(result);
        }
    }
}
