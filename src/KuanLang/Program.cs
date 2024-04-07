using System.Text;

namespace KuanLang;

internal static class Program
{
    private static bool s_hadError = false;

    internal static void Main(string[] args)
    {
        switch (args.Length)
        {
            case > 1:
                Console.WriteLine("Usage: kuan [script]");
                Environment.Exit(64);
                break;
            case 1:
                RunFile(args[0]);
                break;
            default:
                RunPrompt();
                break;
        }
    }

    private static void RunFile(string path)
    {
        byte[] bytes = File.ReadAllBytes(path);
        Run(Encoding.UTF8.GetString(bytes));

        if (s_hadError)
        {
            Environment.Exit(65);
        }
    }

    private static void Run(string source)
    {
        var scanner = new Scanner { Source = source };
        var tokens = scanner.ScanTokens();

        foreach (var token in tokens)
        {
            Console.WriteLine(token);
        }
    }

    private static void RunPrompt()
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

            s_hadError = false;
        }
    }

    private static void Error(int line, String message)
    {
        Report(line, string.Empty, message);
    }

    private static void Report(int line, string where, string message)
    {
        Console.Error.WriteLine($"[line {line}] Error {where}: {message}");

        s_hadError = true;
    }
}
