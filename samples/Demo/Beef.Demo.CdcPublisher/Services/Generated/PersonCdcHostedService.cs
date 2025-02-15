/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using Beef;
using Beef.Data.Database.Cdc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using Beef.Demo.CdcPublisher.Data;

namespace Beef.Demo.CdcPublisher.Services
{
    /// <summary>
    /// Provides the <see cref="CdcHostedService"/> capabilities for database object 'Demo.Person'.
    /// </summary>
    public partial class PersonCdcHostedService : CdcHostedService<IPersonCdcData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonCdcHostedService"/> class.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/>.</param>
        /// <param name="config">The <see cref="IConfiguration"/>.</param>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        public PersonCdcHostedService(IServiceProvider serviceProvider, ILogger<PersonCdcHostedService> logger, IConfiguration? config = null) : base(serviceProvider, logger, config) { }
    }
}

#pragma warning restore
#nullable restore