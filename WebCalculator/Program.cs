using WebCalculator.Factories;
using WebCalculator.Interfaces;
using WebCalculator.Models;
using WebCalculator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IExpressionAnalysisService, ExpressionAnalysisService>();
builder.Services.AddTransient<IExpressionFactory, ExpressionFactory>();
builder.Services.AddSingleton<IOperator, OperationsInteractionService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
