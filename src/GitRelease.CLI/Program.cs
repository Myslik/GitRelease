using System;

namespace GitRelease.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var greet = new Greet();
            Console.WriteLine(greet.Hello("world"));
        }
    }
}
