using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace ProjectoJuegoCarro
{
    class Menu
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
                Console.CursorVisible = false;
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
                            JuegoDeCarro.InicioJuego();//En caso de que sea 0 se ejecutar el metodo que pusieron de inicio de juego
                            break;
                        case 1:
                            Console.WriteLine("Mostrando instrucciones...");
                            Thread.Sleep(2000); //espero 2 segundos para hacer un aguaje
                            Instrucciones();
                            break;
                        case 2:
                            Console.WriteLine("Mostrando información acerca de...");
                            Thread.Sleep(2000);
                            AcercaDe();
                            break;
                        case 3:
                            game = true;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(@"

█████▀█████████████████████████████████████████████████████████████████████████▀█████████████
█─▄▄▄▄█▄─▄▄▀██▀▄─██─▄▄▄─█▄─▄██▀▄─██─▄▄▄▄███▄─▄▄─█─▄▄─█▄─▄▄▀█████▄─▄█▄─██─▄█─▄▄▄▄██▀▄─██▄─▄▄▀█
█─██▄─██─▄─▄██─▀─██─███▀██─███─▀─██▄▄▄▄─████─▄▄▄█─██─██─▄─▄███─▄█─███─██─██─██▄─██─▀─███─▄─▄█
▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▀▀▄▄▄▀▀▀▄▄▄▄▀▄▄▀▄▄▀▀▀▄▄▄▀▀▀▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▀▄▄▀
███████████████████████████████████████████████████████████████████████████
█▄─▄▄▀█▄─▄█▄─▀█▄─▄██▀▄─██─▄▄▄▄█─▄─▄─█▄─█─▄███▄─▄▄▀█▄─▄▄▀█▄─▄█▄─▄▄─█─▄─▄─█░█
██─██─██─███─█▄▀─███─▀─██▄▄▄▄─███─████▄─▄█████─██─██─▄─▄██─███─▄█████─███▄█
▀▄▄▄▄▀▀▄▄▄▀▄▄▄▀▀▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▀▄▄▄▀▀▀▄▄▄▀▀▀▀▄▄▄▄▀▀▄▄▀▄▄▀▄▄▄▀▄▄▄▀▀▀▀▄▄▄▀▀▄▀");//En caso de que quiera salir
                            Console.ResetColor(); 
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
                Console.WriteLine(nombres);
                Thread.Sleep(intervalo);
            }
            Console.WriteLine(" Version 1.5.3");
            Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
            Console.ReadKey(true);
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
                Console.WriteLine("Tu objetivo es manejar un carro que se mueve manualmente de izquierda a derecha.");
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


    public class JuegoDeCarro //contenedor lógico 
    {
        //todas las variables, matriz, elementos importantes que componen el programa 
        static int AnchoDeCarretera = 7; //Ancho de la carretera
        static bool JuegoCorriendo = true; //Indica si el juego está corriendo
        static int Velocidad = 0; //Afecta la frecuencia de actualizacion
        static Random Aleatorio = new Random(); //Generador de numeros aleatorios para obstaculos
        static bool[,] Camino = new bool[15, 7]; //Matriz que representa el camino
        static int PosicionDelCarro = 3; //Posicion inicial del carro

        static int puntaje = 0; //Puntaje del jugador

        static string nombre = ""; //Nombre del jugador 

        public static void InicioJuego()
        {
            bool salir = false;

            do
            {
                Console.CursorVisible = false; //Ocultar cursor 
                SeleccionarDificultad(); //Selecciona dificultad
                nombre = ObtenerNombreJugador(); //Obtiene el nombre del jugador

                if (Velocidad > 0) // Solo iniciar el juego si se seleccionó una dificultad válida
                {
                    JuegoCorriendo = true;
                    puntaje = 0;
                    DateTime startTime = DateTime.Now; //Marca el tiempo de inicio 

                    Thread inputThread = new Thread(Entrada);
                    inputThread.Start();

                    // Restablecer el camino antes de comenzar
                    RestablecerCamino();

                    // Bucle principal del juego
                    do
                    {
                        GeneradorDeObstaculos();
                        PistaYObstaculos();
                        Colision();

                        // Incrementa el score basado en el tiempo transcurrido 
                        TimeSpan elapsedTime = DateTime.Now - startTime;
                        puntaje = (int)elapsedTime.TotalSeconds;

                        Thread.Sleep(Velocidad);
                    } while (JuegoCorriendo);

                    inputThread.Join();

                    // Muestra la pantalla de fin de juego 
                    MostrarPantallaFinJuego();

                    // Muestra la opción para volver a jugar o salir 
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(@"
                    ████████████████████████████████████████████████████████
                    █─▄▄▄─█─▄▄─█▄─▀█▄─▄█─▄─▄─█▄─▄█▄─▀█▄─▄█▄─██─▄█▄─▄▄─█▀▄▄▀█
                    █─███▀█─██─██─█▄▀─████─████─███─█▄▀─███─██─███─▄█▀███▄██
                    ▀▄▄▄▄▄▀▄▄▄▄▀▄▄▄▀▀▄▄▀▀▄▄▄▀▀▄▄▄▀▄▄▄▀▀▄▄▀▀▄▄▄▄▀▀▄▄▄▄▄▀▀▀▄▀▀");
                    Console.WriteLine("1. Sí");
                    Console.WriteLine("2. No, salir");
                    Console.ResetColor();

                    char replayChoice = Console.ReadKey(true).KeyChar; // Captura la opción
                    if (replayChoice != '1') // Si el usuario elige no volver a jugar sale del bucle
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

        static string ObtenerNombreJugador()
        {
            Console.WriteLine("Insertar tu nombre de jugador: ");
            string? nombre = Console.ReadLine();
            return nombre ?? "Jugador"; // Si es empty or null return "Jugador"
        }

        static void PistaYObstaculos()
        {
            Console.Clear();
            for (int i = 0; i < Camino.GetLength(0); i++) // Iterar a través de cada fila de la matriz 'Camino'
            {
                for (int j = 0; j < AnchoDeCarretera; j++) // Iterar a través de cada columna de la matriz 'Camino'
                {
                    if (i == Camino.GetLength(0) - 1 && j == PosicionDelCarro) // Si estamos en la última fila de la matriz 'Camino' Y en la posición del carro, dibuja el carro
                        Console.Write('▲'); // Carro
                    else if (Camino[i, j])
                        Console.Write('='); // Obstáculo
                    else
                        Console.Write('|'); // Carretera
                }
                Console.WriteLine();
            }
        }

        static void SeleccionarDificultad()
        {
            bool selectingDifficulty = true;

            while (selectingDifficulty)
            {
                Console.Clear();
                Console.WriteLine("Seleccione la dificultad:");
                Console.WriteLine("\n1. Fácil");
                Console.WriteLine("\n2. Normal");
                Console.WriteLine("\n3. Difícil");
                Console.WriteLine("\n\nPresione Esc para salir.");

                char choice = Console.ReadKey(true).KeyChar;

                switch (choice)
                {
                    case '1':
                        Velocidad = 1000; // Aumentar el tiempo de espera para facilitar el juego.
                        Console.ForegroundColor = ConsoleColor.Cyan;
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
                        Console.ResetColor();
                        break;
                    case '2':
                        Velocidad = 600; // Menos aumento para dificultad normal.
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(@"
                     _____   __                              ______     
                     ___  | / /___________________ _________ ___  /     
                     __   |/ /_  __ \_  ___/_  __ `__ \  __ `/_  /      
                     _  /|  / / /_/ /  /   _  / / / / / /_/ /_  /       
                     /_/ |_/  \____//_/    /_/ /_/ /_/\__,_/ /_/        
                        ");
                        selectingDifficulty = false;
                        Console.ResetColor();
                        break;
                    case '3':
                        Velocidad = 400; // Nada de tiempo de espera aumento para dificultad difícil.
                        Console.ForegroundColor = ConsoleColor.Red;
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
                        Console.ResetColor();
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
            }
        }

        static void GeneradorDeObstaculos()
        {
            for (int i = Camino.GetLength(0) - 1; i > 0; i--) // Mover los obstáculos existentes hacia abajo
            {
                for (int j = 0; j < AnchoDeCarretera; j++) // Va moviendo el estado del obstáculo de la fila superior a la actual
                {
                    Camino[i, j] = Camino[i - 1, j]; // Moviendo así los obstáculos una fila hacia abajo
                }
            }

            for (int j = 0; j < AnchoDeCarretera; j++)
            {
                if (Aleatorio.Next(0, 10) < 4) // 40% de probabilidad de generar un obstáculo
                {
                    if (!Camino[0, j]) // Solo genera un obstáculo si no hay uno ya 
                    {
                        Camino[0, j] = true;
                    }
                }
                else
                {
                    Camino[0, j] = false; // Deja espacio libre si no se genera un obstáculo
                }
            }
        }

        static void Colision()
        {
            if (Camino[Camino.GetLength(0) - 1, PosicionDelCarro]) // Si hay un obstáculo en la posición del carro
            {
                JuegoCorriendo = false; // Termina el juego
            }
        }

        static void Entrada()
        {
            while (JuegoCorriendo) // Continuar mientras el juego está corriendo 
            {
                var key = Console.ReadKey(true).Key; // Para leer la tecla presionada 

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (PosicionDelCarro > 0) PosicionDelCarro--; // Mover el carro a la izquierda si no está en el borde
                        break;
                    case ConsoleKey.RightArrow:
                        if (PosicionDelCarro < AnchoDeCarretera - 1) PosicionDelCarro++; // Mover el carro a la derecha si no está en el borde
                        break;
                    case ConsoleKey.Escape:
                        JuegoCorriendo = false; // Terminar el juego si se presiona ESC
                        break;
                }
            }
        }

        static void RestablecerCamino() //Esta funcion restablece el camino cada vez que se inicia la matrix camino
        {
            for (int i = 0; i < Camino.GetLength(0); i++)
            {
                for (int j = 0; j < Camino.GetLength(1); j++)
                {
                    Camino[i, j] = false;
                }
            }
        }

        static void MostrarPantallaFinJuego()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"
            ██╗░░██╗░█████╗░░██████╗
            ██║░░██║██╔══██╗██╔════╝
            ███████║███████║╚█████╗░
            ██╔══██║██╔══██║░╚═══██╗
            ██║░░██║██║░░██║██████╔╝
            ╚═╝░░╚═╝╚═╝░░╚═╝╚═════╝░

            ░█████╗░░█████╗░██╗░░░░░██╗░██████╗██╗░█████╗░███╗░░██╗░█████╗░██████╗░░█████╗░██╗
            ██╔══██╗██╔══██╗██║░░░░░██║██╔════╝██║██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔══██╗██║
            ██║░░╚═╝██║░░██║██║░░░░░██║╚█████╗░██║██║░░██║██╔██╗██║███████║██║░░██║██║░░██║██║
            ██║░░██╗██║░░██║██║░░░░░██║░╚═══██╗██║██║░░██║██║╚████║██╔══██║██║░░██║██║░░██║╚═╝
            ╚█████╔╝╚█████╔╝███████╗██║██████╔╝██║╚█████╔╝██║░╚███║██║░░██║██████╔╝╚█████╔╝██╗
            ░╚════╝░░╚════╝░╚══════╝╚═╝╚═════╝░╚═╝░╚════╝░╚═╝░░╚══╝╚═╝░░╚═╝╚═════╝░░╚════╝░╚═╝");
            Console.WriteLine("Juego terminado.");
            Console.WriteLine($"Nombre del jugador: {nombre}");
            Console.WriteLine($"Puntaje del jugador: {puntaje}");
            Console.WriteLine("Presiona cualquier tecla para volver al menú.");
            Console.ReadKey(true); // Espera a que el usuario presione una tecla
            Console.ResetColor();
        }
    }
}