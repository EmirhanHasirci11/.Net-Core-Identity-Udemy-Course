#pragma checksum "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6de96cb241989fbfd8f60d0ba5eaae3e97344ed2"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6de96cb241989fbfd8f60d0ba5eaae3e97344ed2", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"666b5190aaada8a4fadbc1bfb89bc9f1a9ac2df7", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AppUser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Admin_Layout_.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1 style=""text-align:center"">Kullanıcılar listesi</h1>
<table class=""table table-bordered table-striped"">
    <thead>
        <tr>
            <th>ID</th>
            <th>UserName</th>
            <th>E-mail</th>
        </tr>
    </thead>
    <tbody>         
");
#nullable restore
#line 16 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Admin\Index.cshtml"
             if (Model.Count() == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n\r\n                <td style=\"text-align:center\" colspan=\"3\">Hiçbir üye bulunmamaktadır</td>\r\n                </tr>\r\n");
#nullable restore
#line 22 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Admin\Index.cshtml"
            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Admin\Index.cshtml"
                 foreach(var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 28 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Admin\Index.cshtml"
                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 29 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Admin\Index.cshtml"
                       Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 30 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Admin\Index.cshtml"
                       Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 32 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Admin\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\emir_\source\repos\IdentityUdemyCourse\IdentityUdemyCourse\Views\Admin\Index.cshtml"
                 
            }        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AppUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
