using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Addresses_DBs2
{
    internal interface IDatabase_Core
    {
        void TruncateAndRepopulate(List<PersonAddressClass> personsAddresses);
        void TruncateContainer();
        void RepopulateData(List<PersonAddressClass> personsAddresses);
    }
}
