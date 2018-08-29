namespace BoVoyage.Framework.UI
{
    public interface IModule
    {
        string NomModule { get; }

        void Afficher();
    }
}