using Gaz.Domain.Entities;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;

namespace Gaz.Service
{
    public class ServerConnection
	{
		private const string URL = "https://192.168.42.100:7103";
		static HttpClient client = new HttpClient();
		private static string Token;

		#region Auth
		public static async Task<User> Login(string email, string password)
		{
			User user = null;
			var request = new HttpRequestMessage(HttpMethod.Post, URL +  "/api/Authenticate/Login?email=" + email + "&password=" + password);
			Token = await request.Content.ReadAsStringAsync();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			if (response.IsSuccessStatusCode)
			{
				var req = new HttpRequestMessage(HttpMethod.Get, URL + "/api/Users/GetUserEmail/" + email);
				string json = await response.Content.ReadAsStringAsync();
				user = JsonConvert.DeserializeObject<User>(json);
			}
			else
			{
				throw new Exception("Unauthorized");
			}
			return user;
		}
		#endregion
	}
}
