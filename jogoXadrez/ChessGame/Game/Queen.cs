using ChessGame.Board;

namespace ChessGame.Game
{
    public class Queen(MatchBoard matchBoard, Color color) : Piece(matchBoard, color)
    {

        public override string ToString()
        {
            return "Q";
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

            //up
            pos.SetValues(Position.Row - 1, Position.Column);
            while (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (MatchBoard.Piece(pos) != null && MatchBoard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row - 1;
            }

            //up-right
            pos.SetValues(Position.Row - 1, Position.Column + 1);
            while (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (MatchBoard.Piece(pos) != null && MatchBoard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Row - 1, pos.Column + 1);
            }

            //right
            pos.SetValues(Position.Row, Position.Column + 1);
            while (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (MatchBoard.Piece(pos) != null && MatchBoard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            //down-right
            pos.SetValues(Position.Row + 1, Position.Column + 1);
            while (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (MatchBoard.Piece(pos) != null && MatchBoard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Row + 1, pos.Column + 1);
            }

            //down
            pos.SetValues(Position.Row + 1, Position.Column);
            while (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (MatchBoard.Piece(pos) != null && MatchBoard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row + 1;
            }

            //down-left
            pos.SetValues(Position.Row + 1, Position.Column - 1);
            while (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (MatchBoard.Piece(pos) != null && MatchBoard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Row + 1, pos.Column - 1);
            }

            //left
            pos.SetValues(Position.Row, Position.Column - 1);
            while (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (MatchBoard.Piece(pos) != null && MatchBoard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            //up-left
            pos.SetValues(Position.Row - 1, Position.Column - 1);
            while (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (MatchBoard.Piece(pos) != null && MatchBoard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Row - 1, pos.Column - 1);
            }

            return matrix;
        }
    }
}