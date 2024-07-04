using System;
using System.Drawing;
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
        string[] opciones = { "Iniciar juego", "Instrucciones","Acerca de", "Salir del juego" };

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


█████████████████████████████████████████████████████████████████████████
█▄─▄▄▀█▄─▄█▄─▀█▄─▄██▀▄─██─▄▄▄▄█─▄─▄─█▄─█─▄███▄─▄▄▀█▄─▄▄▀█▄─▄█▄─▄▄─█─▄─▄─█
██─██─██─███─█▄▀─███─▀─██▄▄▄▄─███─████▄─▄█████─██─██─▄─▄██─███─▄█████─███
▀▄▄▄▄▀▀▄▄▄▀▄▄▄▀▀▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▀▄▄▄▀▀▀▄▄▄▀▀▀▀▄▄▄▄▀▀▄▄▀▄▄▀▄▄▄▀▄▄▄▀▀▀▀▄▄▄▀▀

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
                            ProjectoJuegoCarro.JuegoDeCarro.InicioJuego();//En caso de que sea 0 se ejecutar el metodo que pusieron de inicio de juego
                            break;
                        case 1:
                            Console.WriteLine("Mostrando instrucciones...");
                            Thread.Sleep(2000); //espero 2 segundos para hacer un aguaje
                            Instrucciones();
                            break;
                        case 2:
                            Console.WriteLine("Mostrando información acerca de...");
                            AcercaDe();
                            Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
                            Console.ReadKey(true);
                            break;
                        case 3:
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

    static void AcercaDe()
    {
        Thread.Sleep(2000);
        string nombres = @"
        
███████╗███╗░░██╗███╗░░░███╗░█████╗░███╗░░██╗██╗░░░██╗███████╗██╗░░░░░
██╔════╝████╗░██║████╗░████║██╔══██╗████╗░██║██║░░░██║██╔════╝██║░░░░░
█████╗░░██╔██╗██║██╔████╔██║███████║██╔██╗██║██║░░░██║█████╗░░██║░░░░░
██╔══╝░░██║╚████║██║╚██╔╝██║██╔══██║██║╚████║██║░░░██║██╔══╝░░██║░░░░░
███████╗██║░╚███║██║░╚═╝░██║██║░░██║██║░╚███║╚██████╔╝███████╗███████╗
╚══════╝╚═╝░░╚══╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝░╚═════╝░╚══════╝╚══════╝

██╗░░██╗░█████╗░██████╗░██╗░░░░░░█████╗░
██║░██╔╝██╔══██╗██╔══██╗██║░░░░░██╔══██╗
█████═╝░███████║██████╔╝██║░░░░░███████║
██╔═██╗░██╔══██║██╔══██╗██║░░░░░██╔══██║
██║░╚██╗██║░░██║██║░░██║███████╗██║░░██║
╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝

██╗░██████╗░█████╗░░█████╗░░█████╗░
██║██╔════╝██╔══██╗██╔══██╗██╔══██╗
██║╚█████╗░███████║███████║██║░░╚═╝
██║░╚═══██╗██╔══██║██╔══██║██║░░██╗
██║██████╔╝██║░░██║██║░░██║╚█████╔╝
╚═╝╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝░╚════╝░

██╗░░██╗███████╗░█████╗░████████╗░█████╗░██████╗░
██║░░██║██╔════╝██╔══██╗╚══██╔══╝██╔══██╗██╔══██╗
███████║█████╗░░██║░░╚═╝░░░██║░░░██║░░██║██████╔╝
██╔══██║██╔══╝░░██║░░██╗░░░██║░░░██║░░██║██╔══██╗
██║░░██║███████╗╚█████╔╝░░░██║░░░╚█████╔╝██║░░██║
╚═╝░░╚═╝╚══════╝░╚════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝
        
        ";
        Console.WriteLine(nombres);
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

    static void Instrucciones()
    {
        string imagenInstrucciones = @"
        
            _____ _____ _____ _____       __ _____ _____ _____ _____ 
            |     |     |     |     |   __|  |  |  |   __|  _  | __  |
            |   --|  |  | | | |  |  |  |  |  |  |  |  |  |     |    -|
            |_____|_____|_|_|_|_____|  |_____|_____|_____|__|__|__|__|
        
        
        
        ";

        ConsoleColor[] colors = new ConsoleColor[]
        {
            ConsoleColor.Red,
            ConsoleColor.Green,
            ConsoleColor.Blue,
            ConsoleColor.Yellow,
            ConsoleColor.Gray,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkBlue
        };

        int intervalo = 400;
        
            foreach(var color in colors)
            {
                Console.Clear();
                Console.ForegroundColor = color;
                Console.WriteLine(imagenInstrucciones);
                Thread.Sleep(intervalo);
            }
            Console.WriteLine("¡Bienvenido al juego de carreras en la consola!");
            Console.WriteLine("================================================");
            Console.WriteLine();
            Console.WriteLine("Instrucciones:");
            Console.WriteLine("==============");
            Console.WriteLine("Tu objetivo es manejar un carro que se mueve automáticamente de izquierda a derecha.");
            Console.WriteLine("Debes evitar chocar con los obstáculos que aparecen en tu camino.");
            Console.WriteLine("Para mover el carro, utiliza las teclas de dirección:");
            Console.WriteLine("   - Izquierda (←) para mover el carro hacia la izquierda.");
            Console.WriteLine("   - Derecha (→) para mover el carro hacia la derecha.");
            Console.WriteLine();
            Console.WriteLine("¡Presta atención y reacciona rápido! dependiendo de la velocidad que escojas,");
            Console.WriteLine("los obstáculos se volverán más frecuentes a medida que avanzas.");
            Console.WriteLine();
            Console.WriteLine("¡Buena suerte y que empiece la carrera!");
            Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
            Console.ReadKey(true);
    }
}


