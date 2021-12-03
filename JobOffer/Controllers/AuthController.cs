using JobOffer.Filters;
using JobOffer.Models;
using JobOffer.Repositories;
using JobOffer.Repositories.Abstraction;
using JobOffer.Services;
using JobOffer.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUsersRepository repo;
        public AuthController(IUsersRepository _repo)
        {
            this.repo = _repo;
        }

        [ServiceFilter(typeof(NonAuthenticatedFilter))]
        public IActionResult Login()
        {
            return View();
        
        }

        [HttpPost]
        [ServiceFilter(typeof(NonAuthenticatedFilter))]

        public IActionResult Login(UserLoginVM model)
        {
            //fields are correctly entered
            if (!ModelState.IsValid)
            {
                return View(model);
            }




            User user = repo.GetByUsernameAndPassword(model.Username,model.Password);

            if (user!=null)
            {
                AuthService.LoggedUser = user;
                return RedirectToAction("List","Users");
            }

            return View(model);//vrushtame login viewto s populneni poleta
        }

        [ServiceFilter(typeof(NonAuthenticatedFilter))]

        public IActionResult Register()
        {
            return View();
        }

        [ServiceFilter(typeof(NonAuthenticatedFilter))]

        [HttpPost]
        public IActionResult Register(UserRegisterVM model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User u = new User()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Username = model.Username

            };
            repo.Save(u);

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            AuthService.LoggedUser = null;
            return RedirectToAction("Login");
        }
    }
}
