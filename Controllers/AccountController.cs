using Microsoft.AspNetCore.Mvc;
using MyAssistant.Models;

namespace MyAssistant.Controllers
{
    public class AccountController:Controller
    {
        private IMyAssistantRepo repositoryObj;
        public AccountController(IMyAssistantRepo repoObj)
        {
            repositoryObj = repoObj;
        }

        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPage(LoginResponse lr)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("ModelState is valid");
                User queryResult;
                queryResult=repositoryObj.Users.Where(record => record.Email == lr.Email && record.Password == lr.Password).FirstOrDefault();
                if (queryResult != null)
                {
                    //HttpContext.Session.SetString("UserName", queryResult.UserName);
                    //HttpContext.Session.SetString("Email", queryResult.Email);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid email or password";
                    return RedirectToAction("LoginPage");
                }
            }
            return View();
        }
    }
}
