using CorrelationId.DependencyInjection;
using CorrelationId;
using ExamAppWebUI.Middlewares;
using ExamAppWebUI.Models.Implementations;
using Microsoft.AspNetCore.Cors.Infrastructure;
using NLog.Web;
using NLog;
using ExamAppDataAccess.Interfaces;
using ExamAppDataAccess.Implementations.EntityFramework;
using ExamAppWebUI.Mappers.Interfaces;
using ExamAppEntities.Implementations;
using ExamAppWebUI.Mappers.Implementations;
using ExamAppWebUI.Services.Interfaces;
using ExamAppWebUI.Services.Implementations;

var logger = LogManager.Setup().LoadConfigurationFromFile("nLog.config").GetCurrentClassLogger();

try
{
    logger.Log(NLog.LogLevel.Info, "Application started");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseNLog();

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    var connectionString = builder.Configuration.GetConnectionString("Default");

    builder.Services.AddDefaultCorrelationId();

    if (connectionString != null)
    {
        builder.Services.AddTransient<IUnitOfWork>((serviceProvider) =>
        {
            return new UnitOfWork(connectionString);
        });
    }

    builder.Services.AddScoped<IBaseMapper<Student, StudentModel>, StudentMapper>();
    builder.Services.AddScoped<IBaseMapper<Subject, SubjectModel>, SubjectMapper>();
    builder.Services.AddScoped<IBaseMapper<Exam, ExamModel>, ExamMapper>();


    builder.Services.AddScoped<IStudentService, StudentService>();
    builder.Services.AddScoped<ISubjectService, SubjectService>();
    builder.Services.AddScoped<IExamService, ExamService>();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseMiddleware<HttpLoggerMiddleware>();
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.UseCorrelationId();
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{
    logger.Fatal(ex, "Application start-up failed");
}
finally
{
    LogManager.Shutdown();
}