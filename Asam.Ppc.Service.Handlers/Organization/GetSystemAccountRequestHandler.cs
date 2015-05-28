using Asam.Ppc.Domain.SecurityModule;
using Asam.Ppc.Service.Messages.Security;

namespace Asam.Ppc.Service.Handlers.Organization
{
    using Common;
    using Messages.Common;
    using global::AutoMapper;

    public class GetSystemAccountRequestHandler: ServiceRequestHandler<GetDtoByKeyRequest<SystemAccountDto>, DtoResponse<SystemAccountDto> >
    {
        private readonly ISystemAccountRepository _systemAccountRepository;

        public GetSystemAccountRequestHandler(ISystemAccountRepository systemAccountRepository)
        {
            _systemAccountRepository = systemAccountRepository;
        }

        protected override void Handle(GetDtoByKeyRequest<SystemAccountDto> request, DtoResponse<SystemAccountDto> response)
        {
            var systemAccount = _systemAccountRepository.GetByKey(request.Key);
            response.DataTransferObject = Mapper.Map<SystemAccount, SystemAccountDto>(systemAccount);
        }
    }
}