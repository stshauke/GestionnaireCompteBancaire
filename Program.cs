// ============================================================
// FICHIER : Program.cs
// RÔLE    : Point d'entrée de l'application.
//           Gère le menu, les interactions utilisateur,
//           et l'écriture des transactions dans un fichier.
// ============================================================

using System;
using System.IO;                      // Pour écrire dans un fichier texte
using GestionnaireCompteBancaire;    // Pour accéder à nos classes

// --------------------------------------------------------
// CRÉATION DES COMPTES
// On instancie un compte courant et un compte épargne
// avec un titulaire, un numéro et un solde initial.
// --------------------------------------------------------

CompteCourant compteCourant = new CompteCourant(
    nomTitulaire: "Jean Dupont",
    numeroCmpte: "CC-001-2024",
    soldeInitial: 0m               // "m" indique que c'est un decimal
);

CompteEpargne compteEpargne = new CompteEpargne(
    nomTitulaire: "Jean Dupont",
    numeroCmpte: "CE-001-2024",
    soldeInitial: 0m
);

// --------------------------------------------------------
// MESSAGE DE DÉMARRAGE
// Affiché dès le lancement de l'application.
// --------------------------------------------------------

Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
Console.ReadLine(); // On attend que l'utilisateur appuie sur Entrée

// --------------------------------------------------------
// BOUCLE PRINCIPALE
// L'application tourne en boucle jusqu'à ce que
// l'utilisateur choisisse [X] pour quitter.
// --------------------------------------------------------

bool continuer = true; // Variable de contrôle de la boucle

while (continuer) // Tant que l'utilisateur ne quitte pas...
{
    // -- Affichage du menu --
    AfficherMenu();

    // -- Lecture du choix de l'utilisateur --
    // ToUpper() convertit en majuscules pour éviter les erreurs de casse
    string choix = Console.ReadLine()?.Trim().ToUpper() ?? "";

    // -- Traitement du choix avec un switch --
    switch (choix)
    {
        // -----------------------------------------------
        // [I] Afficher les infos du titulaire
        // -----------------------------------------------
        case "I":
            Console.WriteLine();
            compteCourant.AfficherInfos();  // Appel de la méthode héritée
            Console.WriteLine();
            compteEpargne.AfficherInfos();
            Console.WriteLine();
            Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
            Console.ReadLine();
            break;

        // -----------------------------------------------
        // [CS] Consulter le solde du compte courant
        // -----------------------------------------------
        case "CS":
            Console.WriteLine();
            Console.WriteLine($"Solde du compte courant : {compteCourant.Solde} €");
            Console.WriteLine();
            Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
            Console.ReadLine();
            break;

        // -----------------------------------------------
        // [CD] Déposer sur le compte courant
        // -----------------------------------------------
        case "CD":
            Console.WriteLine();
            Console.Write("Quel montant souhaitez-vous déposer ? ");
            if (decimal.TryParse(Console.ReadLine(), out decimal montantDepotCC))
            {
                // TryParse tente de convertir le texte en nombre décimal
                // Si ça échoue, on ne plante pas l'application
                compteCourant.Deposer(montantDepotCC);
            }
            else
            {
                Console.WriteLine("Montant invalide. Veuillez entrer un nombre.");
            }
            Console.WriteLine();
            Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
            Console.ReadLine();
            break;

        // -----------------------------------------------
        // [CR] Retirer du compte courant
        // -----------------------------------------------
        case "CR":
            Console.WriteLine();
            Console.Write("Quel montant souhaitez-vous retirer ? ");
            if (decimal.TryParse(Console.ReadLine(), out decimal montantRetraitCC))
            {
                compteCourant.Retirer(montantRetraitCC);
            }
            else
            {
                Console.WriteLine("Montant invalide. Veuillez entrer un nombre.");
            }
            Console.WriteLine();
            Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
            Console.ReadLine();
            break;

        // -----------------------------------------------
        // [ES] Consulter le solde du compte épargne
        // -----------------------------------------------
        case "ES":
            Console.WriteLine();
            Console.WriteLine($"Solde du compte épargne : {compteEpargne.Solde} €");
            Console.WriteLine();
            Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
            Console.ReadLine();
            break;

        // -----------------------------------------------
        // [ED] Déposer sur le compte épargne
        // -----------------------------------------------
        case "ED":
            Console.WriteLine();
            Console.Write("Quel montant souhaitez-vous déposer ? ");
            if (decimal.TryParse(Console.ReadLine(), out decimal montantDepotCE))
            {
                compteEpargne.Deposer(montantDepotCE);
            }
            else
            {
                Console.WriteLine("Montant invalide. Veuillez entrer un nombre.");
            }
            Console.WriteLine();
            Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
            Console.ReadLine();
            break;

        // -----------------------------------------------
        // [ER] Retirer du compte épargne
        // -----------------------------------------------
        case "ER":
            Console.WriteLine();
            Console.Write("Quel montant souhaitez-vous retirer ? ");
            if (decimal.TryParse(Console.ReadLine(), out decimal montantRetraitCE))
            {
                compteEpargne.Retirer(montantRetraitCE);
            }
            else
            {
                Console.WriteLine("Montant invalide. Veuillez entrer un nombre.");
            }
            Console.WriteLine();
            Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
            Console.ReadLine();
            break;

        // -----------------------------------------------
        // [X] Quitter l'application
        // -----------------------------------------------
        case "X":
            continuer = false; // On sort de la boucle while
            break;

        // -----------------------------------------------
        // Choix invalide
        // -----------------------------------------------
        default:
            Console.WriteLine();
            Console.WriteLine("Option invalide. Veuillez réessayer.");
            Console.WriteLine();
            Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
            Console.ReadLine();
            break;
    }
}

