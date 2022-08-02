using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMod.Utils {
    public static class PseudoNumpyHelpers {
        // Method accepting a Vecto2 object and returning the L2-norm of that vector.
        public static float L2Norm(Vector2 vector) {
            double sqrtArg = Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2);
            return (float)Math.Sqrt(sqrtArg);
        }
    }
}
