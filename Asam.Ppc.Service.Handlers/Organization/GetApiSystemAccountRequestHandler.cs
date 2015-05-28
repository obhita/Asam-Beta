using Asam.Ppc.Domain.SecurityModule;
using Asam.Ppc.Service.Messages.Security;

namespace Asam.Ppc.Service.Handlers.Organization
{
    using Common;
    using Messages.Common;
    using global::AutoMapper;

    public class GetApiSystemAccountRequestHandler : ServiceRequestHandler<GetApiSystemAccountRequest, DtoResponse<ApiSystemAccountDto>>
    {
        private readonly IApiSystemAccountRepository _apiSystemAccountRepository;

        public GetApiSystemAccountRequestHandler(IApiSystemAccountRepository apiSystemAccountRepository)
        {
            _apiSystemAccountRepository = apiSystemAccountRepository;
        }

        protected override void Handle(GetApiSystemAccountRequest request, DtoResponse<ApiSystemAccountDto> response)
        {
            var apiSystemAccount = _apiSystemAccountRepository.GetByApiCombinationKey(request.EhrId, request.OrganizationKey, request.UserId, request.UserName, request.UserEmail);
            response.DataTransferObject = Mapper.Map<ApiSystemAccount, ApiSystemAccountDto>(apiSystemAccount);
        }
    }
}