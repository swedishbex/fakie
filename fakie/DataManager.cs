using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace fakie
{
	static public class DataManager
	{
		static JObject regionsData = null;
		static JObject parksData = null;

		static public async Task<Object> GetAllData()
		{
			regionsData = await firebaseAPI.doGet("regions", "", "");
			parksData = await firebaseAPI.doGet("parks", "", "");
			return null;
		}

		static public async Task<JObject> GetRegions()
		{
			if (regionsData == null)
			{
				await GetAllData();
			}

			return regionsData;
		}

		static public async Task<JObject> GetParks()
		{
			if (parksData == null)
			{
				await GetAllData();
			}

			return parksData;
		}

		static public async Task<JObject> GetPark(string name)
		{
			var parks = await GetParks();
			JObject dataForPark = null;

			foreach (var park in parks)
			{
				if (park.Key.ToUpper() == name.ToUpper())
				{
					dataForPark = (JObject)park.Value;
					break;
				}
			}

			return dataForPark;
		}
	}
}
