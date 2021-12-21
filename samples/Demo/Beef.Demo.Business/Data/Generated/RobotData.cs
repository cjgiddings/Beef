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
using Microsoft.Azure.Cosmos;
using Beef;
using Beef.Business;
using Beef.Data.Cosmos;
using Beef.Entities;
using Beef.Mapper;
using Beef.Mapper.Converters;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.Data
{
    /// <summary>
    /// Provides the <see cref="Robot"/> data access.
    /// </summary>
    public partial class RobotData : IRobotData
    {
        private readonly ICosmosDb _cosmos;
        private readonly AutoMapper.IMapper _mapper;

        private Action<CosmosDbArgs>? _onDataArgsCreate;
        private Func<IQueryable<Model.Robot>, RobotArgs?, CosmosDbArgs, IQueryable<Model.Robot>>? _getByArgsOnQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotData"/> class.
        /// </summary>
        /// <param name="cosmos">The <see cref="ICosmosDb"/>.</param>
        /// <param name="mapper">The <see cref="AutoMapper.IMapper"/>.</param>
        public RobotData(ICosmosDb cosmos, AutoMapper.IMapper mapper)
            { _cosmos = Check.NotNull(cosmos, nameof(cosmos)); _mapper = Check.NotNull(mapper, nameof(mapper)); RobotDataCtor(); }

        partial void RobotDataCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Gets the specified <see cref="Robot"/>.
        /// </summary>
        /// <param name="id">The <see cref="Robot"/> identifier.</param>
        /// <returns>The selected <see cref="Robot"/> where found.</returns>
        public Task<Robot?> GetAsync(Guid id) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            var __dataArgs = CosmosDbArgs.Create(_mapper, "Items", PartitionKey.None, onCreate: _onDataArgsCreate);
            return await _cosmos.Container<Robot, Model.Robot>(__dataArgs).GetAsync(id).ConfigureAwait(false);
        });

        /// <summary>
        /// Creates a new <see cref="Robot"/>.
        /// </summary>
        /// <param name="value">The <see cref="Robot"/>.</param>
        /// <returns>The created <see cref="Robot"/>.</returns>
        public Task<Robot> CreateAsync(Robot value) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            var __dataArgs = CosmosDbArgs.Create(_mapper, "Items", PartitionKey.None, onCreate: _onDataArgsCreate);
            return await _cosmos.Container<Robot, Model.Robot>(__dataArgs).CreateAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
        });

        /// <summary>
        /// Updates an existing <see cref="Robot"/>.
        /// </summary>
        /// <param name="value">The <see cref="Robot"/>.</param>
        /// <returns>The updated <see cref="Robot"/>.</returns>
        public Task<Robot> UpdateAsync(Robot value) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            var __dataArgs = CosmosDbArgs.Create(_mapper, "Items", PartitionKey.None, onCreate: _onDataArgsCreate);
            return await _cosmos.Container<Robot, Model.Robot>(__dataArgs).UpdateAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
        });

        /// <summary>
        /// Deletes the specified <see cref="Robot"/>.
        /// </summary>
        /// <param name="id">The <see cref="Robot"/> identifier.</param>
        public Task DeleteAsync(Guid id) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            var __dataArgs = CosmosDbArgs.Create(_mapper, "Items", PartitionKey.None, onCreate: _onDataArgsCreate);
            await _cosmos.Container<Robot, Model.Robot>(__dataArgs).DeleteAsync(id).ConfigureAwait(false);
        });

        /// <summary>
        /// Gets the <see cref="RobotCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="Entities.RobotArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>The <see cref="RobotCollectionResult"/>.</returns>
        public Task<RobotCollectionResult> GetByArgsAsync(RobotArgs? args, PagingArgs? paging) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            RobotCollectionResult __result = new RobotCollectionResult(paging);
            var __dataArgs = CosmosDbArgs.Create(_mapper, "Items", __result.Paging!, PartitionKey.None, onCreate: _onDataArgsCreate);
            __result.Result = _cosmos.Container<Robot, Model.Robot>(__dataArgs).Query(q => _getByArgsOnQuery?.Invoke(q, args, __dataArgs) ?? q).SelectQuery<RobotCollection>();
            return await Task.FromResult(__result).ConfigureAwait(false);
        });

        /// <summary>
        /// Provides the <see cref="Robot"/> and Entity Framework <see cref="Model.Robot"/> <i>AutoMapper</i> mapping.
        /// </summary>
        public partial class CosmosMapperProfile : AutoMapper.Profile
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CosmosMapperProfile"/> class.
            /// </summary>
            public CosmosMapperProfile()
            {
                var s2d = CreateMap<Robot, Model.Robot>();
                s2d.ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
                s2d.ForMember(d => d.ModelNo, o => o.MapFrom(s => s.ModelNo));
                s2d.ForMember(d => d.SerialNo, o => o.MapFrom(s => s.SerialNo));
                s2d.ForMember(d => d.EyeColor, o => o.MapFrom(s => s.EyeColorSid));
                s2d.ForMember(d => d.PowerSource, o => o.MapFrom(s => s.PowerSourceSid));
                s2d.ForMember(d => d.ETag, o => o.MapFrom(s => s.ETag));
                s2d.ForMember(d => d.ChangeLog, o => o.MapFrom(s => s.ChangeLog));

                var d2s = CreateMap<Model.Robot, Robot>();
                d2s.ForMember(s => s.Id, o => o.MapFrom(d => d.Id));
                d2s.ForMember(s => s.ModelNo, o => o.MapFrom(d => d.ModelNo));
                d2s.ForMember(s => s.SerialNo, o => o.MapFrom(d => d.SerialNo));
                d2s.ForMember(s => s.EyeColorSid, o => o.MapFrom(d => d.EyeColor));
                d2s.ForMember(s => s.PowerSourceSid, o => o.MapFrom(d => d.PowerSource));
                d2s.ForMember(s => s.ETag, o => o.MapFrom(d => d.ETag));
                d2s.ForMember(s => s.ChangeLog, o => o.MapFrom(d => d.ChangeLog));

                CosmosMapperProfileCtor(s2d, d2s);
            }

            partial void CosmosMapperProfileCtor(AutoMapper.IMappingExpression<Robot, Model.Robot> s2d, AutoMapper.IMappingExpression<Model.Robot, Robot> d2s); // Enables the constructor to be extended.
        }
    }
}

#pragma warning restore
#nullable restore