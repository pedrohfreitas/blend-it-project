using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Blend.IT.AppService.Interfaces;
using Blend.IT.AppService.Services;
using Blend.IT.Domain.Interfaces;
using Blend.IT.Domain.Repositories;
using Blend.IT.Domain.Services;
using Blend.IT.Infra.Repositories;

namespace Blend.IT.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddTransient<IAuthenticateAppService, AuthenticateAppService>();
            services.AddTransient<IAuthenticateService, AuthenticateService>();
            services.AddTransient<IAuthenticateRepository, AuthenticateRepository>();

            services.AddTransient<IStudentAppService, StudentAppService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IStudentRepository, StudentRepository>();

            services.AddTransient<ITeacherAppService, TeacherAppService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();

        }
    }
}
