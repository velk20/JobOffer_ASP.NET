using JobOffer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Repositories.Abstraction
{
    public interface IUsersRepository:IBaseRepository<User>
    {
        //opisvat metodite koito moje da izpulnqva db CRUD

        User GetByUsernameAndPassword(string username, string password);
    }
}
