using api.FriendsVersus.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    interface IUserData
    {
        Task<UserCreationResponse> CreateUserAsync(UserCreationRequest request, CancellationToken token);
        Task<UserCreationResponse> AuthenticateCreationAsync(UserEmailAuthenticationRequest request, CancellationToken token);

    }
}
