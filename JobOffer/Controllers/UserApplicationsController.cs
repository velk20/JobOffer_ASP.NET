using JobOffer.Filters;
using JobOffer.Models;
using JobOffer.Repositories;
using JobOffer.Repositories.Abstraction;
using JobOffer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Controllers
{
    [ServiceFilter(typeof(AuthenticatedFilter))]
    public class UserApplicationsController : Controller
    {
        private readonly IJobOffersRepository jobOffersRepository;
        private readonly IUserApplicationRepository userApplicationRepository;

        public UserApplicationsController(IJobOffersRepository repo, IUserApplicationRepository userApplicationRepository)
        {
            jobOffersRepository = repo;
            this.userApplicationRepository = userApplicationRepository;
        }
        public IActionResult Apply(int jobOfferId)
        {
            JobOfferModel offer = jobOffersRepository.GetById(jobOfferId);

            if (offer == null)
            {
                return RedirectToAction("List","JobOffer");
            }

            this.userApplicationRepository.Save(new UserApplication
            {
                JobOfferId = offer.ID,
                UserId = AuthService.LoggedUser.ID,
                Status = UserApplicationStatus.Pending
            }); ;
            return RedirectToAction("Details","JobOffer",new { id = offer.ID});
        }

        public IActionResult Accept(int applicationId)
        {
            UserApplication application = userApplicationRepository.GetById(applicationId);
            if (application == null)
            {
                return RedirectToAction("List", "JobOffer");
            }

            if (application.Status == UserApplicationStatus.Accepted)
            {
                return RedirectToAction("Details", "JobOffer", new { id = application.JobOfferId });
            }

            application.Status = UserApplicationStatus.Accepted;
            userApplicationRepository.Save(application);
            return RedirectToAction("Details", "JobOffer", new { id = application.JobOfferId });

        }
        
        public IActionResult Reject(int applicationId)
        {
            UserApplication application = userApplicationRepository.GetById(applicationId);
            if (application == null)
            {
                return RedirectToAction("List", "JobOffer");
            }

            if (application.Status == UserApplicationStatus.Rejected)
            {
                return RedirectToAction("Details", "JobOffer", new { id = application.JobOfferId });
            }

            application.Status = UserApplicationStatus.Rejected;
            userApplicationRepository.Save(application);
            return RedirectToAction("Details", "JobOffer", new { id = application.JobOfferId });

        }
    }
}
