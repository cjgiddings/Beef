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
    /// Represents the US State entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [ReferenceDataInterface(typeof(IReferenceData))]
    public partial class USState : ReferenceDataBaseGuid
    {
        #region Operator

        /// <summary>
        /// An implicit cast from an <b>Id</b> to a <see cref="USState"/>.
        /// </summary>
        /// <param name="id">The <b>Id</b>.</param>
        /// <returns>The corresponding <see cref="USState"/>.</returns>
        [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Improves useability")]
        public static implicit operator USState(Guid id) => ConvertFromId<USState>(id);

        /// <summary>
        /// An implicit cast from a <b>Code</b> to a <see cref="USState"/>.
        /// </summary>
        /// <param name="code">The <b>Code</b>.</param>
        /// <returns>The corresponding <see cref="USState"/>.</returns>
        [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Improves useability")]
        public static implicit operator USState(string? code) => ConvertFromCode<USState>(code);

        #endregion
    
        #region ICopyFrom
    
        /// <summary>
        /// Performs a copy from another <see cref="USState"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="USState"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<USState>(from);
            CopyFrom(fval);
        }
        
        /// <summary>
        /// Performs a copy from another <see cref="USState"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="USState"/> to copy from.</param>
        public void CopyFrom(USState from)
        {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            CopyFrom((ReferenceDataBaseGuid)from);

            OnAfterCopyFrom(from);
        }

        #endregion

        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="USState"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="USState"/>.</returns>
        public override object Clone()
        {
            var clone = new USState();
            clone.CopyFrom(this);
            return clone;
        }
        
        #endregion
        
        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="USState"/> resetting property values as appropriate to ensure a basic level of data consistency.
        /// </summary>
        public override void CleanUp()
        {
            base.CleanUp();

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
                if (!base.IsInitial)
                    return false;

                return true;
            }
        }

        #endregion

        #region PartialMethods
      
        partial void OnAfterCleanUp();

        partial void OnAfterCopyFrom(USState from);

        #endregion
    }

    #region Collection

    /// <summary>
    /// Represents the <see cref="USState"/> collection.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Tightly coupled; OK.")]
    public partial class USStateCollection : ReferenceDataCollectionBase<USState>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="USStateCollection"/> class.
        /// </summary>
        public USStateCollection() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="USStateCollection"/> class with an entities range.
        /// </summary>
        /// <param name="entities">The <see cref="USState"/> entities.</param>
        public USStateCollection(IEnumerable<USState> entities) => AddRange(entities);
    }

    #endregion  
}

#pragma warning restore CA2227, CA1819
#pragma warning restore IDE0005
#nullable restore