using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Projectmanagement;
using Projectmanagement.Models;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagement.test
{
    public class UserControllerTest: IClassFixture<ApiAppFactory>
    {
        private readonly WebApplicationFactory<Startup> factory;
        public UserControllerTest(ApiAppFactory factory)
        {
            this.factory = factory;
        }
		[Fact]
		public async Task GetAllUsers_Test()
		{
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.GetAsync("api/v1/users/getAllUsers");
			/* Assert */
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			var readers = JsonConvert.DeserializeObject<List<UserData>>(content);
			Assert.True(readers.Count > 0);
		}
		[Fact]
		public async Task GetUser_Test()
		{
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.GetAsync("api/v1/users/getUser/101");
			/* Assert */
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			var readers = JsonConvert.DeserializeObject<UserData>(content);
			Assert.NotNull(readers.FirstName);
		}
		[Fact]
		public async Task createUser_Test()
		{
			var data = new UserData
			{
				UserId = 106,
				FirstName = "Vimal",
				LastName = "Kashyap",
				Email = "vimal.K@gmail.com",
				Password = "vimal321"
			};		
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.PostAsync("api/v1/users/createUser", JsonContent.Create(data));
			/* Assert */
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			var readers = JsonConvert.DeserializeObject<UserData>(content);
			Assert.NotNull(readers.FirstName);
		}
		[Fact]
		public async Task deleteUser_Test()
		{
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.DeleteAsync("api/v1/users/deleteUser/101");
			var content = response.StatusCode;			
			Assert.Equal("BadRequest", content.ToString());
		}
		[Fact]
		public async Task updateUser_Test()
		{ 
			var jsonString = "{\"UserId\":101,\"FirstName\":\"Vimal\",\"LastName\":\"Kashyap\",\"Email\":\"vimal.K@gmail.com\",\"Password\":\"vimal321\"}";
			var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.PutAsync("api/v1/users/updateUser", httpContent);
			/* Assert */
			response.EnsureSuccessStatusCode();
			var content = response.StatusCode;
			Assert.Equal("OK",content.ToString());
		}
	}
}

