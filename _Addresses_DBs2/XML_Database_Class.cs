using _Addresses_DBs2.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _Addresses_DBs2
{
    internal class XML_Database_Class : IDatabase_Core
    {
        public void TruncateAndRepopulate(List<PersonAddressClass> personsAddresses)
        {
            TruncateContainer();
            RepopulateData(personsAddresses);
        }

        public void RepopulateData(List<PersonAddressClass> personsAddresses)
        {
            FieldInfo[] fields = GLOBALS_Class.PersonAddressFields();

            using (var xmlWriter = new XmlTextWriter(Settings.Default.NamesAddresses_XmlDB_File, Encoding.ASCII))
            {
                int index = 1;
                InitAndStartFile(xmlWriter);
                foreach(PersonAddressClass pac in personsAddresses)
                {
                    xmlWriter.WriteStartElement("person");
                    WriteElementFull(xmlWriter, "id", index);
                    foreach(FieldInfo field in fields)
                    {
                        object value = field.GetValue(pac);
                        WriteElementFull(xmlWriter, field.Name, value);
                    }
                    xmlWriter.WriteEndElement();
                    index++;
                }
                FinishAndCloseFile(xmlWriter);
            }
        }

        public void TruncateContainer()
        {
            GLOBALS_Class.DeleteOldFileDB(Settings.Default.NamesAddresses_XmlDB_File);
        }

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void InitAndStartFile(XmlTextWriter xmlWriter)
        {
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.Indentation = 4;
            xmlWriter.WriteStartDocument(true);
            xmlWriter.WriteStartElement("list");
        }

        private void WriteElementFull(XmlTextWriter xmlWriter, string elementName, object value)
        {
            xmlWriter.WriteStartElement(elementName);
            
            if(value != null)
                xmlWriter.WriteValue(value);

            xmlWriter.WriteEndElement();
        }

        private void FinishAndCloseFile(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }
    }
}
