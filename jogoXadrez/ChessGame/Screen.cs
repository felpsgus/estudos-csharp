using ChessGame.Game;
using ChessGame.Board;

namespace ChessGame
{
    public static class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.MatchBoard);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn);
            if (match.Finished)
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("Winner: " + match.CurrentPlayer);
            }
            else
            {
                Console.WriteLine("Waiting for: " + match.CurrentPlayer);
                if (match.Check)
                {
                    Console.WriteLine("CHECK!");
                }
            }
        }

        private static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces:");
            Console.Write("White: ");
            PrintHashSet(match.CapturedPieces, Color.White);
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintHashSet(match.CapturedPieces, Color.Black);
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        private static void PrintHashSet(IEnumerable<Piece> hashSet, Color color)
        {
            Console.Write("[");
            foreach (var piece in hashSet.Where(piece => piece.Color == color))
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }

        private static void PrintBoard(MatchBoard matchBoard)
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
                    Console.BackgroundColor = possibleMovements[i, j] ? alteredBackground : originalBackground;
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
            char column = s![0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        private static void PrintPiece(Piece piece)
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
}