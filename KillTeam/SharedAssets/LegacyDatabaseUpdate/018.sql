CREATE TABLE Phases (
    Id    TEXT PRIMARY KEY,
    NomEn TEXT,
    NomFr TEXT,
    NomDe TEXT
);
INSERT INTO Phases (
                       NomDe,
                       NomFr,
                       NomEn,
                       Id
                   )
                   VALUES (
                       'FernUndNahkampfphase',
                       'Tir & combat',
                       'Shooting & fight',
                       7
                   ),
                   (
                       'Moralphase',
                       'Moral',
                       'Morale',
                       6
                   ),
                   (
                       'Nahkampfphase',
                       'Combat',
                       'Fight',
                       5
                   ),
                   (
                       'Fernkampfphase',
                       'Tir',
                       'Shooting',
                       4
                   ),
                   (
                       'Psiphase',
                       'Psychique',
                       'Psychic',
                       3
                   ),
                   (
                       'Bewegungsphase',
                       'Mouvement',
                       'Movement',
                       2
                   ),
                   (
                       'Initiativephase',
                       'Initiative',
                       'Initiative',
                       1
                   );



ALTER TABLE Tactiques
  ADD PhaseId TEXT REFERENCES Phases (Id) ON DELETE RESTRICT;

update tactiques set PhaseId = '5' where id ='AA1';
update tactiques set PhaseId = '2' where id ='AA6';
update tactiques set PhaseId = '4' where id ='AA5';
update tactiques set PhaseId = '4' where id ='AA4';
update tactiques set PhaseId = NULL where Id ='AA3';
update tactiques set PhaseId = '5' where id ='AA2';
update tactiques set PhaseId = '4' where id ='DW1';
update tactiques set PhaseId = '7' where id ='DW2';
update tactiques set PhaseId = '7' where id ='DW3';
update tactiques set PhaseId = '7' where id ='DW4';
update tactiques set PhaseId = '2' where id ='ALL1';
update tactiques set PhaseId = '4' where id ='ALL2';
update tactiques set PhaseId = '5' where id ='ALL3';
update tactiques set PhaseId = '6' where id ='ALL4';
update tactiques set PhaseId = NULL where Id ='ALL5';
update tactiques set PhaseId = '7' where id ='ALL6';
update tactiques set PhaseId = '5' where id ='L1';
update tactiques set PhaseId = '4' where id ='GK1';
update tactiques set PhaseId = '5' where id ='GK2';
update tactiques set PhaseId = '1' where id ='GK3';
update tactiques set PhaseId = '3' where id ='GK4';
update tactiques set PhaseId = NULL where Id ='AM2';
update tactiques set PhaseId = '2' where id ='AM1';
update tactiques set PhaseId = '4' where id ='AM3';
update tactiques set PhaseId = '6' where id ='AM4';
update tactiques set PhaseId = '5' where id ='ME1';
update tactiques set PhaseId = '4' where id ='ME2';
update tactiques set PhaseId = '2' where id ='ME3';
update tactiques set PhaseId = '1' where id ='ME4';
update tactiques set PhaseId = '7' where id ='HA1';
update tactiques set PhaseId = '5' where id ='HA2';
update tactiques set PhaseId = '2' where id ='HA3';
update tactiques set PhaseId = '1' where id ='HA4';
update tactiques set PhaseId = '5' where id ='DG1';
update tactiques set PhaseId = '2' where id ='DG2';
update tactiques set PhaseId = '7' where id ='DG3';
update tactiques set PhaseId = '1' where id ='DG4';
update tactiques set PhaseId = '2' where id ='DG5';
update tactiques set PhaseId = '5' where id ='DG6';
update tactiques set PhaseId = '3' where id ='TS1';
update tactiques set PhaseId = NULL where Id ='TS2';
update tactiques set PhaseId = '7' where id ='TS3';
update tactiques set PhaseId = '5' where id ='TS4';
update tactiques set PhaseId = '2' where id ='TS5';
update tactiques set PhaseId = '4' where id ='TS6';
update tactiques set PhaseId = '2' where id ='AS1';
update tactiques set PhaseId = '2' where id ='AS2';
update tactiques set PhaseId = '1' where id ='AS3';
update tactiques set PhaseId = '4' where id ='AS4';
update tactiques set PhaseId = '4' where id ='AS5';
update tactiques set PhaseId = NULL where Id ='AS6';
update tactiques set PhaseId = '4' where id ='DR1';
update tactiques set PhaseId = '2' where id ='DR2';
update tactiques set PhaseId = '5' where id ='DR3';
update tactiques set PhaseId = '4' where id ='DR4';
update tactiques set PhaseId = '2' where id ='AR1';
update tactiques set PhaseId = '2' where id ='AR2';
update tactiques set PhaseId = '2' where id ='AR3';
update tactiques set PhaseId = '5' where id ='AR4';
update tactiques set PhaseId = '4' where id ='AR5';
update tactiques set PhaseId = '5' where id ='AR6';
update tactiques set PhaseId = NULL where Id ='NE1';
update tactiques set PhaseId = '5' where id ='NE2';
update tactiques set PhaseId = '4' where id ='NE3';
update tactiques set PhaseId = '4' where id ='NE4';
update tactiques set PhaseId = '5' where id ='NE5';
update tactiques set PhaseId = '4' where id ='NE6';
update tactiques set PhaseId = '5' where id ='OR2';
update tactiques set PhaseId = '5' where id ='OR1';
update tactiques set PhaseId = '4' where id ='OR3';
update tactiques set PhaseId = NULL where Id ='OR4';
update tactiques set PhaseId = '4' where id ='OR5';
update tactiques set PhaseId = '4' where id ='OR6';
update tactiques set PhaseId = '4' where id ='TA1';
update tactiques set PhaseId = '4' where id ='TA2';
update tactiques set PhaseId = '4' where id ='TA3';
update tactiques set PhaseId = NULL where Id ='TA4';
update tactiques set PhaseId = '5' where id ='TY1';
update tactiques set PhaseId = '4' where id ='TY3';
update tactiques set PhaseId = '5' where id ='TY2';
update tactiques set PhaseId = '2' where id ='TY4';
update tactiques set PhaseId = '2' where id ='TY5';
update tactiques set PhaseId = '2' where id ='TY6';
update tactiques set PhaseId = '5' where id ='GC1';
update tactiques set PhaseId = NULL where Id ='GC2';
update tactiques set PhaseId = '2' where id ='GC3';
update tactiques set PhaseId = '5' where id ='GC4';
update tactiques set PhaseId = '4' where id ='GC5';
update tactiques set PhaseId = '3' where id ='GC6';
update tactiques set PhaseId = '4' where id ='L2';
update tactiques set PhaseId = '1' where id ='L3';
update tactiques set PhaseId = '5' where id ='CB1';
update tactiques set PhaseId = '5' where id ='CB2';
update tactiques set PhaseId = '2' where id ='CB3';
update tactiques set PhaseId = '2' where id ='CO3';
update tactiques set PhaseId = '4' where id ='CO2';
update tactiques set PhaseId = '6' where id ='CO1';
update tactiques set PhaseId = '4' where id ='D3';
update tactiques set PhaseId = '4' where id ='D2';
update tactiques set PhaseId = '4' where id ='D1';
update tactiques set PhaseId = '6' where id ='AL3';
update tactiques set PhaseId = '4' where id ='AL2';
update tactiques set PhaseId = '4' where id ='AL1';
update tactiques set PhaseId = NULL where Id ='M3';
update tactiques set PhaseId = '2' where id ='M2';
update tactiques set PhaseId = '2' where id ='M1';
update tactiques set PhaseId = '2' where id ='SC3';
update tactiques set PhaseId = '4' where id ='SC2';
update tactiques set PhaseId = '2' where id ='SC1';
update tactiques set PhaseId = '4' where id ='SN3';
update tactiques set PhaseId = '4' where id ='SN2';
update tactiques set PhaseId = '4' where id ='SN1';
update tactiques set PhaseId = '4' where id ='V3';
update tactiques set PhaseId = '4' where id ='V2';
update tactiques set PhaseId = '1' where id ='V1';
update tactiques set PhaseId = '6' where id ='Z3';
update tactiques set PhaseId = NULL where Id ='Z2';
update tactiques set PhaseId = '5' where id ='Z1';
update tactiques set PhaseId = NULL where Id ='ST3';
update tactiques set PhaseId = NULL where Id ='ST2';
update tactiques set PhaseId = '1' where id ='ST1';
update tactiques set PhaseId = NULL where Id ='F3';
update tactiques set PhaseId = '5' where id ='F2';
update tactiques set PhaseId = '2' where id ='F1';
update tactiques set PhaseId = '5' where id ='ES6';
update tactiques set PhaseId = '4' where id ='ES5';
update tactiques set PhaseId = '2' where id ='ES4';
update tactiques set PhaseId = '4' where id ='ES3';
update tactiques set PhaseId = '2' where id ='ES2';
update tactiques set PhaseId = NULL where Id ='ES1';
update tactiques set PhaseId = '2' where id ='GI6';
update tactiques set PhaseId = '2' where id ='GI5';
update tactiques set PhaseId = '2' where id ='GI4';
update tactiques set PhaseId = '4' where id ='GI3';
update tactiques set PhaseId = '2' where id ='GI2';
update tactiques set PhaseId = '5' where id ='GI1';
update tactiques set PhaseId = '2' where id ='ESE1';
update tactiques set PhaseId = '5' where id ='ESE2';
update tactiques set PhaseId = '3' where id ='GIV1';
update tactiques set PhaseId = '2' where id ='GIV2';
update tactiques set PhaseId = '5' where id ='COM3';
update tactiques set PhaseId = '2' where id ='COM2';
update tactiques set PhaseId = NULL where Id ='COM1';
update tactiques set PhaseId = '5' where id ='FULS';
update tactiques set PhaseId = '2' where id ='MDL';
update tactiques set PhaseId = '6' where id ='BOW';
update tactiques set PhaseId = NULL where Id ='RTF';
update tactiques set PhaseId = '6' where id ='IJAS';
update tactiques set PhaseId = NULL where Id ='PIFTW';
update tactiques set PhaseId = '6' where id ='IO';
update tactiques set PhaseId = '4' where id ='BTD';
update tactiques set PhaseId = '1' where id ='SIC';
update tactiques set PhaseId = '1' where id ='RF';
update tactiques set PhaseId = '4' where id ='APA';
update tactiques set PhaseId = '1' where id ='GVC';
update tactiques set PhaseId = '5' where id ='FSY';
update tactiques set PhaseId = '5' where id ='HMK';
update tactiques set PhaseId = '5' where id ='SB';
update tactiques set PhaseId = '3' where id ='PB';
update tactiques set PhaseId = '3' where id ='LM';
update tactiques set PhaseId = '3' where id ='MF';
update tactiques set PhaseId = '4' where id ='IS';
update tactiques set PhaseId = '4' where id ='LH';
update tactiques set PhaseId = '4' where id ='ITF';
update tactiques set PhaseId = '5' where id ='BSB2';
update tactiques set PhaseId = '4' where id ='DFC';
update tactiques set PhaseId = '1' where id ='HD';
update tactiques set PhaseId = '4' where id ='AAC';
update tactiques set PhaseId = '4' where id ='AAL';
update tactiques set PhaseId = '2' where id ='AAH2';
update tactiques set PhaseId = '4' where id ='DWW';
update tactiques set PhaseId = '2' where id ='AMC1';
update tactiques set PhaseId = '2' where id ='AMC2';
update tactiques set PhaseId = '4' where id ='AMP1';
update tactiques set PhaseId = '4' where id ='AMP2';
update tactiques set PhaseId = '2' where id ='AMT';
update tactiques set PhaseId = '2' where id ='MET';
update tactiques set PhaseId = '4' where id ='MED';
update tactiques set PhaseId = '4' where id ='HAE';
update tactiques set PhaseId = '5' where id ='DGF';
update tactiques set PhaseId = '5' where id ='DGT';
update tactiques set PhaseId = '5' where id ='DGB';
update tactiques set PhaseId = '5' where id ='DGPS';
update tactiques set PhaseId = '1' where id ='ASA';
update tactiques set PhaseId = '4' where id ='DRA';
update tactiques set PhaseId = '5' where id ='DRS';
update tactiques set PhaseId = '2' where id ='DRH';
update tactiques set PhaseId = '5' where id ='ART';
update tactiques set PhaseId = '4' where id ='ARD';
update tactiques set PhaseId = '1' where id ='NEO';
update tactiques set PhaseId = '1' where id ='NEY';
update tactiques set PhaseId = '1' where id ='ORW';
update tactiques set PhaseId = '1' where id ='ORBM';
update tactiques set PhaseId = '1' where id ='ORP';
update tactiques set PhaseId = '1' where id ='TAC';
update tactiques set PhaseId = '2' where id ='TAE';
update tactiques set PhaseId = '4' where id ='TYTP';
update tactiques set PhaseId = '2' where id ='GCP';
update tactiques set PhaseId = '2' where id ='GCA';
update tactiques set PhaseId = '5' where id ='AAH';
update tactiques set PhaseId = '6' where id ='NEO2';
update tactiques set PhaseId = '1' where id ='NEY2';
update tactiques set PhaseId = '4' where id ='TAE2';
update tactiques set PhaseId = '2' where id ='TAE3';
update tactiques set PhaseId = '2' where id ='TAE4';
update tactiques set PhaseId = '1' where id ='GCP2';
update tactiques set PhaseId = '4' where id ='AACDW';
update tactiques set PhaseId = '2' where id ='AAHDW2';
update tactiques set PhaseId = '5' where id ='AAHDW';
update tactiques set PhaseId = NULL where Id ='DW10';
update tactiques set PhaseId = '4' where id ='DW9';
update tactiques set PhaseId = '5' where id ='DW8';
update tactiques set PhaseId = '2' where id ='DW7';
update tactiques set PhaseId = '5' where id ='DW6';
update tactiques set PhaseId = '5' where id ='DW5';
update tactiques set PhaseId = '6' where id ='AA12';
update tactiques set PhaseId = '4' where id ='AA11';
update tactiques set PhaseId = '5' where id ='AA10';
update tactiques set PhaseId = '6' where id ='AA9';
update tactiques set PhaseId = NULL where Id ='AA8';
update tactiques set PhaseId = NULL where Id ='AA7';
update tactiques set PhaseId = '4' where id ='AM10';
update tactiques set PhaseId = NULL where Id ='AM9';
update tactiques set PhaseId = NULL where Id ='AM8';
update tactiques set PhaseId = '4' where id ='AM7';
update tactiques set PhaseId = '1' where id ='AM6';
update tactiques set PhaseId = NULL where Id ='AM5';
update tactiques set PhaseId = '5' where id ='ME9';
update tactiques set PhaseId = NULL where Id ='ME8';
update tactiques set PhaseId = '2' where id ='ME7';
update tactiques set PhaseId = '2' where id ='ME6';
update tactiques set PhaseId = '2' where id ='ME5';
update tactiques set PhaseId = '5' where id ='DR5';
update tactiques set PhaseId = '4' where id ='DR6';
update tactiques set PhaseId = '1' where id ='DR7';
update tactiques set PhaseId = '7' where id ='DR8';
update tactiques set PhaseId = '1' where id ='DR9';
update tactiques set PhaseId = '5' where id ='DR10';
update tactiques set PhaseId = NULL where Id ='OR7';
update tactiques set PhaseId = '2' where id ='OR8';
update tactiques set PhaseId = '4' where id ='OR9';
update tactiques set PhaseId = '2' where id ='OR10';
update tactiques set PhaseId = '2' where id ='OR11';
update tactiques set PhaseId = '5' where id ='OR12';
update tactiques set PhaseId = '2' where id ='TY7';
update tactiques set PhaseId = '5' where id ='TY8';
update tactiques set PhaseId = '4' where id ='TY9';
update tactiques set PhaseId = '5' where id ='TY10';
update tactiques set PhaseId = NULL where Id ='TY11';
update tactiques set PhaseId = '5' where id ='TY12';
update tactiques set PhaseId = '5' where id ='GC7';
update tactiques set PhaseId = '4' where id ='GC8';
update tactiques set PhaseId = '5' where id ='GC9';
update tactiques set PhaseId = '5' where id ='GC10';
update tactiques set PhaseId = '4' where id ='GC11';
update tactiques set PhaseId = '4' where id ='GC12';
