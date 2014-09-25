namespace BullsAndCows.WebApi.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading;
    using Microsoft.AspNet.Identity;

    public class AspNetUserIdProvider : IUserIdProvider
    {
        public string GetUserId()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}