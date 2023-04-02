using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Que
{
    public class User // model class, -> bcs description for DB (table moves)
    {
        // fields
        [Key]
        public int id { get; set; }
        private string username, email, pass;

        public string Username
        {
            get { return username; } set {  username = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        //constructors
        public User() { }

        public User(string username, string email, string pass)
        {
            this.username = username;
            this.email = email;
            this.pass = pass; 
        }


    }
}
