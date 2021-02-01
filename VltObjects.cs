using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Collections.Generic;

using System.Collections;


namespace prog{
    
    public class IngameDataobj
    {
        string binhash;
        string nodename;
        string catalogName;
        string description;
        public IngameDataobj(string hash, string node, string cName, string desc)
        {
            binhash =  hash;
            nodename = node;
            catalogName = cName;
            description = desc;
        }
    }

    public class WheelsData
    {
        public string brand;
        public string[] rims;
        public WheelsData(string branding, string[] wheels)
        {
            brand = branding;
            rims = wheels;
        }

    }
    
    public class WheelsArr
    {
        public WheelsData[] wheels;
        public static WheelsArr JsonDeserialize(string filePath)
        {
            WheelsArr r = JsonConvert.DeserializeObject<WheelsArr>(File.ReadAllText(filePath), 
            new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto});
            return r;
        }
    }

    public class VehArr
    {
        public string[] cars;
        public string[] catalogs;
        public static VehArr JsonDeserialize(string filePath)
        {
            VehArr r = JsonConvert.DeserializeObject<VehArr>(File.ReadAllText(filePath), 
            new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto});
            return r;
        }
    }
 
    // public class VirtualItem
    // {
    //     string itemName;
    //     string hash;
    //     string icon;
    //     string longdescription = "GM_CATALOG_00000000";
    //     string shortdescription = "GM_CATALOG_00000119";
    //     string subType = "vpart_bodykit";
    //     string title;
    //     string type = "visualpart";
    //     string brand = "visual_brand_nfs";
    //     int resellprice = 0;
    //     int tier = 0;
    //     bool warnondelete = false;
    // }
}