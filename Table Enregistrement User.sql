use GestionnaireContact
DROP TABLE IF EXISTS Enregistrement
GO
CREATE TABLE Enregistrement (
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY CLUSTERED,
	nom VARCHAR(50) NOT NULL,
	prenom VARCHAR(50) NOT NULL,
	email VARCHAR(150) NOT NULL,
	password VARCHAR(150) NOT NULL
)