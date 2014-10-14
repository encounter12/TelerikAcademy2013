namespace WebServicesExam.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using WebServicesExam.Data;
    using WebServicesExam.Models;
    using WebServicesExam.WebApi.Models;
    using WebServicesExam.WebApi.Infrastructure;
    using System.Net;

    public class ScoresController : BaseApiController
    {
        public ScoresController(IApplicationData data, IUserIdProvider userIdProvider) :
            base(data, userIdProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}