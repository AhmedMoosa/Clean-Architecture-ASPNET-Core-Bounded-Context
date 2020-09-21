using Demo.SharedKernel.DTOs;
using Demo.SharedKernel.Interfaces;
using Demo.Users.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Users.Core.Interfaces
{
    public interface IAuthenticationService : ICreateForAsync<InputUser>
    {
        Task<OperationResult> ValidateUserAsync(string userName, string password, bool rememberMe);
    }
}
