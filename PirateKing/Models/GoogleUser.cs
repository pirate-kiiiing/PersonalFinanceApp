﻿using System;
using Newtonsoft.Json;

namespace PirateKing.Models
{
    /// <summary>
    /// Google User
    /// </summary>
    public class GoogleUser : AzureDocumentBase
    {
        public GoogleUser(string etag, long timestamp) : base(etag, timestamp) { }

        [JsonProperty(PropertyName = "id")]
        public string GoogleUserId { get; set; }

        [JsonProperty(PropertyName = "tenantId")]
        public Guid TenantId { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public Guid UserId { get; set; }
    }
}
