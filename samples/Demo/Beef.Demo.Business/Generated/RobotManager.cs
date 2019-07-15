/*
 * This file is automatically generated; any changes will be lost. 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Entities;
using Beef.Validation;
using Beef.Demo.Common.Entities;
using Beef.Demo.Business.Validation;
using Beef.Demo.Business.DataSvc;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business
{
    /// <summary>
    /// Provides the Robot business functionality.
    /// </summary>
    public partial class RobotManager : IRobotManager
    {
        #region Private

        private Func<Guid, Task> _getOnPreValidateAsync = null;
        private Action<MultiValidator, Guid> _getOnValidate = null;
        private Func<Guid, Task> _getOnBeforeAsync = null;
        private Func<Robot, Guid, Task> _getOnAfterAsync = null;

        private Func<Robot, Task> _createOnPreValidateAsync = null;
        private Action<MultiValidator, Robot> _createOnValidate = null;
        private Func<Robot, Task> _createOnBeforeAsync = null;
        private Func<Robot, Task> _createOnAfterAsync = null;

        private Func<Robot, Guid, Task> _updateOnPreValidateAsync = null;
        private Action<MultiValidator, Robot, Guid> _updateOnValidate = null;
        private Func<Robot, Guid, Task> _updateOnBeforeAsync = null;
        private Func<Robot, Guid, Task> _updateOnAfterAsync = null;

        private Func<Guid, Task> _deleteOnPreValidateAsync = null;
        private Action<MultiValidator, Guid> _deleteOnValidate = null;
        private Func<Guid, Task> _deleteOnBeforeAsync = null;
        private Func<Guid, Task> _deleteOnAfterAsync = null;

        private Func<RobotArgs, PagingArgs, Task> _getByArgsOnPreValidateAsync = null;
        private Action<MultiValidator, RobotArgs, PagingArgs> _getByArgsOnValidate = null;
        private Func<RobotArgs, PagingArgs, Task> _getByArgsOnBeforeAsync = null;
        private Func<RobotCollectionResult, RobotArgs, PagingArgs, Task> _getByArgsOnAfterAsync = null;

        #endregion

        /// <summary>
        /// Gets the <see cref="Robot"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Robot"/> identifier.</param>
        /// <returns>The selected <see cref="Robot"/> object where found; otherwise, <c>null</c>.</returns>
        public Task<Robot> GetAsync(Guid id)
        {
            return ManagerInvoker.Default.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                EntityBase.CleanUp(id);
                if (_getOnPreValidateAsync != null) await _getOnPreValidateAsync(id);

                MultiValidator.Create()
                    .Add(id.Validate(nameof(id)).Mandatory())
                    .Additional((__mv) => _getOnValidate?.Invoke(__mv, id))
                    .Run().ThrowOnError();

                if (_getOnBeforeAsync != null) await _getOnBeforeAsync(id);
                var __result = await RobotDataSvc.GetAsync(id);
                if (_getOnAfterAsync != null) await _getOnAfterAsync(__result, id);
                Cleaner.Clean(__result);
                return __result;
            });
        }

        /// <summary>
        /// Creates the <see cref="Robot"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Robot"/> object.</param>
        /// <returns>A refreshed <see cref="Robot"/> object.</returns>
        public Task<Robot> CreateAsync(Robot value)
        {
            return ManagerInvoker.Default.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Create;
                EntityBase.CleanUp(value);
                if (_createOnPreValidateAsync != null) await _createOnPreValidateAsync(value);

                MultiValidator.Create()
                    .Add(value.Validate(nameof(value)).Mandatory().Entity(RobotValidator.Default))
                    .Additional((__mv) => _createOnValidate?.Invoke(__mv, value))
                    .Run().ThrowOnError();

                if (_createOnBeforeAsync != null) await _createOnBeforeAsync(value);
                var __result = await RobotDataSvc.CreateAsync(value);
                if (_createOnAfterAsync != null) await _createOnAfterAsync(__result);
                Cleaner.Clean(__result);
                return __result;
            });
        }

        /// <summary>
        /// Updates the <see cref="Robot"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Robot"/> object.</param>
        /// <param name="id">The <see cref="Robot"/> identifier.</param>
        /// <returns>A refreshed <see cref="Robot"/> object.</returns>
        public Task<Robot> UpdateAsync(Robot value, Guid id)
        {
            return ManagerInvoker.Default.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Update;
                if (value != null) { value.Id = id; }
                EntityBase.CleanUp(value, id);
                if (_updateOnPreValidateAsync != null) await _updateOnPreValidateAsync(value, id);

                MultiValidator.Create()
                    .Add(value.Validate(nameof(value)).Mandatory().Entity(RobotValidator.Default))
                    .Additional((__mv) => _updateOnValidate?.Invoke(__mv, value, id))
                    .Run().ThrowOnError();

                if (_updateOnBeforeAsync != null) await _updateOnBeforeAsync(value, id);
                var __result = await RobotDataSvc.UpdateAsync(value);
                if (_updateOnAfterAsync != null) await _updateOnAfterAsync(__result, id);
                Cleaner.Clean(__result);
                return __result;
            });
        }

        /// <summary>
        /// Deletes the <see cref="Robot"/> object.
        /// </summary>
        /// <param name="id">The <see cref="Robot"/> identifier.</param>
        public Task DeleteAsync(Guid id)
        {
            return ManagerInvoker.Default.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Delete;
                EntityBase.CleanUp(id);
                if (_deleteOnPreValidateAsync != null) await _deleteOnPreValidateAsync(id);

                MultiValidator.Create()
                    .Add(id.Validate(nameof(id)).Mandatory())
                    .Additional((__mv) => _deleteOnValidate?.Invoke(__mv, id))
                    .Run().ThrowOnError();

                if (_deleteOnBeforeAsync != null) await _deleteOnBeforeAsync(id);
                await RobotDataSvc.DeleteAsync(id);
                if (_deleteOnAfterAsync != null) await _deleteOnAfterAsync(id);
            });
        }

        /// <summary>
        /// Gets the <see cref="Robot"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="RobotArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="RobotCollectionResult"/>.</returns>
        public Task<RobotCollectionResult> GetByArgsAsync(RobotArgs args, PagingArgs paging)
        {
            return ManagerInvoker.Default.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                EntityBase.CleanUp(args);
                if (_getByArgsOnPreValidateAsync != null) await _getByArgsOnPreValidateAsync(args, paging);

                MultiValidator.Create()
                    .Add(args.Validate(nameof(args)).Entity(RobotArgsValidator.Default))
                    .Additional((__mv) => _getByArgsOnValidate?.Invoke(__mv, args, paging))
                    .Run().ThrowOnError();

                if (_getByArgsOnBeforeAsync != null) await _getByArgsOnBeforeAsync(args, paging);
                var __result = await RobotDataSvc.GetByArgsAsync(args, paging);
                if (_getByArgsOnAfterAsync != null) await _getByArgsOnAfterAsync(__result, args, paging);
                Cleaner.Clean(__result);
                return __result;
            });
        }
    }
}
