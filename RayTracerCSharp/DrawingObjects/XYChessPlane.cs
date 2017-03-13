
namespace RayTracerCSharp
{
    public class XYChessPlane : XYPlane
    {

        private readonly double _ambientReflectionCoeff1;
        private readonly double _ambientReflectionCoeff2;
        private readonly double _chessSize;


        public XYChessPlane(Point position,
            double ambientLight,
            double setAmbientReflectionCoeff1,
            double setAmbientReflectionCoeff2,
            double setDiffuseReflectionCoeff,
            double setSpecularReflectionCoeff,
            int setSpecularReflectionExponent,
            double setSpecularColor,
            double setTransmissionCoeff,
            double setTransparencyIndicesOfRefractionAir,
            double setTransparencyIndicesOfRefractionObj,
            double size,
            double chessSizeSet)
        {
            Position = new Point(position);
            AmbientLight = ambientLight;
            _ambientReflectionCoeff1 = setAmbientReflectionCoeff1;
            _ambientReflectionCoeff2 = setAmbientReflectionCoeff2;
            AmbientReflectionCoeff = 0;
            DiffuseReflectionCoeff = setDiffuseReflectionCoeff;
            SpecularReflectionCoeff = setSpecularReflectionCoeff;
            SpecularReflectionExponent = setSpecularReflectionExponent;
            SpecularColor = setSpecularColor;
            TransmissionCoeff = setTransmissionCoeff;
            TransparencyIndicesOfRefractionAir = setTransparencyIndicesOfRefractionAir;
            TransparencyIndicesOfRefractionObj = setTransparencyIndicesOfRefractionObj;
            Planesize = size;
            _chessSize = chessSizeSet;
            Id = new DrawingObjectId(0, "PlaneXY Chess", DrawingObjectType.Xychessplane);
        }

        public override void Texture(Point intersPoint)
        {
            // find if white or black chess square
            // returnColor is set and read by calling getColor();
            double tmp = intersPoint.X;
            int xChess = 0, yChess = 0;
            while (tmp > _chessSize*2) tmp = tmp - _chessSize*2;
            if (tmp > _chessSize) xChess = 1;
            tmp = intersPoint.Y;
            while (tmp > _chessSize*2) tmp = tmp - _chessSize*2;
            if (tmp > _chessSize) yChess = 1;
            int chess = xChess + yChess;
            if ((chess == 0) || (chess == 2))
            {
                AmbientReflectionCoeff = _ambientReflectionCoeff1;
            }
            else AmbientReflectionCoeff = _ambientReflectionCoeff2;
        }

    }

}
