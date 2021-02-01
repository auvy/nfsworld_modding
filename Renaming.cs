using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Collections.Generic;

using System.Collections;

namespace prog
{
    public static class RenamingFunctions
    {
        //this was used once to generate wheel labrune/vlt
        public static void GenerateWheelNames(string filesPath, WheelsArr allwheels)
        {
            int LowerRimSize = 17;
            int UpperRimSize = 21;

            string catalogHead = "GM_CATALOG_";

            for(int i = 0; i < allwheels.wheels.Length; i++)
            {
                for(int j = 0; j < allwheels.wheels[i].rims.Length; j++)
                {
                    string style = "STYLE0" + (j + 1).ToString();
                    
                    for(int k = LowerRimSize; k < UpperRimSize + 1; k++)
                    {
                        string itemName = allwheels.wheels[i].brand + "_" + style + "_" + k.ToString() + "_" + "25";
                        uint itembinHash = Hashing.BinHash(itemName);
                        string nodeName = VLTOps.GetVltNodeHash(itemName);
                        string catalogName = catalogHead + itemName;
                        string text = allwheels.wheels[i].rims[j] + " " + k.ToString() + '"' + " WHEELS";

                        uint catalogBinHash = Hashing.BinHash(catalogName);
                        string catalogbinHex = Hashing.HexHash(catalogBinHash);

                        StreamWriter labrunew = new StreamWriter(filesPath + "labrune.txt", true);
                        labrunew.Write("0\t" + catalogbinHex + "\t" + catalogName + "\t" + text + "\n");
                        labrunew.Dispose();

                        StreamWriter vltedw = new StreamWriter(filesPath + "vlted.nfsms", true);
                        vltedw.Write(VLTOps.vltedCommands[0] + " virtualitem " + nodeName + " title " + catalogName + "\n");
                        vltedw.Dispose();
                    }
                }
            }
        }
    }
}