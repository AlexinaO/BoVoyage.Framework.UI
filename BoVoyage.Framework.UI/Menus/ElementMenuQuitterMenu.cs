using System;

namespace BoVoyage.Framework.UI
{
    public sealed class ElementMenuQuitterMenu : ElementMenu
    {
        public ElementMenuQuitterMenu(string commande, string libelle) : base(commande, libelle)
        {
            this.AfficherLigneRetourMenuApresExecution = false;
        }

        public override void Afficher()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine();
            Console.WriteLine($"Tapez {this.Commande} pour {this.Libelle}");
            Console.ResetColor();
        }

        public override void Executer()
        {
            this.FonctionAExecuter?.Invoke();
        }
    }
}