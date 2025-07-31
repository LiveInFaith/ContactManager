using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp1_ContactManager
{
    public class Contacts
    {
        private int _id;
        private string _name;
        private string _email;
        private string _phone;

        public Contacts(int id, string name, string email, string phone)
        {
            Id_V = id;
            Name_V = name;
            Email_V = email;
            Phone_V = phone;
        }
        public Contacts()
        {
            
        }

        public int Id_V { get => _id; set => _id = value; }
        public string Name_V { get => _name; set => _name = value; }
        public string Email_V { get => _email; set => _email = value; }
        public string Phone_V { get => _phone; set => _phone = value; }

        public override string ToString()
        {
            return $"ID : {Id_V}, Name : {Name_V}, Email : {Email_V}, Phone Number : {Phone_V}";
        }
    }
}
