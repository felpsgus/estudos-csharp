using ChessGame.Game;
using ChessGame.Board;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        match.ValidOriginPosition(origin);

                        bool[,] possibleMovements = match.MatchBoard.Piece(origin).PossibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(match.MatchBoard, possibleMovements);

                        Console.WriteLine();
                        Console.WriteLine("Turn: " + match.Turn);
                        Console.WriteLine("Waiting for: " + match.CurrentPlayer);
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadChessPosition().ToPosition();
                        match.ValidDestinyPosition(origin, destiny);

                        match.MakeMove(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match);
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
}