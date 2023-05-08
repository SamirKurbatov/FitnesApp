using FitnesApp.BL;
using FitnesApp.BL.Controller;
using FitnesApp.BL.Models;

Console.Write("Введите имя: ");
var name = Console.ReadLine();

var userController = new UserController(name);

var eatingController = new EatingController(userController.CurrentUser);

if (userController.IsNewUser)
{
    Console.Write("Введите пол: ");
    var gender = Console.ReadLine() ?? "Пол не введен";
    var birthday = ParseDateTime();
    var weight = ParseAndInputDouble("вес");
    var height = ParseAndInputDouble("рост");
    userController.SetNewUserData(name, gender, birthday, weight, height);
}

Console.Write(userController.CurrentUser);

Console.WriteLine("Что вы хотите сделать? ");
Console.WriteLine("E - вести прием пищи? ");

var key = Console.ReadKey();

if (key.Key == ConsoleKey.E)
{
    var foods = EnterEating();
    eatingController.Add(foods.food, foods.weight);

    foreach (var item in eatingController.Eating.Foods)
    {
        Console.WriteLine(item.Key + " " + item.Value);
    }
}

static (Food food, double weight) EnterEating()
{
    Console.Write("Введите имя продукта: ");
    var food = Console.ReadLine() ?? "Продукт не введен";
    var calories = ParseAndInputDouble("калорийность");
    var weight = ParseAndInputDouble("вес");
    var proteins = ParseAndInputDouble("белки");
    var fats = ParseAndInputDouble("жиры");
    var carbs = ParseAndInputDouble("углеводы");

    var product = new Food(food, proteins, fats, carbs, calories);

    return (product, weight);
}

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

static double ParseAndInputDouble(string name)
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