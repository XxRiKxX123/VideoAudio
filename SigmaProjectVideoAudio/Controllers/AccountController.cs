using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using System.Web.Security;
using BL.AccountModels;
using System.Net.Mail;
using BL.Helpers;

namespace VideoAudio.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterInfo reg)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    BL.Helpers.RegisterHelper helper = new BL.Helpers.RegisterHelper();
                    helper.Register(reg);
                        // наш email с заголовком письма
                        MailAddress from = new MailAddress("Identificationkartoteka@yandex.ru", "Web Registration");
                        // кому отправляем
                        MailAddress to = new MailAddress(reg.Email);
                        // создаем объект сообщения
                        MailMessage m = new MailMessage(from, to);
                        // тема письма
                        m.Subject = "Email confirmation";
                        // текст письма - включаем в него ссылку
                        m.Body = string.Format("Для завершения регистрации перейдите по ссылке:" +
                                        "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>",
                            Url.Action("ConfirmEmail", "Account", new { Token = reg.Login, Email = reg.Email }, Request.Url.Scheme));
                        m.IsBodyHtml = true;
                        // адрес smtp-сервера, с которого мы и будем отправлять письмо
                        SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.yandex.ru", 25);
                        smtp.EnableSsl = true;
                        // логин и пароль
                        smtp.Credentials = new System.Net.NetworkCredential("Identificationkartoteka@yandex.ru", "qwerty12345");
                        smtp.Send(m);
                        return RedirectToAction("Confirm", "Account", new { Email = reg.Email });
                }

            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(reg);

        }
        [AllowAnonymous]
        public string Confirm(string Email)
        {
            return "На почтовый адрес " + Email + " Вам высланы дальнейшие" +
                    "инструкции по завершению регистрации";
        }
       [AllowAnonymous]
        public ActionResult ConfirmEmail(string Token, string Email)
        {
            if (Token != null)
            {
                RegisterHelper h = new RegisterHelper();
                BL.AccountModels.ActivationModel activation = h.GetActivationList(Token);
                return View(activation);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmEmail(BL.AccountModels.ActivationModel account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RegisterHelper h = new RegisterHelper();
                    h.ActivationMail(account);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(account);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(BL.AccountModels.LoginModel user)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    BL.Helpers.RegisterHelper h = new BL.Helpers.RegisterHelper();
                    if (h.LogAccount(user.Login, user.Password))
                    {
                        if (h.CheckActivation(user.Login) == true)
                        {
                            FormsAuthentication.SetAuthCookie(user.Login, createPersistentCookie: true);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Не подтвержден email.");
                            return View(user);
                        }

                    }
                }
            }
            catch (DataException)
            {
            }
            ModelState.AddModelError("", "Имя пользователя или пароль указаны неверно.");
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(BL.AccountModels.ForgotPasswordModel account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BL.Helpers.RegisterHelper helper = new BL.Helpers.RegisterHelper();
                    BL.AccountModels.ForgotPasswordModel forgotpassword = helper.GetForgotPasswordList(account.Login);
                    MailAddress from = new MailAddress("Identificationkartoteka@yandex.ru", "Web Registration");
                    MailAddress to = new MailAddress(forgotpassword.Mail);
                    MailMessage m = new MailMessage(from, to);
                    m.Subject = "Email confirmation";
                    m.Body = string.Format("Ваш пароль: " + forgotpassword.Password);
                    m.IsBodyHtml = true;
                    SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.yandex.ru", 25);
                    smtp.Credentials = new System.Net.NetworkCredential("Identificationkartoteka@yandex.ru", "qwerty12345");
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(account);
        }
    }
}