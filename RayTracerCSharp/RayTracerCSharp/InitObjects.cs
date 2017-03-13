

namespace RayTracerCSharp
{

    public class InitObjects
    {
        const double AmbientLight = 50; // Background lighting
        const double TransparencyIndicesOfRefractionAir = 1;
        const double TransparencyIndicesOfRefractionObj = 1;

        /// <summary>
        /// Defines a set of objects
        /// </summary>
        public void AddObjects(
            ObjectList objectlist )
            //TextArea      textAreaLog )
        {
            //textAreaLog.append("Defining objects\n");

            objectlist.COP = new Point(Constants.CenterOfProjectionX, Constants.CenterOfProjectionY, Constants.CenterOfProjectionZ);
            
            AddChessBoard(objectlist);

            AddMirrorPlane(objectlist);
            
            AddSecondPlane(objectlist);

            AddSphere(objectlist);

            //AddSphere2(objectlist);

            AddSphere3(objectlist);

            //-----------------------------------------------
            // Define lights
            //-----------------------------------------------
            //textAreaLog.append("Adding 3 Lights\n");

            Point pos = new Point();
            pos.Set(100, 800, -500);
            double lightSourceIntensity = 70;
            Light light = new Light(pos, lightSourceIntensity);
            objectlist.AddLight(light);

            pos.Set(-1100, 800, -200);
            lightSourceIntensity = 70;
            light = new Light(pos, lightSourceIntensity);
            objectlist.AddLight(light);

            pos.Set(0, 800, -800);
            lightSourceIntensity = 50;
            light = new Light(pos, lightSourceIntensity);
            objectlist.AddLight(light);
        }

        private static void AddChessBoard(ObjectList objectlist)
        {
            //textAreaLog.append("Adding Chessboard at y = -400 \n");
            DrawingObject obj = new ChessBoardPlane(
                -400, // double yPos ,                                           
                AmbientLight,
                0.01, // double AmbientReflectionCoeff, 
                0.99, // double AmbientReflectionCoeff2,
                0.2, // double DiffuseReflectionCoeff,
                0.1, // double SpecularReflectionCoeff,
                100, // int    SpecularReflectionExponent,
                50.0, // double SpecularColor,
                0.0, // double TransmissionCoeff,
                TransparencyIndicesOfRefractionAir,
                TransparencyIndicesOfRefractionObj,
                100 // double chessSize, 
                );
            objectlist.AddObject(obj);
        }

        private static void AddMirrorPlane(ObjectList objectlist)
        {
            //textAreaLog.append("Adding Plane 1 XY at 0,0,1500 \n");
            DrawingObject obj = new XYPlane(
                new Point(0, 0, 1500), // pos,
                AmbientLight,
                0.14, // AmbientReflectionCoeff - Background lighting reflected
                0.04, // DiffuseReflectionCoeff - Reflection of light from light source
                1.0, // SpecularReflectionCoeff - mirror effect
                100, // SpecularReflectionExponent,
                50.0, // SpecularColor,
                0.0, // TransmissionCoeff,                                  
                TransparencyIndicesOfRefractionAir,
                TransparencyIndicesOfRefractionObj,
                3000 // size, 
                );
            objectlist.AddObject(obj);
        }

        private static void AddSecondPlane(ObjectList objectlist)
        {
            //textAreaLog.append("Adding Pane 2 XY at at 0,0,600\n");
            Point pos = new Point(0, 0, 600);
            double size = 150;
            double ambientReflectionCoeff = 0.2;
            double diffuseReflectionCoeff = 0.1;
            double specularReflectionCoeff = 0.1;
            int specularReflectionExponent = 100;
            double specularColor = 50;
            double transmissionCoeff = 0.95;
            DrawingObject obj = new XYPlane(pos,
                AmbientLight,
                ambientReflectionCoeff,
                diffuseReflectionCoeff,
                specularReflectionCoeff,
                specularReflectionExponent,
                specularColor,
                transmissionCoeff,
                TransparencyIndicesOfRefractionAir,
                TransparencyIndicesOfRefractionObj,
                size);
            objectlist.AddObject(obj);
        }

