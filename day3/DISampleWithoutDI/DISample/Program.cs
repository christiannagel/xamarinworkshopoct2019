using System;

namespace DISample
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new HomeController();
            var result = controller.Index("Stephanie");
            Console.WriteLine(result);
        }
    }
}
