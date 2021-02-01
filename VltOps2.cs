// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Globalization;
// using System.Linq;
// using System.Runtime.InteropServices;
// using System.Text;
// using System.Threading.Tasks;
// using System.Windows.Input;
// using Newtonsoft.Json;
// using System.IO;

// namespace prog {


//     public static class VLTOps2
//     {
//         public static string[] vltedCommands = {"update_field", "add_node", "add_field", "resize_field"};

//         //FindNodeByString
//         public static string GetVltNodeHash(string name)
//         {
//             //get hex from BinHash
//             //turn it to string
//             string hash = "0x" + Hashing.HexHash(Hashing.BinHash(name));
//             //turn it lowercase
//             hash = hash.ToLower();
//             //put that string to VLTHash
//             string vlthash = "0x" + Hashing.HexHash(Hashing.VLTHash(hash));
//             //get node name lowercase
//             vlthash = vlthash.ToLower();
//             return vlthash;
//         }

//         public static string VirtualItemCommand(string node, string bruh)
//         {
//             string address = " virtualitem " + node;
//             return "";
//         }
//         public static string VisualPartCommand(string node, string parthash, string carhash)
//         {
//             string address = " visualpart " + node;

//             string addnode = vltedCommands[1] + address + "\n";
//             string addfield = vltedCommands[2] + address + " baseCarHashes 1\n";
//             string updateCarIdField = vltedCommands[0] + address + " baseCarHashes 0 " + carhash + "\n";
//             string updatePartId = vltedCommands[0] + address + " visualPartHash " + parthash + "\n";
            
//             return addnode + addfield + updateCarIdField + updatePartId;
//         }

//         public static void CreateVisualPartVirtualitemData(StreamWriter vltedw, string partName, string shortDesc, Construct struc, int i)
//         {
//             string longDesc = "GM_CATALOG_00000000"; //forall
//             string type = "visualpart";             //forall
//             string brand = struc.brand;     //depends on struc
//             int resellPrice = 0;                    //forall
//             int tier = 0;                           //forall
//             string warnOnDelete = "False";          //forall

//             int catalogMultiplier = -1;             //struc depend
//             if(struc is HoodCF) catalogMultiplier = 0;  //struc depend

//             string index = i.ToString(); //dependant on loop counter
//             if(i < 10) index = "0" + index;



//             uint partHash = Hashing.BinHash(partName);      //same
//             string nodeName = GetVltNodeHash(partName);     //same
//             string icon = struc.icon;                       //struc
//             string subtype = struc.subtype;                 //struc
//             string title = "GM_CATALOG_" + struc.catalogs[i + catalogMultiplier]; //struc


//             //same for everything
//             vltedw.WriteLine(vltedCommands[1] + " virtualitem " + nodeName);
//             vltedw.WriteLine(vltedCommands[0] + " virtualitem " + nodeName + " title " + title);
//             vltedw.WriteLine(vltedCommands[0] + " virtualitem " + nodeName + " hash " + partHash);
//             vltedw.WriteLine(vltedCommands[0] + " virtualitem " + nodeName + " icon " + struc.icon);
//             vltedw.WriteLine(vltedCommands[0] + " virtualitem " + nodeName + " itemName " + partName);
//             vltedw.WriteLine(vltedCommands[0] + " virtualitem " + nodeName + " longdescription " + longDesc);
//             vltedw.WriteLine(vltedCommands[0] + " virtualitem " + nodeName + " shortdescription " + shortDesc);
//             vltedw.WriteLine(vltedCommands[0] + " virtualitem " + nodeName + " subType " + struc.subtype);
//             vltedw.WriteLine(vltedCommands[0] + " virtualitem " + nodeName + " type " + type);

//             vltedw.WriteLine(vltedCommands[2] + " virtualitem " + nodeName + " brand");
//             vltedw.WriteLine(vltedCommands[2] + " virtualitem " + nodeName + " resellprice");
//             vltedw.WriteLine(vltedCommands[2] + " virtualitem " + nodeName + " tier");
//             vltedw.WriteLine(vltedCommands[2] + " virtualitem " + nodeName + " warnondelete");

//             vltedw.WriteLine(vltedCommands[0] + " virtualitem " + nodeName + " brand " + brand);
//             vltedw.WriteLine(vltedCommands[0] + " virtualitem " + nodeName + " resellprice " + resellPrice.ToString());
//             vltedw.WriteLine(vltedCommands[0] + " virtualitem " + nodeName + " tier " + tier.ToString());
//             vltedw.WriteLine(vltedCommands[0] + " virtualitem " + nodeName + " warnondelete " + warnOnDelete);
//             //same for everything
//         }




