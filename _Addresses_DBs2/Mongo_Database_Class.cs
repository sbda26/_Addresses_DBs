using _Addresses_DBs2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace _Addresses_DBs2
{
	internal class Mongo_Database_Class : IDatabase_Core
	{
		public IMongoDatabase _database;

		public void TruncateAndRepopulate(List<PersonAddressClass> personsAddresses)
		{
			Open_Database();
			TruncateContainer();
			RepopulateData(personsAddresses);
		}

		public void RepopulateData(List<PersonAddressClass> personsAddresses)
		{
			IMongoCollection<PersonAddressClass> collection = GetCollection();
			collection.InsertMany(personsAddresses);
		}

		public void TruncateContainer()
		{
			_database.DropCollection(Settings.Default.NamesAddresses_MongoDB_CollectionName);
		}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

		private void Open_Database()
		{
			var client = new MongoClient(Settings.Default.NamesAddresses_MongoDB_ConnectionString);
			_database = client.GetDatabase(Settings.Default.NamesAddresses_MongoDB_DatabaseName);
		}

		private IMongoCollection<PersonAddressClass> GetCollection()
		{
			return _database.GetCollection<PersonAddressClass>(Settings.Default.NamesAddresses_MongoDB_CollectionName);
		}

	}
}
