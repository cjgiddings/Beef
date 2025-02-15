/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Threading.Tasks;
using Beef.RefData;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Common.Entities
{
    /// <summary>
    /// Provides a standard mechanism for accessing the <b>ReferenceData</b>. 
    /// </summary>
    public abstract partial class ReferenceData : IReferenceData
    {
        /// <summary>
        /// Gets the current <see cref="ReferenceData"/> instance.
        /// </summary>
        public static ReferenceData Current => (ReferenceData)ReferenceDataManager.Current.GetProvider(typeof(IReferenceData));
        
        /// <summary>
        /// Gets all the underlying <see cref="ReferenceDataBase"/> <see cref="Type">types</see>.
        /// </summary>
        /// <returns>An array of the <see cref="ReferenceDataBase"/> <see cref="Type">types</see>.</returns>
        public static Type[] GetAllTypes() => new Type[] 
            {
                typeof(Country),
                typeof(USState),
                typeof(Gender),
                typeof(EyeColor),
                typeof(PowerSource),
                typeof(Company),
                typeof(Status)
            };

        /// <summary>
        /// Gets the provider interface cref="Type"/> used for <see cref="ReferenceDataManager.GetProvider(Type)"/>. The value is <see cref="IReferenceData"/>.
        /// </summary>
        public Type ProviderType => typeof(IReferenceData);

        /// <summary>
        /// Gets the <see cref="IReferenceDataCollection"/> for the associated <see cref="ReferenceDataBase"/> <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The associated <see cref="ReferenceDataBase"/> <see cref="Type"/>.</param>
        /// <returns>The corresponding <see cref="IReferenceDataCollection"/>.</returns>
        public abstract IReferenceDataCollection this[Type type] { get; }

        /// <summary>
        /// Prefetches all of the named <see cref="ReferenceDataBase"/> objects.
        /// </summary>
        /// <param name="names">The list of <see cref="ReferenceDataBase"/> names.</param>
        /// <remarks>Note for implementers; should only fetch where not already cached or expired. This is provided to improve performance for consuming applications to reduce the overhead of
        /// making multiple individual invocations, i.e. reduces chattiness across a potentially high-latency connection.</remarks>
        public abstract Task PrefetchAsync(params string[] names);
        
        #region Collections

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.CountryCollection"/>.
        /// </summary>
        public abstract RefDataNamespace.CountryCollection Country { get; }

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.USStateCollection"/>.
        /// </summary>
        public abstract RefDataNamespace.USStateCollection USState { get; }

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.GenderCollection"/>.
        /// </summary>
        public abstract RefDataNamespace.GenderCollection Gender { get; }

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.EyeColorCollection"/>.
        /// </summary>
        public abstract RefDataNamespace.EyeColorCollection EyeColor { get; }

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.PowerSourceCollection"/>.
        /// </summary>
        public abstract RefDataNamespace.PowerSourceCollection PowerSource { get; }

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.CompanyCollection"/>.
        /// </summary>
        public abstract RefDataNamespace.CompanyCollection Company { get; }

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.StatusCollection"/>.
        /// </summary>
        public abstract RefDataNamespace.StatusCollection Status { get; }

        #endregion
    }
}

#pragma warning restore
#nullable restore