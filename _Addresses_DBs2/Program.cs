using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Addresses_DBs2
{
	class Program
	{
		static void Main(string[] args)
		{
			var mainDB = new MainDatabaseClass();
			mainDB.InitializeAllDatabases();
		}

	}
}