//         public static void CreateNVisualPartVirtualItem(Construct struc, string car, string carcatalog, string filesPath, bool more, bool all)
//         {
//             if(struc.global == true)
//             {
//                 if(struc is SpoilerGlobal || struc is SpoilerGlobalCF)
//                 {            

//                 }
//             }


//             //individual car 
//             string partName = car + struc.firstPartName + index + struc.secondPartName; //depends on global/private
//             //spoiler global/cf
//             string partName = struc.firstPartName + index + AllCars.sizes[j] + struc.secondPartName;
//             //global neon/plate
//             string partName = struc.firstPartName + "STYLE" + index + struc.secondPartName;

//             //individual car
//             string shortDesc = "GM_CATALOG_0000" + carcatalog; //depends on global/private/spoiler
//             //spoiler global/cf
//             string shortDesc = "GM_CATALOG_0000" + AllCars.sizeCatalog[j];
//             //global neon/plate
//             string shortDesc = "GM_CATALOG_0000" + "49F3";

//             int counter = more ? struc.newUpper : struc.upper;

//             int lowCount = all ? struc.lower : struc.upper + 1;


//             if(struc.global == false)
//             {
//                 uint carID = Hashing.BinHash(car);

//                 for(int i = lowCount; i < counter + 1; i++)     //go through every part in Struc
//                 {
//                     StreamWriter vltedw = new StreamWriter(filesPath, true);

//                     //same for everything
//                     CreateVisualPartVirtualitemData(vltedw, partName, shortDesc, struc, i);
//                     //same for everything

//                     //visualpart
//                     vltedw.WriteLine(vltedCommands[1] + " visualpart " + nodeName);
//                     vltedw.WriteLine(vltedCommands[2] + " visualpart " + nodeName + " baseCarHashes 1");
//                     vltedw.WriteLine(vltedCommands[0] + " visualpart " + nodeName + " visualPartHash " + partHash);
//                     vltedw.WriteLine(vltedCommands[0] + " visualpart " + nodeName + " baseCarHashes[0] " + carID);
//                     //different
//                     vltedw.Dispose();
//                 }
//             }
//             else
//             {
//                 if(struc is SpoilerGlobal || struc is SpoilerGlobalCF)
//                 {
//                     for(int j = 0; j < AllCars.sizes.Length; j++)
//                     {
//                         for(int i = lowCount; i < counter + 1; i++)
//                         {
//                             StreamWriter vltedw = new StreamWriter(filesPath, true);
        
        
//                             CreateVisualPartVirtualitemData(vltedw, partName, shortDesc, struc, i);


//                             //visualpart
//                             vltedw.WriteLine(vltedCommands[1] + " visualpart " + nodeName);

//                             vltedw.WriteLine(vltedCommands[2] + " visualpart " + nodeName + " baseCarHashes " + AllCars.sizeArraysNew[j].Length.ToString());
//                             if(i <= struc.upper)
//                             {
//                                 vltedw.WriteLine(vltedCommands[3] + " visualpart " + nodeName + " baseCarHashes 0");
//                                 vltedw.WriteLine(vltedCommands[3] + " visualpart " + nodeName + " baseCarHashes " + AllCars.sizeArraysNew[j].Length.ToString());
//                             }

//                             vltedw.WriteLine(vltedCommands[0] + " visualpart " + nodeName + " visualPartHash " + partHash);
//                             for(int k = 0; k < AllCars.sizeArraysNew[j].Length; k++) 
//                                 vltedw.WriteLine(vltedCommands[0] + " visualpart " + nodeName + " baseCarHashes[" + k.ToString() + "] " + AllCars.sizeArraysNew[j][k]);


//                             vltedw.Dispose();

//                         }
//                     }
//                 }
//                 else if(struc is Neon || struc is LicensePlate)
//                 {

//                     for(int i = lowCount; i < counter + 1; i++)
//                     {


//                         StreamWriter vltedw = new StreamWriter(filesPath, true);

//                         CreateVisualPartVirtualitemData(vltedw, partName, shortDesc, struc, i);

//                         vltedw.WriteLine(vltedCommands[1] + " visualpart " + nodeName);
//                         vltedw.WriteLine(vltedCommands[0] + " visualpart " + nodeName + " visualPartHash " + partHash);

