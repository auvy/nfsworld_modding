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
    
    public static class HoodCreator
    {
        public static JObject Hood(int number, string carName, bool cf)
        {
            Templates temp = new Templates();

            JObject o = (JObject)temp.mainTemplate.DeepClone();

            string strNumber = "";

            if(number < 10) strNumber = "0" + number.ToString();
            else strNumber = number.ToString();

            string name = carName + "_STYLE" + strNumber + "_HOOD";
            if(cf) name += "_CF";
            o["Name"] = name;


            JObject lodCharOffset = (JObject)temp.lodCharacterOffset2.DeepClone();

            JObject lanHash = (JObject)temp.template1.DeepClone();
            if(cf) lanHash.Add("Value", 171723638 + (1 * number));
            else  lanHash.Add("Value", 2528916686 + (1 * number));
            lanHash["Name"] = "LANGUAGEHASH";

            JObject lodNamePref = (JObject)temp.lodPrefixSelector.DeepClone();

            JObject nameOffset = (JObject)temp.template1.DeepClone();
            JArray strings = (JArray)nameOffset["Strings"];
            if(cf) strings.Add(strNumber + " CF");
            else strings.Add(strNumber);
            nameOffset["Name"] = "NAME_OFFSET";

            JObject idUpdateGroup = (JObject)temp.template1.DeepClone();
            idUpdateGroup.Add("Value", 23328 + (1 * number));
            idUpdateGroup["Name"] = "PARTID_UPGRADE_GROUP";

            JObject mxLod = (JObject)temp.maxLod.DeepClone();
            mxLod["Value"] = 3;

            JObject idk = (JObject)temp.template1.DeepClone();
            idk.Add("Value", 199781921);
            idk["Name"] = "0xE80A3B62";

            JObject lodBaseName = (JObject)temp.template1.DeepClone();
            strings = (JArray)lodBaseName["Strings"];
            strings.Add("STYLE" + strNumber);
            if(cf) strings.Add("HOOD_CF");
            else strings.Add("HOOD");
            lodBaseName["Name"] = "LOD_BASE_NAME";


            strings = (JArray)o["Attributes"];

            strings.Add(lodCharOffset);
            strings.Add(lanHash);
            strings.Add(lodNamePref);
            strings.Add(nameOffset);
            strings.Add(idUpdateGroup);
            strings.Add(mxLod);
            strings.Add(idk);
            strings.Add(lodBaseName);

            return o;
        }
    }
}