using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BootStrap.Net.util
{
    public class BootStrapNetInterop
    {
        private IJSRuntime JSRuntime { get; set; }

        public BootStrapNetInterop(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
        }

        public Task<bool> ChangeBody(string classname) 
            => JSRuntime.InvokeAsync<bool>("blazorStrap.changeBody", classname);

        public Task<bool> Log(string message) 
            => JSRuntime.InvokeAsync<bool>("blazorStrap.log", message);

        public Task<bool> Popper(string target, string popper, ElementRef arrow, string placement) 
            => JSRuntime.InvokeAsync<bool>("blazorStrap.popper", target, popper, arrow, placement);

        public Task<bool> Tooltip(string target, ElementRef tooltip, ElementRef arrow, string placement) 
            => JSRuntime.InvokeAsync<bool>("blazorStrap.tooltip", target, tooltip, arrow, placement);

        public Task<bool> SetItem(string key, string value, bool session)
        {
            return JSRuntime.InvokeAsync<bool>("blazorDBInterop.setItem", key, value, session);
        }

        public Task<string> GetItem(string key, bool session)
        {
            return JSRuntime.InvokeAsync<string>("blazorDBInterop.getItem", key, session);
        }

        public Task<bool> RemoveItem(string key, bool session)
        {
            return JSRuntime.InvokeAsync<bool>("blazorDBInterop.removeItem", key, session);
        }

        public Task<bool> Clear(bool session)
        {
            return JSRuntime.InvokeAsync<bool>("blazorDBInterop.clear", session);
        }

        public Task<bool> Log(params object[] list)
        {
            var _list = new List<object>(list); //This line is needed see: https://github.com/aspnet/Blazor/issues/740
            return JSRuntime.InvokeAsync<bool>("blazorDBInterop.logs");
        }
    }
}
