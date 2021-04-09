using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #region Methods
        public bool IsNeighbor(Zelle zelle)
        {
            return (
                (this._x - 1 == zelle.X && this._y == zelle.Y) ||
                (this._x - 1 == zelle.X && this._y - 1 == zelle.Y) ||
                (this._x == zelle.X && this._y - 1 == zelle.Y) ||
                (this._x + 1 == zelle.X && this._y - 1 == zelle.Y) ||
                (this._x + 1 == zelle.X && this._y == zelle.Y) ||
                (this._x + 1 == zelle.X && this._y + 1 == zelle.Y) ||
                (this._x == zelle.X && this._y + 1 == zelle.Y) ||
                (this._x - 1 == zelle.X && this._y + 1 == zelle.Y)
             );
        }

        public Zelle[] GetNeighbors()
        {
            Zelle[] neighbors = {
                new Zelle { 
                    X = this._x - 1,
                    Y = this._y
                },
                new Zelle { 
                    X = this._x - 1,
                    Y = this._y - 1 
                },
                new Zelle { 
                    X = this._x,
                    Y = this._y - 1 
                },
                new Zelle { 
                    X = this._x + 1, 
                    Y = this._y - 1 
                },
                new Zelle { 
                    X = this._x + 1,
                    Y = this._y 
                },
                new Zelle { 
                    X = this._x + 1, 
                    Y = this._y + 1 
                },
                new Zelle { 
                    X = this._x, 
                    Y = this._y + 1 
                },
                new Zelle { 
                    X = this._x - 1, 
                    Y = this._y + 1 
                }
            };
            return neighbors;
        }
        #endregion
    }
}
