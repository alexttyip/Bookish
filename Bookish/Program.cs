using System;
using Bookish.Services;

namespace Bookish
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Out.WriteLine(UserServices.AuthenticateInputUser().ToString());
        }
    }
}