namespace ProjectoJuegoCarro
{
    public class JuegoDeCarro
    {
        static int AnchoDeCarretera = 3;
        static bool JuegoCorriendo = true;
        static int Velocidad = 0;
        static Random Aleatorio = new Random();
        static bool[,] Camino = new bool[20, 3];
        static int PosicionDelCarro = 1;

        public static void InicioJuego()
        {
            bool salir = false;

            do
            {
                Console.CursorVisible = false;
                SeleccionarDificultad();

                if (Velocidad > 0) // Solo iniciar el juego si se seleccionó una dificultad válida
                {
                    JuegoCorriendo = true;
                    Thread inputThread = new Thread(Entrada);
                    inputThread.Start();

                    while (JuegoCorriendo)
                    {
                        GeneradorDeObstaculos();
                        PistaYObstaculos();
                        Colision();
                        Thread.Sleep(Velocidad);
                    }

                    inputThread.Join();

                    Console.Clear();
                    Console.WriteLine("¡Colisión! Juego terminado.");
                    Console.WriteLine("Presiona cualquier tecla para volver al menú.");
                    Console.ReadKey(true); // Espera a que el usuario presione una tecla

                    Console.Clear();
                    Console.WriteLine("¿Deseas jugar de nuevo?");
                    Console.WriteLine("1. Sí");
                    Console.WriteLine("2. No, salir");

                    char replayChoice = Console.ReadKey(true).KeyChar;
                    if (replayChoice != '1')
                    {
                        salir = true;
                    }
                }
                else
                {
                    salir = true; // Si no se seleccionó una dificultad, salir del programa
                }

            } while (!salir);
        }

        static void PistaYObstaculos()
        {
            Console.Clear();
            for (int i = 0; i < Camino.GetLength(0); i++)
            {
                for (int j = 0; j < AnchoDeCarretera; j++)
                {
                    if (i == Camino.GetLength(0) - 1 && j == PosicionDelCarro)
                        Console.Write('O'); // Carro
                    else if (Camino[i, j])
                        Console.Write('=');
                    else
                        Console.Write('|');
                }
                Console.WriteLine();
            }
        }

