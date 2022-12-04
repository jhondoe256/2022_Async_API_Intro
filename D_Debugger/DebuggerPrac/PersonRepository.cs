public class PersonRepository
{
    private readonly List<Person> _personDB = new List<Person>();
    private int _count;

    public PersonRepository()
    {
        Seed();
    }

    public bool AddPerson(Person person)
    {
        if (person is null)
        {
            return false;
        }
        else
        {
            _count++;
            person.Id = _count;
            _personDB.Add(person);
            return true;
        }
    }

    public List<Person> GetPeople()
    {
        return _personDB;
    }

    public Person GetPerson(int personId)
    {
        return _personDB.SingleOrDefault(p => p.Id == personId);
    }

    public bool UpdatePerson(int personId, Person updatedPersonData)
    {
        Person personInDB = GetPerson(personId);
        if (personInDB != null)
        {
            personInDB.FirstName = updatedPersonData.FirstName;
            personInDB.LastName = updatedPersonData.LastName;
            return true;
        }
        return false;
    }

    public bool DeletePerson(int personId)
    {
        return _personDB.Remove(GetPerson(personId));
    }

    public void Seed()
    {
        var personA = new Person("Terry", "Brown");
        var personB = new Person("Dame", "Dash");
        var personC = new Person("Steve", "Jobs");

        AddPerson(personA);
        AddPerson(personB);
        AddPerson(personC);
    }

}