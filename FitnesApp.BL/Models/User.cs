using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FitnesApp.BL.Models
{
    [Serializable]
    public record class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDay { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public int Age
        {
            get
            {
                DateTime nowDate = DateTime.Today;
                int age = nowDate.Year - BirthDay.Year;
                if (BirthDay > nowDate.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        public User(string firstName, Gender gender, DateTime birthday, double weight, double height)
        {
            if (birthday < DateTime.Parse("01.01.1900") || birthday >= DateTime.Now)
            {
                throw new NullReferenceException(nameof(birthday));
            }
            if (string.IsNullOrEmpty(firstName))
            {
                throw new NullReferenceException(nameof(firstName));
            }
            if (gender == null)
            {
                throw new NullReferenceException(nameof(gender));
            }
            if (weight <= 0)
            {
                throw new ArgumentNullException(nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentNullException(nameof(height));
            }

            FirstName = firstName;
            Gender = gender;
            BirthDay = birthday;
            Weight = weight;
            Height = height;
        }

        public User(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new NullReferenceException(nameof(firstName));
            }
            FirstName = firstName;
        }

        public User() { }
    }
}
