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
    public class UsersRepository:BaseRepository<User>,IUsersRepository
    {
        public UsersRepository(JobOfferContext context):base(context)
        {

        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return _dbSet.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
