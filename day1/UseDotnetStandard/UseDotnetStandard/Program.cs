using SharedLib;
using System;

namespace UseDotnetStandard
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = new Foo().Bar();
            Console.WriteLine(s);
        }
    }
}
