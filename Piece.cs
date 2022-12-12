namespace Chess
{
    class Piece
    {
        public string PieceColor
        { get; set; }
        public string PieceType
        { get; set; }
        public int PosX
        { get; set; }
        public int PosY
        { get; set; }

        public char[] abc = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

        public List<int[]> possibleMoves;

        public Piece(string pieceType, string color, string position)
        {
            this.PieceType = pieceType;
            this.PieceColor = color;
            this.possibleMoves = new List<int[]>();
            int[] positionArray = ParsePosition(position);
            this.PosX = positionArray[0];
            this.PosY = positionArray[1];
        }

        public int[] ParsePosition(string pos)
        {
            char[] splitPos = pos.ToArray();
            int[] intPos = new int[2];
            intPos[0] = Array.IndexOf(this.abc, splitPos[0]);
            intPos[1] = 8 - (int)Char.GetNumericValue(splitPos[1]);
            return intPos;
        }

        public string GetAbbreviation()
        {
            if (this.PieceType == "knight")
            {
                if (this.PieceColor == "black")
                {
                    return "bN";
                }
                else
                {
                    return "wN";
                }
            }

            string color = " ";
            if (this.PieceColor == "black")
            {
                color = "b";
            }
            else if (this.PieceColor == "white")
            {
                color = "w";
            }
            return color + this.PieceType[0].ToString().ToUpper();
        }

        public override string ToString()
        {
            return $"Piece name: {this.PieceType}       Color: {this.PieceColor}        Position: ({this.PosX}, {this.PosY})";
        }

        public void ChangePosition(int numX, int numY)
        {
            this.PosX += numX;
            this.PosY += numY;
        }

        public bool IsPossible(int posX, int posY)
        {
            return posX <= 7 && posX >= 0 && posY <= 7 && posY >= 0;
        }
    }
}