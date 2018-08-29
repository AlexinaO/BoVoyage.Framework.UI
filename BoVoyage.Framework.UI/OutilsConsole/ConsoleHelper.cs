using System;
using System.Collections.Generic;
using System.Linq;

namespace BoVoyage.Framework.UI
{
    public static class ConsoleHelper
    {
        public static void AfficherEntete(string libelle)
        {
            Console.Clear();
            Console.ForegroundColor = CouleursConsole.Entete;
            string texte = new string('*', libelle.Length + 6);
            Console.WriteLine(texte);
            Console.WriteLine(string.Format("|  {0}  |", libelle.ToUpper()));
            Console.WriteLine(texte);
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void AfficherLibelleSaisie(string libelle)
        {
            Console.ForegroundColor = CouleursConsole.Saisie;
            Console.WriteLine();
            Console.WriteLine(libelle);
            Console.ResetColor();
        }

        public static void AfficherLignePourRetournerAuMenu()
        {
            Console.ForegroundColor = CouleursConsole.RetourMenu;
            Console.WriteLine();
            Console.WriteLine("> Appuyez sur une touche pour retourner au menu...");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void AfficherListe<T>(IEnumerable<T> liste, IEnumerable<InformationAffichage> strategieAffichage)
        {
            if (!strategieAffichage.Any())
            {
                Console.WriteLine("Rien à afficher...");
            }

            string[,] str = new string[liste.Count() + 2, strategieAffichage.Count()];
            for (int i = 0; i < strategieAffichage.Count(); i++)
            {
                var informationAffichage = strategieAffichage.ElementAt(i);
                int nombreCaracteres = informationAffichage.NombreCaracteres;
                str[0, i] = string.Format("{0} ", informationAffichage.GetEntete());
                str[1, i] = new string('-', nombreCaracteres + 1);
                for (int j = 0; j < liste.Count(); j++)
                {
                    var element = liste.ElementAt(j);
                    str[j + 2, i] = string.Format("{0} ", informationAffichage.GetValeur(element));
                }
            }
            for (int i = 0; i < liste.Count() + 2; i++)
            {
                for (int j = 0; j < strategieAffichage.Count(); j++)
                {
                    Console.Write(str[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void AfficherMessageErreur(string message)
        {
            ConsoleHelper.EffacerLignesConsole(1);
            Console.ForegroundColor = CouleursConsole.MessageErreur;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void AfficherVotreChoix()
        {
            Console.ForegroundColor = CouleursConsole.Saisie;
            Console.WriteLine();
            Console.Write("> Votre choix : ");
            Console.ResetColor();
        }

        public static void EffacerLignesConsole(int nombreLignes = 1)
        {
            for (int i = 1; i <= nombreLignes; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }
    }
}