using _Addresses_DBs2.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _Addresses_DBs2
{
    internal class CSV_Database_Class : IDatabase_Core
    {
        public void TruncateAndRepopulate(List<PersonAddressClass> personsAddresses)
        {
            TruncateContainer();
            RepopulateData(personsAddresses);
        }

        public void RepopulateData(List<PersonAddressClass> personsAddresses)
        {
            using (var csvWriter = new StreamWriter(Settings.Default.NamesAddresses_CsvDB_File, false, Encoding.ASCII))
            {
                WriteHeaderLine(csvWriter);
                foreach (PersonAddressClass pac in personsAddresses)
                    WriteDataLine(csvWriter, pac);
                csvWriter.Flush();
                csvWriter.Close();
            }
        }

        public void TruncateContainer()
        {
            GLOBALS_Class.DeleteOldFileDB(Settings.Default.NamesAddresses_CsvDB_File);
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void WriteHeaderLine(StreamWriter csvWriter)
        {
            FieldInfo[] fields = GLOBALS_Class.PersonAddressFields();
            int limit = fields.GetUpperBound(0);

            for (int index = 0; index <= limit; index++)
            {
                if (index < limit)
                {
                    csvWriter.Write(fields[index].Name);
                    csvWriter.Write(",");
                }
                else
                    csvWriter.WriteLine(fields[index].Name);
            }
        }

        private void WriteDataLine(StreamWriter csvWriter, PersonAddressClass pac)
        {
            string[] values = GLOBALS_Class.Values(pac);
            int limit = values.GetUpperBound(0);

            for(int index = 0; index <= limit; index++)
            {
                if (index < limit)
                {
                    csvWriter.Write(values[index]);
                    csvWriter.Write(",");
                }
                else
                    csvWriter.WriteLine(values[index]);
            }
        }
    }
}
