using System;
using System.Linq;
using System.Web.Mvc;
using Asam.Ppc.Service.Messages.Common;

namespace Asam.Ppc.Mvc.Infrastructure
{
    /// <summary>
    /// Model state extensions.
    /// </summary>
    public static class ModelStateDictionaryExtensions
    {
        /// <summary>
        /// Adds the model error.
        /// </summary>
        /// <param name="modelStateDictionary">The model state dictionary.</param>
        /// <param name="dataErrorInfo">The data error info.</param>
        public static void AddModelError(this ModelStateDictionary modelStateDictionary, DataErrorInfo dataErrorInfo)
        {
            modelStateDictionary.AddModelError(
                dataErrorInfo.DataErrorInfoType == DataErrorInfoType.PropertyLevel
                    ? dataErrorInfo.Properties[0]
                    : string.Empty, dataErrorInfo.Message);
        }

        /// <summary>
        /// Adds the data error info.
        /// </summary>
        /// <param name="modelStateDictionary">The model state dictionary.</param>
        /// <param name="dataErrorInfo">The data error info.</param>
        public static void AddDataErrorInfo(this ModelStateDictionary modelStateDictionary, DataErrorInfo dataErrorInfo)
        {
            if (dataErrorInfo.ErrorLevel == ErrorLevel.Error)
            {
                modelStateDictionary.AddModelError(
                    dataErrorInfo.DataErrorInfoType == DataErrorInfoType.PropertyLevel
                        ? dataErrorInfo.Properties[0]
                        : string.Empty, dataErrorInfo.Message);
            }
            else
            {
                modelStateDictionary.AddModelWarning(
                   dataErrorInfo.DataErrorInfoType == DataErrorInfoType.PropertyLevel
                       ? dataErrorInfo.Properties[0]
                       : string.Empty, dataErrorInfo.Message);
            }
        }


        /// <summary>
        /// Adds the model warning.
        /// </summary>
        /// <param name="modelStateDictionary">The model state dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="exception">The exception.</param>
        public static void AddModelWarning(this ModelStateDictionary modelStateDictionary, string key, Exception exception)
        {
            GetModelStateForKey(key, modelStateDictionary).Warnings.Add(exception);
        }

        /// <summary>
        /// Adds the model warning.
        /// </summary>
        /// <param name="modelStateDictionary">The model state dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="errorMessage">The error message.</param>
        public static void AddModelWarning(this ModelStateDictionary modelStateDictionary, string key, string errorMessage)
        {
            GetModelStateForKey(key, modelStateDictionary).Warnings.Add(errorMessage);
        }

        private static ExtendedModelState GetModelStateForKey(string key, ModelStateDictionary modelStateDictionary)
        {
            if (key == null)
            {
                throw new ArgumentException("Model state key");
            }
            
            ModelState modelState;
            if (!modelStateDictionary.TryGetValue(key, out modelState))
            {
                modelStateDictionary[key] = modelState = new ExtendedModelState();
            }

            if (!(modelState is ExtendedModelState))
            {
                modelStateDictionary.Remove(key);
                modelStateDictionary[key] = modelState = new ExtendedModelState(modelState);
            }

            return modelState as ExtendedModelState;
        }

        /// <summary>
        /// Determines whether the specified model state dictionary has warnings.
        /// </summary>
        /// <param name="modelStateDictionary">The model state dictionary.</param>
        /// <returns>
        ///   <c>true</c> if the specified model state dictionary has warnings; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasWarnings(this ModelStateDictionary modelStateDictionary)
        {
            return modelStateDictionary.Values.Any(m =>
                {
                    var extendedModelState = m as ExtendedModelState;
                    if (extendedModelState == null)
                    {
                        return true;
                    }
                    return (extendedModelState.Warnings.Count == 0);
                });
        }

        /// <summary>
        /// Gets the warnings.
        /// </summary>
        /// <param name="modelStateDictionary">The model state dictionary.</param>
        /// <returns></returns>
        public static ModelStateDictionary GetWarnings(this ModelStateDictionary modelStateDictionary)
        {
            var msd = new ModelStateDictionary();
            foreach (var ms in from ms in modelStateDictionary
                               let extendedModelState = ms.Value as ExtendedModelState
                               where extendedModelState != null
                               where extendedModelState.Warnings.Count != 0
                               select ms)
            {
                msd.Add(ms);
            }
            return msd;
        }
    }
}