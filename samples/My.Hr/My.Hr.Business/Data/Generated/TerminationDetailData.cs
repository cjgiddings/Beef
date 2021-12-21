/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Data.Database;
using Beef.Entities;
using Beef.Mapper;
using Beef.Mapper.Converters;
using My.Hr.Business.Entities;
using RefDataNamespace = My.Hr.Business.Entities;

namespace My.Hr.Business.Data
{
    /// <summary>
    /// Provides the <see cref="TerminationDetail"/> data access.
    /// </summary>
    public partial class TerminationDetailData
    {

        /// <summary>
        /// Provides the <see cref="TerminationDetail"/> property and database column mapping.
        /// </summary>
        public partial class DbMapper : DatabaseMapper<TerminationDetail, DbMapper>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DbMapper"/> class.
            /// </summary>
            public DbMapper()
            {
                Property(s => s.Date, "TerminationDate");
                Property(s => s.ReasonSid, "TerminationReasonCode");
                DbMapperCtor();
            }
            
            partial void DbMapperCtor(); // Enables the DbMapper constructor to be extended.
        }
    }
}

#pragma warning restore
#nullable restore