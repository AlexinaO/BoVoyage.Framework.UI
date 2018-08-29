using System;

namespace BoVoyage.Framework.UI
{
	public static class ConsoleSaisie
	{
		private const string MessagePourValeurObligatoire = "Valeur obligatoire. Veuillez recommencer: ";

		private const string MessagePourValeurInvalide = "Valeur invalide. Veuillez recommencer: ";

		public static string SaisirChaineObligatoire(string libelle)
		{
			ConsoleHelper.AfficherLibelleSaisie(libelle);
			string saisie = Console.ReadLine();
            while(string.IsNullOrEmpty(saisie))
			{
				ConsoleHelper.AfficherMessageErreur("Valeur obligatoire. Veuillez recommencer: ");
                saisie = Console.ReadLine();
            }

            return saisie;
		}

		public static string SaisirChaineOptionnelle(string libelle)
		{
			ConsoleHelper.AfficherLibelleSaisie(libelle);
			return Console.ReadLine();
		}

		public static DateTime SaisirDateObligatoire(string libelle)
		{
			ConsoleHelper.AfficherLibelleSaisie(libelle);
            var valeur = new DateTime();
            bool estValide = true;
			do
			{
                estValide = true;
                string saisie = Console.ReadLine();
				if (!string.IsNullOrEmpty(saisie))
				{
					if (!DateTime.TryParse(saisie, out valeur))
					{
						ConsoleHelper.AfficherMessageErreur("Valeur invalide. Veuillez recommencer: ");
                        estValide = false;
					}
				}
				else
				{
					ConsoleHelper.AfficherMessageErreur("Valeur obligatoire. Veuillez recommencer: ");
                    estValide = false;
                }
            }
			while (!estValide);
			return valeur;
		}

		public static DateTime? SaisirDateOptionnelle(string libelle)
		{
			bool estValide;
            DateTime? valeur = null;
            ConsoleHelper.AfficherLibelleSaisie(libelle);
			do
			{
                estValide = true;
				string saisie = Console.ReadLine();
				if (!string.IsNullOrEmpty(saisie))
				{
					if (DateTime.TryParse(saisie, out DateTime dateTime))
					{
                        valeur = dateTime;
					}
					else
					{
                        ConsoleHelper.AfficherMessageErreur("Valeur invalide. Veuillez recommencer: ");
                        estValide = false;
                    }
                }
				else
				{
                    valeur = null;
					break;
				}
			}
			while (!estValide);
			return valeur;
		}

        public static decimal SaisirDecimalObligatoire(string libelle)
        {
            ConsoleHelper.AfficherLibelleSaisie(libelle);
            decimal valeur = new decimal();
            bool estValide = true;
            do
            {
                estValide = true;
                string saisie = Console.ReadLine();
                if (!string.IsNullOrEmpty(saisie))
                {
                    if (!decimal.TryParse(saisie.Replace(".", ","), out valeur))
                    {
                        ConsoleHelper.AfficherMessageErreur("Valeur invalide. Veuillez recommencer: ");
                        estValide = false;
                    }
                }
                else
                {
                    ConsoleHelper.AfficherMessageErreur("Valeur obligatoire. Veuillez recommencer: ");
                    estValide = false;
                }
            }
            while (!estValide);
            return valeur;
        }

        public static decimal? SaisirDecimalOptionnel(string libelle)
        {
            bool estValide;
            decimal? valeur = null;
            ConsoleHelper.AfficherLibelleSaisie(libelle);
            do
            {
                estValide = true;
                string saisie = Console.ReadLine();
                if (!string.IsNullOrEmpty(saisie))
                {
                    if (decimal.TryParse(saisie.Replace(".", ","), out decimal nombre))
                    {
                        valeur = nombre;
                    }
                    else
                    {
                        ConsoleHelper.AfficherMessageErreur("Valeur invalide. Veuillez recommencer: ");
                        estValide = false;
                    }
                }
                else
                {
                    valeur = null;
                    break;
                }
            }
            while (!estValide);
            return valeur;
        }

		public static int SaisirEntierObligatoire(string libelle)
		{
            ConsoleHelper.AfficherLibelleSaisie(libelle);
            int valeur = new int();
            bool estValide = true;
            do
            {
                estValide = true;
                string saisie = Console.ReadLine();
                if (!string.IsNullOrEmpty(saisie))
                {
                    if (!int.TryParse(saisie, out valeur))
                    {
                        ConsoleHelper.AfficherMessageErreur("Valeur invalide. Veuillez recommencer: ");
                        estValide = false;
                    }
                }
                else
                {
                    ConsoleHelper.AfficherMessageErreur("Valeur obligatoire. Veuillez recommencer: ");
                    estValide = false;
                }
            }
            while (!estValide);
            return valeur;
        }

        public static int? SaisirEntierOptionnel(string libelle)
		{
            bool estValide;
            int? valeur = null;
            ConsoleHelper.AfficherLibelleSaisie(libelle);
            do
            {
                estValide = true;
                string saisie = Console.ReadLine();
                if (!string.IsNullOrEmpty(saisie))
                {
                    if (int.TryParse(saisie, out int nombre))
                    {
                        valeur = nombre;
                    }
                    else
                    {
                        ConsoleHelper.AfficherMessageErreur("Valeur invalide. Veuillez recommencer: ");
                        estValide = false;
                    }
                }
                else
                {
                    valeur = null;
                    break;
                }
            }
            while (!estValide);
            return valeur;
        }
    }
}