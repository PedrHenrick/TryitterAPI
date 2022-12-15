using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Json;
using TryitterWebAPI.Models;

namespace TryitterTests
{
    public class TestStudentsControllers : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _applicationFactory;

        public TestStudentsControllers(WebApplicationFactory<Program> applicationFactory)
        {
            _applicationFactory = applicationFactory;
        }

        [Fact]
        public async Task GetAllStudentsTest_Return_Ok()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync("/api/students");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetStudentByIdTest_Return_Ok()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync("/api/students/2");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetStudentsWithPostsTest_Return_Ok()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync("/api/students/posts");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateStudentTest_Return_Created()
        {
            var student = new Student
            {
                Name = "Pedro",
                Email = "pedro@teste.com",
                CurrentModule = "Ciência de dados",
                Status = "Plante um júnios!",
                Password = "password",
            };

            var client = _applicationFactory.CreateClient();
            using HttpResponseMessage response = await client.PostAsJsonAsync("/api/students", student);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task UpdateStudentTest_Return_Ok()
        {
            var student = new Student
            {
                Name = "Pedro",
                Email = "pedro@teste.com",
                CurrentModule = "Ciência de dados",
                Status = "Plante um júnios!",
                Password = "password",
            };

            var client = _applicationFactory.CreateClient();
            using HttpResponseMessage response = await client.PutAsJsonAsync("/api/students/2", student);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteStudentTest_Return_NoContent()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.DeleteAsync("/api/students/3");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}