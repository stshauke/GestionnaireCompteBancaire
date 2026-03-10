// ============================================================
// FICHIER : CompteCourant.cs
// RÔLE    : Représente un compte COURANT.
//           Hérite de CompteBancaire (mot-clé : )
// ============================================================

namespace GestionnaireCompteBancaire
{
    /// <summary>
    /// Classe CompteCourant — hérite de CompteBancaire.
    /// Le symbole ":" signifie "hérite de".
    /// CompteCourant récupère automatiquement toutes les propriétés
    /// et méthodes de CompteBancaire (Solde, Deposer, Retirer, etc.)
    /// </summary>
    public class CompteCourant : CompteBancaire
    {
        // --------------------------------------------------------
        // CONSTRUCTEUR
        // On appelle le constructeur parent avec "base(...)"
        // pour initialiser les propriétés héritées.
        // --------------------------------------------------------

        /// <summary>
        /// Crée un nouveau compte courant.
        /// </summary>
        /// <param name="nomTitulaire">Nom du titulaire</param>
        /// <param name="numeroCmpte">Numéro de compte</param>
        /// <param name="soldeInitial">Solde de départ</param>
        public CompteCourant(string nomTitulaire, string numeroCmpte, decimal soldeInitial)
            : base(nomTitulaire, numeroCmpte, soldeInitial)
        // ^ "base(...)" appelle le constructeur de CompteBancaire
        {
            // Rien de spécifique à initialiser pour l'instant
            // (on pourrait ajouter ici un découvert autorisé, par exemple)
        }

        /// <summary>
        /// Redéfinition de AfficherInfos() pour préciser le TYPE de compte.
        /// "override" signifie qu'on remplace la version de la classe parent.
        /// </summary>
        public override void AfficherInfos()
        {
            Console.WriteLine("--- Compte Courant ---");
            base.AfficherInfos(); // On appelle quand même la méthode parent
        }
    }
}