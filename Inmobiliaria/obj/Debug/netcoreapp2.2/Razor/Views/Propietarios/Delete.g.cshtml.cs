#pragma checksum "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2af123a879bb65c7ab76cd77080b670e2178c54f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Propietarios_Delete), @"mvc.1.0.view", @"/Views/Propietarios/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Propietarios/Delete.cshtml", typeof(AspNetCore.Views_Propietarios_Delete))]
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
#line 1 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\_ViewImports.cshtml"
using Inmobiliaria;

#line default
#line hidden
#line 2 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\_ViewImports.cshtml"
using Inmobiliaria.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2af123a879bb65c7ab76cd77080b670e2178c54f", @"/Views/Propietarios/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edf381669dde6995b9201d231bb8643b95e5b7cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Propietarios_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Inmobiliaria.Models.Propietario>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(84, 198, true);
            WriteLiteral("\r\n<h1>Eliminar Propietario</h1>\r\n\r\n<h3>??Est??s seguro que quieres eliminar esto?</h3>\r\n<div>\r\n    <h4>Propietario</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(283, 49, false);
#line 15 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdPropietario));

#line default
#line hidden
            EndContext();
            BeginContext(332, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(396, 45, false);
#line 18 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdPropietario));

#line default
#line hidden
            EndContext();
            BeginContext(441, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(504, 42, false);
#line 21 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(546, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(610, 38, false);
#line 24 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(648, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(711, 44, false);
#line 27 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Apellido));

#line default
#line hidden
            EndContext();
            BeginContext(755, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(819, 40, false);
#line 30 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Apellido));

#line default
#line hidden
            EndContext();
            BeginContext(859, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(922, 41, false);
#line 33 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(963, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1027, 37, false);
#line 36 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1064, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1127, 41, false);
#line 39 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Clave));

#line default
#line hidden
            EndContext();
            BeginContext(1168, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1232, 37, false);
#line 42 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Clave));

#line default
#line hidden
            EndContext();
            BeginContext(1269, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1332, 44, false);
#line 45 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Telefono));

#line default
#line hidden
            EndContext();
            BeginContext(1376, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1440, 40, false);
#line 48 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Telefono));

#line default
#line hidden
            EndContext();
            BeginContext(1480, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1543, 39, false);
#line 51 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Dni));

#line default
#line hidden
            EndContext();
            BeginContext(1582, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1646, 35, false);
#line 54 "C:\Users\USUARIO\source\repos\InmobiliariaWeb\Inmobiliaria\Views\Propietarios\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Dni));

#line default
#line hidden
            EndContext();
            BeginContext(1681, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(1719, 183, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2af123a879bb65c7ab76cd77080b670e2178c54f10708", async() => {
                BeginContext(1745, 85, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Eliminar\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(1830, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2af123a879bb65c7ab76cd77080b670e2178c54f11184", async() => {
                    BeginContext(1852, 33, true);
                    WriteLiteral("Volver a la lista de propietarios");
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
                BeginContext(1889, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1902, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Inmobiliaria.Models.Propietario> Html { get; private set; }
    }
}
#pragma warning restore 1591
