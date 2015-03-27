using BL.AccountModels;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;

namespace BL.Helpers
{
    public class RegisterHelper
    {
        public bool Register(RegisterInfo reg)
        {
            RegisterRepository repo = new RegisterRepository();
            RolesHelper helper = new RolesHelper();
            DAL.Entity.Roles role = helper.RoleUser();
            DAL.Entity.Account Areg = new DAL.Entity.Account
            {
                LastName = reg.LastName,
                MidleName = reg.MidleName,
                FirstName = reg.FirstName,
                Login = reg.Login,
                Password = reg.Password,
                Email = reg.Email,
                ConfirmedEmail=false,
                Roles = role
            };            
            repo.RegAccount(Areg);
            return true;
        }

        public bool LogAccount(string login, string password)
        {
            DAL.Repository.RegisterRepository repo = new DAL.Repository.RegisterRepository();
            return repo.Account.Any(a => a.Login.Equals(login) && a.Password.Equals(password));
        }
        public BL.AccountModels.ActivationModel GetActivationList(string username)
        {
            DAL.Repository.RegisterRepository repo = new DAL.Repository.RegisterRepository();
            DAL.Entity.Account user = repo.Account.Where(u => u.Login == username).FirstOrDefault();
            return new BL.AccountModels.ActivationModel(user.ID, user.LastName, user.FirstName, user.MidleName, user.Email, user.Login, user.Password, user.ConfirmedEmail);
        }

        public bool ActivationMail(BL.AccountModels.ActivationModel account)
        {
            DAL.Entity.Account activation = new DAL.Entity.Account
            {
                ID = account.ID,
                LastName = account.LastName,
                FirstName = account.FirstName,
                MidleName = account.MidleName,
                Email = account.Email,
                Login = account.Login,
                Password = account.Password,
                ConfirmedEmail = true
            };
            DAL.Repository.RegisterRepository repo = new DAL.Repository.RegisterRepository();
            repo.ActivationAccount(activation);
            return true;
        }
        public bool CheckActivation(string login)
        {
            DAL.Repository.RegisterRepository repo = new DAL.Repository.RegisterRepository();
            List<DAL.Entity.Account> activ = repo.Account.Where(b => b.Login == login && b.ConfirmedEmail == true).ToList();
            if (activ.Count() > 0)
                return true;
            else
                return false;
        }
        public BL.AccountModels.ForgotPasswordModel GetForgotPasswordList(string login)
        {
            DAL.Repository.RegisterRepository repo = new DAL.Repository.RegisterRepository();
            DAL.Entity.Account user = repo.Account.Where(u => u.Login == login).FirstOrDefault();
            return new BL.AccountModels.ForgotPasswordModel(user.Email, user.Login, user.Password);
        }
    }
}
