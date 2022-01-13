using AutoMapper;
using JobOffer.Models;
using JobOffer.Repositories.Abstraction;
using JobOffer.Services.Abstractions;
using JobOffer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Services.Implementations
{
    public class BaseService<TModel, TDetailsVM,TEditVM>: IBaseService<TModel, TDetailsVM, TEditVM>
         where TModel : BaseModel
        where TDetailsVM : BaseViewModel
        where TEditVM : BaseViewModel
    {
        protected readonly IBaseRepository<TModel> repository;
        protected readonly IMapper mapper;
        public BaseService(IBaseRepository<TModel> repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public List<TDetailsVM> GetAll()
        {
            return repository.GetAll().Select(item => mapper.Map<TModel,TDetailsVM>(item)).ToList();
        }

        public TDetailsVM GetById(int id)
        {
            var item = repository.GetById(id);
            return this.mapper.Map<TModel, TDetailsVM>(item);
        }

        public void Insert(TEditVM item)
        {
            TModel model = mapper.Map<TModel>(item);
            repository.Create(model);
        }

        public void Update(TEditVM item)
        {
            TModel model = mapper.Map<TModel>(item);
            repository.Update(model);
        }

        public void Save(TEditVM item)
        {
            if (item.ID != 0)
            {
                Update(item);
            }else
            {
                Insert(item);
            }
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
