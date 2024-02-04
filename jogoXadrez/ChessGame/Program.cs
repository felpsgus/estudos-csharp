using ChessGame.Game;
using ChessGame.Board;

namespace ChessGame;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ChessMatch match = new ChessMatch();

            while (!match.Finished)
            {
                Console.Clear();
                Screen.PrintBoard(match.MatchBoard);

                Console.WriteLine();
                Console.WriteLine("Turn: " + match.Turn);
                Console.WriteLine("Waiting for: " + match.CurrentPlayer);
                Console.Write("Origin: ");
                Position origin = Screen.ReadChessPosition().ToPosition();

                bool[,] possibleMovements = match.MatchBoard.Piece(origin).PossibleMovements();

                Console.Clear();
                Screen.PrintBoard(match.MatchBoard, possibleMovements);

                Console.WriteLine();
                Console.WriteLine("Turn: " + match.Turn);
                Console.WriteLine("Waiting for: " + match.CurrentPlayer);
                Console.Write("Origin: ");
                Console.Write("Destiny: ");
                Position destiny = Screen.ReadChessPosition().ToPosition();

                match.ExecuteMovement(origin, destiny);
            }

        }
        catch (Board.BoardException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
    }
}