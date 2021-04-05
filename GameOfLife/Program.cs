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
                new Zelle{ x = 4, y = 3 },
                new Zelle{ x = 4, y = 5 },
                new Zelle{ x = 5, y = 4 },
                new Zelle{ x = 6, y = 4 },
                new Zelle{ x = 7, y = 4 },
            };
            SpielFeld spielFeld = new SpielFeld(8,8,zellen);
            spielFeld.next();
        }

    }
    public class SpielFeld
    {
        public Zelle[] startZellen;
        public Zelle[] lebendeZellen;
        public int x, y;

        public SpielFeld(int x, int y, Zelle[] lebendeZellen)
        {
            this.startZellen = lebendeZellen;
            this.lebendeZellen = lebendeZellen;
            this.x = x;
            this.y = y;
        }

        public void next() {
            Zelle[] naechsteGenerationLebendeZellen = { };
            
            // Neugeborene
            foreach(Zelle lebendeZelle in lebendeZellen)
            {
                foreach (Zelle currentZelle in lebendeZelle.getNeighbors())
                {
                    if (!Array.Exists<Zelle>(lebendeZellen, zelle => zelle.x == currentZelle.x && zelle.y == currentZelle.y) && checkPopulation(currentZelle) == 3)
                    {
                        if (!Array.Exists<Zelle>(naechsteGenerationLebendeZellen, zelle => zelle.x == currentZelle.x && zelle.y == currentZelle.y)) {
                           // Console.WriteLine("x: " + currentZelle.x + ", y: " + currentZelle.y + ", population: " + checkPopulation(currentZelle));
                            naechsteGenerationLebendeZellen = naechsteGenerationLebendeZellen.Append(currentZelle).ToArray();
                        }
                    }
                }
            } 

            // Überlebende Zellen
            foreach(Zelle lebendeZelle in lebendeZellen)
            {
               if(checkPopulation(lebendeZelle) >= 2 && checkPopulation(lebendeZelle) <= 3)
                {
                    if (!Array.Exists<Zelle>(naechsteGenerationLebendeZellen, zelle => zelle.x == lebendeZelle.x && zelle.y == lebendeZelle.y))
                    {
                       // Console.WriteLine("x: " + lebendeZelle.x + ", y: " + lebendeZelle.y + ", population: " + checkPopulation(lebendeZelle));
                        naechsteGenerationLebendeZellen = naechsteGenerationLebendeZellen.Append(lebendeZelle).ToArray();
                    }
                }
            }

            this.lebendeZellen = naechsteGenerationLebendeZellen;
            //foreach(Zelle  lebendeZelle in lebendeZellen)
            //{
            //    Console.WriteLine("x: " + lebendeZelle.x + ", y: " + lebendeZelle.y + ", population: " + checkPopulation(lebendeZelle));
            //}
        }

        public int checkPopulation(Zelle zelle)
        {
            int population = 0;

            foreach (Zelle currentZelle in lebendeZellen)
            {
                if (zelle.isNeighbor(currentZelle))
                {
                    population++;
                } 
            }

            return population;
        }

        public void reset() {
            this.lebendeZellen = (Zelle[]) startZellen.Clone();
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

        public Zelle[] getNeighbors()
        {
            Zelle[] neighbors = {
                new Zelle { x = this.x - 1, y = this.y },
                new Zelle { x = this.x - 1, y = this.y -1 },
                new Zelle { x = this.x, y = this.y -1 },
                new Zelle { x = this.x + 1, y = this.y - 1 },
                new Zelle { x = this.x + 1, y = this.y },
                new Zelle { x = this.x + 1, y = this.y + 1 },
                new Zelle { x = this.x, y = this.y + 1},
                new Zelle { x = this.x - 1, y = this.y + 1 },
            };
            return neighbors;
        }
    }
}
