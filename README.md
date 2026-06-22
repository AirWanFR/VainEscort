# VainEscort

<div align="center">

![VainEscort Logo](logo_vainescort_rounded.png)

Une application de gestion d'escorte complète développée en C#

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE.txt)
![Language: C#](https://img.shields.io/badge/Language-C%23-239120)

</div>

## 📋 Description

VainEscort est une application Windows Forms (WinForms) conçue pour la gestion complète d'une entreprise d'escorte. Elle offre une interface conviviale et un système de gestion de données robuste basé sur une architecture en couches (BLL/DAL).

## ✨ Fonctionnalités Principales

### 👥 Gestion des Clients
- Création, lecture, modification et suppression de clients
- Gestion des informations clients complètes
- Interface dédiée pour la consultation des profils

### 💼 Gestion des Employés
- Gestion du personnel de l'entreprise
- Suivi des profils et informations des employés
- Interface de gestion intégrée

### 📦 Gestion du Catalogue
- Gestion des services disponibles
- Tarification et descriptions des prestations
- Interface de consultation et modification du catalogue

### 💵 Facturation
- Gestion des factures et paiements
- Suivi des transactions clients
- Génération de documents de facturation
- Historique des paiements

### 🎯 Gestion des Prestations
- Enregistrement des services fournis
- Suivi des prestations par client
- Gestion des détails des missions

### 🔧 Tableau de Bord
- Interface de gestion globale (Management)
- Vue d'ensemble des activités
- Navigation centralisée vers tous les modules

## 🏗️ Architecture

Le projet suit une architecture en trois couches :

```
┌─────────────────────────────────┐
│    Interface Utilisateur (UI)   │
│   Fic*.cs (Windows Forms)       │
├─────────────────────────────────┤
│   Couche Métier (BLL)           │
│   *BLL.cs (Business Logic)      │
├─────────────────────────────────┤
│   Couche Données (DAL)          │
│   *DAL.cs (Data Access)         │
└─────────────────────────────────┘
```

### 📂 Structure des Fichiers

- **UI/Formulaires** : `Home.cs`, `FicCatalogue.cs`, `FicClients.cs`, `FicEmployes.cs`, `FicFacturation.cs`, `FicPresta.cs`, `FicManagement.cs`
- **Couche Métier (BLL)** : `CatalogueBLL.cs`, `ClientBLL.cs`, `EmployesBLL.cs`, `FacturationBLL.cs`, `PrestaBLL.cs`, `ManagementBLL.cs`, `HomeBLL.cs`
- **Couche Données (DAL)** : `CatalogueDAL.cs`, `ClientDAL.cs`, `EmployesDAL.cs`, `FacturationDAL.cs`, `PrestaDAL.cs`, `ManagementDAL.cs`, `HomeDAL.cs`

## 🚀 Démarrage Rapide

### Prérequis

- .NET Framework ou .NET Core
- Visual Studio ou Visual Studio Code
- Une base de données configurée

### Installation

1. **Cloner le repository**
   ```bash
   git clone https://github.com/AirWanFR/VainEscort.git
   cd VainEscort
   ```

2. **Ouvrir le projet**
   ```bash
   # Ouvrir la solution Visual Studio
   start Projet_VainEscort.slnx
   ```

3. **Compiler et exécuter**
   - Appuyer sur `F5` pour lancer le projet
   - Ou utiliser la commande `dotnet run`

## 📝 Configuration

Avant de lancer l'application, assurez-vous que :
- La chaîne de connexion à la base de données est configurée
- Les fichiers de configuration nécessaires sont en place
- Les autorisations d'accès sont correctement définies

## 🔐 Licence

Ce projet est sous licence MIT. Consultez le fichier [LICENSE.txt](LICENSE.txt) pour plus de détails.

## 👨‍💻 Auteur

**AirWanFR** - [Profil GitHub](https://github.com/AirWanFR)

## 📞 Support et Contact

Pour toute question ou suggestion, veuillez :
- Ouvrir une [issue](https://github.com/AirWanFR/VainEscort/issues)
- Consulter les [discussions](https://github.com/AirWanFR/VainEscort/discussions)

---

<div align="center">

**Faites de la gestion d'entreprise une tâche simple et efficace avec VainEscort** ✨

</div>
