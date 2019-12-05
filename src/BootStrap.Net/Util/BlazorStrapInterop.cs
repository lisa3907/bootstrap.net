using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootStrap.Net.Util
{
    public class BootStrapNetInterop
    {
        private IJSRuntime JSRuntime
        {
            get; set;
        }

        public BootStrapNetInterop(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
        }

        public ValueTask<bool> ChangeBody(string classname)
            => JSRuntime.InvokeAsync<bool>("blazorStrap.changeBody", classname);

        public ValueTask<bool> Log(string message)
            => JSRuntime.InvokeAsync<bool>("blazorStrap.log", message);

        public ValueTask<bool> Popper(string target, string popper, ElementReference arrow, string placement)
            => JSRuntime.InvokeAsync<bool>("blazorStrap.popper", target, popper, arrow, placement);

        public ValueTask<bool> Tooltip(string target, ElementReference tooltip, ElementReference arrow, string placement)
            => JSRuntime.InvokeAsync<bool>("blazorStrap.tooltip", target, tooltip, arrow, placement);

        public ValueTask<bool> SetItem(string key, string value, bool session)
        {
            return JSRuntime.InvokeAsync<bool>("blazorDBInterop.setItem", key, value, session);
        }

        public ValueTask<string> GetItem(string key, bool session)
        {
            return JSRuntime.InvokeAsync<string>("blazorDBInterop.getItem", key, session);
        }

        public ValueTask<bool> RemoveItem(string key, bool session)
        {
            return JSRuntime.InvokeAsync<bool>("blazorDBInterop.removeItem", key, session);
        }

        public ValueTask<bool> Clear(bool session)
        {
            return JSRuntime.InvokeAsync<bool>("blazorDBInterop.clear", session);
        }

        public ValueTask<bool> Log(params object[] list)
        {
            var _list = new List<object>(list); //This line is needed see: https://github.com/aspnet/Blazor/issues/740
            return JSRuntime.InvokeAsync<bool>("blazorDBInterop.logs");
        }
    }
}