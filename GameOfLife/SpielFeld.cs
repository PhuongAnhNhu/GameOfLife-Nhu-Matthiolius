using System;
using System.Linq;

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

        #region Constructor
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
                    if (!ZelleExistiert(this._lebendeZellen, currentZelle) && CheckPopulation(currentZelle) == 3)
                    {
                        if (!ZelleExistiert(naechsteGenerationLebendeZellen, currentZelle))
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
                    if (!ZelleExistiert(naechsteGenerationLebendeZellen, lebendeZelle))
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

        public void ZelleAendern(Zelle zelle, out bool zelleLebt)
        {
            zelleLebt = ZelleExistiert(this._lebendeZellen, zelle);
            if (zelleLebt)
                this._lebendeZellen = this._lebendeZellen.Remove(zelle).ToArray();
            else
                this._lebendeZellen = this._lebendeZellen.Append(zelle).ToArray();
        }

        public static bool ZelleExistiert(Zelle[] suchArray, Zelle pruefZelle)
        {
            return Array.Exists<Zelle>(suchArray, zelle => zelle.X == pruefZelle.X && zelle.Y == pruefZelle.Y);
        }
        #endregion
    }
}
