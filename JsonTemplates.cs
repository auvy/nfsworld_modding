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
    public class Templates
    {
        public JObject mainTemplate = JObject.Parse(@"
        {
            'Name': '',
            'Attributes': []
        }");
        public JObject template1 = JObject.Parse(@"
        {
            'Name': '',
            'Strings': []
        }");
        public JObject lodPrefixSelector = JObject.Parse(@"        
        {
          'Name': 'LOD_NAME_PREFIX_SELECTOR',
          'Value': 0,
          'Strings': []
        }");
        public JObject lodCharacterOffset = JObject.Parse(@"        
        {
          'Name': 'LOD_CHARACTERS_OFFSET',
          'Strings': [
            'ABCDE'
          ]
        }");
        public JObject maxLod = JObject.Parse(@"        
        {
          'Name': 'MAX_LOD',
          'Value': 4,
          'Strings': []
        }");

        public JObject lodCharacterOffset2 = JObject.Parse(@"        
        {
          'Name': 'LOD_CHARACTERS_OFFSET',
          'Strings': [
            'ABCD '
          ]
        }");

        public JObject stockFalse = JObject.Parse(@"        
        {
          'Name': 'STOCK',
          'Value': false,
          'Strings': []
        }");
    
        public JObject useMarker = JObject.Parse(@"        
        {
          'Name': 'USEMARKER1',
          'Value': 1,
          'Strings': []
        }");

    }
}