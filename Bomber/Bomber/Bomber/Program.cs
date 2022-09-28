
using var client = new HttpClient();

var timesToRequst = 100;

for (int requestRepetitions = 0; requestRepetitions < timesToRequst; requestRepetitions++)
{
    var result = await client.GetAsync("https://bestalpineappdemo.azurewebsites.net/", HttpCompletionOption.ResponseContentRead);
    Console.WriteLine(result.StatusCode);
}