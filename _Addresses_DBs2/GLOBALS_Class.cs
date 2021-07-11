using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace _Addresses_DBs2
{
    public class GLOBALS_Class
    {
        public static void DeleteOldFileDB(string filename)
        {
            var fiXML = new FileInfo(filename);

            if (fiXML.Exists == true)
                fiXML.Delete();

            if (fiXML.Directory.Exists == false)
                fiXML.Directory.Create();
        }

        public static FieldInfo[] PersonAddressFields()
        {
            Type t = typeof(PersonAddressClass);
            FieldInfo[] fields = t.GetFields();

            return fields;
        }

        public static string[] Values(PersonAddressClass pac)
        {
            Type t = pac.GetType();
            FieldInfo[] fields = t.GetFields();
            var values = new List<string>();

            foreach(FieldInfo fi in fields)
            {
                object oValue = fi.GetValue(pac);
                string sValue = (oValue != null) ? oValue.ToString() : string.Empty;
                values.Add(sValue);
            }

            return values.ToArray();
        }

    }
}
