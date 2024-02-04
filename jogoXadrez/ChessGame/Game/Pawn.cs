using ChessGame.Board;

namespace ChessGame.Game;

public class Pawn : Piece
{
    public Pawn(MatchBoard matchBoard, Color color) : base(matchBoard, color)
    {
    }

    public override string ToString()
    {
        return "P";
    }

    public override bool CanMoveTo(Position pos)
    {
        Piece p = MatchBoard.Piece(pos);
        return p == null;
    }

    public override bool[,] PossibleMovements()
    {
        bool[,] matrix = new bool[MatchBoard.Rows, MatchBoard.Columns];

        Position pos = new Position(0, 0);

        // up
        Console.WriteLine(Position);
        Console.WriteLine(pos);
        pos.SetValues(Position.Row - 1, Position.Column);
        if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
        }

        if (NumMovements == 0)
        {
            pos.SetValues(Position.Row - 2, Position.Column);
            if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }
        }

        // up-left
        pos.SetValues(Position.Row - 1, Position.Column - 1);
        if (MatchBoard.ValidPosition(pos) && !CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
        }

        // up-right
        pos.SetValues(Position.Row - 1, Position.Column + 1);
        if (MatchBoard.ValidPosition(pos) && !CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
        }

        return matrix;
    }
}