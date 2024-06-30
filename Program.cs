using System;
namespace Proyecto
{
    class Progam
    {
        static void Main()
        {
            Console.WriteLine("Inserte un numero: ");
            string? numberAsString = Console.ReadLine();
            int number = Convert.ToInt32(numberAsString);
        }
    }
}