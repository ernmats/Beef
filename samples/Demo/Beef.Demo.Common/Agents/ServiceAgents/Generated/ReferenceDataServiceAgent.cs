/*
 * This file is automatically generated; any changes will be lost. 
 */

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Beef.RefData;
using Beef.WebApi;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Common.Agents.ServiceAgents
{
    /// <summary>
    /// Defines the <b>ReferenceData</b> service agent.
    /// </summary>
    public partial interface IReferenceDataServiceAgent
    {
        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.Gender"/> objects.
        /// </summary>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<RefDataNamespace.GenderCollection>> GenderGetAllAsync();

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.EyeColor"/> objects.
        /// </summary>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<RefDataNamespace.EyeColorCollection>> EyeColorGetAllAsync();

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.Company"/> objects.
        /// </summary>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<RefDataNamespace.CompanyCollection>> CompanyGetAllAsync();

        /// <summary>
        /// Gets the named reference data objects.
        /// </summary>
        /// <param name="names">The list of reference data names.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        /// <remarks>The reference data objects will need to be manually extracted from the corresponding response content.</remarks>
        Task<WebApiAgentResult> GetNamedAsync(string[] names);
  }

    /// <summary>
    /// Provides the <b>ReferenceData</b> Web API service agent.
    /// </summary>
    public partial class ReferenceDataServiceAgent : WebApiServiceAgentBase<ReferenceDataServiceAgent>, IReferenceDataServiceAgent
    {
        /// <summary>
        /// Static constructor.
        /// </summary>
        static ReferenceDataServiceAgent()
        {
            Register(() =>
            {
                var rd = WebApiServiceAgentManager.Get<ReferenceDataServiceAgent>();
                return rd == null ? null : new ReferenceDataServiceAgent(rd.Client, rd.BeforeRequest);
            }, false);
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceDataServiceAgent"/> class with a <paramref name="httpClient"/>.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="beforeRequest">The <see cref="Action{HttpRequestMessage}"/> to invoke before the <see cref="HttpRequestMessage">Http Request</see> is made (see <see cref="WebApiServiceAgentBase.BeforeRequest"/>).</param>
        public ReferenceDataServiceAgent(HttpClient httpClient = null, Action<HttpRequestMessage> beforeRequest = null) : base(httpClient, beforeRequest) { }

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.Gender"/> objects.
        /// </summary>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<RefDataNamespace.GenderCollection>> GenderGetAllAsync()
        {
            return base.GetAsync<RefDataNamespace.GenderCollection>("api/v1/demo/ref/genders", args: new WebApiArg[] { });      
        }

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.EyeColor"/> objects.
        /// </summary>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<RefDataNamespace.EyeColorCollection>> EyeColorGetAllAsync()
        {
            return base.GetAsync<RefDataNamespace.EyeColorCollection>("api/v1/demo/ref/eyeColors", args: new WebApiArg[] { });      
        }

        /// <summary>
        /// Gets all of the <see cref="RefDataNamespace.Company"/> objects.
        /// </summary>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<RefDataNamespace.CompanyCollection>> CompanyGetAllAsync()
        {
            return base.GetAsync<RefDataNamespace.CompanyCollection>("api/v1/demo/ref/companies", args: new WebApiArg[] { });      
        }

        /// <summary>
        /// Gets the named reference data objects.
        /// </summary>
        /// <param name="names">The list of reference data names.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        /// <remarks>The reference data objects will need to be manually extracted from the corresponding response content.</remarks>
        public Task<WebApiAgentResult> GetNamedAsync(string[] names)
        {
            return base.GetAsync("api/v1/ref", args: new WebApiArg[] { new WebApiArg<string[]>("names", names) });
        }
    }
}
