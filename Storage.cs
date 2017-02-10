using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace CRUDApplication
{
    class Storage
    {
        private static Storage sharedInstance;
       
        private Storage(){}

        public static Storage GetSharedInstance()
        {
            if (sharedInstance == null)
                sharedInstance = new Storage();
            return sharedInstance;
        }

        public BindingList<User> users = new BindingList<User>();
        public BindingList<User> matchList = new BindingList<User>();


        public void GetData(string toFilePath)
        {
            var info = File.ReadLines(toFilePath, Encoding.Default);

            foreach(string userString in info)
            {
                var data = userString.Split(' ');

                int id = Convert.ToInt32(data[0]);
                int phoneNumber = Convert.ToInt32(data[3]);

                var user = new User(id, data[1], data[2], phoneNumber, data[4]);

                users.Add(user);
            }
            
        }
    }
}
