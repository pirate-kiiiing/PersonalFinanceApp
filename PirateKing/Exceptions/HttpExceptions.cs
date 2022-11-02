﻿using System;
using System.Net;
using PirateKing.Core;

namespace PirateKing.Exceptions
{
    public class HttpExceptions
    {
        #region Client Errors

        public static HttpException BadRequestException(object content = null, string message = null)
        {
            return new HttpException(HttpStatusCode.BadRequest, message)
            {
                Content = content,
            };
        }

        public static HttpException UnauthorizedException(object content = null, string message = null)
        {
            return new HttpException(HttpStatusCode.Unauthorized, message)
            {
                Content = content,
            };
        }

        public static HttpException NotFoundException(object content = null, string message = null)
        {
            return new HttpException(HttpStatusCode.NotFound, message)
            {
                Content = content,
            };
        }

        #endregion

        #region Service Errors

        #endregion
    }
}
