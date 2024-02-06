using ChessGame.Board;

namespace ChessGame.Game
{
    public class Knight(MatchBoard matchBoard, Color color) : Piece(matchBoard, color)
    {

        public override string ToString()
        {
            return "N";
        }

        public override bool AllowedMovement(Position pos)
        {
            Piece p = MatchBoard.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[MatchBoard.Rows, MatchBoard.Columns];

            Position pos = new Position(0, 0);

            //up-right
            pos.SetValues(Position.Row - 2, Position.Column + 1);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //right-up
            pos.SetValues(Position.Row - 1, Position.Column + 2);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //right-down
            pos.SetValues(Position.Row + 1, Position.Column + 2);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //down-right
            pos.SetValues(Position.Row + 2, Position.Column + 1);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //down-left
            pos.SetValues(Position.Row + 2, Position.Column - 1);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //left-down
            pos.SetValues(Position.Row + 1, Position.Column - 2);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //left-up
            pos.SetValues(Position.Row - 1, Position.Column - 2);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //up-left
            pos.SetValues(Position.Row - 2, Position.Column - 1);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            return matrix;
        }
    }
}