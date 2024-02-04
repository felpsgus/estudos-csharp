using ChessGame.Board;

namespace ChessGame.Game;

public class ChessPosition : Position
{
    public char Coluna { get; set; }
    public int Linha { get; set; }

    public ChessPosition(char coluna, int linha) : base(linha, coluna)
    {
        Coluna = coluna;
        Linha = linha;
    }

    public Position ToPosition()
    {
        return new Position(8 - Linha, Coluna - 'a');
    }

    public override string ToString()
    {
        return "" + Coluna + Linha;
    }
}