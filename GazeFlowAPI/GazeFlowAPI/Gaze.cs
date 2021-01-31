using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GazeFlowAPI;
using RGiesecke.DllExport;

namespace GazeFlowAPI_dll
{
    public static class Gaze
    {
        [DllExport]
        public static void Coordinates(ref object obj)
        {

            obj = new float[] { 0, 0, 0, 0, 0, 0, 0, 0 };

            CGazeFlowAPI gazeFlowAPI = new CGazeFlowAPI();
            //To get your AppKey register at http://gazeflow.epizy.com/GazeFlowAPI/register/

            string AppKey = "Dronecontrolusingeye-graze1-Non-Commercial-Use";

            if (gazeFlowAPI.Connect("127.0.0.1", 43333, AppKey))
            {
                while (true)
                {
                    CGazeData GazeData = gazeFlowAPI.ReciveGazeDataSyn();
                    if (GazeData == null)
                    {
                        Console.WriteLine("Disconected");
                        return;
                    }
                    else
                    {

                        //Console.WriteLine("Gaze: {0} , {1}", GazeData.GazeX, GazeData.GazeY);
                        //Console.WriteLine("Head: {0} , {1}, {2}", GazeData.HeadX, GazeData.HeadY, GazeData.HeadZ);
                        //Console.WriteLine("Head rot : {0} , {1}, {2}", GazeData.HeadYaw, GazeData.HeadPitch, GazeData.HeadRoll);
                        //Console.WriteLine("");
                        //append to list, return
                        obj = new float[] { GazeData.GazeX, GazeData.GazeY, GazeData.HeadX, GazeData.HeadY, GazeData.HeadZ, GazeData.HeadYaw, GazeData.HeadPitch, GazeData.HeadRoll };
                        return;
                    }
                }


            }
            else
                Console.WriteLine("Connection fail");
            obj = new float[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            //Console.Read();
            return;

        }

    }
}
