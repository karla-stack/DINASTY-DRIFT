using System;
using System.Text;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        MostrarMenu();
    }

    static void MostrarMenu()
    {
        bool game = false; //Creamos la variable de bucle para usarla en el while del codigo
        int opcionSeleccionada = 0; //declaro y inicio la variable para así saber que opción elige el jugador
        string[] opciones = { "Iniciar juego", "Instrucciones", "Configuraciones", "Acerca de", "Salir del juego" };

        while (!game) //Aqui se crea un bucle que mientras el jugador no le de a salir o no ejecute una de las opciones del break no va a terminar.
        {
            Console.Clear(); // Limpiar la consola en cada iteración del menú porque si no se va a ver raro.

            // Le cambiamos los colores a la consola.
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string imagenDelMenu = @"
                          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⡤⢤⣶⣶⣶⣶⣶⣒⣒⣀⣺⣿⣿⠿⢶⣶⣶⣶⣦⣤⣤⣤⣄⣀⣀⣀⣀⡀⠀⠀
       ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⠴⠚⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠛⠒⠲⠦⢤⣉⠙⣿⣿⣿⣟⢿⣿⠿⠿⠿⢿⣿  
       ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣶⣷⡦⠞⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⡇⠀⠈⠛⢿⣿⡀⠀⠀⠀⠻    
      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣤⠤⢴⣿⣉⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠇⠀⠀⠀⠀⠙⣿⣄⡀⠀⠀    
       ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣤⡶⠞⠛⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠓⠒⠒⠢⠤⠤⣄⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⠀⢠⠤⠤⠤⣤⣾⠀⠙⢦⡀  
        ⠀⠀⠀⠀⠀⠀⠀⠀⣠⠴⣮⣛⣩⢴⡿⠿⠶⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠙⠒⠒⠒⠤⠤⢤⣤⣾⢿⣴⢏⣀⣀⣤⡼⠻⡆⠀⠈⢷  
       ⠀⠀⠀⠀⠀⢀⣴⠋⠁⠀⠀⠀⠀⠙⠓⠲⠤⠬⠷⠀⠀⢀⣀⣀⣀⣀⣀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⠤⡞⠉⠀⠀⠹⡟⠀⠀⠀⠀⠀⢱⠀⢠⣼    
        ⠀⠀⠀⣀⡴⠋⠈⢙⡞⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠛⠢⠤⢄⣀⣠⠴⠛⣋⣠⠴⠒⠉⠉⢉⣲⠶⠀⣀⡠⠤⠒⠊⠉⠁⠀⠀⠀⠠⠀⡂⠐⢹⠂⠀⠀⠀⠀⣼⢰⣿⣿  
        ⡀⣠⣼⠏⠀⠀⣰⠟⠦⢤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠓⠒⠒⠒⠋⣉⠤⠒⠋⠁⠀⠀⠀⠀⡀⠠⠀⠈⠀⠁⠀⠀⠀⢸⠀⠀⠀⠀⢀⣯⣼⣿⣿    
        ⡟⠋⠹⢤⣠⠞⠁⠀⠀⠀⠀⠈⠉⠐⠲⠤⢄⣀⡀⠀⠀⠀⠀⣀⠤⠤⠤⠤⠤⣄⣀⣀⠀⢀⡠⠖⠋⠀⠀⠀⠄⡠⢐⠤⠀⠂⠀⣀⣀⡀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⢸⣿⣿⣿⣿  
       ⢻⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⢒⡶⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⢦⠀⠀⠀⠈⠈⠀⠀⠀⠀⢀⣴⣿⡿⣿⡝⣆⠀⠀⠀⠴⣽⠤⠞⣠⣵⠿⣻⣿⣿⠈  
        ⢿⣿⣿⠶⢤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡴⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢨⠇⠀⠀⠀⠀⣀⣀⣤⣤⣾⣿⢿⡆⢸⣧⢹⠀⠄⣪⣶⣿⣴⠟⢋⣥⠴⢻⣿⠏⠀ 
        ⢸⣿⣿⡇⠀⠘⣿⣶⣦⣤⣀⡀⠀⠀⠀⠀⠀⠀⠈⠑⠲⠤⢤⣀⣀⡀⠀⠀⠀⠀⠀⠀⣀⣀⣞⣀⣠⣤⣾⣿⣿⣿⣿⣿⣿⢻⢸⣿⣾⣿⣾⣤⣾⣿⠿⢋⡡⠞⠉⠉⠉⠉⠀⠀⠀
       ⣼⡟⣿⡇⠀⠀⢹⣄⠈⠙⠒⠯⣽⣶⢶⣤⣤⣄⣀⣀⠀⠀⠀⠀⠈⠙⠻⠿⠿⠿⠿⠿⠿⠛⠛⠛⢉⣉⣽⠶⣿⠟⣿⣿⣧⣿⣾⣿⣿⡇⢹⡿⠋⣡⠖⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀
       ⣇⠳⣼⣧⠴⠛⠉⠉⠉⠒⣦⣤⣀⡀⠀⠀⠉⠙⢦⠀⠉⠉⢙⣷⣶⠒⠒⠒⠶⡶⠶⠶⢶⣤⠖⠚⠉⠁⠀⣰⣷⠾⣿⢿⢥⣼⣾⣿⣿⠃⣸⣠⠞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀
       ⠈⠳⣌⣿⢦⣄⠀⢀⣴⣿⣿⣷⣿⡯⣗⠲⠤⣀⡈⣇⠀⠀⠻⡄⠈⣷⠀⠀⠀⡿⠒⠶⠾⢿⠀⠀⠀⢠⣾⡏⠁⣸⡇⢸⡸⢠⡌⢡⣿⠴⠿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
       ⠀⠀⠈⠙⠳⢿⣙⠺⢽⣿⣮⣿⣿⠗⠋⠀⠀⠀⠉⡿⠀⠀⣀⣹⣿⣯⣤⣶⣚⣛⣒⣛⣓⣿⠀⠀⠀⢽⣿⣶⣶⡏⢧⣼⣷⡿⢁⣾⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
       ⠀⠀⠀⠀⠀⠀⠈⠙⠢⢬⣙⠛⠧⢤⣀⣀⠀⢀⣴⠃⠀⢀⣹⢦⣤⣉⣉⣯⣍⣹⣿⣿⣿⡃⣀⡤⠴⠛⠋⠁⠀⡇⠘⣜⣏⣠⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
       ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠓⠦⢤⣈⡉⠉⠙⠛⠛⠛⠲⠤⠤⠤⠴⣶⣶⣿⣿⢿⡿⣯⠀⠀⠀⠀⠀⢀⣠⡟⠤⠿⠟⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠒⠲⠤⢤⣄⣀⣀⣀⣤⣈⣤⣤⠤⣴⣿⣥⠤⠴⠒⠚⠋⠉                    
";

            Console.WriteLine(imagenDelMenu);
            // Thread.Sleep(500);
        

            // Mostrar opciones del menú
            Console.WriteLine("Menú principal");
            MostrarOpcionesMenu(opciones, opcionSeleccionada);

            // Leer la tecla presionada por el usuario la declare con ConsoleKeyInfo
            ConsoleKeyInfo tecla = Console.ReadKey(true);

            // Determinar la acción según la tecla presionada
            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow:
                    if (opcionSeleccionada > 0)
                        opcionSeleccionada--;
                    break;
                case ConsoleKey.DownArrow:
                    if (opcionSeleccionada < opciones.Length - 1) //Aqui yo verifico si la opción del menu no es la última opción del menu
                        opcionSeleccionada++; //le aumento uno para que se mueva una opción para abajo
                    break;
                case ConsoleKey.Enter:
                    // Ejecutar la opción seleccionada
                    Console.Clear(); // Limpiar la consola antes de mostrar el resultado
                    switch (opcionSeleccionada)
                    {
                        case 0:
                            Juego.InicioJuego(); //En caso de que sea 0 se ejecutar el metodo que pusieron de inicio de juego
                            break;
                        case 1:
                            Console.WriteLine("Mostrando instrucciones...");
                            Thread.Sleep(2000); //espero 2 segundos para hacer un aguaje
                            Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
                            Console.ReadKey(true);
                            break;
                        case 2:
                            Console.WriteLine("Mostrando configuraciones...");
                            Thread.Sleep(2000); //espero 2 segundos para hacer un aguajex2
                            Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
                            Console.ReadKey(true);
                            break;
                        case 3:
                            Console.WriteLine("Mostrando información acerca de...");
                            Thread.Sleep(2000); //espero 2 segundos para hacer un aguajex3
                            Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
                            Console.ReadKey(true);
                            break;
                        case 4:
                            game = true;
                            Console.WriteLine("Gracias por jugar"); //En caso de que quiera salir
                            break;
                        default:
                            Console.WriteLine("Opción no válida."); // Por si pone una loquera
                            break;
                    }
                    break;
            }
        }
    }

    static void MostrarOpcionesMenu(string[] opciones, int opcionSeleccionada)
    {
        for (int i = 0; i < opciones.Length; i++)
        {
            if (i == opcionSeleccionada)
            {
                // Resaltar la opción seleccionada con colores inversos
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            Console.WriteLine($"{i + 1}. {opciones[i]}"); // Mostrar la opción del menú
            Console.ResetColor(); // Aqui reinicie los colores del programa para que el juego no se inicie con azul y eso del menu.
        }
        Console.SetCursorPosition(3, 4 + opciones.Length);
    }
}

