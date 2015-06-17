#region License Header

// /*******************************************************************************
//  * Open Behavioral Health Information Technology Architecture (OBHITA.org)
//  * 
//  * Redistribution and use in source and binary forms, with or without
//  * modification, are permitted provided that the following conditions are met:
//  *     * Redistributions of source code must retain the above copyright
//  *       notice, this list of conditions and the following disclaimer.
//  *     * Redistributions in binary form must reproduce the above copyright
//  *       notice, this list of conditions and the following disclaimer in the
//  *       documentation and/or other materials provided with the distribution.
//  *     * Neither the name of the <organization> nor the
//  *       names of its contributors may be used to endorse or promote products
//  *       derived from this software without specific prior written permission.
//  * 
//  * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
//  * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
//  * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//  * DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
//  * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
//  * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
//  * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
//  * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
//  * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//  * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//  ******************************************************************************/

#endregion

namespace Asam.Ppc.Service.Handlers.Security
{
    #region Using Statements

    using System;
    using System.Net;
    using System.Net.Http;
    using Common;
    using Domain.SecurityModule;
    using Infrastructure.Services;
    using Messages.Common;
    using Messages.Security;
    using NLog;
    using Pillar.Domain.Primitives;
    using global::AutoMapper;

    #endregion

    public class CreateSystemAdminRequestHandler : ServiceRequestHandler<CreateSystemAdminRequest, DtoResponse<SystemAccountDto>>
    {
        #region Fields

        private readonly IRoleRepository _roleRepository;
        private readonly ISystemAccountFactory _systemAccountFactory;
        private readonly ISystemAccountIdentityServiceManager _systemAccountIdentityServiceManager;
        private readonly ISystemAccountRepository _systemAccountRepository;
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors and Destructors

        public CreateSystemAdminRequestHandler ( ISystemAccountRepository systemAccountRepository,
                                                 IRoleRepository roleRepository,
                                                 ISystemAccountFactory systemAccountFactory,
                                                 ISystemAccountIdentityServiceManager systemAccountIdentityServiceManager )
        {
            _systemAccountRepository = systemAccountRepository;
            _roleRepository = roleRepository;
            _systemAccountFactory = systemAccountFactory;
            _systemAccountIdentityServiceManager = systemAccountIdentityServiceManager;
        }

        #endregion

        #region Methods

        protected override void Handle ( CreateSystemAdminRequest request, DtoResponse<SystemAccountDto> response )
        {
            var systemAccount = _systemAccountRepository.GetByIdentifier(request.Email);
            var role = _roleRepository.GetInternalRoleKeyByName("System Admin");
            if ( role != null )
            {
                if ( systemAccount == null )
                {
                    var identityServiceResponse = _systemAccountIdentityServiceManager.Create ( request.Username, request.Email );
                    if ( identityServiceResponse.Sucess )
                    {
                        systemAccount = _systemAccountFactory.CreateSystemAdmin(request.Email, new Email(request.Email));
                        var systemAccountDto = Mapper.Map<SystemAccount, SystemAccountDto>(systemAccount);
                        response.DataTransferObject = systemAccountDto;
                        systemAccount.AddRole(role);
                    }
                    else
                    {
                        var result = identityServiceResponse.ErrorMessage;
                        var dataErrorInfo = new DataErrorInfo(result, ErrorLevel.Error);
                        response.DataTransferObject = new SystemAccountDto();
                        response.DataTransferObject.AddDataErrorInfo(dataErrorInfo);
                    }
                }
                else
                {
                    var result = "System account already in use.";
                    var dataErrorInfo = new DataErrorInfo(result, ErrorLevel.Error);
                    response.DataTransferObject = new SystemAccountDto();
                    response.DataTransferObject.AddDataErrorInfo(dataErrorInfo);
                }
            }
        }

        #endregion
    }
}