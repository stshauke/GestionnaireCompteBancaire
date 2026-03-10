# 🏦 Gestionnaire de Compte Bancaire

Application console développée en **C#** permettant de gérer un compte 
courant et un compte épargne de manière interactive.

---

##  Fonctionnalités

-  Afficher les informations du titulaire du compte
-  Consulter le solde du compte courant
-  Consulter le solde du compte épargne
-  Effectuer un dépôt sur le compte courant
-  Effectuer un dépôt sur le compte épargne
-  Effectuer un retrait sur le compte courant
-  Effectuer un retrait sur le compte épargne
-  Sauvegarde automatique des transactions dans un fichier `.txt` à la fermeture
-  Quitter l'application

---

##  Structure du projet
```
GestionnaireCompteBancaire/
│
├── CompteBancaire.cs   → Classe abstraite de base (héritage)
├── CompteCourant.cs    → Hérite de CompteBancaire
├── CompteEpargne.cs    → Hérite de CompteBancaire
└── Program.cs          → Menu interactif et logique principale
```

---

##  Notions C# utilisées

| Notion | Utilisation |
|---|---|
| **Héritage** | `CompteCourant` et `CompteEpargne` héritent de `CompteBancaire` |
| **Classe abstraite** | `CompteBancaire` ne peut pas être instanciée directement |
| **Constructeurs** | Initialisation des comptes avec `base(...)` |
| **Propriétés** | `Solde`, `NomTitulaire`, `NumeroCmpte` avec getters/setters |
| **Liste** | `List<string>` pour stocker l'historique des transactions |
| **Boucle** | `while` pour le menu, `foreach` pour écrire les transactions |
| **Fichier texte** | `StreamWriter` pour exporter les transactions |

---

##  Comment exécuter le projet

1. Clonez le dépôt :
```bash
   git clone https://github.com/stshauke/GestionnaireCompteBancaire.git
```
2. Ouvrez le fichier `.sln` dans **Visual Studio**
3. Appuyez sur **F5** pour lancer l'application
4. Appuyez sur **Entrée** pour afficher le menu

---

##  Exemple d'utilisation
```
Appuyez sur Entrée pour afficher le menu.

Veuillez sélectionner une option ci-dessous :
[I]  Voir les informations sur le titulaire du compte
[CS] Compte courant  - Consulter le solde
[CD] Compte courant  - Déposer des fonds
[CR] Compte courant  - Retirer des fonds
[ES] Compte épargne  - Consulter le solde
[ED] Compte épargne  - Déposer des fonds
[ER] Compte épargne  - Retirer des fonds
[X]  Quitter
> CD

Quel montant souhaitez-vous déposer ? 20
Vous avez déposé : 20 €.

Appuyez sur Entrée pour afficher le menu.
```

---

##  Technologies

- **Langage** : C#
- **Framework** : .NET 6.0+
- **IDE** : Visual Studio 2022

---

## 👤 Auteur

**Salomon TSHAUKE MULUMBA** — Projet réalisé dans le cadre d'un exercice de programmation C#.
