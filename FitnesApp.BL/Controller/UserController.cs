﻿using FitnesApp.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitnesApp.BL.Controller
{
    public class UserController : BaseController
    {
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsers();

            CurrentUser = Users.SingleOrDefault(u => u.FirstName == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        public void SetNewUserData(string name,string genderName, DateTime birthDay, double weight = 1, double height = 1)
        {
            CurrentUser.FirstName = name;
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDay = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            SaveUsers();
        }

        private void SaveUsers()
        {
            Save(Users);
        }

        private List<User> GetUsers()
        {
            var users = Load<User>();
            if (users == null)
            {
                Console.WriteLine($"File {nameof(users)} is empty or corrupted");
            }
            return users ?? new List<User>();
        }
    }
}
