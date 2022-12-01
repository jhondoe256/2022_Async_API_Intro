
public class Potato
{
    public Potato() { }

    public Potato(bool isPeeled)
    {
        IsPeeled = isPeeled;
    }

    public bool IsPeeled { get; set; }

    //sychronous method
    public bool Peel()
    {
        System.Console.WriteLine("You start peeling the potato.");
        //simulate peeling the potato
        //3 sec to peel a potato
        //since this is a synchronous method we need to .Wait()
        Task.Delay(3000).Wait();
        System.Console.WriteLine("You peeled the potato.");

        IsPeeled = true;

        return true;
    }
}
