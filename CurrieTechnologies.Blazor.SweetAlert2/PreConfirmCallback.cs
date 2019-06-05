using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public class PreConfirmCallback
    {
        private readonly Func<dynamic, Task<dynamic>> callback;
        private readonly EventCallback eventCallback;

        public PreConfirmCallback(Func<dynamic, Task<dynamic>> callback, object callingObject)
        {
            this.callback = callback;
            this.eventCallback = EventCallback.Factory.Create(callingObject, () => { });
        }

        public async Task<dynamic> InvokeAsync (dynamic inputValue)
        {
            var ret = await callback(inputValue);
            await eventCallback.InvokeAsync(inputValue);
            return ret;
        }
    }
}
