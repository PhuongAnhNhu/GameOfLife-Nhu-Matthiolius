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
                new Zelle{ X = 4, Y = 3 },
                new Zelle{ X = 4, Y = 5 },
                new Zelle{ X = 5, Y = 4 },
                new Zelle{ X = 6, Y = 4 },
                new Zelle{ X = 7, Y = 4 },
            };
            SpielFeld spielFeld = new SpielFeld(8, 8, zellen);
            spielFeld.Next();
        }
    }
}
