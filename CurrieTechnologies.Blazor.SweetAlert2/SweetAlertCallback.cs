using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    /// <summary>
    /// A bound event handler delagate.
    /// </summary>
    public class SweetAlertCallback
    {
        private readonly Action syncCallback;
        private readonly Func<Task> asyncCallback;
        private readonly EventCallback eventCallback;

        /// <summary>
        /// Creates a <see cref="SweetAlertCallback"/> for the provided <paramref name="receiver"/> and <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver. Pass in `this` from the calling component.</param>
        /// <param name="callback">The event callback.</param>
        public SweetAlertCallback(object receiver, Action callback)
        {
            this.syncCallback = callback;
            this.eventCallback = EventCallback.Factory.Create(receiver, () => { });
        }

        /// <summary>
        /// Creates a <see cref="SweetAlertCallback"/> for the provided <paramref name="receiver"/> and <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver. Pass in `this` from the calling component.</param>
        /// <param name="callback">The event callback.</param>
        public SweetAlertCallback(object receiver, Func<Task> callback)
        {
            this.asyncCallback = callback;
            this.eventCallback = EventCallback.Factory.Create(receiver, () => { });
        }

        /// <summary>
        /// Invokes the delegate associated with this binding and dispatches an event notification to the appropriate component.
        /// </summary>
        /// <returns></returns>
        public async Task InvokeAsync()
        {
            if (this.asyncCallback != null)
            {
                await this.asyncCallback();
            }
            else
            {
                this.syncCallback();
            }
            await eventCallback.InvokeAsync(null);
        }
    }
}
