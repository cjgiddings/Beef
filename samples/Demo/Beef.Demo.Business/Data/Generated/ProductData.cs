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
using Beef.Data.OData;
using Beef.Entities;
using Beef.Mapper;
using Beef.Mapper.Converters;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;
using Soc = Simple.OData.Client;

namespace Beef.Demo.Business.Data
{
    /// <summary>
    /// Provides the <see cref="Product"/> data access.
    /// </summary>
    public partial class ProductData : IProductData
    {
        private readonly ITestOData _odata;
        private readonly AutoMapper.IMapper _mapper;

        private Func<Soc.IBoundClient<Model.Product>, ProductArgs?, ODataArgs, Soc.IBoundClient<Model.Product>>? _getByArgsOnQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductData"/> class.
        /// </summary>
        /// <param name="odata">The <see cref="ITestOData"/>.</param>
        /// <param name="mapper">The <see cref="AutoMapper.IMapper"/>.</param>
        public ProductData(ITestOData odata, AutoMapper.IMapper mapper)
            { _odata = Check.NotNull(odata, nameof(odata)); _mapper = Check.NotNull(mapper, nameof(mapper)); ProductDataCtor(); }

        partial void ProductDataCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Gets the specified <see cref="Product"/>.
        /// </summary>
        /// <param name="id">The <see cref="Product"/> identifier.</param>
        /// <returns>The selected <see cref="Product"/> where found.</returns>
        public Task<Product?> GetAsync(int id) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            var __dataArgs = ODataArgs.Create(_mapper, "Products");
            return await _odata.GetAsync<Product, Model.Product>(__dataArgs, id).ConfigureAwait(false);
        });

        /// <summary>
        /// Gets the <see cref="ProductCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="Entities.ProductArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>The <see cref="ProductCollectionResult"/>.</returns>
        public Task<ProductCollectionResult> GetByArgsAsync(ProductArgs? args, PagingArgs? paging) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            ProductCollectionResult __result = new ProductCollectionResult(paging);
            var __dataArgs = ODataArgs.Create(_mapper, __result.Paging!, "Products");
            __result.Result = _odata.Query<Product, Model.Product>(__dataArgs, q => _getByArgsOnQuery?.Invoke(q, args, __dataArgs) ?? q).SelectQuery<ProductCollection>();
            return await Task.FromResult(__result).ConfigureAwait(false);
        });

        /// <summary>
        /// Provides the <see cref="Product"/> and OData <see cref="Model.Product"/> <i>AutoMapper</i> mapping.
        /// </summary>
        public partial class ODataMapperProfile : AutoMapper.Profile
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ODataMapperProfile"/> class.
            /// </summary>
            public ODataMapperProfile()
            {
                var s2d = CreateMap<Product, Model.Product>();
                s2d.ForMember(d => d.ID, o => o.MapFrom(s => s.Id));
                s2d.ForMember(d => d.Name, o => o.MapFrom(s => s.Name));
                s2d.ForMember(d => d.Description, o => o.MapFrom(s => s.Description));

                var d2s = CreateMap<Model.Product, Product>();
                d2s.ForMember(s => s.Id, o => o.MapFrom(d => d.ID));
                d2s.ForMember(s => s.Name, o => o.MapFrom(d => d.Name));
                d2s.ForMember(s => s.Description, o => o.MapFrom(d => d.Description));

                ODataMapperProfileCtor(s2d, d2s);
            }

            partial void ODataMapperProfileCtor(AutoMapper.IMappingExpression<Product, Model.Product> s2d, AutoMapper.IMappingExpression<Model.Product, Product> d2s); // Enables the constructor to be extended.
        }
    }
}

#pragma warning restore
#nullable restore