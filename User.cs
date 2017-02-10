using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApplication
{
    class User
    {
        private int id = 0;
        public int Id { get; private set; }
        private string name = "";
        public string Name { get; private set; }
        private string surname = "";
        public string Surname { get; private set; }
        private int phoneNumber = 0;
        public int PhoneNumber { get; private set; }
        private string email = "";
        public string Email { get; private set; }

        public User(int id, string name, string surname, int phoneNumber, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public User(string id, string name, string surname, string phoneNumber, string email)
        {
            Id = Convert.ToInt32(id);
            Name = name;
            Surname = surname;
            PhoneNumber = Convert.ToInt32(phoneNumber);
            Email = email;
        }

        public User(Dictionary<string, string> data)
        {
            foreach(string key in data.Keys)
            {
                switch (key)
                {
                    case "id":
                        if (data[key] == "") { Id = 0; break; }
                        Id = Convert.ToInt32(data[key]);
                            break;
                    case "name":
                            Name = data[key];
                            break;
                    case "surname":
                        Surname = data[key];
                        break;
                    case "phoneNumber":
                        if (data[key] == "") { PhoneNumber = 0; break; }
                        PhoneNumber = Convert.ToInt32(data[key]);
                        break;
                    case "email":
                        Email = data[key];
                        break;
                    default:
                        break;
                }
            }
        }

        public static bool operator == (User user1, User user2)
        {
        return ((user1.id == user2.id) && (user1.name == user2.name) && 
            (user1.surname == user2.surname) && (user1.phoneNumber == user2.phoneNumber) && 
            (user1.email == user2.email));
        }

        public static bool operator != (User user1, User user2)
        {
            return ((user1.id != user2.id) || (user1.name != user2.name) ||
            (user1.surname != user2.surname) || (user1.phoneNumber != user2.phoneNumber) ||
            (user1.email != user2.email));
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
