namespace Chess
{
    class Knight : Piece
    {
        public Knight(string color, string position) : base("knight", color, position) { }

        public void Move(int direction)
        {
            bool possible = (
                (this.PosX - 1 > 0 && this.PosY - 2 > 0)
                && (this.PosX + 1 < 7 && this.PosY - 2 > 0)
                && (this.PosX + 2 < 7 && this.PosY - 1 > 0)
                && (this.PosX + 1 < 7 && this.PosY + 1 < 7)
                && (this.PosX + 1 < 7 && this.PosY + 2 < 7)
                && (this.PosX - 1 > 0 && this.PosY + 2 < 7)
                && (this.PosX - 2 > 0 && this.PosY + 1 < 7)
                && (this.PosX - 1 > 0 && this.PosY + 2 < 7)
            );

            if (possible)
            {
                // 0: NNE; 1: NEE; 2: SEE; 3: SSE; 4: SSW; 5: SSW; 6: NWW; 7: NNW;
                if (direction == 0)
                {
                    ChangePosition(1, -2);
                }
                else if (direction == 1)
                {
                    ChangePosition(2, -1);
                }
                else if (direction == 2)
                {
                    ChangePosition(2, 1);
                }
                else if (direction == 3)
                {
                    ChangePosition(1, 2);
                }
                else if (direction == 4)
                {
                    ChangePosition(-1, 2);
                }
                else if (direction == 5)
                {
                    ChangePosition(-2, 1);
                }
                else if (direction == 6)
                {
                    ChangePosition(-2, -2);
                }
                else if (direction == 7)
                {
                    ChangePosition(-1, -2);
                }
            }
        }
    }
}