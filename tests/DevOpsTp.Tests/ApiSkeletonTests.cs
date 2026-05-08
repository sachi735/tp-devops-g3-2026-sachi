using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace DevOpsTp.Tests;

public class ApiSkeletonTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiSkeletonTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task RootEndpoint_ReturnsOk()
    {
        var response = await _client.GetAsync("/");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task HealthEndpoint_ReturnsOk()
    {
        var response = await _client.GetAsync("/health");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task ReadyEndpoint_ReturnsOk()
    {
        var response = await _client.GetAsync("/ready");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task VersionEndpoint_ReturnsOk()
    {
        var response = await _client.GetAsync("/version");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task PingEndpoint_ReturnsOk()
    {
        var response = await _client.GetAsync("/diagnostics/ping");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task ErrorEndpoint_ReturnsInternalServerError()
    {
        var response = await _client.GetAsync("/diagnostics/error");

        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async Task SlowEndpoint_ReturnsOk()
    {
        var response = await _client.GetAsync("/diagnostics/slow");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
