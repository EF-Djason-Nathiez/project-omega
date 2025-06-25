using UnityEngine;

namespace Utilities
{
    public static class Math
    {
        public static float BezierCurve(float t, float p0, float p1, float p2, float p3)
        {
            // Calculate the Bezier curve point at parameter t
            return Mathf.Pow(1 - t, 3) * p0 +
                   3 * Mathf.Pow(1 - t, 2) * t * p1 +
                   3 * (1 - t) * Mathf.Pow(t, 2) * p2 +
                   Mathf.Pow(t, 3) * p3;
        }


    }
}
