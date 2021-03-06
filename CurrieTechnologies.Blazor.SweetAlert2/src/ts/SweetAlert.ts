﻿// tslint:disable-next-line: no-reference
/// <reference path="../../node_modules/sweetalert2/sweetalert2.d.ts"/>

// tslint:disable-next-line: no-submodule-imports
import flatten from "lodash/flatten";
import Swal, { SweetAlertOptions, SweetAlertResult, SweetAlertType } from "sweetalert2";
import ISimpleSweetAlertOptions from "./SimpleSweetAlertOptions";
import ISweetAlertQueueResult from "./SweetAlertQueueResult";
import ISweetAlertResult from "./SweetAlertResult";

declare var DotNet: any;
const domWindow = window as any;
const namespace: string = "CurrieTechnologies.Blazor.SweetAlert2";

function getEnumNumber(enumString: string): number {
  if (enumString === "cancel") {
    return 0;
  }
  if (enumString === "backdrop") {
    return 1;
  }
  if (enumString === "close") {
    return 2;
  }
  if (enumString === "esc") {
    return 3;
  }
  if (enumString === "timer") {
    return 4;
  }
  return 0;
}

function getStringVerison(input: any): string {
  if (input instanceof Object) {
    return JSON.stringify(input);
  }
  return input.toString();
}

function dispatchFireResult(requestId: string, result: SweetAlertResult): Promise<void> {
  const myResult = (result as any) as ISweetAlertResult;
  myResult.value = myResult.value ? getStringVerison(myResult.value) : null;
  myResult.dismiss = myResult.dismiss ? getEnumNumber(result.dismiss.toString()) : null;
  return DotNet.invokeMethodAsync(namespace, "ReceiveFireResult", requestId, myResult);
}

function dispatchQueueResult(requestId: string, result: SweetAlertResult): Promise<void> {
  const queueResult = result as ISweetAlertQueueResult;
  queueResult.value = result.value ? flatten(result.value).map((v: any) => (v ? getStringVerison(v) : null)) : null;
  queueResult.dismiss = queueResult.dismiss ? getEnumNumber(result.dismiss.toString()) : null;
  return DotNet.invokeMethodAsync(namespace, "ReceiveQueueResult", requestId, queueResult);
}

function dispatchPreConfirm(requestId: string, inputValue: any): Promise<any> {
  return DotNet.invokeMethodAsync(namespace, "ReceivePreConfirmInput", requestId, getStringVerison(inputValue));
}

function dispatchQueuePreConfirm(requestId: string, inputValue: any): Promise<any> {
  const valArray: any[] = Array.isArray(inputValue) ? inputValue : [inputValue];

  return DotNet.invokeMethodAsync(
    namespace,
    "ReceivePreConfirmQueueInput",
    requestId,
    valArray.map((v) => getStringVerison(v)),
  );
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

function cleanSettings(settings: ISimpleSweetAlertOptions): ISimpleSweetAlertOptions {
  const settingsToReturn: any = { ...settings } as any;
  for (const propName in settingsToReturn) {
    if (settingsToReturn[propName] === null || settingsToReturn[propName] === undefined) {
      delete settingsToReturn[propName];
    }
  }

  return settingsToReturn as ISimpleSweetAlertOptions;
}

function getSwalSettingsFromPoco(
  settings: ISimpleSweetAlertOptions,
  requestId: string,
  isQueue: boolean,
): SweetAlertOptions {
  const swalSettings = (cleanSettings(settings) as any) as SweetAlertOptions;

  if (settings.preConfirm) {
    swalSettings.preConfirm = isQueue
      ? (inputValue) => dispatchQueuePreConfirm(requestId, inputValue)
      : (inputValue) => dispatchPreConfirm(requestId, inputValue);
  } else {
    delete swalSettings.preConfirm;
  }

  if (settings.inputValidator) {
    swalSettings.inputValidator = (inputValue) => dispatchInputValidator(requestId, inputValue);
  } else {
    delete swalSettings.inputValidator;
  }

  if (settings.onBeforeOpen) {
    swalSettings.onBeforeOpen = () => dispatchOnBeforeOpen(requestId);
  } else {
    delete swalSettings.onBeforeOpen;
  }

  if (settings.onAfterClose) {
    swalSettings.onAfterClose = () => dispatchOnAfterClose(requestId);
  } else {
    delete swalSettings.onAfterClose;
  }

  if (settings.onOpen) {
    swalSettings.onOpen = () => dispatchOnOpen(requestId);
  } else {
    delete swalSettings.onOpen;
  }

  if (settings.onClose) {
    swalSettings.onClose = () => dispatchOnClose(requestId);
  } else {
    delete swalSettings.onClose;
  }

  if (settings.grow === "false") {
    swalSettings.grow = false;
  } else if (settings.grow == null) {
    delete swalSettings.grow;
  } else {
    swalSettings.grow = settings.grow;
  }

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
  let params: [string] | [string, string] | [string, string, string] = [title];
  params = message ? ([...params, message] as [string, string]) : ([...params, ""] as [string, string]);
  params = type ? ([...params, type.toString()] as [string, string, string]) : params;
  const result = await Swal.fire(Swal.argsToParams(params));
  await dispatchFireResult(requestId, result);
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.FireSettings = async (
  requestId: string,
  settingsPoco: ISimpleSweetAlertOptions,
) => {
  const swalSettings = getSwalSettingsFromPoco(settingsPoco, requestId, false);

  const result = await Swal.fire(swalSettings);
  await dispatchFireResult(requestId, result);
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.Queue = async (
  requestId: string,
  optionIds: string[],
  steps: ISimpleSweetAlertOptions[],
) => {
  const arrSwalSettings: SweetAlertOptions[] = optionIds.map((optionId, i) =>
    getSwalSettingsFromPoco(steps[i], optionId, true),
  );

  const result = await Swal.queue(arrSwalSettings);
  await dispatchQueueResult(requestId, result);
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.IsVisible = (): boolean => {
  return !!Swal.isVisible();
};

domWindow.CurrieTechnologies.Blazor.SweetAlert2.Update = async (
  requestId: string,
  settingsPoco: ISimpleSweetAlertOptions,
) => {
  const swalSettings = getSwalSettingsFromPoco(settingsPoco, requestId, false);
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
  const stepSettings = getSwalSettingsFromPoco(step, requestId, true);
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

domWindow.CurrieTechnologies.Blazor.SweetAlert2.SetTheme = (theme: number): void => {
  let fileName: string = "";
  switch (theme) {
    case 1: {
      fileName = "darkTheme.min.css";
      break;
    }
    case 2: {
      fileName = "minimalTheme.min.css";
      break;
    }
    case 3: {
      fileName = "borderlessTheme.min.css";
      break;
    }
    default: {
      return;
    }
  }

  const head = document.getElementsByTagName("head")[0];
  const styleTag = document.createElement("link");
  styleTag.rel = "stylesheet";
  styleTag.href = `_content/CurrieTechnologies.Blazor.SweetAlert2/${fileName}`;
  head.appendChild(styleTag);
};
