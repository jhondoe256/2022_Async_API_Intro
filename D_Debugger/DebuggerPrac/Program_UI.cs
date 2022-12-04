public class Program_UI
{
    private readonly PersonRepository _pRepo = new PersonRepository();
    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("==Person App==\n" +
            "1. Add Person\n" +
            "2. View People\n" +
            "3. View Person\n" +
            "4. Update Person\n" +
            "5. Delete Person\n" +
            "0. Close App\n");

            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddPerson();
                    break;
                case "2":
                    ViewPeople();
                    break;
                case "3":
                    ViewPerson();
                    break;
                case "4":
                    UpdatePerson();
                    break;
                case "5":
                    DeletePerson();
                    break;
                case "0":
                    isRunning = CloseApp();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    PressAnyKey();
                    break;
            }
        }
    }
    private void AddPerson()
    {
        Console.Clear();
        Person person = InitPersonForm();

        //add to DB:
        if (_pRepo.AddPerson(person))
        {
            System.Console.WriteLine("Success!");
        }
        else
        {
            System.Console.WriteLine("Failure.");
        }

        Console.ReadKey();
    }

    private Person InitPersonForm()
    {
        var person = new Person();

        System.Console.Write("Enter First Name: ");
        person.FirstName = Console.ReadLine();

        System.Console.Write("Enter Last Name: ");
        person.LastName = Console.ReadLine();

        return person;
    }

    private void ViewPeople()
    {
        Console.Clear();
        PeopleMenu();

        Console.ReadKey();
    }

    private void PeopleMenu()
    {
        foreach (var person in _pRepo.GetPeople())
        {
            System.Console.WriteLine(person);
        }
    }

    private void ViewPerson()
    {
        Console.Clear();

        PeopleMenu();

        System.Console.WriteLine("Please Select a Person by Id.");

        int personIdSelection = int.Parse(Console.ReadLine());
        Console.Clear();
        System.Console.WriteLine(_pRepo.GetPerson(personIdSelection));

        Console.ReadKey();
    }

    private void UpdatePerson()
    {
        Console.Clear();
        PeopleMenu();
        System.Console.WriteLine("Please Select a Person by Id.");

        int personIdSelection = int.Parse(Console.ReadLine());

        var personInDB = _pRepo.GetPerson(personIdSelection);
        if (personInDB != null)
        {
            Console.Clear();
            Person updatedPersonData = InitPersonForm();

            if (_pRepo.UpdatePerson(personInDB.Id, updatedPersonData))
            {
                System.Console.WriteLine("Success!");
            }
            else
            {
                System.Console.WriteLine("Failure.");
            }
        }
        else
        {
            System.Console.WriteLine($"Sorry the user with {personIdSelection} doesn't exist.");
        }

        Console.ReadKey();
    }

    private void DeletePerson()
    {
        Console.Clear();
        Console.Clear();
        PeopleMenu();
        System.Console.WriteLine("Please Select a Person by Id.");

        int personIdSelection = int.Parse(Console.ReadLine());

        if (_pRepo.DeletePerson(personIdSelection))
        {
            System.Console.WriteLine("Success!");
        }
        else
        {
            System.Console.WriteLine("Failure.");
        }

        Console.ReadKey();
    }

    private bool CloseApp()
    {
        Console.Clear();
        System.Console.WriteLine("Thanks!");
        PressAnyKey();
        return false;
    }


    private void PressAnyKey()
    {
        Console.Clear();
        System.Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
}