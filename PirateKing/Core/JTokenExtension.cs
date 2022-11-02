﻿using System;
using Newtonsoft.Json.Linq;

namespace PirateKing.Core
{
    public static class JTokenExtensions
    {
        public static byte ToByte(this JToken jtoken)
        {
            return Convert.ToByte(jtoken);
        }
        public static decimal ToDecimal(this JToken jtoken)
        {
            return Convert.ToDecimal(jtoken);
        }
        public static short ToShort(this JToken jtoken)
        {
            return Convert.ToInt16(jtoken);
        }
        public static int ToInt(this JToken jtoken)
        {
            return Convert.ToInt32(jtoken);
        }
        public static long ToLong(this JToken jtoken)
        {
            return Convert.ToInt64(jtoken);
        }
        public static bool ToBoolean(this JToken jtoken)
        {
            return Convert.ToBoolean(jtoken);
        }
        public static DateTime ToDateTime(this JToken jtoken)
        {
            return Convert.ToDateTime(jtoken);
        }
        public static byte? ToNullableByte(this JToken jtoken)
        {
            return (jtoken.Type == JTokenType.Null) ? null : (byte?)Convert.ToByte(jtoken);
        }
        public static decimal? ToNullableDecimal(this JToken jtoken)
        {
            return (jtoken.Type == JTokenType.Null) ? null : (decimal?)Convert.ToDecimal(jtoken);
        }
        public static short? ToNullableShort(this JToken jtoken)
        {
            return (jtoken.Type == JTokenType.Null) ? null : (short?)Convert.ToInt16(jtoken);
        }
        public static int? ToNullableInt(this JToken jtoken)
        {
            return (jtoken.Type == JTokenType.Null) ? null : (int?)Convert.ToInt32(jtoken);
        }
        public static long? ToNullableLong(this JToken jtoken)
        {
            return (jtoken.Type == JTokenType.Null) ? null : (long?)Convert.ToInt64(jtoken);
        }
        public static string ToNullableString(this JToken jtoken)
        {
            return (jtoken.Type == JTokenType.Null) ? null : jtoken.ToString();
        }
    }
}
