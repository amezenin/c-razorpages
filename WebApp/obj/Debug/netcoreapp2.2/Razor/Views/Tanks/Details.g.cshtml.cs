#pragma checksum "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "469c53bda60b6b1a57ec597c64d703a9f7620c54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tanks_Details), @"mvc.1.0.view", @"/Views/Tanks/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tanks/Details.cshtml", typeof(AspNetCore.Views_Tanks_Details))]
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
#line 1 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#line 2 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"469c53bda60b6b1a57ec597c64d703a9f7620c54", @"/Views/Tanks/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Tanks_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BLL.App.DTO.Tank>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(25, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(70, 127, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Tank</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(198, 40, false);
#line 14 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(238, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(302, 36, false);
#line 17 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(338, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(401, 45, false);
#line 20 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Dimension));

#line default
#line hidden
            EndContext();
            BeginContext(446, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(510, 41, false);
#line 23 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Dimension));

#line default
#line hidden
            EndContext();
            BeginContext(551, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(614, 44, false);
#line 26 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(658, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(722, 40, false);
#line 29 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(762, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(825, 47, false);
#line 32 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AverageMass));

#line default
#line hidden
            EndContext();
            BeginContext(872, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(936, 43, false);
#line 35 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayFor(model => model.AverageMass));

#line default
#line hidden
            EndContext();
            BeginContext(979, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1042, 43, false);
#line 38 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RealFcr));

#line default
#line hidden
            EndContext();
            BeginContext(1085, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1149, 39, false);
#line 41 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayFor(model => model.RealFcr));

#line default
#line hidden
            EndContext();
            BeginContext(1188, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1251, 42, false);
#line 44 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RealNh));

#line default
#line hidden
            EndContext();
            BeginContext(1293, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1357, 38, false);
#line 47 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayFor(model => model.RealNh));

#line default
#line hidden
            EndContext();
            BeginContext(1395, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1458, 42, false);
#line 50 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RealNo));

#line default
#line hidden
            EndContext();
            BeginContext(1500, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1564, 38, false);
#line 53 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayFor(model => model.RealNo));

#line default
#line hidden
            EndContext();
            BeginContext(1602, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1665, 40, false);
#line 56 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Farm));

#line default
#line hidden
            EndContext();
            BeginContext(1705, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1769, 41, false);
#line 59 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Farm.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1810, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1873, 44, false);
#line 62 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FishType));

#line default
#line hidden
            EndContext();
            BeginContext(1917, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1981, 48, false);
#line 65 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
       Write(Html.DisplayFor(model => model.FishType.Species));

#line default
#line hidden
            EndContext();
            BeginContext(2029, 27, true);
            WriteLiteral("\r\n        </dd>\r\n        \r\n");
            EndContext();
            BeginContext(3231, 30, true);
            WriteLiteral("    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(3261, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "469c53bda60b6b1a57ec597c64d703a9f7620c5411761", async() => {
                BeginContext(3307, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 107 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3315, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(3323, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "469c53bda60b6b1a57ec597c64d703a9f7620c5414077", async() => {
                BeginContext(3345, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3361, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BLL.App.DTO.Tank> Html { get; private set; }
    }
}
#pragma warning restore 1591
