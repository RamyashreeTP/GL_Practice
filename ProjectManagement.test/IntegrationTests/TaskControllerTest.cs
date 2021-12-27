using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Projectmanagement;
using Projectmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagement.test.IntegrationTests
{
    public class TaskControllerTest: IClassFixture<ApiAppFactory>
	{
		private readonly WebApplicationFactory<Startup> factory;
		public TaskControllerTest(ApiAppFactory factory)
		{
			this.factory = factory;
		}
		[Fact]
		public async Task GetAllTasks_Test()
		{
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.GetAsync("api/v1/tasks/getAllTasks");
			/* Assert */
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			var readers = JsonConvert.DeserializeObject<List<TaskData>>(content);
			Assert.True(readers.Count > 0);
		}
		[Fact]
		public async Task GetTask_Test()
		{
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.GetAsync("api/v1/tasks/getTask/501");
			/* Assert */
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			var readers = JsonConvert.DeserializeObject<TaskData>(content);
			Assert.NotNull(readers.detail);
		}
		[Fact]
		public async Task createTask_Test()
		{
			var data = new TaskData() { taskId = 501, projectId = 1000, status = 1, userId = 101, detail = "task detail 1", createdOn = new DateTime() };
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.PostAsync("api/v1/tasks/createTask", JsonContent.Create(data));
			/* Assert */
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			var readers = JsonConvert.DeserializeObject<TaskData>(content);
			Assert.NotNull(readers.detail);
		}
		[Fact]
		public async Task deleteUser_Test()
		{
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.DeleteAsync("api/v1/tasks/deleteTask/506");
			/* Assert */
			var content = response.StatusCode;
			Assert.Equal("BadRequest", content.ToString());
		}
		[Fact]
		public async Task updateTask_Test()
		{
			var jsonString = "{\"taskId\":504,\"projectId\":1000,\"status\":1,\"userId\":101,\"detail\":\"task detail 1\",\"createdOn\":\"12:12:21\"}";
			var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.PutAsync("api/v1/tasks/updateTask", httpContent);
			/* Assert */
			response.EnsureSuccessStatusCode();
			var content = response.StatusCode;
			Assert.Equal("OK", content.ToString());
		}
	}
}
