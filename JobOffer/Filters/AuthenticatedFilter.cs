using JobOffer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Filters
{

    //this is for non logged user to go list pages
    public class AuthenticatedFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (AuthService.LoggedUser == null)
            {
                context.HttpContext.Response.Redirect("/Auth/Login");
                context.Result = new EmptyResult();
            }        
        }
    }
}
