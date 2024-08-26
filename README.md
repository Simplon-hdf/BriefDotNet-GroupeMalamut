![GitHub forks](https://img.shields.io/github/forks/Simplon-hdf/BriefDotNet-GroupeMalamut?style=for-the-badge)


# "Marche et Deviens" PoC

## **Table des Matières**


1. Introduction
2. Installation et Configuration
    1. Pré-requis
    2. Installation du projet
    3. Configuration
    4. Utilisation
3. Contributeurs
4. Technologies Utilisées
5. Fonctionnalités principales
6. Dépannage

## **Introduction**

"Marche et Deviens" est un projet de proof of concept (PoC) d’un projet visant à fédérer des équipes à travers des randonnées organisées.  

  
Le projet est divisé en deux parties principales : 
- Une API backend développée en C# / .NET
- Une application frontend développée en Angular.

## **Installation et Configuration**

### **Prérequis**

- Votre IDE favori (Visual Studio Code / Visual Studio / JetBrains Rider…etc)
- Node.js *(version utilisée : 20.16.0)*
- Npm *(version utilisée : 10.8.1)*
- .NET 8
- Angular 18
- Angular CLI

### **Installation du projet**

1. Clonez le repository dans votre Terminal : `git clone https://github.com/Simplon-hdf/BriefDotNet-GroupeMalamut.git`
2. Installez les dépendances pour le front-end dans votre Terminal : `npm install`
    
    
3. Installez les dépendances pour le back-end : `dotnet tool install`

### **Configuration**

Assurez-vous de configurer les fichiers `environment.ts` pour le front-end et `appsettings.json` pour le back-end avec les bonnes valeurs pour les URLs de l'API, les clés de sécurité, etc.

## **Utilisation**

Pour démarrer l'application : dans le Terminal de votre IDE, tapez `ng serve`

L'application sera accessible à l’adresse `http://localhost:4200`. 

## **Technologies Utilisées**

- **Frontend** : ![Angular](https://img.shields.io/badge/angular-%23DD0031.svg?style=for-the-badge&logo=angular&logoColor=white)
- **Backend** : ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
- **Base de Données** : ![MySQL](https://img.shields.io/badge/mysql-4479A1.svg?style=for-the-badge&logo=mysql&logoColor=white)
- **Authentification** : ![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)
- **Styling** : ![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)

- **Outils de Versionning :** ![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)






## **Fonctionnalités principales liées aux randonnées**

Une fois sur le site, l’utilisateur pourra :

1. **Consulter les Randonnées Disponibles** :
    - L'utilisateur pourra voir une liste de randonnées disponibles, y compris les détails tels que la date, le pays, la région, la commune de départ, le prix, la durée, et le nombre de participants.
2. **Participer à des Séjours Courts et Longs** :
    - L'utilisateur pourra choisir entre des séjours courts et longs, en fonction de ses préférences et de sa disponibilité *(Phase 2)*.
3. **Accéder à des informations détaillées** :
    - L'utilisateur pourra accéder à des informations détaillées sur chaque randonnée, y compris des descriptions et des images.
4. **Utiliser une Interface Intuitive** :
    - L'application fournira une interface utilisateur intuitive et facile à utiliser, permettant une navigation fluide et une expérience utilisateur agréable
5. **Offre personallisée** :
    - L'utilisateur pourra utiliser un formulaire de contact pour demander une offre sur-mesure *(Phase 2)*
### **Gestion des Randonnées**

- **Voir les Randonnées** : Accédez à la liste des randonnées disponibles via l'onglet "OffresRandonnées".
- **Ajouter une Randonnée** : Utilisez le formulaire pour ajouter une nouvelle randonnée avec des détails tels que le nom, la date, et la description.
- **Barre de Progression de Reservations** :
1) Affichage d'une barre montrant la
progression des réservations sur une offre. 
2) Ajout d'un code couleur pour indiquer quand le nombre minimun de réservation est atteint *(Phase 2)*.

### **Gestion des Utilisateurs**

- **Inscription** : Créer un compte utilisateur via le formulaire d'inscription.
- **Connexion** : Connecter un  compte pour accéder à des fonctionnalités personnalisées.
- **Administrateur :** Assigner un compte Admin
- **Profil Utilisateur** : Consulter et modifier les informations personnelles dans la section "Profil" *(Phase 2)*.

### **Authentification**

- **Connexion** : Utilisez votre email et mot de passe pour vous connecter.
- **Changer le Mot de Passe** : Accédez à la section "Changer le mot de passe" pour mettre à jour votre mot de passe *(à venir…)*.

## **Dépannage**

### **Problèmes Courants**

- **Problèmes de Connexion** : 
1) Assurez-vous que votre email et mot de passe sont corrects. 
2) Si vous avez oublié votre mot de passe, changez-le *(à venir…)*.
- **API Inaccessible** : Vérifiez que le back-end est bien démarré et accessible à l'URL correcte.

### **Logs et Erreurs**

- **Frontend** : Les erreurs du front-end sont affichées dans la console du navigateur.
- **Backend** : Les erreurs du back-end sont loguées dans la console où l'API est démarrée.


## Author

- [Shanaz](https://github.com/MikkoPet)
- [Nicolas](https://github.com/Nicolas-Puchois)
- [Gabriel](https://github.com/gabrielluthun)
- [Fatima](https://github.com/fat5B)
