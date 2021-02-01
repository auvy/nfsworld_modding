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

namespace prog {
    public static class LabruneOps
    {
        public static string GenerateLabrune(string text, string catalog)
        {
            string catalogName = "GM_CATALOG_" + catalog;
            string hash = Hashing.HexHash(Hashing.BinHash(catalogName));
            return "0	" + hash + "	" + catalogName + "	" + text;
        }

    }
}