using JobOffer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Repositories.Abstraction
{
    public interface IBaseRepository<T> where T:BaseModel
    {
        //opisvat metodite koito moje da izpulnqva db CRUD
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T item);
        void Create(T item);
        void Save(T item);
        void Delete(int id);
    }
}
