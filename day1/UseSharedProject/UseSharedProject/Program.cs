using MySharedProject;
using System;

namespace UseSharedProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = new Foo().Bar();
            Console.WriteLine(s);

            // this is in the master branch
        }
    }
}
