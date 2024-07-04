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
                            ProjectoJuegoCarro.JuegoDeCarro.IniciarJuego();//En caso de que sea 0 se ejecutar el metodo que pusieron de inicio de juego
                            break;
                        case 1:
                            Console.WriteLine("Mostrando instrucciones...");
                            Thread.Sleep(2000); //espero 2 segundos para hacer un aguaje
                            Instrucciones();
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

        int tiempo = 10;
        int intervalo = 400;
        int formulaRara = (tiempo * 1000) / intervalo;
        int i = 0; 

        do
        {
            foreach(var color in colors)
            {
                Console.Clear();
                Console.WriteLine(imagenInstrucciones);
                Console.ForegroundColor = color;
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
            Console.WriteLine("¡Presta atención y reacciona rápido! La velocidad aumentará gradualmente,");
            Console.WriteLine("y los obstáculos se volverán más frecuentes a medida que avanzas.");
            Console.WriteLine();
            Console.WriteLine("¡Buena suerte y que empiece la carrera!");
            Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
            Console.ReadKey(true);
        } while (i < formulaRara);


    }
}


namespace ProjectoJuegoCarro //Nuevo organizador metodo para la iniciacion del juego
{
    public class JuegoDeCarro //La clase creada proporcional al juego.
    {
        static int AnchoDeCarretera = 3; //Difinimos un metodo para el ancho.
        static bool JuegoCorriendo = true;      //Otro metodo que vamos a usar como algo primoldial.
        static int Velocidad = 0;       //Este sera un poco mas variado.
        static Random Aleatorio = new Random(); //Un metodo para crear una nueva instancia no iniciada
        static bool[,] Camino = new bool[20, 3]; //Con este metodo creamos una matriz Bidimensional no iniciada.

        static int PosicionDelCarro = 1; // 0: Izquierda, 1: Centro, 2: Derecha. Recondando como recorre la matrix 0=1, 1=2, etc,


        public static void IniciarJuego() //No usamos Main porque solo podemos tener uno (creo).
        {
            Console.CursorVisible = false; //Se quita el cursor para que no interactue.
            SeleccionarDificultad();    //Llamamos esta primera opcion para seleccionar la dificultad

            Thread inputThread = new Thread(Entrada); //Se crea un hilo para ejecutar la entrada.
            inputThread.Start(); //Iniciamos el hilo

            while (JuegoCorriendo) //Este es el bucle principal del juego, Muentras el juego sea true sigue corriendo..
            {
                GeneradorDeObstaculos(); //Llamamos al generador de obstaculos
                PistaYObstaculos(); //Llamamos la creacion de la pista y los obstaculos.
                Colision();                 //Si coliciona salimos del bloque.
                Thread.Sleep(Velocidad);        //Esto pausa la ejecucion del hilo para que el juego vaya mas lento.
            }

            inputThread.Join(); //Esto detiene la ejecucion del hilo pero para que no finalice el programa.
        }    

        static void PistaYObstaculos() //Esto es para generar la pista, obstaculo y el carro.
        {
            Console.Clear();
            
            //Doble bucle para recorrer el camino y poner lo que definiremos como pista, etc.
            for (int i = 0; i < Camino.GetLength(0); i++) //Recorre las columnas
            {               
                for (int j = 0; j < AnchoDeCarretera; j++)//Recorre las filas
                {
                    if (i == Camino.GetLength(0) - 1 && j == PosicionDelCarro) 
                        Console.Write('O'); //Carro
                    else if (Camino[i, j])
                        Console.Write('='); //Obstaculo
                    else
                        Console.Write('|'); //Pista
                }
                Console.WriteLine(); //Aqui imprime todo
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

        
        static void SeleccionarDificultad()
        {
            Console.Clear();
            Console.WriteLine("Seleccione la dificultad:");
            Console.WriteLine("1. Fácil");
            Console.WriteLine("2. Normal");
            Console.WriteLine("3. Difícil");
            
            Console.WriteLine("\nPresione Esc para volver al menu."); 

            
            char choice = Console.ReadKey(true).KeyChar;

            switch (choice)
            {
                case '1':
                    Velocidad += 600; // Aumentar el tiempo de espera para facilitar el juego.
                    break;
                case '2':
                    Velocidad += 300; // Menos aumento para dificultad normal
                    break;
                case '3':
                    Velocidad += 100; // Nada de tiempo de espera aumento para dificultad difícil.
                    break;

                default:
                    Console.WriteLine("1");
                    break;
            }
        }

        static void GeneradorDeObstaculos()//Genera obstaculos 
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
                Camino[0, j] = Aleatorio.Next(0, 10) < 2; // 20% de probabilidad de bache (se puede modificar)
            }
        }



        static void Colision()//Esto es para cuando choque se vuelva falso y salga de todos los bucles e imprima.
        {
            if (Camino[Camino.GetLength(0) - 1, PosicionDelCarro])
            {
                JuegoCorriendo = false;
                Console.Clear();
                Console.WriteLine("¡Colisión! Juego terminado.");
                Console.WriteLine("Presiona cualquier tecla para volver al menu.");
            }
        }

        static void Entrada() //Todo esto es para hacer las movidas del "carro"
        {
            while (JuegoCorriendo)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.LeftArrow && PosicionDelCarro > 0)
                    {
                        PosicionDelCarro--;
                    }
            
                else if (keyInfo.Key == ConsoleKey.RightArrow && PosicionDelCarro < AnchoDeCarretera - 1)
                    {
                        PosicionDelCarro++;
                    }
            
                else if (keyInfo.Key == ConsoleKey.Escape)
                        {
                            JuegoCorriendo = false;
                        }
            
            }
        }
    }
}   
