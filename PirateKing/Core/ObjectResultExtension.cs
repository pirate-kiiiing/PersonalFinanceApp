﻿using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace PirateKing.Core
{
    public static class ObjectResultExtension
    {
        public static ObjectResult StatusCodeResult(this ObjectResult actionResult, HttpStatusCode statusCode)
        {
            actionResult.StatusCode = (int) statusCode;

            return actionResult;
        }

        public static ObjectResult BadRequest(this ObjectResult actionResult)
        {
            return StatusCodeResult(actionResult, HttpStatusCode.BadRequest);
        }

        public static ObjectResult Unauthorized(this ObjectResult actionResult)
        {
            return StatusCodeResult(actionResult, HttpStatusCode.Unauthorized);
        }

        public static ObjectResult NotFound(this ObjectResult actionResult)
        {
            return StatusCodeResult(actionResult, HttpStatusCode.NotFound);
        }

        public static ObjectResult InternalServerError(this ObjectResult actionResult)
        {
            return StatusCodeResult(actionResult, HttpStatusCode.InternalServerError);
        }
    }
}
