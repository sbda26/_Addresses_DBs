using System;
using System.Collections.Generic;
using System.IO;

namespace _Addresses_DBs2
{
	internal class Fill_Address_List_Class
	{
		private const int _ciLimit = 1000;
		private Random _clsRandom = new Random();
		public List<PersonAddressClass> List = new List<PersonAddressClass>();

		public void Go()
		{
			string[] arr_sFirstNames = ReadFile("FirstNames.txt");
			string[] arr_sLastNames = ReadFile("LastNames.txt");
			string[] arr_sDwellingNumbers = Fill_DwellingNumbers();
			string[] arr_sApartments = Fill_Apartments_Array();
			string[] arr_sStreetNames = ReadFile("StreetNames.txt");
			string[] arr_sStreetTypes = Fill_StreetTypes_Array();
			string[] arr_sTowns = ReadFile("Towns.txt");
			string[] arr_sStates = Fill_States_Array();
			string[] arr_sZIPs = Fill_ZIPs_Array();

			for(int iIndex = 0; iIndex < _ciLimit; iIndex++)
			{
				var clsPerson = new PersonAddressClass();

				clsPerson.FirstName = arr_sFirstNames[iIndex];
				clsPerson.LastName = arr_sLastNames[iIndex];
				clsPerson.DwellingNumber = arr_sDwellingNumbers[iIndex];
				clsPerson.Apartment = arr_sApartments[iIndex];
				clsPerson.StreetName = arr_sStreetNames[iIndex];
				clsPerson.StreetType = arr_sStreetTypes[iIndex];
				clsPerson.Town = arr_sTowns[iIndex];
				clsPerson.State = arr_sStates[iIndex];
				clsPerson.Zip = arr_sZIPs[iIndex];
				List.Add(clsPerson);
			}
		}

		private string[] Fill_DwellingNumbers()
		{
			var lst = new List<string>();

			for (int iIndex = 0; iIndex < _ciLimit; iIndex++)
			{
				int iDwelling_Number = _clsRandom.Next(1, 9999);
				lst.Add(iDwelling_Number.ToString());
			}

			return lst.ToArray();
		}

		private string[] Fill_Apartments_Array()
		{
			var lst = new List<string>();

			for (int iIndex = 0; iIndex < _ciLimit; iIndex++)
			{
				int iRandom_Choice = _clsRandom.Next(3);
				string sValue = null;
				switch (iRandom_Choice)
				{
					case 0:
						break;  // leave as null
					case 1: // letter
						{
							int iLetter = _clsRandom.Next(65, 91);  // 'A' -> 'Z'
							char chLetter = (char)iLetter;
							sValue = chLetter.ToString();
						}
						break;
					case 2: // number
						{
							int iNumber = _clsRandom.Next(1, 10);
							sValue = iNumber.ToString();
						}
						break;
				}
				lst.Add(sValue);
			}

			return lst.ToArray();
		}
		
		private string[] Fill_StreetTypes_Array()
		{
			string[] arr_sStreetTypes = ReadFile("StreetTypes.txt");
			int iLength = arr_sStreetTypes.Length;
			var lst = new List<string>();

			for (int iIndex = 0; iIndex < _ciLimit; iIndex++)
			{
				int iRandomType = _clsRandom.Next(0, iLength);
				lst.Add(arr_sStreetTypes[iRandomType]);
			}

			return lst.ToArray();
		}

		private string[] Fill_States_Array()
		{
			string[] arr_sStates = ReadFile("States.txt");
			int iLength = arr_sStates.GetUpperBound(0);
			var lst = new List<string>();

			for (int iIndex = 0; iIndex < _ciLimit; iIndex++)
			{
				int iRandomState = _clsRandom.Next(0, iLength);
				lst.Add(arr_sStates[iRandomState]);
			}

			return lst.ToArray();
		}

		private string[] Fill_ZIPs_Array()
		{
			var lst = new List<string>();

			for (int iIndex = 0; iIndex < _ciLimit; iIndex++)
			{
				int iZIP = _clsRandom.Next(1001, 99999);
				lst.Add(iZIP.ToString("D5"));
			}

			return lst.ToArray();
		}

		private string[] ReadFile(string path)
		{
			return File.ReadAllLines("Lists\\" + path);
		}
	}
}
