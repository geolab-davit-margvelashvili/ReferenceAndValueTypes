public class Person
{
    public int Age { get; set; }
    public string Name { get; set; }
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
        int.TryParse(Console.ReadLine(), out int number1);
        int number2 = number1;

        number1 = 50;

        Console.WriteLine($"number1 before increase: {number1}");
        IncreaseByTen(ref number1);
        Console.WriteLine($"number1 after increase: {number1}");

        Person person1 = new Person()
        {
            Age = 25,
            Name = "Daviti"
        };

        RedefineObject(person1);
        RedefineObjectByRef(ref person1);
        SetName(person1);
        AssignValue(out var number5);
        Console.WriteLine(number5);

        Person person2 = new Person()
        {
            Age = 20,
            Name = "Giorigi"
        };

        person1 = person2;
        person1.Age = 60;

        Console.WriteLine(person1.Age);

        PersonStructure person3 = new PersonStructure
        {
            Name = person2.Name,
            Age = person2.Age
        };
        //person2 = person3; // ეს არ შეიძლება

        Console.WriteLine();
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