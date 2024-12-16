namespace BlazorPlaywright.Tests.Infra;

/// <summary>
/// Base Blazor <seealso cref="PageTest"/> class for Blazor web page E2E testing setups.
/// </summary>
internal class BlazorTest : PageTest
{
    private readonly CustomWebApplicationFactory _webApplicationFactory;

    protected Uri RootUri { get; private set; }

    public BlazorTest()
    {
        _webApplicationFactory = new();
        // This will trigger the "proper" web host creation.
        _ = _webApplicationFactory.CreateClient();

        RootUri = _webApplicationFactory.ClientOptions.BaseAddress;
    }

    [OneTimeTearDown]
    public void TearDownBlazorWeb()
    {
        _webApplicationFactory.Dispose();
    }
}
