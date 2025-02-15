/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Entities;
using Beef.Validation;
using Beef.Demo.Business.Entities;
using Beef.Demo.Business.DataSvc;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business
{
    /// <summary>
    /// Provides the <see cref="Contact"/> business functionality.
    /// </summary>
    public partial class ContactManager : IContactManager
    {
        private readonly IContactDataSvc _dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManager"/> class.
        /// </summary>
        /// <param name="dataService">The <see cref="IContactDataSvc"/>.</param>
        public ContactManager(IContactDataSvc dataService)
            { _dataService = Check.NotNull(dataService, nameof(dataService)); ContactManagerCtor(); }

        partial void ContactManagerCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Gets the <see cref="ContactCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <returns>The <see cref="ContactCollectionResult"/>.</returns>
        public async Task<ContactCollectionResult> GetAllAsync() => await ManagerInvoker.Current.InvokeAsync(this, async () =>
        {
            return Cleaner.Clean(await _dataService.GetAllAsync().ConfigureAwait(false));
        }, BusinessInvokerArgs.Read).ConfigureAwait(false);

        /// <summary>
        /// Gets the specified <see cref="Contact"/>.
        /// </summary>
        /// <param name="id">The <see cref="Contact"/> identifier.</param>
        /// <returns>The selected <see cref="Contact"/> where found.</returns>
        public async Task<Contact?> GetAsync(Guid id) => await ManagerInvoker.Current.InvokeAsync(this, async () =>
        {
            Cleaner.CleanUp(id);
            await id.Validate(nameof(id)).Mandatory().RunAsync(throwOnError: true).ConfigureAwait(false);
            return Cleaner.Clean(await _dataService.GetAsync(id).ConfigureAwait(false));
        }, BusinessInvokerArgs.Read).ConfigureAwait(false);

        /// <summary>
        /// Creates a new <see cref="Contact"/>.
        /// </summary>
        /// <param name="value">The <see cref="Contact"/>.</param>
        /// <returns>The created <see cref="Contact"/>.</returns>
        public async Task<Contact> CreateAsync(Contact value) => await ManagerInvoker.Current.InvokeAsync(this, async () =>
        {
            await value.Validate().Mandatory().RunAsync(throwOnError: true).ConfigureAwait(false);

            Cleaner.CleanUp(value);
            return Cleaner.Clean(await _dataService.CreateAsync(value).ConfigureAwait(false));
        }, BusinessInvokerArgs.Create).ConfigureAwait(false);

        /// <summary>
        /// Updates an existing <see cref="Contact"/>.
        /// </summary>
        /// <param name="value">The <see cref="Contact"/>.</param>
        /// <param name="id">The <see cref="Contact"/> identifier.</param>
        /// <returns>The updated <see cref="Contact"/>.</returns>
        public async Task<Contact> UpdateAsync(Contact value, Guid id) => await ManagerInvoker.Current.InvokeAsync(this, async () =>
        {
            await value.Validate().Mandatory().RunAsync(throwOnError: true).ConfigureAwait(false);

            value.Id = id;
            Cleaner.CleanUp(value);
            return Cleaner.Clean(await _dataService.UpdateAsync(value).ConfigureAwait(false));
        }, BusinessInvokerArgs.Update).ConfigureAwait(false);

        /// <summary>
        /// Deletes the specified <see cref="Contact"/>.
        /// </summary>
        /// <param name="id">The <see cref="Contact"/> identifier.</param>
        public async Task DeleteAsync(Guid id) => await ManagerInvoker.Current.InvokeAsync(this, async () =>
        {
            Cleaner.CleanUp(id);
            await id.Validate(nameof(id)).Mandatory().RunAsync(throwOnError: true).ConfigureAwait(false);
            await _dataService.DeleteAsync(id).ConfigureAwait(false);
        }, BusinessInvokerArgs.Delete).ConfigureAwait(false);

        /// <summary>
        /// Raise Event.
        /// </summary>
        /// <param name="throwError">Indicates whether throw a DivideByZero exception.</param>
        public async Task RaiseEventAsync(bool throwError) => await ManagerInvoker.Current.InvokeAsync(this, async () =>
        {
            Cleaner.CleanUp(throwError);
            await _dataService.RaiseEventAsync(throwError).ConfigureAwait(false);
        }, BusinessInvokerArgs.Unspecified).ConfigureAwait(false);
    }
}

#pragma warning restore
#nullable restore