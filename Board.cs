namespace Chess
{
    class Board
    {
        private List<Piece> blackPieces
        { get; set; }

        private List<Piece> whitePieces
        { get; set; }

        private List<List<Piece>> boardList;

        private char[] abc = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        /*
            Constructor that fills the board with all the pieces.   
        */
        public Board()
        {
            this.whitePieces = new List<Piece>();
            this.blackPieces = new List<Piece>();
            InitializePieces();
            this.boardList = new List<List<Piece>>();

            // Add blank spaces to the board
            for (int i = 0; i < 8; i++)
            {
                this.boardList.Add(new List<Piece>());
                for (int j = 0; j < 8; j++)
                {
                    this.boardList[i].Add(new Piece("x", "none", $"{this.abc[i]}{j}"));
                }
            }
        }

        public void InitializePieces()
        {
            // Add white pieces to the board
            this.whitePieces.Add(new King("white", "e1"));
            this.whitePieces.Add(new Queen("white", "d1"));
            this.whitePieces.Add(new Bishop("white", "c1"));
            this.whitePieces.Add(new Bishop("white", "f1"));
            this.whitePieces.Add(new Knight("white", "b1"));
            this.whitePieces.Add(new Knight("white", "g1"));
            this.whitePieces.Add(new Rook("white", "a1"));
            this.whitePieces.Add(new Rook("white", "h1"));

            // Add black pieces to the board
            this.blackPieces.Add(new King("black", "e8"));
            this.blackPieces.Add(new Queen("black", "d8"));
            this.blackPieces.Add(new Bishop("black", "c8"));
            this.blackPieces.Add(new Bishop("black", "f8"));
            this.blackPieces.Add(new Knight("black", "b8"));
            this.blackPieces.Add(new Knight("black", "g8"));
            this.blackPieces.Add(new Rook("black", "a8"));
            this.blackPieces.Add(new Rook("black", "h8"));

            // Add pawns to the board
            string[] abc = new string[] { "a", "b", "c", "d", "e", "f", "g", "h" };
            for (int i = 0; i < 8; i++)
            {
                this.whitePieces.Add(new Pawn("white", $"{abc[i]}2"));
                this.blackPieces.Add(new Pawn("black", $"{abc[i]}7"));
            }
        }

        public override string ToString()
        {
            for (int i = 0; i < 16; i++)
            {
                Piece whitePiece = this.whitePieces[i];
                Piece blackPiece = this.blackPieces[i];
                this.boardList[whitePiece.PosY][whitePiece.PosX] = whitePiece;
                this.boardList[blackPiece.PosY][blackPiece.PosX] = blackPiece;
            }

            string boardString = "----------------------------------------------------\n";
            for (int i = 0; i < 8; i++)
            {
                boardString += $"|      {this.boardList[i][0].GetAbbreviation()} | {this.boardList[i][1].GetAbbreviation()} | {this.boardList[i][2].GetAbbreviation()} | {this.boardList[i][3].GetAbbreviation()} | {this.boardList[i][4].GetAbbreviation()} | {this.boardList[i][5].GetAbbreviation()} | {this.boardList[i][6].GetAbbreviation()} | {this.boardList[i][7].GetAbbreviation()}       |\n";
                if (i < 7)
                {
                    boardString += "       --------------------------------------      \n";
                }
            }
            boardString += "----------------------------------------------------";
            return boardString;
        }

        public int[] ParsePosition(string pos)
        {
            char[] splitPos = pos.ToArray();
            int[] intPos = new int[2];
            intPos[0] = Array.IndexOf(this.abc, splitPos[0]);
            intPos[1] = 8 - (int)Char.GetNumericValue(splitPos[1]);
            return intPos;
        }

        public void MovePiece(string move)
        {
            // Input move should be a string of the format "a2-a3"
            string[] moves = move.Split("-");
            int[] firstMove = ParsePosition(moves[0]);
            int[] secondMove = ParsePosition(moves[1]);
            Piece pieceToMove = this.boardList[firstMove[1]][firstMove[0]];
            string pieceType = pieceToMove.PieceType;
            int diffX = secondMove[0] - firstMove[0];
            int diffY = secondMove[1] - firstMove[1];
            if (pieceType == "king")
            {
                King king = (King)pieceToMove;
                if (diffX == 1 && diffY == 1)
                {
                    king.Move(3);
                }
                else if (diffX == 0 && diffY == 1)
                {
                    king.Move(4);
                }
                else if (diffX == -1 && diffY == 1)
                {
                    king.Move(5);
                }
                else if (diffX == 0 && diffY == -1)
                {
                    king.Move(0);
                }
                else if (diffX == 1 && diffY == -1)
                {
                    king.Move(1);
                }
                else if (diffX == -1 && diffY == -1)
                {
                    king.Move(7);
                }
                else if (diffX == 1 && diffY == 0)
                {
                    king.Move(2);
                }
                else if (diffX == -1 && diffY == 0)
                {
                    king.Move(6);
                }
                this.boardList[king.PosY][king.PosX] = king;
            }
            else if (pieceType == "queen")
            {
                Queen queen = (Queen)pieceToMove;
                int numSquares = (int)Math.Sqrt(Math.Pow(secondMove[0] - firstMove[0], 2) + Math.Pow(secondMove[1] - firstMove[1], 2));
                if (diffX > 0 && diffY > 0)
                {
                    queen.Move(1, numSquares);
                }
                else if (diffX == 0 && diffY > 0)
                {
                    queen.Move(4, numSquares);
                }
                else if (diffX < 0 && diffY > 0)
                {
                    queen.Move(5, numSquares);
                }
                else if (diffX == 0 && diffY < 0)
                {
                    queen.Move(0, numSquares);
                }
                else if (diffX > 0 && diffY < 0)
                {
                    queen.Move(1, numSquares);
                }
                else if (diffX < 0 && diffY < 0)
                {
                    queen.Move(7, numSquares);
                }
                else if (diffX > 0 && diffY == 0)
                {
                    queen.Move(2, numSquares);
                }
                else if (diffX < 0 && diffY == 0)
                {
                    queen.Move(6, numSquares);
                }
                this.boardList[queen.PosY][queen.PosX] = queen;
            }
            else if (pieceType == "bishop")
            {
                Bishop bishop = (Bishop)pieceToMove;
                int numSquares = (int)Math.Sqrt(Math.Pow(secondMove[0] - firstMove[0], 2) + Math.Pow(secondMove[1] - firstMove[1], 2));
                if (diffX > 0 && diffY < 0)
                {
                    bishop.Move(0, numSquares);
                }
                else if (diffX > 0 && diffY < 0)
                {
                    bishop.Move(1, numSquares);
                }
                else if (diffX < 0 && diffY > 0)
                {
                    bishop.Move(2, numSquares);
                }
                else if (diffX < 0 && diffY < 0)
                {
                    bishop.Move(3, numSquares);
                }
                this.boardList[bishop.PosY][bishop.PosX] = bishop;
            }
            else if (pieceType == "knight")
            {
                Knight knight = (Knight)pieceToMove;
                this.boardList[knight.PosY][knight.PosX] = knight;
            }
            else if (pieceType == "rook")
            {
                Rook rook = (Rook)pieceToMove;
                if (diffX == 0 && diffY > 0)
                {
                    rook.Move(0, diffY);
                }
                else if (diffX == 0 && diffY < 0)
                {
                    rook.Move(2, diffY);
                }
                else if (diffX > 0 && diffY == 0)
                {
                    rook.Move(1, diffX);
                }
                else if (diffX < 0 && diffY == 0)
                {
                    rook.Move(3, diffX);
                }
                this.boardList[rook.PosY][rook.PosX] = rook;
            }
            else if (pieceType == "pawn")
            {
                Pawn pawn = (Pawn)pieceToMove;
                if (diffY == 1)
                {
                    pawn.Move(2);
                }
                else if (diffY == 2)
                {
                    pawn.Move(3);
                }
                else if (diffY == -1)
                {
                    pawn.Move(0);
                }
                else if (diffY == -2)
                {
                    pawn.Move(1);
                }
                this.boardList[pawn.PosY][pawn.PosX] = pawn;
            }
            this.boardList[firstMove[1]][firstMove[0]] = new Piece("x", "none", moves[0]);
            Console.WriteLine("The move " + move + " was played");
        }
    }
}