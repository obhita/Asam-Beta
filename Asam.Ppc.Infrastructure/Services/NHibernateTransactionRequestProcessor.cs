namespace Asam.Ppc.Infrastructure.Services
{
    #region Using Statements

    using System.Collections.Generic;
    using System.Linq;
    using Agatha.Common;
    using Agatha.Common.Caching;
    using Agatha.ServiceLayer;
    using Domain;
    using NLog;
    using Newtonsoft.Json;
    using global::NHibernate;
    using global::NHibernate.Context;

    #endregion

    /// <summary>
    /// Request processor that manages nhibernate transaction.
    /// </summary>
    public class NHibernateTransactionRequestProcessor : RequestProcessorBase
    {
        #region Fields

        private readonly ISessionProvider _sessionProvider;
        private bool _validationFailureOccurred;
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="NHibernateTransactionRequestProcessor" /> class.
        /// </summary>
        /// <param name="serviceLayerConfiguration">The service layer configuration.</param>
        /// <param name="cacheManager">The cache manager.</param>
        /// <param name="sessionProvider">The session provider.</param>
        public NHibernateTransactionRequestProcessor (
            ServiceLayerConfiguration serviceLayerConfiguration,
            ICacheManager cacheManager,
            ISessionProvider sessionProvider )
            : base ( serviceLayerConfiguration, cacheManager )
        {
            _sessionProvider = sessionProvider;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Afters the processing.
        /// </summary>
        /// <param name="requests">The requests.</param>
        /// <param name="responses">The responses.</param>
        protected override void AfterProcessing ( IEnumerable<Request> requests, IEnumerable<Response> responses )
        {
            var session = _sessionProvider.GetSession ();
            responses = responses.ToList ();

            base.AfterProcessing(requests, responses);

            if ( Logger.IsTraceEnabled )
            {
                Logger.Trace ( "Responses: {0}",
                    JsonConvert.SerializeObject ( responses, new JsonSerializerSettings {ContractResolver = new SerializableContractResolver {IgnoreSerializableAttribute = true}} ) );
            }

            if ( !_validationFailureOccurred && session.Transaction.IsActive )
            {
                if ( !IsExceptionOccurred ( responses ) )
                {
                    Logger.Debug("Commiting Transaction");
                    session.Transaction.Commit ();
                }
            }
            else
            {
                Logger.Debug("Validation Error occured or No active Transanction.");
            }
        }

        /// <summary>
        ///     Befores the processing.
        /// </summary>
        /// <param name="requests">The requests.</param>
        protected override void BeforeProcessing ( IEnumerable<Request> requests )
        {
            Logger.Debug ( "Starting Nhibernate Sesssion and Transaction" );
            var session = _sessionProvider.GetSession ();
            session.FlushMode = FlushMode.Commit;
            session.BeginTransaction ();
            if ( Logger.IsTraceEnabled )
            {
                Logger.Trace ( "Requests: {0}",
                    JsonConvert.SerializeObject ( requests, new JsonSerializerSettings { ContractResolver = new SerializableContractResolver {IgnoreSerializableAttribute = true}, NullValueHandling = NullValueHandling.Ignore} ) );
            }
            base.BeforeProcessing ( requests );
        }

        /// <summary>
        ///     Disposes the unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanagedResources ()
        {
            base.DisposeUnmanagedResources ();

            if ( _sessionProvider != null )
            {
                var session = _sessionProvider.GetSession ();

                if ( session != null )
                {
                    var transaction = session.Transaction;
                    if ( transaction.IsActive )
                    {
                        transaction.Dispose ();
                    }

                    session.Dispose ();
                    CurrentSessionContext.Unbind ( _sessionProvider.SessionFactory );
                }
            }
        }

        private static bool IsExceptionOccurred ( IEnumerable<Response> responses )
        {
            return responses.Any ( p =>
                {
                    if ( p.Exception != null )
                    {
                        Logger.Debug("Exception in response: " + p.ToString());
                        Logger.Debug(p.Exception.Message + " - Stack Trace: " + p.Exception.StackTrace.ToString());
                        return true;
                    }
                    return false;
                } );
        }

        #endregion
    }
}