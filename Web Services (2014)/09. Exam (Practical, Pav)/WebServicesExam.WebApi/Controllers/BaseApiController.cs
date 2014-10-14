namespace WebServicesExam.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using WebServicesExam.Data;
    using WebServicesExam.WebApi.Infrastructure;
    
    public abstract class BaseApiController : ApiController
    {
        protected BaseApiController(IApplicationData data, IUserIdProvider userIdProvider)
        {
            this.Data = data;
            this.UserIdProvider = userIdProvider;
        }

        protected IApplicationData Data { get; set; }

        protected IUserIdProvider UserIdProvider { get; set; }
    }
}