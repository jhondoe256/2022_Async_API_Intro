
using System.Diagnostics;

public class Kitchen
{
    string soundFile = @"Your file location goes here";
    public async Task<Fries> FryPotatoesAsync(Potato potato)
    {
        //check if the potato is peeled
        if (potato.IsPeeled == true)
        {
            System.Console.WriteLine("Dropping In the Fries.");
            await Task.Delay(2000);

            System.Console.WriteLine("The Fries are frying.");
            await Task.Delay(3000);

            System.Console.WriteLine("Ding, Fries are Done!");
            return new Fries(potato);
        }
        else
        {
            System.Console.WriteLine("The potato isn't peeled.");
            return null;
        }
    }

    public async Task<Fries> FryPotatoesRefactorAsync(Potato potato)
    {
        //check if the potato is peeled
        if (potato.IsPeeled == true)
        {
            //changing the color to yellow
            PrettyPrint("Dropping In the Fries.", 14);
            await Task.Delay(5000);

            PrettyPrint("The Fries are frying.", 14);
            await Task.Delay(8000);

            PrettyPrint("Ding, Fries are Done!", 14);
            PlaySound(soundFile);
            return new Fries(potato);
        }
        else
        {
            System.Console.WriteLine("The potato isn't peeled.");
            return null;
        }
    }

    //Synchronous method..again...
    public Hamburger AssembleBurger()
    {
        var time = 1000;

        PrettyPrint("Assembling the burger.", 13);
        PrettyPrint("Setting the bun down.", 4);

        Task.Delay(time).Wait();

        PrettyPrint("Set the Patty down gently.", 12);
        Task.Delay(time).Wait();

        PrettyPrint("Placing down some chese.", 14);
        Task.Delay(time).Wait();

        PrettyPrint("Lettuce, is there now.", 10);
        Task.Delay(time).Wait();

        PrettyPrint("Remember the pickles.", 2);
        Task.Delay(time).Wait();

        PrettyPrint("Add the sauce.", 12);
        Task.Delay(time).Wait();

        PrettyPrint("Slap a bun on there.", 4);
        PrettyPrint("Burger Assembled.", 13);

        return new Hamburger();
    }

    public bool ServeMeal(Fries fries, Hamburger hamburger)
    {
        if (fries == null)
        {
            PrettyPrint("The FRIES ARE NOT READY!!!,YUCK!", 4);
            return false;
        }
        else
        {
            PrettyPrint("You combine the burger and fries and serve the meal.", 15);
            return true;
        }
    }

    public void PrettyPrint(string message, int color)
    {
        //casting to console color via 'int color' being 'passed in the method'
        //Black          0
        //DarkBlue       1
        //DarkGreen      2
        //DarkCyan       3
        //DarkRed        4 
        //DarkMagenta    5
        //DarkYellow     6
        //Gray           7
        //DarkGray       8
        //Blue           9
        //Green          10
        //Cyan           11
        //Red            12
        //Magenta        13
        //Yellow         14
        //White          15

        //change the color
        Console.ForegroundColor = (ConsoleColor)color;
        //write our message
        System.Console.WriteLine(message);
        //change the color back.
        Console.ResetColor();


    }

    public void PlaySound(string file)
    {
        Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '{file}').PlaySync();");
    }
}
