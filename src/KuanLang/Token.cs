namespace KuanLang;

internal sealed record Token
{
    public required TokenType Type { get; init; }
    public required string Lexeme { get; init; }
    public required object Literal { get; init; }
    public required int Line { get; init; }
}
