using JobOffer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Repositories.Abstraction
{
    public interface IJobOffersRepository:IBaseRepository<JobOfferModel>
    {
        //opisvat metodite koito moje da izpulnqva db CRUD

        IEnumerable<JobOfferModel> GetByCreatorId(int id);
        JobOfferModel GetByIdFull(int id);
        void DeleteAll(int id);
    }
}
