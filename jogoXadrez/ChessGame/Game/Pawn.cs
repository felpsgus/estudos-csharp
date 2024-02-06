using ChessGame.Board;

namespace ChessGame.Game
{
    public class Pawn(MatchBoard matchBoard, Color color, ChessMatch match) : Piece(matchBoard, color)
    {
        private ChessMatch Match { get; set; } = match;

        public override string ToString()
        {
            return "P";
        }

        private bool Enemy(Position pos)
        {
            Piece p = MatchBoard.Piece(pos);
            return p != null && p.Color != Color;
        }

        public override bool AllowedMovement(Position pos)
        {
            Piece p = MatchBoard.Piece(pos);
            return p == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[MatchBoard.Rows, MatchBoard.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                // up
                pos.SetValues(Position.Row - 1, Position.Column);
                if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
                {
                    matrix[pos.Row, pos.Column] = true;
                }

                if (NumMovements == 0)
                {
                    if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
                    {
                        matrix[pos.Row - 1, pos.Column] = true;
                    }
                }

                // up-left
                pos.SetValues(Position.Row - 1, Position.Column - 1);
                if (MatchBoard.ValidPosition(pos) && Enemy(pos))
                {
                    matrix[pos.Row, pos.Column] = true;
                }

                // up-right
                pos.SetValues(Position.Row - 1, Position.Column + 1);
                if (MatchBoard.ValidPosition(pos) && Enemy(pos))
                {
                    matrix[pos.Row, pos.Column] = true;
                }

                // #SpecialMove en passant
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (MatchBoard.ValidPosition(left) && Enemy(left) && MatchBoard.Piece(left) == Match.EnPassantVulnerable)
                    {
                        matrix[left.Row - 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (MatchBoard.ValidPosition(right) && Enemy(right) && MatchBoard.Piece(right) == Match.EnPassantVulnerable)
                    {
                        matrix[right.Row - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                // down
                pos.SetValues(Position.Row + 1, Position.Column);
                if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
                {
                    matrix[pos.Row, pos.Column] = true;
                }

                if (NumMovements == 0)
                {
                    if (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
                    {
                        matrix[pos.Row + 1, pos.Column] = true;
                    }
                }

                // down-left
                pos.SetValues(Position.Row + 1, Position.Column - 1);
                if (MatchBoard.ValidPosition(pos) && Enemy(pos))
                {
                    matrix[pos.Row, pos.Column] = true;
                }

                // down-right
                pos.SetValues(Position.Row + 1, Position.Column + 1);
                if (MatchBoard.ValidPosition(pos) && Enemy(pos))
                {
                    matrix[pos.Row, pos.Column] = true;
                }

                // #SpecialMove en passant
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (MatchBoard.ValidPosition(left) && Enemy(left) && MatchBoard.Piece(left) == Match.EnPassantVulnerable)
                    {
                        matrix[left.Row + 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (MatchBoard.ValidPosition(right) && Enemy(right) && MatchBoard.Piece(right) == Match.EnPassantVulnerable)
                    {
                        matrix[right.Row + 1, right.Column] = true;
                    }
                }
            }


            return matrix;
        }
    }
}