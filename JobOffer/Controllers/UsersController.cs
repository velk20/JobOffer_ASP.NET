using JobOffer.Filters;
using JobOffer.Models;
using JobOffer.Repositories;
using JobOffer.Repositories.Abstraction;
using JobOffer.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Controllers
{
    //ako nqma lognat potrbitel go prenasochva kum login form

    [ServiceFilter(typeof(AuthenticatedFilter))]

    public class UsersController : Controller
    {
        private IUsersRepository repo;

        public UsersController(IUsersRepository _repo)
        {
            this.repo = _repo;
        }
        public IActionResult List()
        {
            var users = repo.GetAll();// get all users from database

            var usersVm = new List<UsersListVM>();

            foreach (var user in users)
            {
                usersVm.Add(new UsersListVM()
                {
                    Email = user.Email,
                    ID = user.ID,
                    Name = $"{user.FirstName} {user.LastName}",
                    Username = user.Username
                });
            }

            return View(usersVm);
        }

        public IActionResult Edit(int id)
        {
            var user = repo.GetById(id);


            //this means we want to create NOT to edit !!
            if (user == null)
            {
                return View(new UserEditVM());
            }

            //this is for the edit
            var editVM = new UserEditVM()
            {
                ID = user.ID,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return View(editVM);
        }
        
        [HttpPost]
        public IActionResult Edit(UserEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = repo.GetById(model.ID);

            //create
            if (user == null)
                user = new User();
            

            user.Username = model.Username;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Password = model.Password;
            user.Email = model.Email;

            repo.Save(user);

            return RedirectToAction("List");
        }

        public IActionResult Details(int id)
        {
            var user = repo.GetById(id);

            if (user == null)
            {
                return RedirectToAction("List");
            }

            UserDetailsVM model = new UserDetailsVM()
            {

                ID = user.ID,
                Email = user.Email,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            repo.Delete(id);

            return RedirectToAction("List");
        }
    }
}
