using AutoMapper;
using JobOffer.Models;
using JobOffer.ViewModels.Auth;
using JobOffer.ViewModels.JobOffers;
using JobOffer.ViewModels.UserApplications;
using JobOffer.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Services.AutoMapper
{
    public class AutoMapperConfiguration: Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<User, UserDetailsVM>();
            CreateMap<User, UserEditVM>();

            CreateMap<JobOfferModel, JobOfferDetailsVM>()
                .ForMember(detailsVM => detailsVM.CreatorName, model => model.MapFrom(offer => $"{offer.Creator.FirstName} {offer.Creator.LastName}"))
                .ForMember(detailsVM => detailsVM.UserApplications, model => model.MapFrom(offer => offer.UserApplications));
            CreateMap<JobOfferModel, JobOfferEditVM>();

            CreateMap<UserApplication, UserApplicationEditVM>();
            CreateMap<UserApplication, UserApplicationDetailsVM>()
                .ForMember(detailsVM => detailsVM.ApplicationName, model => model.MapFrom(app => $"{app.User.FirstName} {app.User.LastName}"))
                .ForMember(detailsVM => detailsVM.JobOfferName, model => model.MapFrom(app => app.JobOffer.Title))
                .ForMember(detailsVm => detailsVm.Status, model => model.MapFrom(app => app.Status));

            CreateMap<UserEditVM, User>();
            CreateMap<UserRegisterVM, User>();

            CreateMap<JobOfferEditVM, JobOfferModel>()
                .ForMember(model => model.CreatorId, vm => vm.MapFrom(editVm => editVm.CreatorId))
                .ForMember(model => model.UserApplications, vm => vm.Ignore())
                .ForMember(model => model.Creator, vm => vm.Ignore());

            CreateMap<UserApplicationEditVM, UserApplication>();

        }
    }
}
