#pragma checksum "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eadc67fa7834146445cac8900d1adb2033f8a3f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
#line 2 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\_ViewImports.cshtml"
using IdentityCoreTraining.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\_ViewImports.cshtml"
using IdentityCoreTraining.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eadc67fa7834146445cac8900d1adb2033f8a3f1", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e38b8ffb181a79a64b67f634b1436cba29a7aee", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AppUser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table table-bordered table-striped\">\r\n\r\n    <tr>\r\n        <td>User Id</td>\r\n        <td>User Name</td>\r\n        <td>Email</td>\r\n    </tr>\r\n");
#nullable restore
#line 14 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Admin\Index.cshtml"
     if (Model.Count() < 1)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td colspan=\"3\">Hicbir uye yoktur.</td>\r\n        </tr>\r\n");
#nullable restore
#line 19 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Admin\Index.cshtml"
    }
    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Admin\Index.cshtml"
         foreach (var user in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Admin\Index.cshtml"
               Write(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Admin\Index.cshtml"
               Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Admin\Index.cshtml"
               Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 29 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Admin\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\oguzhan\source\repos\IdentityCoreTraining\IdentityCoreTraining\Views\Admin\Index.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AppUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591