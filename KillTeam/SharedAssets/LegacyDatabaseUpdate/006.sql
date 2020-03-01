   
DROP TABLE IF EXISTS Traits; 
CREATE TABLE "Traits" (

    "Id" TEXT NOT NULL CONSTRAINT "PK_Traits" PRIMARY KEY,

    "DescriptionEn" TEXT NULL,

    "DescriptionFr" TEXT NULL,

    "DescriptionDe" TEXT NULL,

    "DeclinaisonId" TEXT NULL,
	
    "Niveau" INTEGER NOT NULL,

    "NomEn" TEXT NULL,
	
    "NomFr" TEXT NULL,

    "NomDe" TEXT NULL,

    "Point" INTEGER NOT NULL,

    CONSTRAINT "FK_Tactiques_Declinaison_DeclinaisonId" FOREIGN KEY ("DeclinaisonId") REFERENCES "Declinaisons" ("Id") ON DELETE RESTRICT

);

DROP TABLE IF EXISTS MembreTrait; 
CREATE TABLE "MembreTrait" (

    "Id" TEXT NOT NULL CONSTRAINT "PK_MembreTrait" PRIMARY KEY,

    "TraitId" TEXT NULL,

    "MembreId" TEXT NULL,

    CONSTRAINT "FK_MembreTrait_Traits_TraitId" FOREIGN KEY ("TraitId") REFERENCES "Traits" ("Id") ON DELETE RESTRICT,

    CONSTRAINT "FK_MembreTrait_Membres_MembreId" FOREIGN KEY ("MembreId") REFERENCES "Membres" ("Id") ON DELETE RESTRICT

);

DROP TABLE IF EXISTS CoutNiveau; 
CREATE TABLE "CoutNiveau" (

    "Id" TEXT NOT NULL CONSTRAINT "PK_CoutNiveau" PRIMARY KEY,

    "DeclinaisonId" TEXT NULL,
	
    "Niveau" INTEGER NOT NULL,

    "Cout" INTEGER NOT NULL,

    CONSTRAINT "FK_CoutNiveau_Declinaisons_DeclinaisonId" FOREIGN KEY ("DeclinaisonId") REFERENCES "Declinaisons" ("Id") ON DELETE RESTRICT

);

DROP TABLE IF EXISTS SurchargeCoutArme; 
CREATE TABLE "SurchargeCoutArme" (

    "Id" TEXT NOT NULL CONSTRAINT "PK_SurchargeCoutArme" PRIMARY KEY,

    "DeclinaisonId" TEXT NULL,

    "ArmeId" TEXT NULL,

    "Cout" INTEGER NOT NULL,

    CONSTRAINT "FK_SurchargeCoutArme_Declinaison_DeclinaisonId" FOREIGN KEY ("DeclinaisonId") REFERENCES "Declinaisons" ("Id") ON DELETE RESTRICT,

    CONSTRAINT "FK_SurchargeCoutArme_Arme_ArmeId" FOREIGN KEY ("ArmeId") REFERENCES "Armes" ("Id") ON DELETE RESTRICT

);


ALTER TABLE Tactiques
  ADD DeclinaisonId TEXT REFERENCES Declinaisons (Id) ON DELETE RESTRICT
    CONSTRAINT FK_Tactiques_Declinaisons_DeclinaisonId references Declinaisons ( DeclinaisonId );
	     
ALTER TABLE Tactiques
  ADD Aura INTEGER DEFAULT (0) NOT NULL;

ALTER TABLE Tactiques
  ADD Commandant INTEGER DEFAULT (0) NOT NULL;
  
ALTER TABLE Declinaisons
  ADD Commandant INTEGER DEFAULT (0) NOT NULL;

-- Changement Nb Attaque en string

CREATE TABLE sqlitestudio_temp_table AS SELECT *
                                          FROM Declinaisons;

DROP TABLE Declinaisons;

CREATE TABLE Declinaisons (
    Id         TEXT    NOT NULL
                       CONSTRAINT PK_Declinaisons PRIMARY KEY,
    A          TEXT    NOT NULL,
    CC         INTEGER NOT NULL,
    CT         INTEGER NOT NULL,
    Cd         INTEGER NOT NULL,
    E          INTEGER NOT NULL,
    F          INTEGER NOT NULL,
    FigurineId TEXT,
    M          INTEGER NOT NULL,
    Max        INTEGER NOT NULL,
    NomEn      TEXT,
    NomFr      TEXT,
    PV         INTEGER NOT NULL,
    Sv         INTEGER NOT NULL,
    cout       INTEGER NOT NULL,
    Commandant INTEGER DEFAULT (0) 
                       NOT NULL,
    CONSTRAINT FK_Declinaisons_Figurines_FigurineId FOREIGN KEY (
        FigurineId
    )
    REFERENCES Figurines (Id) ON DELETE RESTRICT
);

INSERT INTO Declinaisons (
                             Id,
                             A,
                             CC,
                             CT,
                             Cd,
                             E,
                             F,
                             FigurineId,
                             M,
                             Max,
                             NomEn,
                             NomFr,
                             PV,
                             Sv,
                             cout,
                             Commandant
                         )
                         SELECT Id,
                                A,
                                CC,
                                CT,
                                Cd,
                                E,
                                F,
                                FigurineId,
                                M,
                                Max,
                                NomEn,
                                NomFr,
                                PV,
                                Sv,
                                cout,
                                Commandant
                           FROM sqlitestudio_temp_table;

DROP TABLE sqlitestudio_temp_table;

CREATE INDEX IX_Declinaisons_FigurineId ON Declinaisons (
    "FigurineId"
);