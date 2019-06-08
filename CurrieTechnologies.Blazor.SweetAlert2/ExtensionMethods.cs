using Microsoft.Extensions.DependencyInjection;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public static class ExtensionMethods
    {
        public static IServiceCollection AddSweetAlert2(this IServiceCollection services)
        {
            return services.AddSingleton<SweetAlertService>();
        }
    }
}
