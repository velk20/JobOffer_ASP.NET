using JobOffer.Models;
using JobOffer.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Repositories
{
    public class JobOffersRepository :BaseRepository<JobOfferModel>,IJobOffersRepository
    {
       
        public JobOffersRepository(JobOfferContext context):base(context)
        {

        }

        public JobOfferModel GetByIdFull (int id)
        { 
           return _dbSet
                .Include(jo => jo.UserApplications)
                .Include(jobOffer=>jobOffer.Creator)
                .FirstOrDefault(jojo => jojo.ID == id);
        }

        public IEnumerable<JobOfferModel> GetByCreatorId(int id)
        {
            return _dbSet.Where(jo => jo.CreatorId == id);
        }

       

        public void DeleteAll(int id)
        {
            var jobOffer = GetByIdFull(id);
            if (jobOffer == null)
            {
                return;
            }

            _context.Set<UserApplication>().RemoveRange(jobOffer.UserApplications);
            _dbSet.Remove(jobOffer);

            _context.SaveChanges();
        }
    }
}
