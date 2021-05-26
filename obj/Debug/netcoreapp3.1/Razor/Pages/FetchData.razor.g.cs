#pragma checksum "C:\sources\insti-knowledge-o365\Pages\FetchData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9356795c0a181e27150ddb0c0ab5d91b1d479b5c"
// <auto-generated/>
#pragma warning disable 1591
namespace blazor_base.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\sources\insti-knowledge-o365\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\sources\insti-knowledge-o365\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\sources\insti-knowledge-o365\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\sources\insti-knowledge-o365\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\sources\insti-knowledge-o365\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\sources\insti-knowledge-o365\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\sources\insti-knowledge-o365\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\sources\insti-knowledge-o365\_Imports.razor"
using blazor_base.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
using blazor_base;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public partial class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>O:365 C:luster P:harm</h1>\r\n\r\n");
            __builder.AddMarkupContent(1, "<p>This WebApp consumes O365 email and Clusters the content into unlabeled groups</p>\r\n\r\n");
#nullable restore
#line 10 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
 if (IsLoading)
{
    if (LoadingTemplate != null)
    {
        

#line default
#line hidden
#nullable disable
            __builder.AddContent(2, 
#nullable restore
#line 14 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
         LoadingTemplate

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 14 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
                        
    }
    else
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(3, "        <div class=\"spinner-border\"></div>\r\n        ");
            __builder.OpenElement(4, "span");
            __builder.AddAttribute(5, "style", "display: inline-block; vertical-align: super");
            __builder.AddContent(6, 
#nullable restore
#line 19 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
                                                                    LoadingText

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n");
#nullable restore
#line 20 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
    }
}
else
{
    

#line default
#line hidden
#nullable disable
            __builder.AddContent(8, 
#nullable restore
#line 24 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
     ChildContent

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 24 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
                 
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(9, "\r\n");
#nullable restore
#line 40 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
 if (!submissionSuccess)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(10, "    ");
            __builder.AddMarkupContent(11, "<p>You are not logged in</p>\r\n");
#nullable restore
#line 43 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(12, "    ");
            __builder.OpenElement(13, "table");
            __builder.AddAttribute(14, "class", "table");
            __builder.AddMarkupContent(15, "\r\n        ");
            __builder.OpenElement(16, "thead");
            __builder.AddMarkupContent(17, "\r\n            ");
            __builder.OpenElement(18, "tr");
            __builder.AddMarkupContent(19, "\r\n                ");
            __builder.OpenElement(20, "th");
            __builder.AddContent(21, "Logged in? ");
            __builder.AddContent(22, 
#nullable restore
#line 49 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
                                o365Data.LoggedIn.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n        ");
            __builder.OpenElement(26, "tbody");
            __builder.AddMarkupContent(27, "\r\n\r\n            ");
            __builder.OpenElement(28, "tr");
            __builder.AddMarkupContent(29, "\r\n                ");
            __builder.OpenElement(30, "td");
            __builder.AddContent(31, " k =  ");
            __builder.AddContent(32, 
#nullable restore
#line 59 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
                           o365Data.kStr

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n\r\n                <td></td>\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n");
#nullable restore
#line 80 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(37, "\r\n\r\n\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(38);
            __builder.AddAttribute(39, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 84 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
                  O365txt

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(40, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 84 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
                                          (async () => await SendCredsGetData())

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(41, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(42, "\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(43);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(44, "\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(45);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(46, "\r\n    e:mail\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(47);
                __builder2.AddAttribute(48, "id", "Username");
                __builder2.AddAttribute(49, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 88 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
                                          o365Data.Username

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(50, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => o365Data.Username = __value, o365Data.Username))));
                __builder2.AddAttribute(51, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => o365Data.Username));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(52, "\r\n    p:assword\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(53);
                __builder2.AddAttribute(54, "id", "Password");
                __builder2.AddAttribute(55, "type", "password");
                __builder2.AddAttribute(56, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 90 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
                                          o365Data.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(57, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => o365Data.Password = __value, o365Data.Password))));
                __builder2.AddAttribute(58, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => o365Data.Password));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(59, "\r\n    N:umber of Clusters\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(60);
                __builder2.AddAttribute(61, "id", "kStr");
                __builder2.AddAttribute(62, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 92 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
                                      o365Data.kStr

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(63, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => o365Data.kStr = __value, o365Data.kStr))));
                __builder2.AddAttribute(64, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => o365Data.kStr));
                __builder2.AddAttribute(65, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(66, "2");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(67, "\r\n    N:umber of Msgs to Cluster\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(68);
                __builder2.AddAttribute(69, "id", "documents");
                __builder2.AddAttribute(70, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 94 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
                                           o365Data.documents

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(71, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => o365Data.documents = __value, o365Data.documents))));
                __builder2.AddAttribute(72, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => o365Data.documents));
                __builder2.AddAttribute(73, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(74, "2");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(75, "\r\n\r\n    ");
                __builder2.OpenElement(76, "button");
                __builder2.AddAttribute(77, "id", "submitter");
                __builder2.AddAttribute(78, "type", "submit");
                __builder2.AddElementReferenceCapture(79, (__value) => {
#nullable restore
#line 96 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
                 buttonSend = __value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.AddContent(80, "Organize / Cluster my Email");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(81, "\r\n");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 26 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
      
    [Parameter]
    public bool IsLoading { get; set; }

    [Parameter]
    public string LoadingText { get; set; } = "Loading...";

    [Parameter]
    public RenderFragment LoadingTemplate { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

#line default
#line hidden
#nullable disable
#nullable restore
#line 103 "C:\sources\insti-knowledge-o365\Pages\FetchData.razor"
       

    private O365Data o365Data = null;

    protected override async Task OnInitializedAsync()
    {
        o365Data = new O365Data();
    }

    private ElementReference buttonSend;
    private ElementReference buttonCluster;

    private bool submissionSuccess = false;
    private bool clusterSuccess = false;

    public async Task SendCredsGetData()
    {
        o365Data.GetData();
        if (o365Data.LoggedIn) { submissionSuccess = true; }
    }

    public async Task ClusterTheData() { }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private O365Data O365txt { get; set; }
    }
}
#pragma warning restore 1591
