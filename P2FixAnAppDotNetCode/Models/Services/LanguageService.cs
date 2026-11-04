using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Provides services method to manage the application language
    /// </summary>
    public class LanguageService : ILanguageService
    {
        /// <summary>
        /// Set the UI language
        /// </summary>
        public void ChangeUiLanguage(HttpContext context, string language)
        {
            string culture = SetCulture(language);
            UpdateCultureCookie(context, culture);
        }

        /// <summary>
        /// Set the culture
        /// </summary>
        public string SetCulture(string language)
        {
            string culture = "";
            // TODO complete the code 
            // Default language is "en", french is "fr" and wolof is "wo".
            // (l'espagnol "es" était proposé mais n'avait aucune traduction : remplacé par le wolof)
            switch (language)
            {
                case "French":
                    culture = "fr";
                    break;
                case "Wolof":
                    culture = "wo";
                    break;
                default:
                    culture = "en";
                    break;
            }
            return culture;
        }

        /// <summary>
        /// Update the culture cookie
        /// </summary>
        public void UpdateCultureCookie(HttpContext context, string culture)
        {
            // Wolof : textes de l'interface en wolof (UICulture "wo"),
            // mais on conserve la culture du français ("fr") pour les nombres, dates, etc.
            RequestCulture requestCulture = culture == "wo"
                ? new RequestCulture(culture: "fr", uiCulture: "wo")
                : new RequestCulture(culture);

            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(requestCulture));
        }
    }
}
