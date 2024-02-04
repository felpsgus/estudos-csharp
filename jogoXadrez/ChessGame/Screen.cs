using ChessGame.Game;
using ChessGame.Board;

namespace ChessGame;

public class Screen
{
    public static void PrintBoard(MatchBoard matchBoard)
    {
        for (int i = 0; i < matchBoard.Rows; i++)
        {
            Console.Write($"{8 - i} ");
            for (int j = 0; j < matchBoard.Columns; j++)
            {
                PrintPiece(matchBoard.Piece(i, j));
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }

    public static void PrintBoard(MatchBoard matchBoard, bool[,] possibleMovements)
    {
        ConsoleColor originalBackground = Console.BackgroundColor;
        ConsoleColor alteredBackground = ConsoleColor.DarkGray;

        for (int i = 0; i < matchBoard.Rows; i++)
        {
            Console.Write($"{8 - i} ");
            for (int j = 0; j < matchBoard.Columns; j++)
            {
                if (possibleMovements[i, j])
                {
                    Console.BackgroundColor = alteredBackground;
                }
                else
                {
                    Console.BackgroundColor = originalBackground;
                }
                PrintPiece(matchBoard.Piece(i, j));
                Console.BackgroundColor = originalBackground;
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }

    public static ChessPosition ReadChessPosition()
    {
        string s = Console.ReadLine();
        char column = s[0];
        int row = int.Parse(s[1] + "");
        return new ChessPosition(column, row);
    }

    public static void PrintPiece(Piece piece)
    {
        if (piece == null)
        {
            Console.Write("- ");
        }
        else
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
            Console.Write(" ");
        }
    }
}