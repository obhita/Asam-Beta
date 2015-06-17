namespace Asam.Ppc.Service.Handlers.Organization
{
    #region

    using System.Linq;
    using Common;
    using Domain.CommonModule;
    using Domain.CommonModule.Lookups;
    using Domain.CommonModule.ValueObjects;
    using Domain.OrganizationModule;
    using Infrastructure;
    using Messages.Common;
    using Messages.Organization;
    using Pillar.Domain.Primitives;
    using global::AutoMapper;

    #endregion

    public class AddAddressToOrganizationRequestHandler :
        ServiceRequestHandler<AddDtoRequest<OrganizationAddressDto>, AddDtoResponse<OrganizationAddressDto>>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public AddAddressToOrganizationRequestHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        protected override void Handle(AddDtoRequest<OrganizationAddressDto> request, AddDtoResponse<OrganizationAddressDto> response)
        {
            var organization = _organizationRepository.GetByKey( UserContext.IsSystemAdmin ? request.AggregateKey : UserContext.OrganizationKey);
            var addressDto = request.DataTransferObject.Address;
            var address = new Address(addressDto.FirstStreetAddress,
                                      addressDto.SecondStreetAddress,
                                      addressDto.CityName,
                                      Lookup.Find<StateProvince>(addressDto.StateProvince.Code),
                                      new PostalCode(addressDto.PostalCode));

            var organizationAddressType = Lookup.Find<OrganizationAddressType>(request.DataTransferObject.OrganizationAddressType.Code);
            var organizationAddress = new OrganizationAddress(organizationAddressType, address, request.DataTransferObject.IsPrimary);
            var originalAddress = organization.OrganizationAddresses.FirstOrDefault(a => a.Key == request.DataTransferObject.OriginalHash);
            if (originalAddress != organizationAddress)
            {
                if (originalAddress != null)
                {
                    organization.RemoveAddress(originalAddress);
                }
                organization.AddAddress(organizationAddress);
            }
            else if (organizationAddress.IsPrimary)
            {
                organization.MakePrimary(organizationAddress);
            }
            response.AggregateKey = organization.Key;
            response.DataTransferObject = Mapper.Map<OrganizationAddress, OrganizationAddressDto>(organizationAddress);
            response.DataTransferObject.Key = organization.Key;
        }
    }
}