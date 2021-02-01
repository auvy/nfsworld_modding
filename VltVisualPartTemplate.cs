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
        abstract public class Construct
        {
            public string firstPartName;
            public string secondPartName;
            public string icon;
            public string subtype;
            public int lower;
            public int upper;
            public string[] catalogs;
            public int newUpper;
            public bool global;
            public string brand;
        }        
        
        public class Widebody : Construct
        {
            public Widebody()
            {
                global = false;
                firstPartName = "_KITW";
                secondPartName = "_INTEGRATED_KIT";
                icon = "VP_BST3_WOH";
                subtype = "vpart_bodykit";
                lower = 1;
                upper = 5;
                newUpper = 10;
                catalogs = new string[] {
                    "000049A9", "000049A7", "000049A5", "000049AA", "000049AF",
                    "000W49AC", "000W49AE", "000W49A8", "000W49AD", "000WAPEX"
                    };
                brand = "visual_brand_nfs";
            }
        }
        public class Bodykit : Construct
        {
            public Bodykit()
            {
                global = false;
                firstPartName = "_KIT";
                secondPartName = "_INTEGRATED_KIT";
                icon = "VP_BST1_WOH";
                subtype = "vpart_bodykit";
                lower = 1;
                upper = 12;
                newUpper = 12;
                catalogs = new string[] {
                    "000049A6", "000049BB", "000049BE", "000049A4", "000049C0", 
                    "000049AC", "000049AE", "000049A8", "000049AD", "0000APEX", 
                    "0000ENDO", "000049F4"
                    };
                brand = "visual_brand_nfs";
            }
        }  

        public class Ampedbody : Construct
        {
            public Ampedbody()
            {
                global = false;
                firstPartName = "_KIT9";
                secondPartName = "_INTEGRATED_KIT";
                icon = "VP_BST2_WOH";
                subtype = "vpart_bodykit";
                lower = 1;
                upper = 10;
                newUpper = 10;
                catalogs = new string[] {
                    "000A49A6", "000A49BB", "000A49BE", "000A49A4", "000A49C0", 
                    "000A49AC", "000A49AE", "000A49A8", "000A49AD", "000AAPEX"
                    };
                brand = "visual_brand_nfs";
            }
        }  

        public class Hood : Construct
        {
            public Hood()
            {
                global = false;
                firstPartName = "_STYLE";
                secondPartName = "_HOOD";
                icon = "PART_HOOD";
                subtype = "vpart_hood";
                lower = 1;
                upper = 8;
                newUpper = 25;
                catalogs = new string[] {
                    "00004998", "00004999", "0000499D", "0000499F", "000049A0", 
                    "00004993", "00004996", "00004997", 
                    "0000HD09", "0000HD10", "0000HD11", "0000HD12", "0000HD13", "0000HD14", "0000HD15", "0000HD16", "0000HD17", "0000HD18", "0000HD19", "0000HD20", "0000HD21", "0000HD22", "0000HD23", "0000HD24", "0000HD25" 
                    };
                brand = "visual_brand_nfs";
            }
        }  
        public class HoodCF : Construct
        {
            public HoodCF()
            {
                global = false;
                firstPartName = "_STYLE";
                secondPartName = "_HOOD_CF";
                icon = "PART_HOOD_CF";
                subtype = "vpart_hood";
                lower = 0;
                upper = 8;
                newUpper = 25;
                catalogs = new string[] {
           "0000STCF", "0000499E", "000049A1", "0000499A", "000049A2", "000049A3",
                       "0000499C", "00004994", "0000499B",
                       "0000HC09", "0000HC10", "0000HC11", "0000HC12", "0000HC13", "0000HC14", "0000HC15", "0000HC16", "0000HC17", "0000HC18", "0000HC19", "0000HC20", "0000HC21", "0000HC22", "0000HC23", "0000HC24", "0000HC25"
                    };
                brand = "visual_brand_nfs";
            }
        }  

        public class Spoiler : Construct
        {
            public Spoiler()
            {
                global = false;
                firstPartName = "_STYLE";
                secondPartName = "_SPOILER";
                icon = "PART_SPOILER";
                subtype = "vpart_spoiler";
                lower = 1;
                upper = 1;
                newUpper = 10;
                catalogs = new string[] {
                    "00004ED3",
                    "0000US01", "0000US02", "0000US03", "0000US04", "0000US05",
                    "0000US06", "0000US07", "0000US08", "0000US09", "0000US10"
                    };
                brand = "visual_brand_nfs";
            }
        }  


        public class SpoilerGlobal : Construct
        {
            public SpoilerGlobal()
            {
                global = true;
                firstPartName = "SPOILER_STYLE";
                secondPartName = "";
                icon = "PART_SPOILER";
                subtype = "vpart_spoiler";
                lower = 1;
                upper = 9;
                newUpper = 50;
                catalogs = new string[] {
                //default go here,
                "000049C3", "000049B5", "000049BF", "000049C2", "000049B0", "000049BD", "000049C1", "000049AB", "000049BC",
                "0000SD10", "0000SD11", "0000SD12", "0000SD13", "0000SD14", "0000SD15", "0000SD16", "0000SD17", "0000SD18", "0000SD19", "0000SD20", "0000SD21", "0000SD22", "0000SD23", "0000SD24", "0000SD25", "0000SD26", "0000SD27", "0000SD28", "0000SD29", "0000SD30", "0000SD31", "0000SD32", "0000SD33", "0000SD34", "0000SD35", "0000SD36", "0000SD37", "0000SD38", "0000SD39", "0000SD40", "0000SD41", "0000SD42", "0000SD43", "0000SD44", "0000SD45", "0000SD46", "0000SD47", "0000SD48", "0000SD49", "0000SD50"
                    };
                brand = "visual_brand_nfs";
            }
        }  

        public class SpoilerGlobalCF : Construct
        {
            public SpoilerGlobalCF()
            {
                global = true;
                firstPartName = "SPOILER_STYLE";
                secondPartName = "_CF";
                icon = "PART_SPOILER_CF";
                subtype = "vpart_spoiler";
                lower = 1;
                upper = 9;
                newUpper = 50;
                catalogs = new string[] {
                //default go here,
                "000049B1", "000049B2", "000049B3", "000049B4", "000049B6", "000049B7", "000049B8", "000049B9", "000049BA",
                "0000SC10", "0000SC11", "0000SC12", "0000SC13", "0000SC14", "0000SC15", "0000SC16", "0000SC17", "0000SC18", "0000SC19", "0000SC20", "0000SC21", "0000SC22", "0000SC23", "0000SC24", "0000SC25", "0000SC26", "0000SC27", "0000SC28", "0000SC29", "0000SC30", "0000SC31", "0000SC32", "0000SC33", "0000SC34", "0000SC35", "0000SC36", "0000SC37", "0000SC38", "0000SC39", "0000SC40", "0000SC41", "0000SC42", "0000SC43", "0000SC44", "0000SC45", "0000SC46", "0000SC47", "0000SC48", "0000SC49", "0000SC50"
                    };
                brand = "visual_brand_nfs";
            }
        }  


        public class LicensePlate : Construct
        {
            public LicensePlate()
            {
                global = true;
                firstPartName = "LICENSEPLATE_";
                secondPartName = "";
                icon = "PART_R3_LP";
                subtype = "vpart_licenseplate";
                lower = 0;
                upper = 49;
                newUpper = 49;
                catalogs = new string[] {
                "LPSTL000", "LPSTL001", "LPSTL002", "LPSTL003", "LPSTL004", "LPSTL005", "LPSTL006", "LPSTL007", "LPSTL008", "LPSTL009", "LPSTL010", "LPSTL011", "LPSTL012", "LPSTL013", "LPSTL014", "LPSTL015", "LPSTL016", "LPSTL017", "LPSTL018", "LPSTL019", "LPSTL020", "LPSTL021", "LPSTL022", "LPSTL023", "LPSTL024", "LPSTL025", "LPSTL026", "LPSTL027", "LPSTL028", "LPSTL029", "LPSTL030", "LPSTL031", "LPSTL032", "LPSTL033", "LPSTL034", "LPSTL035", "LPSTL036", "LPSTL037", "LPSTL038", "LPSTL039", "LPSTL040", "LPSTL041", "LPSTL042", "LPSTL043", "LPSTL044", "LPSTL045", "LPSTL046", "LPSTL047", "LPSTL048", "LPSTL049"                    };
                brand = "visual_brand_nfs";
            }
        }  

        public class Neon : Construct
        {
            public Neon()
            {
                global = true;
                firstPartName = "CARNEONGLOW_";
                secondPartName = "";
                icon = "PART_R3_NE_GOLD";
                subtype = "vpart_neon";
                lower = 0;
                upper = 49;
                newUpper = 49;
                catalogs = new string[] {
                "NESTL000", "NESTL001", "NESTL002", "NESTL003", "NESTL004", "NESTL005", "NESTL006", "NESTL007", "NESTL008", "NESTL009", "NESTL010", "NESTL011", "NESTL012", "NESTL013", "NESTL014", "NESTL015", "NESTL016", "NESTL017", "NESTL018", "NESTL019", "NESTL020", "NESTL021", "NESTL022", "NESTL023", "NESTL024", "NESTL025", "NESTL026", "NESTL027", "NESTL028", "NESTL029", "NESTL030", "NESTL031", "NESTL032", "NESTL033", "NESTL034", "NESTL035", "NESTL036", "NESTL037", "NESTL038", "NESTL039", "NESTL040", "NESTL041", "NESTL042", "NESTL043", "NESTL044", "NESTL045", "NESTL046", "NESTL047", "NESTL048", "NESTL049"                    };
                brand = "visual_brand_lumox";
            }
        }  



}
