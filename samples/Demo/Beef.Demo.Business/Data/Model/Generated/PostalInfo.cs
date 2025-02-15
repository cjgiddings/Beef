/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Newtonsoft.Json;

namespace Beef.Demo.Business.Data.Model
{
    /// <summary>
    /// Represents the Postal Info model.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class PostalInfo
    {
        /// <summary>
        /// Gets or sets the Country (see <see cref="RefDataNamespace.Country"/>).
        /// </summary>
        [JsonProperty("country abbreviation", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Country { get; set; }

        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        [JsonProperty("place name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        [JsonProperty("state abbreviation", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? State { get; set; }

        /// <summary>
        /// Gets or sets the Places.
        /// </summary>
        [JsonProperty("places", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PlaceInfoCollection? Places { get; set; }
    }
}

#pragma warning restore
#nullable restore