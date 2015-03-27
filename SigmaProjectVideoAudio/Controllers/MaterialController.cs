using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using BL;
using DAL.Entity;
using BL.MaterialModels;
using BL.Helpers;

namespace VideoAudio.Controllers
{
    public class MaterialController : Controller
    {
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaterialCreate material)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    BL.Helpers.MaterialHelper helper = new BL.Helpers.MaterialHelper();
                    helper.AddMaterial(material);
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(material);
        }

        [Authorize]
        public ActionResult Edit(int id = 1)
        {
            MaterialHelper helper = new MaterialHelper();
            MaterialEdit edit = helper.GetEditList(User.Identity.Name,id);
            if (edit != null)
            {
                return View(edit);
            }
            else
            {
                RolesHelper rolehelper = new RolesHelper();
                if(rolehelper.UserRoles(User.Identity.Name) == true)
                {
                    MaterialEdit editAdmin = helper.GetAdminEditList(id);
                    return View(editAdmin);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
                   
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MaterialEdit material)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    BL.Helpers.MaterialHelper helper = new BL.Helpers.MaterialHelper();
                    helper.MaterialEdit(material);
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(material);
        }
        [Authorize]
        public ActionResult Delete(int id = 1)
        {
            MaterialHelper helper = new MaterialHelper();
            MaterialDelete delete = helper.GetDeleteList(id);
            return View(delete);
        }

        [HttpPost, ActionName("Delete")]

        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    BL.Helpers.MaterialHelper helper = new BL.Helpers.MaterialHelper();
                    helper.MaterialDelete(id);
                }

            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

