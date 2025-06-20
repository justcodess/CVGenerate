using AutoMapper;
using CVGenerate.Application.Interfaces;
using CVGenerate.Application.Services;
using CVGenerate.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace CVGenerate.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IWorkExperienceService, WorkExperienceService>();
        services.AddScoped<IEducationService, EducationService>();
        services.AddScoped<ISkillService, SkillService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<IInterestService, InterestService>();
        services.AddScoped<IReferenceService, ReferenceService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IWebLinkService, WebLinkService>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IPersonalInfoService, PersonalInfoService>();
        services.AddScoped<ICustomSectionService, CustomSectionService>();
        services.AddScoped<IProfileService, ProfileService>();

        // DÜZELTİLMİŞ satır:
        services.AddAutoMapper(typeof(UserProfile).Assembly);

        return services;
    }
}