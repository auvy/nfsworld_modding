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
    class Program {

        public static string[] namingScheme = {
            "DRAG",
            "VERGE", "GLINT", "OMNI",  "PRIME", "WIZEN", "HEX",   "Q-TECH", "CURV",  "HERO",
            "APEX",  "ENDO",  "XOR",   "SIGIL", "LOCUS", "RECON", "TORQ",   "UMBRA", "BICEP",
            "YOKAI", "NOMAD", "ICHOR", "MAGNI", "KABAL", "FAUST", "DRAFT",  "ZION",  "JINGO",
            "ZAZEN", "CONIC", "DJINN", "GYRO",  "SPUR",  "MORPH", "TAMPA",  "KRAIT", "ROGUE",
            "ANVIL", "XYST",  "JADE",  "LANK",  "ETUDE", "FORGE", "YAGA",   "OPUS",  "WARP",
            "BANE",  "UXAS",  "VOLPE", "PROXY", "QUAKE"
        };

        public static string[] prefixSuffix = {
            "WIDE", "AMPED", "BODYKIT",
            "LARGE", "SMALL", "HATCH", "SPOILER",
            "HOOD", "CF"
        };


        public static string[] needed = {
            "MAZRA RX-7 (FC3S)", "HUMMER H1",
            "APEX BODYKIT", "ENDO BODYKIT", "DRAG BODYKIT", 
            "VERGE AMPED BODYKIT", "GLINT AMPED BODYKIT", "OMNI AMPED BODYKIT", "PRIME AMPED BODYKIT", 
            "WIZEN AMPED BODYKIT", "HEX AMPED BODYKIT", "Q-TECH AMPED BODYKIT", "CURV AMPED BODYKIT", 
            "HERO AMPED BODYKIT", "APEX AMPED BODYKIT",
            "STOCK CF HOOD"
        };
 
        public static string[] catalogs = {
            "0000FC3S", "0000HUH1", 
            "0000APEX", "0000ENDO", "000049F4", 
            "000A49A6", "000A49BB", "000A49BE", "000A49A4", 
            "000A49C0", "000A49AC", "000A49AE", "000A49A8", 
            "000A49AD", "000AAPEX", 
            "0000STCF"
        };

        public static string[] aight = {
            "W49AC", "W49AE", "W49A8", "W49AD", "WAPEX"
        };

        public static void CreateAllLabruneEntries()
        {
            StreamWriter vltedw = new StreamWriter("./data/NewLabruneEntries.txt", true);

            for(int i = 0; i < needed.Length; i++)
                vltedw.WriteLine(LabruneOps.GenerateLabrune(needed[i], catalogs[i]));

            for(int i = 1; i < 11; i++){
                string number = (i < 10) ? "0" + i.ToString() : i.ToString();
                vltedw.WriteLine(LabruneOps.GenerateLabrune("UNIQUE SPOILER " + number, "0000US" + number));
            }

            string part = ""; 
            string catalog = "";
            string catalogpref = "";
            
            for(int i = 9; i < 26; i++){
                part = namingScheme[i] + " HOOD";
                catalogpref = (i < 10) ? "09" : i.ToString();
                catalog = "0000HD" + catalogpref;
                vltedw.WriteLine(LabruneOps.GenerateLabrune(part, catalog));
                part = namingScheme[i] + " CF HOOD";
                catalogpref = (i < 10) ? "09" : i.ToString();
                catalog = "0000HC" + catalogpref;
                vltedw.WriteLine(LabruneOps.GenerateLabrune(part, catalog));
            }
            for (int i = 10; i < 51; i++)
            {
                part = namingScheme[i] + " SPOILER";
                catalogpref = i.ToString();
                catalog = "0000SD" + catalogpref;
                vltedw.WriteLine(LabruneOps.GenerateLabrune(part, catalog));

                part = namingScheme[i] + " CF SPOILER";
                catalogpref = i.ToString();
                catalog = "0000SC" + catalogpref;
                vltedw.WriteLine(LabruneOps.GenerateLabrune(part, catalog));
            }

            for(int i = 6; i < 11; i++)
            {
                vltedw.WriteLine(LabruneOps.GenerateLabrune(namingScheme[i] + " WIDE BODYKIT", "000" + aight[i - 6]));
            }
            vltedw.Dispose();
        }

        static void Main() {
            

            VLTOps.AddVirtualItemParts();
        }
    }
}
