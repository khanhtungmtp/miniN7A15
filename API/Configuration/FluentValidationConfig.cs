
using API._Validators;
using API.Dtos;
using FluentValidation;
using FluentValidation.Resources;

namespace API.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfig(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddScoped<ILanguageManager, CustomLanguageManager>();
            services.AddScoped<IValidator<ProductCreateDto>, CreateProductValidator>();

        }
    }
}