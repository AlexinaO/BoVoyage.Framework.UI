using System;

namespace BoVoyage.Framework.UI
{
    public class ElementMenu
    {
        public ElementMenu(string commande, string libelle)
        {
            this.Commande = commande ?? throw new ArgumentNullException(nameof(commande));
            this.Libelle = libelle ?? throw new ArgumentNullException(nameof(libelle));
        }

        public string Libelle { get; }

        public string Commande { get; }

        public bool AfficherLigneRetourMenuApresExecution { get; set; } = true;

        public Action FonctionAExecuter { get; set; }

        public bool Correspondre(string valeur)
        {
            return this.Commande.Equals(valeur, StringComparison.OrdinalIgnoreCase);
        }

        public virtual void Afficher()
        {
            Console.WriteLine(string.Format("{0} - {1}", this.Commande, this.Libelle));
        }

        public virtual void Executer()
        {
            ConsoleHelper.AfficherEntete(this.Libelle);
            this.FonctionAExecuter();
            if (this.AfficherLigneRetourMenuApresExecution)
            {
                ConsoleHelper.AfficherLignePourRetournerAuMenu();
            }
        }
    }
}