// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace blazor_base.Spinner_Service
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
#line 8 "C:\sources\insti-knowledge-o365\_Imports.razor"
using blazor_base;

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
#line 1 "C:\sources\insti-knowledge-o365\Spinner-Service\Spinner.razor"
using Faso.Blazor.SpinKit;

#line default
#line hidden
#nullable disable
    public partial class Spinner : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 21 "C:\sources\insti-knowledge-o365\Spinner-Service\Spinner.razor"
 
    protected bool IsVisible { get; set; }
    protected override void OnInitialized()
    {
        SpinnerService.OnShow += ShowSpinner;
        SpinnerService.OnHide += HideSpinner;
    }

    public void ShowSpinner()
    {
        IsVisible = true;
        StateHasChanged();
    }

    public void HideSpinner()
    {
        IsVisible = false;
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SpinnerService SpinnerService { get; set; }
    }
}
#pragma warning restore 1591