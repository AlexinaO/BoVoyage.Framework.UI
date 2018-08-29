namespace BoVoyage.Framework.UI
{
    public abstract class ModuleBase<TApplication> : IModule where TApplication : ApplicationBase
    {
        private readonly string nomModule;

        protected ModuleBase(TApplication application, string nomModule)
        {
            this.Application = application;
            this.nomModule = nomModule;
        }

        string IModule.NomModule => this.nomModule;

        protected TApplication Application { get; }

        private Menu Menu { get; set; }

        /// <summary>
        /// Affiche le module. La première fois, il va initialiser le menu.
        /// </summary>
        public void Afficher()
        {
            if (this.Menu == null)
            {
                this.Menu = new Menu(this.nomModule);
                this.InitialiserMenu(this.Menu);
            }

            this.Menu.Afficher();
        }

        protected abstract void InitialiserMenu(Menu menu);
    }
}
