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
    public class BaseRepository<T>:IBaseRepository<T> where T:BaseModel
    {
        protected readonly DbContext _context;//samata baza danni
        protected readonly DbSet<T> _dbSet;//tablicata koqto iskame da rabotim 

        public BaseRepository(DbContext context)
        {
            this._context = context;
            _dbSet = _context.Set<T>();

        }


        public void Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return;
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(u=>u.ID == id);
        }

        public void Save(T item)
        {
            if (item.ID != 0)
            {
                Update(item);
            }
            else Create(item);
        }

        public void Update(T item)
        {
           
            _context.Entry(item).State = EntityState.Modified;//za da go promenim
            _context.SaveChanges();
        }
    }
}
