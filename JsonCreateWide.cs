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
    
    public static class WBodykitCreator
    {
        public static JObject Body(int number, string carName)
        { 
            Templates temp = new Templates();
            JObject o = (JObject)temp.mainTemplate.DeepClone();

            string strNumber = "";

            if(number < 10) strNumber = "0" + number.ToString();
            else strNumber = number.ToString();

            string name = carName + "_BODY_KITW" + strNumber;
            o["Name"] = name;

            JObject cv = (JObject)temp.template1.DeepClone();
            cv.Add("Value", 2750249672 + (35937 * number));
            cv["Name"] = "CV";

            JObject lodCharOffset = (JObject)temp.lodCharacterOffset.DeepClone();

            JObject lanHash = (JObject)temp.template1.DeepClone();
            lanHash.Add("Value", 2678708386 + (1 * number));
            lanHash["Name"] = "LANGUAGEHASH";

            JObject lodNamePref = (JObject)temp.lodPrefixSelector.DeepClone();

            JObject kitNumber = (JObject)temp.template1.DeepClone();
            kitNumber.Add("Value", number);
            kitNumber["Name"] = "KITNUMBER";

            JObject nameOffset = (JObject)temp.template1.DeepClone();
            JArray strings = (JArray)nameOffset["Strings"];
            strings.Add(strNumber);
            nameOffset["Name"] = "NAME_OFFSET";

            JObject idUpdateGroup = (JObject)temp.template1.DeepClone();
            idUpdateGroup.Add("Value", 5984 + (1 * number));
            idUpdateGroup["Name"] = "PARTID_UPGRADE_GROUP";

            JObject mxLod = (JObject)temp.maxLod.DeepClone();

            JObject lodBaseName = (JObject)temp.template1.DeepClone();
            strings = (JArray)lodBaseName["Strings"];
            strings.Add("KITW" + strNumber);
            strings.Add("BODY");
            lodBaseName["Name"] = "LOD_BASE_NAME";

            strings = (JArray)o["Attributes"];
            strings.Add(cv);
            strings.Add(lodCharOffset);
            strings.Add(lanHash);
            strings.Add(lodNamePref);
            strings.Add(kitNumber);
            strings.Add(nameOffset);
            strings.Add(idUpdateGroup);
            strings.Add(mxLod);
            strings.Add(lodBaseName);

            return o;
        }
    
        public static JObject Integrated(int number, string carName)
        {
            Templates temp = new Templates();
            
            JObject o = (JObject)temp.mainTemplate.DeepClone();

            string strNumber = "";

            if(number < 10) strNumber = "0" + number.ToString();
            else strNumber = number.ToString();

            string name = carName + "_KITW" + strNumber + "_INTEGRATED_KIT";
            o["Name"] = name;

            JObject lanHash = (JObject)temp.template1.DeepClone();
            lanHash.Add("Value", 3877976299 + (1 * number));
            lanHash["Name"] = "LANGUAGEHASH";

            JObject kitNumber = (JObject)temp.template1.DeepClone();
            kitNumber.Add("Value", 800 + number);
            kitNumber["Name"] = "KITNUMBER";

            JObject idk = (JObject)temp.template1.DeepClone();
            idk.Add("Value", number);
            idk["Name"] = "0x7D29CF3E";

            JObject nameOffset = (JObject)temp.template1.DeepClone();
            JArray strings = (JArray)nameOffset["Strings"];
            strings.Add("W" + strNumber);
            nameOffset["Name"] = "NAME_OFFSET";

            JObject idUpdateGroup = (JObject)temp.template1.DeepClone();
            idUpdateGroup.Add("Value", 30752);
            idUpdateGroup["Name"] = "PARTID_UPGRADE_GROUP";


            strings = (JArray)o["Attributes"];

            strings.Add(lanHash);
            strings.Add(kitNumber);
            strings.Add(idk);
            strings.Add(nameOffset);
            strings.Add(idUpdateGroup);

            return o;
        }

        public static JObject Door(int number, string carName, string side)
        {
            Templates temp = new Templates();

            JObject o = (JObject)temp.mainTemplate.DeepClone();

            string strNumber = "";

            if(number < 10) strNumber = "0" + number.ToString();
            else strNumber = number.ToString();

            string name = carName + "_KITW" + strNumber + "_DOOR_" + side;
            o["Name"] = name;

            JObject lodCharOffset = (JObject)temp.lodCharacterOffset.DeepClone();

            JObject lanHash = (JObject)temp.template1.DeepClone();
            uint doorHash = 0;
            if(side == "LEFT") doorHash = 1774456068;
            else doorHash = 2729735447;
            lanHash.Add("Value", doorHash);
            lanHash["Name"] = "LANGUAGEHASH";

            JObject lodNamePref = (JObject)temp.lodPrefixSelector.DeepClone();

            JObject kitNumber = (JObject)temp.template1.DeepClone();
            kitNumber.Add("Value", number);
            kitNumber["Name"] = "KITNUMBER";

            JObject nameOffset = (JObject)temp.template1.DeepClone();
            JArray strings = (JArray)nameOffset["Strings"];
            strings.Add(strNumber);
            nameOffset["Name"] = "NAME_OFFSET";

            JObject idUpdateGroup = (JObject)temp.template1.DeepClone();
            int updateGroupVal = 0;
            if(side == "LEFT") updateGroupVal = 24320;
            else updateGroupVal = 24576;
            idUpdateGroup.Add("Value", updateGroupVal);
            idUpdateGroup["Name"] = "PARTID_UPGRADE_GROUP";

            JObject mxLod = (JObject)temp.maxLod.DeepClone();

            JObject lodBaseName = (JObject)temp.template1.DeepClone();
            strings = (JArray)lodBaseName["Strings"];
            strings.Add("KITW" + strNumber);
            strings.Add("DOOR_" + side);
            lodBaseName["Name"] = "LOD_BASE_NAME";

            strings = (JArray)o["Attributes"];
            strings.Add(lodCharOffset);
            strings.Add(lanHash);
            strings.Add(lodNamePref);
            strings.Add(kitNumber);
            strings.Add(nameOffset);
            strings.Add(idUpdateGroup);
            strings.Add(mxLod);
            strings.Add(lodBaseName);

            return o;
        }
    }
}