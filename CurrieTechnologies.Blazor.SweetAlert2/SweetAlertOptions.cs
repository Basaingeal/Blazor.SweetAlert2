using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public class SweetAlertOptions
    {
        /// <summary>
        /// The title of the modal, as HTML.
        /// <para>It can either be added to the object under the key "title" or passed as the first parameter of the function.</para>
        /// </summary>
        public string Titlte { get; set; } = null;

        /// <summary>
        /// The title of the modal, as text. Useful to avoid HTML injection.
        /// </summary>
        public string TitleText { get; set; } = null;

        /// <summary>
        /// A description for the modal.
        /// <para>It can either be added to the object under the key "text" or passed as the second parameter of the function.</para>
        /// </summary>
        public string Text { get; set; } = null;

        /// <summary>
        /// A HTML description for the modal.
        /// <para>If "text" and "html" parameters are provided in the same time, "text" will be used.</para>
        /// </summary>
        public string Html { get; set; } = null;

        /// <summary>
        /// The footer of the modal, as HTML.
        /// </summary>
        public string Footer { get; set; } = null;

        /// <summary>
        /// The type of the modal.
        /// <para>SweetAlert2 comes with 5 built-in types which will show a corresponding icon animation: 'warning', 'error', 'success', 'info' and 'question'.</para>
        /// <para>It can either be put in the array under the key "type" or passed as the third parameter of the function.</para>
        /// </summary>
        public SweetAlertType Type { get; set; } = null;

        // TODO: Allow string - Either a boolean value or a css background value (hex, rgb, rgba, url, etc.)
        /// <summary>
        /// Whether or not SweetAlert2 should show a full screen click-to-dismiss backdrop.
        /// </summary>
        public bool Backdrop { get; set; } = true;

        /// <summary>
        /// Whether or not an alert should be treated as a toast notification.
        /// <para>This option is normally coupled with the `position` parameter and a timer.</para>
        /// <para>Toasts are NEVER autofocused.</para>
        /// </summary>
        public bool Toast { get; set; } = false;

        /// <summary>
        /// The container element for adding modal into (query selector only).
        /// </summary>
        public string Target { get; set; } = "body";

        // TODO: Type-Safe Enum for input
        /// <summary>
        /// Input field type, can be text, email, password, number, tel, range, textarea, select, radio, checkbox, file and url.
        /// </summary>
        public string Input { get; set; } = null;

        /// <summary>
        /// Modal window width, including paddings (box-sizing: border-box). Can be in px or %.
        /// </summary>
        public string Width { get; set; } = null;

        /// <summary>
        /// Modal window padding.
        /// </summary>
        public string Padding { get; set; } = null;

        /// <summary>
        /// Modal window background (CSS background property).
        /// </summary>
        public string Background { get; set; } = "#fff";

        // TODO: Type-Safe Enum for Position
        /// <summary>
        /// Modal window position
        /// </summary>
        public string Position { get; set; } = "center";

        //TODO: Type-safe enum for grow.
        //TODO: On client, switch null to false.
        /// <summary>
        /// Modal window grow direction
        /// </summary>
        public string Grow { get; set; } = null;

        /// <summary>
        /// A custom CSS class for the modal.
        /// <para>If a string value is provided, the classname will be applied to the popup.</para>
        /// <para></para>
        /// </summary>
        public SweetAlertCustomClass CustomClass { get; set; } = new SweetAlertCustomClass("");

        /// <summary>
        /// Auto close timer of the modal. Set in ms (milliseconds).
        /// </summary>
        public decimal? Timer { get; set; } = null;

        //TODO: Accept function to resolve.
        /// <summary>
        /// If set to false, modal CSS animation will be disabled.
        /// </summary>
        public bool? Animation { get; set; } = true;

        /// <summary>
        /// By default, SweetAlert2 sets html's and body's CSS height to auto !important.
        /// <para>If this behavior isn't compatible with your project's layout, set heightAuto to false.</para>
        /// </summary>
        public bool? HeightAuto { get; set; } = true;

        //TODO: Accept function to resolve. All allows.
        /// <summary>
        /// If set to false, the user can't dismiss the modal by clicking outside it.
        /// </summary>
        public bool? AllowOutsideClick { get; set; } = true;

        /// <summary>
        /// If set to false, the user can't dismiss the modal by pressing the Escape key.
        /// </summary>
        public bool? AllowEscapeKey { get; set; } = true;

        /// <summary>
        /// If set to false, the user can't confirm the modal by pressing the Enter or Space keys, unless they manually focus the confirm button.
        /// </summary>
        public bool? AllowEnterKey { get; set; } = true;

        /// <summary>
        /// If set to false, SweetAlert2 will allow keydown events propagation to the document.
        /// </summary>
        public bool? StopKeydownPropagation { get; set; } = true;

        /// <summary>
        /// Useful for those who are using SweetAlert2 along with Bootstrap modals.
        /// <para>By default keydownListenerCapture is false which means when a user hits Esc, both SweetAlert2 and Bootstrap modals will be closed.</para>
        /// <para>Set keydownListenerCapture to true to fix that behavior.</para>
        /// </summary>
        public bool? KeydownListenerCapture { get; set; } = false;

        /// <summary>
        /// If set to false, a "Confirm"-button will not be shown.
        /// <para>It can be useful when you're using custom HTML description.</para>
        /// </summary>
        public bool? ShowConfirmButton { get; set; } = true;

        /// <summary>
        /// If set to true, a "Cancel"-button will be shown, which the user can click on to dismiss the modal.
        /// </summary>
        public bool? ShowCancelButton { get; set; } = false;

        /// <summary>
        /// Use this to change the text on the "Confirm"-button.
        /// </summary>
        public string ConfirmButtonText { get; set; } = "OK";

        /// <summary>
        /// Use this to change the text on the "Cancel"-button.
        /// </summary>
        public string CancelButtonText { get; set; } = "Cancel";

        /// <summary>
        /// Use this to change the background color of the "Confirm"-button (must be a HEX value).
        /// </summary>
        public string ConfirmButtonColor { get; set; } = "#3085d6";

        /// <summary>
        /// Use this to change the background color of the "Cancel"-button (must be a HEX value).
        /// </summary>
        public string CancelButtonColor { get; set; } = "#aaa";

        /// <summary>
        /// Use this to change the aria-label for the "Confirm"-button.
        /// </summary>
        public string ConfirmButtonAriaLabel { get; set; } = "";

        /// <summary>
        /// Use this to change the aria-label for the "Cancel"-button.
        /// </summary>
        public string CancelButtonAriaLabel { get; set; } = "";

        /// <summary>
        /// Whether to apply the default SweetAlert2 styling to buttons.
        /// <para>If you want to use your own classes (e.g. Bootstrap classes) set this parameter to false.</para>
        /// </summary>
        public bool? ButtonsStyling { get; set; } = true;

        /// <summary>
        /// Set to true if you want to invert default buttons positions.
        /// </summary>
        public bool? ReverseButtons { get; set; } = false;

        /// <summary>
        /// Set to false if you want to focus the first element in tab order instead of "Confirm"-button by default.
        /// </summary>
        public bool? FocusConfirm { get; set; } = true;

        /// <summary>
        /// Set to true if you want to focus the "Cancel"-button by default.
        /// </summary>
        public bool? FocusCancel { get; set; } = false;

        /// <summary>
        /// Set to true to show close button in top right corner of the modal.
        /// </summary>
        public bool? ShowCloseButton { get; set; } = false;

        /// <summary>
        /// Use this to change the `aria-label` for the close button.
        /// </summary>
        public string CloseButtonAriaLabel { get; set; } = "Close this dialog";

        /// <summary>
        /// Set to true to disable buttons and show that something is loading. Useful for AJAX requests.
        /// </summary>
        public bool? ShowLoaderOnConfirm { get; set; } = false;

        //TODO: Remove if impossible
        /// <summary>
        /// Function to execute before confirm, may be async (Promise-returning) or sync.
        /// </summary>
        public Func<object, Task<object>> PreConfirm { get; set; } = null;

        /// <summary>
        /// Add a customized icon for the modal. Should contain a string with the path or URL to the image.
        /// </summary>
        public string ImageUrl { get; set; } = null;

        /// <summary>
        /// If imageUrl is set, you can specify imageWidth to describes image width in px.
        /// </summary>
        public double? ImageWidth { get; set; } = null;

        /// <summary>
        /// If imageUrl is set, you can specify imageHeight to describes image height in px.
        /// </summary>
        public double? ImageHeight { get; set; } = null;

        /// <summary>
        /// An alternative text for the custom image icon.
        /// </summary>
        public string ImageAlt { get; set; } = "";

        /// <summary>
        /// Input field placeholder.
        /// </summary>
        public string InputPlaceholder { get; set; } = "";

        /// <summary>
        /// Input field initial value.
        /// </summary>
        public string InputValue { get; set; } = "";

        /// <summary>
        /// If input parameter is set to "select" or "radio", you can provide options.
        /// <para>Object keys will represent options values, object values will represent options text values.</para>
        /// </summary>
        public Dictionary<string, string> InputOptions { get; set; }

        /// <summary>
        /// Automatically remove whitespaces from both ends of a result string.
        /// <para>Set this parameter to false to disable auto-trimming.</para>
        /// </summary>
        public bool? InputAutoTrim { get; set; } = true;

        //TODO: Input Attributes POCO
        /// <summary>
        /// HTML input attributes (e.g. min, max, step, accept...), that are added to the input field.
        /// </summary>
        public Dictionary<string, string> InputAttributes { get; set; } = null;

        /// <summary>
        /// Validator for input field.
        /// </summary>
        public Func<string, Task<string>> InputValidator { get; set; } = null;

        /// <summary>
        /// A custom validation message for default validators (email, url).
        /// </summary>
        public string ValidationMessage { get; set; } = null;

        /// <summary>
        /// Progress steps, useful for modal queues, see usage example.
        /// </summary>
        public IEnumerable<string> ProgressSteps { get; set; } = new List<string>();

        /// <summary>
        /// Current active progress step.
        /// </summary>
        public string CurrentProgressStep { get; set; }

        /// <summary>
        /// Distance between progress steps.
        /// </summary>
        public string ProgressStepsDistance { get; set; } = null;

        /// <summary>
        /// Function to run when modal built, but not shown yet. Provides modal DOM element as the first argument.
        /// </summary>
        public Action<string> OnBeforeOpen { get; set; } = null;

        /// <summary>
        /// Function to run after modal has been disposed.
        /// </summary>
        public Action OnActerClose { get; set; } = null;

        /// <summary>
        /// Function to run when modal opens, provides modal DOM element as the first argument.
        /// </summary>
        public Action<string> OnOpen { get; set; } = null;

        /// <summary>
        /// Function to run when modal closes, provides modal DOM element as the first argument.
        /// </summary>
        public Action<string> OnClose { get; set; } = null;

        /// <summary>
        /// Set to false to disable body padding adjustment when scrollbar is present.
        /// </summary>
        public bool? ScrollbarPadding { get; set; } = true;
    }
}
