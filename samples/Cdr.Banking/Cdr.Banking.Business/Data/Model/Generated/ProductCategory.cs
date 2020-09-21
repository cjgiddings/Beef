/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options
#pragma warning disable CA2227, CA1819 // Collection/Array properties should be read only; ignored, as acceptable for a DTO.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Beef.RefData.Model;
using Newtonsoft.Json;

namespace Cdr.Banking.Business.Data.Model
{
    /// <summary>
    /// Represents the Product Category model.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class ProductCategory : ReferenceDataBaseGuid
    {
    }

    /// <summary>
    /// Represents the <see cref="ProductCategory"/> collection.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Tightly coupled; OK.")]
    public partial class ProductCategoryCollection : List<ProductCategory> { }
}

#pragma warning restore CA2227, CA1819
#pragma warning restore IDE0005
#nullable restore