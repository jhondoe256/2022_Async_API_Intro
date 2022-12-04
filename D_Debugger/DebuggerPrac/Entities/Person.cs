
public class Person
{
    public Person() { }

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }

    public override string ToString()
    {
        var str = "Person: {" + "\n";
        str += $"Id: {Id}\n";
        str += $"Name: {FullName}\n";
        str += "}" + "\n";
        str += $"------------------------------------------\n";
        return str;
    }
}
