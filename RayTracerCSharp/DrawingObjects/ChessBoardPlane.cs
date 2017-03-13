using System;

namespace RayTracerCSharp
{
    public class ChessBoardPlane : DrawingObject
    {
        // plane is positioned in XY plane
        public double ChessSize;
        public double AmbientReflectionCoeff1, AmbientReflectionCoeff2;

        // float _latestDistance;
        //    float latestLightIntensity;

        /** Creates a new instance of RT_Plane */
        //public ChessBoardPlane(){}
        public ChessBoardPlane(double yPos,
                                      double ambientLight,
                                      double ambientReflectionCoeff1,
                                      double ambientReflectionCoeff2,
                                      double diffuseReflectionCoeff,
                                      double specularReflectionCoeff,
                             int specularReflectionExponent,
                             double specularColor,
                             double transmissionCoeff,
                             double transparencyIndicesOfRefractionAir,
                             double transparencyIndicesOfRefractionObj,
                             double chessSize)
        {
            Position = new Point(0, yPos, 0);

            AmbientLight = ambientLight;
            AmbientReflectionCoeff1 = ambientReflectionCoeff1;
            AmbientReflectionCoeff2 = ambientReflectionCoeff2;
            AmbientReflectionCoeff  = ambientReflectionCoeff1;
            DiffuseReflectionCoeff = diffuseReflectionCoeff;
            SpecularReflectionCoeff = specularReflectionCoeff;
            SpecularReflectionExponent = specularReflectionExponent;
            SpecularColor = specularColor;
            TransmissionCoeff = transmissionCoeff;
            TransparencyIndicesOfRefractionAir = transparencyIndicesOfRefractionAir;
            TransparencyIndicesOfRefractionObj = transparencyIndicesOfRefractionObj;
            ChessSize = chessSize;
            Id = new DrawingObjectId(0, "PlaneChessBoard", DrawingObjectType.Chessboardplane);
        }

        public override void Texture(Point intersectionPoint)
        {
            // Find if white or black chess square
            int xChess, yChess;
            var tmpx = intersectionPoint.X;
            if (tmpx >= 0)
            {
                while (tmpx > ChessSize * 2) tmpx = tmpx - ChessSize * 2;
                xChess = 0;
                if (tmpx > ChessSize) xChess = 1;
            }
            else
            {
                while (tmpx < -ChessSize * 2)
                    tmpx = tmpx + ChessSize * 2;
                xChess = 0;
                if (tmpx > -ChessSize)
                    xChess = 1;
            }
            var tmpy = intersectionPoint.Z;
            if (tmpy >= 0)
            {
                while (tmpy > ChessSize * 2) tmpy = tmpy - ChessSize * 2;
                yChess = 0;
                if (tmpy > ChessSize) yChess = 1;
            }
            else
            {
                while (tmpy < -ChessSize * 2) tmpy = tmpy + ChessSize * 2;
                yChess = 0;
                if (tmpy > -ChessSize) yChess = 1;
            }
            var chess = xChess + yChess;
            if ((chess == 0) || (chess == 2))
                AmbientReflectionCoeff = AmbientReflectionCoeff1;
            else
                AmbientReflectionCoeff = AmbientReflectionCoeff2;
        }

        public override Hit Hit(Ray ray, ObjectList objList, bool inside)
        {
            // assumes that:
            // - image is in XY plane with positive Z
            // - plane is in XZ plane with negative Y and outside image
            Hit hitData = new Hit(false);
            // Check if ray intersects plane
            if (((ray.StartPoint.Y > Position.Y)        // starts on positive side of Y
                  && (ray.Vector.Y < 0))      // and has negative y direction
                /* || (  ( ray.startpoint.y < ypos )        // OR starts on negativee side of Y
                    && ( ray.vector.y > 0        ) ) */)
            {   // and has positive y direction

                double t = (Position.Y - ray.StartPoint.Y) / ray.Vector.Y;
                hitData.IsHit = true;
                hitData.IntersectionPoint =
                    new Point(ray.StartPoint.X + t * ray.Vector.X,
                                  Position.Y,
                                  ray.StartPoint.Z + t * ray.Vector.Z);
                hitData.Distance = Math.Abs(t * ray.Vector.LengthOf());

                return hitData; // true
            }
            return hitData;  // false
        }

        public override Vector ComputeNormal(Point point)
        {
            // assumes that:
            // - COP is at 0,0,0
            // - image is in XY plane with positive Z
            // - plane is in XZ plane with negative Y 
            Vector v = new Vector(0, 1, 0);
            v.Normalise();
            return v;
        }

        public override void IdMe()
        {
            //System.out.print( "  ChessBoard  " );
            //System.out.print( id.number );
        }

    }
}
