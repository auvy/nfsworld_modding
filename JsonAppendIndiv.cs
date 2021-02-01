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
    public static class Appender
    {
        public static void AppendWBodykit (JObject o, int number, string carName)
        {
            JArray strings = (JArray)o["Parts"];
            strings.Add(WBodykitCreator.Body(number, carName));
            strings.Add(WBodykitCreator.Door(number, carName, "LEFT"));
            strings.Add(WBodykitCreator.Door(number, carName, "RIGHT"));
            strings.Add(WBodykitCreator.Integrated(number, carName));
        }

        public static void AppendWBodykitNew (JObject o, int number, string carName)
        {
            JArray strings = (JArray)o["Parts"];
            strings.Add(WBodykitCreator.Body(number, carName));
            strings.Add(WBodykitCreator.Door(number, carName, "LEFT"));
            strings.Add(WBodykitCreator.Door(number, carName, "RIGHT"));
            strings.Add(WBodykitCreator.Integrated(number, carName));
            //damaged parts to be added
        }

        public static void AppendBodykit (JObject o, int number, string carName)
        {
            //
        }

        public static void AppendBodykitNew (JObject o, int number, string carName)
        {
            //
        }

        public static void AppendHood (JObject o, int number, string carName, bool cf)
        {
            JArray strings = (JArray)o["Parts"];
            strings.Add(HoodCreator.Hood(number, carName, cf));
        }

        public static void AppendSpoiler (JObject o, int number, string carName, bool cf)
        {
            JArray strings = (JArray)o["Parts"];
            strings.Add(SpoilerCreator.Spoiler(number, carName, cf));
        }
    }
}