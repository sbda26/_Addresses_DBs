using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Addresses_DBs2
{
    public class MainDatabaseClass
    {
        public void InitializeAllDatabases()
        {
			var clsNamesAddresses = new Fill_Address_List_Class();

			clsNamesAddresses.Go();
			InitializeDatabase(clsNamesAddresses.List, new SQL_Database_Class());
			InitializeDatabase(clsNamesAddresses.List, new Mongo_Database_Class());
			InitializeDatabase(clsNamesAddresses.List, new XML_Database_Class());
			InitializeDatabase(clsNamesAddresses.List, new CSV_Database_Class());
			InitializeDatabase(clsNamesAddresses.List, new JSON_Database_Class());
		}

		private void InitializeDatabase(List<PersonAddressClass> list, IDatabase_Core db)
		{
			db.TruncateAndRepopulate(list);
		}
	}
}
