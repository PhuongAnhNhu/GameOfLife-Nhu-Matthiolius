namespace GameOfLife
{
    public class Zelle
    {
        #region Fields
        private int _x;
        private int _y;
        #endregion

        #region Properties
        public int X
        {
            get { return this._x; }
            set { this._x = value; }
        }
        public int Y
        {
            get { return this._y; }
            set { this._y = value; }
        }
        #endregion

        #region Constructors
        public Zelle(int x, int y)
        {
            this._x = x;
            this._y = y;
        }
        #endregion

        #region Methods
        public bool IsNeighbor(Zelle zelle, int xMax, int yMax)
        {
            int left = this._x - 1 == 0 ? xMax : this._x - 1;
            int right = this._x == xMax ? 1 : this._x + 1;
            int up = this._y - 1 == 0 ? yMax : this._y - 1;
            int down = this._y == yMax ? 1 : this._y + 1;
            if (left == zelle.X && up == zelle.Y)
                return true;
            if (this._x == zelle.X && up == zelle.Y)
                return true;
            if (right == zelle.X && up == zelle.Y)
                return true;
            if (left == zelle.X && this._y == zelle.Y)
                return true;
            if (right == zelle.X && this._y == zelle.Y)
                return true;
            if (left == zelle.X && down == zelle.Y)
                return true;
            if (this._x == zelle.X && down == zelle.Y)
                return true;
            if (right == zelle.X && down == zelle.Y)
                return true;
            return false;
        }

        public Zelle[] GetNeighbors(int xMax, int yMax)
        {
            int left = this._x - 1 == 0 ? xMax : this._x - 1;
            int right = this._x == xMax ? 1 : this._x + 1;
            int up = this._y - 1 == 0 ? yMax : this._y - 1;
            int down = this._y == yMax ? 1 : this._y + 1;
            Zelle[] neighbors =
            {
                new Zelle(left, up),
                new Zelle(this._x, up),
                new Zelle(right, up),
                new Zelle(left, this._y),
                new Zelle(right, this._y),
                new Zelle(left, down),
                new Zelle(this._x, down),
                new Zelle(right, down)
            };
            return neighbors;
        }
        #endregion
    }
}
