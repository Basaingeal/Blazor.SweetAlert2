using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public class SweetAlertCallback
    {
        private readonly EventCallback eventCallback;

        public SweetAlertCallback(Action callback, object callingObject)
        {
            eventCallback = EventCallback.Factory.Create(callingObject, callback);
        }

        public Task InvokeAsync()
        {
            return eventCallback.InvokeAsync(null);
        }
    }
}
