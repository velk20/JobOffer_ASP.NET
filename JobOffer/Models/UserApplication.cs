using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Models
{
    public class UserApplication:BaseModel
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual JobOfferModel JobOffer { get; set; }
        public int JobOfferId { get; set; }
        public UserApplicationStatus Status { get; set; }

    }

    public enum UserApplicationStatus
    {
        Pending,
        Accepted,
        Rejected
    }
}
