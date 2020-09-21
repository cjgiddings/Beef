/*
 * This file is automatically generated; any changes will be lost. 
 */
 
#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Beef;
using Beef.AspNetCore.WebApi;
using Beef.Entities;
using Beef.RefData;
using Cdr.Banking.Common.Entities;
using RefDataNamespace = Cdr.Banking.Common.Entities;

namespace Cdr.Banking.Api.Controllers
{
    /// <summary>
    /// Provides the <b>ReferenceData</b> Web API functionality.
    /// </summary>
    [AllowAnonymous]
    public partial class ReferenceDataController : ControllerBase
    {
        /// <summary> 
        /// Gets all of the <see cref="RefDataNamespace.OpenStatus"/> reference data items that match the specified criteria.
        /// </summary>
        /// <param name="codes">The reference data code list.</param>
        /// <param name="text">The reference data text (including wildcards).</param>
        /// <returns>A RefDataNamespace.OpenStatus collection.</returns>
        [AllowAnonymous]
        [HttpGet()]
        [Route("api/v1/ref/openStatuses")]
        [ProducesResponseType(typeof(IEnumerable<RefDataNamespace.OpenStatus>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult OpenStatusGetAll(List<string>? codes = default, string? text = default) => new WebApiGet<ReferenceDataFilterResult<RefDataNamespace.OpenStatus>>(this, 
            () => Task.FromResult(ReferenceDataFilter.ApplyFilter<RefDataNamespace.OpenStatusCollection, RefDataNamespace.OpenStatus>(RefDataNamespace.ReferenceData.Current.OpenStatus, codes, text, includeInactive: this.IncludeInactive())),
            operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);

        /// <summary> 
        /// Gets all of the <see cref="RefDataNamespace.ProductCategory"/> reference data items that match the specified criteria.
        /// </summary>
        /// <param name="codes">The reference data code list.</param>
        /// <param name="text">The reference data text (including wildcards).</param>
        /// <returns>A RefDataNamespace.ProductCategory collection.</returns>
        [AllowAnonymous]
        [HttpGet()]
        [Route("api/v1/ref/productCategories")]
        [ProducesResponseType(typeof(IEnumerable<RefDataNamespace.ProductCategory>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult ProductCategoryGetAll(List<string>? codes = default, string? text = default) => new WebApiGet<ReferenceDataFilterResult<RefDataNamespace.ProductCategory>>(this, 
            () => Task.FromResult(ReferenceDataFilter.ApplyFilter<RefDataNamespace.ProductCategoryCollection, RefDataNamespace.ProductCategory>(RefDataNamespace.ReferenceData.Current.ProductCategory, codes, text, includeInactive: this.IncludeInactive())),
            operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);

        /// <summary> 
        /// Gets all of the <see cref="RefDataNamespace.AccountUType"/> reference data items that match the specified criteria.
        /// </summary>
        /// <param name="codes">The reference data code list.</param>
        /// <param name="text">The reference data text (including wildcards).</param>
        /// <returns>A RefDataNamespace.AccountUType collection.</returns>
        [AllowAnonymous]
        [HttpGet()]
        [Route("api/v1/ref/accountUTypes")]
        [ProducesResponseType(typeof(IEnumerable<RefDataNamespace.AccountUType>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult AccountUTypeGetAll(List<string>? codes = default, string? text = default) => new WebApiGet<ReferenceDataFilterResult<RefDataNamespace.AccountUType>>(this, 
            () => Task.FromResult(ReferenceDataFilter.ApplyFilter<RefDataNamespace.AccountUTypeCollection, RefDataNamespace.AccountUType>(RefDataNamespace.ReferenceData.Current.AccountUType, codes, text, includeInactive: this.IncludeInactive())),
            operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);

        /// <summary> 
        /// Gets all of the <see cref="RefDataNamespace.MaturityInstructions"/> reference data items that match the specified criteria.
        /// </summary>
        /// <param name="codes">The reference data code list.</param>
        /// <param name="text">The reference data text (including wildcards).</param>
        /// <returns>A RefDataNamespace.MaturityInstructions collection.</returns>
        [AllowAnonymous]
        [HttpGet()]
        [Route("api/v1/ref/maturityInstructions")]
        [ProducesResponseType(typeof(IEnumerable<RefDataNamespace.MaturityInstructions>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult MaturityInstructionsGetAll(List<string>? codes = default, string? text = default) => new WebApiGet<ReferenceDataFilterResult<RefDataNamespace.MaturityInstructions>>(this, 
            () => Task.FromResult(ReferenceDataFilter.ApplyFilter<RefDataNamespace.MaturityInstructionsCollection, RefDataNamespace.MaturityInstructions>(RefDataNamespace.ReferenceData.Current.MaturityInstructions, codes, text, includeInactive: this.IncludeInactive())),
            operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);

        /// <summary> 
        /// Gets all of the <see cref="RefDataNamespace.TransactionType"/> reference data items that match the specified criteria.
        /// </summary>
        /// <param name="codes">The reference data code list.</param>
        /// <param name="text">The reference data text (including wildcards).</param>
        /// <returns>A RefDataNamespace.TransactionType collection.</returns>
        [AllowAnonymous]
        [HttpGet()]
        [Route("api/v1/ref/transactionTypes")]
        [ProducesResponseType(typeof(IEnumerable<RefDataNamespace.TransactionType>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult TransactionTypeGetAll(List<string>? codes = default, string? text = default) => new WebApiGet<ReferenceDataFilterResult<RefDataNamespace.TransactionType>>(this, 
            () => Task.FromResult(ReferenceDataFilter.ApplyFilter<RefDataNamespace.TransactionTypeCollection, RefDataNamespace.TransactionType>(RefDataNamespace.ReferenceData.Current.TransactionType, codes, text, includeInactive: this.IncludeInactive())),
            operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);

        /// <summary> 
        /// Gets all of the <see cref="RefDataNamespace.TransactionStatus"/> reference data items that match the specified criteria.
        /// </summary>
        /// <param name="codes">The reference data code list.</param>
        /// <param name="text">The reference data text (including wildcards).</param>
        /// <returns>A RefDataNamespace.TransactionStatus collection.</returns>
        [AllowAnonymous]
        [HttpGet()]
        [Route("api/v1/ref/transactionStatuses")]
        [ProducesResponseType(typeof(IEnumerable<RefDataNamespace.TransactionStatus>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult TransactionStatusGetAll(List<string>? codes = default, string? text = default) => new WebApiGet<ReferenceDataFilterResult<RefDataNamespace.TransactionStatus>>(this, 
            () => Task.FromResult(ReferenceDataFilter.ApplyFilter<RefDataNamespace.TransactionStatusCollection, RefDataNamespace.TransactionStatus>(RefDataNamespace.ReferenceData.Current.TransactionStatus, codes, text, includeInactive: this.IncludeInactive())),
            operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);

        /// <summary>
        /// Gets the reference data entries for the specified entities and codes from the query string; e.g: ?entity=codeX,codeY&amp;entity2=codeZ&amp;entity3
        /// </summary>
        /// <returns>A <see cref="ReferenceDataMultiCollection"/>.</returns>
        [AllowAnonymous]
        [HttpGet()]
        [Route("api/v1/ref")]
        [ProducesResponseType(typeof(ReferenceDataMultiCollection), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetNamed()
        {
            return new WebApiGet<ReferenceDataMultiCollection>(this, async () =>
            {
                var coll = new ReferenceDataMultiCollection();
                var inactive = this.IncludeInactive();
                var refSelection = this.ReferenceDataSelection();

                var names = refSelection.Select(x => x.Key).ToArray();
                await RefDataNamespace.ReferenceData.Current.PrefetchAsync(names).ConfigureAwait(false);

                foreach (var q in refSelection)
                {
                    switch (q.Key)
                    {
                        case var s when string.Compare(s, nameof(RefDataNamespace.OpenStatus), StringComparison.InvariantCultureIgnoreCase) == 0: coll.Add(new ReferenceDataMultiItem(nameof(RefDataNamespace.OpenStatus), ReferenceDataFilter.ApplyFilter<RefDataNamespace.OpenStatusCollection, RefDataNamespace.OpenStatus>(RefDataNamespace.ReferenceData.Current.OpenStatus, q.Value, includeInactive: inactive))); break;
                        case var s when string.Compare(s, nameof(RefDataNamespace.ProductCategory), StringComparison.InvariantCultureIgnoreCase) == 0: coll.Add(new ReferenceDataMultiItem(nameof(RefDataNamespace.ProductCategory), ReferenceDataFilter.ApplyFilter<RefDataNamespace.ProductCategoryCollection, RefDataNamespace.ProductCategory>(RefDataNamespace.ReferenceData.Current.ProductCategory, q.Value, includeInactive: inactive))); break;
                        case var s when string.Compare(s, nameof(RefDataNamespace.AccountUType), StringComparison.InvariantCultureIgnoreCase) == 0: coll.Add(new ReferenceDataMultiItem(nameof(RefDataNamespace.AccountUType), ReferenceDataFilter.ApplyFilter<RefDataNamespace.AccountUTypeCollection, RefDataNamespace.AccountUType>(RefDataNamespace.ReferenceData.Current.AccountUType, q.Value, includeInactive: inactive))); break;
                        case var s when string.Compare(s, nameof(RefDataNamespace.MaturityInstructions), StringComparison.InvariantCultureIgnoreCase) == 0: coll.Add(new ReferenceDataMultiItem(nameof(RefDataNamespace.MaturityInstructions), ReferenceDataFilter.ApplyFilter<RefDataNamespace.MaturityInstructionsCollection, RefDataNamespace.MaturityInstructions>(RefDataNamespace.ReferenceData.Current.MaturityInstructions, q.Value, includeInactive: inactive))); break;
                        case var s when string.Compare(s, nameof(RefDataNamespace.TransactionType), StringComparison.InvariantCultureIgnoreCase) == 0: coll.Add(new ReferenceDataMultiItem(nameof(RefDataNamespace.TransactionType), ReferenceDataFilter.ApplyFilter<RefDataNamespace.TransactionTypeCollection, RefDataNamespace.TransactionType>(RefDataNamespace.ReferenceData.Current.TransactionType, q.Value, includeInactive: inactive))); break;
                        case var s when string.Compare(s, nameof(RefDataNamespace.TransactionStatus), StringComparison.InvariantCultureIgnoreCase) == 0: coll.Add(new ReferenceDataMultiItem(nameof(RefDataNamespace.TransactionStatus), ReferenceDataFilter.ApplyFilter<RefDataNamespace.TransactionStatusCollection, RefDataNamespace.TransactionStatus>(RefDataNamespace.ReferenceData.Current.TransactionStatus, q.Value, includeInactive: inactive))); break;
                    }
                }
                
                return coll;
            }, operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);
        }
    }
}

#pragma warning restore IDE0005
#nullable restore