using FitnesApp.BL.Models;

namespace FitnesApp.BL.Controller
{
    public class ExerciesController : BaseController
    {
        private readonly User user;

        public List<Exercise> Exercises { get; }

        public List<Activity> Activites { get; }

        public ExerciesController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user), "Пользователь не должен быть пустым значением");

            Exercises = GetAllExercies();
            Activites = GetAllActivities();
        }

        public void Add(Activity activity, DateTime start, DateTime finish)
        {
            var act = Activites.SingleOrDefault(x => x.Title == activity.Title);

            var exercise = new Exercise(start, finish, act, user);

            if (act == null)
            {
                Activites.Add(activity);
                Exercises.Add(exercise);
            }
            else
            {
                Activites.Add(act);
                Exercises.Add(exercise);
            }
            Save();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        private List<Exercise>? GetAllExercies()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(Activites);
            Save(Exercises);
        }
    }
}
