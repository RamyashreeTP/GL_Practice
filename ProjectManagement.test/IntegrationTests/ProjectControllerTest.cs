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
    public class ProjectControllerTest : IClassFixture<ApiAppFactory>
	{
		private readonly WebApplicationFactory<Startup> factory;
		public ProjectControllerTest(ApiAppFactory factory)
		{
			this.factory = factory;
		}
		[Fact]
		public async Task GetAllProjects_Test()
		{
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.GetAsync("api/v1/projects/getAllProjects");
			/* Assert */
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			var readers = JsonConvert.DeserializeObject<List<ProjectData>>(content);
			Assert.True(readers.Count > 0);
		}
		[Fact]
		public async Task GetProject_Test()
		{
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.GetAsync("api/v1/projects/getTask/1001");
			/* Assert */
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			var readers = JsonConvert.DeserializeObject<ProjectData>(content);
			Assert.NotNull(readers.projectName);
		}
		[Fact]
		public async Task createProject_Test()
		{
			var data = new ProjectData() { projectId = 1007, projectName = "projectName", projectDetail = "projectDetail", createdOn = new DateTime() };
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.PostAsync("api/v1/projects/createProject", JsonContent.Create(data));
			/* Assert */
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			var readers = JsonConvert.DeserializeObject<ProjectData>(content);
			Assert.NotNull(readers.projectName);
		}
		[Fact]
		public async Task deleteProject_Test()
		{
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.DeleteAsync("api/v1/projects/deleteProject/1009");
			/* Assert */
			var content = response.StatusCode;
			Assert.Equal("BadRequest", content.ToString());
		}
		[Fact]
		public async Task updateProject_Test()
		{
			var jsonString = "{\"projectId\":1002,\"projectName\":\"projectName\",\"projectDetail\":\"projectDetail\",\"createdOn\":\"12:12:21\"}";
			var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
			/* Arrange  */
			var client = factory.CreateClient();
			/* Act */
			var response = await client.PutAsync("api/v1/projects/updateProject", httpContent);
			/* Assert */
			response.EnsureSuccessStatusCode();
			var content = response.StatusCode;
			Assert.Equal("OK", content.ToString());
		}
	}
}
