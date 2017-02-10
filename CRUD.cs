using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace CRUDApplication
{
    class CRUD
    {

        public void Create(string id, string name, string surName, 
                                      string phoneNumber, string email)
        {
            var user = new User(id, name, surName, phoneNumber, email);
            Storage.GetSharedInstance().users.Add(user);
        }

        public BindingList<User> Read(Dictionary<string, string> dataForSearch)
        {
            var users = new BindingList<User>();
            var newUser = new User(dataForSearch);

            foreach(User user in Storage.GetSharedInstance().users)
            { 
                if (((user.Id == newUser.Id) || (newUser.Id == 0)) &&
                    ((user.Name == newUser.Name) || (newUser.Name == "")) &&
                    ((user.Surname == newUser.Surname) || (newUser.Surname == "")) &&
                    ((user.PhoneNumber == newUser.PhoneNumber) || (newUser.PhoneNumber == 0)) &&
                    ((user.Email == newUser.Email) || (newUser.Email == "")))
                { 
                    users.Add(user);
                }
            }

            return users;
        }

        public void Update(User user)
        {

            for (int i = 0; i < Storage.GetSharedInstance().users.Count; i += 1)
            {
                if (Storage.GetSharedInstance().users[i].Id == user.Id)
                    Storage.GetSharedInstance().users[i] = user;
            }

        }

        public void Delete(User user)
        {
            for (int i = 0; i < Storage.GetSharedInstance().users.Count; i += 1)
            {
                if (Storage.GetSharedInstance().users[i].Id == user.Id)
                    Storage.GetSharedInstance().users.Remove(Storage.GetSharedInstance().users[i]);
            }
        }

    }
}
