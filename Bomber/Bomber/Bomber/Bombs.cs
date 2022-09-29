namespace Bomber;

public static class Bombs
{
    public static void MultipleGetRequests(int timesToRequest)
    {
        using var client = new HttpClient();
        for (int requestRepetitions = 0; requestRepetitions< timesToRequest; requestRepetitions++)
        {
            var result = client.GetAsync("https://bestalpineappdemo.azurewebsites.net/", HttpCompletionOption.ResponseContentRead);
        }
        Console.WriteLine("Ran " + timesToRequest + " times.");
    }
}