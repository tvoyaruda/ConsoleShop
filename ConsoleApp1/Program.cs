using System;
using Data;
using Entities;
using BLL;
using PL;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Menu m = new Menu();
            m.Run();
            Console.ReadLine();
        }
    }
}
