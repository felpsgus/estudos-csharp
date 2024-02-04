using ChessGame.Board;

namespace ChessGame.Game;

public class ChessMatch
{
    public MatchBoard MatchBoard { get; }
    public int Turn { get; private set; }
    public Color CurrentPlayer { get; private set; }
    public bool Finished { get; private set; }

    public ChessMatch()
    {
        MatchBoard = new MatchBoard(8, 8);
        Turn = 1;
        CurrentPlayer = Color.White;
        Finished = false;
        PlacePieces();
    }

    public void ExecuteMovement(Position origin, Position destiny)
    {
        ValidOriginPosition(origin);

        Piece piece = MatchBoard.TakePiece(origin);
        bool[,] possibleMovements = piece.PossibleMovements();
        if (possibleMovements[origin.Row, origin.Column])
        {
            piece.IncreaseNumMovements();
            Piece CapturedPiece = MatchBoard.TakePiece(destiny);
            MatchBoard.PlacePiece(piece, destiny);
        }
        else
        {
            throw new BoardException("Invalid movement!");
        }
    }

    public void MakePlay(Position origin, Position destiny)
    {
        ExecuteMovement(origin, destiny);
        Turn++;
        ChangePlayer();
    }

    private void ChangePlayer()
    {
        CurrentPlayer = CurrentPlayer == Color.White ? Color.Black : Color.White;
    }

    public void ValidOriginPosition(Position pos)
    {
        if (MatchBoard.Piece(pos) == null)
        {
            throw new BoardException("There is no piece in the chosen position!");
        }
        if (CurrentPlayer != MatchBoard.Piece(pos).Color)
        {
            throw new BoardException("The chosen piece is not yours!");
        }
        if (!MatchBoard.Piece(pos).HasPossibleMovements())
        {
            throw new BoardException("There are no possible movements for the chosen piece!");
        }
    }

    private void PlacePieces()
    {
        MatchBoard.PlacePiece(new Tower(MatchBoard, Color.White), new ChessPosition('a', 1).ToPosition());
        MatchBoard.PlacePiece(new Horse(MatchBoard, Color.White), new ChessPosition('b', 1).ToPosition());
        MatchBoard.PlacePiece(new Bishop(MatchBoard, Color.White), new ChessPosition('c', 1).ToPosition());
        MatchBoard.PlacePiece(new Queen(MatchBoard, Color.White), new ChessPosition('d', 1).ToPosition());
        MatchBoard.PlacePiece(new King(MatchBoard, Color.White), new ChessPosition('e', 1).ToPosition());
        MatchBoard.PlacePiece(new Bishop(MatchBoard, Color.White), new ChessPosition('f', 1).ToPosition());
        MatchBoard.PlacePiece(new Horse(MatchBoard, Color.White), new ChessPosition('g', 1).ToPosition());
        MatchBoard.PlacePiece(new Tower(MatchBoard, Color.White), new ChessPosition('h', 1).ToPosition());
        for (int i = 0; i < 8; i++)
        {
            MatchBoard.PlacePiece(new Pawn(MatchBoard, Color.White), new ChessPosition((char)('a' + i), 2).ToPosition());
        }

        MatchBoard.PlacePiece(new Tower(MatchBoard, Color.Black), new ChessPosition('a', 8).ToPosition());
        MatchBoard.PlacePiece(new Horse(MatchBoard, Color.Black), new ChessPosition('b', 8).ToPosition());
        MatchBoard.PlacePiece(new Bishop(MatchBoard, Color.Black), new ChessPosition('c', 8).ToPosition());
        MatchBoard.PlacePiece(new Queen(MatchBoard, Color.Black), new ChessPosition('d', 8).ToPosition());
        MatchBoard.PlacePiece(new King(MatchBoard, Color.Black), new ChessPosition('e', 8).ToPosition());
        MatchBoard.PlacePiece(new Bishop(MatchBoard, Color.Black), new ChessPosition('f', 8).ToPosition());
        MatchBoard.PlacePiece(new Horse(MatchBoard, Color.Black), new ChessPosition('g', 8).ToPosition());
        MatchBoard.PlacePiece(new Tower(MatchBoard, Color.Black), new ChessPosition('h', 8).ToPosition());
        for (int i = 0; i < 8; i++)
        {
            MatchBoard.PlacePiece(new Pawn(MatchBoard, Color.Black), new ChessPosition((char)('a' + i), 7).ToPosition());
        }
    }
}