use GestionnaireContact
DROP TABLE IF EXISTS Administrateur
GO
CREATE TABLE Administrateur (
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY CLUSTERED,
	loginUtilisateur VARCHAR(50) NOT NULL,
	passwordUtilisateur VARCHAR(50) NOT NULL	
)