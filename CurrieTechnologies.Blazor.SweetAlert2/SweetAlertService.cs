using Microsoft.JSInterop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public class SweetAlertService
    {

        private readonly IJSRuntime jSRuntime;
        private static readonly IDictionary<Guid, TaskCompletionSource<SweetAlertResult>> pendingFireRequests =
            new Dictionary<Guid, TaskCompletionSource<SweetAlertResult>>();

        private static readonly IDictionary<Guid, PreConfirmCallback> preConfirmCallbacks =
            new Dictionary<Guid, PreConfirmCallback>();

        private static readonly IDictionary<Guid, SweetAlertCallback> onOpenCallbacks =
            new Dictionary<Guid, SweetAlertCallback>();

        private static readonly IDictionary<Guid, SweetAlertCallback> onCloseCallbacks =
            new Dictionary<Guid, SweetAlertCallback>();

        private static readonly IDictionary<Guid, SweetAlertCallback> onBeforeOpenCallbacks =
            new Dictionary<Guid, SweetAlertCallback>();

        private static readonly IDictionary<Guid, SweetAlertCallback> onAfterCloseCallbacks =
            new Dictionary<Guid, SweetAlertCallback>();

        private static readonly IDictionary<Guid, InputValidatorCallback> InputValidatorCallbacks =
            new Dictionary<Guid, InputValidatorCallback>();

        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

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
            await jSRuntime.InvokeAsync<object>("CurrieTechnologies.Blazor.SweetAlert2.Fire", requestId, title, message, type?.ToString());
            return await tcs.Task;
        }

        [JSInvokable]
        public static Task ReceiveFireResult(string requestId, SweetAlertResult result)
        {
            var requestGuid = Guid.Parse(requestId);
            pendingFireRequests.TryGetValue(requestGuid, out TaskCompletionSource<SweetAlertResult> pendingTask);
            pendingFireRequests.Remove(requestGuid);
            pendingTask.SetResult(result);
            return Task.CompletedTask;
        }

        public async Task<SweetAlertResult> FireAsync(SweetAlertOptions settings)
        {
            var tcs = new TaskCompletionSource<SweetAlertResult>();
            Guid requestId = Guid.NewGuid();
            pendingFireRequests.Add(requestId, tcs);

            if(settings.PreConfirm != null)
            {
                preConfirmCallbacks.Add(requestId, settings.PreConfirm);
            }
            if (settings.InputValidator != null)
            {
                InputValidatorCallbacks.Add(requestId, settings.InputValidator);
            }
            if (settings.OnOpen != null)
            {
                onOpenCallbacks.Add(requestId, settings.OnOpen);
            }
            if (settings.OnClose != null)
            {
                onCloseCallbacks.Add(requestId, settings.OnClose);
            }
            if (settings.OnBeforeOpen != null)
            {
                onBeforeOpenCallbacks.Add(requestId, settings.OnBeforeOpen);
            }
            if (settings.OnAfterClose != null)
            {
                onAfterCloseCallbacks.Add(requestId, settings.OnAfterClose);
            }

            var poco = settings.ToPOCO();
            string settingsJson = JsonSerializer.ToString(poco, jsonSerializerOptions);
            await jSRuntime.InvokeAsync<SweetAlertResult>("CurrieTechnologies.Blazor.SweetAlert2.FireSettings", requestId, settingsJson);
            return await tcs.Task;
        }

        [JSInvokable]
        public static Task<dynamic> ReceivePreConfirmInput(string requestId, object inputValue)
        {
            var requestIdGuid = Guid.Parse(requestId);
            preConfirmCallbacks.TryGetValue(requestIdGuid, out PreConfirmCallback callback);
            return callback.InvokeAsync(inputValue);
        }

        [JSInvokable]
        public static Task<string> ReceiveInputValidatorInput(string requestId, string inputValue)
        {
            var requestIdGuid = Guid.Parse(requestId);
            InputValidatorCallbacks.TryGetValue(requestIdGuid, out InputValidatorCallback callback);
            return callback.InvokeAsync(inputValue);
        }

        [JSInvokable]
        public static async Task ReceiveOnOpenInput(string requestId)
        {
            var requestIdGuid = Guid.Parse(requestId);
            onOpenCallbacks.TryGetValue(requestIdGuid, out SweetAlertCallback callback);
            await callback.InvokeAsync();
        }

        [JSInvokable]
        public static async Task ReceiveOnCloseInput(string requestId)
        {
            var requestIdGuid = Guid.Parse(requestId);
            onCloseCallbacks.TryGetValue(requestIdGuid, out SweetAlertCallback callback);
            await callback.InvokeAsync();
        }

        [JSInvokable]
        public static async Task ReceiveOnBeforeOpenInput(string requestId)
        {
            var requestIdGuid = Guid.Parse(requestId);
            onBeforeOpenCallbacks.TryGetValue(requestIdGuid, out SweetAlertCallback callback);
            await callback.InvokeAsync();
        }

        [JSInvokable]
        public static async Task ReceiveOnAfterCloseInput(string requestId)
        {
            var requestIdGuid = Guid.Parse(requestId);
            onAfterCloseCallbacks.TryGetValue(requestIdGuid, out SweetAlertCallback callback);
            await callback.InvokeAsync();
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
