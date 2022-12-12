namespace Chess
{
    class Bishop : Piece
    {
        private List<string> PossibleMoves;

        public Bishop(string color, string position) : base("bishop", color, position)
        {
            this.PossibleMoves = new List<string>();
            SetPossibleMoves();
        }

        public void Move(int direction, int numSquares)
        {
            bool possible = (
                this.PosX + numSquares <= 7
                && this.PosX - numSquares >= 0
                && this.PosY + numSquares <= 7
                && this.PosY - numSquares >= 0
            );

            if (possible)
            {
                // 0: NE; 1: SE; 2: SW; 3: NW;
                if (direction == 0)
                {
                    ChangePosition(-1 * numSquares, numSquares);
                }
                else if (direction == 1)
                {
                    ChangePosition(numSquares, numSquares);
                }
                else if (direction == 2)
                {
                    ChangePosition(numSquares, -1 * numSquares);
                }
                else if (direction == 3)
                {
                    ChangePosition(-1 * numSquares, -1 * numSquares);
                }
            }
            else
            {
                Console.WriteLine("Invalid move ...");
            }
        }

        public void SetPossibleMoves()
        {
            List<string> possibleMoves = new List<string>();
            int x = this.PosX;
            int y = this.PosY;
            for (int i = 1; i < 8; i++)
            {
                if (IsPossible(x + i, 7 - (y + i)))
                {
                    possibleMoves.Add($"{this.abc[x + i]}{8 - (y + i)}");
                }
                if (IsPossible(x - i, 7 - (y + i)))
                {
                    possibleMoves.Add($"{this.abc[x - i]}{8 - (y + i)}");
                }
                if (IsPossible(x + i, 7 - (y - i)))
                {
                    possibleMoves.Add($"{this.abc[x + i]}{8 - (y - i)}");
                }
                if (IsPossible(x - i, 7 - (y - i)))
                {
                    possibleMoves.Add($"{this.abc[x - i]}{8 - (y - i)}");
                }
            }
            this.PossibleMoves = possibleMoves;
        }

        public bool IsLegal(int currentX, int currentY, int newX, int newY)
        {
            return true;
        }
    }
}