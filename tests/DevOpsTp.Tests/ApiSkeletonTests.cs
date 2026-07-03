using System.Net;
using System.Text.Json;
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
    public async Task StatusEndpoint_ReturnsOperationalStatus()
    {
        var response = await _client.GetAsync("/status");
        var body = await response.Content.ReadAsStringAsync();
        using var json = JsonDocument.Parse(body);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("operational", json.RootElement.GetProperty("status").GetString());
        Assert.True(json.RootElement.GetProperty("uptimeSeconds").GetDouble() >= 0);
        Assert.True(json.RootElement.GetProperty("checks").GetArrayLength() >= 3);
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
