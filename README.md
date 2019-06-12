Installation
------------

```sh
Install-Package CurrieTechnologies.Blazor.PageVisibility --IncludePrerelease
```

Or grab from [Nuget](https://www.nuget.org/packages/CurrieTechnologies.Blazor.SweetAlert2/)


Usage
-----
Register the service in your Startup file.
```js
// Startup.cs
public void ConfigureServices(IServiceCollection services)
{
...
services.AddSweetAlert2();
...
}
```

Inject the SweetAlertService into any Blazor component
```cs
// Sample.razor
@inject SweetAlertService Swal;
<button class="btn btn-primary"
		@onclick="@(async () => await Swal.FireAsync("Any fool can use a computer"))">
	Try me!
</button>
```


Examples
--------

The most basic message:

```js
await Swal.FireAsync("Hello world!");
```

A message signaling an error:

```js
await Swal.FireAsync("Oops...", "Something went wrong!", "error");
```

Handling the result of SweetAlert2 modal:

```js
SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
	{
		Title = "Are you sure?",
		Text = "You will not be able to recover this imaginary file!",
		Type = SweetAlertType.Warning,
		ShowCancelButton = true,
		ConfirmButtonText = "Yes, delete it!",
		CancelButtonText = "No, keep it"
	});

if (!string.IsNullOrEmpty(result.Value))
{
	await Swal.FireAsync(
		"Deleted",
		"Your imaginary file has been deleted.",
		SweetAlertType.Success
		);
}
else if (result.Dismiss == DismissReason.Cancel)
{
	await Swal.FireAsync(
		"Cancelled",
		"Your imaginary file is safe :)'",
		SweetAlertType.Error
		);
}
```

## [More examples can be found on the SweetAlert2 project site](https://sweetalert2.github.io/)


Notable differences from the JavaScript library
---------------------
- No methods that return an HTMLElement are included (e. g. `Swal.getContainer()`)
- The value of a `SweetAlertResult` (`result.Value`) can only be a string (or a collection of strings if returned from a queue request). Object must be parsed to/from JSON in your code.
- `OnOpenAsync()`, `OnCloseAsync()`, `OnBeforeOpenAsync()`, and `OnAfterCloseAsync()` can all take asynchronous callbacks. 🎉 (none will return an HTMLElement though.)
- Callbacks must be passed inside of objects specifically designed for the given callback property. e.g. the `InputValidator` property takes an `InputValidatorCallback` created like so:
```js
new SweetAlertOptions {
	...
	InputValidator = new InputValidatorCallback(this, (string input) => input.Length == 0 ? "Please provide a value" : null),
	...
}
```
`this` is passed in so that the Blazor `EventCallback` used behind the scenes can trigger a re-render if the state of the calling component was changed in the callback.
These callbacks are necessary because there is currently no way to create an `EventCallback` in Blazor that isn't a component parameter without using the `EventCallbackFactory` which is clunky. It also allows the callback to return a value that can be used by the SweetAlert2 library. (e.g. A validation message to show if input validation fails.) Native Blazor `EventCallback`s only return generic `Task`s.
- Currently the timer functions which get information about the timer may fail if there is no current timer. This seems to be an issue with the JSInterop's ability to parse null into a nullable value type (e.g. `double?`).

Browser compatibility
---------------------
Compatible with all browsers than can run WebAssembly and Blazor.

 IE11* | Edge | Chrome | Firefox | Safari | Opera | UC Browser
-------|------|--------|---------|--------|-------|------------
 ❌ | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | ❌ |

Related projects
-------------------------

- [SweetAlert2](https://sweetalert2.github.io/) - Original SweetAlert2 project