class Juego
{
    static int filas = 40;
    static int columnas = 10;
    static char[,] pista = new char[filas, columnas];
    static int posicionCarroFila = filas - 2; 
    static int posicionCarroColumna = columnas / 2; 

   public static void InicioJuego()
    {
        Pista();
        //Movimiento();
        Console.WriteLine("Presione 'Q' o 'Esc'  para volver al menú principal...");
        while (Console.ReadKey(true).Key != ConsoleKey.Q)
        {
            // Esperar hasta que se presione 'Q'
        }
    }

    static void Pista()
    {
        // Llenar la pista
        for (int i = 0; i < filas; i++)
        {
            for (int c = 0; c < columnas; c++)
            {
                if (i == 0 || i == filas - 1 || c == 0 || c == columnas - 1)
                {
                    pista[i, c] = '|'; // Borde de la pista
                }
                else
                {
                    pista[i, c] = ' '; // Camino de la pista
                }

            }
        }
        MostrarPista();

    }

    static void MostrarPista()
    {
        Console.Clear();

        for (int i = 0; i < filas; i++)
        {
            for (int c = 0; c < columnas; c++)
            {
            Console.Write(pista[i, c]);
            }
            Console.WriteLine();
        }
    }

    /*static void Movimiento() //CHAT GPT PRUEBA
    {
        while (true)
        {
            ConsoleKeyInfo tecla = Console.ReadKey(true);
            switch (tecla.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (posicionCarroColumna > 1)
                    {
                        pista[posicionCarroFila, posicionCarroColumna] = ' ';
                        posicionCarroColumna--;
                        pista[posicionCarroFila, posicionCarroColumna] = 'A';
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (posicionCarroColumna < columnas - 2)
                    {
                        pista[posicionCarroFila, posicionCarroColumna] = ' ';
                        posicionCarroColumna++;
                        pista[posicionCarroFila, posicionCarroColumna] = 'A';
                    }
                    break;
                case ConsoleKey.Escape:
                    return; // Salir del juego
            }
            MostrarPista();
        }
    } */
}    