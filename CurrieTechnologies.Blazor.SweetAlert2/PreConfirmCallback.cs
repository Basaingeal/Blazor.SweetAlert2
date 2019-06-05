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
    public class PreConfirmCallback
    {
        private readonly Func<dynamic, Task<dynamic>> asyncCallback;
        private readonly Func<dynamic, dynamic> syncCallback;
        private readonly EventCallback eventCallback;

        /// <summary>
        /// Creates a <see cref="PreConfirmCallback"/> for the provided <paramref name="receiver"/> and <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver. Pass in `this` from the calling component.</param>
        /// <param name="callback">The event callback.</param>
        public PreConfirmCallback(object receiver, Func<dynamic, Task<dynamic>> callback)
        {
            this.asyncCallback = callback;
            this.eventCallback = EventCallback.Factory.Create(receiver, () => { });
        }

        /// <summary>
        /// Creates a <see cref="PreConfirmCallback"/> for the provided <paramref name="receiver"/> and <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver. Pass in `this` from the calling component.</param>
        /// <param name="callback">The event callback.</param>
        public PreConfirmCallback(object receiver, Func<dynamic, dynamic> callback)
        {
            this.syncCallback = callback;
            this.eventCallback = EventCallback.Factory.Create(receiver, () => { });
        }

        /// <summary>
        /// Invokes the delage associated with this binding and dispatches an event notification to the appropriate component.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <returns></returns>
        public async Task<dynamic> InvokeAsync (dynamic arg)
        {
            dynamic ret;
            if (this.asyncCallback != null)
            {
                ret = await this.asyncCallback(arg);
            }
            else
            {
                ret = this.syncCallback(arg);
            }
            await eventCallback.InvokeAsync(arg);
            return ret;
        }
    }
}
