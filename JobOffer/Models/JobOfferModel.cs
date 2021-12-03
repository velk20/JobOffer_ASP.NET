using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Models
{
    public class JobOfferModel:BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public virtual   List<UserApplication> UserApplications { get; set; }
    }
}
