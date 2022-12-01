SWAPI_Service _service = new SWAPI_Service();

Person luke = await _service.GetPersonAsync("https://swapi.dev/api/people/1");
System.Console.WriteLine(luke.Name);

Vehicle vehicle = await _service.GetVehicleAsync("https://swapi.dev/api/vehicles/14");
System.Console.WriteLine(vehicle.Name);

var person = await _service.GetAsync<Person>("https://swapi.dev/api/people/4");
System.Console.WriteLine(person.Name);

var veh = await _service.GetAsync<Vehicle>("https://swapi.dev/api/vehicles/4");
System.Console.WriteLine(veh.Name);

SearchResult<Person> personSearchResult = await _service.GetSearchPersonAsync("skywalker");
foreach (var p in personSearchResult.Results)
{
    System.Console.WriteLine($"{p.Name} - {p.BirthYear}");
}


Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine("=== Using SWAPI Service Search Result GENERIC (vehicle) ===");
Console.ResetColor();

var genVehSearch = await _service.GetSearchResultAsync<Vehicle>("speeder", "vehicles");
foreach (var item in genVehSearch.Results)
{
    System.Console.WriteLine(item.Name);
}