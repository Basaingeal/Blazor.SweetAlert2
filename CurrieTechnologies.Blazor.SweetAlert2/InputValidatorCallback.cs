using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public class InputValidatorCallback
    {
        private readonly Func<string, Task<string>> callback;
        private readonly EventCallback eventCallback;

        public InputValidatorCallback(Func<string, Task<string>> callback, object callingObject)
        {
            this.callback = callback;
            this.eventCallback = EventCallback.Factory.Create(callingObject, () => { });
        }

        public async Task<string> InvokeAsync(string inputValue)
        {
            var ret = await callback(inputValue);
            await eventCallback.InvokeAsync(inputValue);
            return ret;
        }

    }
}
