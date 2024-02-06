using ChessGame.Board;

namespace ChessGame.Game
{
    public class King(MatchBoard matchBoard, Color color, ChessMatch chessMatch) : Piece(matchBoard, color)
    {
        private ChessMatch ChessMatch { get; set; } = chessMatch;

        public override string ToString()
        {
            return "K";
        }

        public override bool AllowedMovement(Position pos)
        {
            Piece p = MatchBoard.Piece(pos);
            return p == null || p.Color != Color;
        }

        private bool TestRookCastling(Position pos)
        {
            Piece p = MatchBoard.Piece(pos);
            return p != null && p is Rook && p.Color == Color && p.NumMovements == 0;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[MatchBoard.Rows, MatchBoard.Columns];

            Position pos = new Position(0, 0);

            //up
            pos.SetValues(Position.Row -1, Position.Column);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //up-right
            pos.SetValues(Position.Row - 1, Position.Column + 1);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //right
            pos.SetValues(Position.Row, Position.Column + 1);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //down-right
            pos.SetValues(Position.Row + 1, Position.Column + 1);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //down
            pos.SetValues(Position.Row + 1, Position.Column);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //down-left
            pos.SetValues(Position.Row + 1, Position.Column - 1);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //left
            pos.SetValues(Position.Row, Position.Column - 1);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            //up-left
            pos.SetValues(Position.Row - 1, Position.Column - 1);
            if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            // #SpecialMove Castling
            if (NumMovements == 0 && !ChessMatch.Check)
            {
                // #SpecialMove Castling Kingside Rook
                Position posR1 = new Position(Position.Row, Position.Column + 3);
                if (TestRookCastling(posR1))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if (MatchBoard.Piece(p1) == null && MatchBoard.Piece(p2) == null)
                    {
                        matrix[Position.Row, Position.Column + 2] = true;
                    }
                }

                // #SpecialMove Castling Queenside Rook
                Position posR2 = new Position(Position.Row, Position.Column - 4);
                if (TestRookCastling(posR2))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    if (MatchBoard.Piece(p1) == null && MatchBoard.Piece(p2) == null && MatchBoard.Piece(p3) == null)
                    {
                        matrix[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return matrix;
        }
    }
}