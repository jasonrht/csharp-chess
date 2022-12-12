namespace Chess
{
    class King : Piece
    {
        public King(string color, string position) : base("king", color, position)
        {
            this.PossibleMoves = new List<string>();
        }

        private List<string> PossibleMoves;

        public void Move(int direction)
        {
            bool possible = (
                this.PosX + 1 < 7
                && this.PosX - 1 > 0
                && this.PosY + 1 < 7
                && this.PosY - 1 > 0
            );

            if (possible)
            {
                // 0: N; 1: NE; 2: E; 3: SE; 4: S; 5: SW; 6: W; 7: NW;
                if (direction == 0)
                {
                    ChangePosition(0, -1);
                }
                else if (direction == 1)
                {
                    ChangePosition(1, -1);
                }
                else if (direction == 2)
                {
                    ChangePosition(1, 0);
                }
                else if (direction == 3)
                {
                    ChangePosition(1, 1);
                }
                else if (direction == 4)
                {
                    ChangePosition(0, 1);
                }
                else if (direction == 5)
                {
                    ChangePosition(-1, 1);
                }
                else if (direction == 6)
                {
                    this.PosX -= 1;
                    ChangePosition(-1, 0);
                }
                else if (direction == 7)
                {
                    ChangePosition(-1, -1);
                }
            }
            else
            {
                Console.WriteLine("Invalid move ...");
            }

        }
    }
}