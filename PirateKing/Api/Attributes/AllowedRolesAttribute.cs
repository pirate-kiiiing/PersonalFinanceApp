﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using PirateKing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PirateKing.Api.Attributes
{
    public class AllowedRolesAttribute : TypeFilterAttribute
    {
        public AllowedRolesAttribute(params UserRole[] userRoles) : base(typeof(AllowedRolesFilter))
        {
            Arguments = new object[] { userRoles };
        }
    }

    public class AllowedRolesFilter : IAuthorizationFilter
    {
        private readonly HashSet<string> userRoles;

        public AllowedRolesFilter(UserRole[] userRoles)
        {
            this.userRoles = new HashSet<string>(userRoles.Select(r => r.ToString()));
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            IPrincipal principal = context.HttpContext.User;

            if (principal.Identity.IsAuthenticated == false)
            {
                context.Result = new UnauthorizedResult();

                return;
            }

            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == ClaimTypes.Role && userRoles.Contains(c.Value));
            
            if (hasClaim == false)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
