using ChessGame.Board;

namespace ChessGame.Game
{
    public class ChessMatch
    {
        public MatchBoard MatchBoard { get; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces { get; set; }
        public HashSet<Piece> CapturedPieces { get; private set; }
        public bool Check { get; private set; }
        public Piece? EnPassantVulnerable { get; private set; }

        public ChessMatch()
        {
            MatchBoard = new MatchBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PlacePieces();
        }

        private Piece ExecuteMovement(Position origin, Position destiny)
        {
            Piece piece = MatchBoard.TakePiece(origin);
            piece.IncreaseNumMovements();
            Piece capturedPiece = MatchBoard.TakePiece(destiny);
            MatchBoard.PlacePiece(piece, destiny);

            // #special-move castling king side rook
            if (piece is King && destiny.Column == origin.Column + 2)
            {
                Position originR = new Position(origin.Row, origin.Column + 3);
                Position destinyR = new Position(origin.Row, origin.Column + 1);
                Piece rook = MatchBoard.TakePiece(originR);
                rook.IncreaseNumMovements();
                MatchBoard.PlacePiece(rook, destinyR);
            }

            // #special-move castling queen side rook
            if (piece is King && destiny.Column == origin.Column - 2)
            {
                Position originR = new Position(origin.Row, origin.Column - 4);
                Position destinyR = new Position(origin.Row, origin.Column - 1);
                Piece rook = MatchBoard.TakePiece(originR);
                rook.IncreaseNumMovements();
                MatchBoard.PlacePiece(rook, destinyR);
            }

            // #specialmove en passant
            if (piece is Pawn)
            {
                if (origin.Column != destiny.Column && capturedPiece == null)
                {
                    Position posP;
                    if (piece.Color == Color.White)
                    {
                        posP = new Position(destiny.Row + 1, destiny.Column);
                    }
                    else
                    {
                        posP = new Position(destiny.Row - 1, destiny.Column);
                    }
                    capturedPiece = MatchBoard.TakePiece(posP);
                }
            }

            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        private void UndoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece? piece = MatchBoard.TakePiece(destiny);
            piece?.DecreaseNumMovements();
            if (capturedPiece != null)
            {
                MatchBoard.PlacePiece(capturedPiece, destiny);
                CapturedPieces.Remove(capturedPiece);
            }
            MatchBoard.PlacePiece(piece, origin);
        }

        private void ChangePlayer()
        {
            CurrentPlayer = CurrentPlayer == Color.White ? Color.Black : Color.White;
        }

        public void MakeMove(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecuteMovement(origin, destiny);

            Piece p = MatchBoard.Piece(destiny);

            // #special-move promotion
            if (p is Pawn)
            {
                if ((p.Color == Color.White && destiny.Row == 0) || (p.Color == Color.Black && destiny.Row == 7))
                {
                    p = MatchBoard.TakePiece(destiny);
                    Pieces.Remove(p);
                    Piece queen = new Queen(MatchBoard, p.Color);
                    MatchBoard.PlacePiece(queen, destiny);
                    Pieces.Add(queen);
                }
            }

            if (KingInCheck(CurrentPlayer))
            {
                UndoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            Check = KingInCheck(Opponent(CurrentPlayer));
            if (CheckMate(Opponent(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

            // #specialmove en passant
            if (p is Pawn && (destiny.Row == origin.Row - 2 || destiny.Row == origin.Row + 2))
            {
                EnPassantVulnerable = p;
            }
            else
            {
                EnPassantVulnerable = null;
            }
        }

        private static Color Opponent(Color color)
        {
            return color == Color.White ? Color.Black : Color.White;
        }

        private King? King(Color color)
        {
            return PiecesInGame(color).OfType<King>().FirstOrDefault();
        }

        private bool KingInCheck(Color color)
        {
            Piece? king = King(color);
            if (king == null)
            {
                throw new BoardException($"There is no {color} king on the board!");
            }
            return PiecesInGame(Opponent(color)).Select(piece => piece.PossibleMovements()).Any(matrix => matrix[king.Position.Row, king.Position.Column]);
        }

        public bool CheckMate(Color color)
        {
            if (!Check)
            {
                return false;
            }
            foreach (var piece in PiecesInGame(color))
            {
                bool[,] matrix = piece.PossibleMovements();
                for (int i = 0; i < MatchBoard.Rows; i++)
                {
                    for (int j = 0; j < MatchBoard.Columns; j++)
                    {
                        if (matrix[i, j])
                        {
                            Position origin = (Position)piece.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecuteMovement(origin, destiny);
                            bool check = KingInCheck(color);
                            UndoMovement(origin, destiny, capturedPiece);
                            if (!check)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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

        public void ValidDestinyPosition(Position origin, Position destiny)
        {
            if (!MatchBoard.Piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }
        }

        private HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> piecesInGame = new HashSet<Piece>();
            piecesInGame = Pieces.Select(piece => piece.Color == color ? piece : null).Where(piece => piece != null).ToHashSet();
            piecesInGame.ExceptWith(CapturedPiecesByColor(color));
            return piecesInGame;
        }

        private HashSet<Piece> CapturedPiecesByColor(Color color)
        {
            HashSet<Piece> capturedPiecesByColor = new HashSet<Piece>();
            foreach (var piece in CapturedPieces.Where(piece => piece.Color == color))
            {
                capturedPiecesByColor.Add(piece);
            }
            return capturedPiecesByColor;
        }

        private void PlaceNewPiece(char column, int row, Piece piece)
        {
            MatchBoard.PlacePiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece('a', 1, new Rook(MatchBoard, Color.White));
            PlaceNewPiece('b', 1, new Knight(MatchBoard, Color.White));
            PlaceNewPiece('c', 1, new Bishop(MatchBoard, Color.White));
            PlaceNewPiece('d', 1, new Queen(MatchBoard, Color.White));
            PlaceNewPiece('e', 1, new King(MatchBoard, Color.White, this));
            PlaceNewPiece('f', 1, new Bishop(MatchBoard, Color.White));
            PlaceNewPiece('g', 1, new Knight(MatchBoard, Color.White));
            PlaceNewPiece('h', 1, new Rook(MatchBoard, Color.White));
            for (int i = 0; i < 8; i++)
            {
                PlaceNewPiece((char)('a' + i), 2, new Pawn(MatchBoard, Color.White, this));
            }

            PlaceNewPiece('a', 8, new Rook(MatchBoard, Color.Black));
            PlaceNewPiece('b', 8, new Knight(MatchBoard, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(MatchBoard, Color.Black));
            PlaceNewPiece('d', 8, new Queen(MatchBoard, Color.Black));
            PlaceNewPiece('e', 8, new King(MatchBoard, Color.Black, this));
            PlaceNewPiece('f', 8, new Bishop(MatchBoard, Color.Black));
            PlaceNewPiece('g', 8, new Knight(MatchBoard, Color.Black));
            PlaceNewPiece('h', 8, new Rook(MatchBoard, Color.Black));
            for (int i = 0; i < 8; i++)
            {
                PlaceNewPiece((char)('a' + i), 7, new Pawn(MatchBoard, Color.Black, this));
            }
        }
    }
}