using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class SpielFeld
    {
        #region Fields
        private Zelle[] _startZellen;
        private Zelle[] _lebendeZellen;
        private int _x, _y;
        #endregion

        #region Properties
        public Zelle[] StartZellen
        {
            get { return this._startZellen; }
        }

        public Zelle[] LebendeZellen
        {
            get { return this._lebendeZellen; }
        }

        public int X
        {
            get { return this._x; }
        }
        public int Y
        {
            get { return this._y; }
        }
        #endregion

        #region Constructors
        public SpielFeld(int x, int y, Zelle[] lebendeZellen)
        {
            this._startZellen = lebendeZellen;
            this._lebendeZellen = lebendeZellen;
            this._x = x;
            this._y = y;
        }
        #endregion

        #region Methods
        public void Next()
        {
            Zelle[] naechsteGenerationLebendeZellen = { };

            // Neugeborene
            foreach (Zelle lebendeZelle in this._lebendeZellen)
            {
                foreach (Zelle currentZelle in lebendeZelle.GetNeighbors())
                {
                    if (!Array.Exists<Zelle>(this._lebendeZellen, zelle => zelle.X == currentZelle.X && zelle.Y == currentZelle.Y) && CheckPopulation(currentZelle) == 3)
                    {
                        if (!Array.Exists<Zelle>(naechsteGenerationLebendeZellen, zelle => zelle.X == currentZelle.X && zelle.Y == currentZelle.Y))
                        {
                            // Console.WriteLine("x: " + currentZelle.x + ", y: " + currentZelle.y + ", population: " + checkPopulation(currentZelle));
                            naechsteGenerationLebendeZellen = naechsteGenerationLebendeZellen.Append(currentZelle).ToArray();
                        }
                    }
                }
            }

            // Überlebende Zellen
            foreach (Zelle lebendeZelle in this._lebendeZellen)
            {
                if (CheckPopulation(lebendeZelle) >= 2 && CheckPopulation(lebendeZelle) <= 3)
                {
                    if (!Array.Exists<Zelle>(naechsteGenerationLebendeZellen, zelle => zelle.X == lebendeZelle.X && zelle.Y == lebendeZelle.Y))
                    {
                        // Console.WriteLine("x: " + lebendeZelle.x + ", y: " + lebendeZelle.y + ", population: " + checkPopulation(lebendeZelle));
                        naechsteGenerationLebendeZellen = naechsteGenerationLebendeZellen.Append(lebendeZelle).ToArray();
                    }
                }
            }

            this._lebendeZellen = naechsteGenerationLebendeZellen;
            //foreach(Zelle  lebendeZelle in lebendeZellen)
            //{
            //    Console.WriteLine("x: " + lebendeZelle.x + ", y: " + lebendeZelle.y + ", population: " + checkPopulation(lebendeZelle));
            //}
        }

        public int CheckPopulation(Zelle zelle)
        {
            int population = 0;

            foreach (Zelle currentZelle in this._lebendeZellen)
            {
                if (zelle.IsNeighbor(currentZelle))
                {
                    population++;
                }
            }

            return population;
        }

        public void Reset()
        {
            this._lebendeZellen = (Zelle[])_startZellen.Clone();
        }
        #endregion
    }
}
