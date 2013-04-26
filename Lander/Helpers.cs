using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lander
{
    public static class Helpers
    {
        public static float Clamp(float value, float min, float max)
        {
            return Math.Min(Math.Max(value, min), max);
        }
    }
}
