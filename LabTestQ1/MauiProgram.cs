using Microsoft.Extensions.Logging;
using LabTestQ1.View;
using CommunityToolkit.Maui;
using LabTestQ1.ViewModels;
using LabTestQ1.Services;

namespace LabTestQ1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .RegisterViews()
                .UseMauiCommunityToolkit()
                .RegisterViewModel()
                .RegisterService()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            
            return builder.Build();
        }
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<Q1>();
            mauiAppBuilder.Services.AddTransient<Question1>();
            mauiAppBuilder.Services.AddTransient<Question2>();
            mauiAppBuilder.Services.AddTransient<Question3>();
            return mauiAppBuilder;
        }    
        public static MauiAppBuilder RegisterViewModel(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddScoped<RegistrationViewModel>();
            mauiAppBuilder.Services.AddScoped<Question3ViewModel>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterService(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddScoped<ApiClient>();
           
            return mauiAppBuilder;
        }
    }
}