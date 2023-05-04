using FluentValidation.Resources;
namespace API.Configuration
{
    public class CustomLanguageManager : LanguageManager
    {
        public CustomLanguageManager()
        {
            AddTranslation("en", "NotNullValidator", "'{PropertyName}' is required.");
            AddTranslation("en-US", "NotNullValidator", "'{PropertyName}' is required.");
            AddTranslation("en-GB", "NotNullValidator", "'{PropertyName}' is required.");
        }
    }
}