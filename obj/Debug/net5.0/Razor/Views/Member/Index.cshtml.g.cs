#pragma checksum "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Member\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9d3361c6da6a33242029db74414992d26118a85"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Member_Index), @"mvc.1.0.view", @"/Views/Member/Index.cshtml")]
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
#line 1 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\_ViewImports.cshtml"
using IdentityUdemyCourse;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\_ViewImports.cshtml"
using IdentityUdemyCourse.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\_ViewImports.cshtml"
using IdentityUdemyCourse.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9d3361c6da6a33242029db74414992d26118a85", @"/Views/Member/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8adbf17581e1360b38b487693930e13a6ff4a4a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Member_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Member\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Member_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3 class=\"text-center\">Kullanıcı bilgileri</h3>\r\n<div class=\"row\">\r\n    <div class=\"col-sm-3\">\r\n        <div class=\"col-12\">\r\n\r\n        <img style=\"width:100%;height:100%;\" class=\"rounded-circle\"");
            BeginWriteAttribute("src", " src=\"", 315, "\"", 335, 1);
#nullable restore
#line 12 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Member\Index.cshtml"
WriteAttributeValue("", 321, Model.Picture, 321, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        </div>\r\n    </div>\r\n    <div class=\"col-sm-9\">\r\n        <table class=\"table table-bordered table-striped\">\r\n            <tr>\r\n                <th>Kullanıcı İsmi</th>\r\n                <td>");
#nullable restore
#line 19 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Member\Index.cshtml"
               Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Mail</th>\r\n                <td> ");
#nullable restore
#line 23 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Member\Index.cshtml"
                Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Telefon</th>\r\n                <td>");
#nullable restore
#line 27 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Member\Index.cshtml"
               Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Şehir</th>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Member\Index.cshtml"
               Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Doğum Tarihi</th>\r\n                <td>");
#nullable restore
#line 35 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Member\Index.cshtml"
               Write(Model.BirthDate.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>       \r\n\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
