using JobOffer.Models;
using JobOffer.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Repositories.Implementatons
{
    public class UserApplicationRepository:BaseRepository<UserApplication>,IUserApplicationRepository
    {
        public UserApplicationRepository(JobOfferContext context):base(context)
        {

        }
    }
}