        private static void AddThirdPlane(ObjectList objectlist)
        {
            //textAreaLog.append("Adding Plane 3 Chess at 250,200,500 \n");
            Point pos = new Point(250,200,500);
            double size = 300;
            double AmbientReflectionCoeff = 0.1;
            double AmbientReflectionCoeff2 = 0.8;
            double DiffuseReflectionCoeff = 0.4;
            double SpecularReflectionCoeff = 0.4;
            int    SpecularReflectionExponent = 100;
            double SpecularColor = 50;
            double TransmissionCoeff = 0.0;
            double chessSize = 50;
            DrawingObject obj = new XYChessPlane ( pos,
                                           AmbientLight, 
                                           AmbientReflectionCoeff, 
                                           AmbientReflectionCoeff2,
                                           DiffuseReflectionCoeff,
                                              SpecularReflectionCoeff,
                                       SpecularReflectionExponent,
                                       SpecularColor,
                                       TransmissionCoeff,
                                       TransparencyIndicesOfRefractionAir,
                                       TransparencyIndicesOfRefractionObj,
                                           size, 
                                           chessSize  );
            objectlist.AddObject(obj);
        }

        private static void AddSphere(ObjectList objectlist)
        {
            //textAreaLog.append("Adding Sphere 1 at 100,100,500 \n");
            Point pos = new Point(100, 100, 500);
            double size = 100;
            var ambientReflectionCoeff = 0.6;
            var diffuseReflectionCoeff = 0.8;
            var specularReflectionCoeff = 0.1;
            var specularReflectionExponent = 100;
            double specularColor = 50;
            var transmissionCoeff = 0.0;
            DrawingObject obj = new Sphere(pos,
                AmbientLight,
                ambientReflectionCoeff,
                diffuseReflectionCoeff,
                specularReflectionCoeff,
                specularReflectionExponent,
                specularColor,
                transmissionCoeff,
                TransparencyIndicesOfRefractionAir,
                TransparencyIndicesOfRefractionObj,
                size);
            objectlist.AddObject(obj);
        }

        private static void AddSphere2(ObjectList objectlist)
        {
            //textAreaLog.append("Adding Sphere 2 at -200,200,400 \n");
            Point pos = new Point(-200, 200, 400);
            double size = 100;
            var ambientReflectionCoeff = 0.1;
            double diffuseReflectionCoeff = 1;
            var specularReflectionCoeff = 0.2;
            var specularReflectionExponent = 100;
            double specularColor = 50;
            var transmissionCoeff = 0.0;
            DrawingObject obj = new Sphere(pos,
                AmbientLight,
                ambientReflectionCoeff,
                diffuseReflectionCoeff,
                specularReflectionCoeff,
                specularReflectionExponent,
                specularColor,
                transmissionCoeff,
                TransparencyIndicesOfRefractionAir,
                TransparencyIndicesOfRefractionObj,
                size);
            objectlist.AddObject(obj);
        }

        private static void AddSphere3(ObjectList objectlist)
        {
            //textAreaLog.append("Adding Sphere 3 at -100,-100,700 \n");

            Point pos = new Point(-100, -100, 700);
            double size = 100;
            var ambientReflectionCoeff = 0.2;
            var diffuseReflectionCoeff = 0.2;
            var specularReflectionCoeff = 1.0;
            var specularReflectionExponent = 100;
            double specularColor = 80;
            var transmissionCoeff = 0.0;
            DrawingObject obj = new Sphere(pos,
                AmbientLight,
                ambientReflectionCoeff,
                diffuseReflectionCoeff,
                specularReflectionCoeff,
                specularReflectionExponent,
                specularColor,
                transmissionCoeff,
                TransparencyIndicesOfRefractionAir,
                TransparencyIndicesOfRefractionObj,
                size);
            objectlist.AddObject(obj);
        }


    }

}
