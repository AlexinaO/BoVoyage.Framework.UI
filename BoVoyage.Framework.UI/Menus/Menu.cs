using System;
using System.Collections.Generic;
using System.Linq;

namespace BoVoyage.Framework.UI
{
	public class Menu
	{
		private readonly List<ElementMenu> elements = new List<ElementMenu>();

		public Menu()
		{
		}

		public Menu(string libelle)
		{
			this.Libelle = libelle;
		}

        public string Libelle
        {
            get; private set;
        }

        public void Afficher()
		{
			ElementMenu elementMenu;
			while (true)
			{
				ConsoleHelper.AfficherEntete(this.Libelle);
				foreach (var element in this.elements)
				{
					element.Afficher();
				}

                Console.WriteLine();
                ConsoleHelper.AfficherVotreChoix();
				do
				{
					var consoleKeyInfo = Console.ReadKey();
					elementMenu = this.elements.FirstOrDefault((ElementMenu x) => x.Correspondre(consoleKeyInfo.KeyChar.ToString()));

                    if (elementMenu == null)
                    {
                        Console.WriteLine();
                        ConsoleHelper.AfficherMessageErreur("Choix incorrect. ");
                        ConsoleHelper.AfficherVotreChoix();
                    }
				}
				while (elementMenu == null);
				elementMenu.Executer();
				if (elementMenu is ElementMenuQuitterMenu)
				{
					break;
				}
			}
		}

		public void AjouterElement(ElementMenu element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element", "L'élément à ajouter ne peut pas être null");
			}
			if (this.elements.Any<ElementMenu>((ElementMenu x) => x.Commande == element.Commande))
			{
				throw new InvalidOperationException(string.Format("Il y a déjà un élément de menu avec la commande {0}", element.Commande));
			}
			this.elements.Add(element);
		}

        public void DefinirLibelle(string libelle)
        {
            this.Libelle = libelle;
        }
	}
}