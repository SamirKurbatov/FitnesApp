namespace FitnesApp.BL.Models
{
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }

        public Dictionary<Food, double> Foods { get; set; }

        public User User { get; }

        public DateTime EatingMoment { get; set; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может иметь пустое значение. ", nameof(user));
            EatingMoment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Title == food.Title);

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}