using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Projectmanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagement.test.IntegrationTests
{
    public class LoginControllerTest : IClassFixture<ApiAppFactory>
    {
        private readonly WebApplicationFactory<Startup> factory;
        public LoginControllerTest(ApiAppFactory factory)
        {
            this.factory = factory;
        }
        [Fact]
        public async Task ValidateUsers_Test()
        {
            /* Arrange  */
            var client = factory.CreateClient();
            /* Act */
            var response = await client.GetAsync("api/v1/Authentication/login");
            /* Assert */
            response.EnsureSuccessStatusCode();
            var content = response.StatusCode;
            Assert.Equal("BadRequest", content.ToString());
        }
        [Fact]
        public async Task addUser_Test()
        {
            /* Arrange  */
            var client = factory.CreateClient();
            /* Act */
            var response = await client.GetAsync("api/v1/Authentication/addUser");
            /* Assert */
            response.EnsureSuccessStatusCode();
            var content = response.StatusCode;
            Assert.Equal("BadRequest", content.ToString());
        }
    }
}
