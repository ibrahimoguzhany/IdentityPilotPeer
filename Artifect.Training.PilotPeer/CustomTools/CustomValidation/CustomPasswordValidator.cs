using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Arfitect.Training.PilotPeer.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Arfitect.Training.PilotPeer.CustomTools.CustomValidation
{
    public class CustomPasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                if (!user.Email.Contains(user.UserName))
                {
                    errors.Add(new IdentityError()
                    { Code = "PasswordContainsUserName", Description = "Şifre alanı kullanıcı adı içeremez" });
                }
            }
            if (password.ToLower().Contains(user.Email.ToLower()))
            {
                errors.Add(new IdentityError()
                { Code = "PasswordContainsEmail", Description = "Şifre alanı email adresinizi içeremez" });
            }
            //if(password.ToLower().Contains("1234"))
            //{
            //    errors.Add(new IdentityError()
            //        { Code = "PasswordContainsUser1234", Description = "Şifre alanı ardisik sayi içeremez" });
            //}
            if (errors.Count == 0)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

        }
    }
}
