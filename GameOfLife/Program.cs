using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    static class Program
    {
        static void Main()
        {
            Zelle[] zellen = {
                new Zelle{ x = 0, y = 0 },
                new Zelle{ x = 1, y = 0 },
                new Zelle{ x = 2, y = 0 },
            };
            SpielFeld spielFeld = new SpielFeld(8,8,zellen);
        }
    }
    public class SpielFeld
    {
        public Zelle[] startZellen;
        public Zelle[] zellen;
        public int x, y;

        public SpielFeld(int x, int y, Zelle[] zellen)
        {
            this.startZellen = zellen;
            this.zellen = zellen;
            this.x = x;
            this.y = y;
        }

        public void next() { 
            
        }

        public int checkPopulation(Zelle zelle)
        {
            int population = 0;

            foreach (Zelle currentZelle in zellen)
            {
                if (zelle.isNeighbor(currentZelle))
                {
                    population++;
                } 
            }

            return population;
        }

        public void reset() {
            this.zellen = (Zelle[]) startZellen.Clone();
        }

    }

    public class Zelle
    {
        public int x;
        public int y;

        public bool isNeighbor(Zelle zelle)
        {
            return (
                (this.x - 1 == zelle.x && this.y == zelle.y) ||
                (this.x - 1 == zelle.x && this.y - 1 == zelle.y) ||
                (this.x == zelle.x && this.y - 1 == zelle.y) ||
                (this.x + 1 == zelle.x && this.y - 1 == zelle.y) ||
                (this.x + 1 == zelle.x && this.y == zelle.y) ||
                (this.x + 1 == zelle.x && this.y + 1 == zelle.y) ||
                (this.x == zelle.x && this.y + 1 == zelle.y) ||
                (this.x - 1 == zelle.x && this.y + 1 == zelle.y)
             ); 
        } 
    }
}
