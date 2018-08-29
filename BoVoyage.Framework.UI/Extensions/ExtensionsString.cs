namespace BoVoyage.Framework.UI
{
    public static class ExtensionsString
    {
        public static string Tronquer(this string valeur, int nombreCaracteres)
        {
            return (valeur.Length <= nombreCaracteres ? valeur : string.Concat(valeur.Substring(0, nombreCaracteres - "...".Length), "..."));
        }
    }
}