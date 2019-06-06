import Swal, { SweetAlertOptions, SweetAlertResult, SweetAlertType } from "sweetalert2";
import ISimpleSweetAlertOptions from "./SimpleSweetAlertOptions";

declare var DotNet: any;
const domWindow = window as any;
const namespace: string = "CurrieTechnologies.Blazor.SweetAlert2";

function dispatchFireResult(requestId: string, result: SweetAlertResult): Promise<void> {
  return DotNet.invokeMethodAsync(namespace, "ReceiveFireResult", requestId, result);
}

function dispatchPreConfirm(requestId: string, inputValue: any): Promise<any> {
  return DotNet.invokeMethodAsync(namespace, "ReceivePreConfirmInput", requestId, inputValue);
}

function dispatchInputValidator(requestId: string, inputValue: any): Promise<string> {
  return DotNet.invokeMethodAsync(namespace, "ReceiveInputValidatorInput", requestId, inputValue);
}

function dispatchOnOpen(requestId: string): void {
  DotNet.invokeMethodAsync(namespace, "ReceiveOnOpenInput", requestId);
}

function dispatchOnClose(requestId: string): void {
  DotNet.invokeMethodAsync(namespace, "ReceiveOnCloseInput", requestId);
}

function dispatchOnBeforeOpen(requestId: string): void {
  DotNet.invokeMethodAsync(namespace, "ReceiveOnBeforeOpenInput", requestId);
}

function dispatchOnAfterClose(requestId: string): void {
  DotNet.invokeMethodAsync(namespace, "ReceiveOnAfterCloseInput", requestId);
}

function dispatchOnComplete(requestId: string): void {
  DotNet.invokeMethodAsync(namespace, "ReceiveOnCompleteInput", requestId);
}

function getSwalSettingsFromPoco(settings: ISimpleSweetAlertOptions, requestId: string): SweetAlertOptions {
  const swalSettings = (settings as any) as SweetAlertOptions;
  swalSettings.preConfirm = settings.preConfirm ? (inputValue) => dispatchPreConfirm(requestId, inputValue) : null;
  swalSettings.inputValidator = settings.inputValidator
    ? (inputValue) => dispatchInputValidator(requestId, inputValue)
    : null;
  swalSettings.onBeforeOpen = settings.onBeforeOpen ? () => dispatchOnBeforeOpen(requestId) : null;
  swalSettings.onAfterClose = settings.onAfterClose ? () => dispatchOnAfterClose(requestId) : null;
  swalSettings.onOpen = settings.onOpen ? () => dispatchOnOpen(requestId) : null;
  swalSettings.onClose = settings.onClose ? () => dispatchOnClose(requestId) : null;
  swalSettings.grow = settings.grow === "false" ? false : settings.grow;
  return swalSettings;
}

domWindow.CurrieTechnologies = domWindow.CurrieTechnologies || {};
domWindow.CurrieTechnologies.Blazor = domWindow.CurrieTechnologies.Blazor || {};
domWindow.CurrieTechnologies.Blazor.SweetAlert2 = domWindow.CurrieTechnologies.Blazor.SweetAlert2 || {};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.Fire = async (
  requestId: string,
  title: string,
  message: string,
  type: SweetAlertType,
) => {
  const result = await Swal.fire(title, message, type);
  await dispatchFireResult(requestId, result);
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.FireSettings = async (
  requestId: string,
  settingsPoco: ISimpleSweetAlertOptions,
) => {
  const swalSettings = getSwalSettingsFromPoco(settingsPoco, requestId);

  const result = await Swal.fire(swalSettings);
  await dispatchFireResult(requestId, result);
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.Queue = async (
  requestId: string,
  optionIds: string[],
  steps: ISimpleSweetAlertOptions[],
) => {
  const arrSwalSettings: SweetAlertOptions[] = optionIds.map((optionId, i) =>
    getSwalSettingsFromPoco(steps[i], optionId),
  );

  const result = await Swal.queue(arrSwalSettings);
  await dispatchFireResult(requestId, result);
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.IsVisible = (): boolean => {
  return !!Swal.isVisible();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.Update = async (
  requestId: string,
  settingsPoco: ISimpleSweetAlertOptions,
) => {
  const swalSettings = getSwalSettingsFromPoco(settingsPoco, requestId);
  Swal.update(swalSettings);
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.Close = (requestId: string): void => {
  Swal.close(() => dispatchOnComplete(requestId));
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.EnableButtons = (): void => {
  Swal.enableButtons();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.DisableButtons = (): void => {
  Swal.disableButtons();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.ShowLoading = (): void => {
  Swal.showLoading();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.HideLoading = (): void => {
  Swal.hideLoading();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.HideLoading = (): boolean => {
  return Swal.isLoading();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.ClickConfirm = (): void => {
  Swal.clickConfirm();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.ClickCancel = (): void => {
  Swal.clickCancel();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.ShowValidationMessage = (validationMessage: string): void => {
  Swal.showValidationMessage(validationMessage);
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.ResetValidationMessage = (): void => {
  Swal.resetValidationMessage();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.DisableInput = (): void => {
  Swal.disableInput();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.EnableInput = (): void => {
  Swal.enableInput();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.GetTimerLeft = (): number | undefined => {
  return Swal.getTimerLeft();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.StopTimer = (): number | undefined => {
  return Swal.stopTimer();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.ResumeTimer = (): number | undefined => {
  return Swal.resumeTimer();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.ToggleTimer = (): number | undefined => {
  return Swal.toggleTimer();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.IsTimmerRunning = (): boolean | undefined => {
  return Swal.isTimerRunning();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.IncreaseTimer = (n: number): number | undefined => {
  return Swal.increaseTimer(n);
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.GetQueueStep = (): string => {
  return Swal.getQueueStep();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.InsertQueueStep = (
  requestId: string,
  step: ISimpleSweetAlertOptions,
  index?: number,
): number => {
  const stepSettings = getSwalSettingsFromPoco(step, requestId);
  return Swal.insertQueueStep(stepSettings, index);
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.DeleteQueueStep = (index: number): void => {
  Swal.deleteQueueStep(index);
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.ShowProgressSteps = (): void => {
  Swal.showProgressSteps();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.HideProgressSteps = (): void => {
  Swal.hideProgressSteps();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.IsValidParamter = (paramName: string): boolean => {
  return Swal.isValidParameter(paramName);
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.IsUpdatableParamter = (paramName: string): boolean => {
  return Swal.isUpdatableParameter(paramName);
};
