using System;
using System.Linq.Expressions;
using System.Reflection;

namespace BoVoyage.Framework.UI
{
    public sealed class InformationAffichage
    {
        private InformationAffichage(PropertyInfo propriete, string entete, int nombreCaracteres)
        {
            this.Propriete = propriete;
            this.Entete = entete;
            this.NombreCaracteres = nombreCaracteres;
        }

        /// <summary>
        /// Récupérer le nombre de caractères maximum à afficher
        /// </summary>
        internal int NombreCaracteres { get; }

        private PropertyInfo Propriete { get; }

        private string Entete { get; }

        /// <summary>
        /// Génère une instance de la classe <see cref="InformationAffichage"/>.
        /// </summary>
        /// <typeparam name="T">Type de la classe</typeparam>
        /// <param name="propriete">Propriété de la classe à afficher.</param>
        /// <param name="entete">Libellé de la colonne</param>
        /// <param name="nombreCaracteres">Nombre de caractères maximum à afficher</param>
        /// <returns></returns>
        public static InformationAffichage Creer<T>(Expression<Func<T, object>> propriete, string entete, int nombreCaracteres)
        {
            return new InformationAffichage(OutilsReflection.GetInformationPropriete(propriete), entete, nombreCaracteres);
        }

        internal string GetEntete()
        {
            return this.Entete.ToUpper().PadRight(this.NombreCaracteres);
        }

        internal string GetValeur(object element)
        {
            var renduTexte = string.Empty;
            var value = this.Propriete.GetValue(element);
            if (value != null)
            {
                renduTexte = value.ToString().Replace(Environment.NewLine, " ");
                if (value is DateTime date)
                {
                    renduTexte = date.ToShortDateString();
                }
            }

            return renduTexte.Tronquer(this.NombreCaracteres).PadRight(this.NombreCaracteres);
        }
    }
}