using System;
using Infrastructure;
using Domain;
using BLL;
using PL;

namespace ConsoleShop
{
    static class Program
    {
        static void Main(string[] args)
        {
            State m = new State();
            m.Run();
        }
    }
}
