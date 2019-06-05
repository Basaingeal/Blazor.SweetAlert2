import Swal, { SweetAlertOptions, SweetAlertResult, SweetAlertType } from "sweetalert2";

declare var DotNet: any;
const domWindow = window as any;
const namespace: string = "CurrieTechnologies.Blazor.SweetAlert2";

function dispatchFireResult(requestId: string, result: SweetAlertResult): Promise<void> {
  return DotNet.invokeMethodAsync(namespace, "ReceiveFireResult", requestId, result);
}

function dispatchExecutePreConfirm(requestId: string, inputValue: any): Promise<any> {
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

domWindow.CurrieTechnologies.Blazor.SweetAlert2.FireSettings = async (requestId: string, settingsJson: string) => {
  const settings = JSON.parse(settingsJson);

  const swalSettings = settings as SweetAlertOptions;
  swalSettings.preConfirm = settings.preConfirm
    ? (inputValue) => dispatchExecutePreConfirm(requestId, inputValue)
    : null;
  swalSettings.inputValidator = settings.inputValidator
    ? (inputValue) => dispatchInputValidator(requestId, inputValue)
    : null;
  swalSettings.onBeforeOpen = settings.onBeforeOpen ? () => dispatchOnBeforeOpen(requestId) : null;
  swalSettings.onAfterClose = settings.onAfterClose ? () => dispatchOnAfterClose(requestId) : null;
  swalSettings.onOpen = settings.onOpen ? () => dispatchOnOpen(requestId) : null;
  swalSettings.onClose = settings.onClose ? () => dispatchOnClose(requestId) : null;

  const result = await Swal.fire(swalSettings);
  await dispatchFireResult(requestId, result);
};
