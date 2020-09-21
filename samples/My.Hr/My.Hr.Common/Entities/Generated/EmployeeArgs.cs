/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options
#pragma warning disable CA2227, CA1819 // Collection/Array properties should be read only; ignored, as acceptable for a DTO.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Beef.RefData;
using Newtonsoft.Json;
using RefDataNamespace = My.Hr.Common.Entities;

namespace My.Hr.Common.Entities
{
    /// <summary>
    /// Represents the <see cref="Employee"/> search arguments entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class EmployeeArgs : EntityBase, IEquatable<EmployeeArgs>
    {
        #region Privates

        private string? _firstName;
        private string? _lastName;
        private List<string>? _gendersSids;
        private DateTime? _startFrom;
        private DateTime? _startTo;
        private bool? _isIncludeTerminated;

        #endregion

        #region Properties

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
        /// Gets or sets the <see cref="Genders"/> list using the underlying Serialization Identifier (SID).
        /// </summary>
        [JsonProperty("genders", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Genders")]
        public List<string>? GendersSids
        {
            get => _gendersSids;
            set => SetValue(ref _gendersSids, value, false, false, nameof(Genders));
        }

        /// <summary>
        /// Gets or sets the Genders (see <see cref="RefDataNamespace.Gender"/>).
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Display(Name="Genders")]
        public ReferenceDataSidList<RefDataNamespace.Gender, string>? Genders
        {
            get => new ReferenceDataSidList<RefDataNamespace.Gender, string>(ref _gendersSids);
            set => SetValue(ref _gendersSids, value?.ToSidList(), false, false, nameof(Genders));
        }

        /// <summary>
        /// Gets or sets the Start From.
        /// </summary>
        [JsonProperty("startFrom", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Start From")]
        public DateTime? StartFrom
        {
            get => _startFrom;
            set => SetValue(ref _startFrom, value, false, DateTimeTransform.DateOnly, nameof(StartFrom));
        }

        /// <summary>
        /// Gets or sets the Start To.
        /// </summary>
        [JsonProperty("startTo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Start To")]
        public DateTime? StartTo
        {
            get => _startTo;
            set => SetValue(ref _startTo, value, false, DateTimeTransform.DateOnly, nameof(StartTo));
        }

        /// <summary>
        /// Indicates whether Is Include Terminated.
        /// </summary>
        [JsonProperty("includeTerminated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Is Include Terminated")]
        public bool? IsIncludeTerminated
        {
            get => _isIncludeTerminated;
            set => SetValue(ref _isIncludeTerminated, value, false, false, nameof(IsIncludeTerminated));
        }

        #endregion

        #region IEquatable

        /// <summary>
        /// Determines whether the specified object is equal to the current object by comparing the values of all the properties.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj) => obj is EmployeeArgs val && Equals(val);

        /// <summary>
        /// Determines whether the specified <see cref="EmployeeArgs"/> is equal to the current <see cref="EmployeeArgs"/> by comparing the values of all the properties.
        /// </summary>
        /// <param name="value">The <see cref="EmployeeArgs"/> to compare with the current <see cref="EmployeeArgs"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="EmployeeArgs"/> is equal to the current <see cref="EmployeeArgs"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(EmployeeArgs? value)
        {
            if (value == null)
                return false;
            else if (ReferenceEquals(value, this))
                return true;

            return base.Equals((object)value)
                && Equals(FirstName, value.FirstName)
                && Equals(LastName, value.LastName)
                && Equals(GendersSids, value.GendersSids)
                && Equals(StartFrom, value.StartFrom)
                && Equals(StartTo, value.StartTo)
                && Equals(IsIncludeTerminated, value.IsIncludeTerminated);
        }

        /// <summary>
        /// Compares two <see cref="EmployeeArgs"/> types for equality.
        /// </summary>
        /// <param name="a"><see cref="EmployeeArgs"/> A.</param>
        /// <param name="b"><see cref="EmployeeArgs"/> B.</param>
        /// <returns><c>true</c> indicates equal; otherwise, <c>false</c> for not equal.</returns>
        public static bool operator == (EmployeeArgs? a, EmployeeArgs? b) => Equals(a, b);

        /// <summary>
        /// Compares two <see cref="EmployeeArgs"/> types for non-equality.
        /// </summary>
        /// <param name="a"><see cref="EmployeeArgs"/> A.</param>
        /// <param name="b"><see cref="EmployeeArgs"/> B.</param>
        /// <returns><c>true</c> indicates not equal; otherwise, <c>false</c> for equal.</returns>
        public static bool operator != (EmployeeArgs? a, EmployeeArgs? b) => !Equals(a, b);

        /// <summary>
        /// Returns the hash code for the <see cref="EmployeeArgs"/>.
        /// </summary>
        /// <returns>The hash code for the <see cref="EmployeeArgs"/>.</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(FirstName);
            hash.Add(LastName);
            hash.Add(GendersSids);
            hash.Add(StartFrom);
            hash.Add(StartTo);
            hash.Add(IsIncludeTerminated);
            return base.GetHashCode() ^ hash.ToHashCode();
        }
    
        #endregion

        #region ICopyFrom
    
        /// <summary>
        /// Performs a copy from another <see cref="EmployeeArgs"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="EmployeeArgs"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<EmployeeArgs>(from);
            CopyFrom(fval);
        }
        
        /// <summary>
        /// Performs a copy from another <see cref="EmployeeArgs"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="EmployeeArgs"/> to copy from.</param>
        public void CopyFrom(EmployeeArgs from)
        {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            CopyFrom((EntityBase)from);
            FirstName = from.FirstName;
            LastName = from.LastName;
            GendersSids = from.GendersSids;
            StartFrom = from.StartFrom;
            StartTo = from.StartTo;
            IsIncludeTerminated = from.IsIncludeTerminated;

            OnAfterCopyFrom(from);
        }

        #endregion

        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="EmployeeArgs"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="EmployeeArgs"/>.</returns>
        public override object Clone()
        {
            var clone = new EmployeeArgs();
            clone.CopyFrom(this);
            return clone;
        }
        
        #endregion
        
        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="EmployeeArgs"/> resetting property values as appropriate to ensure a basic level of data consistency.
        /// </summary>
        public override void CleanUp()
        {
            base.CleanUp();
            FirstName = Cleaner.Clean(FirstName, StringTrim.UseDefault, StringTransform.UseDefault);
            LastName = Cleaner.Clean(LastName, StringTrim.UseDefault, StringTransform.UseDefault);
            GendersSids = Cleaner.Clean(GendersSids);
            StartFrom = Cleaner.Clean(StartFrom, DateTimeTransform.DateOnly);
            StartTo = Cleaner.Clean(StartTo, DateTimeTransform.DateOnly);
            IsIncludeTerminated = Cleaner.Clean(IsIncludeTerminated);

            OnAfterCleanUp();
        }

        /// <summary>
        /// Indicates whether considered initial; i.e. all properties have their initial value.
        /// </summary>
        /// <returns><c>true</c> indicates is initial; otherwise, <c>false</c>.</returns>
        public override bool IsInitial
        {
            get
            {
                return Cleaner.IsInitial(FirstName)
                    && Cleaner.IsInitial(LastName)
                    && Cleaner.IsInitial(GendersSids)
                    && Cleaner.IsInitial(StartFrom)
                    && Cleaner.IsInitial(StartTo)
                    && Cleaner.IsInitial(IsIncludeTerminated);
            }
        }

        #endregion

        #region PartialMethods
      
        partial void OnAfterCleanUp();

        partial void OnAfterCopyFrom(EmployeeArgs from);

        #endregion
    }
}

#pragma warning restore CA2227, CA1819
#pragma warning restore IDE0005
#nullable restore