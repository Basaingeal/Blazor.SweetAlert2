using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Function to display a simple SweetAlert2 modal.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Task<SweetAlertResult> FireAsync(string title, string message = null, SweetAlertType type = null)
        {
            SweetAlertOptions newSettings = Mix(storedOptions);
            newSettings.Title = title;
            newSettings.Html = message ?? newSettings.Html;
            newSettings.Type = type ?? newSettings.Type;
            return swal.FireAsync(newSettings);
        }

        /// <summary>
        /// Function to display a SweetAlert2 modal, with an object of options, all being optional.
        /// </summary>
        /// <param name="settings"></param>
        public Task<SweetAlertResult> FireAsync(SweetAlertOptions settings)
        {
            return swal.FireAsync(Mix(settings));
        }

        /// <summary>
        /// Reuse configuration by creating a Swal instance.
        /// </summary>
        /// <param name="settings">The default options to set for this instance.</param>
        /// <returns></returns>
        public SweetAlertMixin Mixin(SweetAlertOptions settings)
        {
            return new SweetAlertMixin(Mix(settings), swal);
        }

        /// <summary>
        /// Determines if a modal is shown.
        /// </summary>
        public Task<bool> IsVisibleAsync()
        {
            return swal.IsVisibleAsync();
        }

        /// <summary>
        /// Closes the currently open SweetAlert2 modal programmatically.
        /// </summary>
        /// <param name="onComplete">An optional callback to be called when the alert has finished closing.</param>
        public Task CloseAsync(SweetAlertCallback onComplete)
        {
            return swal.CloseAsync(onComplete);
        }

        /// <summary>
        /// Closes the currently open SweetAlert2 modal programmatically.
        /// </summary>
        public Task CloseAsync()
        {
            return swal.CloseAsync();
        }

        /// <summary>
        /// Updates popup options.
        /// </summary>
        /// <param name="newSettings"></param>
        public Task UpdateAsync(SweetAlertOptions newSettings)
        {
            return swal.UpdateAsync(Mix(newSettings));
        }

        /// <summary>
        /// Enables "Confirm" and "Cancel" buttons.
        /// </summary>
        public Task EnableButtonsAsync()
        {
            return swal.EnableButtonsAsync();
        }

        /// <summary>
        /// Disables "Confirm" and "Cancel" buttons.
        /// </summary>
        public Task DisableButtonsAsync()
        {
            return swal.DisableButtonsAsync();
        }

        /// <summary>
        /// Disables buttons and show loader. This is useful with HTML requests.
        /// </summary>
        public Task ShowLoadingAsync()
        {
            return swal.ShowLoadingAsync();
        }

        /// <summary>
        /// Enables buttons and hide loader.
        /// </summary>
        public Task HideLoadingAsync()
        {
            return swal.HideLoadingAsync();
        }

        /// <summary>
        /// Determines if modal is in the loading state.
        /// </summary>
        public Task<bool> IsLoadingAsync()
        {
            return swal.IsLoadingAsync();
        }

        /// <summary>
        /// Clicks the "Confirm"-button programmatically.
        /// </summary>
        public Task ClickConfirmAsync()
        {
            return swal.ClickCancelAsync();
        }

        /// <summary>
        /// Clicks the "Cancel"-button programmatically.
        /// </summary>
        public Task ClickCancelAsync()
        {
            return swal.ClickCancelAsync();
        }

        /// <summary>
        /// Shows a validation message.
        /// </summary>
        /// <param name="validationMessage">The validation message.</param>
        public Task ShowValidationMessageAsync(string validationMessage)
        {
            return swal.ShowValidationMessageAsync(validationMessage);
        }

        /// <summary>
        /// Hides validation message.
        /// </summary>
        public Task ResetValidationMessageAsync()
        {
            return swal.ResetValidationMessageAsync();
        }

        /// <summary>
        /// Disables the modal input. A disabled input element is unusable and un-clickable.
        /// </summary>
        public Task DisableInputAsync()
        {
            return swal.DisableInputAsync();
        }

        /// <summary>
        /// Enables the modal input.
        /// </summary>
        public Task EnableInputAsync()
        {
            return swal.EnableInputAsync();
        }

        /// <summary>
        /// If `timer` parameter is set, returns number of milliseconds of timer remained.
        /// <para>Otherwise, returns null.</para>
        /// </summary>
        public Task<double?> GetTimerLeftAsync()
        {
            return swal.GetTimerLeftAsync();
        }

        /// <summary>
        /// Stop timer. Returns number of milliseconds of timer remained.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        public Task<double?> StopTimerAsync()
        {
            return swal.StopTimerAsync();
        }

        /// <summary>
        /// Resume timer. Returns number of milliseconds of timer remained.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        public Task<double?> ResumeTimerAsync()
        {
            return swal.ResumeTimerAsync();
        }

        /// <summary>
        /// Toggle timer. Returns number of milliseconds of timer remained.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        public Task<double?> ToggleTimerAsync()
        {
            return swal.ToggleTimerAsync();
        }

        /// <summary>
        /// Check if timer is running. Returns true if timer is running, and false is timer is paused / stopped.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        public Task<bool?> IsTimmerRunningAsync()
        {
            return swal.IsTimmerRunningAsync();
        }

        /// <summary>
        /// Increase timer. Returns number of milliseconds of an updated timer.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        /// <param name="n">The number of milliseconds to add to the currect timer</param>
        public Task<double?> IncreaseTimerAsync(double n)
        {
            return swal.IncreaseTimerAsync(n);
        }

        /// <summary>
        /// Provide an array of SweetAlert2 parameters to show multiple modals, one modal after another.
        /// </summary>
        /// <param name="steps">The steps' configuration.</param>
        public Task<SweetAlertQueueResult> QueueAsync(IEnumerable<SweetAlertOptions> steps)
        {
            return swal.QueueAsync(steps.Select(s => Mix(s)));
        }

        /// <summary>
        /// Gets the index of current modal in queue. When there's no active queue, null will be returned.
        /// </summary>
        public Task<string> GetQueueStepAsync()
        {
            return swal.GetQueueStepAsync();
        }

        /// <summary>
        /// Inserts a modal in the queue.
        /// </summary>
        /// <param name="step">The step configuration (same object as in the Swal.fire() call).</param>
        /// <param name="index">The index to insert the step at. By default a modal will be added to the end of a queue.</param>
        public Task<double> InsertQueueStepAsync(SweetAlertOptions step, double? index = null)
        {
            return swal.InsertQueueStepAsync(Mix(step), index);
        }

        /// <summary>
        /// Deletes the modal at the specified index in the queue.
        /// </summary>
        /// <param name="index">The modal index in the queue.</param>
        public Task DeleteQueueStepAsync(double index)
        {
            return swal.DeleteQueueStepAsync(index);
        }

        /// <summary>
        /// Shows progress steps.
        /// </summary>
        public Task ShowProgressStepsAsync()
        {
            return swal.ShowProgressStepsAsync();
        }

        /// <summary>
        /// Shows progress steps.
        /// </summary>
        public Task HideProgressStepsAsync()
        {
            return swal.HideProgressStepsAsync();
        }

        /// <summary>
        /// Determines if a given parameter name is valid.
        /// </summary>
        /// <param name="paramName">The parameter to check.</param>
        /// <returns></returns>
        public Task<bool> IsValidParamterAsync(string paramName)
        {
            return swal.IsValidParamterAsync(paramName);
        }

        /// <summary>
        /// Determines if a given parameter name is valid for Swal.update() method.
        /// </summary>
        /// <param name="paramName">The parameter to check.</param>
        /// <returns></returns>
        public Task<bool> IsUpdatableParamterAsync(string paramName)
        {
            return swal.IsUpdatableParamterAsync(paramName);
        }

        /// <summary>
        /// Normalizes the arguments you can give to Swal.fire() in an object of type SweetAlertOptions.
        /// </summary>
        /// <param name="paramaters">The array of arguments to normalize.</param>
        /// <exception cref="ArgumentException">Thrown if parameters is not 1, 2, or 3 elements long.</exception>
        public SweetAlertOptions ArgsToParams(IEnumerable<string> paramaters)
        {
            return swal.ArgsToParams(paramaters);
        }

        private SweetAlertOptions Mix(SweetAlertOptions newSettings)
        {
            return new SweetAlertOptions
            {
                Title = newSettings.Title ?? storedOptions.Title,
                TitleText = newSettings.TitleText ?? storedOptions.TitleText,
                Text = newSettings.Text ?? storedOptions.Text,
                Html = newSettings.Html ?? storedOptions.Html,
                Footer = newSettings.Footer ?? storedOptions.Footer,
                Type = newSettings.Type ?? storedOptions.Type,
                Backdrop = newSettings.Backdrop ?? storedOptions.Backdrop,
                Toast = newSettings.Toast ?? storedOptions.Toast,
                Target = newSettings.Target ?? storedOptions.Target,
                Input = newSettings.Input ?? storedOptions.Input,
                Width = newSettings.Width ?? storedOptions.Width,
                Padding = newSettings.Padding ?? storedOptions.Padding,
                Background = newSettings.Background ?? storedOptions.Background,
                Position = newSettings.Position ?? storedOptions.Position,
                Grow = newSettings.Grow ?? storedOptions.Grow,
                CustomClass = newSettings.CustomClass ?? storedOptions.CustomClass,
                Timer = newSettings.Timer ?? storedOptions.Timer,
                Animation = newSettings.Animation ?? storedOptions.Animation,
                HeightAuto = newSettings.HeightAuto ?? storedOptions.HeightAuto,
                AllowOutsideClick = newSettings.AllowOutsideClick ?? storedOptions.AllowOutsideClick,
                AllowEscapeKey = newSettings.AllowEscapeKey ?? storedOptions.AllowEscapeKey,
                AllowEnterKey = newSettings.AllowEnterKey ?? storedOptions.AllowEnterKey,
                StopKeydownPropagation = newSettings.StopKeydownPropagation ?? storedOptions.StopKeydownPropagation,
                KeydownListenerCapture = newSettings.KeydownListenerCapture ?? storedOptions.KeydownListenerCapture,
                ShowConfirmButton = newSettings.ShowConfirmButton ?? storedOptions.ShowConfirmButton,
                ShowCancelButton = newSettings.ShowCancelButton ?? storedOptions.ShowCancelButton,
                ConfirmButtonText = newSettings.ConfirmButtonText ?? storedOptions.ConfirmButtonText,
                CancelButtonText = newSettings.CancelButtonText ?? storedOptions.CancelButtonText,
                ConfirmButtonColor = newSettings.ConfirmButtonColor ?? storedOptions.ConfirmButtonColor,
                CancelButtonColor = newSettings.CancelButtonColor ?? storedOptions.CancelButtonColor,
                ConfirmButtonAriaLabel = newSettings.ConfirmButtonAriaLabel ?? storedOptions.ConfirmButtonAriaLabel,
                CancelButtonAriaLabel = newSettings.CancelButtonAriaLabel ?? storedOptions.CancelButtonAriaLabel,
                ButtonsStyling = newSettings.ButtonsStyling ?? storedOptions.ButtonsStyling,
                ReverseButtons = newSettings.ReverseButtons ?? storedOptions.ReverseButtons,
                FocusConfirm = newSettings.FocusConfirm ?? storedOptions.FocusConfirm,
                FocusCancel = newSettings.FocusCancel ?? storedOptions.FocusCancel,
                ShowCloseButton = newSettings.ShowCloseButton ?? storedOptions.ShowCloseButton,
                CloseButtonAriaLabel = newSettings.CloseButtonAriaLabel ?? storedOptions.CloseButtonAriaLabel,
                ShowLoaderOnConfirm = newSettings.ShowLoaderOnConfirm ?? storedOptions.ShowLoaderOnConfirm,
                PreConfirm = newSettings.PreConfirm ?? storedOptions.PreConfirm,
                ImageUrl = newSettings.ImageUrl ?? storedOptions.ImageUrl,
                ImageWidth = newSettings.ImageWidth ?? storedOptions.ImageWidth,
                ImageHeight = newSettings.ImageHeight ?? storedOptions.ImageHeight,
                ImageAlt = newSettings.ImageAlt ?? storedOptions.ImageAlt,
                InputPlaceholder = newSettings.InputPlaceholder ?? storedOptions.InputPlaceholder,
                InputValue = newSettings.InputValue ?? storedOptions.InputValue,
                InputOptions = newSettings.InputOptions ?? storedOptions.InputOptions,
                InputAutoTrim = newSettings.InputAutoTrim ?? storedOptions.InputAutoTrim,
                InputAttributes = newSettings.InputAttributes ?? storedOptions.InputAttributes,
                InputValidator = newSettings.InputValidator ?? storedOptions.InputValidator,
                ValidationMessage = newSettings.ValidationMessage ?? storedOptions.ValidationMessage,
                ProgressSteps = newSettings.ProgressSteps ?? storedOptions.ProgressSteps,
                CurrentProgressStep = newSettings.CurrentProgressStep ?? storedOptions.CurrentProgressStep,
                ProgressStepsDistance = newSettings.ProgressStepsDistance ?? storedOptions.ProgressStepsDistance,
                OnBeforeOpen = newSettings.OnBeforeOpen ?? storedOptions.OnBeforeOpen,
                OnAfterClose = newSettings.OnAfterClose ?? storedOptions.OnAfterClose,
                OnOpen = newSettings.OnOpen ?? storedOptions.OnOpen,
                OnClose = newSettings.OnClose ?? storedOptions.OnClose,
                ScrollbarPadding = newSettings.ScrollbarPadding ?? storedOptions.ScrollbarPadding,
            };
        }
    }
}
