#pragma checksum "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b47c9b0ed2b15b9318cc68a283f29141f88ee8dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tanks_Index), @"mvc.1.0.view", @"/Views/Tanks/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tanks/Index.cshtml", typeof(AspNetCore.Views_Tanks_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b47c9b0ed2b15b9318cc68a283f29141f88ee8dc", @"/Views/Tanks/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Tanks_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BLL.App.DTO.TankDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Feed", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(84, 29, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(113, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b47c9b0ed2b15b9318cc68a283f29141f88ee8dc4956", async() => {
                BeginContext(136, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(150, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(243, 40, false);
#line 16 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(283, 69, true);
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th>\r\n                ");
            EndContext();
            BeginContext(353, 45, false);
#line 20 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Dimension));

#line default
#line hidden
            EndContext();
            BeginContext(398, 69, true);
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th>\r\n                ");
            EndContext();
            BeginContext(468, 44, false);
#line 24 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(512, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(568, 47, false);
#line 27 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.AverageMass));

#line default
#line hidden
            EndContext();
            BeginContext(615, 21, true);
            WriteLiteral("\r\n            </th>\r\n");
            EndContext();
            BeginContext(963, 34, true);
            WriteLiteral("            <th>\r\n                ");
            EndContext();
            BeginContext(998, 40, false);
#line 41 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Farm));

#line default
#line hidden
            EndContext();
            BeginContext(1038, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1094, 44, false);
#line 44 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FishType));

#line default
#line hidden
            EndContext();
            BeginContext(1138, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1194, 43, false);
#line 47 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Biomass));

#line default
#line hidden
            EndContext();
            BeginContext(1237, 68, true);
            WriteLiteral("\r\n            </th>\r\n           \r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1306, 47, false);
#line 51 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FeedPercent));

#line default
#line hidden
            EndContext();
            BeginContext(1353, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1409, 42, false);
#line 54 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FeedKg));

#line default
#line hidden
            EndContext();
            BeginContext(1451, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1507, 46, false);
#line 57 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.GrowingDay));

#line default
#line hidden
            EndContext();
            BeginContext(1553, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1609, 46, false);
#line 60 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NewBiomass));

#line default
#line hidden
            EndContext();
            BeginContext(1655, 56, true);
            WriteLiteral("\r\n            </th> \r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1712, 43, false);
#line 63 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Density));

#line default
#line hidden
            EndContext();
            BeginContext(1755, 56, true);
            WriteLiteral("\r\n            </th> \r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1812, 46, false);
#line 66 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NewAverage));

#line default
#line hidden
            EndContext();
            BeginContext(1858, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 72 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(1976, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2025, 39, false);
#line 75 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(2064, 69, true);
            WriteLiteral("\r\n            </td>\r\n            \r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2134, 44, false);
#line 79 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Dimension));

#line default
#line hidden
            EndContext();
            BeginContext(2178, 69, true);
            WriteLiteral("\r\n            </td>\r\n            \r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2248, 43, false);
#line 83 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(2291, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2347, 46, false);
#line 86 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.AverageMass));

#line default
#line hidden
            EndContext();
            BeginContext(2393, 21, true);
            WriteLiteral("\r\n            </td>\r\n");
            EndContext();
            BeginContext(2738, 34, true);
            WriteLiteral("            <td>\r\n                ");
            EndContext();
            BeginContext(2773, 44, false);
#line 100 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Farm.Name));

#line default
#line hidden
            EndContext();
            BeginContext(2817, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2873, 51, false);
#line 103 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FishType.Species));

#line default
#line hidden
            EndContext();
            BeginContext(2924, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2980, 42, false);
#line 106 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Biomass));

#line default
#line hidden
            EndContext();
            BeginContext(3022, 65, true);
            WriteLiteral("\r\n            </td>\r\n        \r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3088, 46, false);
#line 110 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FeedPercent));

#line default
#line hidden
            EndContext();
            BeginContext(3134, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3190, 41, false);
#line 113 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FeedKg));

#line default
#line hidden
            EndContext();
            BeginContext(3231, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3287, 45, false);
#line 116 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.GrowingDay));

#line default
#line hidden
            EndContext();
            BeginContext(3332, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3388, 45, false);
#line 119 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NewBiomass));

#line default
#line hidden
            EndContext();
            BeginContext(3433, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3489, 42, false);
#line 122 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Density));

#line default
#line hidden
            EndContext();
            BeginContext(3531, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3587, 45, false);
#line 125 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NewAverage));

#line default
#line hidden
            EndContext();
            BeginContext(3632, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3687, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b47c9b0ed2b15b9318cc68a283f29141f88ee8dc17778", async() => {
                BeginContext(3732, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 128 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
                                       WriteLiteral(item.Id);

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
            BeginContext(3740, 19, true);
            WriteLiteral(" \r\n                ");
            EndContext();
            BeginContext(3759, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b47c9b0ed2b15b9318cc68a283f29141f88ee8dc20115", async() => {
                BeginContext(3807, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 129 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
                                          WriteLiteral(item.Id);

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
            BeginContext(3818, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(3836, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b47c9b0ed2b15b9318cc68a283f29141f88ee8dc22457", async() => {
                BeginContext(3883, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 130 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
                                         WriteLiteral(item.Id);

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
            BeginContext(3893, 19, true);
            WriteLiteral(" \r\n                ");
            EndContext();
            BeginContext(3912, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b47c9b0ed2b15b9318cc68a283f29141f88ee8dc24798", async() => {
                BeginContext(3957, 4, true);
                WriteLiteral("Feed");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 131 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
                                       WriteLiteral(item.Id);

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
            BeginContext(3965, 73, true);
            WriteLiteral(" \r\n                \r\n                \r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 136 "C:\itcollege\VR2\icd0009-2018\FishFarm\WebApp\Views\Tanks\Index.cshtml"
}

#line default
#line hidden
            BeginContext(4041, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BLL.App.DTO.TankDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
