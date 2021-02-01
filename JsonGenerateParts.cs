using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace prog {
    public static class GenerateJsons {
        static string folderpath = "globalc/CarParts/";        
        public static void CreateIndividualParts()
        {
            /*this was used to generate KITW06-10, 
            H00D_STYLE09-15 + CF, SPOILER_STYLE_02-05
            for every car from list
            */
            for(int i = 0; i < AllCars.carlist.Length; i++)
            {
                string car = AllCars.carlist[i];

                string path = folderpath + car + ".json";
                JObject carParts = JObject.Parse(File.ReadAllText(path));

                // create new stuff
                for(int w = 6; w < 11; w++)
                {
                    Appender.AppendWBodykit(carParts, w, car);
                }
                for(int h = 9; h < 26; h++)
                {
                    Appender.AppendHood(carParts, h, car, false);
                    Appender.AppendHood(carParts, h, car, true);
                }      
                for(int s = 2; s < 11; s++)
                {
                    Appender.AppendSpoiler(carParts, s, car, false);
                }

                //write to file            
                using (StreamWriter file = File.CreateText("newGlobal/" + car + ".json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, carParts);
                }
            }
        }
        public static void CreateGlobalParts()
        {
            string filename = "NEON_GLOW.json";
            string path = folderpath + filename;
            JObject carParts = JObject.Parse(File.ReadAllText(path));

            string style = "";
            for(int n = 0; n < 50; n++)
            {
                if(n < 10) style = "0" + n.ToString();
                else style = n.ToString();
                AppenderGlobal.AppendNeon(carParts, "STYLE" + style);
            }    

            using (StreamWriter file = File.CreateText("newGlobal/" + filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, carParts);
            }

            filename = "0x36E415D2.json";
            path = folderpath + filename;
            carParts = JObject.Parse(File.ReadAllText(path));

            style = "";
            for(int n = 0; n < 50; n++)
            {
                if(n < 10) style = "0" + n.ToString();
                else style = n.ToString();
                AppenderGlobal.AppendPlate(carParts, "STYLE" + style);
            }    

            using (StreamWriter file = File.CreateText("newGlobal/" + filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, carParts);
            }

            string[] types = {"LARGE", "SMALL", "HATCH"};

            foreach(string s in types)
            {
                filename = "SPOILER_" + s + ".json";
                path = folderpath + filename;
                carParts = JObject.Parse(File.ReadAllText(path));

                for(int n = 10; n < 51; n++)
                {
                    AppenderGlobal.AppendSpoilerGlobal(carParts, n, s, false);
                    AppenderGlobal.AppendSpoilerGlobal(carParts, n, s, true);
                }    

                using (StreamWriter file = File.CreateText("newGlobal/" + filename))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, carParts);
                }
            }
        }
    }
}

