using System.Text;

namespace KuanLang;

public static class Program
{
    public static void Main(string[] args)
    {
        if (args.Length > 1)
        {
            Console.WriteLine("Usage: kuan [script]");
            Environment.Exit(64);
        }
        else if (args.Length == 1)
        {
            RunFile(args[0]);
        }
        else
        {
            RunPrompt();
        }
    }

    static void RunFile(string path)
    {
        byte[] bytes = File.ReadAllBytes(path);
        Run(Encoding.UTF8.GetString(bytes));
    }

    static void Run(string source)
    {
        var scanner = new Scanner { Source = source };
        var tokens = scanner.ScanTokens();

        foreach (var token in tokens)
        {
            Console.WriteLine(token);
        }
    }

    static void RunPrompt()
    {
        var welcomeMessage = """

             _  __                     _               _        _
            | |/ /   _  __ _ _ __     | |__   __ _ ___| |_ __ _| |
            | ' / | | |/ _` | '_ \    | '_ \ / _` / __| __/ _` | |
            | . \ |_| | (_| | | | |_  | |_) | (_| \__ \ || (_| |_|  _ _ _
            |_|\_\__,_|\__,_|_| |_( ) |_.__/ \__,_|___/\__\__,_(_) (_|_|_)
                                  |/


            """;

        Console.WriteLine(welcomeMessage);

        while (true)
        {
            Console.Write("kuan > ");

            var line = Console.ReadLine();

            if (line is null)
            {
                break;
            }

            Run(line);
        }
    }
}