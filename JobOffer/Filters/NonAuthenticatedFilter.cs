using JobOffer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer.Filters
{
    //this is for when user is logged he CANNOT go to the login form without loggout
    public class NonAuthenticatedFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (AuthService.LoggedUser != null)
            {
                context.HttpContext.Response.Redirect("/Users/List");
                context.Result = new EmptyResult();
            }
        }
    }
}
