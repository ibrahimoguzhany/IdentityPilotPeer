using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artifect.PilotPeer.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Artifect.PilotPeer.CustomTagHelpers
{

    [HtmlTargetElement("td", Attributes = "user-roles")]
    public class UserRolesName : TagHelper
    {
        public UserManager<AppUser> UserManager { get; }
        public UserRolesName(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }

        [HtmlAttributeName("user-roles")]
        public string UserId { get; set; }


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            AppUser user = await UserManager.FindByIdAsync(UserId);

            IList<string> roles = await UserManager.GetRolesAsync(user);

            string html = string.Empty;

            roles.ToList().ForEach(x =>
            {
                html += $"<span class='badge badge-info'>{x}</span>";
            });
            output.Content.SetHtmlContent(html);
        }
    }
}
