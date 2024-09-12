using WebCalculator.Factories;
using WebCalculator.Interfaces;
using WebCalculator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IExpressionAnalysisService, ExpressionAnalysisService>();
builder.Services.AddTransient<IExpressionFactory, ExpressionFactory>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
