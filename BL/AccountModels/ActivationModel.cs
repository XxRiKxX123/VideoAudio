using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AccountModels
{
    public class ActivationModel
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MidleName { get; set; }
        public string Email { get; set; }
        public bool ConfirmedEmail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ActivationModel()
        {
            this.ID = ID;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MidleName = MidleName;
            this.Email = Email;
            this.Login = Login;
            this.Password = Password;
            this.ConfirmedEmail = ConfirmedEmail;
        }

        public ActivationModel(int ID, string LastName, string FirstName, string MiddleName, string EMail, string Login, string Password, bool ConfirmedEmail)
        {
            this.ID = ID;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MidleName = MiddleName;
            this.Email = EMail;
            this.ConfirmedEmail = ConfirmedEmail;
            this.Login = Login;
            this.Password = Password;
        }
    }
}