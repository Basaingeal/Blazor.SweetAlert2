using Microsoft.JSInterop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public class SweetAlertService
    {

        private readonly IJSRuntime jSRuntime;
        private static readonly IDictionary<Guid, TaskCompletionSource<SweetAlertResult>> pendingFireRequests =
            new Dictionary<Guid, TaskCompletionSource<SweetAlertResult>>();

        public SweetAlertService(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        /// <summary>
        /// Function to display a simple SweetAlert2 modal.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<SweetAlertResult> FireAsync(string title, string message = null, SweetAlertType type = null)
        {
            var tcs = new TaskCompletionSource<SweetAlertResult>();
            Guid requestId = Guid.NewGuid();
            pendingFireRequests.Add(requestId, tcs);
            await jSRuntime.InvokeAsync<object>("CurrieTechnologies.Blazor.SweetAlert2.Fire", requestId, title, message, type);
            return await tcs.Task;
        }

        [JSInvokable]
        public static Task RecieveFireResult(string requestId, SweetAlertResult result)
        {
            var requestGuid = Guid.Parse(requestId);
            pendingFireRequests.TryGetValue(requestGuid, out TaskCompletionSource<SweetAlertResult> pendingTask);
            pendingFireRequests.Remove(requestGuid);
            pendingTask.SetResult(result);
            return Task.CompletedTask;
        }

        public Task<SweetAlertResult> FireAsync(SweetAlertOptions settings)
        {
            return jSRuntime.InvokeAsync<SweetAlertResult>("CurrieTechnologies.Blazor.SweetAlert2.FireSettings", settings);
        }


        /// <summary>
        /// An enum of possible reasons that can explain an alert dismissal.
        /// </summary>
        public enum DismissReason
        {
            Cancel,
            Backdrop,
            Close,
            Esc,
            Timer
        }
    }
}
