using System;
using MLogicLib;

namespace MarketingLogic {
    class Program {
        static void Main(string[] args) {
            //string path_in = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["path_in"];
            string path_in = @"..\..\..\" + System.Configuration.ConfigurationManager.AppSettings["path_in"];
            string file = System.Configuration.ConfigurationManager.AppSettings["file"];
            int frame_width = int.Parse(System.Configuration.ConfigurationManager.AppSettings["frame_width"]);

            MLogic ml = new(path_in, file);
            int[] M = ml.GetMedian(frame_width);
        }
    }
}
