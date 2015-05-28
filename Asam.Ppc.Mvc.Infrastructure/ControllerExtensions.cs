using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Asam.Ppc.Service.Messages.Common;
using Pillar.Common.DataTransferObject;

namespace Asam.Ppc.Mvc.Infrastructure
{
    /// <summary>
    /// Controller extensions.
    /// </summary>
    public static class ControllerExtensions
    {
        /// <summary>
        /// Handles the errors and warnings.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="dataErrorInfoCollection">The data error info collection.</param>
        /// <param name="notification">The notification.</param>
        /// <param name="onError">The on error.</param>
        /// <returns><see cref="ViewResult"/>.</returns>
        public static ViewResult HandleErrorsAndWarnings(this Controller controller, IEnumerable<DataErrorInfo> dataErrorInfoCollection, Notification notification, Func<ViewResult> onError)
        {
            var dataErrors = dataErrorInfoCollection.ToList();
            var error = HasError(dataErrors, notification, controller.ModelState);
            if (error)
            {
                return onError();
            }
            var warning = HasWarning(dataErrors, controller.ModelState);
            if (warning)
            {
                controller.TempData["ModelState"] = controller.ModelState.GetWarnings();
            }
            return null;
        }

        #region Private Methods

        private static bool HasWarning(IEnumerable<DataErrorInfo> dataErrorInfoCollection,
                                       ModelStateDictionary modelState)
        {
            var warning = false;
            foreach (var errorInfo in dataErrorInfoCollection.Where(d => d.ErrorLevel == ErrorLevel.Warning))
            {
                warning = true;
                modelState.AddDataErrorInfo(errorInfo);
            }
            return warning;
        }

        private static bool HasError(Notification notification, ModelStateDictionary modelState)
        {
            var error = false;
            if (notification != null && notification.NotificationType == NotificationType.Error)
            {
                error = true;
                modelState.AddModelError(string.Empty, new DataException(notification.Message));
            }
            return error;
        }

        private static bool HasError(IEnumerable<DataErrorInfo> dataErrorInfoCollection, ModelStateDictionary modelState)
        {
            var dataErrors = dataErrorInfoCollection.ToList();
            var error = dataErrors.Any(d => d.ErrorLevel == ErrorLevel.Error);
            if (error)
            {
                foreach (var errorInfo in dataErrors)
                {
                    modelState.AddDataErrorInfo(errorInfo); //include warnings too
                }
            }
            return error;
        }

        private static bool HasError(IEnumerable<DataErrorInfo> dataErrorInfoCollection, Notification notification,
                                     ModelStateDictionary modelState)
        {
            var error = HasError(dataErrorInfoCollection, modelState);
            error |= HasError(notification, modelState);
            return error;
        }

        #endregion
    }
}
