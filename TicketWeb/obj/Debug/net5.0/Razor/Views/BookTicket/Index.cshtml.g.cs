#pragma checksum "D:\PBL3-TicketWeb\TicketWeb\Views\BookTicket\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a97e80b888c07d081732f1e628d1686c8f4a442"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BookTicket_Index), @"mvc.1.0.view", @"/Views/BookTicket/Index.cshtml")]
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
#line 1 "D:\PBL3-TicketWeb\TicketWeb\Views\_ViewImports.cshtml"
using TicketWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PBL3-TicketWeb\TicketWeb\Views\_ViewImports.cshtml"
using TicketWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a97e80b888c07d081732f1e628d1686c8f4a442", @"/Views/BookTicket/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8fb632d47e17aa42a9fa559e95a81be29ee3cc51", @"/Views/_ViewImports.cshtml")]
    public class Views_BookTicket_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TicketWeb.Data.ChuyenBay>>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\PBL3-TicketWeb\TicketWeb\Views\BookTicket\Index.cshtml"
  
    ViewData["Title"] = "BookTicket";
    Layout = "_LayoutPortal3";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .header {
        background-color: #1559b6;
        text-align: center;
        padding: 5px;
        border-bottom: 2px ridge #ffffff;
        font-size: 30px;
        color: azure;
        font-family: sans-serif;
    }

.btn_select { border-radius: 5px; color: #ffffff; background-image: url(""https://olala.vn/images/ic_flight-gray.png"");
              padding: 10px; 

}

body { background-color: #90e3fc;
       line-height: 3.5; 
}
</style>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a97e80b888c07d081732f1e628d1686c8f4a4423778", async() => {
                WriteLiteral("\r\n    <title>Đặt Vé</title>\r\n    <div class=\"header\">\r\n        <h1 class=\"head-title\">ĐẶT VÉ</h1>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 39 "D:\PBL3-TicketWeb\TicketWeb\Views\BookTicket\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.SanBayDi_ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("            \r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 42 "D:\PBL3-TicketWeb\TicketWeb\Views\BookTicket\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.SanBayDen_ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 45 "D:\PBL3-TicketWeb\TicketWeb\Views\BookTicket\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ThoiGianDuKienBay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 51 "D:\PBL3-TicketWeb\TicketWeb\Views\BookTicket\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 54 "D:\PBL3-TicketWeb\TicketWeb\Views\BookTicket\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.SanBayDi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 57 "D:\PBL3-TicketWeb\TicketWeb\Views\BookTicket\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.SanBayDen));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 60 "D:\PBL3-TicketWeb\TicketWeb\Views\BookTicket\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ThoiGianDuKienBay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>    \r\n            <td>\r\n                <a class=\"btn_select\" >Chọn</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 66 "D:\PBL3-TicketWeb\TicketWeb\Views\BookTicket\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TicketWeb.Data.ChuyenBay>> Html { get; private set; }
    }
}
#pragma warning restore 1591