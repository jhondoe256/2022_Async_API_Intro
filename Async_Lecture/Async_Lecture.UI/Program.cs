Console.Clear();
System.Console.WriteLine("Press any key to create a meal.");

Console.ReadKey();

Kitchen kitchen = new Kitchen();
Potato potato = new Potato();

//lets peel the potato first!!
potato.Peel();

var fries =  kitchen.FryPotatoesAsync(potato);
var hamburger = kitchen.AssembleBurger();

//serve the meal
kitchen.ServeMeal(fries.Result,hamburger);

Console.ReadKey();