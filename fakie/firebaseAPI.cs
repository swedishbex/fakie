using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace fakie
{
	static public class firebaseAPI
	{
		static string projectName = "fakie-12555";
		static string apiKey = "AIzaSyADI40IUt_bKRh_cvoh5AkllmMEYSfXJZc";


		/*		Kommande:
		 * 		orderBy
		 * 		limitToFirst, limitToLast, startAt, endAt, equalTo
		 * 
		 */

		static string getToken()
		{
			if (App.Current.Properties.ContainsKey("authToken"))
			{
				return App.Current.Properties["authToken"] as string;
			}

			return "";
		}

		static public string getUID()
		{
			if (App.Current.Properties.ContainsKey("authUID"))
			{
				return App.Current.Properties["authUID"] as string;
			}

			return "";
		}


		static public async Task<JObject> doPut(Dictionary<string, string> data, string path)
		{ 
			var httpClientRequest = new HttpClient();

			var jsonRequest = JsonConvert.SerializeObject(data);

			HttpContent content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

			string authString = "";
			if (getToken() != "")
			{
				authString = "?auth=" + getToken();
			}

			var result = await httpClientRequest.PutAsync("https://"+projectName+".firebaseio.com/"+path+".json"+authString, content);

			var resultString = await result.Content.ReadAsStringAsync();

			var jsonResult = JObject.Parse(resultString);

			return jsonResult;
		}

		static public async Task<JObject> doPost(Dictionary<string, string> data, string path)
		{
			var httpClientRequest = new HttpClient();

			var jsonRequest = JsonConvert.SerializeObject(data);

			HttpContent content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

			string authString = "";
			if (getToken() != "")
			{
				authString = "?auth=" + getToken();
			}

			var result = await httpClientRequest.PostAsync("https://" + projectName + ".firebaseio.com/" + path + ".json" + authString, content);

			var resultString = await result.Content.ReadAsStringAsync();

			var jsonResult = JObject.Parse(resultString);

			return jsonResult;
		}


		static public async Task<JObject> doGet(string path, string orderBy, string equalTo)
		{
			var httpClientRequest = new HttpClient();

			string authString = "";
			if (getToken() != "")
			{
				authString = "&auth="+getToken();
			}

			string orderString = "";
			if (orderBy != "")
			{
				orderString = "&orderBy=\""+orderBy+"\"";
				if (equalTo != "")
				{
					orderString = orderString + "&equalTo=\""+equalTo+"\"";
				}
			}
			//?orderBy="category"&equalTo="Frukt"
			System.Diagnostics.Debug.WriteLine("https://" + projectName + ".firebaseio.com/" + path + ".json?a=a" + authString + orderString);
			var result = await httpClientRequest.GetAsync("https://" + projectName + ".firebaseio.com/" + path + ".json?a=a" + authString+orderString);

			var resultString = await result.Content.ReadAsStringAsync();

			var jsonResult = JObject.Parse(resultString);

			return jsonResult;
		}

		static public async Task<JObject> doDelete(string path)
		{
			var httpClientRequest = new HttpClient();

			string authString = "";
			if (getToken() != "")
			{
				authString = "?auth=" + getToken();
			}

			var result = await httpClientRequest.DeleteAsync("https://" + projectName + ".firebaseio.com/" + path + ".json" + authString);

			var resultString = await result.Content.ReadAsStringAsync();

			var jsonResult = JObject.Parse(resultString);

			return jsonResult;
		}


		static public async Task<JObject> doRegister(string email, string password)
		{
			var httpClientRequest = new HttpClient();

			var postData = new Dictionary<string, string>();
			postData.Add("email", email);
			postData.Add("password", password);
			postData.Add("returnSecureToken", "true");

			var jsonRequest = JsonConvert.SerializeObject(postData);

			HttpContent content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

			var result = await httpClientRequest.PostAsync("https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key="+apiKey, content);

			var resultString = await result.Content.ReadAsStringAsync();

			var jsonResult = JObject.Parse(resultString);

			if (jsonResult["idToken"] != null)
			{
				string authToken = (string)jsonResult["idToken"];
				string authUID = (string)jsonResult["localId"];

				App.Current.Properties.Add("authToken", authToken);
				App.Current.Properties.Add("authUID", authUID);
				App.Current.SavePropertiesAsync();
			}

			return jsonResult;
		}

		static public async Task<JObject> doLogin(string email, string password)
		{
			var httpClientRequest = new HttpClient();

			var postData = new Dictionary<string, string>();
			postData.Add("email", email);
			postData.Add("password", password);
			postData.Add("returnSecureToken", "true");

			var jsonRequest = JsonConvert.SerializeObject(postData);

			HttpContent content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

			var result = await httpClientRequest.PostAsync("https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=" + apiKey, content);

			var resultString = await result.Content.ReadAsStringAsync();

			var jsonResult = JObject.Parse(resultString);

			System.Diagnostics.Debug.WriteLine(resultString);

			if (jsonResult["idToken"] != null)
			{
				string authToken = (string)jsonResult["idToken"];
				string authUID = (string)jsonResult["localId"];

				App.Current.Properties.Add("authToken", authToken);
				App.Current.Properties.Add("authUID", authUID);
				App.Current.SavePropertiesAsync();
			}

			return jsonResult;
		}



	}
}
