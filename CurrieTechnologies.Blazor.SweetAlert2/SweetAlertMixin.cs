namespace CurrieTechnologies.Blazor.SweetAlert2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SweetAlertMixin: IAsyncSweetAlertService, ISyncSweetAlertService
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
            SweetAlertOptions newSettings = this.Mix(this.storedOptions);
            newSettings.Title = title;
            newSettings.Html = message ?? newSettings.Html;
            newSettings.Type = type ?? newSettings.Type;
            return this.swal.FireAsync(newSettings);
        }

        /// <summary>
        /// Function to display a SweetAlert2 modal, with an object of options, all being optional.
        /// </summary>
        /// <param name="settings"></param>
        public Task<SweetAlertResult> FireAsync(SweetAlertOptions settings)
        {
            return this.swal.FireAsync(this.Mix(settings));
        }

        /// <summary>
        /// Reuse configuration by creating a Swal instance.
        /// </summary>
        /// <param name="settings">The default options to set for this instance.</param>
        /// <returns></returns>
        public SweetAlertMixin Mixin(SweetAlertOptions settings)
        {
            return new SweetAlertMixin(this.Mix(settings), this.swal);
        }

        /// <summary>
        /// Determines if a modal is shown.
        /// </summary>
        public Task<bool> IsVisibleAsync()
        {
            return this.swal.IsVisibleAsync();
        }

        /// <summary>
        /// Closes the currently open SweetAlert2 modal programmatically.
        /// </summary>
        /// <param name="onComplete">An optional callback to be called when the alert has finished closing.</param>
        public Task CloseAsync(SweetAlertCallback onComplete)
        {
            return this.swal.CloseAsync(onComplete);
        }

        /// <summary>
        /// Closes the currently open SweetAlert2 modal programmatically.
        /// </summary>
        public Task CloseAsync()
        {
            return this.swal.CloseAsync();
        }

        /// <summary>
        /// Updates popup options.
        /// </summary>
        /// <param name="newSettings"></param>
        public Task UpdateAsync(SweetAlertOptions newSettings)
        {
            return this.swal.UpdateAsync(this.Mix(newSettings));
        }

        /// <summary>
        /// Enables "Confirm" and "Cancel" buttons.
        /// </summary>
        public Task EnableButtonsAsync()
        {
            return this.swal.EnableButtonsAsync();
        }

        /// <summary>
        /// Disables "Confirm" and "Cancel" buttons.
        /// </summary>
        public Task DisableButtonsAsync()
        {
            return this.swal.DisableButtonsAsync();
        }

        /// <summary>
        /// Disables buttons and show loader. This is useful with HTML requests.
        /// </summary>
        public Task ShowLoadingAsync()
        {
            return this.swal.ShowLoadingAsync();
        }

        /// <summary>
        /// Enables buttons and hide loader.
        /// </summary>
        public Task HideLoadingAsync()
        {
            return this.swal.HideLoadingAsync();
        }

        /// <summary>
        /// Determines if modal is in the loading state.
        /// </summary>
        public Task<bool> IsLoadingAsync()
        {
            return this.swal.IsLoadingAsync();
        }

        /// <summary>
        /// Clicks the "Confirm"-button programmatically.
        /// </summary>
        public Task ClickConfirmAsync()
        {
            return this.swal.ClickCancelAsync();
        }

        /// <summary>
        /// Clicks the "Cancel"-button programmatically.
        /// </summary>
        public Task ClickCancelAsync()
        {
            return this.swal.ClickCancelAsync();
        }

        /// <summary>
        /// Shows a validation message.
        /// </summary>
        /// <param name="validationMessage">The validation message.</param>
        public Task ShowValidationMessageAsync(string validationMessage)
        {
            return this.swal.ShowValidationMessageAsync(validationMessage);
        }

        /// <summary>
        /// Hides validation message.
        /// </summary>
        public Task ResetValidationMessageAsync()
        {
            return this.swal.ResetValidationMessageAsync();
        }

        /// <summary>
        /// Disables the modal input. A disabled input element is unusable and un-clickable.
        /// </summary>
        public Task DisableInputAsync()
        {
            return this.swal.DisableInputAsync();
        }

        /// <summary>
        /// Enables the modal input.
        /// </summary>
        public Task EnableInputAsync()
        {
            return this.swal.EnableInputAsync();
        }

        /// <summary>
        /// If `timer` parameter is set, returns number of milliseconds of timer remained.
        /// <para>Otherwise, returns null.</para>
        /// </summary>
        public Task<double?> GetTimerLeftAsync()
        {
            return this.swal.GetTimerLeftAsync();
        }

        /// <summary>
        /// Stop timer. Returns number of milliseconds of timer remained.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        public Task<double?> StopTimerAsync()
        {
            return this.swal.StopTimerAsync();
        }

        /// <summary>
        /// Resume timer. Returns number of milliseconds of timer remained.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        public Task<double?> ResumeTimerAsync()
        {
            return this.swal.ResumeTimerAsync();
        }

        /// <summary>
        /// Toggle timer. Returns number of milliseconds of timer remained.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        public Task<double?> ToggleTimerAsync()
        {
            return this.swal.ToggleTimerAsync();
        }

        /// <summary>
        /// Check if timer is running. Returns true if timer is running, and false is timer is paused / stopped.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        public Task<bool?> IsTimmerRunningAsync()
        {
            return this.swal.IsTimmerRunningAsync();
        }

        /// <summary>
        /// Increase timer. Returns number of milliseconds of an updated timer.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        /// <param name="n">The number of milliseconds to add to the currect timer</param>
        public Task<double?> IncreaseTimerAsync(double n)
        {
            return this.swal.IncreaseTimerAsync(n);
        }

        /// <summary>
        /// Provide an array of SweetAlert2 parameters to show multiple modals, one modal after another.
        /// </summary>
        /// <param name="steps">The steps' configuration.</param>
        public Task<SweetAlertQueueResult> QueueAsync(IEnumerable<SweetAlertOptions> steps)
        {
            return this.swal.QueueAsync(steps.Select(s => this.Mix(s)));
        }

        /// <summary>
        /// Gets the index of current modal in queue. When there's no active queue, null will be returned.
        /// </summary>
        public Task<string> GetQueueStepAsync()
        {
            return this.swal.GetQueueStepAsync();
        }

        /// <summary>
        /// Inserts a modal in the queue.
        /// </summary>
        /// <param name="step">The step configuration (same object as in the Swal.fire() call).</param>
        /// <param name="index">The index to insert the step at. By default a modal will be added to the end of a queue.</param>
        public Task<double> InsertQueueStepAsync(SweetAlertOptions step, double? index = null)
        {
            return this.swal.InsertQueueStepAsync(this.Mix(step), index);
        }

        /// <summary>
        /// Deletes the modal at the specified index in the queue.
        /// </summary>
        /// <param name="index">The modal index in the queue.</param>
        public Task DeleteQueueStepAsync(double index)
        {
            return this.swal.DeleteQueueStepAsync(index);
        }

        /// <summary>
        /// Shows progress steps.
        /// </summary>
        public Task ShowProgressStepsAsync()
        {
            return this.swal.ShowProgressStepsAsync();
        }

        /// <summary>
        /// Shows progress steps.
        /// </summary>
        public Task HideProgressStepsAsync()
        {
            return this.swal.HideProgressStepsAsync();
        }

        /// <summary>
        /// Determines if a given parameter name is valid.
        /// </summary>
        /// <param name="paramName">The parameter to check.</param>
        public Task<bool> IsValidParamterAsync(string paramName)
        {
            return this.swal.IsValidParamterAsync(paramName);
        }

        /// <summary>
        /// Determines if a given parameter name is valid for Swal.update() method.
        /// </summary>
        /// <param name="paramName">The parameter to check.</param>
        public Task<bool> IsUpdatableParamterAsync(string paramName)
        {
            return this.swal.IsUpdatableParamterAsync(paramName);
        }

        /// <summary>
        /// Normalizes the arguments you can give to Swal.fire() in an object of type SweetAlertOptions.
        /// </summary>
        /// <param name="paramaters">The array of arguments to normalize.</param>
        /// <exception cref="ArgumentException">Thrown if parameters is not 1, 2, or 3 elements long.</exception>
        public SweetAlertOptions ArgsToParams(IEnumerable<string> paramaters)
        {
            return this.swal.ArgsToParams(paramaters);
        }

        private SweetAlertOptions Mix(SweetAlertOptions newSettings)
        {
            return new SweetAlertOptions
            {
                Title = newSettings.Title ?? this.storedOptions.Title,
                TitleText = newSettings.TitleText ?? this.storedOptions.TitleText,
                Text = newSettings.Text ?? this.storedOptions.Text,
                Html = newSettings.Html ?? this.storedOptions.Html,
                Footer = newSettings.Footer ?? this.storedOptions.Footer,
                Type = newSettings.Type ?? this.storedOptions.Type,
                Backdrop = newSettings.Backdrop ?? this.storedOptions.Backdrop,
                Toast = newSettings.Toast ?? this.storedOptions.Toast,
                Target = newSettings.Target ?? this.storedOptions.Target,
                Input = newSettings.Input ?? this.storedOptions.Input,
                Width = newSettings.Width ?? this.storedOptions.Width,
                Padding = newSettings.Padding ?? this.storedOptions.Padding,
                Background = newSettings.Background ?? this.storedOptions.Background,
                Position = newSettings.Position ?? this.storedOptions.Position,
                Grow = newSettings.Grow ?? this.storedOptions.Grow,
                CustomClass = newSettings.CustomClass ?? this.storedOptions.CustomClass,
                Timer = newSettings.Timer ?? this.storedOptions.Timer,
                Animation = newSettings.Animation ?? this.storedOptions.Animation,
                HeightAuto = newSettings.HeightAuto ?? this.storedOptions.HeightAuto,
                AllowOutsideClick = newSettings.AllowOutsideClick ?? this.storedOptions.AllowOutsideClick,
                AllowEscapeKey = newSettings.AllowEscapeKey ?? this.storedOptions.AllowEscapeKey,
                AllowEnterKey = newSettings.AllowEnterKey ?? this.storedOptions.AllowEnterKey,
                StopKeydownPropagation = newSettings.StopKeydownPropagation ?? this.storedOptions.StopKeydownPropagation,
                KeydownListenerCapture = newSettings.KeydownListenerCapture ?? this.storedOptions.KeydownListenerCapture,
                ShowConfirmButton = newSettings.ShowConfirmButton ?? this.storedOptions.ShowConfirmButton,
                ShowCancelButton = newSettings.ShowCancelButton ?? this.storedOptions.ShowCancelButton,
                ConfirmButtonText = newSettings.ConfirmButtonText ?? this.storedOptions.ConfirmButtonText,
                CancelButtonText = newSettings.CancelButtonText ?? this.storedOptions.CancelButtonText,
                ConfirmButtonColor = newSettings.ConfirmButtonColor ?? this.storedOptions.ConfirmButtonColor,
                CancelButtonColor = newSettings.CancelButtonColor ?? this.storedOptions.CancelButtonColor,
                ConfirmButtonAriaLabel = newSettings.ConfirmButtonAriaLabel ?? this.storedOptions.ConfirmButtonAriaLabel,
                CancelButtonAriaLabel = newSettings.CancelButtonAriaLabel ?? this.storedOptions.CancelButtonAriaLabel,
                ButtonsStyling = newSettings.ButtonsStyling ?? this.storedOptions.ButtonsStyling,
                ReverseButtons = newSettings.ReverseButtons ?? this.storedOptions.ReverseButtons,
                FocusConfirm = newSettings.FocusConfirm ?? this.storedOptions.FocusConfirm,
                FocusCancel = newSettings.FocusCancel ?? this.storedOptions.FocusCancel,
                ShowCloseButton = newSettings.ShowCloseButton ?? this.storedOptions.ShowCloseButton,
                CloseButtonAriaLabel = newSettings.CloseButtonAriaLabel ?? this.storedOptions.CloseButtonAriaLabel,
                ShowLoaderOnConfirm = newSettings.ShowLoaderOnConfirm ?? this.storedOptions.ShowLoaderOnConfirm,
                PreConfirm = newSettings.PreConfirm ?? this.storedOptions.PreConfirm,
                ImageUrl = newSettings.ImageUrl ?? this.storedOptions.ImageUrl,
                ImageWidth = newSettings.ImageWidth ?? this.storedOptions.ImageWidth,
                ImageHeight = newSettings.ImageHeight ?? this.storedOptions.ImageHeight,
                ImageAlt = newSettings.ImageAlt ?? this.storedOptions.ImageAlt,
                InputPlaceholder = newSettings.InputPlaceholder ?? this.storedOptions.InputPlaceholder,
                InputValue = newSettings.InputValue ?? this.storedOptions.InputValue,
                InputOptions = newSettings.InputOptions ?? this.storedOptions.InputOptions,
                InputAutoTrim = newSettings.InputAutoTrim ?? this.storedOptions.InputAutoTrim,
                InputAttributes = newSettings.InputAttributes ?? this.storedOptions.InputAttributes,
                InputValidator = newSettings.InputValidator ?? this.storedOptions.InputValidator,
                ValidationMessage = newSettings.ValidationMessage ?? this.storedOptions.ValidationMessage,
                ProgressSteps = newSettings.ProgressSteps ?? this.storedOptions.ProgressSteps,
                CurrentProgressStep = newSettings.CurrentProgressStep ?? this.storedOptions.CurrentProgressStep,
                ProgressStepsDistance = newSettings.ProgressStepsDistance ?? this.storedOptions.ProgressStepsDistance,
                OnBeforeOpen = newSettings.OnBeforeOpen ?? this.storedOptions.OnBeforeOpen,
                OnAfterClose = newSettings.OnAfterClose ?? this.storedOptions.OnAfterClose,
                OnOpen = newSettings.OnOpen ?? this.storedOptions.OnOpen,
                OnClose = newSettings.OnClose ?? this.storedOptions.OnClose,
                ScrollbarPadding = newSettings.ScrollbarPadding ?? this.storedOptions.ScrollbarPadding,
            };
        }

        /// <summary>
        /// Determines if a modal is shown.
        /// </summary>
        public bool IsVisible()
        {
            return this.swal.IsVisible();
        }

        /// <summary>
        /// Closes the currently open SweetAlert2 modal programmatically.
        /// </summary>
        /// <param name="onComplete">An optional callback to be called when the alert has finished closing.</param>
        public void Close(SweetAlertCallback onComplete)
        {
            this.swal.Close(onComplete);
        }

        /// <summary>
        /// Closes the currently open SweetAlert2 modal programmatically.
        /// </summary>
        public void Close()
        {
            this.swal.Close();
        }

        /// <summary>
        /// Updates popup options.
        /// </summary>
        /// <param name="newSettings"></param>
        public void Update(SweetAlertOptions newSettings)
        {
            this.swal.Update(this.Mix(newSettings));
        }

        /// <summary>
        /// Enables "Confirm" and "Cancel" buttons.
        /// </summary>
        public void EnableButtons()
        {
            this.swal.EnableButtons();
        }

        /// <summary>
        /// Disables "Confirm" and "Cancel" buttons.
        /// </summary>
        public void DisableButtons()
        {
            this.swal.DisableButtons();
        }

        /// <summary>
        /// Disables buttons and show loader. This is useful with HTML requests.
        /// </summary>
        public void ShowLoading()
        {
            this.swal.ShowLoading();
        }

        /// <summary>
        /// Enables buttons and hide loader.
        /// </summary>
        public void HideLoading()
        {
            this.swal.HideLoading();
        }

        /// <summary>
        /// Determines if modal is in the loading state.
        /// </summary>
        public bool IsLoading()
        {
            return this.swal.IsLoading();
        }

        /// <summary>
        /// Clicks the "Confirm"-button programmatically.
        /// </summary>
        public void ClickConfirm()
        {
            this.swal.ClickConfirm();
        }

        /// <summary>
        /// Clicks the "Cancel"-button programmatically.
        /// </summary>
        public void ClickCancel()
        {
            this.swal.ClickCancel();
        }

        /// <summary>
        /// Shows a validation message.
        /// </summary>
        /// <param name="validationMessage">The validation message.</param>
        public void ShowValidationMessage(string validationMessage)
        {
            this.swal.ShowValidationMessage(validationMessage);
        }

        /// <summary>
        /// Hides validation message.
        /// </summary>
        public void ResetValidationMessage()
        {
            this.swal.ResetValidationMessage();
        }

        /// <summary>
        /// Disables the modal input. A disabled input element is unusable and un-clickable.
        /// </summary>
        public void DisableInput()
        {
            this.swal.DisableInput();
        }

        /// <summary>
        /// Enables the modal input.
        /// </summary>
        public void EnableInput()
        {
            this.swal.EnableInput();
        }

        /// <summary>
        /// If `timer` parameter is set, returns number of milliseconds of timer remained.
        /// <para>Otherwise, returns null.</para>
        /// </summary>
        public double? GetTimerLeft()
        {
            return this.swal.GetTimerLeft();
        }

        /// <summary>
        /// Stop timer. Returns number of milliseconds of timer remained.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        public double? StopTimer()
        {
            return this.swal.StopTimer();
        }

        /// <summary>
        /// Resume timer. Returns number of milliseconds of timer remained.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        public double? ResumeTimer()
        {
            return this.swal.ResumeTimer();
        }

        /// <summary>
        /// Toggle timer. Returns number of milliseconds of timer remained.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        public double? ToggleTimer()
        {
            return this.swal.ToggleTimer();
        }

        /// <summary>
        /// Check if timer is running. Returns true if timer is running, and false is timer is paused / stopped.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        public bool? IsTimmerRunning()
        {
            return this.swal.IsTimmerRunning();
        }

        /// <summary>
        /// Increase timer. Returns number of milliseconds of an updated timer.
        /// <para>If `timer` parameter isn't set, returns null.</para>
        /// </summary>
        /// <param name="n">The number of milliseconds to add to the currect timer</param>
        public double? IncreaseTimer(double n)
        {
            return this.swal.IncreaseTimer(n);
        }

        /// <summary>
        /// Gets the index of current modal in queue. When there's no active queue, null will be returned.
        /// </summary>
        public string GetQueueStep()
        {
            return this.swal.GetQueueStep();
        }

        /// <summary>
        /// Inserts a modal in the queue.
        /// </summary>
        /// <param name="step">The step configuration (same object as in the Swal.fire() call).</param>
        /// <param name="index">The index to insert the step at. By default a modal will be added to the end of a queue.</param>
        public double InsertQueueStep(SweetAlertOptions step, double? index)
        {
            return this.swal.InsertQueueStep(this.Mix(step), index);
        }

        /// <summary>
        /// Deletes the modal at the specified index in the queue.
        /// </summary>
        /// <param name="index">The modal index in the queue.</param>
        public void DeleteQueueStep(double index)
        {
            this.swal.DeleteQueueStep(index);
        }

        /// <summary>
        /// Shows progress steps.
        /// </summary>
        public void ShowProgressSteps()
        {
            this.swal.ShowProgressSteps();
        }

        /// <summary>
        /// Shows progress steps.
        /// </summary>
        public void HideProgressSteps()
        {
            this.swal.HideProgressSteps();
        }

        /// <summary>
        /// Determines if a given parameter name is valid.
        /// </summary>
        /// <param name="paramName">The parameter to check.</param>
        /// <returns></returns>
        public bool IsValidParamter(string paramName)
        {
            return this.swal.IsValidParamter(paramName);
        }

        /// <summary>
        /// Determines if a given parameter name is valid for Swal.update() method.
        /// </summary>
        /// <param name="paramName">The parameter to check.</param>
        /// <returns></returns>
        public bool IsUpdatableParamter(string paramName)
        {
            return this.swal.IsUpdatableParamter(paramName);
        }
    }
}
