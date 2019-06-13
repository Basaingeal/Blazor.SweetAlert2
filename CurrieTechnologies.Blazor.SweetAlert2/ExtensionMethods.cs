namespace CurrieTechnologies.Blazor.SweetAlert2
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.JSInterop;
    using System;

    /// <summary>
    /// Collection of methods that extend other classes.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Adds the <see cref="SweetAlertService"/> as a singleton to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="SweetAlertService"/> to.</param>
        /// <returns>The original <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddSweetAlert2(this IServiceCollection services)
        {
            return services.AddSingleton<SweetAlertService>();
        }

        /// <summary>
        /// Registers an action to configure the <see cref="SweetAlertService"/> and add it as a singleton to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="SweetAlertService"/> to.</param>
        /// <param name="configureOptions">The action used to configure the options.</param>
        /// <returns></returns>
        public static IServiceCollection AddSweetAlert2(this IServiceCollection services, Action<SweetAlertServiceOptions> configureOptions)
        {
            var options = new SweetAlertServiceOptions();
            configureOptions(options);
            return services.AddSingleton(s => new SweetAlertService(s.GetRequiredService<IJSRuntime>(), options));
        }
    }
}
