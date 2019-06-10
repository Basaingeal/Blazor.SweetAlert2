namespace CurrieTechnologies.Blazor.SweetAlert2
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Collection of methods that extend other classes.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Adds the <see cref="SweetAlertService"/> as a signleton to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="SweetAlertService"/> to.</param>
        /// <returns>The original <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddSweetAlert2(this IServiceCollection services)
        {
            return services.AddSingleton<SweetAlertService>();
        }
    }
}
