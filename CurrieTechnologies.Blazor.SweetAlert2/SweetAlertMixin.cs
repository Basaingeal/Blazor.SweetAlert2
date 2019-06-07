using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public class SweetAlertMixin
    {
        private readonly SweetAlertOptions storedOptions;
        private readonly SweetAlertService swal;

        internal SweetAlertMixin(SweetAlertOptions settings, SweetAlertService service)
        {
            this.storedOptions = settings;
            this.swal = service;
        }

        public Task<SweetAlertQueueResult> QueueAsync(IEnumerable<SweetAlertOptions> steps)
        {
            var mixedSteps = steps.Select(s => Mix(s));
            return swal.QueueAsync(mixedSteps);
        }

        private SweetAlertOptions Mix(SweetAlertOptions newSettings)
        {
            return new SweetAlertOptions
            {
                AllowEnterKey = newSettings.AllowEnterKey ?? storedOptions.AllowEnterKey,
                Input = newSettings.Input ?? storedOptions.Input,
                ConfirmButtonText = newSettings.ConfirmButtonText ?? storedOptions.ConfirmButtonText,
                ShowCancelButton = newSettings.ShowCancelButton ?? storedOptions.ShowCancelButton,
                ProgressSteps = newSettings.ProgressSteps ?? storedOptions.ProgressSteps,
                Title = newSettings.Title ?? storedOptions.Title,
                Text = newSettings.Text ?? storedOptions.Text,
                PreConfirm = newSettings.PreConfirm ?? storedOptions.PreConfirm
            };
        }
    }
}
