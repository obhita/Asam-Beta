namespace Asam.Ppc.Service.Handlers.Organization
{
    #region Using Statements

    using Common;
    using Domain.OrganizationModule;
    using Domain.SecurityModule;
    using Messages.Organization;
    using Messages.Security;
    using global::AutoMapper;

    #endregion

    /// <summary>
    ///     Handler for getting <see cref="StaffDto" />
    /// </summary>
    public class GetStaffDtoByKeyRequestHandler : ServiceRequestHandler<GetStaffDtoByKeyRequest, GetStaffDtoResponse>
    {
        #region Fields

        private readonly IStaffRepository _staffRepository;
        private readonly ISystemAccountRepository _systemAccountRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetStaffDtoByKeyRequestHandler" /> class.
        /// </summary>
        /// <param name="staffRepository">The staff repository.</param>
        /// <param name="systemAccountRepository">The system account repository.</param>
        public GetStaffDtoByKeyRequestHandler ( IStaffRepository staffRepository, ISystemAccountRepository systemAccountRepository )
        {
            _staffRepository = staffRepository;
            _systemAccountRepository = systemAccountRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle ( GetStaffDtoByKeyRequest request, GetStaffDtoResponse response )
        {
            var staff = _staffRepository.GetByKey ( request.Key );
            var staffDto = Mapper.Map<Staff, StaffDto> ( staff );

            var systemAccount = _systemAccountRepository.GetByStaffKey ( staff.Key );
            if ( systemAccount != null )
            {
                var systemAccountDto = Mapper.Map<SystemAccount, SystemAccountDto> ( systemAccount );

                staffDto.SystemAccount = systemAccountDto;
            }
            response.DataTransferObject = staffDto;
        }

        #endregion
    }
}