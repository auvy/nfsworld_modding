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
    public static class AppenderGlobal
    {
        public static void AppendNeon (JObject o, string name)
        {
            JArray strings = (JArray)o["Parts"];
            strings.Add(OtherCreator.Neon(name));
        }
        public static void AppendPlate (JObject o, string name)
        {
            JArray strings = (JArray)o["Parts"];
            strings.Add(OtherCreator.Plate(name));
        }

        public static void AppendSpoilerGlobal (JObject o, int number, string type, bool cf)
        {
            JArray strings = (JArray)o["Parts"];
            strings.Add(SpoilerCreator.GlobalSpoiler(number, type, cf));
        }
    }
}