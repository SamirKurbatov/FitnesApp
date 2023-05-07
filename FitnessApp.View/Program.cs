using FitnesApp.BL;

Console.Write("Введите имя: ");
var name = Console.ReadLine();

var userController = new UserController(name);

if (userController.IsNewUser)
{
    Console.Write("Введите пол: ");
    var gender = Console.ReadLine() ?? "Пол не введен";
    var weight = ParseDouble("вес");
    var height = ParseDouble("рост");
    var birthday = ParseDateTime();
    userController.SetNewUserData(gender, birthday, weight, height);
}

Console.Write(userController.CurrentUser);

Console.ReadLine();

static DateTime ParseDateTime()
{
    DateTime birthday;
    while (true)
    {
        Console.Write("Введите дату рождения (dd.MM.yyyy): ");
        if (DateTime.TryParse(Console.ReadLine(), out birthday))
        {
            break;
        }
        else
        {
            Console.WriteLine("Неверный формат даты рождения");
        }
    }

    return birthday;
}

static double ParseDouble(string name)
{
    while (true)
    {
        Console.Write($"Введите {name}: ");
        if (double.TryParse(Console.ReadLine(), out double value))
        {
            return value;
        }
        else
        {
            Console.WriteLine($"Неверный формат {name}");
        }
    }
}