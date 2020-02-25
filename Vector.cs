using System;
using System.Text;

namespace MatrixTransformations
{
    public class Vector
    {
        public float x, y;

        public Vector()
        {
        }

        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v1.y);
        }

        public override string ToString()
        {
            return $"[ {x} , {y} ]";
        }
    }
}
