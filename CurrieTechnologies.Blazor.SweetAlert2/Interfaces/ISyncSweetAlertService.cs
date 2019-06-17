using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    internal interface ISyncSweetAlertService
    {
        Task<SweetAlertResult> FireAsync(string title, string message, SweetAlertType type);

        Task<SweetAlertResult> FireAsync(SweetAlertOptions settings);

        SweetAlertMixin Mixin(SweetAlertOptions settings);

        bool IsVisible();

        void Close(SweetAlertCallback onComplete);

        void Close();

        void Update(SweetAlertOptions newSettings);

        void EnableButtons();

        void DisableButtons();

        void ShowLoading();

        void HideLoading();

        bool IsLoading();

        void ClickConfirm();

        void ClickCancel();

        void ShowValidationMessage(string validationMessage);

        void ResetValidationMessage();

        void DisableInput();

        void EnableInput();

        double? GetTimerLeft();

        double? StopTimer();

        double? ResumeTimer();

        double? ToggleTimer();

        bool? IsTimmerRunning();

        double? IncreaseTimer(double n);

        Task<SweetAlertQueueResult> QueueAsync(IEnumerable<SweetAlertOptions> steps);

        string GetQueueStep();

        double InsertQueueStep(SweetAlertOptions step, double? index);

        void DeleteQueueStep(double index);

        void ShowProgressSteps();

        void HideProgressSteps();

        bool IsValidParamter(string paramName);

        bool IsUpdatableParamter(string paramName);

        SweetAlertOptions ArgsToParams(IEnumerable<string> paramaters);
    }
}
