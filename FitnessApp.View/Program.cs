using FitnesApp.BL;
using FitnesApp.BL.Controller;
using FitnesApp.BL.Models;
using System.ComponentModel;
using System.Globalization;
using System.Resources;


Console.Write("Введите имя: ");

var name = Console.ReadLine();

var userController = new UserController(name);

var eatingController = new EatingController(userController.CurrentUser);

var exerciseController = new ExerciesController(userController.CurrentUser);

if (userController.IsNewUser)
{
    Console.Write("Введите пол: ");
    var gender = Console.ReadLine() ?? "Пол не введен";
    var birthday = ParseDateTime("дату рождения", "(dd.MM.yyyy)");
    var weight = ParseAndInputDouble("вес");
    var height = ParseAndInputDouble("рост");
    userController.SetNewUserData(name, gender, birthday, weight, height);
}

Console.Write(userController.CurrentUser);

while (true)
{
    Console.WriteLine("Что вы хотите сделать? ");
    Console.WriteLine("E - вести прием пищи? ");
    Console.WriteLine("A - вести упражнение? ");
    Console.WriteLine("В - выйти из программы ");

    var key = Console.ReadKey();

    switch (key.Key)
    {
        case ConsoleKey.E:
            var foods = EnterEating();
            eatingController.Add(foods.food, foods.weight);

            foreach (var item in eatingController.Eating.Foods)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            break;
        case ConsoleKey.A:
            var exercise = EnterExercise();
            exerciseController.Add(exercise.activity, exercise.startTime, exercise.finishTime);

            foreach (var item in exerciseController.Exercises)
            {
                Console.Write($"упражнение {item} выполнялось с {item.Start} до {item.Finish}");
            }
            break;
        case ConsoleKey.B:
            Environment.Exit(0);
            break;
    }

    Console.ReadLine();
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


static (DateTime startTime, DateTime finishTime, Activity activity) EnterExercise()
{
    Console.Write("Введите название упражнения: ");
    var title = Console.ReadLine() ?? "Упражнение не введено";
    var energy = ParseAndInputDouble("расход энергии в минуту");
    var activity = new Activity(title, energy);
    string format = "(dd.MM.yyyy hh:mm)";
    var startTime = ParseDateTime("начало упражнения", format);
    var finishTime = ParseDateTime("конец упражнения", format);

    return new (startTime, finishTime, activity);
}

static DateTime ParseDateTime(string value, string format)
{
    DateTime birthday;
    while (true)
    {
        Console.Write($"Введите {value} {format}: ");
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