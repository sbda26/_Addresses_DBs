using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Addresses_DBs2.Properties;

namespace _Addresses_DBs2
{
	internal class SQL_Database_Class : IDatabase_Core
	{
		private NamesAddressesEntities_SQL _context = new NamesAddressesEntities_SQL();

		public void TruncateAndRepopulate(List<PersonAddressClass> personsAddresses)
		{
			TruncateContainer();
			RepopulateData(personsAddresses);
		}

		public void TruncateContainer()
		{
			_context.TruncateNamesAddresses();
		}

		public void RepopulateData(List<PersonAddressClass> personsAddresses)
		{
			foreach (PersonAddressClass p in personsAddresses)
				_context.InsertNameAddress(p.FirstName, p.LastName,
										   p.DwellingNumber, p.Apartment, p.StreetName, p.StreetType,
										   p.Town, p.State, p.Zip);
		}




		/*
		
		private SqlConnection _sqlconn = new SqlConnection(Settings.Default.NamesAddresses_SQLDB_ConnectionString);

		public void Go(ref List<PersonAddressClass> personsAddresses)
		{
			_sqlconn.Open();
			TruncateContainer();
			RepopulateData(ref personsAddresses);
			_sqlconn.Close();
		}
		
		public void TruncateContainer()
		{
			const string csSQL = "TRUNCATE TABLE NamesAddresses";

			using (SqlCommand sqlcmd = Init_SqlCommand_CommandText(csSQL))
				sqlcmd.ExecuteNonQuery();
		}

		public void RepopulateData(ref List<PersonAddressClass> personsAddresses)
		{
			foreach(PersonAddressClass person in personsAddresses)
			{
				SqlParameter[] parameters = PersonParameters(person);
				using (SqlCommand sqlcmd = Init_SqlCommand_StoredProc("InsertNameAddress", parameters))
					sqlcmd.ExecuteNonQuery();
			}	
		}
		
		// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

		private SqlParameter[] PersonParameters(PersonAddressClass person)
		{
			var parameters = new SqlParameter[]
			{
				new SqlParameter("@firstName", person.FirstName),
				new SqlParameter("@lastName", person.LastName),
				new SqlParameter("@dwellingNumber", person.DwellingNumber),
				new SqlParameter("@apartment", person.Apartment),
				new SqlParameter("@streetName", person.StreetName),
				new SqlParameter("@streetType", person.StreetType),
				new SqlParameter("@town", person.Town),
				new SqlParameter("@state", person.State),
				new SqlParameter("@zip", person.Zip)
			};

			return parameters;
		}


		private SqlCommand Init_SqlCommand_CommandText(string commandText)
		{
			return SqlCmd_Common_Parameters(commandText, CommandType.Text);
		}

		private SqlCommand Init_SqlCommand_StoredProc(string storedProc, params SqlParameter[] parameters)
		{
			SqlCommand sqlcmd = SqlCmd_Common_Parameters(storedProc, CommandType.StoredProcedure);

			sqlcmd.Parameters.AddRange(parameters);
			return sqlcmd;
		}

		private SqlCommand SqlCmd_Common_Parameters(string sql, CommandType commandType)
		{
			return new SqlCommand { CommandText = sql, CommandTimeout = 0, CommandType = commandType, Connection = _sqlconn };
		}

	*/
	}
}
