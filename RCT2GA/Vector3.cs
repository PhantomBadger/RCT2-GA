using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA
{
    class Vector3
    {
        //TODO
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 operator + (Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Vector3 vec = (Vector3)obj;
            return (X == vec.X && Y == vec.Y && Z == vec.Z);
        }

    }
}
