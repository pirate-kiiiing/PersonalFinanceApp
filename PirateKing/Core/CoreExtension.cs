﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PirateKing.Core
{
    public static class CoreExtension
    {
        public static string Serialize(this object value)
        {
            return JsonConvert.SerializeObject(
                value,
                Formatting.None,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        public static T Deserialize<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public static bool TryDeserialize<T>(this string value, out T result)
        {
            try
            {
                result = Deserialize<T>(value);

                return true;
            }
            catch
            {
                result = default;

                return false;
            }
        }

        public async static Task<T> ReadContentAsAsync<T>(this HttpResponseMessage httpResponse)
        {
            httpResponse = httpResponse ?? throw new ArgumentNullException($"Invalid {nameof(httpResponse)}");

            string content = await httpResponse.Content.ReadAsStringAsync();
            
            return content.Deserialize<T>();
        }
    }
}
