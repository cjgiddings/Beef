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

namespace My.Hr.Common.Entities
{
    /// <summary>
    /// Represents the <see cref="Employee"/> base entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class EmployeeBase : IGuidIdentifier, IUniqueKey
    {
        /// <summary>
        /// Gets or sets the <see cref="Employee"/> identifier.
        /// </summary>
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Unique <see cref="Employee"/> Email.
        /// </summary>
        [JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the First Name.
        /// </summary>
        [JsonProperty("firstName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Last Name.
        /// </summary>
        [JsonProperty("lastName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the Gender (see <see cref="RefDataNamespace.Gender"/>).
        /// </summary>
        [JsonProperty("gender", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Gender { get; set; }

        /// <summary>
        /// Gets or sets the Birthday.
        /// </summary>
        [JsonProperty("birthday", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets the Start Date.
        /// </summary>
        [JsonProperty("startDate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the Termination (see <see cref="Common.Entities.TerminationDetail"/>).
        /// </summary>
        [JsonProperty("termination", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TerminationDetail? Termination { get; set; }

        /// <summary>
        /// Gets or sets the Phone No.
        /// </summary>
        [JsonProperty("phoneNo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? PhoneNo { get; set; }

        /// <summary>
        /// Gets the list of property names that represent the unique key.
        /// </summary>
        public string[] UniqueKeyProperties => new string[] { nameof(Id) };
        
        /// <summary>
        /// Creates the <see cref="UniqueKey"/>.
        /// </summary>
        /// <returns>The <see cref="Beef.Entities.UniqueKey"/>.</returns>
        /// <param name="id">The <see cref="Id"/>.</param>
        public static UniqueKey CreateUniqueKey(Guid id) => new UniqueKey(id);

        /// <summary>
        /// Gets the <see cref="UniqueKey"/> (consists of the following property(s): <see cref="Id"/>).
        /// </summary>
        public UniqueKey UniqueKey => CreateUniqueKey(Id);
    }

    /// <summary>
    /// Represents the <see cref="EmployeeBase"/> collection.
    /// </summary>
    public partial class EmployeeBaseCollection : List<EmployeeBase> { }

    /// <summary>
    /// Represents the <see cref="EmployeeBase"/> collection result.
    /// </summary>
    public class EmployeeBaseCollectionResult : CollectionResult<EmployeeBaseCollection, EmployeeBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBaseCollectionResult"/> class.
        /// </summary>
        public EmployeeBaseCollectionResult() { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBaseCollectionResult"/> class with <paramref name="paging"/>.
        /// </summary>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public EmployeeBaseCollectionResult(PagingArgs? paging) : base(paging) { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBaseCollectionResult"/> class with a <paramref name="collection"/> of items to add.
        /// </summary>
        /// <param name="collection">A collection containing items to add.</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public EmployeeBaseCollectionResult(IEnumerable<EmployeeBase> collection, PagingArgs? paging = null) : base(paging) => Result.AddRange(collection);
    }
}

#pragma warning restore
#nullable restore