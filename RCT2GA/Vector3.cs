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

        public Vector3(Vector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public static Vector3 operator + (Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
        }

        public static Vector3 operator - (Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z);
        }

        public static Vector3 operator * (Vector3 vec1, int scalar)
        {
            return new Vector3(vec1.X * scalar, vec1.Y * scalar, vec1.Z * scalar);
        }

        public static bool operator == (Vector3 vec1, Vector3 vec2)
        {
            return ((vec1.X == vec2.X) && (vec1.Y == vec2.Y) && (vec1.Z == vec2.Z));
        }

        public static bool operator != (Vector3 vec1, Vector3 vec2)
        {
            return !(vec1 == vec2);
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
