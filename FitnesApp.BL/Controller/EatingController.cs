using FitnesApp.BL.Models;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnesApp.BL.Controller
{
    public class EatingController : BaseController
    {
        private readonly User user;

        public List<Food> Foods { get; }

        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Title == food.Title);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            return base.Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return base.Load<Food>() ?? new List<Food>();
        }

        private void Save()
        {
            Save(Foods);
            Save(new List<Eating> { Eating });
        }
    }
}
