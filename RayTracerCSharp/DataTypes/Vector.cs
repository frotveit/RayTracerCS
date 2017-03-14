using System;

namespace RayTracerCSharp
{
    public class Vector : IEquatable<Vector>
    {
        public double X, Y, Z;

        public Vector() { }
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector(Vector v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }
        public double GetX() { return X; }
        public double GetY() { return Y; }
        public double GetZ() { return Z; }
        public void Set(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public void ComputeVector(Point from, Point to)
        {
            X = to.X - from.X;
            Y = to.Y - from.Y;
            Z = to.Z - from.Z;
        }

        public double ComputeDotProduct(Vector vector2)
        {
            return (X * vector2.X
                + Y * vector2.Y
                + Z * vector2.Z);
        }

        public void Normalise()
        {
            var root = X * X + Y * Y + Z * Z;
            var length = Math.Sqrt(root);
            X = X / length;
            Y = Y / length;
            Z = Z / length;
        }
        public double LengthOf()
        {
            double root = X * X + Y * Y + Z * Z;
            double length = Math.Abs(Math.Sqrt(root));
            return length;
        }
        public Vector Multiply(double mult)
        {
            Vector newVec = new Vector(X * mult, Y * mult, Z * mult);
            return newVec;
        }

        /// <summary>
        /// Return this vector minus argument vector.
        /// </summary>
        public Vector MinusVector(Vector vec)
        {
            Vector newVec = new Vector(X - vec.X, Y - vec.Y, Z - vec.Z);
            return newVec;
        }

        #region Equals

        public bool Equals(Vector other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(Object other)
        {
            if (other.GetType() != typeof(Vector))
                return false;
            return X == ((Vector)other).X && Y == ((Vector)other).Y && Z == ((Vector)other).Z;
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            return (int)X;
        }

        #endregion Equals
    }
}
