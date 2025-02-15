/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using Beef.Data.Database.Cdc;
using Beef.Entities;
using Beef.Mapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Beef.Demo.CdcPublisher.Entities
{
    /// <summary>
    /// Represents the CDC model for the root (parent) database table 'Demo.Person'.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class PersonCdc : ITableKey, IETag
    {
        /// <summary>
        /// Gets or sets the 'Person Id' (Demo.Person.PersonId) column value.
        /// </summary>
        [JsonProperty("personId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid PersonId { get; set; }

        /// <summary>
        /// Gets or sets the entity tag (calculated as a JSON serialized hash value).
        /// </summary>
        [JsonProperty("etag", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [MapperIgnore()]
        public string? ETag { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [MapperIgnore()]
        public UniqueKey UniqueKey => new UniqueKey(PersonId);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [MapperIgnore()]
        public string[] UniqueKeyProperties => new string[] { nameof(PersonId) };

        /// <summary>
        /// Gets or sets the 'Person Id' <i>primary key</i> (Demo.Person.PersonId) column value (from the actual database table primary key; not from the change-data-capture source).
        /// </summary>
        /// <remarks>Will have a <c>default</c> value when the record no longer exists within the database (i.e. has been physically deleted).</remarks>
        public Guid TableKey_PersonId { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <remarks><inheritdoc/></remarks>
        public UniqueKey TableKey => new UniqueKey(TableKey_PersonId);
    }
}

#pragma warning restore
#nullable restore