using System;
using System.Collections.Generic;
using System.Text;
#if WPF
using System.Windows;
#endif

namespace MySharedProject
{
    public class Foo
    {
        public string Bar()
        {
#if WPF
            MessageBox.Show("Hello, WPF!");
#else
            global::System.Console.WriteLine("Hello, some framework");
#endif
            return "Sample shared project";
        }
    }
}
