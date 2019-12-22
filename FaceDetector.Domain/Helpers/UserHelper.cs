using System;
using System.Linq;

using FaceDetector.Domain.Models.Common;

using Microsoft.AspNetCore.Http;

namespace FaceDetector.Services.Helpers
{
    public class UserHelper
    {
        public static Guid GetUserId(IHttpContextAccessor _contextAccessor)
        {
            try
            {
                return Guid.Parse(_contextAccessor.HttpContext.User.FindFirst("UserId")?.Value);
            }
            catch
            {
                throw new FaceAppException("Unauthorized", 401);
            }
        }

        public static Guid? GetUserIdNoException(IHttpContextAccessor _contextAccessor)
        {
            try
            {
                return Guid.Parse(_contextAccessor.HttpContext.User.FindFirst("UserId")?.Value);
            }
            catch
            {
                return null;
            }
        }
    }
}
