using Demo.SharedKernel.DTOs;
using Demo.Users.Core.DTOs;
using Demo.Users.Core.Entities;
using Demo.Users.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Users.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        SignInManager<AspNetUsers> _signInManager;
        UserManager<AspNetUsers> _userManager;
        public AuthenticationService(SignInManager<AspNetUsers> signInMgr, UserManager<AspNetUsers> userMgr)
        {
            _signInManager = signInMgr;
            _userManager = userMgr;
        }

        public async Task<OperationResult> CreateForAsync(InputUser entityToCreate)
        {
            var userToCreate = new AspNetUsers
            {
                PhoneNumber = entityToCreate.Mobile,
                Email = entityToCreate.Email
            };
            userToCreate.UserName = !string.IsNullOrEmpty(entityToCreate.Email) ? entityToCreate.Email : entityToCreate.Mobile;
            var result = await _userManager.CreateAsync(userToCreate, entityToCreate.Password);
            if (result.Succeeded)
            {
                var user = new UserViewModel
                {
                    Email = userToCreate.Email,
                    Mobile = userToCreate.PhoneNumber,
                    Id = userToCreate.Id
                };
                return OperationResult.Succeeded(payload: user);
            }
            return OperationResult.Failed(payload: result);
        }

        public async Task<OperationResult> ValidateUserAsync(string userName, string password, bool rememberMe)
        {
            var normalizedUserName = _userManager.NormalizeName(userName);
            var existedUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedUserName || u.NormalizedEmail == normalizedUserName || u.PhoneNumber == normalizedUserName);
            if (existedUser != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(existedUser, password, true);
                if (result.Succeeded)
                {
                    var user = new UserViewModel
                    {
                        Email = existedUser.Email,
                        Mobile = existedUser.PhoneNumber,
                        Id = existedUser.Id
                    };
                    return OperationResult.Succeeded(payload: user);
                }
                //else if (result.IsNotAllowed)
                //{

                //}
                //else if (result.IsLockedOut)
                //{

                //}
                //else if (result.RequiresTwoFactor)
                //{

                //}
                return OperationResult.Failed(payload: result);
            }
            return OperationResult.Failed("Invalid User!.");
        }
    }
}