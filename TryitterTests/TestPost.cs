using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Json;
using TryitterWebAPI.Models;

namespace TryitterTests
{
    public class TestPostsControllers : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _applicationFactory;

        public TestPostsControllers(WebApplicationFactory<Program> applicationFactory)
        {
            _applicationFactory = applicationFactory;
        }
    

        [Fact]
        public async Task GetPostByIdTest_Return_Ok()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync("/api/posts/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreatePostTest_Return_Created()
        {
            var posts = new Post
            {
                Description = "Hello Mundo",
                UrlImage = "www.imagemAleatoria.com.br"
            };

            var client = _applicationFactory.CreateClient();
            using HttpResponseMessage response = await client.PostAsJsonAsync("/api/posts", posts);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task UpdatePostTest_Return_Ok()
        {
            var posts = new Post
            {
                Description = "Hello Mundo",
                UrlImage = "www.imagemAleatoria.com.br"
            };

            var client = _applicationFactory.CreateClient();
            using HttpResponseMessage response = await client.PutAsJsonAsync("/api/post/4", posts);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeletePostTest_Return_NoContent()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.DeleteAsync("/api/posts/2");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}