
namespace FitnesApp.BL.Models
{
    [Serializable]
    public record Activity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double CaloriesPerMinute { get; set; }

        public Activity(string name, double caloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Имя не должно быть равно нулю");
            }

            Title = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public Activity()
        {
            
        }
    }
}
