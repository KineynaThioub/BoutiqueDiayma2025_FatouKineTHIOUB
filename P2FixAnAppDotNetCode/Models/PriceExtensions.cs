using System.Globalization;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// Affichage des prix en francs CFA (la boutique vend au Sénégal).
    /// Le format "c" affichait $ / € / ¤ selon la culture choisie.
    /// </summary>
    public static class PriceExtensions
    {
        public static string ToFcfa(this double price)
        {
            return price.ToString("N0", CultureInfo.CurrentCulture) + " FCFA";
        }
    }
}