        static void SeleccionarDificultad()
        {
            bool selectingDifficulty = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Seleccione la dificultad:");
                Console.WriteLine("1. Fácil");
                Console.WriteLine("2. Normal");
                Console.WriteLine("3. Difícil");
                Console.WriteLine("Presione Esc para salir.");

                char choice = Console.ReadKey(true).KeyChar;

                switch (choice)
                {
                    case '1':
                        Velocidad = 600; // Aumentar el tiempo de espera para facilitar el juego.
                        Console.WriteLine(@"
                      ______                
                      |  ____|               
                      | |__   __ _ ___ _   _ 
                      |  __| / _` / __| | | |
                      | |___| (_| \__ \ |_| |
                      |______\__,_|___/\__, |
                                        __/ |
                                       |___/ 
                        ");
                        selectingDifficulty = false;
                        break;
                    case '2':
                        Velocidad = 400; // Menos aumento para dificultad normal.
                        Console.WriteLine(@"

                     _____   __                              ______     
                     ___  | / /___________________ _________ ___  /     
                     __   |/ /_  __ \_  ___/_  __ `__ \  __ `/_  /      
                     _  /|  / / /_/ /  /   _  / / / / / /_/ /_  /       
                     /_/ |_/  \____//_/    /_/ /_/ /_/\__,_/ /_/        
                        
                        ");
                        selectingDifficulty = false;
                        break;
                    case '3':
                        Velocidad = 300; // Nada de tiempo de espera aumento para dificultad difícil.
                        Console.WriteLine(@"
                        
                           ██░ ██  ▄▄▄       ██▀███  ▓█████▄  ▄████▄   ▒█████   ██▀███  ▓█████     ▐██▌
                          ▓██░ ██▒▒████▄    ▓██ ▒ ██▒▒██▀ ██▌▒██▀ ▀█  ▒██▒  ██▒▓██ ▒ ██▒▓█   ▀     ▐██▌
                          ▒██▀▀██░▒██  ▀█▄  ▓██ ░▄█ ▒░██   █▌▒▓█    ▄ ▒██░  ██▒▓██ ░▄█ ▒▒███       ▐██▌
                          ░▓█ ░██ ░██▄▄▄▄██ ▒██▀▀█▄  ░▓█▄   ▌▒▓▓▄ ▄██▒▒██   ██░▒██▀▀█▄  ▒▓█  ▄     ▓██▒
                          ░▓█▒░██▓ ▓█   ▓██▒░██▓ ▒██▒░▒████▓ ▒ ▓███▀ ░░ ████▓▒░░██▓ ▒██▒░▒████▒    ▒▄▄ 
                           ▒ ░░▒░▒ ▒▒   ▓▒█░░ ▒▓ ░▒▓░ ▒▒▓  ▒ ░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒▓ ░▒▓░░░ ▒░ ░    ░▀▀▒
                          ▒ ░▒░ ░  ▒   ▒▒ ░  ░▒ ░ ▒░ ░ ▒  ▒   ░  ▒     ░ ▒ ▒░   ░▒ ░ ▒░ ░ ░  ░    ░  ░
                          ░  ░░ ░  ░   ▒     ░░   ░  ░ ░  ░ ░        ░ ░ ░ ▒    ░░   ░    ░          ░
                          ░  ░  ░      ░  ░   ░        ░    ░ ░          ░ ░     ░        ░  ░    ░   
                          ░      ░                                         
                        
                        ");
                        selectingDifficulty = false;
                        break;
                    case (char)ConsoleKey.Escape:
                        Console.WriteLine("Saliendo del juego...");
                        Thread.Sleep(1000); // Pequeña pausa antes de salir
                        Environment.Exit(0); // Salir del programa completamente
                        break;
                    default:
                        Console.WriteLine("Selección inválida. Inténtalo de nuevo.");
                        break;
                }

                if (!selectingDifficulty)
                {
                    Console.WriteLine("\nDificultad seleccionada. Presione cualquier tecla para comenzar el juego.");
                    Console.ReadKey(true);
                }
            } while (selectingDifficulty);
        }

        static void GeneradorDeObstaculos()
        {
            for (int i = Camino.GetLength(0) - 1; i > 0; i--)
            {
                for (int j = 0; j < AnchoDeCarretera; j++)
                {
                    Camino[i, j] = Camino[i - 1, j];
                }
            }

            for (int j = 0; j < AnchoDeCarretera; j++)
            {
                if(Aleatorio.Next(0,10)<2)
                {
                    if(!Camino[0, j])
                    {
                        Camino[0, j] = true;
                    }
                }
                else
                {
                    Camino[0, j] = false;
                }
            }
        }

        static void Colision()
        {
            if (Camino[Camino.GetLength(0) - 1, PosicionDelCarro])
            {
                JuegoCorriendo = false;
            }
        }

        static void Entrada()
        {
            while (JuegoCorriendo)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (PosicionDelCarro > 0) PosicionDelCarro--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (PosicionDelCarro < AnchoDeCarretera - 1) PosicionDelCarro++;
                        break;
                    case ConsoleKey.Escape:
                        JuegoCorriendo = false;
                        break;
                }
            }
        }
    }
}
