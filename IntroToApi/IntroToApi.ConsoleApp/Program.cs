using System;
using Newtonsoft.Json;
using static System.Console;

Clear();

HttpClient _client = new HttpClient();

HttpResponseMessage response = await _client.GetAsync("https://swapi.dev/api/people/1");
// System.Console.WriteLine(await response.Content.ReadAsStringAsync());

if (response.IsSuccessStatusCode)
{
    var content = await response.Content.ReadAsStringAsync();
    // System.Console.WriteLine(content);
    //todo: Deseralize json info to our Person object
    //Person person = JsonConvert.DeserializeObject<Person>(content);
    // WriteLine(person.Name);

    var luke = await response.Content.ReadAsAsync<Person>();
    WriteLine(luke.Name);

    foreach (string vehicleUrl in luke.Vehicles)
    {
        var vehResponse = await _client.GetAsync(vehicleUrl);

        if (vehResponse.IsSuccessStatusCode)
        {
            var vehicle = await vehResponse.Content.ReadAsAsync<Vehicle>();
            WriteLine($"{vehicle.Name} - {vehicle.CargoCapacity}");
        }
    }

}
