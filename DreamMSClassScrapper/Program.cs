using Microsoft.Playwright;

class Program
{
    public static async Task Main()
    {
        Console.Write("Enter character name: ");
        var charName = Console.ReadLine();

        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = true });
        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://dreamms.gg/?rank=0#speakers");

        if (charName == null)
        {
            Console.WriteLine("Character name is empty");
            return;
        }
        
        await page.FillAsync("input[name='search']", charName);
        await page.Keyboard.PressAsync("Enter");
        await page.WaitForTimeoutAsync(1500); // let JS update the list

        var characterCards = await page.QuerySelectorAllAsync("div.col-lg-4.col-md-6");

        foreach (var card in characterCards)
        {
            var nameElement = await card.QuerySelectorAsync("div.details h3 a");
            var levelElement = await card.QuerySelectorAsync("div.details p");
            var jobElement = await card.QuerySelectorAsync("div.details div.social p");

            async Task<string> GetInnerTextOrEmpty(IElementHandle? element) =>
                element != null ? await element.InnerTextAsync() : string.Empty;

            var name = await GetInnerTextOrEmpty(nameElement);
            var level = await GetInnerTextOrEmpty(levelElement);
            var job = await GetInnerTextOrEmpty(jobElement);

            if (string.Equals(name.Trim(), charName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Found: {name}, {level}, {job}");
                return;
            }
        }

        Console.WriteLine("Character not found.");
    }
}