// --------------------------------------------------------
// ÉCRITURE DES TRANSACTIONS DANS UN FICHIER TEXTE
// Exécutée uniquement quand l'utilisateur choisit [X].
// --------------------------------------------------------

EcrireTransactionsDansFichier(compteCourant, compteEpargne);

Console.WriteLine();
Console.WriteLine("Au revoir ! Les transactions ont été sauvegardées.");
Console.WriteLine("Appuyez sur Entrée pour fermer.");
Console.ReadLine();


// ============================================================
// MÉTHODES LOCALES (définies après le code principal)
// ============================================================

/// <summary>
/// Affiche le menu principal dans la console.
/// </summary>
void AfficherMenu()
{
    Console.WriteLine();
    Console.WriteLine("Veuillez sélectionner une option ci-dessous :");
    Console.WriteLine("[I]  Voir les informations sur le titulaire du compte");
    Console.WriteLine("[CS] Compte courant  - Consulter le solde");
    Console.WriteLine("[CD] Compte courant  - Déposer des fonds");
    Console.WriteLine("[CR] Compte courant  - Retirer des fonds");
    Console.WriteLine("[ES] Compte épargne  - Consulter le solde");
    Console.WriteLine("[ED] Compte épargne  - Déposer des fonds");
    Console.WriteLine("[ER] Compte épargne  - Retirer des fonds");
    Console.WriteLine("[X]  Quitter");
    Console.Write("> "); // Invite de saisie
}

/// <summary>
/// Écrit toutes les transactions des deux comptes dans un fichier texte.
/// Le fichier est créé dans le dossier de l'application.
/// </summary>
/// <param name="courant">Le compte courant</param>
/// <param name="epargne">Le compte épargne</param>
void EcrireTransactionsDansFichier(CompteCourant courant, CompteEpargne epargne)
{
    // Nom du fichier avec la date/heure pour éviter les écrasements
    string nomFichier = $"transactions_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

    // StreamWriter permet d'écrire ligne par ligne dans un fichier
    using (StreamWriter writer = new StreamWriter(nomFichier))
    {
        // -- En-tête du fichier --
        writer.WriteLine("========================================");
        writer.WriteLine("   HISTORIQUE DES TRANSACTIONS");
        writer.WriteLine($"   Généré le : {DateTime.Now:dd/MM/yyyy à HH:mm:ss}");
        writer.WriteLine("========================================");
        writer.WriteLine();

        // -- Transactions du compte courant --
        writer.WriteLine("--- COMPTE COURANT ---");
        writer.WriteLine($"Titulaire : {courant.NomTitulaire}");
        writer.WriteLine($"N° compte : {courant.NumeroCmpte}");
        writer.WriteLine($"Solde final : {courant.Solde} €");
        writer.WriteLine();

        if (courant.Transactions.Count == 0)
        {
            writer.WriteLine("Aucune transaction effectuée.");
        }
        else
        {
            // Boucle foreach pour parcourir la liste des transactions
            foreach (string transaction in courant.Transactions)
            {
                writer.WriteLine($"  • {transaction}");
            }
        }

        writer.WriteLine();

        // -- Transactions du compte épargne --
        writer.WriteLine("--- COMPTE ÉPARGNE ---");
        writer.WriteLine($"Titulaire : {epargne.NomTitulaire}");
        writer.WriteLine($"N° compte : {epargne.NumeroCmpte}");
        writer.WriteLine($"Solde final : {epargne.Solde} €");
        writer.WriteLine();

        if (epargne.Transactions.Count == 0)
        {
            writer.WriteLine("Aucune transaction effectuée.");
        }
        else
        {
            // Boucle foreach pour parcourir la liste des transactions
            foreach (string transaction in epargne.Transactions)
            {
                writer.WriteLine($"  • {transaction}");
            }
        }

        writer.WriteLine();
        writer.WriteLine("========================================");
        writer.WriteLine("   FIN DU RAPPORT");
        writer.WriteLine("========================================");
    }

    Console.WriteLine($"Fichier sauvegardé : {nomFichier}");
}


/*

---

## 📁 Récapitulatif de la structure finale
```
GestionnaireCompteBancaire /
│
├── CompteBancaire.cs    ← Classe abstraite de base (héritage)
├── CompteCourant.cs     ← Hérite de CompteBancaire
├── CompteEpargne.cs     ← Hérite de CompteBancaire
└── Program.cs           ← Menu + logique principale

*/