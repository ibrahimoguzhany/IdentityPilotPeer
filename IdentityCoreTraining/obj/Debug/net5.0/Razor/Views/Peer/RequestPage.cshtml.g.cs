#pragma checksum "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Peer\RequestPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee9f6778b260ee9b2666fa73d2f28fa41235e3e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Peer_RequestPage), @"mvc.1.0.view", @"/Views/Peer/RequestPage.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 3 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\_ViewImports.cshtml"
using IdentityCoreTraining.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\_ViewImports.cshtml"
using IdentityCoreTraining.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\_ViewImports.cshtml"
using IdentityCoreTraining.Models.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee9f6778b260ee9b2666fa73d2f28fa41235e3e7", @"/Views/Peer/RequestPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c549273d4e1859bdb703b029db66939b2c5c0031", @"/Views/_ViewImports.cshtml")]
    public class Views_Peer_RequestPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SupportRequestViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Peer\RequestPage.cshtml"
  
    Layout = "~/Views/Peer/_PeerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h3>Request Page</h3>


<table class=""table table-striped table-bordered"">

    <tr>
        <th>Id</th>
        <th>Name</th>
        <th>Email Address</th>
        <th>Phone number</th>
        <th>Peer Note</th>
        <th>Status</th>
        <th>Base Information</th>
        <th>How soon wants to be contacted</th>
        <th>Language Preferency</th>
        <th>User Id</th>
        <th>Islemler</th>
    </tr>

    <td>");
#nullable restore
#line 25 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Peer\RequestPage.cshtml"
   Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 26 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Peer\RequestPage.cshtml"
       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 27 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Peer\RequestPage.cshtml"
       Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 28 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Peer\RequestPage.cshtml"
       Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 29 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Peer\RequestPage.cshtml"
       Write(Model.PeerNote);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 30 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Peer\RequestPage.cshtml"
       Write(Model.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 31 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Peer\RequestPage.cshtml"
       Write(Model.BaseInformation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 32 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Peer\RequestPage.cshtml"
       Write(Model.HowSoonWantsToBeContacted);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 33 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Peer\RequestPage.cshtml"
       Write(Model.LanguagePreferency);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 34 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Peer\RequestPage.cshtml"
   Write(Model.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    \r\n\r\n\r\n\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SupportRequestViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591