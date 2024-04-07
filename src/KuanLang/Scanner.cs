namespace KuanLang;

sealed record Scanner
{
    public required string Source { get; init; }

    public List<Token> ScanTokens()
    {
        Console.WriteLine(Source);
        return [];
    }
}
