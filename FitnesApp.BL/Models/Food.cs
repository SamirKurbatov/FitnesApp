namespace FitnesApp.BL.Models
{
    [Serializable]
    public record Food
    {
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbs { get; set; }

        /// <summary>
        /// Калории за 100 грамм продукта
        /// </summary>
        public double Calories { get; set; }

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
