namespace Chess
{
    class Rook : Piece
    {
        public Rook(string color, string position) : base("rook", color, position) { }

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
                // 0: N; 1: E; 2: S; 3: W;
                if (direction == 0)
                {
                    ChangePosition(0, -1 * numSquares);
                }
                else if (direction == 1)
                {
                    ChangePosition(numSquares, 0);
                }
                else if (direction == 2)
                {
                    ChangePosition(0, numSquares);
                }
                else if (direction == 3)
                {
                    ChangePosition(-1 * numSquares, 0);
                }
            }
            else
            {
                Console.WriteLine("Invalid move ...");
            }
        }
    }
}