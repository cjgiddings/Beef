/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Beef.RefData;
using Newtonsoft.Json;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.Entities
{
    /// <summary>
    /// Represents the Contact entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class Contact : EntityBase, IGuidIdentifier, IUniqueKey, IEquatable<Contact>
    {
        #region Privates

        private Guid _id;
        private string? _firstName;
        private string? _lastName;
        private string? _statusSid;
        private string? _statusText;
        private string? _internalCode;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="Contact"/> identifier.
        /// </summary>
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        [Display(Name="Identifier")]
        public Guid Id
        {
            get => _id;
            set => SetValue(ref _id, value, false, false, nameof(Id));
        }

        /// <summary>
        /// Gets or sets the First Name.
        /// </summary>
        [JsonProperty("firstName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="First Name")]
        public string? FirstName
        {
            get => _firstName;
            set => SetValue(ref _firstName, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(FirstName));
        }

        /// <summary>
        /// Gets or sets the Last Name.
        /// </summary>
        [JsonProperty("lastName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Last Name")]
        public string? LastName
        {
            get => _lastName;
            set => SetValue(ref _lastName, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(LastName));
        }

        /// <summary>
        /// Gets or sets the <see cref="Status"/> using the underlying Serialization Identifier (SID).
        /// </summary>
        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Status")]
        public string? StatusSid
        {
            get => _statusSid;
            set => SetValue(ref _statusSid, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(Status));
        }

        /// <summary>
        /// Gets the corresponding <see cref="Status"/> text (read-only where selected).
        /// </summary>
        [JsonProperty("statusText", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? StatusText { get => _statusText ?? GetRefDataText(() => Status); set => _statusText = value; }

        /// <summary>
        /// Gets or sets the Status (see <see cref="RefDataNamespace.Status"/>).
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Display(Name="Status")]
        public RefDataNamespace.Status? Status
        {
            get => _statusSid;
            set => SetValue(ref _statusSid, value, false, false, nameof(Status)); 
        }

        /// <summary>
        /// Gets or sets the Internal Code.
        /// </summary>
        [JsonProperty("internalCode", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Internal Code")]
        public string? InternalCode
        {
            get => _internalCode;
            set => SetValue(ref _internalCode, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(InternalCode));
        }

        #endregion

        #region IUniqueKey
        
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

        #endregion

        #region IEquatable

        /// <summary>
        /// Determines whether the specified object is equal to the current object by comparing the values of all the properties.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj) => obj is Contact val && Equals(val);

        /// <summary>
        /// Determines whether the specified <see cref="Contact"/> is equal to the current <see cref="Contact"/> by comparing the values of all the properties.
        /// </summary>
        /// <param name="value">The <see cref="Contact"/> to compare with the current <see cref="Contact"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Contact"/> is equal to the current <see cref="Contact"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(Contact? value)
        {
            if (value == null)
                return false;
            else if (ReferenceEquals(value, this))
                return true;

            return base.Equals((object)value)
                && Equals(Id, value.Id)
                && Equals(FirstName, value.FirstName)
                && Equals(LastName, value.LastName)
                && Equals(StatusSid, value.StatusSid)
                && Equals(InternalCode, value.InternalCode);
        }

        /// <summary>
        /// Compares two <see cref="Contact"/> types for equality.
        /// </summary>
        /// <param name="a"><see cref="Contact"/> A.</param>
        /// <param name="b"><see cref="Contact"/> B.</param>
        /// <returns><c>true</c> indicates equal; otherwise, <c>false</c> for not equal.</returns>
        public static bool operator == (Contact? a, Contact? b) => Equals(a, b);

        /// <summary>
        /// Compares two <see cref="Contact"/> types for non-equality.
        /// </summary>
        /// <param name="a"><see cref="Contact"/> A.</param>
        /// <param name="b"><see cref="Contact"/> B.</param>
        /// <returns><c>true</c> indicates not equal; otherwise, <c>false</c> for equal.</returns>
        public static bool operator != (Contact? a, Contact? b) => !Equals(a, b);

        /// <summary>
        /// Returns the hash code for the <see cref="Contact"/>.
        /// </summary>
        /// <returns>The hash code for the <see cref="Contact"/>.</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(FirstName);
            hash.Add(LastName);
            hash.Add(StatusSid);
            hash.Add(InternalCode);
            return base.GetHashCode() ^ hash.ToHashCode();
        }
    
        #endregion

        #region ICopyFrom
    
        /// <summary>
        /// Performs a copy from another <see cref="Contact"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="Contact"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<Contact>(from);
            CopyFrom(fval);
        }
        
        /// <summary>
        /// Performs a copy from another <see cref="Contact"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="Contact"/> to copy from.</param>
        public void CopyFrom(Contact from)
        {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            CopyFrom((EntityBase)from);
            Id = from.Id;
            FirstName = from.FirstName;
            LastName = from.LastName;
            StatusSid = from.StatusSid;
            InternalCode = from.InternalCode;

            OnAfterCopyFrom(from);
        }

        #endregion

        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="Contact"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="Contact"/>.</returns>
        public override object Clone()
        {
            var clone = new Contact();
            clone.CopyFrom(this);
            return clone;
        }
        
        #endregion
        
        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="Contact"/> resetting property values as appropriate to ensure a basic level of data consistency.
        /// </summary>
        public override void CleanUp()
        {
            base.CleanUp();
            Id = Cleaner.Clean(Id);
            FirstName = Cleaner.Clean(FirstName, StringTrim.UseDefault, StringTransform.UseDefault);
            LastName = Cleaner.Clean(LastName, StringTrim.UseDefault, StringTransform.UseDefault);
            StatusSid = Cleaner.Clean(StatusSid);
            InternalCode = Cleaner.Clean(InternalCode, StringTrim.UseDefault, StringTransform.UseDefault);

            OnAfterCleanUp();
        }

        /// <summary>
        /// Indicates whether considered initial; i.e. all properties have their initial value.
        /// </summary>
        /// <returns><c>true</c> indicates is initial; otherwise, <c>false</c>.</returns>
        public override bool IsInitial
        {
            get => false;
        }

        #endregion

        #region PartialMethods
      
        partial void OnAfterCleanUp();

        partial void OnAfterCopyFrom(Contact from);

        #endregion
    }

    #region Collection

    /// <summary>
    /// Represents the <see cref="Contact"/> collection.
    /// </summary>
    public partial class ContactCollection : EntityBaseCollection<Contact>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactCollection"/> class.
        /// </summary>
        public ContactCollection() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactCollection"/> class with an entities range.
        /// </summary>
        /// <param name="entities">The <see cref="Contact"/> entities.</param>
        public ContactCollection(IEnumerable<Contact> entities) => AddRange(entities);

        /// <summary>
        /// Creates a deep copy of the <see cref="ContactCollection"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="ContactCollection"/>.</returns>
        public override object Clone()
        {
            var clone = new ContactCollection();
            foreach (var item in this)
            {
                clone.Add((Contact)item.Clone());
            }
                
            return clone;
        }

        /// <summary>
        /// An implicit cast from the <see cref="ContactCollectionResult"/> to a corresponding <see cref="ContactCollection"/>.
        /// </summary>
        /// <param name="result">The <see cref="ContactCollectionResult"/>.</param>
        /// <returns>The corresponding <see cref="ContactCollection"/>.</returns>
        public static implicit operator ContactCollection(ContactCollectionResult result) => result?.Result!;
    }

    #endregion  

    #region CollectionResult

    /// <summary>
    /// Represents the <see cref="Contact"/> collection result.
    /// </summary>
    public class ContactCollectionResult : EntityCollectionResult<ContactCollection, Contact>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactCollectionResult"/> class.
        /// </summary>
        public ContactCollectionResult() { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactCollectionResult"/> class with <paramref name="paging"/>.
        /// </summary>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public ContactCollectionResult(PagingArgs? paging) : base(paging) { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactCollectionResult"/> class with a <paramref name="collection"/> of items to add.
        /// </summary>
        /// <param name="collection">A collection containing items to add.</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public ContactCollectionResult(IEnumerable<Contact> collection, PagingArgs? paging = null) : base(paging) => Result.AddRange(collection);
        
        /// <summary>
        /// Creates a deep copy of the <see cref="ContactCollectionResult"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="ContactCollectionResult"/>.</returns>
        public override object Clone()
        {
            var clone = new ContactCollectionResult();
            clone.CopyFrom(this);
            return clone;
        }
    }

    #endregion
}

#pragma warning restore
#nullable restore