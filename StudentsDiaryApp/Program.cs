

using StudentsDiaryApp;
using System.Xml.Linq;

Console.WriteLine("Witamy w Dzienniczku Ucznia, w którym podane są oceny uczniów Szkoły podstawowej");
Console.WriteLine("===========================================");
Console.WriteLine();

bool CloseApp = false;


while (!CloseApp)
{
    Console.WriteLine(

        "1 - Zapisz ocenę ucznia w pamięci programu i wyświetl wyniki\n" +
        "2 - Zapisz ocenę ucznia w pliku .txt i wyświetl wyniki\n" +
        "x - Zamknij aplikację\n");

    Console.WriteLine("Co chcesz wybrać? \n Naciśnij 1, 2 lub x: ");
    var userInput = Console.ReadLine().ToUpper();

    switch (userInput)
    {
        case "1":
            AddGradesToMemory();
            break;

        case "2":
            AddGradesToTxtFile();
            break;

        case "x":
            CloseApp = true;
            break;

        default:
            Console.WriteLine("Błąd.\n");
            continue;
    }
}

//Console.WriteLine("Podaj dane ucznia: ");
//Console.WriteLine("Wpisz imię: ");
//var name = Console.ReadLine();
//Console.WriteLine("Wpisz nazwisko: ");
//var surname = Console.ReadLine();
//Console.WriteLine("Wpisz płeć (K/M): ");
//var sex = Console.ReadLine();

var student = new StudentInMemory("Monika", "hhg", "k");


Console.WriteLine();
Console.WriteLine("Proszę wpisać ocenę ucznia od 1 do 6.");
Console.WriteLine();
Console.WriteLine();

static void AddGradesToMemory()
{
    Console.WriteLine("Wpisz imię: ");
    string name = Console.ReadLine();
    Console.WriteLine("Wpisz nazwisko: ");
    var surname = Console.ReadLine();
    Console.WriteLine("Wpisz płeć (K/M): ");
    var sex = Console.ReadLine();

    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(sex))
    {
        var inMemoryStudent = new StudentInMemory(name, surname, sex);

        EnterGrade(inMemoryStudent);
        inMemoryStudent.GetStatistics();
    }
    else
    {
        Console.WriteLine("Miejsce na dane ucznia nie może pozostać puste!");
    }
}

static void AddGradesToTxtFile()
{
    Console.WriteLine("Wpisz imię: ");
    string name = Console.ReadLine();
    Console.WriteLine("Wpisz nazwisko: ");
    var surname = Console.ReadLine();
    Console.WriteLine("Wpisz płeć (K/M): ");
    var sex = Console.ReadLine();

    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(sex))
    {
        var inFileStudent = new StudentInFile(name, surname, sex);

        inFileStudent.GetStatistics();
    }
    else
    {
        Console.WriteLine("Miejsce na dane ucznia nie może pozostać puste!");
    }
}


static void EnterGrade(IStudent student)
{ 

    while (true)
    {
        Console.WriteLine("Podaj kolejną ocenę ucznia (jeśli chcesz wyjść naciśnij 'q'): ");
        var input = Console.ReadLine();
        if (input == "q")
        {
            Console.WriteLine("Oto wyniki podanego ucznia: ");
            break;
        }
        try
        {
            student.AddGrade(input);
        }
        catch (Exception e)
        {

            Console.WriteLine($"Exception catched: {e.Message}");
        }

    }
}

var ststistics = student.GetStatistics();
Console.WriteLine($"Average: {ststistics.Average}");
Console.WriteLine($"Min: {ststistics.Min}");
Console.WriteLine($"Max: {ststistics.Max}");
