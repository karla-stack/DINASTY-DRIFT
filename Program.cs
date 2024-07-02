using System;
namespace Proyecto
{
    class Program
    {
        static void Main()
        {
            bool game = false;

            while(!game)
            {

                Console.WindowHeight = 40; //UI/UX 
                Console.WindowHeight = 50;

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkBlue;


                
                Console.WriteLine("Menú principal");  //Opciones del menú
                Console.WriteLine("1. Iniciar juego");
                Console.WriteLine("2. Instrucciones");
                Console.WriteLine("3. Configuraciones");
                Console.WriteLine("4. Acerca de ");
                Console.WriteLine("5. Salir del juego");

                Console.WriteLine("Seleccione una opcion ");
                string? opcionAsString = Console.ReadLine(); // Pidiendo datos 

                int opcion;
                if(int.TryParse(opcionAsString, out opcion))//Convirtiendo datos
                {
                  switch(opcion)  // en los cases van los métodos 
                  {
                    case 1:
                    break;

                    case 2:
                    break;

                    case 3:
                    break;

                    case 4:
                    break;

                    case 5:
                    game = true;
                    Console.WriteLine("Gracias por jugar"); // El bucle se rompe y termina el programa
                    break; 

                   }
                }
                else
                {
                    Console.WriteLine("Error insertar un numero de menú válido"); //En caso de que el usuario ingrese un valor inválido
                }


            }
            
        }
    }
}