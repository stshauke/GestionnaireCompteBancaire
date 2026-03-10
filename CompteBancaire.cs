// ============================================================
// FICHIER : CompteBancaire.cs
// RÔLE    : Classe de BASE dont hériteront les deux types de comptes.
//           Elle contient les propriétés et comportements communs.
// ============================================================

using System;
using System.Collections.Generic;

namespace GestionnaireCompteBancaire
{
    /// <summary>
    /// Classe abstraite représentant un compte bancaire générique.
    /// "abstract" signifie qu'on ne peut pas créer directement un objet
    /// de cette classe — elle sert uniquement de modèle pour les sous-classes.
    /// </summary>
    public abstract class CompteBancaire
    {
        // --------------------------------------------------------
        // PROPRIÉTÉS (données que chaque compte possède)
        // --------------------------------------------------------

        /// <summary>Nom complet du titulaire du compte.</summary>
        public string NomTitulaire { get; private set; }

        /// <summary>Numéro unique du compte bancaire.</summary>
        public string NumeroCmpte { get; private set; }

        /// <summary>
        /// Solde actuel du compte.
        /// "protected set" = seule cette classe (et ses enfants) peuvent modifier le solde.
        /// De l'extérieur, on ne peut que LIRE le solde.
        /// </summary>
        public decimal Solde { get; protected set; }

        /// <summary>
        /// Liste qui stocke l'historique de toutes les transactions.
        /// Chaque transaction est une chaîne de texte (ex: "Dépôt : 50 €").
        /// </summary>
        public List<string> Transactions { get; private set; }

        // --------------------------------------------------------
        // CONSTRUCTEUR
        // Le constructeur est appelé lors de la création d'un objet.
        // Il initialise les propriétés de base.
        // --------------------------------------------------------

        /// <summary>
        /// Constructeur de la classe de base.
        /// Les sous-classes appellent ce constructeur via "base(...)".
        /// </summary>
        /// <param name="nomTitulaire">Nom du propriétaire du compte</param>
        /// <param name="numeroCmpte">Numéro d'identification du compte</param>
        /// <param name="soldeInitial">Montant de départ sur le compte</param>
        public CompteBancaire(string nomTitulaire, string numeroCmpte, decimal soldeInitial)
        {
            NomTitulaire = nomTitulaire;
            NumeroCmpte = numeroCmpte;
            Solde = soldeInitial;
            Transactions = new List<string>(); // On initialise la liste vide
        }

        // --------------------------------------------------------
        // MÉTHODES COMMUNES (partagées par tous les types de comptes)
        // --------------------------------------------------------

        /// <summary>
        /// Effectue un dépôt sur le compte.
        /// </summary>
        /// <param name="montant">Montant à déposer (doit être positif)</param>
        public void Deposer(decimal montant)
        {
            // Vérification : on ne peut pas déposer un montant négatif ou nul
            if (montant <= 0)
            {
                Console.WriteLine("Le montant doit être supérieur à zéro.");
                return; // On arrête la méthode ici
            }

            Solde += montant; // On ajoute le montant au solde

            // On enregistre la transaction dans la liste
            string transaction = $"Dépôt : {montant} €  |  Nouveau solde : {Solde} €";
            Transactions.Add(transaction);

            Console.WriteLine($"Vous avez déposé : {montant} €.");
        }

        /// <summary>
        /// Effectue un retrait sur le compte.
        /// </summary>
        /// <param name="montant">Montant à retirer (doit être positif et <= solde)</param>
        public void Retirer(decimal montant)
        {
            // Vérification : montant valide
            if (montant <= 0)
            {
                Console.WriteLine("Le montant doit être supérieur à zéro.");
                return;
            }

            // Vérification : fonds suffisants
            if (montant > Solde)
            {
                Console.WriteLine("Fonds insuffisants pour effectuer ce retrait.");
                return;
            }

            Solde -= montant; // On soustrait le montant du solde

            // On enregistre la transaction dans la liste
            string transaction = $"Retrait : {montant} €  |  Nouveau solde : {Solde} €";
            Transactions.Add(transaction);

            Console.WriteLine($"Vous avez retiré : {montant} €.");
        }

        /// <summary>
        /// Affiche les informations du titulaire et le solde du compte.
        /// "virtual" permet aux sous-classes de redéfinir cette méthode si nécessaire.
        /// </summary>
        public virtual void AfficherInfos()
        {
            Console.WriteLine($"Titulaire     : {NomTitulaire}");
            Console.WriteLine($"N° de compte  : {NumeroCmpte}");
            Console.WriteLine($"Solde actuel  : {Solde} €");
        }
    }
}