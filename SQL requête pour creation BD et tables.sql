-- TRAVAIL PRATIQUE -- Stéphane Potey et Juliana Elles

-- Création de la BD
USE master
GO
DROP DATABASE IF EXISTS GestionnaireContact
GO
CREATE DATABASE GestionnaireContact
GO

use GestionnaireContact
GO

-- Création de la table Contacts
DROP TABLE IF EXISTS Contacts
GO
CREATE TABLE Contacts (
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY CLUSTERED,
	nom VARCHAR(50) NOT NULL,
	prenom VARCHAR(50) NOT NULL,
	age INT NULL,
	telephone VARCHAR(10) NOT NULL,
	ville VARCHAR(50) NULL,
	loisirs VARCHAR(150) NULL
)
GO

-- Création de la table Gestionnaire
DROP TABLE IF EXISTS Gestionnaire
GO
CREATE TABLE Gestionnaire (
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY CLUSTERED,
	nom VARCHAR(50) NOT NULL,
	prenom VARCHAR(50) NOT NULL,
	email VARCHAR(150) NOT NULL,
	password VARCHAR(150) NOT NULL
)
GO

-- Création de la table Administrateur
DROP TABLE IF EXISTS Administrateur
GO
CREATE TABLE Administrateur (
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY CLUSTERED,
	nom VARCHAR(50) NOT NULL,
	prenom VARCHAR(50) NOT NULL,
	email VARCHAR(150) NOT NULL,
	password VARCHAR(150) NOT NULL
)
GO