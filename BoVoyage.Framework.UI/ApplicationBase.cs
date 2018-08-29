using System;
using System.Collections.Generic;

namespace BoVoyage.Framework.UI
{
    public abstract class ApplicationBase
    {
        private readonly IList<IModule> modules = new List<IModule>();
        private readonly string nomApplication;

        protected ApplicationBase(string nomApplication)
        {
            this.nomApplication = nomApplication;
        }

        private Menu MenuPrincipal { get; set; }

        /// <summary>
        /// Démarre l'application.
        /// Les étapes:
        ///  1 - Initialisation des modules préalablement ajoutés
        ///  2 - Initialisation du menu principal
        ///  3 - Affichage du menu principal
        /// </summary>
        public void Demarrer()
        {
            this.InitialiserModules();
            this.InitialiserMenuPrincipal();

            this.MenuPrincipal.Afficher();
        }

        protected abstract void InitialiserModules();

        private void InitialiserMenuPrincipal()
        {
            this.MenuPrincipal = new Menu(this.nomApplication);
            int indexModule = 1;
            foreach (var module in this.modules)
            {
                this.MenuPrincipal.AjouterElement(new ElementMenu(indexModule++.ToString(), module.NomModule)
                {
                    AfficherLigneRetourMenuApresExecution = false,
                    FonctionAExecuter = module.Afficher
                });
            }

            this.MenuPrincipal.AjouterElement(new ElementMenuQuitterMenu("Q", "Quitter")
            {
                FonctionAExecuter = () => Environment.Exit(1)
            });
        }

        protected TModule AjouterModule<TModule>(TModule module)
            where TModule : IModule
        {
            this.modules.Add(module);
            return module;
        }
    }
}
