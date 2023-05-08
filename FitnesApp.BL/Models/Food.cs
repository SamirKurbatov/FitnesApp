namespace FitnesApp.BL.Models
{
    [Serializable]
    public record Food
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbs { get; }

        /// <summary>
        /// Калории за 100 грамм продукта
        /// </summary>
        public double Calories { get; }

        public Food(string title, double proteins, double fats, double carbs, double calories)
        {
            Title = title;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbs = carbs / 100.0;
            Calories = calories / 100.0;
        }

        public Food(string title)
        {
            Title = title;
        }

        public Food()
        {
            
        }
    }
}
