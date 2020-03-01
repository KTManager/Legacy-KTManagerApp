
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table : MembreArme
CREATE TABLE IF NOT EXISTS "MembrePouvoir" (

    "Id" TEXT NOT NULL CONSTRAINT "PK_MembrePouvoir" PRIMARY KEY,

    "PouvoirId" TEXT NULL,

    "MembreId" TEXT NULL,

    CONSTRAINT "FK_MembrePouvoir_Pouvoirs_PouvoirId" FOREIGN KEY ("PouvoirId") REFERENCES "Pouvoirs" ("Id") ON DELETE RESTRICT,

    CONSTRAINT "FK_MembreArme_Membres_MembreId" FOREIGN KEY ("MembreId") REFERENCES "Membres" ("Id") ON DELETE RESTRICT

);


ALTER TABLE Equipes
  ADD Roster INTEGER DEFAULT (0) NOT NULL;

ALTER TABLE Membres
  ADD XP INTEGER DEFAULT (0) NOT NULL;
ALTER TABLE Membres
  ADD Blessures INTEGER DEFAULT (0) NOT NULL;
ALTER TABLE Membres
  ADD Convalescence INTEGER DEFAULT (0) NOT NULL;
ALTER TABLE Membres
  ADD Recrue INTEGER DEFAULT (0) NOT NULL;
ALTER TABLE Membres
  ADD Selected INTEGER DEFAULT (0) NOT NULL;

COMMIT TRANSACTION;

PRAGMA foreign_keys = on;
