using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public static class Extensions
    {
        public static IEnumerable<Zelle> Remove(this IEnumerable<Zelle> zelleSequence, Zelle zelle)
        {
            if (SpielFeld.ZelleExistiert(zelleSequence.ToArray(), zelle))
            {
                zelleSequence = zelleSequence.Where<Zelle>(z => z.X != zelle.X || z.Y != zelle.Y);
            }
            return zelleSequence;
        }
    }
}
