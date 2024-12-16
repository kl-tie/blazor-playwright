using BlazorPlaywright.Tests.Infra;
using Microsoft.Playwright;

namespace BlazorPlaywright.Tests;

/// <summary>
/// Sample test for /counter page.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.Self)]
internal class CounterPageTest : BlazorTest
{
    private readonly string _url;

    public CounterPageTest()
    {
        _url = RootUri.AbsoluteUri + "counter";
    }

    /// <summary>
    /// Test the counter increment button.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task Count_Increments_WhenButtonIsClicked()
    {
        // Arrange.
        await Page.GotoAsync(_url,
            new()
            {
                WaitUntil = WaitUntilState.NetworkIdle
            });

        // Act.
        await Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync();

        // Assert.
        await Expect(Page.GetByRole(AriaRole.Status)).ToHaveTextAsync("Current count: 1");
    }

    [Test]
    public async Task DisplayCurrentCount_AfterNavigateFromHome()
    {
        // Arrange.
        await Page.GotoAsync(RootUri.AbsoluteUri,
            new()
            {
                WaitUntil = WaitUntilState.NetworkIdle
            });

        // Act.
        await Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();

        // Assert.
        await Expect(Page.GetByRole(AriaRole.Status)).ToHaveTextAsync("Current count: 0");
    }
}
