using _Addresses_DBs2.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Addresses_DBs2
{
    internal class JSON_Database_Class : IDatabase_Core
    {
        public void TruncateAndRepopulate(List<PersonAddressClass> personsAddresses)
        {
            TruncateContainer();
            RepopulateData(personsAddresses);
        }

        public void RepopulateData(List<PersonAddressClass> personsAddresses)
        {
            string json = JsonConvert.SerializeObject(personsAddresses, Formatting.Indented);
            File.WriteAllText(Settings.Default.NamesAddresses_JsonDB_File, json);
        }

        public void TruncateContainer()
        {
            GLOBALS_Class.DeleteOldFileDB(Settings.Default.NamesAddresses_JsonDB_File);
        }
    }
}
