using JobOffer.Filters;
using JobOffer.Models;
using JobOffer.Repositories;
using JobOffer.Repositories.Abstraction;
using JobOffer.Services;
using JobOffer.ViewModels.JobOffers;
using JobOffer.ViewModels.UserApplications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Controllers
{
    //ako nqma lognat potrbitel go prenasochva kum login form
    [ServiceFilter(typeof(AuthenticatedFilter))]

    public class JobOfferController : Controller
    {
        private IJobOffersRepository repo;
        public JobOfferController(IJobOffersRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult List(int? id)
        {
            List<JobOfferModel> items;
            if (id.HasValue)
            {
                items = repo.GetByCreatorId(id.Value).ToList();
            }
            else
            {
                 items = repo.GetAll().ToList();

            }

            var vms = new List<JobOfferListVM>();

            foreach (var item  in items)
            {
                vms.Add(new JobOfferListVM()
                {
                    ID = item.ID,
                    Title = item.Title,
                    Description = item.Description,
                    CreatorName = $"{item.Creator.FirstName} {item.Creator.LastName}"
                });

            }
            return View(vms);
        }

        //public IActionResult ListForUser()
        //{
        //    var entities = repo.GetByCreatorId(AuthService.LoggedUser.ID);

        //    var viewModels = new List<JobOfferListVM>();

        //    foreach (var item in entities)
        //    {
        //        viewModels.Add(new JobOfferListVM()
        //        {
        //            ID = item.ID,
        //            Title = item.Title,
        //            Description = item.Description,
        //            CreatorName = $"{AuthService.LoggedUser.FirstName} {AuthService.LoggedUser.LastName}"

        //        });
        //    }

        //    return View(vms);
        //}

        public IActionResult Edit(int id)
        {
            var item = repo.GetById(id);

            if (item == null)
            {
                return View(new JobOfferEditVM());
            }
            var editVM = new JobOfferEditVM()
            {
                ID = item.ID,
                CreatorId = item.ID,
                Title = item.Title,
                Description = item.Description
            
            };


            return View(editVM);
        }

        [HttpPost]
        public IActionResult Edit(JobOfferEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var item = repo.GetById(model.ID);

            if (item ==null)
            {
                item = new Models.JobOfferModel();
                item.CreatorId = AuthService.LoggedUser.ID;
            }

            item.Title = model.Title;
            item.Description = model.Description;
            repo.Save(item);
            return RedirectToAction("List");

        }

        public IActionResult Details(int id)
        {
            var item = repo.GetByIdFull(id);

            if (item == null)
            {
                return RedirectToAction("List");
            }

            var detailsVM = new JobOfferDetailsVM()
            {
                ID = item.ID,
                Title = item.Title,
                Description = item.Description,
                CreatorName = $"{item.Creator.FirstName} {item.Creator.LastName}",
                HasApplied = item.UserApplications.Exists(item => item.UserId == AuthService.LoggedUser.ID),
                UserApplications = new UserApplicationListVM()
                {
                    UserApplications = item.UserApplications.Select(app => new UserApplicationDetailsVM
                    {
                        Id = app.ID,
                        Status = app.Status,
                        ApplicationName = $"{app.User.FirstName} {app.User.LastName}",
                        JobOfferName = app.JobOffer.Title
                    }).ToList()
            
                }
            };

            return View(detailsVM);
        }

        public IActionResult Delete(int id)
        {
            repo.DeleteAll(id);

            return RedirectToAction("List");
        }
    }
}
