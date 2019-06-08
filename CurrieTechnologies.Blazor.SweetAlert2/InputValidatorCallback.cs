using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    /// <summary>
    /// A bound event handler delagate.
    /// </summary>
    public class InputValidatorCallback
    {
        private readonly Func<string, Task<string>> asyncCallback;
        private readonly Func<string, string> syncCallback;
        private readonly EventCallback eventCallback;

        /// <summary>
        /// Creates an <see cref="InputValidatorCallback"/> for the provided <paramref name="receiver"/> and <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver. Pass in `this` from the calling component.</param>
        /// <param name="callback">The event callback.</param>
        public InputValidatorCallback(object receiver, Func<string, Task<string>> callback)
        {
            this.asyncCallback = callback;
            this.eventCallback = EventCallback.Factory.Create(receiver, () => { });
        }

        /// <summary>
        /// Creates an <see cref="InputValidatorCallback"/> for the provided <paramref name="receiver"/> and <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver. Pass in `this` from the calling component.</param>
        /// <param name="callback">The event callback.</param>
        public InputValidatorCallback(object receiver, Func<string, string> callback)
        {
            this.syncCallback = callback;
            this.eventCallback = EventCallback.Factory.Create(receiver, () => { });
        }

        /// <summary>
        /// Invokes the delegate associated with this binding and dispatches an event notification to the appropriate component.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <returns></returns>
        public async Task<string> InvokeAsync(string arg)
        {
            string ret;
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
