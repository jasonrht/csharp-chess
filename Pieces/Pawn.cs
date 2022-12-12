namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(string color, string position) : base("pawn", color, position) { }

        public void Move(int direction)
        {
            bool possible = (
                this.PosY + 1 <= 7
                && this.PosY - 1 >= 0
            );

            if (possible)
            {
                // 0: N; 1: 2xN; 2: S; 3: 2xS;
                if (direction == 0)
                {
                    ChangePosition(0, -1);
                }
                else if (direction == 1)
                {
                    ChangePosition(0, -2);
                }
                else if (direction == 2)
                {
                    ChangePosition(0, 1);
                }
                else if (direction == 3)
                {
                    ChangePosition(0, 2);
                }
            }
            else
            {
                Console.WriteLine("Invalid move ...");
            }
        }
    }
}