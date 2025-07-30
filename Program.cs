using Microsoft.Playwright;
using System.Threading.Tasks;

class Program
{
    public static async Task Main()
    {
        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        // Login
        await page.GotoAsync("https://demo.snipeitapp.com/login");
        await page.FillAsync("#username", "admin");
        await page.FillAsync("#password", "password");
        await page.ClickAsync("button:has-text('Login')");
        await page.WaitForURLAsync("https://demo.snipeitapp.com/");

        // Navigate to Assets page
        await page.ClickAsync("text=Assets");
        await page.WaitForSelectorAsync("text=Asset Tag");

        // Start asset creation
        await page.ClickAsync("a.btn.btn-primary:has-text('Create New')");
        await page.WaitForSelectorAsync("#asset_tag");
        await page.WaitForTimeoutAsync(3000);

        // Capture auto-generated asset tag
        var assetTagElement = await page.QuerySelectorAsync("input#asset_tag");
        string assetTagValue = await assetTagElement.InputValueAsync();

        // Select random company
        await page.Locator("#select2-company_select-container").ClickAsync();
        await page.WaitForSelectorAsync(".select2-results__option");
        var options = await page.Locator(".select2-results__option").AllAsync();
        var random = new Random();
        var randomIndex = random.Next(0, options.Count);
        await options[randomIndex].ClickAsync();

        // Select model: Macbook Pro 13"
        await page.ClickAsync("#select2-model_select_id-container");
        await page.WaitForSelectorAsync(".select2-results__option", new() { State = WaitForSelectorState.Visible });
        await page.ClickAsync("text=Laptops - Macbook Pro 13\"");

        // Select status: Ready to Deploy
        await page.ClickAsync("#select2-status_select_id-container");
        await page.WaitForSelectorAsync("li.select2-results__option", new() { State = WaitForSelectorState.Visible });
        await page.ClickAsync("li.select2-results__option:has-text(\"Ready to Deploy\")");

        // Save asset and navigate to details
        await page.ClickAsync("button:has-text('Save')");
        await page.WaitForSelectorAsync("text=Success:");
        await page.ClickAsync("text=Click here to view");

        // Navigate to checkout page
        await page.ClickAsync("a[href*='/checkout']");

        // Select random user
        await page.ClickAsync("#select2-assigned_user_select-container");
        await Task.Delay(3000);
        await page.WaitForSelectorAsync(".select2-results__option", new() { State = WaitForSelectorState.Visible });
        await Task.Delay(3000);
        var userList = await page.QuerySelectorAllAsync(".select2-results__option");
        int userIndex = new Random().Next(userList.Count);
        await userList[userIndex].ClickAsync();

        // Submit checkout
        await page.ClickAsync("#submit_button");
        await Task.Delay(3000);

        // Search for asset by tag
        await page.FillAsync("input.search-input", assetTagValue);
        await page.PressAsync("input.search-input", "Enter");

        // Open asset detail from search result
        await page.ClickAsync($"text={assetTagValue}");

        // Open History tab
        await page.ClickAsync("a[href='#history']");
        await page.WaitForSelectorAsync("#history table");
    }
}
