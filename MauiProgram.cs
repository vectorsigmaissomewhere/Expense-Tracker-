using Cashy.Services;
using Microsoft.Extensions.Logging;

namespace Cashy
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
            builder.Services.AddSingleton(sp => new SQLiteDatabase(FileAccessHelper.GetLocalFilePath("app.db")));
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<TransactionService>();

            return builder.Build();
        }
    }
}
