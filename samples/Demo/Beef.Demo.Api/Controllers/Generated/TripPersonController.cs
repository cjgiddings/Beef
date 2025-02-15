/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Beef;
using Beef.AspNetCore.WebApi;
using Beef.Entities;
using Beef.Demo.Business;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Api.Controllers
{
    /// <summary>
    /// Provides the <see cref="TripPerson"/> Web API functionality.
    /// </summary>
    [Route("api/v1/tripPeople")]
    public partial class TripPersonController : ControllerBase
    {
        private readonly ITripPersonManager _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripPersonController"/> class.
        /// </summary>
        /// <param name="manager">The <see cref="ITripPersonManager"/>.</param>
        public TripPersonController(ITripPersonManager manager)
            { _manager = Check.NotNull(manager, nameof(manager)); TripPersonControllerCtor(); }

        partial void TripPersonControllerCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Gets the specified <see cref="TripPerson"/>.
        /// </summary>
        /// <param name="id">The <see cref="TripPerson"/> identifier (username).</param>
        /// <returns>The selected <see cref="TripPerson"/> where found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TripPerson), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get(string? id) =>
            new WebApiGet<TripPerson?>(this, () => _manager.GetAsync(id),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NotFound);

        /// <summary>
        /// Creates a new <see cref="TripPerson"/>.
        /// </summary>
        /// <param name="value">The <see cref="TripPerson"/>.</param>
        /// <returns>The created <see cref="TripPerson"/>.</returns>
        [HttpPost("")]
        [ProducesResponseType(typeof(TripPerson), (int)HttpStatusCode.Created)]
        public IActionResult Create([FromBody] TripPerson value) =>
            new WebApiPost<TripPerson>(this, () => _manager.CreateAsync(WebApiActionBase.Value(value)),
                operationType: OperationType.Create, statusCode: HttpStatusCode.Created, alternateStatusCode: null);

        /// <summary>
        /// Updates an existing <see cref="TripPerson"/>.
        /// </summary>
        /// <param name="value">The <see cref="TripPerson"/>.</param>
        /// <param name="id">The <see cref="TripPerson"/> identifier (username).</param>
        /// <returns>The updated <see cref="TripPerson"/>.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TripPerson), (int)HttpStatusCode.OK)]
        public IActionResult Update([FromBody] TripPerson value, string? id) =>
            new WebApiPut<TripPerson>(this, () => _manager.UpdateAsync(WebApiActionBase.Value(value), id),
                operationType: OperationType.Update, statusCode: HttpStatusCode.OK, alternateStatusCode: null);

        /// <summary>
        /// Deletes the specified <see cref="TripPerson"/>.
        /// </summary>
        /// <param name="id">The <see cref="TripPerson"/> identifier (username).</param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Delete(string? id) =>
            new WebApiDelete(this, () => _manager.DeleteAsync(id),
                operationType: OperationType.Delete, statusCode: HttpStatusCode.NoContent);
    }
}

#pragma warning restore
#nullable restore