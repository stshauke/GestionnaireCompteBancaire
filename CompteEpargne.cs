// ============================================================
// FICHIER : CompteEpargne.cs
// RÔLE    : Représente un compte ÉPARGNE.
//           Hérite de CompteBancaire, exactement comme CompteCourant.
// ============================================================

namespace GestionnaireCompteBancaire
{
    /// <summary>
    /// Classe CompteEpargne — hérite de CompteBancaire.
    /// Identique dans sa structure à CompteCourant,
    /// mais représente un type de compte différent.
    /// </summary>
    public class CompteEpargne : CompteBancaire
    {
        // --------------------------------------------------------
        // CONSTRUCTEUR
        // --------------------------------------------------------

        /// <summary>
        /// Crée un nouveau compte épargne.
        /// </summary>
        /// <param name="nomTitulaire">Nom du titulaire</param>
        /// <param name="numeroCmpte">Numéro de compte</param>
        /// <param name="soldeInitial">Solde de départ</param>
        public CompteEpargne(string nomTitulaire, string numeroCmpte, decimal soldeInitial)
            : base(nomTitulaire, numeroCmpte, soldeInitial)
        // ^ On transmet les paramètres au constructeur de CompteBancaire
        {
            // (On pourrait ajouter ici un taux d'intérêt, par exemple)
        }

        /// <summary>
        /// Redéfinition de AfficherInfos() pour préciser le TYPE de compte.
        /// </summary>
        public override void AfficherInfos()
        {
            Console.WriteLine("--- Compte Épargne ---");
            base.AfficherInfos(); // Appel de la méthode parent
        }
    }
}