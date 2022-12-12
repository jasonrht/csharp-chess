namespace Chess
{
    class Queen : Piece
    {
        public Queen(string color, string position) : base("queen", color, position) { }

        public void Move(int direction, int numSquares)
        {
            bool possible = (
                this.PosX + numSquares < 7
                && this.PosX - numSquares > 0
                && this.PosY + numSquares < 7
                && this.PosY - numSquares > 0
            );

            if (possible)
            {
                // 0: N; 1: NE; 2: E; 3: SE; 4: S; 5: SW; 6: W; 7: NW;
                if (direction == 0)
                {
                    ChangePosition(0, -1 * numSquares);
                }
                else if (direction == 1)
                {
                    ChangePosition(numSquares, -1 * numSquares);
                }
                else if (direction == 2)
                {
                    ChangePosition(numSquares, 0);
                }
                else if (direction == 3)
                {
                    ChangePosition(numSquares, numSquares);
                }
                else if (direction == 4)
                {
                    ChangePosition(0, numSquares);
                }
                else if (direction == 5)
                {
                    ChangePosition(-1 * numSquares, numSquares);
                }
                else if (direction == 6)
                {
                    ChangePosition(-1 * numSquares, 0);
                }
                else if (direction == 7)
                {
                    ChangePosition(-1 * numSquares, -1 * numSquares);
                }
            }
            else
            {
                Console.WriteLine("Invalid move ...");
            }
        }
    }
}