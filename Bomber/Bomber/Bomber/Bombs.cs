using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Drawing;
using System.Text.Json;

namespace Bomber;

public static class Bombs
{
    public static async Task MultipleGetRequests(int timesToRequest)
    {
        using var client = new HttpClient();
        for (int requestRepetitions = 0; requestRepetitions< timesToRequest; requestRepetitions++)
        {
            var result = await client.GetAsync("https://bestalpineappdemo.azurewebsites.net/", HttpCompletionOption.ResponseContentRead);
            Console.WriteLine(result.StatusCode);
        }
    }

    public static async Task CreateMultiplePizzas(int timesToRequest)
    {
        using var client = new HttpClient();
        for (int requestRepetitions = 0; requestRepetitions < timesToRequest; requestRepetitions++)
        {
            var newPizza = new NewPizza
            { 
                Name = "pizza" + requestRepetitions,
                Price = requestRepetitions,
                Size = Size.Small,
                IsGlutenFree = requestRepetitions % 2 == 0,
                __RequestVerificationToken = "CfDJ8Lt4alJTBmtKgeuU25sxmg2twld1o3Dd5xJd4oeGCrMFX3ADJi_tPCDcddGwpLVA_esjp9UQMMIyKXTB7woD7I8Hb6IJjKSio4NSO1NtxtJVi0zT9_o9VdhKKMZiF2Z15EfsT1EIr9qmU02ewpzsli8"
            };

            var json = JsonSerializer.Serialize(newPizza);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("https://bestalpineappdemo.azurewebsites.net/Pizza", data);
            Console.WriteLine(result.StatusCode);
            var content = result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
            var dict = new Dictionary<string, string>
            {
                {"NewPizza.Name", newPizza.Name },
                {"NewPizza.Price", newPizza.Price.ToString() },
                {"NewPizza.Size", newPizza.Size.ToString() },
                {"NewPizza.IsGlutenFree", newPizza.IsGlutenFree.ToString() }

            };
            var formContent = new FormUrlEncodedContent(dict);
            var result2 = await client.PostAsync("https://bestalpineappdemo.azurewebsites.net/Pizza", formContent);

            Console.WriteLine(result2.StatusCode);
            var content2 = result2.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content2);

        }
    }
}

public class NewPizza
{
    public string __RequestVerificationToken { get; set; }
    public string? Name { get; set; }
    public Size Size { get; set; }
    public decimal Price { get; set; }
    public bool IsGlutenFree { get; set; }
}

public enum Size
{
    Small,
    Medium,
    Large,
}