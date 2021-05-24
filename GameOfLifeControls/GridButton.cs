using System.ComponentModel;
using System.Windows.Forms;

namespace GameOfLifeControls
{
    public class GridButton : Button
    {
        #region Fields
        private int _gridX;
        private int _gridY;
        #endregion

        #region Properties
        [DefaultValue(1)]
        public int X
        {
            get { return this._gridX; }
            set { this._gridX = value; }
        }
        [DefaultValue(1)]
        public int Y
        {
            get { return this._gridY; }
            set { this._gridY = value; }
        }
        #endregion

        #region Constructors
        public GridButton() : base() { }
        public GridButton(int x, int y) : base()
        {
            this._gridX = x;
            this._gridY = y;
        }
        #endregion
    }
}