//                         vltedw.WriteLine(vltedCommands[2] + " visualpart " + nodeName + " baseCarHashes " + AllCars.everyCarHash.Length.ToString());

//                         for(int k = 0; k < AllCars.everyCarHash.Length; k++) 
//                             vltedw.WriteLine(vltedCommands[0] + " visualpart " + nodeName + " baseCarHashes[" + k.ToString() + "] " + AllCars.everyCarHash[k]);


//                         vltedw.Dispose();
//                     }
//                 }
//             }
//         }

//         public static void AddVirtualItemParts()
//         {            
//             string vwide = "./results/scripts/vanilla/widebody.nfsms";
//             string vbody = "./results/scripts/vanilla/bodykits.nfsms";
//             string vhood = "./results/scripts/vanilla/hoods.nfsms";
//             string vsplr = "./results/scripts/vanilla/spoilers.nfsms";
//             // string vsfix = "./results/scripts/vanilla/spoilerfix.nfsms";

//             string awide = "./results/scripts/addon/widebody.nfsms";
//             string asplr = "./results/scripts/addon/spoilers.nfsms";
//             string ahood = "./results/scripts/addon/hoods.nfsms";
//             // string agspl = "./results/scripts/addon/globalSpoilers.nfsms";
//             string alpts = "./results/scripts/addon/licenseplates.nfsms";
//             string aneon = "./results/scripts/addon/neons.nfsms";



//             // add for all cars all parts including addons
//             for(int i = 0; i < AllCars.carlist.Length; i++)
//             {
//                 CreateNVisualPartVirtualItem(new Widebody(),  AllCars.carlist[i], AllCars.catalogs[i], vwide, false, true);
//                 CreateNVisualPartVirtualItem(new Bodykit(),   AllCars.carlist[i], AllCars.catalogs[i], vbody, false, true);
//                 CreateNVisualPartVirtualItem(new Ampedbody(), AllCars.carlist[i], AllCars.catalogs[i], vbody, false, true);
//                 CreateNVisualPartVirtualItem(new Hood(),      AllCars.carlist[i], AllCars.catalogs[i], vhood, false, true);
//                 CreateNVisualPartVirtualItem(new HoodCF(),    AllCars.carlist[i], AllCars.catalogs[i], vhood, false, true);
//                 CreateNVisualPartVirtualItem(new Spoiler(),   AllCars.carlist[i], AllCars.catalogs[i], vsplr, false, true);
            

//                 CreateNVisualPartVirtualItem(new Widebody(),  AllCars.carlist[i], AllCars.catalogs[i], awide, true, false);
//                 CreateNVisualPartVirtualItem(new Spoiler(),   AllCars.carlist[i], AllCars.catalogs[i], asplr, true, false);
//                 CreateNVisualPartVirtualItem(new Hood(),      AllCars.carlist[i], AllCars.catalogs[i], ahood, true, false);
//                 CreateNVisualPartVirtualItem(new HoodCF(),    AllCars.carlist[i], AllCars.catalogs[i], ahood, true, false);
//             }

//             //for adding new global spoilers
//             // CreateNVisualPartVirtualItem(new SpoilerGlobal(),   "", "", agspl, true, false);
//             // CreateNVisualPartVirtualItem(new SpoilerGlobalCF(), "", "", agspl, true, false);

//             //for fixing noSpoilers
//             // for(int i = 0; i < AllCars.spoilerNoneNodes.Length; i++)       
//             // {   
//             //     StreamWriter vltedw = new StreamWriter(vsfix, true);
//             //     vltedw.WriteLine(vltedCommands[3] + " visualpart " + AllCars.spoilerNoneNodes[i] + " baseCarHashes 0");
//             //     vltedw.WriteLine(vltedCommands[3] + " visualpart " + AllCars.spoilerNoneNodes[i] + " baseCarHashes " + AllCars.sizeArraysNew[i].Length.ToString());

//             //     for(int k = 0; k < AllCars.sizeArraysNew[i].Length; k++) 
//             //     vltedw.WriteLine(vltedCommands[0] + " visualpart " + AllCars.spoilerNoneNodes[i] + " baseCarHashes[" + k.ToString() + "] " + AllCars.sizeArraysNew[i][k]);

//             //     vltedw.Dispose();
//             // }

//             //for adding neons and plates
//             // CreateNVisualPartVirtualItem(new Neon(), "", "", alpts, false, true);
//             // CreateNVisualPartVirtualItem(new LicensePlate(), "", "", aneon, false, true);


//         }
//     }
// }