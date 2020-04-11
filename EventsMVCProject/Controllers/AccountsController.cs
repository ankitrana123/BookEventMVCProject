using EventsMVCProject.ViewModels;
using Services.ServiceModels;
using Services.ServiceOperations;
using System.Web.Mvc;
using System.Web.Security;

namespace EventsMVCProject.Controllers
{
    [AllowAnonymous]
    public class AccountsController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AccountModel accountModel = new AccountModel();
            accountModel.EmailId = model.EmailId;
            accountModel.Password = model.Password;
            AccountOperations accountOperations = new AccountOperations();
            if (accountOperations.Login(accountModel) == true)
            {
                FormsAuthentication.SetAuthCookie(model.EmailId, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid Username and Password");
            return View();


        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(AccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                AccountModel accountModel = new AccountModel();
                accountModel.EmailId = model.EmailId;
                accountModel.Password = model.Password;
                accountModel.FullName = model.FullName;
                AccountOperations accountOperations = new AccountOperations();
                accountOperations.SignUp(accountModel);
            }
            return RedirectToAction("Login");


        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Admin()
        {
            return Redirect("helpdesk.nagarro.com");
        }
    }
}