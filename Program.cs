using _5by5.Utils;

internal class Program
{
    public static List<string> numbers = new EditorArquivo("C:\\Data\\", "5by5TipoAssimNumbers.txt").ReadNumbers();

    public static EditorArquivo editor = new("C:\\Data\\", "5by5TipoAssimCounter.txt");

    private static void Main(string[] args)
    {
        InitSystem();

        while (true)
        {
            Console.Clear();
            menu();
            printCount(editor.Read());

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    editor.Save(editor.Read() + 1);
                    break;
                case ConsoleKey.DownArrow:
                    editor.Save(editor.Read() - 1);
                    break;
                default:
                    Environment.Exit(0);
                    continue;
            }

            if (editor.Read() < 0)
                editor.Save(0);
        }
    }

    private static void InitSystem()
    {
        Console.SetCursorPosition(0, 10);
        Console.WriteLine("Loading system ( < 0% >                                     )");
        Thread.Sleep(600);

        int count = 0;
        
        while ((count += new Random().Next(1, 8)) < 33)
        {
            Console.SetCursorPosition(0, 10);
            Console.Write("Loading system ( ");

            for (int j = 0; j < count; j++)
            {
                Console.Write("=");
                if (j == count - 1)
                    Console.Write($" <{count * 3}%> ");
            }


            
            Thread.Sleep(100);
        }
        Console.SetCursorPosition(0, 10);
        Console.WriteLine("Loading system ( ================================= < 100% > )");
        Thread.Sleep(2000);
    }

    static void menu()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(@"
   _____            _            _                  _        
  / ____|          | |          | |                | |       
 | |     ___  _ __ | |_ __ _  __| | ___  _ __    __| | __ _  
 | |    / _ \| '_ \| __/ _` |/ _` |/ _ \| '__|  / _` |/ _` | 
 | |___| (_) | | | | || (_| | (_| | (_) | |    | (_| | (_| | 
  \_____\___/|_| |_|\__\__,_|\__,_|\___/|_|     \__,_|\__,_| 
             | |                                             
           __| | ___  ___  __ _ _ __ __ _  ___ __ _          
          / _` |/ _ \/ __|/ _` | '__/ _` |/ __/ _` |         
         | (_| |  __/\__ \ (_| | | | (_| | (_| (_| |         
          \__,_|\___||___/\__, |_|  \__,_|\___\__,_|         
                           __/ |           )_)               
                          |___/                              


");

        Console.ForegroundColor = ConsoleColor.Red;
    }

    static void printCount(int number1)
    {
        int firstDigit = number1;
        int digitQuantity = 1;
        decimal number;

        while (firstDigit >= 1)
        {
            firstDigit /= 10;
            digitQuantity *= 10;
        }

        number = (decimal)number1 / digitQuantity;

        Console.Write("\t\t  ");
        printLine(number, digitQuantity, 0);
        Console.Write("\t\t  "); 
        printLine(number, digitQuantity, 1);
        Console.Write("\t\t  "); 
        printLine(number, digitQuantity, 2);
        Console.Write("\t\t  "); 
        printLine(number, digitQuantity, 3);
        Console.Write("\t\t  "); 
        printLine(number, digitQuantity, 4);
        Console.Write("\t\t  "); 
        printLine(number, digitQuantity, 5);
        Console.Write("\t\t  "); 
        printLine(number, digitQuantity, 6);
        Console.Write("\t\t  "); 
        printLine(number, digitQuantity, 7);
    }

    static void printLine(decimal number, int digitQuantity, int currentLine)
    {
        int firstDigit = (int)(number * 10);

        Console.Write(numbers[(firstDigit * 8) + currentLine]);

        if (digitQuantity <= 10)
        {
            Console.WriteLine();
            return;
        }
        else
        {
            printLine((number * 10) - (decimal)firstDigit, digitQuantity / 10, currentLine);
        }
    }
}