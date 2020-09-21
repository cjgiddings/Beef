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
    /// Represents the Performance Outcome entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [ReferenceDataInterface(typeof(IReferenceData))]
    public partial class PerformanceOutcome : ReferenceDataBaseGuid
    {
        #region Operator

        /// <summary>
        /// An implicit cast from an <b>Id</b> to a <see cref="PerformanceOutcome"/>.
        /// </summary>
        /// <param name="id">The <b>Id</b>.</param>
        /// <returns>The corresponding <see cref="PerformanceOutcome"/>.</returns>
        [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Improves useability")]
        public static implicit operator PerformanceOutcome(Guid id) => ConvertFromId<PerformanceOutcome>(id);

        /// <summary>
        /// An implicit cast from a <b>Code</b> to a <see cref="PerformanceOutcome"/>.
        /// </summary>
        /// <param name="code">The <b>Code</b>.</param>
        /// <returns>The corresponding <see cref="PerformanceOutcome"/>.</returns>
        [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Improves useability")]
        public static implicit operator PerformanceOutcome(string? code) => ConvertFromCode<PerformanceOutcome>(code);

        #endregion
    
        #region ICopyFrom
    
        /// <summary>
        /// Performs a copy from another <see cref="PerformanceOutcome"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="PerformanceOutcome"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<PerformanceOutcome>(from);
            CopyFrom(fval);
        }
        
        /// <summary>
        /// Performs a copy from another <see cref="PerformanceOutcome"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="PerformanceOutcome"/> to copy from.</param>
        public void CopyFrom(PerformanceOutcome from)
        {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            CopyFrom((ReferenceDataBaseGuid)from);

            OnAfterCopyFrom(from);
        }

        #endregion

        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="PerformanceOutcome"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="PerformanceOutcome"/>.</returns>
        public override object Clone()
        {
            var clone = new PerformanceOutcome();
            clone.CopyFrom(this);
            return clone;
        }
        
        #endregion
        
        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="PerformanceOutcome"/> resetting property values as appropriate to ensure a basic level of data consistency.
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

        partial void OnAfterCopyFrom(PerformanceOutcome from);

        #endregion
    }

    #region Collection

    /// <summary>
    /// Represents the <see cref="PerformanceOutcome"/> collection.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Tightly coupled; OK.")]
    public partial class PerformanceOutcomeCollection : ReferenceDataCollectionBase<PerformanceOutcome>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceOutcomeCollection"/> class.
        /// </summary>
        public PerformanceOutcomeCollection() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceOutcomeCollection"/> class with an entities range.
        /// </summary>
        /// <param name="entities">The <see cref="PerformanceOutcome"/> entities.</param>
        public PerformanceOutcomeCollection(IEnumerable<PerformanceOutcome> entities) => AddRange(entities);
    }

    #endregion  
}

#pragma warning restore CA2227, CA1819
#pragma warning restore IDE0005
#nullable restore