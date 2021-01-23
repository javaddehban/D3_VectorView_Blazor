using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D3VectorView.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        IJSRuntime js { get; set; }
        public static Index indexInstance{get;set;}
        protected async override Task OnInitializedAsync()
        {
            indexInstance = this;
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                js.InvokeVoidAsync("createVectorView");
                AddLines();
            }
        }
        [JSInvokable]
        public async static void reCreateLines()
        {
            indexInstance.AddLines();
        }

        public  void AddLines()
        {

            js.InvokeVoidAsync("CreateLineVectorView", 0, 0, 0, -0.2, 0.2, "titile0", "#000");
            js.InvokeVoidAsync("CreateLineVectorView", 1, 0, 0, 0.3, 0.4, "titile1", "#f00");
            js.InvokeVoidAsync("CreateLineVectorView", 2, 0, 0, -0.6, -0.1, "titile2", "#0ff");
            js.InvokeVoidAsync("CreateLineVectorView", 3, 0, 0, 0.4, -0.8, "titile3", "#00f");


        }
    }
}
