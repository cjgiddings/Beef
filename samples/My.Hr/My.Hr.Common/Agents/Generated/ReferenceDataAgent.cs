/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Beef.RefData;
using Beef.WebApi;
using My.Hr.Common.Entities;
using RefDataNamespace = My.Hr.Common.Entities;

namespace My.Hr.Common.Agents
{
    /// <summary>
    /// Defines the <b>ReferenceData</b> Web API agent.
    /// </summary>
    public partial interface IReferenceDataAgent
    {
        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.Gender"/> items that match the filter arguments.
        /// </summary>
        /// <param name="args">The optional <see cref="ReferenceDataFilter"/> arguments.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<RefDataNamespace.GenderCollection>> GenderGetAllAsync(ReferenceDataFilter? args = null, WebApiRequestOptions? requestOptions = null);

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.TerminationReason"/> items that match the filter arguments.
        /// </summary>
        /// <param name="args">The optional <see cref="ReferenceDataFilter"/> arguments.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<RefDataNamespace.TerminationReasonCollection>> TerminationReasonGetAllAsync(ReferenceDataFilter? args = null, WebApiRequestOptions? requestOptions = null);

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.RelationshipType"/> items that match the filter arguments.
        /// </summary>
        /// <param name="args">The optional <see cref="ReferenceDataFilter"/> arguments.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<RefDataNamespace.RelationshipTypeCollection>> RelationshipTypeGetAllAsync(ReferenceDataFilter? args = null, WebApiRequestOptions? requestOptions = null);

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.USState"/> items that match the filter arguments.
        /// </summary>
        /// <param name="args">The optional <see cref="ReferenceDataFilter"/> arguments.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<RefDataNamespace.USStateCollection>> USStateGetAllAsync(ReferenceDataFilter? args = null, WebApiRequestOptions? requestOptions = null);

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.PerformanceOutcome"/> items that match the filter arguments.
        /// </summary>
        /// <param name="args">The optional <see cref="ReferenceDataFilter"/> arguments.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<RefDataNamespace.PerformanceOutcomeCollection>> PerformanceOutcomeGetAllAsync(ReferenceDataFilter? args = null, WebApiRequestOptions? requestOptions = null);

        /// <summary>
        /// Gets the reference data entries for the specified entities and codes from the query string; e.g: ref?entity=codeX,codeY&amp;entity2=codeZ&amp;entity3
        /// </summary>
        /// <param name="names">The optional list of reference data names.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        /// <remarks>The reference data objects will need to be manually extracted from the corresponding response content.</remarks>
        Task<WebApiAgentResult> GetNamedAsync(string[] names, WebApiRequestOptions? requestOptions = null);
    }

    /// <summary>
    /// Provides the <b>ReferenceData</b> Web API agent.
    /// </summary>
    public partial class ReferenceDataAgent : WebApiAgentBase, IReferenceDataAgent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceDataAgent"/> class.
        /// </summary>
        /// <param name="args">The <see cref="IHrWebApiAgentArgs"/>.</param>
        public ReferenceDataAgent(IHrWebApiAgentArgs args) : base(args) { }

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.Gender"/> items that match the filter arguments.
        /// </summary>
        /// <param name="args">The optional <see cref="ReferenceDataFilter"/> arguments.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<RefDataNamespace.GenderCollection>> GenderGetAllAsync(ReferenceDataFilter? args = null, WebApiRequestOptions? requestOptions = null) =>
            GetAsync<RefDataNamespace.GenderCollection>("ref/genders", requestOptions: requestOptions, args: new WebApiArg[] { new WebApiArg<ReferenceDataFilter>("args", args!, WebApiArgType.FromUriUseProperties) });      

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.TerminationReason"/> items that match the filter arguments.
        /// </summary>
        /// <param name="args">The optional <see cref="ReferenceDataFilter"/> arguments.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<RefDataNamespace.TerminationReasonCollection>> TerminationReasonGetAllAsync(ReferenceDataFilter? args = null, WebApiRequestOptions? requestOptions = null) =>
            GetAsync<RefDataNamespace.TerminationReasonCollection>("ref/terminationReasons", requestOptions: requestOptions, args: new WebApiArg[] { new WebApiArg<ReferenceDataFilter>("args", args!, WebApiArgType.FromUriUseProperties) });      

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.RelationshipType"/> items that match the filter arguments.
        /// </summary>
        /// <param name="args">The optional <see cref="ReferenceDataFilter"/> arguments.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<RefDataNamespace.RelationshipTypeCollection>> RelationshipTypeGetAllAsync(ReferenceDataFilter? args = null, WebApiRequestOptions? requestOptions = null) =>
            GetAsync<RefDataNamespace.RelationshipTypeCollection>("ref/relationshipTypes", requestOptions: requestOptions, args: new WebApiArg[] { new WebApiArg<ReferenceDataFilter>("args", args!, WebApiArgType.FromUriUseProperties) });      

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.USState"/> items that match the filter arguments.
        /// </summary>
        /// <param name="args">The optional <see cref="ReferenceDataFilter"/> arguments.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<RefDataNamespace.USStateCollection>> USStateGetAllAsync(ReferenceDataFilter? args = null, WebApiRequestOptions? requestOptions = null) =>
            GetAsync<RefDataNamespace.USStateCollection>("ref/usStates", requestOptions: requestOptions, args: new WebApiArg[] { new WebApiArg<ReferenceDataFilter>("args", args!, WebApiArgType.FromUriUseProperties) });      

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.PerformanceOutcome"/> items that match the filter arguments.
        /// </summary>
        /// <param name="args">The optional <see cref="ReferenceDataFilter"/> arguments.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<RefDataNamespace.PerformanceOutcomeCollection>> PerformanceOutcomeGetAllAsync(ReferenceDataFilter? args = null, WebApiRequestOptions? requestOptions = null) =>
            GetAsync<RefDataNamespace.PerformanceOutcomeCollection>("ref/performanceOutcomes", requestOptions: requestOptions, args: new WebApiArg[] { new WebApiArg<ReferenceDataFilter>("args", args!, WebApiArgType.FromUriUseProperties) });      

        /// <summary>
        /// Gets the reference data entries for the specified entities and codes from the query string; e.g: ref?entity=codeX,codeY&amp;entity2=codeZ&amp;entity3
        /// </summary>
        /// <param name="names">The optional list of reference data names.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        /// <remarks>The reference data objects will need to be manually extracted from the corresponding response content.</remarks>
        public Task<WebApiAgentResult> GetNamedAsync(string[] names, WebApiRequestOptions? requestOptions = null)
        {
            var ro = requestOptions ?? new WebApiRequestOptions();
            if (names != null)
                ro.UrlQueryString += string.Join("&", names);
                
            return GetAsync("ref", requestOptions: ro);
        }
    }
}

#pragma warning restore
#nullable restore