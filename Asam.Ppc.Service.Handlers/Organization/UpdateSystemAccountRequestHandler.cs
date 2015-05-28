using Asam.Ppc.Domain.SecurityModule;
using Asam.Ppc.Service.Messages.Security;

namespace Asam.Ppc.Service.Handlers.Organization
{
    #region Using Statements

    using Common;
    using Messages.Common;
    using Messages.Organization;
    using global::AutoMapper;

    #endregion

    /// <summary>
    ///     Handler for update system account requests.
    /// </summary>
    public class UpdateSystemAccountRequestHandler :
        ServiceRequestHandler<UpdateSystemAccountRequest, DtoResponse<SystemAccountDto>>
    {
        private readonly ISystemAccountRepository _systemAccountRepository;

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSystemAccountRequestHandler" /> class.
        /// </summary>
        /// <param name="systemAccountRepository">The system acount repository.</param>
        public UpdateSystemAccountRequestHandler(ISystemAccountRepository systemAccountRepository)
        {
            _systemAccountRepository = systemAccountRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle(UpdateSystemAccountRequest request, DtoResponse<SystemAccountDto> response)
        {
            var systemAccount = _systemAccountRepository.GetByKey(request.Key);
            systemAccount.ReviseEulaSignDate(request.EulaAgreeDate);
            response.DataTransferObject = Mapper.Map<SystemAccount, SystemAccountDto>(systemAccount);
        }

        #endregion
    }
}