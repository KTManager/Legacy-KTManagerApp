ALTER TABLE Declinaisons
  ADD NbPsyConnus INTEGER DEFAULT (0) NOT NULL;
ALTER TABLE Declinaisons
  ADD NbPsyManifestes INTEGER DEFAULT (0) NOT NULL;
ALTER TABLE Declinaisons
  ADD NbPsyAbjures INTEGER DEFAULT (0) NOT NULL;
  

DROP TABLE IF EXISTS SurchargeCoutArme; 
CREATE TABLE "SurchargeCoutArme" (

    "Id" TEXT NOT NULL CONSTRAINT "PK_SurchargeCoutArme" PRIMARY KEY,

    "DeclinaisonId" TEXT NULL,

    "ArmeId" TEXT NULL,

    "Cout" INTEGER NOT NULL,

    CONSTRAINT "FK_SurchargeCoutArme_Declinaison_DeclinaisonId" FOREIGN KEY ("DeclinaisonId") REFERENCES "Declinaisons" ("Id") ON DELETE RESTRICT,

    CONSTRAINT "FK_SurchargeCoutArme_Arme_ArmeId" FOREIGN KEY ("ArmeId") REFERENCES "Armes" ("Id") ON DELETE RESTRICT

);

DROP TABLE IF EXISTS Psychiques; 
CREATE TABLE Psychiques (
    Id            TEXT    NOT NULL
                          CONSTRAINT PK_Psychiques PRIMARY KEY,
    DescriptionEn TEXT,
    DescriptionFr TEXT,
    DeclinaisonId TEXT,
    De        INTEGER NOT NULL,
    Charge        INTEGER NOT NULL,
    Commandant        INTEGER NOT NULL,
    NomEn         TEXT,
    NomFr         TEXT,
    CONSTRAINT FK_Psychiques_Declinaison_DeclinaisonId FOREIGN KEY (
        DeclinaisonId
    )
    REFERENCES Declinaisons (Id) ON DELETE RESTRICT
);

DROP TABLE IF EXISTS MembrePsychique;
CREATE TABLE "MembrePsychique" (

    "Id" TEXT NOT NULL CONSTRAINT "PK_MembrePsychique" PRIMARY KEY,

    "PsychiqueId" TEXT NULL,

    "MembreId" TEXT NULL,

    CONSTRAINT "FK_MembrePsychique_Psychiques_PsychiqueId" FOREIGN KEY ("PsychiqueId") REFERENCES "Psychiques" ("Id") ON DELETE RESTRICT,

    CONSTRAINT "FK_MembrePsychique_Membres_MembreId" FOREIGN KEY ("MembreId") REFERENCES "Membres" ("Id") ON DELETE RESTRICT

);
