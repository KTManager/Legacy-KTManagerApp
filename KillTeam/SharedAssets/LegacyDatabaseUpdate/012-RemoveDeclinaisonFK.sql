PRAGMA foreign_keys = 0;

CREATE TABLE sqlitestudio_temp_table0 AS SELECT *
                                           FROM Tactiques;

DROP TABLE Tactiques;

CREATE TABLE Tactiques (
    Id            TEXT    NOT NULL
                          CONSTRAINT PK_Tactiques PRIMARY KEY,
    DescriptionEn TEXT,
    DescriptionFr TEXT,
    DescriptionDe TEXT,
    FactionId     TEXT,
    Niveau        INTEGER NOT NULL,
    NomEn         TEXT,
    NomFr         TEXT,
    NomDe         TEXT,
    Point         INTEGER NOT NULL,
    SpecialiteId  TEXT,
    DeclinaisonId TEXT,
    Aura          INTEGER DEFAULT (0) 
                          NOT NULL,
    Commandant    INTEGER DEFAULT (0) 
                          NOT NULL,
    CONSTRAINT FK_Tactiques_Factions_FactionId FOREIGN KEY (
        FactionId
    )
    REFERENCES Factions (Id) ON DELETE RESTRICT,
    CONSTRAINT FK_Tactiques_Specialites_SpecialiteId FOREIGN KEY (
        SpecialiteId
    )
    REFERENCES Specialites (Id) ON DELETE RESTRICT,
    CONSTRAINT FK_Tactiques_Declinaisons_DeclinaisonId FOREIGN KEY (
        DeclinaisonId
    )
    REFERENCES Declinaisons (Id) ON DELETE RESTRICT
);

INSERT INTO Tactiques (
                          Id,
                          DescriptionEn,
                          DescriptionFr,
                          FactionId,
                          Niveau,
                          NomEn,
                          NomFr,
                          Point,
                          SpecialiteId,
                          DeclinaisonId,
                          Aura,
                          Commandant
                      )
                      SELECT Id,
                             DescriptionEn,
                             DescriptionFr,
                             FactionId,
                             Niveau,
                             NomEn,
                             NomFr,
                             Point,
                             SpecialiteId,
                             DeclinaisonId,
                             Aura,
                             Commandant
                        FROM sqlitestudio_temp_table0;

DROP TABLE sqlitestudio_temp_table0;

CREATE INDEX IX_Tactiques_FactionId ON Tactiques (
    "FactionId"
);

CREATE INDEX IX_Tactiques_SpecialiteId ON Tactiques (
    "SpecialiteId"
);
CREATE INDEX IX_Tactiques_DeclinaisonId ON Tactiques (
    "DeclinaisonId"
);

PRAGMA foreign_keys = 1;
