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
    public static class LabrSrch {
        public static string[] manufact = {
            "NISSAN",
            "CHRYSLER",
            "PORSCHE",
            "ALFA ROMEO",
            "ASTON MARTIN",
            "AUDI",
            "BENTLEY",
            "BMW",
            "BUGATTI",
            "CADILLAC",
            "CATERHAM",
            "CHEVROLET",
            "DODGE",
            "FORD",
            "HUMMER",
            "INFINITI",
            "JAGUAR",
            "KOENIGSEGG",
            "LAMBORGHINI",
            "LANCIA",
            "LEXUS",
            "LOTUS",
            "MARUSSIA",
            "MAZDA",
            "MCLAREN",
            "MERCEDES-BENZ",
            "MERCEDES BENZ",
            "MITSUBISHI",
            "PAGANI",
            "PLYMOUTH",
            "PONTIAC",
            "RENAULT",
            "SCION",
            "SHELBY",
            "SUBARU",
            "TOYOTA",
            "VOLKSWAGEN"
        };


        public static string[] filters = {
            "UPGRADE",
            "JUGGER",
            "PACKAGE",
            "RENTAL",
            "TREASURE",
            "EASTER",
            "BEAUTY",
            "BEAST",
            "\"",
            "BLUE",
            "SILVER",
            "RED",
            "PURPLE",
            "WHITE",
            "GREEN",
            "BLACK",
            "YELLOW",
            "rental",
            "Rental",
            "reasure",
            "TEST",
            "ORANGE",
            "GREY",
            "MAROON",
            "!",
            ",",
            ".",
            "Slot",
            "LOGO",
            "VINYL",
            "COLLECTOR",
            "ESCAPE",
            "AFTERMARKET",
            "Pack",
            "EXTENDED"
        };
        public static void SearchAndPrint() {
 

            string filename = "data/labruh.txt";

            string theText = File.ReadAllText(filename);  

            string[] lines = theText.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );

            string[] results = Array.FindAll(lines, c => manufact.Any(c.Contains) && c.Contains("CATALOG") && !filters.Any(c.Contains));

            File.WriteAllLines("results/labLEL.txt", results);
        }
    }
}