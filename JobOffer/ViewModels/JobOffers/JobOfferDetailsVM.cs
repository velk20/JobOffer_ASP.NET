﻿using JobOffer.ViewModels.UserApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.ViewModels.JobOffers
{
    public class JobOfferDetailsVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string CreatorName { get; set; }
        public bool HasApplied { get; set; }
        public UserApplicationListVM UserApplications { get; set; }
    }
}
