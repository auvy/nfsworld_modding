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
    public static class OtherCreator
    {
        public static JObject Neon(string neonName)
        {
            Templates temp = new Templates();

            JObject o = (JObject)temp.mainTemplate.DeepClone();

            string name = "CARNEONGLOW_" + neonName;
            o["Name"] = name;

            JObject nameOffset = (JObject)temp.template1.DeepClone();
            JArray strings = (JArray)nameOffset["Strings"];
            strings.Add(name);
            nameOffset["Name"] = "NAME_OFFSET";

            JObject textureHash = (JObject)temp.template1.DeepClone();
            textureHash.Add("Value", Hashing.BinHash(name));
            textureHash["Name"] = "TEXTUREHASH";

            JObject idUpdateGroup = (JObject)temp.template1.DeepClone();
            idUpdateGroup.Add("Value", 25888);
            idUpdateGroup["Name"] = "PARTID_UPGRADE_GROUP";

            strings = (JArray)o["Attributes"];

            strings.Add(nameOffset);
            strings.Add(textureHash);
            strings.Add(idUpdateGroup);

            return o;
        }

        public static JObject Plate(string plateName)
        {
            Templates temp = new Templates();

            JObject o = (JObject)temp.mainTemplate.DeepClone();

            string name = "LICENSEPLATE_" + plateName;
            o["Name"] = name;

            JObject nameOffset = (JObject)temp.template1.DeepClone();
            JArray strings = (JArray)nameOffset["Strings"];
            strings.Add(name);
            nameOffset["Name"] = "NAME_OFFSET";

            JObject textureHash = (JObject)temp.template1.DeepClone();
            textureHash.Add("Value", Hashing.BinHash(name));
            textureHash["Name"] = "TEXTUREHASH";

            JObject idUpdateGroup = (JObject)temp.template1.DeepClone();
            idUpdateGroup.Add("Value", 25632);
            idUpdateGroup["Name"] = "PARTID_UPGRADE_GROUP";

            strings = (JArray)o["Attributes"];

            strings.Add(nameOffset);
            strings.Add(textureHash);
            strings.Add(idUpdateGroup);

            return o;
        }
    }
}