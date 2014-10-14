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

    public class NotificationsController : BaseApiController
    {
        public NotificationsController(IApplicationData data, IUserIdProvider userIdProvider) :
            base(data, userIdProvider)
        {
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
            var currentUserId = this.UserIdProvider.GetUserId();

            var notifications = this.Data.Notifications.All()
                .Where(n => n.User.Id == currentUserId)
                .OrderByDescending(n => n.DateCreated)
                .Select(NotificationModel.FromNotification)
                .Take(10);

            return Ok(notifications);
        }

        [HttpGet]
        [Authorize]
        public HttpResponseMessage Next()
        {
            var currentUserId = this.UserIdProvider.GetUserId();

            var notification = this.Data.Notifications.All()
                .Where(n => n.User.Id == currentUserId && n.State == NotificationState.Unread)
                .OrderBy(n => n.DateCreated)
                .Select(NotificationModel.FromNotification)
                .FirstOrDefault();

            if (notification != null)
            {
                return this.Request.CreateResponse<NotificationModel>(HttpStatusCode.OK, notification);
            }

            return this.Request.CreateResponse(HttpStatusCode.NotModified);
        }
    }
}