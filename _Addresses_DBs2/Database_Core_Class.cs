using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Addresses_DBs2
{
	public abstract class Database_Core_Class
	{
		public abstract void Go(ref List<PersonAddressClass> personsAddresses);
		protected abstract void TruncateContainer();
		protected abstract void RepopulateData(ref List<PersonAddressClass> personsAddresses);
	}
}
