using JogoXadrez.Tabuleiro;

namespace JogoXadrez.Jogo;

public class Rei : Peca
{
    public Rei(Tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
    {
    }

    public override string ToString()
    {
        return "R";
    }
}