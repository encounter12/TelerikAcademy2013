namespace BullsAndCows.WebApi.Infrastructure
{
    using System;
    using System.Linq;

    public interface IUserIdProvider
    {
        string GetUserId();
    }
}
