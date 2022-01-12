using System;

namespace ForTestConsole
{
    class Program
    {
        const int a = 1;
#nullable enable
        static void Main(string[] args)
        {
            Guid guid = Guid.NewGuid();
            Guid guid1 = Guid.NewGuid();
            Console.WriteLine(guid);
            Console.WriteLine(guid1);
            string a = "a";
            string b = a;
            Console.WriteLine(a == b);
            b = b + "1";
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
