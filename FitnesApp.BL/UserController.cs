using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitnesApp.BL
{
    public class UserController
    {
        private const string USERS_FILE_NAME = "userss.dat";

        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = LoadUsers();

            CurrentUser = Users.SingleOrDefault(u => u.FirstName == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDay, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDay = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            SaveUsers();
        }

        public void SaveUsers()
        {
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = new FileStream(USERS_FILE_NAME, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fileStream, Users);
            }
        }

        private List<User> LoadUsers()
        {
            var binary = new BinaryFormatter();
            if (File.Exists(USERS_FILE_NAME))
            {
                using (var fileStream = new FileStream(USERS_FILE_NAME, FileMode.OpenOrCreate))
                {
                    if (fileStream.Length > 1 && binary.Deserialize(fileStream) is List<User> users)
                    {
                        return users;
                    }
                    else
                    {
                        return new List<User>();
                    }
                }
            }

            else
            {
                return new List<User>();
            }
        }
    }
}
