public class Person
{
    //1) გამოიძახება კლასთან პირველი შეხების დროს
    public static int PersonalNumberLength { get; } = 9;

    public string PersonalNumber { get; set; } = "1111111111"; // 1) პირველ ხდება ინიციალიზაცია
    public int Age { get; set; }
    public string Name { get; set; }

    //2) გამოიძახება კლასთან პირველი შეხების დროს
    static Person()
    {
        PersonalNumberLength = 11;
    }

    public Person()
    {
        PersonalNumber = "";
        Name = "";
        Age = 1;
    }

    // 2) მეორე ხდება კონსტრუქტორის გამოძახება
    public Person(string personalNumber) : this()
    {
        if (personalNumber.Length == PersonalNumberLength)
        {
            PersonalNumber = personalNumber;
        }
    }

    public Person(string personalNumber, string name) : this(personalNumber)
    {
        Name = name;
    }

    public Person(string personalNumber, string name, int age) : this(personalNumber, name)
    {
        Age = age;
    }

    public Person(int age)
    {
        Age = age;
    }

    public Person(int age, string name)
    {
        Age = age;
        Name = name;
    }

    public Person(string personalNumber, int age)
    {
        this.PersonalNumber = personalNumber;
        Age = age;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Person person)
        {
            return PersonalNumber == person.PersonalNumber;
        }
        else
        {
            return false;
        }
    }
}

public struct PersonStructure
{
    public int Age { get; set; }
    public string Name { get; set; }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine(Person.PersonalNumberLength);

        Person person0 = new Person("01001020345", "Daviti", 30);

        Person person1 = new Person()
        {
            PersonalNumber = "01001020345",
            Age = 20,
            Name = "Daviti"
        };

        Person person2 = new Person("01001020345")
        {
            PersonalNumber = "000000000", // 3) მესამე გამოიძახება Property Initializer-ი
            Age = 20,
            Name = "Daviti"
        };

        var person5 = person2; //  = person1;

        if (ReferencesEqual(person1, person2, person5))
        {
            Console.WriteLine("All references are equal");
        }
        else
        {
            Console.WriteLine("Not all references are equal");
        }

        if (ReferenceEquals(person1, person2))
        {
            Console.WriteLine("ReferenceEquals(person1, person2)");
        }
        else
        {
            Console.WriteLine("!ReferenceEquals(person1, person2)");
        }

        if (person1.Equals(person2))
        {
            Console.WriteLine("person1.Equals(person2)");
        }
        else
        {
            Console.WriteLine("!person1.Equals(person2)");
        }

        PersonStructure person3 = new PersonStructure
        {
            Name = "Giorgi",
            Age = 25
        };

        PersonStructure person4 = new PersonStructure
        {
            Name = "Giorgi",
            Age = 25
        };

        if (person3.Equals(person4))
        {
            Console.WriteLine("person3 == person4");
        }
        else
        {
            Console.WriteLine("person3 != person4");
        }

        List<Person> personClasses = new List<Person>
        {
            person1,
            person2
        };

        List<PersonStructure> personStructures = new List<PersonStructure>()
        {
            person3,
            person4
        };

        for (int i = 0; i < personClasses.Count; i++)
        {
            personClasses[i].Age++;
        }

        for (int i = 0; i < personStructures.Count; i++)
        {
            PersonStructure temp = personStructures[i];
            temp.Age++;
            personStructures[i] = temp;
        }

        Console.WriteLine();
    }

    public static bool ReferencesEqual(params object[] objects)
    {
        var first = objects[0];
        for (int i = 1; i < objects.Length; i++)
        {
            if (!ReferenceEquals(first, objects[i]))
            {
                return false;
            }
        }
        return true;
    }

    public static void IncreaseByTen(ref int number)
    {
        number += 10;
    }

    public static void AssignValue(out int number)
    {
        var text = Console.ReadLine();
        if (text != "")
        {
            number = int.Parse(text);
        }
        else
        {
            number = 0;
        }
        Console.WriteLine(number);
    }

    public static void RedefineObject(Person person)
    {
        person = new Person()
        {
            Age = 100,
            Name = "Very old man"
        };
    }

    public static void RedefineObjectByRef(ref Person person)
    {
        person = new Person()
        {
            Age = 100,
            Name = "Very old man"
        };
    }

    public static void SetName(Person person)
    {
        person.Name = "Test Name";
    }

    private static void Sum(int number1, int number2)
    {
        Console.WriteLine($"{number1} + {number2} = {number1 + number2}");
    }
}