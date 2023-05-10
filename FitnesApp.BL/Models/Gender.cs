namespace FitnesApp.BL.Models
{
    [Serializable]
    public record Gender
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }

        public Gender() { }
    }
}