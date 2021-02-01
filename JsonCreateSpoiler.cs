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
    
    public static class SpoilerCreator
    {
        public static JObject Spoiler(int number, string carName, bool cf)
        {
            Templates temp = new Templates();

            JObject o = (JObject)temp.mainTemplate.DeepClone();

            string strNumber = "";

            if(number < 10) strNumber = "0" + number.ToString();
            else strNumber = number.ToString();

            string name = carName + "_STYLE" + strNumber + "_SPOILER";
            if(cf) name += "_CF";
            o["Name"] = name;

            JObject stckFalse = (JObject)temp.stockFalse.DeepClone();

            JObject lodCharOffset = (JObject)temp.lodCharacterOffset.DeepClone();

            JObject lanHash = (JObject)temp.template1.DeepClone();
            lanHash.Add("Value", 36323522 + (1 * number));
            lanHash["Name"] = "LANGUAGEHASH";

            JObject lodNamePref = (JObject)temp.lodPrefixSelector.DeepClone();

            JObject nameOffset = (JObject)temp.template1.DeepClone();
            JArray strings = (JArray)nameOffset["Strings"];
            if(cf) strings.Add(strNumber + " CF");
            else strings.Add(strNumber);
            nameOffset["Name"] = "NAME_OFFSET";

            JObject idUpdateGroup = (JObject)temp.template1.DeepClone();
            idUpdateGroup.Add("Value", 15363 + (1 * number));
            idUpdateGroup["Name"] = "PARTID_UPGRADE_GROUP";

            JObject mxLod = (JObject)temp.maxLod.DeepClone();

            JObject lodBaseName = (JObject)temp.template1.DeepClone();
            strings = (JArray)lodBaseName["Strings"];
            strings.Add("STYLE" + strNumber);
            if(cf) strings.Add("SPOILER_CF");
            else strings.Add("SPOILER");
            lodBaseName["Name"] = "LOD_BASE_NAME";


            strings = (JArray)o["Attributes"];

            strings.Add(stckFalse);
            strings.Add(lodCharOffset);
            strings.Add(lanHash);
            strings.Add(lodNamePref);
            strings.Add(nameOffset);
            strings.Add(idUpdateGroup);
            strings.Add(mxLod);
            strings.Add(lodBaseName);

            return o;
        }
        public static JObject GlobalSpoiler(int number, string type, bool cf)
        {
            Templates temp = new Templates();

            JObject o = (JObject)temp.mainTemplate.DeepClone();

            string strNumber = "";

            if(number < 10) strNumber = "0" + number.ToString();
            else strNumber = number.ToString();

            string name = "SPOILER_STYLE" + strNumber + "_" + type;
            if(cf) name += "_CF";
            o["Name"] = name;

            JObject useMark = (JObject)temp.useMarker.DeepClone();

            JObject lodCharOffset = (JObject)temp.lodCharacterOffset.DeepClone();

            JObject lanHash = (JObject)temp.template1.DeepClone();
            if(cf) lanHash.Add("Value", 3983425162 + (35937 * number));
            else   lanHash.Add("Value", 36323522 + (1 * number));
            lanHash["Name"] = "LANGUAGEHASH";

            JObject lodNamePref = (JObject)temp.lodPrefixSelector.DeepClone();
            lodNamePref["Value"] = 2;

            JObject nameOffset = (JObject)temp.template1.DeepClone();
            JArray strings = (JArray)nameOffset["Strings"];
            if(cf) strings.Add("SPOILER " + strNumber + " CF");
            else strings.Add("SPOILER " + strNumber);
            nameOffset["Name"] = "NAME_OFFSET";

            JObject idUpdateGroup = (JObject)temp.template1.DeepClone();
            idUpdateGroup.Add("Value", 15393);
            idUpdateGroup["Name"] = "PARTID_UPGRADE_GROUP";


            JObject lodNamehash = (JObject)temp.template1.DeepClone();
            lodNamehash.Add("Value", 3376116733);
            lodNamehash["Name"] = "LOD_NAME_PREFIX_NAMEHASH";            

            JObject mxLod = (JObject)temp.maxLod.DeepClone();

            JObject lodBaseName = (JObject)temp.template1.DeepClone();
            strings = (JArray)lodBaseName["Strings"];
            strings.Add("STYLE" + strNumber);
            if(cf) strings.Add(type + "_CF");
            else strings.Add(type);
            lodBaseName["Name"] = "LOD_BASE_NAME";


            strings = (JArray)o["Attributes"];

            strings.Add(useMark);
            strings.Add(lodCharOffset);
            strings.Add(lanHash);
            strings.Add(lodNamePref);
            strings.Add(nameOffset);
            strings.Add(idUpdateGroup);
            strings.Add(lodNamehash);
            strings.Add(mxLod);
            strings.Add(lodBaseName);

            return o;
        }
    }
}