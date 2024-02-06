namespace ChessGame.Board
{
    public abstract class Piece(MatchBoard matchBoard, Color color)
    {
        public Position? Position { get; set; } = null;
        public Color Color { get; protected set; } = color;
        public int NumMovements { get; set; } = 0;
        protected MatchBoard MatchBoard { get; set; } = matchBoard;

        public void IncreaseNumMovements()
        {
            NumMovements++;
        }

        public void DecreaseNumMovements()
        {
            NumMovements--;
        }

        public bool HasPossibleMovements()
        {
            bool[,] matrix = PossibleMovements();
            for (int i = 0; i < MatchBoard.Rows; i++)
            {
                for (int j = 0; j < MatchBoard.Columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public abstract bool[,] PossibleMovements();

        public abstract bool AllowedMovement(Position pos);

        public bool CanMoveTo(Position pos)
        {
            return PossibleMovements()[pos.Row, pos.Column];
        }
    }
}