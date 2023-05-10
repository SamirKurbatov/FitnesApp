namespace FitnesApp.BL.Models
{
    [Serializable]
    public record Exercise
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start; 
            Finish = finish; 
            Activity = activity;
            User = user;
        }
        public Exercise() { }
    }
}
