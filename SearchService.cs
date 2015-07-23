using System;
using System.Net;
using System.IO;
using System.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Text;

namespace SearchGoogleApp
{
	public class SearchService
	{
		private string _strSearch="";
		public SearchService (string strSearch)
		{
			this._strSearch = strSearch;
		}

		public string SearchApi()
		{
			bool blnResult = false;
			string result = "";

			try
			{
				string url1 =	"https://www.googleapis.com/customsearch/v1?cx=014810962483295373468%3Af4jzxsnod9a&q=" + _strSearch + "&key=AIzaSyDA11g5KttXDT4s49B_3xnX55WOHal6q68";
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(url1);
				httpWebRequest.Method = "GET";
				var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					var responseText = streamReader.ReadToEnd();
					Console.WriteLine(responseText);

					JObject obj = JObject.Parse (responseText);
					StringBuilder builder = new StringBuilder();
					foreach (var kvp in obj)
					{
						if(kvp.Key == "items")
						{
							result = (string)kvp.Value[0]["title"];
							break;
						}
					}

				}
				if (httpResponse.StatusCode != HttpStatusCode.OK)
					blnResult = false;
				else
					blnResult = true;


			}
			catch(Exception ex) {
				Console.WriteLine (ex.Message);
			}
			return result;
		}


	}
}

