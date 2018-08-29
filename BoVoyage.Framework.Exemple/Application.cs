using BoVoyage.Framework.UI;

namespace BoVoyage.Framework.Exemple
{
    public class Application : ApplicationBase
    {
        public Application()
            : base("Mon application")
        {
        }

        public Module1 Module1 { get; private set; }

        protected override void InitialiserModules()
        {
            this.Module1 = this.AjouterModule(new Module1(this, "Module 1"));
        }
    }
}
