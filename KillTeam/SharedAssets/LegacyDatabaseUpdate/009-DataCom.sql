
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

update Aptitudes set FactionId = 'GK', FigurineId = NULL where Id = 'RBA';
update Aptitudes set FactionId = 'GK', FigurineId = NULL where Id = 'CHD';
update Aptitudes set FactionId = NULL, FigurineId = 'GK' where Id = 'PTR3';

update Armes set DescriptionAdditionnelleEn='When attacking with this weapon, choose one of the profiles below.', DescriptionAdditionnelleFr = 'Lorsque vous attaquez avec cette arme, choisissez un des profils ci-dessous' where Id = 'CPL';
update ProfileArmes set NbTir = 2 where id = 'CPL1';
update ProfileArmes set NbTir = 2 where id = 'CPL2';
update Declinaisons set A = 2, Cd = 7 where Id = 'TAB2';

update Declinaisons set NbPsyConnus = 0, NbPsyManifestes = 1, NbPsyAbjures = 1  where Id = 'GK1';
update Declinaisons set NbPsyConnus = 0, NbPsyManifestes = 1, NbPsyAbjures = 1  where Id = 'GK2';
update Declinaisons set NbPsyConnus = 0, NbPsyManifestes = 1, NbPsyAbjures = 1  where Id = 'GK3';
update Declinaisons set NbPsyConnus = 0, NbPsyManifestes = 1, NbPsyAbjures = 1  where Id = 'TSM3';


update Declinaisons set Commandant = 1  where Id = 'GIV';
update Declinaisons set Commandant = 1  where Id = 'ESE';

delete from Aptitudes where Id = 'PSI';
delete from Aptitudes where Id = 'PSI2';

INSERT OR IGNORE INTO Figurines (
                          NomFr,
                          NomEn,
                          MotClesFr,
                          MotClesEn,
                          FactionId,
                          Id
                      )
                      VALUES (
                          'Primaris Captain',
                          'Primaris Captain',
                          'IMPERIUM, COMMANDANT, INFANTERIE, PRIMARIS, CAPTAIN',
                          'IMPERIUM, COMMANDER, INFANTRY, PRIMARIS, CAPTAIN',
                          'AA',
                          'AAC'
                      ),
                      (
                          'Primaris Lieutenant',
                          'Primaris Lieutenant',
                          'IMPERIUM, COMMANDANT, INFANTERIE, PRIMARIS , LIEUTENANT',
                          'IMPERIUM, COMMANDER, INFANTRY, PRIMARIS , LIEUTENANT',
                          'AA',
                          'AAL'
                      ),
                      (
                          'Primaris Chaplain',
                          'Primaris Chaplain',
                          'IMPERIUM, COMMANDANT, INFANTERIE, PRIMARIS, CHAPLAIN',
                          'IMPERIUM, COMMANDER, INFANTRY, PRIMARIS, CHAPLAIN',
                          'AA',
                          'AAH'
                      ),
                      (
                          'Primaris Librarian',
                          'Primaris Librarian',
                          'IMPERIUM, COMMANDANT, INFANTERIE, PRIMARIS, PSYKER, LIBRARIAN ',
                          'IMPERIUM, COMMANDER, INFANTRY, PRIMARIS, PSYKER, LIBRARIAN ',
                          'AA',
                          'AAB'
                      ),
                      (
                          'Watch Master',
                          'Watch Master',
                          'IMPERIUM, ADEPTUS ASTARTES, COMMANDANT, INFANTERIE, WATCH MASTER',
                          'IMPERIUM, ADEPTUS ASTARTES, COMMANDER, INFANTRY, WATCH MASTER',
                          'DW',
                          'DWW'
                      ),
                      (
                          'Brotherhood Champion',
                          'Brotherhood Champion',
                          'IMPERIUM, ADEPTUS ASTARTES, COMMANDANT, INFANTERIE, PSYKER, BROTHERHOOD CHAMPION',
                          'IMPERIUM, ADEPTUS ASTARTES, COMMANDER, INFANTRY, PSYKER, BROTHERHOOD CHAMPION',
                          'GK',
                          'GKC'
                      ),
                      (
                          'Commissar / Lord Commissar',
                          'Commissar / Lord Commissar',
                          'IMPERIUM,OFFICIO PREFECTUS, COMMANDANT, INFANTERIE, COMMISSAR/LORD COMMISSAR',
                          'IMPERIUM,OFFICIO PREFECTUS, COMMANDER, INFANTRY, COMMISSAR/LORD COMMISSAR',
                          'AM',
                          'AMC'
                      ),
                      (
                          'Platoon Commander /  Company Commander ',
                          'Platoon Commander /  Company Commander ',
                          'IMPERIUM, COMMANDANT, INFANTERIE, OFFICER, PLATOON COMMANDER/COMPANY COMMANDER ',
                          'IMPERIUM, COMMANDER, INFANTRY, OFFICER, PLATOON COMMANDER/COMPANY COMMANDER ',
                          'AM',
                          'AMP'
                      ),
                      (
                          'Tempestor Prime',
                          'Tempestor Prime',
                          'IMPERIUM, MILITARUM TEMPEST US, COMMANDANT, INFANTERIE, OFFICER, TEMPESTOR PRIME',
                          'IMPERIUM, MILITARUM TEMPEST US, COMMANDER, INFANTRY, OFFICER, TEMPESTOR PRIME',
                          'AM',
                          'AMT'
                      ),
                      (
                          'Tech-Priest Enginseer',
                          'Tech-Priest Enginseer',
                          'IMPERIUM, CULT MECHANICUS , COMMANDANT, INFANTERIE, TECH-PRIEST, ENGINSEER ',
                          'IMPERIUM, CULT MECHANICUS , COMMANDER, INFANTRY, TECH-PRIEST, ENGINSEER ',
                          'ME',
                          'MET'
                      ),
                      (
                          'Tech-Priest Dominus',
                          'Tech-Priest Dominus',
                          'IMPERIUM, CULT MECHANICUS, COMMANDANT, INFANTERIE, TECH-PRIEST, DOMINUS',
                          'IMPERIUM, CULT MECHANICUS, COMMANDER, INFANTRY, TECH-PRIEST, DOMINUS',
                          'ME',
                          'MED'
                      ),
                      (
                          'Exalted Champion',
                          'Exalted Champion',
                          'CHAOS, <MARK OF CHAOS>, COMMANDANT, INFANTERIE, EXALTED CHAMPION',
                          'CHAOS, <MARK OF CHAOS>, COMMANDER, INFANTRY, EXALTED CHAMPION',
                          'HA',
                          'HAE'
                      ),
                      (
                          'Sorcerer',
                          'Sorcerer',
                          'CHAOS, <MARK OF CHAOS>, COMMANDANT, INFANTERIE, PSYKER, SORCERER',
                          'CHAOS, <MARK OF CHAOS>, COMMANDER, INFANTRY, PSYKER, SORCERER',
                          'HA',
                          'HAS'
                      ),
                      (
                          'Foul Blightspawn',
                          'Foul Blightspawn',
                          'CHAOS, NURGLE, HERETIC ASTARTES, COMMANDANT, INFANTERIE, FOUL BLIGHTSPAWN',
                          'CHAOS, NURGLE, HERETIC ASTARTES, COMMANDER, INFANTRY, FOUL BLIGHTSPAWN',
                          'DG',
                          'DGF'
                      ),
                      (
                          'Tallyman',
                          'Tallyman',
                          'CHAOS, NURGLE, HERETIC ASTARTES, COMMANDANT, INFANTERIE, TALLYMAN',
                          'CHAOS, NURGLE, HERETIC ASTARTES, COMMANDER, INFANTRY, TALLYMAN',
                          'DG',
                          'DGT'
                      ),
                      (
                          'Biologus Putrifier',
                          'Biologus Putrifier',
                          'CHAOS, NURGLE, HERETIC ASTARTES, COMMANDANT, INFANTERIE, BIOLOGUS PUTRIFIER',
                          'CHAOS, NURGLE, HERETIC ASTARTES, COMMANDER, INFANTRY, BIOLOGUS PUTRIFIER',
                          'DG',
                          'DGB'
                      ),
                      (
                          'Plague Surgeon',
                          'Plague Surgeon',
                          'CHAOS, NURGLE, HERETIC ASTARTES, COMMANDANT, INFANTERIE, PLAGUE SURGEON',
                          'CHAOS, NURGLE, HERETIC ASTARTES, COMMANDER, INFANTRY, PLAGUE SURGEON',
                          'DG',
                          'DGPS'
                      ),
                      (
                          'Exalted Sorcerer',
                          'Exalted Sorcerer',
                          'CHAOS, TZEENTCH, HERETIC ASTARTES, COMMANDANT, INFANTERIE, SORCERER, PSYKER, EXALTED SORCERER',
                          'CHAOS, TZEENTCH, HERETIC ASTARTES, COMMANDER, INFANTRY, SORCERER, PSYKER, EXALTED SORCERER',
                          'TS',
                          'TSE'
                      ),
                      (
                          'Tzaangor Shaman',
                          'Tzaangor Shaman',
                          'CHAOS, TZEENTCH, HERETIC ASTARTES, COMMANDANT, CAVALERIE, DAEMON, TZAANGOR, VOL, PSYKER, SHAMAN',
                          'CHAOS, TZEENTCH, HERETIC ASTARTES, COMMANDER, CAVALRY, DAEMON, TZAANGOR, FLY, PSYKER, SHAMAN',
                          'TS',
                          'TSTS'
                      ),
                      (
                          'Autarch',
                          'Autarch',
                          'AELDARI, WARHOST, COMMANDANT, INFANTERIE, AUTARCH',
                          'AELDARI, WARHOST, COMMANDER, INFANTRY, AUTARCH',
                          'AS',
                          'ASA'
                      ),
                      (
                          'Warlock',
                          'Warlock',
                          'AE LDARI, WARHOST, COMMANDANT, INFANTERIE, PSYKER, WARLOCK',
                          'AE LDARI, WARHOST, COMMANDER, INFANTRY, PSYKER, WARLOCK',
                          'AS',
                          'ASW'
                      ),
                      (
                          'Farseer',
                          'Farseer',
                          'AELDARI, WARHOST, COMMANDANT, INFANTERIE, PSYKER, FARSEER',
                          'AELDARI, WARHOST, COMMANDER, INFANTRY, PSYKER, FARSEER',
                          'AS',
                          'ASF'
                      ),
                      (
                          'Archon',
                          'Archon',
                          'AELDARI, COMMANDANT, INFANTERIE, ARCHON',
                          'AELDARI, COMMANDER, INFANTRY, ARCHON',
                          'DR',
                          'DRA'
                      ),
                      (
                          'Succubus',
                          'Succubus',
                          'AELDARI, COMMANDANT, INFANTERIE, SUCCUBUS',
                          'AELDARI, COMMANDER, INFANTRY, SUCCUBUS',
                          'DR',
                          'DRS'
                      ),
                      (
                          'Haemonculus',
                          'Haemonculus',
                          'AELDARI, COMMANDANT, INFANTERIE, HAEMONCULUS',
                          'AELDARI, COMMANDER, INFANTRY, HAEMONCULUS',
                          'DR',
                          'DRH'
                      ),
                      (
                          'Troupe Master',
                          'Troupe Master',
                          'AELDARI, COMMANDANT, INFANTERIE, TROUPE MASTER',
                          'AELDARI, COMMANDER, INFANTRY, TROUPE MASTER',
                          'AR',
                          'ART'
                      ),
                      (
                          'Shadowseer',
                          'Shadowseer',
                          'AELDARI, COMMANDANT, INFANTERIE, PSYKER, SHADOWSEER',
                          'AELDARI, COMMANDER, INFANTRY, PSYKER, SHADOWSEER',
                          'AR',
                          'ARS'
                      ),
                      (
                          'Death Jester',
                          'Death Jester',
                          'AELDARI, COMMANDANT, INFANTERIE, DEATH JESTER',
                          'AELDARI, COMMANDER, INFANTRY, DEATH JESTER',
                          'AR',
                          'ARD'
                      ),
                      (
                          'Overlord',
                          'Overlord',
                          'COMMANDANT, INFANTERIE, OVERLORD',
                          'COMMANDER, INFANTRY, OVERLORD',
                          'NE',
                          'NEO'
                      ),
                      (
                          'Cryptek',
                          'Cryptek',
                          'COMMANDANT, INFANTERIE, CRYPTEK',
                          'COMMANDER, INFANTRY, CRYPTEK',
                          'NE',
                          'NEY'
                      ),
                      (
                          'Warboss',
                          'Warboss',
                          'COMMANDANT, INFANTERIE, WARBOSS',
                          'COMMANDER, INFANTRY, WARBOSS',
                          'OR',
                          'ORW'
                      ),
                      (
                          'BigMek',
                          'BigMek',
                          'COMMANDANT, INFANTERIE, BIG MEK',
                          'COMMANDER, INFANTRY, BIG MEK',
                          'OR',
                          'ORBM'
                      ),
                      (
                          'Painboy',
                          'Painboy',
                          'COMMANDANT, INFANTERIE, PAINBOY',
                          'COMMANDER, INFANTRY, PAINBOY',
                          'OR',
                          'ORP'
                      ),
                      (
                          'Cadre Fireblade',
                          'Cadre Fireblade',
                          'COMMANDANT, INFANTERIE, CADRE FIREBLADE',
                          'COMMANDER, INFANTRY, CADRE FIREBLADE',
                          'TA',
                          'TAC'
                      ),
                      (
                          'Ethereal',
                          'Ethereal',
                          'COMMANDANT, INFANTERIE, ETHEREAL',
                          'COMMANDER, INFANTRY, ETHEREAL',
                          'TA',
                          'TAE'
                      ),
                      (
                          'Tyranid Prime',
                          'Tyranid Prime',
                          'COMMANDANT, INFANTERIE, SYNAPSE, TYRANID PRIME',
                          'COMMANDER, INFANTRY, SYNAPSE, TYRANID PRIME',
                          'TY',
                          'TYTP'
                      ),
                      (
                          'Broodlord',
                          'Broodlord',
                          'COMMANDANT, INFANTERIE, GENESTEALER, PSYKER, SYNAPSE, BROODLORD',
                          'COMMANDER, INFANTRY, GENESTEALER, PSYKER, SYNAPSE, BROODLORD',
                          'TY',
                          'TYB'
                      ),
                      (
                          'Magus',
                          'Magus',
                          'TYRANIDS, INFANTERIE, COMMANDANT, PSYKER, MAGUS',
                          'TYRANIDS, INFANTRY, COMMANDER, PSYKER, MAGUS',
                          'GC',
                          'GCZ'
                      ),
                      (
                          'Primus',
                          'Primus',
                          'TYRANIDS, INFANTERIE, COMMANDANT, PRIMUS',
                          'TYRANIDS, INFANTRY, COMMANDER, PRIMUS',
                          'GC',
                          'GCP'
                      ),
                      (
                          'Patriarch',
                          'Patriarch',
                          'TYRANIDS, INFANTERIE, GENESTEALER, COMMANDANT, PSYKER, PATRIARCH',
                          'TYRANIDS, INFANTRY, GENESTEALER, COMMANDER, PSYKER, PATRIARCH',
                          'GC',
                          'GCH'
                      ),
                      (
                          'Acolyte Iconward',
                          'Acolyte Iconward',
                          'TYRANIDS, INFANTERIE, COMMANDANT, ACOLYTE ICONWARD',
                          'TYRANIDS, INFANTRY, COMMANDER, ACOLYTE ICONWARD',
                          'GC',
                          'GCA'
                      );
					  
					  
INSERT OR IGNORE INTO Declinaisons (
                             NbPsyAbjures,
                             NbPsyManifestes,
                             NbPsyConnus,
                             Commandant,
                             cout,
                             Sv,
                             PV,
                             NomFr,
                             NomEn,
                             Max,
                             M,
                             FigurineId,
                             F,
                             E,
                             Cd,
                             CT,
                             CC,
                             A,
                             Id
                         )
                         VALUES (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             6,
                             'Primaris Captain',
                             'Primaris Captain',
                             1,
                             6,
                             'AAC',
                             4,
                             4,
                             9,
                             2,
                             2,
                             5,
                             'AAC'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             5,
                             'Primaris Lieutenant',
                             'Primaris Lieutenant',
                             1,
                             6,
                             'AAL',
                             4,
                             4,
                             8,
                             3,
                             2,
                             4,
                             'AAL'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             5,
                             'Primaris Chaplain',
                             'Primaris Chaplain',
                             1,
                             6,
                             'AAH',
                             4,
                             4,
                             9,
                             3,
                             2,
                             4,
                             'AAH'
                         ),
                         (
                             1,
                             2,
                             2,
                             1,
                             0,
                             3,
                             5,
                             'Primaris Librarian',
                             'Primaris Librarian',
                             1,
                             6,
                             'AAB',
                             4,
                             4,
                             9,
                             3,
                             3,
                             4,
                             'AAB'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             2,
                             6,
                             'Watch Master',
                             'Watch Master',
                             1,
                             6,
                             'DWW',
                             4,
                             4,
                             9,
                             2,
                             2,
                             4,
                             'DWW'
                         ),
                         (
                             1,
                             1,
                             1,
                             1,
                             0,
                             2,
                             4,
                             'Brotherhood Champion',
                             'Brotherhood Champion',
                             1,
                             6,
                             'GKC',
                             4,
                             4,
                             8,
                             2,
                             2,
                             4,
                             'GKC'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             5,
                             3,
                             'Commissar',
                             'Commissar',
                             1,
                             6,
                             'AMC',
                             3,
                             3,
                             8,
                             3,
                             3,
                             3,
                             'AMC1'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             4,
                             4,
                             'Lord Commissar',
                             'Lord Commissar',
                             1,
                             6,
                             'AMC',
                             3,
                             3,
                             9,
                             2,
                             2,
                             3,
                             'AMC2'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             5,
                             3,
                             'Platoon Commander',
                             'Platoon Commander',
                             1,
                             6,
                             'AMP',
                             3,
                             3,
                             7,
                             3,
                             3,
                             3,
                             'AMP1'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             5,
                             4,
                             'Company Commander',
                             'Company Commander',
                             1,
                             6,
                             'AMP',
                             3,
                             3,
                             8,
                             3,
                             3,
                             3,
                             'AMP2'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             4,
                             4,
                             'Tempestor Prime',
                             'Tempestor Prime',
                             1,
                             6,
                             'AMT',
                             3,
                             3,
                             8,
                             3,
                             3,
                             3,
                             'AMT'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             4,
                             'Tech-Priest Enginseer',
                             'Tech-Priest Enginseer',
                             1,
                             6,
                             'MET',
                             4,
                             4,
                             8,
                             4,
                             4,
                             2,
                             'MET'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             2,
                             5,
                             'Tech-Priest Dominus',
                             'Tech-Priest Dominus',
                             1,
                             6,
                             'MED',
                             4,
                             4,
                             8,
                             2,
                             3,
                             3,
                             'MED'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             4,
                             'Exalted Champion',
                             'Exalted Champion',
                             1,
                             6,
                             'HAE',
                             4,
                             4,
                             8,
                             3,
                             2,
                             4,
                             'HAE'
                         ),
                         (
                             1,
                             2,
                             2,
                             1,
                             0,
                             3,
                             4,
                             'Sorcerer',
                             'Sorcerer',
                             1,
                             6,
                             'HAS',
                             4,
                             4,
                             9,
                             3,
                             3,
                             3,
                             'HAS'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             4,
                             'Foul Blightspawn',
                             'Foul Blightspawn',
                             1,
                             5,
                             'DGF',
                             4,
                             5,
                             8,
                             3,
                             3,
                             3,
                             'DGF'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             4,
                             'Tallyman',
                             'Tallyman',
                             1,
                             5,
                             'DGT',
                             4,
                             5,
                             8,
                             3,
                             3,
                             3,
                             'DGT'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             4,
                             'Biologus Putrifier',
                             'Biologus Putrifier',
                             1,
                             5,
                             'DGB',
                             4,
                             5,
                             8,
                             3,
                             3,
                             3,
                             'DGB'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             4,
                             'Plague Surgeon',
                             'Plague Surgeon',
                             1,
                             5,
                             'DGPS',
                             4,
                             5,
                             8,
                             3,
                             3,
                             3,
                             'DGPS'
                         ),
                         (
                             1,
                             2,
                             2,
                             1,
                             0,
                             3,
                             4,
                             'Exalted Sorcerer',
                             'Exalted Sorcerer',
                             1,
                             6,
                             'TSE',
                             4,
                             4,
                             9,
                             2,
                             2,
                             5,
                             'TSE'
                         ),
                         (
                             1,
                             1,
                             1,
                             1,
                             0,
                             6,
                             4,
                             'Tzaangor Shaman',
                             'Tzaangor Shaman',
                             1,
                             12,
                             'TSTS',
                             4,
                             4,
                             8,
                             3,
                             3,
                             3,
                             'TSTS'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             5,
                             'Autarch',
                             'Autarch',
                             1,
                             7,
                             'ASA',
                             3,
                             3,
                             9,
                             2,
                             2,
                             4,
                             'ASA'
                         ),
                         (
                             1,
                             1,
                             1,
                             1,
                             0,
                             6,
                             2,
                             'Warlock',
                             'Warlock',
                             1,
                             7,
                             'ASW',
                             3,
                             3,
                             8,
                             3,
                             3,
                             2,
                             'ASW'
                         ),
                         (
                             2,
                             2,
                             2,
                             1,
                             0,
                             6,
                             5,
                             'Farseer',
                             'Farseer',
                             1,
                             7,
                             'ASF',
                             3,
                             3,
                             9,
                             2,
                             2,
                             2,
                             'ASF'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             5,
                             5,
                             'Archon',
                             'Archon',
                             1,
                             8,
                             'DRA',
                             3,
                             3,
                             9,
                             2,
                             2,
                             5,
                             'DRA'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             6,
                             5,
                             'Succubus',
                             'Succubus',
                             1,
                             8,
                             'DRS',
                             3,
                             3,
                             8,
                             2,
                             2,
                             4,
                             'DRS'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             6,
                             5,
                             'Haemonculus',
                             'Haemonculus',
                             1,
                             7,
                             'DRH',
                             3,
                             4,
                             8,
                             2,
                             2,
                             5,
                             'DRH'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             6,
                             5,
                             'Troupe Master',
                             'Troupe Master',
                             1,
                             8,
                             'ART',
                             3,
                             3,
                             9,
                             2,
                             2,
                             5,
                             'ART'
                         ),
                         (
                             1,
                             2,
                             2,
                             1,
                             0,
                             6,
                             5,
                             'Shadowseer',
                             'Shadowseer',
                             1,
                             8,
                             'ARS',
                             3,
                             3,
                             9,
                             2,
                             2,
                             3,
                             'ARS'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             6,
                             5,
                             'Death Jester',
                             'Death Jester',
                             1,
                             8,
                             'ARD',
                             3,
                             3,
                             9,
                             2,
                             2,
                             4,
                             'ARD'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             5,
                             'Overlord',
                             'Overlord',
                             1,
                             5,
                             'NEO',
                             5,
                             5,
                             10,
                             2,
                             2,
                             3,
                             'NEO'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             4,
                             4,
                             'Cryptek',
                             'Cryptek',
                             1,
                             5,
                             'NEY',
                             4,
                             4,
                             10,
                             3,
                             3,
                             1,
                             'NEY'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             4,
                             6,
                             'Warboss',
                             'Warboss',
                             1,
                             5,
                             'ORW',
                             6,
                             5,
                             8,
                             5,
                             2,
                             4,
                             'ORW'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             4,
                             4,
                             'Big Mek',
                             'Big Mek',
                             1,
                             5,
                             'ORBM',
                             5,
                             4,
                             7,
                             5,
                             3,
                             3,
                             'ORBM'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             6,
                             4,
                             'Painboy',
                             'Painboy',
                             1,
                             5,
                             'ORP',
                             5,
                             4,
                             6,
                             5,
                             3,
                             4,
                             'ORP'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             4,
                             5,
                             'Cadre Fireblade',
                             'Cadre Fireblade',
                             1,
                             6,
                             'TAC',
                             3,
                             3,
                             8,
                             2,
                             3,
                             3,
                             'TAC'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             5,
                             4,
                             'Ethereal',
                             'Ethereal',
                             1,
                             6,
                             'TAE',
                             3,
                             3,
                             9,
                             4,
                             3,
                             3,
                             'TAE'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             6,
                             'Tyranid Prime',
                             'Tyranid Prime',
                             1,
                             6,
                             'TYTP',
                             5,
                             5,
                             10,
                             3,
                             2,
                             4,
                             'TYTP'
                         ),
                         (
                             1,
                             1,
                             1,
                             1,
                             0,
                             4,
                             6,
                             'Broodlord',
                             'Broodlord',
                             1,
                             8,
                             'TYB',
                             5,
                             5,
                             10,
                             0,
                             2,
                             6,
                             'TYB'
                         ),
                         (
                             1,
                             1,
                             1,
                             1,
                             0,
                             5,
                             4,
                             'Magus',
                             'Magus',
                             1,
                             6,
                             'GCZ',
                             3,
                             3,
                             8,
                             3,
                             3,
                             3,
                             'GCZ'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             5,
                             5,
                             'Primus',
                             'Primus',
                             1,
                             6,
                             'GCP',
                             4,
                             3,
                             9,
                             3,
                             2,
                             4,
                             'GCP'
                         ),
                         (
                             1,
                             1,
                             1,
                             1,
                             0,
                             4,
                             6,
                             'Patriarch',
                             'Patriarch',
                             1,
                             8,
                             'GCH',
                             6,
                             5,
                             10,
                             5,
                             2,
                             6,
                             'GCH'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             5,
                             4,
                             'Acolyte Iconward',
                             'Acolyte Iconward',
                             1,
                             6,
                             'GCA',
                             4,
                             3,
                             8,
                             3,
                             3,
                             4,
                             'GCA'
                         );

						 INSERT OR IGNORE INTO Armes (
                      cout,
                      NomFr,
                      NomEn,
                      DescriptionAdditionnelleFr,
                      DescriptionAdditionnelleEn,
                      Id
                  )
                  VALUES (
                      0,
                      'Pistolet bolter Absolvor',
                      'Absolvor bolt pistol',
                      NULL,
                      NULL,
                      'PBA'
                  ),
                  (
                      0,
                      'Crozius arcanum',
                      'Crozius arcanum',
                      NULL,
                      NULL,
                      'CA'
                  ),
                  (
                      0,
                      'Epée de force',
                      'Force sword',
                      NULL,
                      NULL,
                      'FS'
                  ),
                  (
                      0,
                      'Lance gardienne',
                      'Guardian spear',
                      'Cette arme peut servir comme arme de tir et arme de mêlée. Lorsque vous faites des attaques de tir en état d''alerte avec cette arme, utilisez le profil de tir; lorsque vous faites des attaques de corps à corps, utilisez le profil de mêlée.',
                      'This weapon can be used as a ranged weapon and a melee weapon. When making shooting attacks or firing Overwatch with this weapon, use the ranged profile; when making close combat attacks, use the melee profile.',
                      'GSE'
                  ),
                  (
                      0,
                      'Hache de l''Omnimessie',
                      'Omnissian axe',
                      NULL,
                      NULL,
                      'OA'
                  ),
                  (
                      0,
                      'Servobras',
                      'Servo-arm',
                      NULL,
                      NULL,
                      'SA'
                  ),
                  (
                      14,
                      'Faisceau d''éradication',
                      'Eradication ray',
                      NULL,
                      NULL,
                      'ER'
                  ),
                  (
                      0,
                      'Macromitraillette',
                      'Macrostubber',
                      NULL,
                      NULL,
                      'M'
                  ),
                  (
                      4,
                      'Serpentine à phosphore',
                      'Phosphor serpenta',
                      NULL,
                      NULL,
                      'PS'
                  ),
                  (
                      0,
                      'Eclateur volkite',
                      'Volkite blaster',
                      NULL,
                      NULL,
                      'VB'
                  ),
                  (
                      0,
                      'Lance à peste',
                      'Plague sprayer',
                      NULL,
                      NULL,
                      'PSR'
                  ),
                  (
                      0,
                      'Pistolet Injector',
                      'Injector pistol',
                      NULL,
                      NULL,
                      'IP'
                  ),
                  (
                      0,
                      'Grenade hyper-bubonique',
                      'Hyper blight grenade',
                      NULL,
                      NULL,
                      'HBG'
                  ),
                  (
                      0,
                      'Pestelame',
                      'Balesword',
                      NULL,
                      NULL,
                      'B'
                  ),
                  (
                      0,
                      'Disc of Tzeentch/Lames',
                      'Disc of Tzeentch/Blades',
                      NULL,
                      NULL,
                      'BD'
                  ),
                  (
                      0,
                      'Vouge stellaire',
                      'Star glaive',
                      NULL,
                      NULL,
                      'SG'
                  ),
                  (
                      3,
                      'Lance chantante',
                      'Singing spear',
                      'Cette arme peut servir comme arme de tir et arme de mêlée. Lorsque vous faites des attaques de tir en état d''alerte avec cette arme, utilisez le profil de tir; lorsque vous faites des attaques de corps à corps, utilisez le profil de mêlée.',
                      'This weapon can be used as a ranged weapon and a melee weapon. When making shooting attacks or firing Overwatch with this weapon, use the ranged profile; when making close combat attacks, use the melee profile.',
                      'SS'
                  ),
                  (
                      0,
                      'Lame sorcière',
                      'Witchblade',
                      NULL,
                      NULL,
                      'W'
                  ),
                  (
                      0,
                      'Lame dessicante',
                      'Huskblade',
                      NULL,
                      NULL,
                      'H'
                  ),
                  (
                      0,
                      'Lame venimeuse',
                      'Venom blade',
                      NULL,
                      NULL,
                      'VBE'
                  ),
                  (
                      0,
                      'Vouge d''archite',
                      'Archite glaive',
                      NULL,
                      NULL,
                      'AG'
                  ),
                  (
                      0,
                      'Pistolet hypodermique',
                      'Stringer pistol',
                      NULL,
                      NULL,
                      'SP'
                  ),
                  (
                      0,
                      'Outils d''Haemonculus',
                      'Haemonculus tools',
                      NULL,
                      NULL,
                      'HT'
                  ),
                  (
                      5,
                      'Injecteur d''ichor',
                      'Ichor injector',
                      NULL,
                      NULL,
                      'IJ'
                  ),
                  (
                      0,
                      'Lance-grenades hallucinogènes',
                      'Hallucinogen grenade launcher',
                      NULL,
                      NULL,
                      'HGL'
                  ),
                  (
                      0,
                      'Sceptre de brume',
                      'Miststave',
                      NULL,
                      NULL,
                      'MS'
                  ),
                  (
                      0,
                      'Canon hurleur',
                      'Shrieker cannon',
                      'Lorsque vous attaquez avec cette arme, choisissez un des profils ci-dessous. Chaque fois que vous obtenez un jet de blessure de 6+ avec cette arme, la touche est résolue à PA-3.',
                      'When attacking with this weapon, choose one of the profiles below. Each time you make a wound roll of 6+ for this weapon, that hit is resolved with an AP of -3.',
                      'SC'
                  ),
                  (
                      0,
                      'Bâton de lumière',
                      'Staff of light',
                      'Cette arme peut servir comme arme de tir et arme de mêlée. Lorsque vous faites des attaques de tir en état d''alerte avec cette arme, utilisez le profil de tir; lorsque vous faites des attaques de corps à corps, utilisez le profil de mêlée.',
                      'This weapon can be used as a ranged weapon and a melee weapon. When making shooting attacks or firing Overwatch with this weapon, use the ranged profile; when making close combat attacks, use the melee profile.',
                      'SOL'
                  ),
                  (
                      0,
                      'Faux du néant',
                      'Voidscythe',
                      NULL,
                      NULL,
                      'V'
                  ),
                  (
                      0,
                      'Fauchard',
                      'Warscythe',
                      NULL,
                      NULL,
                      'WC'
                  ),
                  (
                      0,
                      'Fling'' kustom',
                      'Kustom shoota',
                      NULL,
                      NULL,
                      'KS'
                  ),
                  (
                      6,
                      'Squig d''attak''',
                      'Attack squig',
                      NULL,
                      NULL,
                      'AS'
                  ),
                  (
                      4,
                      'Méga-kalibr'' kustom',
                      'Kustom mega-slugga',
                      NULL,
                      NULL,
                      'KMS'
                  ),
                  (
                      27,
                      'Kanon shokk',
                      'Shokk attack gun',
                      NULL,
                      NULL,
                      'SAG'
                  ),
                  (
                      0,
                      'Pikouz''',
                      '''Urty syringe',
                      NULL,
                      NULL,
                      'US'
                  ),
                  (
                      1,
                      'Egaliseurs',
                      'Equalizers',
                      NULL,
                      NULL,
                      'E'
                  ),
                  (
                      0,
                      'Lame de duel',
                      'Honour blade',
                      NULL,
                      NULL,
                      'HB'
                  ),
                  (
                      0,
                      'Serres perforantes monstrueuses',
                      'Monstrous rending claws',
                      NULL,
                      NULL,
                      'MRC'
                  ),
                  (
                      0,
                      'Pistolet à aiguilles',
                      'Needle pistol',
                      NULL,
                      NULL,
                      'NP'
                  ),
                  (
                      0,
                      'Injecteur de toxines',
                      'Toxin injector claw',
                      NULL,
                      NULL,
                      'TIC'
                  ),
                  (
                      0,
                      'Fusil bolter Stalker de maitre',
                      'Master-crafted stalker bolt rifle',
                      NULL,
                      NULL,
                      'FBSM'
                  ),
                  (
                      0,
                      'Fusil bolter automatique de maitre',
                      'Master-crafted auto bolt rifle',
                      NULL,
                      NULL,
                      'FBAM'
                  ),
                  (
                      20,
                      'Disc of Tzeentch',
                      'Disc of Tzeentch',
                      'Cette figurine perd le mot-clé Infanterie et gagne les mots-clés Daemon, Cavalerie et Vol, son mouvement passe à 12" et son Disc attaquera l''ennemi au combat.',
                      'This model loses the Infantry keyword, gains the Daemon, Cavalry and Fly keywords, his Move characteristic is increased to 12" and his disc will atack his ennemies with its blades when he fights.',
                      'DST'
                  ),
                  (
                      2,
                      'Sceptre de commandement Tempestus',
                      'Tempestus Command Rod',
                      'Le porteur peut utiliser l''aptitude Commandant verbal deux fois à chaque round. Réslvez les effets du premier ordre avant de donner le second.',
                      'A model with a Tempestus command rod may use the Voice of Command ability twice in each battle round. Resolve the effects of the first order before issuing the second order.',
                      'SCT'
                  ),
                  (
                      5,
                      'Hache énergétique',
                      'Power axe',
                      NULL,
                      NULL,
                      'PAX'
                  ),
                  (
                      20,
                      'Ailes de Swooping Hawk',
                      'Swooping Hawk wings',
                      'La caractéristique de mouvement de cette figurine est de 14" et elle gagne les mots clés Réacteur dorsal et Vol.',
                      'This model Move characteristic is increased to 14" and it gains the Jump Pack and Fly keywords',
                      'ASW'
                  ),
                  (
                      10,
                      'Cape Canoptek',
                      'Canoptek cloak',
                      'La caractéristique de mouvement de cette figurine passe à 10" et elle gagne le mot-clé VOL.',
                      'This models move characteristic is increased to 10" and it gains the Fly keyword.',
                      'CCA'
                  ),
                  (
                      0,
                      'Champ de force kustom',
                      'Kustom force field',
                      'Voir tactiques',
                      'See tactics',
                      'CFC'
                  ),
                  (
                      5,
                      'Hover drone',
                      'Hover drone',
                      'La caractéristique de mouvement de cette figurine passe à 8" et elle gagne les mots-clés Répulseur et Vol',
                      'This models characteristic is increased to 8" and it gains the Jet Pack and fly keywords.',
                      'HD'
                  );

				  INSERT OR IGNORE INTO ProfileArmes (
                             TypeArmeId,
                             Portee,
                             PA,
                             NomFr,
                             NomEn,
                             NbTir,
                             F,
                             D,
                             ArmeId,
                             AptitudesFr,
                             AptitudesEn,
                             Id
                         )
                         VALUES (
                             'A',
                             18,
-                            1,
                             'Serpentine à phosphore',
                             'Phosphor serpenta',
                             1,
                             5,
                             1,
                             'PS',
                             'Les attaques ne subissent pas de pénalité sur le jet de touche quand elles visent des cibles masquées.',
                             'Attacks made with this weapon do not suifer the penalty to hit rolls for the target being obscured.',
                             'PS'
                         ),
                         (
                             'L',
                             24,
                             0,
                             'Eclateur volkite',
                             'Volkite blaster',
                             3,
                             6,
                             1,
                             'VB',
                             'A chaque fois que vous obtenez un jet de blessure de 6+, la cible subit une blessure mortelle en plus de tout autre dégât.',
                             'Each time you make a wound roll of 6+ for this weapon, the target suffers a mortal wound in addition to any other damage.',
                             'VB'
                         ),
                         (
                             'A',
                             9,
-                            3,
                             'Lance à peste',
                             'Plague sprayer',
                             'D6',
                             '2D6',
                             3,
                             'PSR',
                             'Cette arme touche automatiquement sa cible. Jetez 2D6 pour déterminer la Force de cette arme après avoir selectionné la ou les cibles. Vous pouvez relancer les jets de blessure de 1 de cette arme.',
                             'This weapon automatically hits its target. Roll to determine the Strength of this weapon after selecting its target(s). You can re-roll wound rails of 1 for this weapon.',
                             'PSR'
                         ),
                         (
                             'P',
                             3,
-                            1,
                             'Pistolet Injector',
                             'Injector pistol',
                             1,
                             4,
                             'D6',
                             'IP',
                             'Vous pouvez relancer les jets de blessure de 1 de cette arme.',
                             'You can re-roll wound rails of 1 for this weapon.',
                             'IP'
                         ),
                         (
                             'G',
                             6,
                             0,
                             'Grenade hyper-bubonique',
                             'Hyper blight grenade',
                             'D6',
                             4,
                             2,
                             'HBG',
                             'Vous pouvez relancer les jets de blessure de 1 de cette arme. Chaque jet de blessure de 6+ avec cette arme inflige une blessure mortelle en plus des dégâts normaux.',
                             'You can re-roll wound rails of 1 for this weapon. Each wound roll of 6+ made for this weapon inflicts a mortal wound on the target in addition to any other damage.',
                             'HBG'
                         ),
                         (
                             'M',
                             'M',
-                            3,
                             'Pestelame',
                             'Balesword',
                             0,
                             'U',
                             1,
                             'B',
                             'Vous pouvez relancer les jets de blessure de 1 de cette arme.',
                             'You can re-roll wound rails of 1 for this weapon.',
                             'B'
                         ),
                         (
                             'P',
                             16,
-                            1,
                             'Pistolet bolter Absolvor',
                             'Absolvor bolt pistol',
                             1,
                             5,
                             1,
                             'PBA',
                             NULL,
                             NULL,
                             'PBA'
                         ),
                         (
                             'M',
                             'M',
-                            1,
                             'Crozius arcanum',
                             'Crozius arcanum',
                             0,
                             '+1',
                             2,
                             'CA',
                             NULL,
                             NULL,
                             'CA'
                         ),
                         (
                             'M',
                             'M',
-                            3,
                             'Epée de force',
                             'Force sword',
                             0,
                             'U',
                             'D3',
                             'FS',
                             NULL,
                             NULL,
                             'FS'
                         ),
                         (
                             'R',
                             24,
-                            1,
                             'Tir',
                             'Ranged',
                             1,
                             4,
                             2,
                             'GS',
                             NULL,
                             NULL,
                             'GSER'
                         ),
                         (
                             'M',
                             'M',
-                            3,
                             'Mêlée',
                             'Melee',
                             0,
                             '+1',
                             'D3',
                             'GS',
                             NULL,
                             NULL,
                             'GSEM'
                         ),
                         (
                             'M',
                             'M',
-                            2,
                             'Hache de l''Omnimessie',
                             'Omnissian axe',
                             0,
                             '+1',
                             2,
                             'OA',
                             NULL,
                             NULL,
                             'OA'
                         ),
                         (
                             'M',
                             'M',
-                            2,
                             'Servobras',
                             'Servo-arm',
                             0,
                             'x2',
                             3,
                             'SA',
                             'Chaque servobras ne peut effectuer qu''une attaque à chaque fois que la figurine combat. Soustrayez 1 du jet de touche quand vous attaquez avec cette arme.',
                             'Each servo-arm can only be used to make one attack each time this mode! fights. When a mode! attacks with this weapon, you must subtract 1 from the hit roll.',
                             'SA'
                         ),
                         (
                             'L',
                             24,
-                            2,
                             'Faisceau d''éradication',
                             'Eradication ray',
                             'D3',
                             6,
                             1,
                             'ER',
                             'Les attaques visant des ennemis à 8" sont résolues à PA -4 et Dégâts D3.',
                             'Attacks from this weapon that target enemies at 8" or Jess are resolved with an AP of-4 and a Damage ofD3.',
                             'ER'
                         ),
                         (
                             'P',
                             12,
                             0,
                             'Macromitraillette',
                             'Macrostubber',
                             5,
                             4,
                             1,
                             'M',
                             NULL,
                             NULL,
                             'M'
                         ),
                         (
                             'M',
                             'M',
                             0,
                             'Disc of Tzeentch/Lames',
                             'Disc of Tzeentch/Blades',
                             0,
                             4,
                             1,
                             'BD',
                             'Après que le cavalier a effectué ses attaques au corps à corps, sa monture peut attaquer. Effectuez une attaque additionnelle avec ce profil d''arme.',
                             'After a model on this mount makes its close combat attacks, you can attack with its mount. Make 1 additional attack, using this weapon profile.',
                             'BD'
                         ),
                         (
                             'M',
                             'M',
-                            3,
                             'Vouge stellaire',
                             'Star glaive',
                             0,
                             'x2',
                             'D3',
                             'SG',
                             'Lorsque vous attaquez avec cette arme, vous devez soustraire 1 au jet de touche.',
                             'When attacking with this weapon, you must subtract 1 from the hit roll.',
                             'SG'
                         ),
                         (
                             'A',
                             12,
                             0,
                             'Tir',
                             'Ranged',
                             1,
                             9,
                             'D3',
                             'SS',
                             'Cette arme blesse toujours sur 2+.',
                             'This weapon always wounds on a roll of 2+.',
                             'SSR'
                         ),
                         (
                             'M',
                             'M',
                             0,
                             'Mêlée',
                             'Melee',
                             0,
                             'U',
                             'D3',
                             'SS',
                             'Cette arme blesse toujours sur 2+.',
                             'This weapon always wounds on a roll of 2+.',
                             'SSM'
                         ),
                         (
                             'M',
                             'M',
                             0,
                             'Lame sorcière',
                             'Witchblade',
                             0,
                             'U',
                             'D3',
                             'W',
                             'Cette arme blesse toujours sur 2+.',
                             'This weapon always wounds on a roll of 2+.',
                             'W'
                         ),
                         (
                             'M',
                             'M',
-                            1,
                             'Lame dessicante',
                             'Huskblade',
                             0,
                             '+1',
                             'D3',
                             'H',
                             NULL,
                             NULL,
                             'H'
                         ),
                         (
                             'M',
                             'M',
                             0,
                             'Lame venimeuse',
                             'Venom blade',
                             0,
                             '*',
                             1,
                             'VBE',
                             'Cette arme blesse toujours sur 2+.',
                             'This weapon always wounds on a roll of 2+.',
                             'VBE'
                         ),
                         (
                             'M',
                             'M',
-                            3,
                             'Vouge d''archite',
                             'Archite glaive',
                             0,
                             '+2',
                             1,
                             'AG',
                             'Lorsque vous attaquez avec cette arme, vous devez soustraire 1 au jet de touche.',
                             'When attacking with this weapon, you must subtract 1 from the hit roll.',
                             'AG'
                         ),
                         (
                             'P',
                             12,
                             0,
                             'Pistolet hypodermique',
                             'Stringer pistol',
                             1,
                             '*',
                             1,
                             'SP',
                             'Cette arme blesse toujours sur 2+.',
                             'This weapon always wounds on a roll of 2+.',
                             'SP'
                         ),
                         (
                             'M',
                             'M',
                             0,
                             'Outils d''Haemonculus',
                             'Haemonculus tools',
                             0,
                             '*',
                             1,
                             'HT',
                             'Cette arme blesse toujours sur 4+.',
                             'This weapon always wounds on a roll of 4+.',
                             'HT'
                         ),
                         (
                             'M',
                             'M',
-                            1,
                             'Injecteur d''ichor',
                             'Ichor injector',
                             0,
                             'U',
                             1,
                             'IJ',
                             'Le porteur ne peut effectuer que 1 attaque avec cette arme chaque fois qu''il combat. Vous pouvez relancer les jets de blessure ratés pour cette arme. A chaque jet de blessure de 6+ obtenu pour cette arme, la cible subit D3 blessures mortelles en plus de tout autre dégât.',
                             'The bearer can only make a single attack with this weapon each time it fights. You can re-roll failed wound rolls for this weapon. Each time you roll a wound roll of 6+ for this weapon, the target suffers D3 mortal wounds in addition to any other damage.',
                             'IJ'
                         ),
                         (
                             'P',
                             18,
                             '*',
                             'Lance-grenades hallucinogènes',
                             'Hallucinogen grenade launcher',
                             1,
                             '*',
                             '*',
                             'HGL',
                             'Si une figurine est touchée par cette arme, jetz 2D6 - si le résultat est égal ou supérieur au Commandement de la cible, celle-ci subit une blessure mortelle.',
                             'If a model is hit by this weapon, roll 2D6 - if the roll is equal to or greater than the target model''s Leadership, it suffers a mortal wound.',
                             'HGL'
                         ),
                         (
                             'M',
                             'M',
-                            1,
                             'Sceptre de brume',
                             'Miststave',
                             0,
                             '+2',
                             'D3',
                             'MS',
                             NULL,
                             NULL,
                             'MS'
                         ),
                         (
                             'A',
                             24,
-                            1,
                             'Hurleur',
                             'Shrieker',
                             1,
                             6,
                             1,
                             'SC',
                             'Chaque fois qu''une figurine d''infanterie est tuée par une attaque de cette arme, jetez un D6 pour chaque figurine ennemie à 2" de cette figurine. Sur 4+ la figurine pour laquelle le dé a été jeté subit 1 blessure mortelle.',
                             'Each time an infantry model is slain by an attack made with this weapon, roll a D6 for each ennemy model within 2" of that model. On a roll of 4+ the model being rolled for suffers a mortal wound.',
                             'SC1'
                         ),
                         (
                             'A',
                             24,
                             0,
                             'Shuriken',
                             'Shuriken',
                             3,
                             6,
                             1,
                             'SC',
                             NULL,
                             NULL,
                             'SC2'
                         ),
                         (
                             'A',
                             12,
-                            2,
                             'Tir',
                             'Ranged',
                             3,
                             5,
                             1,
                             'SOL',
                             NULL,
                             NULL,
                             'SOL1'
                         ),
                         (
                             'M',
                             'M',
-                            2,
                             'Mêlée',
                             'Melee',
                             0,
                             'U',
                             1,
                             'SOL',
                             NULL,
                             NULL,
                             'SOL2'
                         ),
                         (
                             'M',
                             'M',
-                            4,
                             'Faux du néant',
                             'Voidscythe',
                             0,
                             'x2',
                             3,
                             'V',
                             'Lorsque vous attaquez avec cette arme, vous devez soustraire 1 au jet de touche.',
                             'When attacking with this weapon, subtract 1 from the hit roll.',
                             'V'
                         ),
                         (
                             'M',
                             'M',
-                            4,
                             'Fauchard',
                             'Warscythe',
                             0,
                             '+2',
                             2,
                             'WC',
                             NULL,
                             NULL,
                             'WC'
                         ),
                         (
                             'A',
                             24,
                             0,
                             'Fling'' kustom',
                             'Kustom shoota',
                             4,
                             4,
                             1,
                             'KS',
                             NULL,
                             NULL,
                             'KS'
                         ),
                         (
                             'M',
                             'M',
-                            1,
                             'Squig d''attak''',
                             'Attack squig',
                             0,
                             4,
                             1,
                             'AS',
                             'Quand une figurine avec squig d''attak combat, elle peut effectuer 2 attaques supplémentaires avec cette arme.',
                             'Each time a model with an attack squig fights, it can make 2 additional attacks with this weapon.',
                             'AS'
                         ),
                         (
                             'P',
                             12,
-                            3,
                             'Méga-kalibr'' kustom',
                             'Kustom mega-slugga',
                             1,
                             8,
                             'D3',
                             'KMS',
                             'Sur un jet de touche non modifié de 1, le porteur est mis hors de combat.',
                             'On an unmodified hit roll of 1, the bearer is taken out of action.',
                             'KMS'
                         ),
                         (
                             'L',
                             60,
-                            5,
                             'Kanon shokk',
                             'Shokk attack gun',
                             'D6',
                             '2D6',
                             'D3',
                             'SAG',
                             'Avant de tirer avec cette arme, effectuez un jet pour déterminer la Force de tous ses tirs. Si le résultat est 11+, n''effectuez pas de jets de blessure, car chaque attaque inflige D3 blessures mortelles.',
                             'Before firing this weapon, roll once to determine the Strength of ail its shots. If the result is 11 +, do not make wound rolls - instead, each attack that hits causes D3 mortal wounds.',
                             'SAG'
                         ),
                         (
                             'M',
                             'M',
                             0,
                             'Pikouz''',
                             '''Urty syringe',
                             0,
                             'U',
                             1,
                             'US',
                             'Cette arme blesse toujours sur 2+.',
                             'This weapon always wounds on a roll of 2+.',
                             'US'
                         ),
                         (
                             'M',
                             'M',
-                            1,
                             'Egaliseurs',
                             'Equalizers',
                             0,
                             'U',
                             1,
                             'E',
                             'Une figurine armée d''égaliseurs augmente sa caractéristique d''Attaques de 1.',
                             'A model armed with equalizers increases its Attacks characteristic by 1.',
                             'E'
                         ),
                         (
                             'M',
                             'M',
                             0,
                             'Lame de duel',
                             'Honour blade',
                             0,
                             '+2',
                             1,
                             'HB',
                             NULL,
                             NULL,
                             'HB'
                         ),
                         (
                             'M',
                             'M',
-                            3,
                             'Serres perforantes monstrueuses',
                             'Monstrous rending claws',
                             0,
                             'U',
                             'D3',
                             'MRC',
                             'Vous pouvez relancer les jets de blessure ratés pour cette arme. De plus, chaque fois que vous effectuez un jet de blessure de 6+, la touche est résolue avec une PA de -6 et un dégât de 3.',
                             'You can re-roll failed wound rolls for this weapon. In addition, each time you make a wound roll of 6+, that hit is resolved with an AP of -6 and Damage of 3.',
                             'MRC'
                         ),
                         (
                             'P',
                             12,
                             0,
                             'Pistolet à aiguilles',
                             'Needle pistol',
                             1,
                             1,
                             1,
                             'NP',
                             'Cette arme blesse toujours sur 2+.',
                             'This weapon always wounds on a roll of2+.',
                             'NP'
                         ),
                         (
                             'L',
                             36,
-                            2,
                             'Fusil bolter Stalker de maitre',
                             'Master-crafted stalker bolt rifle',
                             1,
                             4,
                             2,
                             'FBSM',
                             NULL,
                             NULL,
                             'FBSM'
                         ),
                         (
                             'A',
                             24,
                             0,
                             'Fusil bolter automatique de maitre',
                             'Master-crafted auto bolt rifle',
                             1,
                             4,
                             2,
                             'FBAM',
                             NULL,
                             NULL,
                             'FBAM'
                         ),
                         (
                             'M',
                             'M',
-                            1,
                             'Injecteur de toxines',
                             'Toxin injector claw',
                             0,
                             'U',
                             1,
                             'TIC',
                             'Cette arme blesse toujours sur un jet de 2+. En outre, chaque fois que vous obtenez un 6+ sur un jet de blessure avec cette arme, la touche est résolue avec une PA de -4.',
                             'This weapon always wounds on a roll of2+. Furthermore, each time you make a wound roll of 6+ with this weapon, that hit is resolved with an AP of -4 .',
                             'TIC'
                         ),
                         (
                             'M',
                             'M',
-                            2,
                             'Hache énergétique',
                             'Power axe',
                             0,
                             '+1',
                             1,
                             'PAX',
                             NULL,
                             NULL,
                             'PAX'
                         );

INSERT OR IGNORE INTO Aptitudes (
                          NomFr,
                          NomEn,
                          FigurineId,
                          FactionId,
                          DescriptionFr,
                          DescriptionEn,
                          DeclinaisonId,
                          Id
                      )
                      VALUES (
                          'Halo de Fer',
                          'Iron Halo',
                          'AAC',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 4+.',
                          'This model has a 4+ invulnerable save.',
                          NULL,
                          'IH'
                      ),
                      (
                          'Rosarius',
                          'Rosarius',
                          'AAH',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 4+.',
                          'This model has a 4+ invulnerable save.',
                          NULL,
                          'R'
                      ),
                      (
                          'Coiffe psychique',
                          'Psychic Hood',
                          'AAB',
                          NULL,
                          'Vous pouvez ajouter 1 aux tests d''Abjuration de cette figurine contre les Psykers ennemis à 12".',
                          'You can add 1 to Deny the Witch,tests you take for this mode! against enemy PSYKERS within 12".',
                          NULL,
                          'PH'
                      ),
                      (
                          'Halo de Fer',
                          'Iron Halo',
                          'DWW',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 4+.',
                          'This model has a 4+ invulnerable save.',
                          NULL,
                          'IHD'
                      ),
                      (
                          'Halo de Fer',
                          'Iron Halo',
                          'GKC',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 4+.',
                          'This model has a 4+ invulnerable save.',
                          NULL,
                          'IHG'
                      ),
                      (
                          'Sacrifice héroïque',
                          'Heroic sacrifice',
                          'GKC',
                          NULL,
                          'Si cette figurine est mise hors de combat en phase de Combat, elle peut immédiatement combattre avant d''être retirée du champ de bataille, même si elel a déjà combattu à cette phase.',
                          'If this model is taken out of action in the Fight phase, you can immediately fight with them before removing the mode! from the battlefield, even if they have already been chosen to fight in that phase. ',
                          NULL,
                          'HS'
                      ),
                      (
                          'Le guerrier parfait',
                          'The Perfect Warrior',
                          'GKC',
                          NULL,
                          'Au début de chaque phase de Combat, vous devez choisir une posture de combat pour la durée de la phase: la Frappe de l''Epée ou le Bouclier de Lame. La Frappe de l''Epée vous permet d''ajouter 1 aux jets de blessure de la figurine à cette phase. Le Bouclier de Lame vous permet d''ajouter 1 aux jets de sauvegarde de cette figurine à cette phase.',
                          'At the start of each Fight phase, you must choose a combat stance for this model to adopt for the duration of that phase - either the Sword Strike stance or the Blade Shield stance. If you choose the Sword Strike stance, add 1 to wound rolls for this model''s attacks for that phase. If you choose the Blade Shield stance, add 1 to this model''s saving throws for that phase.',
                          NULL,
                          'TPW'
                      ),
                      (
                          'Champ réfracteur',
                          'Refractor Field',
                          'MED',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 5+.',
                          'A Lord Commissar has a 5+ invulnerable save.',
                          NULL,
                          'RF'
                      ),
                      (
                          'Officier supérieur',
                          'Senior Officer',
                          'AMP',
                          NULL,
                          'Un Company Commander peut utiliser l''aptitude Commandement verbal deux fois à chaque round. Résolvez les effets du premier ordre avant de donner le second.',
                          'A Company Commander may use the Voice of Command ability twice each battle round. Resolve the effects of the first order before issuing the second order.',
                          NULL,
                          'SO'
                      ),
                      (
                          'Sceptre de commandement Tempestus',
                          'Tempestus Command Rod',
                          'AMT',
                          NULL,
                          'Le porteur peut utiliser l''aptitude Commandement Verbal deux fois à chaque round. Résolvez les effets du premier ordre avant de donner le second.',
                          'A model with a Tempestus command rod may use the Voice of Command ability twice in each battle round. Resolve the effects of the first order before issuing the second order.',
                          NULL,
                          'TCR'
                      ),
                      (
                          'Bioniques de Maitre',
                          'Masterwork Bionics',
                          'MED',
                          NULL,
                          'Au début de chaque round, cette figurine soigne D3 blessures subies.',
                          'At the beginning of each battle round, this model regains D3 lost wounds.',
                          NULL,
                          'MB'
                      ),
                      (
                          'Mort au Faux Empereur',
                          'Death to the False Emperor',
                          'HAE',
                          NULL,
                          'A chaque jet de touche de 6+ pour une figurine avec cette aptitude à la phase de combat, elle peut, si elle ciblait une figurine de l''imperium, effectuer aussitôt une attaque supplémentaire contre la même figurine avec la même arme. Ces attaques bonus n''en génerent pas à leur tour.',
                          'If a model with this ability makes an attack in the Fight phase that targets an IMPERIUM model, each time you roll a hit roll of 6+ you may make an additional attack with the same weapon against the same target. These attacks cannot themselves generate any further attacks.',
                          NULL,
                          'HAE'
                      ),
                      (
                          'Pour les dieux sombres',
                          'For the Dark Gods',
                          'HAE',
                          NULL,
                          'Vous pouvez relancer les jets de touches ratés de cette figurine si elle vise un Commandant ennemi.',
                          'You can re-roll failed hit rolls for this mode! if the target is an enemy COMMANDER.',
                          NULL,
                          'FDG'
                      ),
                      (
                          'Physiologie transhumaine',
                          'Transhuman Physiology',
                          'HAE',
                          NULL,
                          'Ignorez la pénalité imposée aux jets de touche de cette figurine par 1 blessure légère.',
                          'Ignore the penalty to this model''s hit rolls from one flesh wound it has suffered.',
                          NULL,
                          'TP'
                      ),
                      (
                          'Mort au Faux Empereur',
                          'Death to the False Emperor',
                          'HAS',
                          NULL,
                          'A chaque jet de touche de 6+ pour une figurine avec cette aptitude à la phase de combat, elle peut, si elle ciblait une figurine de l''imperium, effectuer aussitôt une attaque supplémentaire contre la même figurine avec la même arme. Ces attaques bonus n''en génerent pas à leur tour.',
                          'If a model with this ability makes an attack in the Fight phase that targets an IMPERIUM model, each time you roll a hit roll of 6+ you may make an additional attack with the same weapon against the same target. These attacks cannot themselves generate any further attacks.',
                          NULL,
                          'HAE2'
                      ),
                      (
                          'Physiologie transhumaine',
                          'Transhuman Physiology',
                          'HAS',
                          NULL,
                          'Ignorez la pénalité imposée aux jets de touche de cette figurine par 1 blessure légère.',
                          'Ignore the penalty to this model''s hit rolls from one flesh wound it has suffered.',
                          NULL,
                          'TP2'
                      ),
                      (
                          'Mort au Faux Empereur',
                          'Death to the False Emperor',
                          'DGF',
                          NULL,
                          'A chaque jet de touche de 6+ pour une figurine avec cette aptitude à la phase de combat, elle peut, si elle ciblait une figurine de l''imperium, effectuer aussitôt une attaque supplémentaire contre la même figurine avec la même arme. Ces attaques bonus n''en génerent pas à leur tour.',
                          'If a model with this ability makes an attack in the Fight phase that targets an IMPERIUM model, each time you roll a hit roll of 6+ you may make an additional attack with the same weapon against the same target. These attacks cannot themselves generate any further attacks.',
                          NULL,
                          'DFE'
                      ),
                      (
                          'Physiologie transhumaine',
                          'Transhuman Physiology',
                          'DGF',
                          NULL,
                          'Ignorez la pénalité imposée aux jets de touche de cette figurine par 1 blessure légère.',
                          'Ignore the penalty to this model''s hit rolls from one flesh wound it has suffered.',
                          NULL,
                          'TPD'
                      ),
                      (
                          'Mort au Faux Empereur',
                          'Death to the False Emperor',
                          'DGT',
                          NULL,
                          'A chaque jet de touche de 6+ pour une figurine avec cette aptitude à la phase de combat, elle peut, si elle ciblait une figurine de l''imperium, effectuer aussitôt une attaque supplémentaire contre la même figurine avec la même arme. Ces attaques bonus n''en génerent pas à leur tour.',
                          'If a model with this ability makes an attack in the Fight phase that targets an IMPERIUM model, each time you roll a hit roll of 6+ you may make an additional attack with the same weapon against the same target. These attacks cannot themselves generate any further attacks.',
                          NULL,
                          'DFE2'
                      ),
                      (
                          'Physiologie transhumaine',
                          'Transhuman Physiology',
                          'DGT',
                          NULL,
                          'Ignorez la pénalité imposée aux jets de touche de cette figurine par 1 blessure légère.',
                          'Ignore the penalty to this model''s hit rolls from one flesh wound it has suffered.',
                          NULL,
                          'TPD2'
                      ),
                      (
                          'Mort au Faux Empereur',
                          'Death to the False Emperor',
                          'DGB',
                          NULL,
                          'A chaque jet de touche de 6+ pour une figurine avec cette aptitude à la phase de combat, elle peut, si elle ciblait une figurine de l''imperium, effectuer aussitôt une attaque supplémentaire contre la même figurine avec la même arme. Ces attaques bonus n''en génerent pas à leur tour.',
                          'If a model with this ability makes an attack in the Fight phase that targets an IMPERIUM model, each time you roll a hit roll of 6+ you may make an additional attack with the same weapon against the same target. These attacks cannot themselves generate any further attacks.',
                          NULL,
                          'DFE3'
                      ),
                      (
                          'Physiologie transhumaine',
                          'Transhuman Physiology',
                          'DGB',
                          NULL,
                          'Ignorez la pénalité imposée aux jets de touche de cette figurine par 1 blessure légère.',
                          'Ignore the penalty to this model''s hit rolls from one flesh wound it has suffered.',
                          NULL,
                          'TPD3'
                      ),
                      (
                          'Mort au Faux Empereur',
                          'Death to the False Emperor',
                          'DGPS',
                          NULL,
                          'A chaque jet de touche de 6+ pour une figurine avec cette aptitude à la phase de combat, elle peut, si elle ciblait une figurine de l''imperium, effectuer aussitôt une attaque supplémentaire contre la même figurine avec la même arme. Ces attaques bonus n''en génerent pas à leur tour.',
                          'If a model with this ability makes an attack in the Fight phase that targets an IMPERIUM model, each time you roll a hit roll of 6+ you may make an additional attack with the same weapon against the same target. These attacks cannot themselves generate any further attacks.',
                          NULL,
                          'DFE4'
                      ),
                      (
                          'Physiologie transhumaine',
                          'Transhuman Physiology',
                          'DGPS',
                          NULL,
                          'Ignorez la pénalité imposée aux jets de touche de cette figurine par 1 blessure légère.',
                          'Ignore the penalty to this model''s hit rolls from one flesh wound it has suffered.',
                          NULL,
                          'TPD4'
                      ),
                      (
                          'Tête de mort impie',
                          'Unholy Death''s Head',
                          'DGF',
                          NULL,
                          'Chaque Foul Blightspawn porte une seule grenade tête de mort impie. Une fois par bataille, le Foul Blightspawn peut la lancer au lieu de lancer une grenade bubonique. La tête de mort impie compte comme une grenade bubonique de type Grenade 2D6.',
                          'Each Foui Blightspawn carries a single unholy death''s head grenade. Once per battle, a Foui Blightspawn can throw an unholy death''s head grenade instead of a blight grenade. When they do so, change that weapon''s Type to Grenade 2D6.',
                          NULL,
                          'UDH'
                      ),
                      (
                          'L''Heptachant',
                          'The Seven-fold Chant',
                          'DGT',
                          NULL,
                          'Si votre kill team est réglementaire, et que vous avez un Tallyman qui n''est pas secoué sur le champ de bataille, jetez 2D6 à chaque fois que vous dépensez des Points de Commandement pour utiliser une tactique de la Death Guard. Sur un 7, les Points de Commandement dépensés sont récupérés sur le champ.',
                          'If your kill team is Battleforged, and you have a Tallyman on the battlefield that is not shaken, roll 2D6 each time you spend Command Points to use a Death Guard Tactic. If the result is 7, the Command Points spent to use that Tactic are immediately refunded.',
                          NULL,
                          'TSC'
                      ),
                      (
                          'Explosion pestilentielle',
                          'Pestillential Explosion',
                          'DGB',
                          NULL,
                          'Si cette figurine est mise hors de combat, jetez un D6 avant de la retirer du champ de bataillle. Sur un 6, chaque figurine à 3" subit une blessure mortelle, à moins d''avoir le mot-clé Nurgle.',
                          'If this model is taken out of action, roll a D6 before removing it from the battlefield. On a 6, each mode! within 3" suffers 1 mortal wound unless it has the NuRGLE keyword.',
                          NULL,
                          'PE'
                      ),
                      (
                          'Voleur de gènes',
                          'Gene-seed Thief',
                          'DGPS',
                          NULL,
                          'Ajoutez 1 aux jets de touche et de blessure en phase de combat quand cette figurine vise une figurine Adeptus Astartes.',
                          'Add 1 to hit and wound rails made for this mode! in the Fight phase when targeting an ADEPTUS ASTARTES model.',
                          NULL,
                          'GT'
                      ),
                      (
                          'Favoris de Tzeentch',
                          'Favoured of Tzeentch',
                          'TSE',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 5+.',
                          'This model has a 5+ invulnerable save.',
                          NULL,
                          'FT'
                      ),
                      (
                          'Aura de sombre gloire',
                          'Aura of Dark Glory',
                          'TSTS',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 5+.',
                          'This model has a 5+ invulnerable save.',
                          NULL,
                          'ADG'
                      ),
                      (
                          'Elixir ensorcelé',
                          'Sorcerous Elixir',
                          'TSTS',
                          NULL,
                          'Vous pouvez relancer le premier test Psychique raté avec cette figurine. Cette aptitude ne peut servir qu''une seule fois par bataille.',
                          'You can re-roll the first failed Psychic test you make for this mode!. This ability can only be used once per battle.',
                          NULL,
                          'SE'
                      ),
                      (
                          'Enfant de Baharroth',
                          'Children of Baharroth',
                          'ASA',
                          NULL,
                          'Autarch avec ailes de Swooping Hawk seulement. Lors du déploiement, vous pouvez placer cette figurine dans le ciel et non sur le champ de bataille. A la fin de n''importe quel phase de mouvement, cette figurine peut descendre - placez-la n''importe où sur le champ de bataille à plus de 9" de toute figurine ennemie.',
                          'Autarch with Swooping Hawk wings only. During deployment, you can set up this mode! in the skies instead of placing it on the battlefield. At the end of any Movement phase this mode! can descend - set it up anywhere on the battlefield that is more than 9" away from any enemy models.',
                          NULL,
                          'CB'
                      ),
                      (
                          'Bouclier de force',
                          'Forceshield',
                          'ASA',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 4+.',
                          'This model has a 4+ invulnerable save.',
                          NULL,
                          'F'
                      ),
                      (
                          'Mandibules de scorpion',
                          'Mandiblasters',
                          'ASA',
                          NULL,
                          'Autarch avec ailes de Swooping Hawk seulement. Au début de chaque phase de combat, vous pouvez choisir une figurine ennemie à 1" de cette figurine et jeter un D6. Sur un 6, cette figurine subit une blessure mortelle.',
                          'Autarch with Swooping Hawk wings only. At the beginning of each Fight phase, you can pick a single enemy mode! within l" of this mode! and roll a D6. On a roll of 6, that mode! suffers a mortal wound.',
                          NULL,
                          'M'
                      ),
                      (
                          'Armure de rune',
                          'Rune Armour',
                          'ASW',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 4+.',
                          'This model has 4+ invulnerable save.',
                          NULL,
                          'RA'
                      ),
                      (
                          'Heaume spectral',
                          'Ghosthelm',
                          'ASF',
                          NULL,
                          'Jetez un D6 chaque fois que cette figurine subit une blessure mortelle, en ajoutant 3 au jet si la blessure mortelle est due aux Périls du Warp; sur 5+, cette blessure est ignorée.',
                          'Roll a D6 whenever this mode! suffers a mortal wound, adding 3 to the roll if the mortal wound was inflicted as the result of the psyker suffering Perils of the Warp. On a 5+ that wound is not lost.',
                          NULL,
                          'G'
                      ),
                      (
                          'Armure de rune',
                          'Rune Armour',
                          'ASF',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 4+.',
                          'This model has a 4+ invulnerable save.',
                          NULL,
                          'RAF'
                      ),
                      (
                          'Runes de Farseer',
                          'Runes of the Farseer',
                          'ASF',
                          NULL,
                          'Une fois par phase psychique, vous pouvez rejeter n''importe quel nombre de dés utilisés pour les tentatives de cette figurine de manifester ou abjurer un pouvoir psychique.',
                          'Once in each Psychic phase, you can re-roll any number of dice used for this model''s attempt to manifest or deny a psychic power.',
                          NULL,
                          'RTF'
                      ),
                      (
                          'Générateur de l''ombre',
                          'Shadowfield',
                          'DRA',
                          NULL,
                          'Cette figurine a une sauvegarde de 2+, qui ne peut jamais être relancée quelel qu''en soit la raison. La première fois que cette sauvegarde invulnérable est ratée, le générateur d''ombre cesse de fonctionner jusqu''à la fin de la bataille.',
                          'This model has a 2+ invulnerable save, which cannot be re-rolled for any reason. The first time this invulnerable save is failed the shadowfield ceases to fonction for the remainder of the battle.',
                          NULL,
                          'S'
                      ),
                      (
                          'Drogues de combat',
                          'Combat Drugs',
                          'DRS',
                          NULL,
                          'Les figurines ayant cette aptitude gagnent un bonus pour toute la bataille, qui dépend de la drogue prise. Avant la bataille, faites un jet sur le tableau ci-dessous pour voir quelle drogue de combat votre kill team emploie. Ce bonus s''applique à toutes les figurines de votre kill team ayant cette aptitude.',
                          'Models with this ability gain a bonus during the battle depending on the drugs they have taken. Before the battle, roll on the table below to see which combat drug your kill team is using. This bonus applies to all models in your kill team with the Combat Drugs ability.',
                          NULL,
                          'CD'
                      ),
                      (
                          'Esquive fulgurante',
                          'Lightning Dodge',
                          'DRS',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 4+.',
                          'This model has a 4+ invulnerable save.',
                          NULL,
                          'LD'
                      ),
                      (
                          'Pas d''échappatoire',
                          'No Escape',
                          'DRS',
                          NULL,
                          'Tirez au dé lorsqu''une figurine d''Infanterie à 1" d''une ou plusieurs figurine ennemie avec cette aptitude veut Battre en Retraite. Cette figurine peut Battre en Retraite seulement si le joueur qui la controle remporte le tir au dé.',
                          'Roll off if an INFANTRY mode! within l" of any enemy models with this ability would Fall Back. The model that would Fall Back can only do so if the player controlling it wins the roll- off.',
                          NULL,
                          'NE'
                      ),
                      (
                          'Insensible à la douleur',
                          'Isensible To Pain',
                          'DRH',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 5+.',
                          'This model has a 5+ invulnerable save.',
                          NULL,
                          'ITP'
                      ),
                      (
                          'La Mort ne Suffit pas',
                          'Death ls Not Enough',
                          'ARD',
                          NULL,
                          'Si cette figurine met une figurine ennemie hors de combat à la phase de tir, le joueur qui controle cette dernière doit ajouter 1 à ses tests de sang froid à la phase de Moral de ce tour.',
                          'If this model takes an enemy mode! out of action in the Shooting phase, the controlling player must add 1 to Nerve tests they make in the Morale phase of that turn.',
                          NULL,
                          'DNE'
                      ),
                      (
                          'Chasseur mortel',
                          'Deadly Hunter',
                          'ARD',
                          NULL,
                          'Lorsque cette figurine cible une figurine ennemie qui est masquée à la phase de tir, celle-ci est considérée comme n''étant pas masquée.',
                          'When this mode! targets an enemy mode! that is obscured in the Shooting phase, treat it as if it were not obscured.',
                          NULL,
                          'DH'
                      ),
                      (
                          'Métal organique',
                          'Living Metal',
                          'NEO',
                          NULL,
                          'Au début de chaque round de bataille, cette figurine récupère 1 PV perdu plus tôt dans la bataille.',
                          'At the beginning of each battle round, this mode! recovers 1 wound lost earlier in the battle.',
                          NULL,
                          'LM'
                      ),
                      (
                          'Disrupteur de phase',
                          'Phase Shifter',
                          'NEO',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 4+.',
                          'This model has a 4+ invulnerable save.',
                          NULL,
                          'PS'
                      ),
                      (
                          'Métal organique',
                          'Living Metal',
                          'NEY',
                          NULL,
                          'Au début de chaque round de bataille, cette figurine récupère 1 PV perdu plus tôt dans la bataille.',
                          'At the beginning of each battle round, this mode! recovers 1 wound lost earlier in the battle.',
                          NULL,
                          'LMC'
                      ),
                      (
                          'On y Va!',
                          '''Ere We Go',
                          'ORW',
                          NULL,
                          'Relancez les jets de charge ratés pour une figurine avec cette aptitude.',
                          'Re-roll failed charge rolls for this model.',
                          NULL,
                          'EWG'
                      ),
                      (
                          'On y Va!',
                          '''Ere We Go',
                          'ORBM',
                          NULL,
                          'Relancez les jets de charge ratés pour une figurine avec cette aptitude.',
                          'Re-roll failed charge rolls for this model.',
                          NULL,
                          'EWG2'
                      ),
                      (
                          'On y Va!',
                          '''Ere We Go',
                          'ORP',
                          NULL,
                          'Relancez les jets de charge ratés pour une figurine avec cette aptitude.',
                          'Re-roll failed charge rolls for this model.',
                          NULL,
                          'EWG3'
                      ),
                      (
                          'Synapse',
                          'Synapse',
                          'TYTP',
                          NULL,
                          'Lers figurines tyranids réussissent automatiquement les tests de sang-froid tant qu''elles sont à 12" d''au moins une figurine amie avec cette aptitude.',
                          'TYRANIDS models automatically pass Nerve tests while within 12" of any friendly models with this ability.',
                          NULL,
                          'SYA'
                      ),
                      (
                          'Ombre dans le Warp',
                          'Shadow in the Warp',
                          'TYTP',
                          NULL,
                          'Soustrayez 1 aux tests psychiques pour les psykers ennemis à 18" d''une figurine avec cette aptitude. Les psykers tyranids ne sont pas affectés.',
                          'Subtract 1 from any psychic tests made for enemy PSYKERS within 18" of a model with this ability. TYRANIDS PSYKERS are not affected.',
                          NULL,
                          'SW'
                      ),
                      (
                          'Réflexes foudroyants',
                          'Lightning Reflexes',
                          'TYB',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 5+.',
                          'This model has a 5+ invulnerable save',
                          NULL,
                          'LR'
                      ),
                      (
                          'Ombre dans le Warp',
                          'Shadow in the Warp',
                          'TYB',
                          NULL,
                          'Soustrayez 1 aux tests psychiques pour les psykers ennemis à 18" d''une figurine avec cette aptitude. Les psykers tyranids ne sont pas affectés.',
                          'Subtract 1 from any psychic tests made for enemy PSYKERS within 18" of a model with this ability. TYRANIDS PSYKERS are not affected.',
                          NULL,
                          'SIW'
                      ),
                      (
                          'Vif et mortel',
                          'Swift and Deadly',
                          'TYB',
                          NULL,
                          'Vous pouvez relancer les jets de charge ratés pour cette figurine.',
                          'You can re-roll failed charge rolls for this model.',
                          NULL,
                          'SD'
                      ),
                      (
                          'Synapse',
                          'Synapse',
                          'TYB',
                          NULL,
                          'Lers figurines tyranids réussissent automatiquement les tests de sang-froid tant qu''elles sont à 12" d''au moins une figurine amie avec cette aptitude.',
                          'TYRANIDS models automatically pass Nerve tests while within 12" of any friendly models with this ability.',
                          NULL,
                          'SYP'
                      ),
                      (
                          'Loyauté aveugle',
                          'Unquestioning Loyalty',
                          'GCZ',
                          NULL,
                          'Jetez un D6 chaque fois que vous utilisez la Tactique de Commandement Attention, Monsieur! sur cette figurine. Sur 2+, vous gagnez un point de commandemennt',
                          'Roll a D6 each time you use the Look Out, Sir! Commander Tactic on this model. On a 2+, you gain a Command Point.',
                          NULL,
                          'UL'
                      ),
                      (
                          'Loyauté aveugle',
                          'Unquestioning Loyalty',
                          'GCP',
                          NULL,
                          'Jetez un D6 chaque fois que vous utilisez la Tactique de Commandement Attention, Monsieur! sur cette figurine. Sur 2+, vous gagnez un point de commandemennt',
                          'Roll a D6 each time you use the Look Out, Sir! Commander Tactic on this model. On a 2+, you gain a Command Point.',
                          NULL,
                          'UL2'
                      ),
                      (
                          'Loyauté aveugle',
                          'Unquestioning Loyalty',
                          'GCH',
                          NULL,
                          'Jetez un D6 chaque fois que vous utilisez la Tactique de Commandement Attention, Monsieur! sur cette figurine. Sur 2+, vous gagnez un point de commandemennt',
                          'Roll a D6 each time you use the Look Out, Sir! Commander Tactic on this model. On a 2+, you gain a Command Point.',
                          NULL,
                          'UL3'
                      ),
                      (
                          'Loyauté aveugle',
                          'Unquestioning Loyalty',
                          'GCA',
                          NULL,
                          'Jetez un D6 chaque fois que vous utilisez la Tactique de Commandement Attention, Monsieur! sur cette figurine. Sur 2+, vous gagnez un point de commandemennt',
                          'Roll a D6 each time you use the Look Out, Sir! Commander Tactic on this model. On a 2+, you gain a Command Point.',
                          NULL,
                          'UL4'
                      ),
                      (
                          'Vif et mortel',
                          'Swift and Deadly',
                          'GCH',
                          NULL,
                          'Vous pouvez relancer les jets de charge ratés pour cette figurine.',
                          'You can re-roll failed charge rolls for this model.',
                          NULL,
                          'SDE'
                      ),
                      (
                          'Réflexes foudroyants',
                          'Lightning Reflexes',
                          'GCH',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 5+.',
                          'This model has a 5+ invulnerable save',
                          NULL,
                          'LRP'
                      ),
                      (
                          'Bannière sacrée du culte',
                          'Sacred Cult Banner',
                          'GCA',
                          NULL,
                          'Vous pouvez relancer les jets de Sang-froid ratés pour les figurines amies à 6" de cette figurine.',
                          'You can re-roll failed Nerve tests for friendly models that are within 6" of this mode!.',
                          NULL,
                          'SCB'
                      );
INSERT OR IGNORE INTO Specialites (
                            NomFr,
                            NomEn,
                            Id
                        )
                        VALUES (
                            'Férocité',
                            'Ferocity',
                            'FR'
                        ),
                        (
                            'Bravoure',
                            'Fortitude',
                            'FE'
                        ),
                        (
                            'Leadership',
                            'Leadership',
                            'LE'
                        ),
                        (
                            'Logistique',
                            'Logistics',
                            'LO'
                        ),
                        (
                            'Mêlée',
                            'Melee',
                            'ME'
                        ),
                        (
                            'Tir',
                            'Shooting',
                            'SH'
                        ),
                        (
                            'Psykers',
                            'Psyker',
                            'P'
                        ),
                        (
                            'Furtivité',
                            'Stealth',
                            'SE'
                        );
INSERT OR IGNORE INTO DeclinaisonSpecialite (
                                      SpecialiteId,
                                      DeclinaisonId
                                  )
                                  VALUES (
                                      'FR',
                                      'AAC'
                                  ),
                                  (
                                      'FE',
                                      'AAC'
                                  ),
                                  (
                                      'LE',
                                      'AAC'
                                  ),
                                  (
                                      'LO',
                                      'AAC'
                                  ),
                                  (
                                      'ME',
                                      'AAC'
                                  ),
                                  (
                                      'SH',
                                      'AAC'
                                  ),
                                  (
                                      'SE',
                                      'AAC'
                                  ),
                                  (
                                      'ST',
                                      'AAC'
                                  ),
                                  (
                                      'F',
                                      'AAC'
                                  ),
                                  (
                                      'FR',
                                      'AAL'
                                  ),
                                  (
                                      'FE',
                                      'AAL'
                                  ),
                                  (
                                      'LE',
                                      'AAL'
                                  ),
                                  (
                                      'ME',
                                      'AAL'
                                  ),
                                  (
                                      'LO',
                                      'AAL'
                                  ),
                                  (
                                      'SH',
                                      'AAL'
                                  ),
                                  (
                                      'SE',
                                      'AAL'
                                  ),
                                  (
                                      'ST',
                                      'AAL'
                                  ),
                                  (
                                      'F',
                                      'AAL'
                                  ),
                                  (
                                      'FR',
                                      'AAH'
                                  ),
                                  (
                                      'FE',
                                      'AAH'
                                  ),
                                  (
                                      'LE',
                                      'AAH'
                                  ),
                                  (
                                      'ME',
                                      'AAH'
                                  ),
                                  (
                                      'SH',
                                      'AAH'
                                  ),
                                  (
                                      'F',
                                      'AAH'
                                  ),
                                  (
                                      'FE',
                                      'AAB'
                                  ),
                                  (
                                      'ME',
                                      'AAB'
                                  ),
                                  (
                                      'P',
                                      'AAB'
                                  ),
                                  (
                                      'SH',
                                      'AAB'
                                  ),
                                  (
                                      'F',
                                      'AAB'
                                  ),
                                  (
                                      'FE',
                                      'DWW'
                                  ),
                                  (
                                      'LE',
                                      'DWW'
                                  ),
                                  (
                                      'LO',
                                      'DWW'
                                  ),
                                  (
                                      'ME',
                                      'DWW'
                                  ),
                                  (
                                      'SH',
                                      'DWW'
                                  ),
                                  (
                                      'ST',
                                      'DWW'
                                  ),
                                  (
                                      'F',
                                      'DWW'
                                  ),
                                  (
                                      'FE',
                                      'GKC'
                                  ),
                                  (
                                      'LE',
                                      'GKC'
                                  ),
                                  (
                                      'ME',
                                      'GKC'
                                  ),
                                  (
                                      'P',
                                      'GKC'
                                  ),
                                  (
                                      'SH',
                                      'GKC'
                                  ),
                                  (
                                      'F',
                                      'GKC'
                                  ),
                                  (
                                      'FE',
                                      'AMC1'
                                  ),
                                  (
                                      'LE',
                                      'AMC1'
                                  ),
                                  (
                                      'LO',
                                      'AMC1'
                                  ),
                                  (
                                      'ME',
                                      'AMC1'
                                  ),
                                  (
                                      'SH',
                                      'AMC1'
                                  ),
                                  (
                                      'ST',
                                      'AMC1'
                                  ),
                                  (
                                      'FE',
                                      'AMC2'
                                  ),
                                  (
                                      'LE',
                                      'AMC2'
                                  ),
                                  (
                                      'LO',
                                      'AMC2'
                                  ),
                                  (
                                      'ME',
                                      'AMC2'
                                  ),
                                  (
                                      'SH',
                                      'AMC2'
                                  ),
                                  (
                                      'ST',
                                      'AMC2'
                                  ),
                                  (
                                      'LE',
                                      'AMP1'
                                  ),
                                  (
                                      'LO',
                                      'AMP1'
                                  ),
                                  (
                                      'SH',
                                      'AMP1'
                                  ),
                                  (
                                      'SE',
                                      'AMP1'
                                  ),
                                  (
                                      'ST',
                                      'AMP1'
                                  ),
                                  (
                                      'LE',
                                      'AMP2'
                                  ),
                                  (
                                      'LO',
                                      'AMP2'
                                  ),
                                  (
                                      'SH',
                                      'AMP2'
                                  ),
                                  (
                                      'SE',
                                      'AMP2'
                                  ),
                                  (
                                      'ST',
                                      'AMP2'
                                  ),
                                  (
                                      'LE',
                                      'AMT'
                                  ),
                                  (
                                      'LO',
                                      'AMT'
                                  ),
                                  (
                                      'SH',
                                      'AMT'
                                  ),
                                  (
                                      'SE',
                                      'AMT'
                                  ),
                                  (
                                      'ST',
                                      'AMT'
                                  ),
                                  (
                                      'FE',
                                      'MET'
                                  ),
                                  (
                                      'LE',
                                      'MET'
                                  ),
                                  (
                                      'LO',
                                      'MET'
                                  ),
                                  (
                                      'SH',
                                      'MET'
                                  ),
                                  (
                                      'ST',
                                      'MET'
                                  ),
                                  (
                                      'F',
                                      'MET'
                                  ),
                                  (
                                      'FE',
                                      'MED'
                                  ),
                                  (
                                      'LE',
                                      'MED'
                                  ),
                                  (
                                      'LO',
                                      'MED'
                                  ),
                                  (
                                      'SH',
                                      'MED'
                                  ),
                                  (
                                      'ST',
                                      'MED'
                                  ),
                                  (
                                      'F',
                                      'MED'
                                  ),
                                  (
                                      'FR',
                                      'HAE'
                                  ),
                                  (
                                      'FE',
                                      'HAE'
                                  ),
                                  (
                                      'LE',
                                      'HAE'
                                  ),
                                  (
                                      'LO',
                                      'HAE'
                                  ),
                                  (
                                      'ME',
                                      'HAE'
                                  ),
                                  (
                                      'SH',
                                      'HAE'
                                  ),
                                  (
                                      'SE',
                                      'HAE'
                                  ),
                                  (
                                      'ST',
                                      'HAE'
                                  ),
                                  (
                                      'F',
                                      'HAE'
                                  ),
                                  (
                                      'FE',
                                      'HAS'
                                  ),
                                  (
                                      'ME',
                                      'HAS'
                                  ),
                                  (
                                      'P',
                                      'HAS'
                                  ),
                                  (
                                      'SH',
                                      'HAS'
                                  ),
                                  (
                                      'F',
                                      'HAS'
                                  ),
                                  (
                                      'FE',
                                      'DGF'
                                  ),
                                  (
                                      'LO',
                                      'DGF'
                                  ),
                                  (
                                      'ME',
                                      'DGF'
                                  ),
                                  (
                                      'F',
                                      'DGF'
                                  ),
                                  (
                                      'FE',
                                      'DGT'
                                  ),
                                  (
                                      'LE',
                                      'DGT'
                                  ),
                                  (
                                      'LO',
                                      'DGT'
                                  ),
                                  (
                                      'ME',
                                      'DGT'
                                  ),
                                  (
                                      'SH',
                                      'DGT'
                                  ),
                                  (
                                      'ST',
                                      'DGT'
                                  ),
                                  (
                                      'F',
                                      'DGT'
                                  ),
                                  (
                                      'FE',
                                      'DGB'
                                  ),
                                  (
                                      'LO',
                                      'DGB'
                                  ),
                                  (
                                      'ME',
                                      'DGB'
                                  ),
                                  (
                                      'SH',
                                      'DGB'
                                  ),
                                  (
                                      'F',
                                      'DGB'
                                  ),
                                  (
                                      'FE',
                                      'DGPS'
                                  ),
                                  (
                                      'LE',
                                      'DGPS'
                                  ),
                                  (
                                      'LO',
                                      'DGPS'
                                  ),
                                  (
                                      'ME',
                                      'DGPS'
                                  ),
                                  (
                                      'SH',
                                      'DGPS'
                                  ),
                                  (
                                      'F',
                                      'DGPS'
                                  ),
                                  (
                                      'FE',
                                      'TSE'
                                  ),
                                  (
                                      'LE',
                                      'TSE'
                                  ),
                                  (
                                      'LO',
                                      'TSE'
                                  ),
                                  (
                                      'ME',
                                      'TSE'
                                  ),
                                  (
                                      'P',
                                      'TSE'
                                  ),
                                  (
                                      'SH',
                                      'TSE'
                                  ),
                                  (
                                      'ST',
                                      'TSE'
                                  ),
                                  (
                                      'F',
                                      'TSE'
                                  ),
                                  (
                                      'FR',
                                      'TSTS'
                                  ),
                                  (
                                      'FE',
                                      'TSTS'
                                  ),
                                  (
                                      'LE',
                                      'TSTS'
                                  ),
                                  (
                                      'ME',
                                      'TSTS'
                                  ),
                                  (
                                      'P',
                                      'TSTS'
                                  ),
                                  (
                                      'ST',
                                      'TSTS'
                                  ),
                                  (
                                      'F',
                                      'TSTS'
                                  ),
                                  (
                                      'FR',
                                      'ASA'
                                  ),
                                  (
                                      'LE',
                                      'ASA'
                                  ),
                                  (
                                      'LO',
                                      'ASA'
                                  ),
                                  (
                                      'ME',
                                      'ASA'
                                  ),
                                  (
                                      'SH',
                                      'ASA'
                                  ),
                                  (
                                      'SE',
                                      'ASA'
                                  ),
                                  (
                                      'ST',
                                      'ASA'
                                  ),
                                  (
                                      'LO',
                                      'ASW'
                                  ),
                                  (
                                      'ME',
                                      'ASW'
                                  ),
                                  (
                                      'P',
                                      'ASW'
                                  ),
                                  (
                                      'SH',
                                      'ASW'
                                  ),
                                  (
                                      'LE',
                                      'ASF'
                                  ),
                                  (
                                      'LO',
                                      'ASF'
                                  ),
                                  (
                                      'P',
                                      'ASF'
                                  ),
                                  (
                                      'ST',
                                      'ASF'
                                  ),
                                  (
                                      'FR',
                                      'DRA'
                                  ),
                                  (
                                      'LE',
                                      'DRA'
                                  ),
                                  (
                                      'LO',
                                      'DRA'
                                  ),
                                  (
                                      'ME',
                                      'DRA'
                                  ),
                                  (
                                      'SH',
                                      'DRA'
                                  ),
                                  (
                                      'SE',
                                      'DRA'
                                  ),
                                  (
                                      'ST',
                                      'DRA'
                                  ),
                                  (
                                      'FR',
                                      'DRS'
                                  ),
                                  (
                                      'ME',
                                      'DRS'
                                  ),
                                  (
                                      'SE',
                                      'DRS'
                                  ),
                                  (
                                      'FR',
                                      'DRH'
                                  ),
                                  (
                                      'FE',
                                      'DRH'
                                  ),
                                  (
                                      'LO',
                                      'DRH'
                                  ),
                                  (
                                      'ME',
                                      'DRH'
                                  ),
                                  (
                                      'F',
                                      'DRH'
                                  ),
                                  (
                                      'FR',
                                      'ART'
                                  ),
                                  (
                                      'LE',
                                      'ART'
                                  ),
                                  (
                                      'ME',
                                      'ART'
                                  ),
                                  (
                                      'SH',
                                      'ART'
                                  ),
                                  (
                                      'SE',
                                      'ART'
                                  ),
                                  (
                                      'ST',
                                      'ART'
                                  ),
                                  (
                                      'FR',
                                      'ARS'
                                  ),
                                  (
                                      'ME',
                                      'ARS'
                                  ),
                                  (
                                      'P',
                                      'ARS'
                                  ),
                                  (
                                      'SH',
                                      'ARS'
                                  ),
                                  (
                                      'SE',
                                      'ARS'
                                  ),
                                  (
                                      'FR',
                                      'ARD'
                                  ),
                                  (
                                      'ME',
                                      'ARD'
                                  ),
                                  (
                                      'SH',
                                      'ARD'
                                  ),
                                  (
                                      'SE',
                                      'ARD'
                                  ),
                                  (
                                      'FE',
                                      'NEO'
                                  ),
                                  (
                                      'LE',
                                      'NEO'
                                  ),
                                  (
                                      'LO',
                                      'NEO'
                                  ),
                                  (
                                      'ME',
                                      'NEO'
                                  ),
                                  (
                                      'SH',
                                      'NEO'
                                  ),
                                  (
                                      'ST',
                                      'NEO'
                                  ),
                                  (
                                      'F',
                                      'NEO'
                                  ),
                                  (
                                      'FE',
                                      'NEY'
                                  ),
                                  (
                                      'LO',
                                      'NEY'
                                  ),
                                  (
                                      'ME',
                                      'NEY'
                                  ),
                                  (
                                      'SH',
                                      'NEY'
                                  ),
                                  (
                                      'ST',
                                      'NEY'
                                  ),
                                  (
                                      'F',
                                      'NEY'
                                  ),
                                  (
                                      'FR',
                                      'ORW'
                                  ),
                                  (
                                      'FE',
                                      'ORW'
                                  ),
                                  (
                                      'LE',
                                      'ORW'
                                  ),
                                  (
                                      'ME',
                                      'ORW'
                                  ),
                                  (
                                      'ST',
                                      'ORW'
                                  ),
                                  (
                                      'F',
                                      'ORW'
                                  ),
                                  (
                                      'FR',
                                      'ORBM'
                                  ),
                                  (
                                      'FE',
                                      'ORBM'
                                  ),
                                  (
                                      'LO',
                                      'ORBM'
                                  ),
                                  (
                                      'ME',
                                      'ORBM'
                                  ),
                                  (
                                      'F',
                                      'ORBM'
                                  ),
                                  (
                                      'FR',
                                      'ORP'
                                  ),
                                  (
                                      'FE',
                                      'ORP'
                                  ),
                                  (
                                      'LO',
                                      'ORP'
                                  ),
                                  (
                                      'ME',
                                      'ORP'
                                  ),
                                  (
                                      'LE',
                                      'TAC'
                                  ),
                                  (
                                      'LO',
                                      'TAC'
                                  ),
                                  (
                                      'SH',
                                      'TAC'
                                  ),
                                  (
                                      'SE',
                                      'TAC'
                                  ),
                                  (
                                      'ST',
                                      'TAC'
                                  ),
                                  (
                                      'LE',
                                      'TAE'
                                  ),
                                  (
                                      'LO',
                                      'TAE'
                                  ),
                                  (
                                      'ST',
                                      'TAE'
                                  ),
                                  (
                                      'FR',
                                      'TYTP'
                                  ),
                                  (
                                      'FE',
                                      'TYTP'
                                  ),
                                  (
                                      'LE',
                                      'TYTP'
                                  ),
                                  (
                                      'ME',
                                      'TYTP'
                                  ),
                                  (
                                      'ST',
                                      'TYTP'
                                  ),
                                  (
                                      'F',
                                      'TYTP'
                                  ),
                                  (
                                      'FR',
                                      'TYB'
                                  ),
                                  (
                                      'FE',
                                      'TYB'
                                  ),
                                  (
                                      'LE',
                                      'TYB'
                                  ),
                                  (
                                      'ME',
                                      'TYB'
                                  ),
                                  (
                                      'P',
                                      'TYB'
                                  ),
                                  (
                                      'SE',
                                      'TYB'
                                  ),
                                  (
                                      'ST',
                                      'TYB'
                                  ),
                                  (
                                      'F',
                                      'TYB'
                                  ),
                                  (
                                      'LE',
                                      'GCZ'
                                  ),
                                  (
                                      'LO',
                                      'GCZ'
                                  ),
                                  (
                                      'P',
                                      'GCZ'
                                  ),
                                  (
                                      'SE',
                                      'GCZ'
                                  ),
                                  (
                                      'FR',
                                      'GCP'
                                  ),
                                  (
                                      'FE',
                                      'GCP'
                                  ),
                                  (
                                      'LE',
                                      'GCP'
                                  ),
                                  (
                                      'LO',
                                      'GCP'
                                  ),
                                  (
                                      'ME',
                                      'GCP'
                                  ),
                                  (
                                      'SH',
                                      'GCP'
                                  ),
                                  (
                                      'SE',
                                      'GCP'
                                  ),
                                  (
                                      'ST',
                                      'GCP'
                                  ),
                                  (
                                      'F',
                                      'GCP'
                                  ),
                                  (
                                      'FR',
                                      'GCH'
                                  ),
                                  (
                                      'FE',
                                      'GCH'
                                  ),
                                  (
                                      'ME',
                                      'GCH'
                                  ),
                                  (
                                      'P',
                                      'GCH'
                                  ),
                                  (
                                      'SE',
                                      'GCH'
                                  ),
                                  (
                                      'F',
                                      'GCH'
                                  ),
                                  (
                                      'FR',
                                      'GCA'
                                  ),
                                  (
                                      'FE',
                                      'GCA'
                                  ),
                                  (
                                      'LE',
                                      'GCA'
                                  ),
                                  (
                                      'ME',
                                      'GCA'
                                  ),
                                  (
                                      'SE',
                                      'GCA'
                                  );

INSERT OR IGNORE INTO Tactiques (
                          Commandant,
                          Aura,
                          DeclinaisonId,
                          SpecialiteId,
                          Point,
                          NomFr,
                          NomEn,
                          Niveau,
                          FactionId,
                          DescriptionFr,
                          DescriptionEn,
                          Id
                      )
                      VALUES (
                          0,
                          0,
                          NULL,
                          'FR',
                          2,
                          'FUREUR DEBRIDEE',
                          'FURY UNLEASHED',
                          3,
                          NULL,
                          'Utilisez cette Tactique à la phase de Combat, avant d''attaquer avec un spécialiste en Férocité de Niveau 3 ou supérieur de votre kill team. Ajoutez 1 aux jets de Trauma que vous effectuez pour 
résoudre les attaques de cette figurine à cette phase.',
                          'Use this Tactic in the Fight phase, before attacking with a Ferocity specialist of Level 3 or higher from your kill team. Add 1 to Injury rolls you make when resolving attacks for this model in this phase.',
                          'FULS'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'FR',
                          1,
                          'AVIDITE MEURTRIERE',
                          'MURDERLUST',
                          1,
                          NULL,
                          'Utilisez cette Tactique quand c''est votre tour de se déplacer à la phase de Mouvement. Un Spécialiste en Férocité de votre kill team qui n''est pas secoué peut tenter une charge contre une figurine ennemie à 15" de lui, et vous pouvez ajouter D3 à son jet de charge. ',
                          'Use this Tactic when it is your turn to move in the Movement phase. A Ferocity specialist from your kill team that is not shaken can make a charge attempt against an enemy model within 15" of them, and you can add D3 to their charge roll. ',
                          'MDL'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'FR',
                          2,
                          'HURLEMENT DE COLERE',
                          'BELLOW OF WRATH',
                          2,
                          NULL,
                          'Utilisez cette Tactique au début de la phase de Moral. A cette phase, vos adversaires doivent relancer les tests de Sang-froid réussis pour les figurines ennemies à 6" d''un spécialiste en Férocité de Niveau 2 ou supérieur de votre kill team qui nest pas secoué. ',
                          'Use this Tactic at the start of the Morale phase. In this phase, your opponent(s) must re-roll successful Nerve tests taken for enemy models within 6" of a Ferocity specialist of Level 2 or higher from your kill team that is not shaken. ',
                          'BOW'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'FE',
                          2,
                          'REFUS DE SUCCOMBER',
                          'REFUSAL TO FALL',
                          3,
                          NULL,
                          'Utilisez cette Tactique lorsque votre adversaire effectue un jet de Trauma pour un spécialiste en Bravoure de Niveau 3 ou supérieur de votre kill team (utilisez la Tactique avant le jet de Trauma). Appliquez un modificateur de -2 à ce jet de Trauma.',
                          'Use this Tactic when your opponent makes an Injury roll for a Fortitude specialist of Level 3 or higher from your kill team ( use the Tactic before the Injury roll is made). Apply a -2 modifier to that Injury roll. ',
                          'RTF'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'FE',
                          1,
                          'CE N''EST QU''UNE EGRATIGNURE',
                          'IT''S JUST A SCRATCH',
                          2,
                          NULL,
                          'Utilisez celle Tactique au début de la phase de Moral. Jetez un D6 pour chaque blessure légère qu''un spécialiste en Bravoure de Niveau 2 ou supérieur de votre kill team a subie. Sur 5+, cette blessure légère est retirée. ',
                          'Use this Tactic at the start of the Morale phase. Roll a D6 for each flesh wound that a Fortitude specialist of Level 2 or higher from your kill team has suffered. On a 5+, that flesh wound is removed.',
                          'IJAS'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'FE',
                          1,
                          'LA DOULEUR EST POUR LES FAIBLES!',
                          'PAIN IS FOR THE WEAK!',
                          1,
                          NULL,
                          'Utilisez cette Tactique lorsqu''un adversaire effectue un jet de Trauma pour une figurine de votre kill team qui est à 3" d''un spécialiste en Bravoure ami (Utilisez cette Tactique avant le jet de Trauma). Soustrayez 1 à tous les dés jetés dans le cadre 
de ce jet de Trauma. ',
                          'Use this Tactic when an opponent makes an Injury roll for a model from your kill team that is within 3" of a friendly Fortitude specialist ( use this Tactic before the Injury roll is made). Subtract 1 from all dice rolled as part of that Injury roll. ',
                          'PIFTW'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'LE',
                          2,
                          'ORATOIRE GALVANISANT',
                          'INSPIRATIAL ORATORY',
                          2,
                          NULL,
                          'Utilisez cette Tactique au début de la phase de 
Moral. Si un spécialiste en Leadership de Niveau 3 ou supérieur de votre kill team est sur le champ de bataille et n''est pas secoué, toutes les figurines amies sur le champ de bataille réussissent automatiquement les tests de Sang-froid à cette phase. ',
                          'Use this Tactic at the start of the Morale phase. As long as a Leadership specialist of Level 3 or higher from your kill team is on the battlefield and not shaken, all friendly models on the battlefield automatically pass Nerve tests made in this phase. ',
                          'IO'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'LE',
                          1,
                          'ABATTEZ-LES',
                          'BRING THEM DOWN!',
                          1,
                          NULL,
                          'Utilisez cette Tactique au début de la phase de Tir.
Choisissez une figurine ennemie visible d''un spécialiste en Leadership de Niveau 2 ou, supérieur
de votre kill team. Vous pouvez relancer les jets de
touche de 1 pour les attaques des figurines amies
effectuées à cette phase et ciblant la figurine choisie.',
                          'Use this Tactic at the start of the Shooting phase. Pick an enemy model that is visible to a Leadership specialist of Level 2 or higher from your kill team. You can re-roll hit rolls of 1 for friendly models'' attacks made in this phase that target the model you picked. ',
                          'BTD'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'LE',
                          1,
                          'COMMANDANT EN SECOND',
                          'SECOND IN COMMAND',
                          1,
                          NULL,
                          'Utilisez cette Tactique au début du round de 
bataille. Jusqu''à la fin du round de bataille, le leader de votre kill team peut utiliser les Tactiques d''Aura de votre Commandant. Dans ce cas, la figurine 
qui gagne l''aptitude d''aura est votre leader, 
et non votre Commandant. ',
                          'Use this Tactic at the start of the battle round. Until the end of the battle round, your kill team''s Leader can use any of your Commander''s Aura Tactics. When they do so, they are the model that gains the aura ability, rather than your Commander. ',
                          'SIC'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'LO',
                          1,
                          'CHAMP REFRACTEUR',
                          'REFRACTOR FIELD',
                          3,
                          NULL,
                          'Utilisez cette Tactique au début du premier round de bataille, avant la phase d''Initiative. Choisissez une figurine de votre kill team; pour la durée de la bataille, elle a une sauvegarde invulnérable de 5+.',
                          'Use this Tactic at the start of the first battle round, before the Initiative phase. Pick a model from your kill team; for the duration of the battle, that model has a 5+ invulnerable save. ',
                          'RF'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'LO',
                          1,
                          'MUNITIONS PERFORMANTES',
                          'ARMOUR-PIERCING AMMUNITION',
                          2,
                          NULL,
                          'Utilisez cette Tactique à la phase de Tir lorsqu''un spécialiste en Logistique de Niveau 2 ou supérieur de votre kill team effectue une attaque de tir avec une arme d''Assaut, à Tir Rapide, Lourde ou Pistolet. Quand vous résolvez les attaques, augmentez de 1 la caractéristique de Force de l''arme, et améliorez sa PA de 1 (ex: PA0 deviant PA-1).',
                          'Use this Tactic in the Shooting phase when a Logistics specialist of Level 2 or higher from your kill team makes a shooting attack with an Assault, Rapid Fire, Heavy or Pistol weapon. When resolving the attacks, increase the weapon''s Strength characteristic by 1, and improve its AP by 1 (e.g. APO becomes AP-1). ',
                          'APA'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'LO',
                          1,
                          'GRAV-CHUTE',
                          'GRAV-CHUTE',
                          1,
                          NULL,
                          'Utilisez cette Tactique au début du premier round de bataille, avant la phase d''Initiative. Choisissez une figurine de votre kill team. Pour la durée de la bataille, cette figurine ne subit jamais de dégâts de chute, et ne chute jamais sur une autre figurine. Si elle devait le faire, placez-la à la place aussi près que possible du point où elle aurait dû atterrir. Cela peut l''amener à l" d''une figurine ennemie.',
                          'Use this Tactic at the start of the first battle round, before the Initiative phase. Pick a model from your kill team. For the duration of the battle, that model never suffers falling damage, and never falls on another model. If it would, instead place that model as close as possible to the point where it would have landed. This can bring it within l" of an enemy model. ',
                          'GVC'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'ME',
                          2,
                          'COUPS BAS',
                          'FIGHT DIRTY',
                          3,
                          NULL,
                          'Utilisez cette Tactique lorsqu''une figurine ennemie effectue des attaques qui ciblent un spécialiste en Mêlée de Niveau 3 ou supérieur de votre kill team à la phase de Combat (utilisez la Tactique avant d''effectuer les jets de touche). Jusqu''à la fin du round, le joueur en contrôle de la figurine ennemie soustrait 2 aux jets de touche des attaques de cette figurine.',
                          'Use this Tactic when an enemy model makes any attacks that target a Melee specialist of Level 3 
or higher from your kill team in the Fight phase 
( use the Tactic before any hit rolls are made). For the rest of the battle round, the enemy model''s controlling player must subtract 2 from hit rolls for that model''s attacks. ',
                          'FSY'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'ME',
                          1,
                          'COUP FRACASSANT',
                          'HAYMAKER',
                          2,
                          NULL,
                          'Utilisez cette Tactique lorsqu''un spécialiste en Mêlée de Niveau 2 ou supérieur de votre kill team effectue une attaque qui cible une figurine ennemie à la phase de Combat (utilisez la tactique avant d''effectuer le jet de touche). Si cette attaque réussit, tout dégât qu''elle inflige est doublé.',
                          'Use this Tactic when a Melee specialist of Level 2 or higher from your kill team makes an attack that targets an enemy model in the Fight phase (use the Tactic before the hit roll is made). If that attack is successful, any damage inflicted is doubled. ',
                          'HMK'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'ME',
                          1,
                          'COUP ETOURDISSANT',
                          'STUNNING BLOW',
                          1,
                          NULL,
                          'Utilisez cette Tactique lorqu''un spécialiste en Mêlée de votre kill team effectue une attaque qui cible une figurine ennemie à la phase de Combat (utilisez la Tactique avant d''effectuer le jet de touche). Si cette attaque touche (que le jet de blessure soit réussi ou non), l''adversaire doit soustraire 1 aux jet de touche de cette figurine jusqu''à la fin du round.',
                          'Use this Tactic when a Melee specialist from your kill team makes an attack that targets an enemy model in the Fight phase (use the Tactic before the hit roll is made). If that attack hits ( whether or not the wound roll is successful), your opponent must subtract 1 from that model''s hit rolls for the rest of the battle round. ',
                          'SB'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'P',
                          2,
                          'BARRAGE PSYCHIQUE',
                          'PSYCHIC BARRAGE',
                          3,
                          NULL,
                          'Utilisez cette Tactique lorsque vous choisissez un spécialiste Psyker de Niveau 3 ou supérieur de votre kill team pour manifester un pouvoir psychique à la phase Psychique. Cette figurine peut tenter de manifester 1 pouvoir supplémentaire à cette phase qu''elle n''a pas déjà tenté de manifester à cette phase. ',
                          'Use this Tactic when you choose a Psyker specialist of Level 3 or higher from your kill team to manifest a psychic power in the Psychic phase. That model can attempt to manifest one additional psychic power in this phase that it has not already attempted to manifest in this phase. ',
                          'PB'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'P',
                          2,
                          'MAITRE DU SAVOIR',
                          'LOREMASTER',
                          2,
                          NULL,
                          'Utilisez celle Tactique au début de la phase
Psychique. Vous pouvez échanger le pouvoir 
psychique qu''un spécialiste Psyker de Niveau  2 ou supérieur de votre kill team connaît (autre que Trait Psychique) pour un nouveau pouvoir généré dans la liste des Pouvoirs Psychiques (p. 17).',
                          'Use this Tactic at the start of the Psychic phase. You can exchange one psychic power that a Psyker specialist of Level 2 or higher from your kill team knows (other than Psybolt) for a new power generated from the Psychic Powers list (pg 17). ',
                          'LM'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'P',
                          1,
                          'CONCENTRATION MENTALE',
                          'MENTAL FOCUS',
                          1,
                          NULL,
                          'Utilisez cette Tactique après avoir manifesté
le pouvoir Trait Psychique avec un spécialiste Psyker de votre kill team. Vous pouvez tenter de manifester Trait Psychique une seconde fois à cette phase. Cette Tactique coûte 1 Point de Commandement à moins que le spécialiste puisse normalement tenter de manifester un seul pouvoir à chaque phase Psychique, auquel car elle coûte 2 Points de Commandement à la place.',
                          'Use this Tactic after a manifesting the Psybolt psychic power with a Psyker specialist from your kill team. You can attempt to manifest Psybolt 
a second time this phase. This Tactic costs 1 Command Point unless the specialist can normally attempt to manifest only one psychic power 
in each Psychic phase, in which case it costs 2 Command Points instead. ',
                          'MF'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'SH',
                          1,
                          'TIR IMPOSSIBLE',
                          'IMPOSSIBLE SHOT',
                          3,
                          NULL,
                          'Utilisez cette Tactique lorsqu''un spécialiste en Tir de Niveau 3 ou supérieur de votre kill team effectue une attaque ciblant une figurine ennemie à la phase de Tir (utilisez la Tactique avant d''effectuer le jet de touche). Ne faites pas de jet de touche; il est automatiquement réussi. Vous ne pouvez pas utiliser cette Tactique au même round que la Tactique Touche Chanceuse. ',
                          'Use this Tactic when a Shooting specialist of Level 3 or higher from your kill team makes an attack that targets an enemy model in the Shooting phase ( use the Tactic before the hit roll is made). Do not make a hit roll - it is automatically successful. You cannot use this Tactic in the same battle round as the Lucky Hit Tactic. ',
                          'IS'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'SH',
                          1,
                          'TOUCHE CHANCEUSE',
                          'LUCKY HIT',
                          2,
                          NULL,
                          'Utilisez cette Tactique lorsqu''un spécialiste en Tir de Niveau 2 ou supérieur de votre kill team effectue une attaque qui touche une figurine ennemie à la phase de Tir ( utiliser la Tactique avant d''effectuer le jet de blessure). Ne faites pas de jet de blessure.
il est automatiquement réussi. ',
                          'Use this Tactic when a Shooting specialist of Level 2 or higher from your kill team makes an attack that hits an enemy model in the Shooting phase ( use the Tactic before the wound roll 
is made). Do not make a wound roll - it is automatically successful. ',
                          'LH'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'SH',
                          1,
                          'DETENTE FACILE',
                          'ITCHY TRIGGER FINGER',
                          1,
                          NULL,
                          'Utilisez cette Tactique au début de la phase de Tir pour Préparer immédiatement un spécialiste en Tir de votre kill team qui n''est ni secoué, ni à l" d''une figurine ennemie. ',
                          'Use this Tactic at the start of the Shooting phase to immediately Ready a Shooting specialist from your kill team that is neither shaken nor within l" of an enemy model. ',
                          'ITF'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'SE',
                          2,
                          'COUP EN TRAITE',
                          'BACKSTAB',
                          3,
                          NULL,
                          'Utilisez cette Tactique à la phase de Combat lorsqu''un spécialiste en Furtivité de Niveau  3 ou supérieur de votre kill team effectue une attaque contre une cible à l" d''au moins une autre figurine amie (avant le jet de touche). Si l''attaque touche, le spécialiste inflige un nombre de blessures mortelles égal à la caractéristique de Dégâts de l''arme;
la séquence d''attaque se termine alors.',
                          'Use this Tactic in the Fight phase when a Stealth specialist of Level 3 or higher from your kill team makes an attack against a target that is within l" of any other friendly model (before the hit roll). If the attack hits, the specialist inflicts a number of mortal wounds on the target equal to the weapon''s Damage characteristic - the attack sequence then ends. ',
                          'BSB2'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'SE',
                          1,
                          'PLONGEON A COUVERT',
                          'DIVE FOR COVER',
                          2,
                          NULL,
                          'Utilisez cette Tactique au début de la phase de Tir si un spécialiste en Furtivité de Niveau 2 ou supérieur de votre kill team est à 2" d''un élément  de terrain. Toutes les figurines ennemies considèrent le spécialiste comme masqué jusqu''à la fin de la phase.',
                          'Use this Tactic at the start of the Shooting phase if a Stealth specialist of Level 2 or higher from your kill team is within 2" of any terrain feature. The specialist is considered to be obscured from all enemy models until the end of the phase. ',
                          'DFC'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'SE',
                          1,
                          'DEPLOIEMENT CACHE',
                          'HIDDEN DEPLOYMENT',
                          1,
                          NULL,
                          'Utilisez cette Tactique au début du premier round de bataille, avant la phase d''Initiative.  Un spécialiste en Furtivité de votre kill team peut immédiatement effectuer un mouvement normal comme à la phase de Mouvement. Cette Tactique ne peut être utilisée qu''une fois par bataille.',
                          'Use this Tactic at the start of the first battle round, before the Initiative phase. A Stealth specialist from your kill team can immediately make a normal move as if it were the Movement phase. You can only use this Tactic once per battle. ',
                          'HD'
                      ),
                      (
                          1,
                          1,
                          'AAC',
                          NULL,
                          1,
                          'Rites de bataille',
                          'Rites of battle',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Tir si votre kill team inclut un Primaris Captain. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez relancer les jets de touche de 1 des figurines amies à 6".',
                          'Use this Tactic at the start of the Shooting phase if your kill team includes a PRIMARIS CAPTAIN. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can re- roll hit rolls of 1 for friendly models within 6" of this model.',
                          'AAC'
                      ),
                      (
                          1,
                          1,
                          'AAL',
                          NULL,
                          1,
                          'Précision tactique',
                          'Tactical precision',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Tir si votre kill team inclut un Primaris Lieutenant. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, Vous pouvez relancer les jets de blessure de 1 des figurines amies à 6".',
                          'Use this Tactic at the start of the Shooting phase if your kill team includes a PRIMARIS LIEUTENANT. That model gains the following aura ability until the end of the battle round:
As long as this model is not shaken, you can re-roll wound rolls of I for friendly models within 6" of this model. ',
                          'AAL'
                      ),
                      (
                          1,
                          1,
                          'AAH',
                          NULL,
                          1,
                          'Chef spirituel',
                          'Spiritual leader',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Mouvement si votre kill team inclut un Primaris Chaplain. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, les figurines amies à 6"peuvent utiliser la caractéristique Commandement de cette figurine à la place de la leur.',
                          'Use this Tactic at the start of the Movement phase if your kill team includes a PRIMARIS CHAPLAIN. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, friendly models within 6" of this model can use this model''s Leadership characteristic instead of their own.',
                          'AAH2'
                      ),
                      (
                          1,
                          1,
                          'DWW',
                          NULL,
                          2,
                          'Maitre de la bataille',
                          'Master of battle',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Tir si votre kill team inclut un Watch Master. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, Vous pouvez relancer les jets de touche ratés des figurines amis à 6".',
                          'Use this Tactic at the start of the Shooting phase if your kill team includes a WATCH MASTER. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can re-roll failed hit rolls for friendly models within 6" of this model.',
                          'DWW'
                      ),
                      (
                          1,
                          1,
                          'AMC1',
                          NULL,
                          1,
                          'Aura de discipline',
                          'Aura of discipline',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de mouvement si votre kill team inclut un Commissar. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, les figurines amies à 6" peuvent utiliser son Commandement au lieu du leur, et réussissent automatiquement leurs tests de sang-froid.',
                          'Use this Tactic at the start of the Movement phase if your kill team includes a COMMISSAR or LORD COMMISSAR. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, friendly models within 6" of this model can use this model''s Leadership characteristic instead of their own, and automatically pass Nerve tests.',
                          'AMC1'
                      ),
                      (
                          1,
                          1,
                          'AMC2',
                          NULL,
                          1,
                          'Aura de discipline',
                          'Aura of discipline',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de mouvement si votre kill team inclut un Lord Commissar. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, les figurines amies à 6" peuvent utiliser son Commandement au lieu du leur, et réussissent automatiquement leurs tests de sang-froid.',
                          'Use this Tactic at the start of the Movement phase if your kill team includes a COMMISSAR or LORD COMMISSAR. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, friendly models within 6" of this model can use this model''s Leadership characteristic instead of their own, and automatically pass Nerve tests.',
                          'AMC2'
                      ),
                      (
                          1,
                          0,
                          'AMP1',
                          NULL,
                          2,
                          'Commandement inspiré',
                          'Inspirational command',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de tir avant de donner l''ordre d''un Platoon Commander de votre kill team (voir le manuel de base de kill team). Cet ordre affect toutes les figurines amies à 6" qui ne sont pas secouées et qui n''ont pas reçu d''autre ordre à ce round. Une figurine ne peut être affectée que par un seul ordre par round, comme d''habitude.',
                          'Use this Tactic at the start of the Shooting 
phase before issuing an order with a PLATOON COMMANDER or COMPANY COMMANDER from your kill team (see the Kill Team Core Manual). When you issue that order, it affects all other friendly models within 6" of that model that are not shaken and have not been issued another order in this battle round. A model may still only be affected by one order per battle round.',
                          'AMP1'
                      ),
                      (
                          1,
                          0,
                          'AMP2',
                          NULL,
                          2,
                          'Commandement inspiré',
                          'Inspirational command',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de tir avant de donner l''ordre d''un Company Commander de votre kill team (voir le manuel de base de kill team). Cet ordre affect toutes les figurines amies à 6" qui ne sont pas secouées et qui n''ont pas reçu d''autre ordre à ce round. Une figurine ne peut être affectée que par un seul ordre par round, comme d''habitude.',
                          'Use this Tactic at the start of the Shooting 
phase before issuing an order with a PLATOON COMMANDER or COMPANY COMMANDER from your kill team (see the Kill Team Core Manual). When you issue that order, it affects all other friendly models within 6" of that model that are not shaken and have not been issued another order in this battle round. A model may still only be affected by one order per battle round.',
                          'AMP2'
                      ),
                      (
                          1,
                          0,
                          'AMT',
                          NULL,
                          1,
                          'Tir de couverture!',
                          'Covering fire!',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Mouvement si votre kill team inclut un Tempestor Prime. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, alors quand les figurines amies à 6" tirent en Alerte, elles touchent sur un jet de 5 ou 6.',
                          'Use this Tactic at the start of the Movement phase if your kill team includes a TEMPESTOR PRIME. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, when friendly models within 6" of this model fire Overwatch, they successfully hit on a roll of 5 or 6.',
                          'AMT'
                      ),
                      (
                          1,
                          1,
                          'MET',
                          NULL,
                          1,
                          'Artisan réparateur',
                          'Repair artisan',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Mouvement si votre kill team inclut un Tech-priest Engineer. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, jetez un D6 à chaque fois qu''une figurine amie à 3" perd un PV. Sur 6, ce PV n''est pas perdu. Si une figurine bénéficie déjà d''un effet similaire, vous pouvez choisir lequel s''applique et relancer un résultat de 1 sur le jet.',
                          'Use this Tactic at the start of the Movement phase if your kill team includes a TECH-PRIEST ENGINSEER. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, roll a D6 each time a friendly model within 3" of this model loses a wound. On a 6 that wound is not lost. If a model already has an ability with a similar effect, you can choose which effect applies, and re-roll ls when making these rolls.',
                          'MET'
                      ),
                      (
                          1,
                          1,
                          'MED',
                          NULL,
                          1,
                          'Seigneur du culte-machine',
                          'Lord of the machine cult',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Tir si votre kill team inclut un Tech-priest Dominus. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez relancer en phase de tir les jets de touche de 1 des figurines amies à 6".',
                          'Use this Tactic at the start of the Shooting phase if your kill team includes a TucH-PRIEST DoMINUS. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can re-roll hit rolls of 1 in the Shooting phase for friendly models within 6" of this model.',
                          'MED'
                      ),
                      (
                          1,
                          1,
                          'HAE',
                          NULL,
                          1,
                          'Aspire à la gloire',
                          'Aspire to glory',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Tir si votre kill team inclut un Exalted Champion. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez relancer les jets de blessure de 1 des figurines amies à 6".',
                          'Use this Tactic at the start of the Shooting phase if your kill team includes an EXALTED CHAMPION. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can re-roll wound rolls of 1 for friendly models within 6" of this model.',
                          'HAE'
                      ),
                      (
                          1,
                          1,
                          'DGF',
                          NULL,
                          1,
                          'Puanteur révoltante',
                          'Revolting stench',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Combat si votre kill team inclut un Foul Blightspawn. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, les figurines ennemies ayant chargé à ce tour et étant à 3" de cette figurine au début de la phase de combat ne peuvent pas être choisies pour combattre pendant la section Marteau de la Fureur de la phase de combat, mais peuvent à la place combattre pendant la section Combattez pour vos vies. Cette aptitude affecte aussi les figurines ayant une aptitude leur permettant de combattre pendant la section Marteau de Fureur comme si elles avaient chargé.',
                          'Use this Tactic at the start of the Fight phase if your kill team includes a FouL BLIGHTSPAWN. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, enemy models that charged this turn and are within 3" of this model at the start of the Fight phase cannot be chosen to fight in the Hammer of Wrath section of the Fight phase, but can be chosen to fight in the Fight For Your Lives section instead. This ability also affects models that have abilities that would enable them to fight in the Hammer of Wrath section as if they had charged. ',
                          'DGF'
                      ),
                      (
                          1,
                          1,
                          'DGT',
                          NULL,
                          1,
                          'Zélote fétide',
                          'Festering zealot',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Combat si votre kill team inclut un Tallyman. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, Vous pouvez relancer les jets de touche ratés en phase de combat pour les figurines amies à 7" de cette figurine.',
                          'Use this Tactic at the start of the Fight phase if your kill team includes a TALLYMAN. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can re­roll failed hit rolls in the Fight phase for friendly models within 7" of this model.',
                          'DGT'
                      ),
                      (
                          1,
                          1,
                          'DGB',
                          NULL,
                          1,
                          'Râteliers à peste',
                          'Blight racks',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Combat si votre kill team inclut un iologus Putrifier. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, améliorez de 1 la Force et les Dégâts des grenades buboniques portées par les figurines amies Death Guard à 3" de cette figurine. De plus, tant qu''une figurine amie est à 3" de cette figurine, chaque jet de blessure de 6+ obtenu avec ses grenades buboniques inflige une blessure mortelle à la cible en plus des dégâts normaux.',
                          'Use this Tactic at the start of the Fight phase if your kill team includes a BIOLOGUS PU TRIFIER. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, increase the Strength and Damage characteristics of all blight grenades carried by friendly DEATH GUARD models by 1 whilst they are within 3" of this model. In addition, whilst a friendly model is within 3" of this model, each wound roll of 6+ made for that model when it attacks with a blight grenade inflicts a mortal wound on the target in addition to any other damage.',
                          'DGB'
                      ),
                      (
                          1,
                          1,
                          'DGPS',
                          NULL,
                          1,
                          'Narthecium corrompu',
                          'Tainted Narthecium',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Combat si votre kill team inclut un Plague Surgeon. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez relancer les jets de 1 d''Affreusement résistsant des figurines amies à 3".',
                          'Use this Tactic at the start of the Fight phase if your kill team includes a PLAGUE SURGEON. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you may re­roll any Disgustingly Resilient rolls of 1 made for friendly models within 3" of this model.',
                          'DGPS'
                      ),
                      (
                          1,
                          1,
                          'ASA',
                          NULL,
                          1,
                          'La voie du commandement',
                          'The path of command',
                          0,
                          NULL,
                          'Utilisez cette tactique au début d''un round de bataille si votre kill team inclut un Autarch. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez relancer les jets de touche de 1 des figurines amies qui sont à 6" de cette figurine.',
                          'Use this Tactic at the start of the battle round if your kill team includes an AUTARCH. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can re­roll hit rolls of 1 for friendly models within 6" of this model.',
                          'ASA'
                      ),
                      (
                          1,
                          1,
                          'DRA',
                          NULL,
                          1,
                          'Seigneur suprême',
                          'Overlord',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Tir si votre kill team inclut un Archon. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez relancer les jets de touche de 1 des figurines amies à 6" de cette figurine.',
                          'Use this Tactic at the start of the Shooting phase if your kill team includes an ARCHON. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can re­roll hit rolls of 1 for friendly models within 6" of this model.',
                          'DRA'
                      ),
                      (
                          1,
                          1,
                          'DRS',
                          NULL,
                          1,
                          'Epouse de la mort',
                          'Bride of death',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Combat si votre kill team inclut un Succubus. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez relancer les jets de touche de 1 des figurines amies à 6" de cette figurine.',
                          'Use this Tactic at the start of the Fight phase if your kill team includes a SuccuBus. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can re­roll hit rolls of 1 for friendly models within 6" of this model. ',
                          'DRS'
                      ),
                      (
                          1,
                          1,
                          'DRH',
                          NULL,
                          1,
                          'Maitre de la douleur',
                          'Master of pain',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Mouvement si votre kill team inclut un Haemonculus. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, ajoutez 1 à la caractéristique d''Endurance des figurines amies à 6" de cette figurine.',
                          'Use this Tactic at the start of the Movement phase if your kill team includes a HAEMONCULUS. That model gains the following aura ability until the end of the battle round:
As long as this model is not shaken, add 1 to the Toughness characteristic of friendly models within 6" of this model.',
                          'DRH'
                      ),
                      (
                          1,
                          1,
                          'ART',
                          NULL,
                          1,
                          'Chorégraphe de guerre',
                          'Choregrapher of war',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Combat si votre kill team inclut un Troupe Master. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez relancer les jets de blessure ratés des figurines amies qui sont à 6" de cette figurine.',
                          'Use this Tactic at the start of the Fight phase if your kill team includes a TROUPE MASTER. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can re-roll failed wound rolls for friendly models that are within 6" of this model.',
                          'ART'
                      ),
                      (
                          1,
                          1,
                          'ARD',
                          NULL,
                          1,
                          'L''art du meurtre',
                          'The art of the kill',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Tir si votre kill team inclut un Death Jester. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez ajouter 1 aux jets de blessure des figurines amies à 6" de cette figurine.',
                          'Use this Tactic at the start of the Shooting phase if your kill team includes a DEATH JESTER. That model gains the following aura ability until the end of the phase: 
As long as this model is not shaken, you can add 1 to wound rolls for friendly models that are within 6" of this model. ',
                          'ARD'
                      ),
                      (
                          1,
                          1,
                          'NEO',
                          NULL,
                          2,
                          'Que ma volonté s''accomplisse',
                          'My will be done',
                          0,
                          NULL,
                          'Utilisez cette tactique au début d''un round de bataille si votre kill team inclut un Overlord. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez ajouter 1 aux jets d''avance, de charge et de touche pour les figurines amies à 6" de cette figurine.',
                          'Use this Tactic at the start of the battle round if your kill team includes an OVERLORD. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can add 1 to Advance, charge and hit rolls for friendly models within 6" of this model. ',
                          'NEO'
                      ),
                      (
                          1,
                          1,
                          'NEY',
                          NULL,
                          1,
                          'Chronométron',
                          'Chronometron',
                          0,
                          NULL,
                          'Utilisez cette tactique au début du round de bataille si votre kill team inclut un Cryptek. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée,les figurines amies à 3" de cette figurine ont une sauvegarde invulnérable de 5+.',
                          'Use this Tactic at the start of the battle round if your kill team includes a CRYPTEK. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, friendly models within 3" of this model have a 5+ invulnerable save. ',
                          'NEY'
                      ),
                      (
                          1,
                          1,
                          'ORW',
                          NULL,
                          2,
                          'Méga-Waaagh!',
                          'Mega-Waaagh!',
                          0,
                          NULL,
                          'Utilisez cette tactique au début du round de bataille si votre kill team inclut un Warboss. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez jeter 3D6 au lieu de 2D6 lorsque vous effectuez des jets de charge pour les figurines amies à 63 de cette figurine, et ignorez le résultat le plus bas.',
                          'Use this Tactic at the start of the battle round if your kill team includes a WARBOSS. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you may roll 3D6 instead of2D6 when making charge rolls 
for friendly models within 6" of this model, and discard the lowest result. ',
                          'ORW'
                      ),
                      (
                          1,
                          1,
                          'ORBM',
                          NULL,
                          2,
                          'Champ de force kustom',
                          'Kustom force field',
                          0,
                          NULL,
                          'Utilisez cette tactique au début du round de bataille si votre kill team inclut un Big Mek avec un champ de force kustom. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, les figurines amies à 6" de cette figurine ont une sauvegarde invulnérable de 5+ contre les attaques de tir.',
                          'Use this Tactic at the start of the battle round if your kill team includes a BrG MEK with a kustom force field. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, friendly models within 6" of this model have a 5+ invulnerable save against shooting attacks.',
                          'ORBM'
                      ),
                      (
                          1,
                          1,
                          'ORP',
                          NULL,
                          1,
                          'Outils de dok',
                          'Dok''s tools',
                          0,
                          NULL,
                          'Utilisez cette tactique au début du round de bataille si votre kill team inclut un Painboy. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, jetez un D6 chaque fois qu''une figurine amie à 3" de cette figurine perd un PV. Sur 6+, ce PV n''est pas perdu (si la figurine a déjà une aptitude ayant un effet similaire, vous pouvez choisir quel effet s''applique, et relancer les 1 quand vous effectuez ces jets). De plus, tant que cette figurine n''est pas secouée à la fin de la phase de Mouvement, vous pouvez retirer une blessure légère à une figurine amie à 3" de cette figurine.',
                          'Use this Tactic at the start of the battle round if your kill team includes a PAINBOY. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, roll a D6 each time a friendly model within 3" of this model loses a wound. On a 6+ that wound is not lost 
(if a model already has an ability with a similar effect, you can choose which effect applies, and re-roll ls when making these rolls). In addition, as long as this model is not shaken at the end of the Movement phase, you can remove one flesh wound from a friendly model within 3" of this model. ',
                          'ORP'
                      ),
                      (
                          1,
                          1,
                          'TAC',
                          NULL,
                          1,
                          'Feu redoublé',
                          'Volley fire',
                          0,
                          NULL,
                          'Utilisez cette tactique au début du round de bataille si votre kill team inclut un Cadre Fireblade. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, les figurines amies à 6" de cette figurine peuvent effectuer un tir supplémentaire avec leurs pistolets, carabines et fusils à impulsions lorsqu''elles tirent sur une cible à mi-portée de l''arme.',
                          'Use this Tactic at the start of the battle round if your kill team includes a CADRE FIREBLADE. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, friendly models within 6" of this model may fire an extra shot with pulse pistols, pulse carbines and pulse rifles when shooting at a target within half the weapon''s range. ',
                          'TAC'
                      ),
                      (
                          1,
                          1,
                          'TAE',
                          NULL,
                          1,
                          'L''échec n''est pas envisageable',
                          'Failure is notan option',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Mouvement si votre kill team inclut un Ethereal. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, les figurines amies à 6" de cette figurine peuvent utiliser le Commandement de cette figurine au lieu du leur.',
                          'Use this Tactic at the start of the Movement phase if your kill team includes an ETHEREAL. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, friendly models within 6" of this model can use this model''s Leadership characteristic instead of their own.',
                          'TAE'
                      ),
                      (
                          1,
                          1,
                          'TYTP',
                          NULL,
                          1,
                          'Guerrier Alpha',
                          'Alpha warrior',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Tir si votre kill team inclut un Tyranid Prime. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouveez ajouter 1 aux jets de touche pour les figurines amies à 6" de cette figurine.',
                          'Use this Tactic at the start of the Shooting phase if your kill team includes a TYRANID PRIME. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can add1 to hit rolls for friendly models within 6" of this model.',
                          'TYTP'
                      ),
                      (
                          1,
                          1,
                          'GCP',
                          NULL,
                          1,
                          'Démagogue du culte',
                          'Cult demagogue',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de mouvement si votre kill team inclut un Primus. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez ajouter 1 aux jets de touche à la phase de Combat pour les figurines amies qui se trouvent à 6" de cette figurine.',
                          'Use this Tactic at the start of the Movement phase if your kill team includes a PRIMUS. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can add 1 to hit rolls in the Fight phase for friendly models that are within 6" of this model.',
                          'GCP'
                      ),
                      (
                          1,
                          1,
                          'GCA',
                          NULL,
                          1,
                          'Nexus de dévotion',
                          'Nexus of devotion',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Mouvement si votre kill team inclut un Acolyte Iconward. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez jeter un D6 chaque fois qu''une figurine amie à 6" de cette figurine perd un PV. Sur un 6, le PV n''est pas perdu. Si une figurine a déjà une aptitude avec un effet similaire, vous pouvez choisir quel effet s''applique, et relancer les 1 quand vous effectuez ces jets.',
                          'Use this Tactic at the start of the Movement phase if your kill team includes an ACOLYTE lCONWARD. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can roll a D6 each time a friendly model within 6" of this model loses a wound; on a 6 the wound is not lost. If a model already has an ability with a similar effect, you can choose which effect applies, and re­roll ls when making these rolls.',
                          'GCA'
                      ),
                      (
                          1,
                          1,
                          'AAH',
                          NULL,
                          1,
                          'Litanies de haine',
                          'Litanies of hate',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Combat si votre kill team inclut un Primaris Chaplain. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez relancer les jets de touche ratés en phase de Combat des figurines amies à 6".',
                          'Use this Tactic at the start of the Fight phase if your kill team includes a PRIMARIS CHAPLAIN. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can re­roll failed hit rolls in the Fight phase for friendly models within 6" of this model.',
                          'AAH'
                      ),
                      (
                          1,
                          0,
                          'NEO',
                          NULL,
                          3,
                          'Orbe de résurrection',
                          'Resurrection orb',
                          0,
                          NULL,
                          'Utilisez cette tactique à la fin de la phase de moral si un Overlord de votre kill team est sur le champ de bataille et n''est pas secoué. Choisissez une figurine amie hors de combat et jetez un D6; sur 2+, placez cette figurine ayant 1 point de vie restant et aucune blessure légère n''importe où à 3" de l''Overlord qui est à plus de 1" des figurines ennemies. Cette tactique ne peut être utilisée qu''une fois par bataille.',
                          'Use this Tactic at the end of the Morale phase if an OVERLORD from your kill team is on the battlefield and not shaken. Pick a friendly model that is out of action and roll a D6; on a 2+, set up that model with 1 wound remaining and no flesh wounds anywhere within 3" of the OVERLORD that is more than 1" from enemy models. This Tactic can only be used once per battle. ',
                          'NEO2'
                      ),
                      (
                          1,
                          1,
                          'NEY',
                          NULL,
                          1,
                          'Technomancien',
                          'Technomancer',
                          0,
                          NULL,
                          'Utilisez cette tactique au début du round de bataille si votre kill team inclut un Cryptek. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez ignorer la pénalité aux jet sde touche pour 1 blessure légère subie par des figurines amies à 6" de cette figurine.',
                          'Use this Tactic at the start of the battle round if your kill team includes a CRYPTEK. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can ignore the penalty to hit rolls for one flesh wound suffered by friendly models within 6" of this model. ',
                          'NEY2'
                      ),
                      (
                          1,
                          1,
                          'TAE',
                          NULL,
                          1,
                          'Typhon de feu',
                          'Storm of fire',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Tir si votre kill team inclut un Ethereal. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez relancer les jets de touche de 1 pour les figurines amies à 6" de cette figurine.',
                          'Use this Tactic at the start of the Shooting phase if your kill team includes an ETHEREAL. That model gains the following aura ability until the end of the phase: 
As long as this model is not shaken, you can re­roll hit rolls of 1 for friendly models within 6" of this model. ',
                          'TAE2'
                      ),
                      (
                          1,
                          1,
                          'TAE',
                          NULL,
                          1,
                          'Dureté de la pierre',
                          'Sense of stone',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Mouvement si votre kill team inclut un Ethereal. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, jetez un D6 chaque fois qu''une figurine amie à 6" de cette figurine perd 1 PV. Sur un 6 ce PV n''est pas perdu. Si une figurine a déjà une aptitude avec un effet similaire, vous pouvez choisir quel effet s''applique, et relancer les 1 quand vous effectuez ces jets.',
                          'Use this Tactic at the start of the Movement phase if your kill team includes an ETHEREAL. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, roll a D6 each time a friendly model within 6" of this model loses a wound. On a 6 that wound is not lost. If a model already has an ability with a similar effect, you can choose which effect applies, and re-roll ls when making these rolls. ',
                          'TAE3'
                      ),
                      (
                          1,
                          1,
                          'TAE',
                          NULL,
                          1,
                          'Grâce du zéphyr',
                          'Zephyr''s grace',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Mouvement si votre kill team inclut un Ethereal. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez choisir de relancer n''importe quels jets d''Avance ou de charge pour les figurines amies à 6" de cette figurine.',
                          'Use this Tactic at the start of the Movement phase if your kill team includes an ETHEREAL. That model gains the following aura ability until the end of the phase: 
As long as this model is not shaken, you can choose to re-roll any Advance or charge rolls for friendly models within 6" of this model. ',
                          'TAE4'
                      ),
                      (
                          1,
                          0,
                          'GCP',
                          NULL,
                          2,
                          'Planificateur méticuleux',
                          'Meticulous planning',
                          0,
                          NULL,
                          'Utilisez cette tactique au début du premier round de bataille si votre kill team inclut un Primus. Jetez un D6 pour chaque figurine de votre kill team qui ne s''est pas déplacée grâce à l''aptitude Embuscade du culte. Sur 5+, vous pouvez déplacer cette figurine comme indiqué dans son aptitude Embuscade du Culte.',
                          'Use this Tactic at the start of the first battle round if your kill team includes a PRIMUS. Roll a D6 for each model from your kill team that did not move as a result of the Cult Ambush ability. On a roll of 5+, you can move that model as described in its Cult Ambush ability. ',
                          'GCP2'
                      );
								  
								  
INSERT OR IGNORE INTO DeclinaisonArme (
                                ArmeId,
                                DeclinaisonId
                            )
                            VALUES (
                                'PB',
                                'AAC'
                            ),
                            (
                                'FBAM',
                                'AAC'
                            ),
                            (
                                'GK',
                                'AAC'
                            ),
                            (
                                'GF',
                                'AAC'
                            ),
                            (
                                'GK',
                                'AAL'
                            ),
                            (
                                'GF',
                                'AAL'
                            ),
                            (
                                'PB',
                                'AAL'
                            ),
                            (
                                'FBAM',
                                'AAL'
                            ),
                            (
                                'GK',
                                'AAH'
                            ),
                            (
                                'GF',
                                'AAH'
                            ),
                            (
                                'PBA',
                                'AAH'
                            ),
                            (
                                'CA',
                                'AAH'
                            ),
                            (
                                'GK',
                                'AAB'
                            ),
                            (
                                'GF',
                                'AAB'
                            ),
                            (
                                'PB',
                                'AAB'
                            ),
                            (
                                'FS',
                                'AAB'
                            ),
                            (
                                'GK',
                                'DWW'
                            ),
                            (
                                'GF',
                                'DWW'
                            ),
                            (
                                'GSE',
                                'DWW'
                            ),
                            (
                                'GAP',
                                'GKC'
                            ),
                            (
                                'GK',
                                'GKC'
                            ),
                            (
                                'GF',
                                'GKC'
                            ),
                            (
                                'BOST',
                                'GKC'
                            ),
                            (
                                'EFN',
                                'GKC'
                            ),
                            (
                                'PB',
                                'AMC2'
                            ),
                            (
                                'PB',
                                'AMC1'
                            ),
                            (
                                'GF',
                                'AMP2'
                            ),
                            (
                                'PLS',
                                'AMP2'
                            ),
                            (
                                'GF',
                                'AMP1'
                            ),
                            (
                                'PLS',
                                'AMP1'
                            ),
                            (
                                'SA',
                                'MET'
                            ),
                            (
                                'OA',
                                'MET'
                            ),
                            (
                                'PLS',
                                'MET'
                            ),
                            (
                                'M',
                                'MED'
                            ),
                            (
                                'OA',
                                'MED'
                            ),
                            (
                                'VB',
                                'MED'
                            ),
                            (
                                'GK',
                                'HAE'
                            ),
                            (
                                'GF',
                                'HAE'
                            ),
                            (
                                'PB',
                                'HAE'
                            ),
                            (
                                'EPT',
                                'HAE'
                            ),
                            (
                                'GK',
                                'HAS'
                            ),
                            (
                                'GF',
                                'HAS'
                            ),
                            (
                                'PB',
                                'HAS'
                            ),
                            (
                                'FS',
                                'HAS'
                            ),
                            (
                                'GK',
                                'DGF'
                            ),
                            (
                                'GBU',
                                'DGF'
                            ),
                            (
                                'PSR',
                                'DGF'
                            ),
                            (
                                'GK',
                                'DGT'
                            ),
                            (
                                'GBU',
                                'DGT'
                            ),
                            (
                                'PP',
                                'DGT'
                            ),
                            (
                                'GK',
                                'DGB'
                            ),
                            (
                                'HBG',
                                'DGB'
                            ),
                            (
                                'IP',
                                'DGB'
                            ),
                            (
                                'CP',
                                'DGB'
                            ),
                            (
                                'GK',
                                'DGPS'
                            ),
                            (
                                'GBU',
                                'DGPS'
                            ),
                            (
                                'B',
                                'DGPS'
                            ),
                            (
                                'PB',
                                'DGPS'
                            ),
                            (
                                'GK',
                                'TSE'
                            ),
                            (
                                'GF',
                                'TSE'
                            ),
                            (
                                'PBI',
                                'TSE'
                            ),
                            (
                                'SCF',
                                'TSE'
                            ),
                            (
                                'SCF',
                                'TSTS'
                            ),
                            (
                                'GPL',
                                'ASA'
                            ),
                            (
                                'SG',
                                'ASA'
                            ),
                            (
                                'W',
                                'ASW'
                            ),
                            (
                                'PSH',
                                'ASW'
                            ),
                            (
                                'W',
                                'ASF'
                            ),
                            (
                                'PSH',
                                'ASF'
                            ),
                            (
                                'H',
                                'DRA'
                            ),
                            (
                                'PEC',
                                'DRA'
                            ),
                            (
                                'SP',
                                'DRH'
                            ),
                            (
                                'NEU',
                                'DRS'
                            ),
                            (
                                'AG',
                                'DRS'
                            ),
                            (
                                'HT',
                                'DRH'
                            ),
                            (
                                'GPL',
                                'ART'
                            ),
                            (
                                'LHA',
                                'ART'
                            ),
                            (
                                'PSH',
                                'ART'
                            ),
                            (
                                'MS',
                                'ARS'
                            ),
                            (
                                'HGL',
                                'ARS'
                            ),
                            (
                                'PSH',
                                'ARS'
                            ),
                            (
                                'SC',
                                'ARD'
                            ),
                            (
                                'V',
                                'NEO'
                            ),
                            (
                                'SOL',
                                'NEY'
                            ),
                            (
                                'FRM',
                                'ORW'
                            ),
                            (
                                'GKK',
                                'ORW'
                            ),
                            (
                                'KS',
                                'ORW'
                            ),
                            (
                                'FRM',
                                'ORBM'
                            ),
                            (
                                'KK',
                                'ORBM'
                            ),
                            (
                                'KAL',
                                'ORBM'
                            ),
                            (
                                'US',
                                'ORP'
                            ),
                            (
                                'PEK',
                                'ORP'
                            ),
                            (
                                'GPH',
                                'TAC'
                            ),
                            (
                                'FIM',
                                'TAC'
                            ),
                            (
                                'DLA',
                                'TAC'
                            ),
                            (
                                'HB',
                                'TAE'
                            ),
                            (
                                'DEV',
                                'TYTP'
                            ),
                            (
                                'GTR',
                                'TYTP'
                            ),
                            (
                                'MRC',
                                'TYB'
                            ),
                            (
                                'SCF',
                                'GCZ'
                            ),
                            (
                                'PMI',
                                'GCZ'
                            ),
                            (
                                'CHE',
                                'GCP'
                            ),
                            (
                                'TIC',
                                'GCP'
                            ),
                            (
                                'EPO',
                                'GCP'
                            ),
                            (
                                'NP',
                                'GCP'
                            ),
                            (
                                'MRC',
                                'GCH'
                            ),
                            (
                                'PMI',
                                'GCA'
                            ),
                            (
                                'CHE',
                                'GCA'
                            ),
                            (
                                'SFO',
                                'GCA'
                            ),
                            (
                                'PRL',
                                'AMT'
                            ),
                            (
                                'GF',
                                'AMT'
                            );
INSERT OR IGNORE INTO Pouvoirs (
                         SpecialiteId,
                         PrecedentId,
                         NomFr,
                         NomEn,
                         DescriptionFr,
                         DescriptionEn,
                         Id
                     )
                     VALUES (
                         'SE',
                         NULL,
                         'Visée assurée',
                         'Steady Aim',
                         'Cette figurine compte toujours comme Préparée à la phase de tir à condition de ne pas s''être déplacé ou d''avoir effectué un mouvement normal ne dépassant pas la moitié de sa caractéristique de Mouvement à la phase de Mouvement de ce round de bataille.',
                         'This model always counts as Readied in the shooting phase provided that it remained stationary or made a normal move of no more than half of its move Characteristic in the Movement phase of this battle round.',
                         'SE1'
                     ),
                     (
                         'SE',
                         'SE1',
                         'Dissimulé',
                         'Skulker',
                         'Si cette figurine est complètement visible mais à 1" d''un quelconque terrain, elle est considérée comme étant masquée.',
                         'If this model is completely visible but within 1" of any terrain it is considered to be obscured.',
                         'SE21'
                     ),
                     (
                         'SE',
                         'SE1',
                         'Grimpeur',
                         'Climber',
                         'Si cette figurine escalade une distance (vers le haut ou le bas) lors d''un mouvement normal, divisez par deux la distance parcourue (ex: grimper un mur de 4" compte comme 2" parcourus).',
                         'If this model climbs any distance vertically (up or down) when making a normal move, halve the distance moved (e.g.
climbing up a 4" wall counts as 2").',
                         'SE22'
                     ),
                     (
                         'SE',
                         'SE21',
                         'Un avec les ombres',
                         'One with the Shadows',
                         'Si cette figurine est masquée lorsqu''elle est ciblée à la phase de Tir, votre adversaire doit soustraire 1 aux jets de touche de la figurine qui tire (en plus de tout autre modificateur).',
                         'If this model is obscured when it is targeted in the Shooting phase, your opponent must subtract 1 from the firing model''s hit rolls (in addition to any other modifiers). ',
                         'SE31'
                     ),
                     (
                         'SE',
                         'SE21',
                         'Rôdeur',
                         'Lurker',
                         'Jetez un D6 chaque fois que cette figurine perd un PV à la phase de Tir lorsqu''elle est masquée du tireur. Sur 5+, ce PV n''est pas perdu. Si une figurine a déjà une aptitude avec un effet similaire (ex: Affreusement Résistant), choisissez l''effet qui
s''applique, et relancez les 1 obtenus sur ces jets.',
                         'Roll a D6 Each time this model loses a wound in the Shooting phase when
it is obscured from the attacking model. On a 5+ that wound is not lost. If a model already has a similar ability (e.g. Disgustingly Resilient), choose which effect applies, and re-roll 1s when making these rolls.',
                         'SE32'
                     ),
                     (
                         'SE',
                         'SE22',
                         'Rampeur',
                         'Prowler',
                         'Les figurines ennemies ne peuvent pas tirer en Etat d''Alerte sur cette figurine si elle était à 6" d''elles au début de votre tour à la phase de Mouvement.',
                         'Enemy models cannot fire Overwatch at this model if it was within 6" of them at the start of your turn in the Movement phase.',
                         'SE33'
                     ),
                     (
                         'SE',
                         'SE22',
                         'Sûr de ses appuis',
                         'Sure-footed',
                         'Cette figurine n''est jamais affectée par le terrain difficile, le terrain dangereux ou les élements de terrain qui ont été piégés à la phase de reconnaissance.',
                         'This model is never affected by difficult terrain, dangerous terrain, or terrain pieces that were booby-trapped in the Scouting phase. ',
                         'SE34'
                     ),
                     (
                         'SH',
                         NULL,
                         'As du tir',
                         'Shootist',
                         'Relancez les jets de touche de 1 pour cette figurine lorsqu''elle effectue une attaque de tir.',
                         'Re-roll hit rolls of 1 for this model when it makes a shooting attack. ',
                         'SH1'
                     ),
                     (
                         'SH',
                         'SH1',
                         'Tireur malin',
                         'Trick-shooter',
                         'Cette figure ne subit pas de pénalité à ses jets de touche parce que sa cible est masquée.',
                         'This model does not suffer penalties to their hit rolls due to thier target being obscured.',
                         'SH21'
                     ),
                     (
                         'SH',
                         'SH1',
                         'As du pistolet',
                         'Pistoleer',
                         'Cette figurine peut tirer deux fois avec 1 pistolet dont elle est équipée à la phase de tir; après avoir tiré avec son Pistolet une première fois, tirer immédiatement avec de nouveau.',
                         'This model can shoot twice with one Pistol weapon they are armed with in the Shooting phase; after they have shot their Pistol a first time, immediately shoot with it again.',
                         'SH22'
                     ),
                     (
                         'SH',
                         'SH21',
                         'Ciblage des points faibles',
                         'Targeting Weak',
                         'Ajoutez 1 aux jets de blessure pour les attaques de cette figurine lorsqu''elle effectue une attaque de tir. ',
                         'Add 1 to wound rolls for this model''s attacks when it makes a shooting attack. ',
                         'SH31'
                     ),
                     (
                         'SH',
                         'SH21',
                         'Tir de précision',
                         'Precision Strike',
                         'A chaque jet de blessure de 6+ obtenu pour une attaque de cette figurine à la phase de tir, infligez à la cible un nombre de blessures mortelles égal à la caractéristique de Dégâts de l''arme; la séquence d''attaque se termine alors.',
                         'Each time you make 
a wound roll of 6+ for this model''s attack in the Shooting phase, inflict a number of mortal wounds on the target equal to the weapon''s Damage characteristic - the attack sequence then ends. ',
                         'SH32'
                     ),
                     (
                         'SH',
                         'SH22',
                         'Tir au jugé',
                         'Hip Shooter',
                         'Cette figurine peut tirer avec une arme d''assaut, à Tir Rapide ou pistolet à la phase de tir (ou réagir pour tirer en état d''alerte) même si elle a avancé à ce round de bataille. Si elle le fait, soustrayez 1 aux jets de touche effectués en tirant avec cette arme sauf si c''est une arme d''assaut.',
                         'This model can shoot an Assault, Rapid Fire or Pistol weapon in the Shooting phase (or React to fire Overwatch) even if it Advanced earlier that battle round. If it does so, you must subtract 1 from any hit rolls made when firing that weapon unless it is an Assault weapon.  ',
                         'SH33'
                     ),
                     (
                         'SH',
                         'SH22',
                         'Long Lancer',
                         'long Bomb',
                         'Doublez la caractéristique de Portée des Grenades utilisées par cette figurine. De plus, cette figurine peut cibler une figurine ennemie qu''elle ne voit pas avec une Grenade; toutefois si elle le fait, la figurine ennemie compte comme étant masquée.',
                         'Double the Range characteristic of any Grenade weapon this model uses. In addition, this model can target an enemy model that is not visible to them with a Grenade weapon, though if they do so, the enemy model counts as obscured.',
                         'SH34'
                     ),
                     (
                         'P',
                         NULL,
                         'Erudit des arcanes',
                         'Student of the Arcane',
                         'Ajoutez 1 aux tests Psychiques de cette figurine.',
                         'Add 1 to this model''s Psychic tests.',
                         'P1'
                     ),
                     (
                         'P',
                         'P1',
                         'Assaut psychique',
                         'Psychic Onslaught',
                         'Ajoutez 1 aux tests Psychiques de cette figurine pour chaque pouvoir psychique qu''elle a déjà manifesté à ce round de bataille.',
                         'Add 1 to this model''s Psychic tests for each psychic power they manifested earlier in the battle round. ',
                         'P21'
                     ),
                     (
                         'P',
                         'P1',
                         'Drain Warp',
                         'Warp Drain',
                         'Ajoutez 1 aux tests d''abjuration de cette figurine.',
                         'Add 1 to this model''s Deny the Witch tests.',
                         'P22'
                     ),
                     (
                         'P',
                         'P21',
                         'Puissance psionique',
                         'Psionic Potency',
                         'Si vous manifestez le pouvoir psychique Trait Psychique avec cette figurine, la portée du pouvoir est de 24" au lieu de 18".',
                         'If you manifest the Psybolt psychic power with this model, the range of the power is 24" instead of 18". ',
                         'P31'
                     ),
                     (
                         'P',
                         'P21',
                         'Omniscience',
                         'Omniscience',
                         'Si vous manifestez le pouvoir psychique Trait Psychique avec cette figurine, vous pouvez cibler n''importe quelle figurine ennemie visible à 18" d''elle au lieu de la plus proche.',
                         'If you manifest the Psybolt psychic power with this model, you can target any visible enemy model within 18" of them instead of the closest.',
                         'P32'
                     ),
                     (
                         'P',
                         'P22',
                         'Charmes protecteurs',
                         'Protective Wards',
                         'Si cette figurine subit les Périls du Warp, jetez un D6 pour chaque blessure mortelle qu''elle subit. Sur 4+, cette blessure mortelle est annulée. Si une figurine a déjà une aptitude avec un effet similaire (ex: Affreusement Résistant), choisissez l''effet qui
s''applique, et relancez les 1 obtenus sur ces jets.',
                         'If this model suffers Perils of the Warp, roll a D6 for each mortal wound they suffer. On a 4+, that wound is not lost. If a model already has an ability with a similar effect (such as Disgustingly Resilient), you can choose which effect applies, and
re-roll 1s when making these rolls. ',
                         'P33'
                     ),
                     (
                         'P',
                         'P22',
                         'Fléau des sorciers',
                         'Witchbane',
                         'Cette figurine peut effectuer une tentative supplémentaire pour Abjurer le Sorcier à chaque round
de bataille.',
                         'This model can make one additional Deny the Witch attempt in each battle round. ',
                         'P34'
                     ),
                     (
                         'ME',
                         NULL,
                         'Combattant expert',
                         'Expert Fighter',
                         'Ajoutez 1 à la caractéristique d''attaques de cetet figurine',
                         'Add 1 to this model''s Attacks charactenstic. ',
                         'ME1'
                     ),
                     (
                         'ME',
                         'ME1',
                         'Guerrier né',
                         'Warrior Born',
                         'Relancez les jets de touche et de blessure de 1 pour cette figurine à la phase de Combat.',
                         'Re-roll hit and wound rolls of 1 for this model in 
the Fight phase. ',
                         'ME21'
                     ),
                     (
                         'ME',
                         'ME1',
                         'Parade éclair',
                         'Swift Parry',
                         'Les adversaires doivent relancer les jets de touche de 6 pour les attaques ciblant cette figurine à la phase de combat.',
                         'Opponents must re-roll hit rolls of 6 for attacks that target this model in
the Fight phase. ',
                         'ME22'
                     ),
                     (
                         'ME',
                         'ME21',
                         'Duelliste',
                         'Duellist',
                         'Jetez un D6 chaque fois que vous utilisez la Tactique de Commandant Duel d''Honneur sur cette figurine. Sur 2+, vous gagnez un point de commandement.',
                         'Roll a D6 each time you use the Duel of Honour Commander Tactic on this model. On a 2+, you gain a Command Point. ',
                         'ME31'
                     ),
                     (
                         'ME',
                         'ME21',
                         'Frappe de précision',
                         'Precision Strike',
                         'A chaque jet de blessure de 6+ obtenu pour une attaque de cette figurine à la phase de Combat, infligez à la cible un nombre de blessures mortelles égal à la caractéristique de Dégâts de l''arme; la séquence d''attaque se termine alors.',
                         'Each time you make a wound roll of 6+ for this model''s attack in the Fight phase, inflict a number of mortal wounds on the target equal to the weapon''s Damage characteristic - the attack sequence then ends. ',
                         'ME32'
                     ),
                     (
                         'ME',
                         'ME22',
                         'Défense impénétrable',
                         'lmpenetrable Defence',
                         'Soustrayez 1 à la caractéristique d''Attaques (jusqu''à un minimum de 1) de toutes les figurines ennemies à 1" de cette figurine lorsqu''elles combattent à la phase de combat, jusqu''à la fin de la phase.',
                         'Subtract 1 from the Attacks characteristic 
(to a minimum of 1) of all enemy models within 1" of this model when they fight in the Fight phase, until the end of the phase. ',
                         'ME33'
                     ),
                     (
                         'ME',
                         'ME22',
                         'Réflexes foudroyants',
                         'Lightning Retlexes',
                         'Jetez un D6 chaque fois que cette figurine perd un PV à la phase de Combat. Sur 5+, ce PV n''est pas perdu. Si une figurine a déjà une aptitude avec un effet similaire (ex: Affreusement résistant), choisissez l''effet qui s''applique, et relancez les 1 obtenus sur ces jets.',
                         'Roll a D6 each time this model suffers a wound in the Fight phase. On a 5+ that wound is not lost. If a mode! already has an ability with 
a similar effect (e.g. Disgustingly Resilient), you can choose which effect applies, and 
re-roll ls when making these rolls. ',
                         'ME34'
                     ),
                     (
                         'LO',
                         NULL,
                         'Armure renforcée',
                         'Extra Armour',
                         'Ignorez les caractéristiques de PA de -1 des attaques ciblant cette figurine.',
                         'Ignore AP characteristics of -1 for attacks that target this model.',
                         'LO1'
                     ),
                     (
                         'LO',
                         'LO1',
                         'Quartier-maitre',
                         'Quartermaster',
                         'Si cette figurine est dans votre kill team et n''est pas hors de combat une fois les jets de Pertes effectués après une mission lors de laquelle vous avez perdu en Matériel, jetez un D6 pour chaque point perdu. Sur 2+, ce point de Matériel n''est pas perdu.',
                         'If this model is in your kill team and not out of action after all casualty rolls have been made after a mission in which you lose any Material, roll a D6 for each point you lose. On a 2+, that point of Materiel is not lost.',
                         'LO21'
                     ),
                     (
                         'LO',
                         'LO1',
                         'Armé jusqu''aux dents',
                         'Armed to the Teeth',
                         'A chaque phase de Tir, au lieu qu''une seule figurine de votre kill team puisse tirer une grenade, cette figurine et 1 autre figurine de votre kill team peuvent chacune tirer une Grenade dont elles sont équipées au lieu de tirer avec leurs autres armes.',
                         'In each Shooting phase, instead of only a single model from your kill team being able to fire a Grenade weapon, this model and one other model in your kill team may each fire a Grenade weapon they are armed with instead of firing any other weapons.',
                         'LO22'
                     ),
                     (
                         'LO',
                         'LO21',
                         'Récupérateur',
                         'Scavenger',
                         'Si cette figurine est dans votre kill team et n''est pas hors de combat une fois les jets de Pertes effectués après une mission, jetez un D6 et ajoutez le nombre de figurines ennemies qui étaient hors de combat à la fin de la mission (avant les jets de pertes). Sur 7+, vous gagnez 1 en Matériel.',
                         'If this model is in your kill team and not out of action after all casualty rolls have been made after a mission, roll a D6 and add the number of enemy models that were out of action at the end of the mission (beforce any Casuality rolls). On a 7+, you gain 1 Materiel.',
                         'LO31'
                     ),
                     (
                         'LO',
                         'LO21',
                         'Maitre du sabotage',
                         'Master of Sabotage',
                         'Si cette figurine est dans votre kill team et n''est pas hors de combat une fois les jets de Pertes effectués après une mission, jetez un D6 pour chaque adversaire qui a joué la mission. Sur 5+, le joueur concerné par le jet perd 1 en matériel.',
                         'If this model is in your kill team and not out of action after all casualty rolls have been made after a mission, roll a D6 for each opponent that played that mission. On a 5+, the player being rolled for loses 1 Materiel.',
                         'LO32'
                     ),
                     (
                         'LO',
                         'LO22',
                         'Maitre Artisan',
                         'Master Artisan',
                         'Choisissez Maître 1 des armes
de cette figurine. Ajoutez 1 à la caractéristique de
Dégâts de cette arme.',
                         'Pick one of this model''s weapons. Add 1 to that weapon''s Damage characterictic.',
                         'LO33'
                     ),
                     (
                         'LO',
                         'LO22',
                         'Lunette Télémetrique',
                         'Rangefinder Scope',
                         'Choisissez une des armes d''Assaut, à Tir Rapide, Lourde ou Pistolet de cette figurine. Augmentez de 6" la caractéristique de Portée de cette arme, et relancez les jets de touche de 1 quand cette figurine fait une attaque de tir avec cette arme.',
                         'Pick one of this model''s Assault, Rapid Fire, Heavy or Pistol weapons. Increase the Range characteritic of that weapon by 6", and re-roll hit rolls of 1 when this model makes a shooting attack with that weapon.',
                         'LO34'
                     ),
                     (
                         'LE',
                         NULL,
                         'Symbole de courage',
                         'Symbol of Courage',
                         'Tant que cette figurine est sur le champ de bataille et n''est pas secouée, soustrayez 1 aux test de sang froid pour les figurines amies.',
                         'As long as this model is on the battlefield and not shaken, substract 1 from Nerve tests for friendly models.',
                         'LE1'
                     ),
                     (
                         'LE',
                         'LE1',
                         'Aura d''autorité',
                         'Aura of Command',
                         'Augmentez de 3" la portée de toutes les tactiques d''Aura que cette figurine utilise.',
                         'Increase the range of all Aura Tactics used by this model by 3".',
                         'LE21'
                     ),
                     (
                         'LE',
                         'LE1',
                         'Galvanisant',
                         'Inspiring',
                         'Les figurines amies à 3" de cette figurine -tant qu''elles ne sont pas secouées- réussissent automatiquement les tests de sang-froid.',
                         'Friendly models within 3" of this model - as long as it is not shaken - automatically pass nerve tests.',
                         'LE22'
                     ),
                     (
                         'LE',
                         'LE21',
                         'Maitre de la guerre',
                         'Master of War',
                         'Chaque fois que cette figurine utilise une Tactique d''Aura, jetez un D6. Sur 3+, vous regagnez 1 Point
de Commandement.',
                         'Each time this model uses an Aura Tactics, roll a D6. On a 3+ you regain 1 Command Point.',
                         'LE31'
                     ),
                     (
                         'LE',
                         'LE21',
                         'Héroïque',
                         'Heroic',
                         'Si cette figurine est sur le
champ de bataille et n''est pas secouée, vous gagnez un Point de Commandement supplémentaire au
début cle chaque round de bataille. Ce PC ne peut être utilisé que pour des Tactiques de Commadant.',
                         'As long as this model is on the battlefield and not shaken, you gain one additional Command Point at start of each battle round.',
                         'LE32'
                     ),
                     (
                         'LE',
                         'LE22',
                         'Apre Détermination',
                         'Grim Determination',
                         'Les figurines amies à 3" de cette figurine -tant qu''elles ne sont pas secouées- ne subissent pas de pénalité à leurs jets de touche à cause de 1 blessure légère qu''elle possèdent.',
                         'Friendly models whitin 3" of this model - as long as it is not shaken - do not suffer penalties to their hit rolls for one flesh wound they have.',
                         'LE33'
                     ),
                     (
                         'LE',
                         'LE22',
                         'Tenace',
                         'Tenacious',
                         'Cette figurine contrôle toujours un pion objectif si elle est à 2" de lui, même si il y a plus de figurines ennemies à 2" de ce pion. Si une figurine ennemie avec une aptitude similaire est également à 2" de ce pion objectif, aucune de ces aptitudes n''a d''effet sur ces figurines.',
                         'This model always controls an objective marker if it is within 2" of it, even if there are more enemy model with a similar ability is also within 2" of that objective marker, neither ability has an effect for either model.',
                         'LE34'
                     ),
                     (
                         'FR',
                         NULL,
                         'Contre-attaque',
                         'Counter-attack',
                         'Cette figurine peut toujours être choisie pour
combattre à la section Marteau de Fureur de la phase de Combat, même si elle n''a pas chargé 
à ce round de bataille.',
                         'This model can always be chosen to fight in the hammer of Wrath section of the Fight phase, even if they did not charge in that battle round.',
                         'FR1'
                     ),
                     (
                         'FR',
                         'FR1',
                         'Soif de sang',
                         'Bloodlust',
                         'Vous pouvez relancer les jets de charge ratés effectués pour cette figurine.',
                         'You can re-roll failed charge rolls you make this model.',
                         'FR21'
                     ),
                     (
                         'FR',
                         'FR1',
                         'Ignore la douleur',
                         'Ignore Pain',
                         'Les attaques de cette figurine ne subissent pas de pénalité à leurs jets de touche pour cause de blessure(s) légère(s) à la phase de combat.',
                         'This model''s attacks do not suffer any penalties to their hit rolls from flesh wound(s) in the Fight phase.',
                         'FR22'
                     ),
                     (
                         'FR',
                         'FR21',
                         'Redoutable cri de guerre',
                         'Fearsome War Cry',
                         'Soustrayez 1 aux jets de touche pour les attaques qui ciblent cette figurine à la phase de combat lors d''un round de bataille au cours duquel elle a chargé.',
                         'Subtract 1 from hit rolls for attacks that target this model in the Fight phase during a battle round in which it charged',
                         'FR31'
                     ),
                     (
                         'FR',
                         'FR21',
                         'Berserk',
                         'Berserker',
                         'Soustrayez 1 aux jets de blessure pour les attaques qui ciblent cette figurine à la phase de Combat. ',
                         'Subtract 1 from wound rolls for attacks that target this model in the Fight phase.',
                         'FR32'
                     ),
                     (
                         'FR',
                         'FR22',
                         'Agonie frénétique',
                         'Death Frenzy',
                         'Si cette figurine est mise hors de combat à la phase de Combat, vous pouvez aussitôt combattre avec elle avant de la retirer du champ de bataille, même si elle a déjà été choisie pour combattre à cette phase.',
                         'If this model is taken out of action in the Fight phase you can immediately fight with them before removing the model from the battlefield, even if they have already been chosen to fight in that phase.',
                         'FR33'
                     ),
                     (
                         'FR',
                         'FR22',
                         'Carnage indigné',
                         'Indignant Rampage',
                         'Ajoutez D3 à la caractéristique d''Attaques de cette figurine pour la durée de la phase de Combat s''il lui reste moins de la moitié de ses PV.',
                         'Add D3 to this model''s Attacks characteristic for the duration of the Fight phase if it has less than half of its wounds remaining.',
                         'FR34'
                     ),
                     (
                         'FE',
                         NULL,
                         'Constitution robuste',
                         'Hardy Constitution',
                         'Jetez un D6 chaque fois que cette figurine perd un PV. Sur 6+ ce PV n''est pas perdu. Si une figurine a déjà une aptitude avec un effet similaire (comme Affreusement Résistant), 
choisissez l''effet qui s''applique, et relancez les 1 obtenus sur ces jets.',
                         'Roll a D6 each time this model loses a wound. On a 6+ that wound is not lost. If a model already has an ability with a similar effect (such as Disgustingly resilient), you can choose which effect applies, and re-roll 1s whan making these rolls.',
                         'FE1'
                     ),
                     (
                         'FE',
                         'FE1',
                         'Indomptable',
                         'Indomitable',
                         'Une fois par round de bataille, vous pouvez relancer un jet de trauma effectué par votre adversaire pour cette figurine.',
                         'Once per battle round you can make your oppoment re-roll an Injury roll for this model.',
                         'FE21'
                     ),
                     (
                         'FE',
                         'FE1',
                         'Difficile à tuer',
                         'Hard to Kill',
                         'Divisez par deux la caractéristique de Dégâts de chaque arme utilisée pour attaquer cette figurine (en arrondissant au-dessus) pour la durée de l''attaque.',
                         'Halve the Damage characteritic of each weapon used to attack this model (rounding up) for the duration of the attack.',
                         'FE22'
                     ),
                     (
                         'FE',
                         'FE21',
                         'Insensible à la douleur',
                         'Feel No Pain',
                         'Les adversaires doivent soustraire1 aux jets de Trauma effectués pour cette figurine. ',
                         'Opponent(s) must subtract 1 from Injury rolls made for this model.',
                         'FE31'
                     ),
                     (
                         'FE',
                         'FE21',
                         'Volonté inflexible',
                         'Unyielding Will',
                         'Cette figurine peut tenter d''abjurer un pouvoir psychique à chaque phase Psychique. Si elle peut déjà le faire, elle peut effectuer une tentative supplémentaire
d''abjurer un pouvoir psychique à chaque phase Psychique.',
                         'This model can attempt to deny one psychic power in each Psychic phase. If it can already do so, it can make one additional attempt to deny a psychic power in each Psychic phase.',
                         'FE32'
                     ),
                     (
                         'FE',
                         'FE22',
                         'Dur à cuire',
                         'True Grit',
                         'Ajouter 1 à la caractéristique d''Endurance de cette figurine. ',
                         'Add 1 to this model''s Toughness characteristic.',
                         'FE33'
                     ),
                     (
                         'FE',
                         'FE22',
                         'Constitution de fer',
                         'Iron Constitution',
                         'Ajoutez 1 à la rnractéristique de PV de cette figurine.',
                         'Add 1 to this model''s Wounds characteristic.',
                         'FE34'
                     );
INSERT OR IGNORE INTO SurchargeCoutArme (
                                  Cout,
                                  ArmeId,
                                  DeclinaisonId,
                                  Id
                              )
                              VALUES (
                                  8,
                                  'TOS',
                                  'TYTP',
                                  45
                              ),
                              (
                                  5,
                                  'EPO',
                                  'TYTP',
                                  44
                              ),
                              (
                                  2,
                                  'CRO',
                                  'TYTP',
                                  43
                              ),
                              (
                                  5,
                                  'CRM',
                                  'TYTP',
                                  42
                              ),
                              (
                                  5,
                                  'BEP',
                                  'TYTP',
                                  41
                              ),
                              (
                                  0,
                                  'PEK',
                                  'ORP',
                                  40
                              ),
                              (
                                  6,
                                  'AS',
                                  'ORW',
                                  39
                              ),
                              (
                                  13,
                                  'PEK',
                                  'ORW',
                                  38
                              ),
                              (
                                  0,
                                  'GKK',
                                  'ORW',
                                  37
                              ),
                              (
                                  5,
                                  'ARL',
                                  'ORW',
                                  36
                              ),
                              (
                                  8,
                                  'ARK',
                                  'ORW',
                                  35
                              ),
                              (
                                  6,
                                  'NDI',
                                  'ARS',
                                  34
                              ),
                              (
                                  10,
                                  'PFU',
                                  'ART',
                                  33
                              ),
                              (
                                  6,
                                  'NDI',
                                  'ART',
                                  32
                              ),
                              (
                                  6,
                                  'EHA',
                                  'ART',
                                  31
                              ),
                              (
                                  4,
                                  'EPE',
                                  'ART',
                                  30
                              ),
                              (
                                  7,
                                  'CHA',
                                  'ART',
                                  29
                              ),
                              (
                                  9,
                                  'BHA',
                                  'ART',
                                  28
                              ),
                              (
                                  0,
                                  'NEU',
                                  'DRS',
                                  27
                              ),
                              (
                                  10,
                                  'PDI',
                                  'DRA',
                                  26
                              ),
                              (
                                  0,
                                  'NEU',
                                  'DRA',
                                  25
                              ),
                              (
                                  5,
                                  'SS',
                                  'ASF',
                                  24
                              ),
                              (
                                  10,
                                  'PFU',
                                  'ASA',
                                  23
                              ),
                              (
                                  7,
                                  'LFWL',
                                  'TSE',
                                  22
                              ),
                              (
                                  7,
                                  'PP',
                                  'TSE',
                                  21
                              ),
                              (
                                  0,
                                  'PP',
                                  'DGT',
                                  20
                              ),
                              (
                                  0,
                                  'LPE',
                                  'DGF',
                                  19
                              ),
                              (
                                  4,
                                  'EPE',
                                  'HAE',
                                  18
                              ),
                              (
                                  12,
                                  'GEN',
                                  'HAE',
                                  17
                              ),
                              (
                                  4,
                                  'PP',
                                  'HAE',
                                  16
                              ),
                              (
                                  8,
                                  'GEN',
                                  'AMT',
                                  15
                              ),
                              (
                                  6,
                                  'GEN',
                                  'AMP2',
                                  14
                              ),
                              (
                                  6,
                                  'GEN',
                                  'AMP1',
                                  13
                              ),
                              (
                                  3,
                                  'PP',
                                  'AMP2',
                                  12
                              ),
                              (
                                  3,
                                  'PP',
                                  'AMP1',
                                  11
                              ),
                              (
                                  1,
                                  'EPT',
                                  'AMP2',
                                  10
                              ),
                              (
                                  1,
                                  'EPT',
                                  'AMP1',
                                  9
                              ),
                              (
                                  2,
                                  'BO',
                                  'AMP2',
                                  8
                              ),
                              (
                                  2,
                                  'BO',
                                  'AMP1',
                                  7
                              ),
                              (
                                  6,
                                  'GEN',
                                  'AMC2',
                                  6
                              ),
                              (
                                  6,
                                  'GEN',
                                  'AMC1',
                                  5
                              ),
                              (
                                  3,
                                  'PP',
                                  'AMC2',
                                  4
                              ),
                              (
                                  3,
                                  'PP',
                                  'AMC1',
                                  3
                              ),
                              (
                                  4,
                                  'EPE',
                                  'AAL',
                                  2
                              ),
                              (
                                  7,
                                  'EPE',
                                  'AAC',
                                  1
                              );
INSERT OR IGNORE INTO Remplacement (
                             Operation,
                             MaxParTeam,
                             FigurineId,
                             Exclusion,
                             DeclinaisonId,
                             Id
                         )
                         VALUES (
                             'FBAM:FBSM',
                             0,
                             NULL,
                             NULL,
                             'AAC',
                             200
                         ),
                         (
                             'EPE',
                             0,
                             NULL,
                             NULL,
                             'AAC',
                             201
                         ),
                         (
                             'FBAM:EPE|FBSM',
                             0,
                             NULL,
                             NULL,
                             'AAL',
                             202
                         ),
                         (
                             'PB:PP',
                             0,
                             'AMC',
                             NULL,
                             NULL,
                             203
                         ),
                         (
                             'EPE',
                             0,
                             'AMC',
                             NULL,
                             NULL,
                             204
                         ),
                         (
                             'GEN',
                             0,
                             'AMC',
                             NULL,
                             NULL,
                             205
                         ),
                         (
                             'EPE|EPT|GEN',
                             0,
                             'AMP',
                             NULL,
                             NULL,
                             206
                         ),
                         (
                             'PLS:BO|PB|PP',
                             0,
                             'AMP',
                             NULL,
                             NULL,
                             207
                         ),
                         (
                             'PRL:SCT|PB|PP',
                             0,
                             NULL,
                             NULL,
                             'AMT',
                             209
                         ),
                         (
                             'EPE|EPT|GEN',
                             0,
                             NULL,
                             NULL,
                             'AMT',
                             208
                         ),
                         (
                             'M:PS',
                             0,
                             NULL,
                             NULL,
                             'MED',
                             211
                         ),
                         (
                             'VB:ER',
                             0,
                             NULL,
                             NULL,
                             'MED',
                             210
                         ),
                         (
                             'BO',
                             0,
                             NULL,
                             NULL,
                             'HAE',
                             212
                         ),
                         (
                             'PB:PP',
                             0,
                             NULL,
                             NULL,
                             'HAE',
                             213
                         ),
                         (
                             'EPT:PAX|GEN|EPE',
                             0,
                             NULL,
                             NULL,
                             'HAE',
                             214
                         ),
                         (
                             'FS:SCF',
                             0,
                             NULL,
                             NULL,
                             'HAS',
                             215
                         ),
                         (
                             'PBI:PP|LFWL',
                             0,
                             NULL,
                             NULL,
                             'TSE',
                             216
                         ),
                         (
                             'EPE2',
                             0,
                             NULL,
                             NULL,
                             'TSE',
                             217
                         ),
                         (
                             'DST&BD',
                             0,
                             NULL,
                             NULL,
                             'TSE',
                             218
                         ),
                         (
                             'SG:EPE2&PFU&ASW',
                             0,
                             NULL,
                             NULL,
                             'ASA',
                             219
                         ),
                         (
                             'W:SS',
                             0,
                             NULL,
                             NULL,
                             'ASW',
                             220
                         ),
                         (
                             'W:SS',
                             0,
                             NULL,
                             NULL,
                             'ASF',
                             221
                         ),
                         (
                             'H:NEU|EPE2|VBE',
                             0,
                             NULL,
                             NULL,
                             'DRA',
                             222
                         ),
                         (
                             'PEC:PDI',
                             0,
                             NULL,
                             NULL,
                             'DRA',
                             223
                         ),
                         (
                             'IJ',
                             0,
                             NULL,
                             NULL,
                             'DRH',
                             224
                         ),
                         (
                             'PSH:NDI|PFU',
                             0,
                             NULL,
                             NULL,
                             'ART',
                             225
                         ),
                         (
                             'LHA:EPE|EHA|BHA|CHA',
                             0,
                             NULL,
                             NULL,
                             'ART',
                             226
                         ),
                         (
                             'PSH:NDI',
                             0,
                             NULL,
                             NULL,
                             'ARS',
                             227
                         ),
                         (
                             'V:SOL|WC',
                             0,
                             NULL,
                             NULL,
                             'NEO',
                             228
                         ),
                         (
                             'CCA',
                             0,
                             NULL,
                             NULL,
                             'NEY',
                             229
                         ),
                         (
                             'KS:ARK|ARL',
                             0,
                             NULL,
                             NULL,
                             'ORW',
                             230
                         ),
                         (
                             'GKK:PEK',
                             0,
                             NULL,
                             NULL,
                             'ORW',
                             231
                         ),
                         (
                             'AS',
                             0,
                             NULL,
                             NULL,
                             'ORW',
                             232
                         ),
                         (
                             'KAL:KMS|SAG|CFC',
                             0,
                             NULL,
                             NULL,
                             'ORBM',
                             233
                         ),
                         (
                             'HB:E',
                             0,
                             NULL,
                             NULL,
                             'TAE',
                             234
                         ),
                         (
                             'HD',
                             0,
                             NULL,
                             NULL,
                             'TAE',
                             235
                         ),
                         (
                             'DEV:CRM|GTR|POE|EPO|SFO|BEP',
                             0,
                             NULL,
                             NULL,
                             'TYTP',
                             236
                         ),
                         (
                             'GTR:EPO|SFO|BEP',
                             0,
                             NULL,
                             NULL,
                             'TYTP',
                             237
                         ),
                         (
                             'CRO',
                             0,
                             NULL,
                             NULL,
                             'TYTP',
                             238
                         ),
                         (
                             'TOS',
                             0,
                             NULL,
                             NULL,
                             'TYTP',
                             239
                         ),
                         (
                             'GSU',
                             0,
                             NULL,
                             NULL,
                             'TYTP',
                             240
                         );
INSERT OR IGNORE INTO Psychiques (
                           Commandant,
                           Charge,
                           NomFr,
                           NomEn,
                           De,
                           DeclinaisonId,
                           DescriptionFr,
                           DescriptionEn,
                           Id
                       )
                       VALUES (
                           0,
                           5,
                           'Trait psychique',
                           'Psybolt',
                           0,
                           NULL,
                           'S''il est manifesté, la figurine ennemie visible du psyker et la plus proche dans les 18" subit 1 blessure mortelle (p.33). Si le résultat du test psychique était 11+, la cible subit D3 blessures mortelles à la place.',
                           'If manifested,
the closest enemy model within 18" of and visible
to the psyker suffers 1 mortal wound (pg 33). If the
result of the Psychic test was 11+, the target suffers
D3 mortal wounds instead.',
                           1
                       ),
                       (
                           1,
                           7,
                           'Fatalité',
                           'Misfortune',
                           6,
                           NULL,
                           'S''il est manifesté, choisissez une figurine amie à 12" et visible du psyker. Jusqu''au début de la prochaine phase psychique, améliorez de 1 la caractéristique PA de toute arme qui cible cette figurine (par exemple, une arme PA0 devient PA-1).',
                           'If manifested, select an enemy model within 12" of and visible to the psyker. Until the start of the next Psychic phase, improve the AP characteristic of any weapon that targets that model by 1 (for example, an AP0 weapon becomes AP-1).',
                           7
                       ),
                       (
                           1,
                           7,
                           'Affaiblissement',
                           'Enfeeble',
                           5,
                           NULL,
                           'S''il est manifesté, choisissez une figurine amie à 12" et visible du psyker. Jusqu''au début de la prochaine phase psychique, votre adversaire doit soustraire 1 aux jets de touche et de blessure pour les attaques de corps à corps de la figurine ciblée par ce pouvoir.',
                           'If manifested, select an enemy model within 12" of and visible to the psyker. Until the start of the next Psychic phase, your opponent must subtract 1 from hit and wound rolls for the target model''s close combat attacks.',
                           6
                       ),
                       (
                           1,
                           5,
                           'Hurlement psychique',
                           'Psychic Shriek',
                           4,
                           NULL,
                           'S''il est manifesté, choisissez une figurine amie à 12" et visible du psyker. Cette figurine doit immédiatement effectuer un test de Sang-froid comme à la phase moral.',
                           'If manifested, select an enemy model within 12" of and visible to the psyker. That model must immediately take a Nerve test as if it were the Morale phase.',
                           5
                       ),
                       (
                           1,
                           6,
                           'Bouclier ardent',
                           'Fire shield',
                           3,
                           NULL,
                           'S''il est manifesté, choisissez une figurine amie à 8" du psyker. Jusqu''au début de la prochaine phase psychique, cette figurine compte comme masquée même si elle est complètement visible par le tireur.',
                           'If manifested, pick a friendly model within 
8" of the psyker. Until the start of the 
next Psychic phase, that model counts as obscured, even if they are completely visible to the firing model.',
                           4
                       ),
                       (
                           1,
                           6,
                           'Prescience',
                           'Forewarning',
                           2,
                           NULL,
                           'S''il est manifesté, jusqu''au début de la prochaine phas Psychique, le psyker a une sauvegarde invulnérable de 4+.',
                           'If manifested, then until the start of the next Psychic phase, the psyker has a 4+ invulnerable save. ',
                           3
                       ),
                       (
                           1,
                           7,
                           'Bras d''acier',
                           'Iron arm',
                           1,
                           NULL,
                           'S''il est manifesté, jusqu''au début de la prochaine phas Psychique, ajoutez 2 aux caractéristiques de Force et d''Endurance du psyker.',
                           'If manifested, then until the start of the next Psychic phase, add 2 to the psyker''s Strength and Toughness characteristics.',
                           2
                       ),
                       (
                           1,
                           8,
                           'Zone neutre',
                           'Null zone',
                           3,
                           'AAB',
                           'S''il est manifesté, alors jusqu''au début de la prochaine phase psychique, les figurines ennemies à 3" du psyker ne peuvent pas effectuer de sauvegardes invulnrébles et doivent diviser par deux (en arrondissant au supérieur) les résultats des tests Psychiques qu''elles effectuent.',
                           'If manifested, then until the start of the next Psychic phase, while they are within 3" of the psyker, enemy models cannot take invulnerable saves and must halve the result of any Psychic tests (rounding up) that they take.',
                           10
                       ),
                       (
                           1,
                           6,
                           'Puissance des héros',
                           'Might of heroes',
                           2,
                           'AAB',
                           'S''il est manifesté, choisissez une figurine amie à 12" du psyker. Jusqu''au début de la prochaine phase psychique, ajoutez 1 à sa Force, son Endurance et ses attaques.',
                           'If manifested, pick a friendly model within 12" of the psyker. Until the start of the next Psychic phase, add 1 to that model''s Strength, Toughness and Attacks characteristics.',
                           9
                       ),
                       (
                           1,
                           5,
                           'Voile du temps',
                           'Veil of time',
                           1,
                           'AAB',
                           'S''il est manifesté, choisissez une figurine amie à 18" du psyker. Jusqu''au début de la prochaine phase psychique, vous pouvez relancer ses jets de charge et d''avance, et elle peut toujours être choisie pour combattre pendant la section Marteau de Fureur de la phase de Combat, même si elle n''a pas effectué de mouvement de charge à ce round.',
                           'If manifested, pick a friendly model within 18" of the psyker. Until the start of your next Psychic phase, you can re-roll charge rolls and Advance rolls for that model, and they can always 
be chosen to fight in the Hammer of Wrath section of the Fight phase, even if they did not make a charge move that battle round. ',
                           8
                       ),
                       (
                           1,
                           6,
                           'Force diabolique',
                           'Diabloic strength',
                           3,
                           'HAS',
                           'S''il est manifesté, choisissez une figurine amie à 8" et visible du psyker. Jusqu''au début de la prochaine phase psychique, ajoutez 2 à sa Force et 1 à ses attaques.',
                           'If manifested, select a friendly model within 8" of the psyker. Until the start of the next Psychic phase, add 2 to that model''s Strength characteristic and 1 to its Attacks characteristic.',
                           13
                       ),
                       (
                           1,
                           6,
                           'Prescience',
                           'Prescience',
                           2,
                           'HAS',
                           'S''il est manifesté, choisissez une figurine amie à 8" du psyker. Vous pouvez ajouter 1 aux jets de touche de cette figurine jusqu''au début de la prochaine phase Psychique.',
                           'If manifested, select a friendly model within 
8" of the psyker. You can add 1 to hit rolls made for that model until the start of the next Psychic phase.',
                           12
                       ),
                       (
                           1,
                           7,
                           'Malédicion mortelle',
                           'Death hex',
                           1,
                           'HAS',
                           'S''il est manifesté, choisissez une figurine ennemie à 12" et visible du psyker. Jusqu''au début de la prochaine phase psychique, cette figurine ne peut pas effectuer de sauvegarde invulnérable.',
                           'If manifested, select an enemy model within 12" of the psyker and visible to him. Until the start of the next Psychic phase, that model cannot take invulnerable saves.',
                           11
                       ),
                       (
                           1,
                           9,
                           'Eclair du changement',
                           'Bolt of change',
                           3,
                           'TSE',
                           'S''il est manifesté, la figurine ennemie la plus proche visible du psyker et à 12" subit D3 blessures mortelles.',
                           'If manifested, the closest enemy model within 12" of the psyker and visible to him suffers D3 mortal wounds.',
                           16
                       ),
                       (
                           1,
                           8,
                           'Trahison de Tzeentch',
                           'Treason of tzeentch',
                           2,
                           'TSE',
                           'S''il est manifesté, choisissez une figurine ennemie à 12" et visible du psyker., puis jetez 2D6. Si le résultat est supérieur au Commandement de la figurine, elle compte comme faisant partie de votre kill team lors des phases de tir et de combat suivantes. A la fin de la phase de combat, la figurine redevient une figurine ennemie.',
                           'If manifested, select an enemy model that is within 12" of the psyker and visible to him and roll 2D6. If the result is greater than the character''s Leadership characteristic, the model is treated as if it were a model from your kill team in the subsequent Shooting and Fight phases. At the end of the Fight phase, the model reverts to being an enemy model.',
                           15
                       ),
                       (
                           1,
                           6,
                           'Regard du destin',
                           'Gaze of fate',
                           1,
                           'TSE',
                           'S''il est manifesté, vous pouvez relancer un seul jet d''Avance, de charge, un test psychique ou d''abjuration, un jet de touche, de blessure, de trauma, de sauvegarde ou de Sang-froid avant la prochaine phase Psychique.',
                           'If manifested, you can re-roll a single Advance roll, charge roll, Psychic test, Deny the Witch test, hit roll, wound roll, saving throw, Injury roll or Nerve test before the next Psychic phase.',
                           14
                       ),
                       (
                           1,
                           9,
                           'Eclair du changement',
                           'Bolt of change',
                           3,
                           'TSTS',
                           'S''il est manifesté, la figurine ennemie la plus proche visible du psyker et à 12" subit D3 blessures mortelles.',
                           'If manifested, the closest enemy model within 12" of the psyker and visible to him suffers D3 mortal wounds.',
                           19
                       ),
                       (
                           1,
                           8,
                           'Trahison de Tzeentch',
                           'Treason of tzeentch',
                           2,
                           'TSTS',
                           'S''il est manifesté, choisissez une figurine ennemie à 12" et visible du psyker., puis jetez 2D6. Si le résultat est supérieur au Commandement de la figurine, elle compte comme faisant partie de votre kill team lors des phases de tir et de combat suivantes. A la fin de la phase de combat, la figurine redevient une figurine ennemie.',
                           'If manifested, select an enemy model that is within 12" of the psyker and visible to him and roll 2D6. If the result is greater than the character''s Leadership characteristic, the model is treated as if it were a model from your kill team in the subsequent Shooting and Fight phases. At the end of the Fight phase, the model reverts to being an enemy model.',
                           18
                       ),
                       (
                           1,
                           6,
                           'Regard du destin',
                           'Gaze of fate',
                           1,
                           'TSTS',
                           'S''il est manifesté, vous pouvez relancer un seul jet d''Avance, de charge, un test psychique ou d''abjuration, un jet de touche, de blessure, de trauma, de sauvegarde ou de Sang-froid avant la prochaine phase Psychique.',
                           'If manifested, you can re-roll a single Advance roll, charge roll, Psychic test, Deny the Witch test, hit roll, wound roll, saving throw, Injury roll or Nerve test before the next Psychic phase.',
                           17
                       ),
                       (
                           1,
                           5,
                           'Puissance/Atonie',
                           'Empower/Enervate',
                           3,
                           'ASW',
                           'S''il est manifesté, choisissez une figurine à 12" du psyker. Si c''est une figurine amie, jusqu''à la prochaine phase psychique, ajoutez 1 aux jets de blessure de ses attaques à la phase de Combat. Si c''est une figurine ennemie, jsuqu''à la prochaine phase psychique, le joueur qui la contrôle doit soustraire 1 aux jets de blessure des ses attaques à la phase de combat.',
                           'If manifested, choose a model within 12". If you chose a friendly model, add 1 to wound rolls in the Fight phase for that model''s attacks until the next Psychic phase. If you chose an enemy model, that model''s controlling player must subtract 1 from wound rolls made for that model''s attacks in the Fight phase until the next Psychic phase.',
                           22
                       ),
                       (
                           1,
                           6,
                           'Protection/Spoliation',
                           'Project/Jinx',
                           2,
                           'ASW',
                           'S''il est manifesté, choisissez une figurine à 12" du psyker. Si c''est une figurine amie, jusqu''à la prochaine phase psychique, ajoutez 1 à ses jets de sauvegarde. Si c''est une figurine ennemie, jsuqu''à la prochaine phase psychique, le joueur qui la contrôle doit soustraire 1 à ses jets de sauvegarde.',
                           'If manifested, choose a model within 12" of  the psyker. If you chose a friendly model, add 1 to saving throws made for that model until the  next Psychic phase. If you chose an enemy model, that model''s controlling player must subtract 1 from saving throws made for that model until the next Psychic phase.',
                           21
                       ),
                       (
                           1,
                           5,
                           'Dissimulation/Révélation',
                           'Conceal/Reveal',
                           1,
                           'ASW',
                           'S''il est manifesté, choisissez une figurine à 12" du psyker. Si c''est une figurine amie, jusqu''à la prochaine phase psychique, votre adversaire doit soustraire 1 aux jets de touche de ses armes de tir qui la ciblent. Si c''est une figurine ennemie, jsuqu''à la prochaine phase psychique, elle ne compte pas comme masquée en ce qui concerne les jets de touche.',
                           'If manifested, choose a model within 12" of
the psyker. If you chose a friendly model,  your opponent must subtract 1 from hit rolls for  ranged weapons that target that model until the next Psychic phase. If you chose an enemy model,  that model is not considered to be obscured for the purposes of hit rolls until the next Psychic phase.',
                           20
                       ),
                       (
                           1,
                           5,
                           'Volonté d''Asuryan',
                           'Will of Asuryan',
                           3,
                           'ASF',
                           'S''il est manifesté, jusqu''à la prochaine phase psychique, les figurines amies réussissent automatiquement leurs tests de sang froid si elles sont à 6" du psyker. De plus, vous pouvez ajouter 1 aux tests d''Abjurer le Sorcier du psyker jusqu''à la prochaine phase psychique.',
                           'If manifested, friendly models automatically pass Nerve tests while they are within 6" of the psyker until the next Psychic phase. In addition, you can add 1 to Deny the Witch tests that you make for the psyker until the next Psychic phase.',
                           25
                       ),
                       (
                           1,
                           6,
                           'Chance',
                           'Fortune',
                           2,
                           'ASF',
                           'S''il est manifesté, choisissez une figurine amie à 12" du psyker. Jusqu''à la prochaine phase psychique, jetez un D6 chaque fois que cette figurine perd un point de vie. Sur 5+ ce point de vie n''est pas perdu. Si la figurine dispose d''une aptitude similaire, vous pouvez choisir quel effet s''applique, et relancer les 1 obtenus sur le jet de dé.',
                           'If manifested, choose a friendly model within 12" of the psyker. Until the next Psychic phase, roll a D6 each time that model loses a wound. On a 5+ that wound is not lost. If that model already has an ability with a similar effect, you can choose which effect applies, and re-roll ls when making these rolls.',
                           24
                       ),
                       (
                           1,
                           6,
                           'Guide',
                           'Guide',
                           1,
                           'ASF',
                           'S''il est manifesté, choisissez une figurine amie à 12" du psyker. Jusqu''à la prochaine phase psychique, vous pouvez relancer les jets de touche des armes de tir de cette figurine.',
                           'If manifested, choose a friendly model within 12" of the psyker. You can re-roll failed hit rolls for that model''s ranged weapons until the next Psychic phase.',
                           23
                       ),
                       (
                           1,
                           7,
                           'Miroirs mentaux',
                           'Mirror of minds',
                           3,
                           'ARS',
                           'S''il est manifesté, choisissez une figurine ennemie à 12" du psyker. Les deux joueurs lancent chacun un D6. Si le résultat du joueur Harlequin est supérieur ou égal à celui de l''adversaire, la cible subit une blessure mortelle. Recommencez jusqu''à ce que la figurine soit mise hors de combat ou que l''adversaire obtienne un résultat supérieur.',
                           'If manifested, select an enemy model within 12" of the psyker. Then, both controlling players roll a D6. If the Harlequin player''s roll is equal to or higher than their opponent''s, the target suffers 1 mortal wound. Repeat this process until the target is taken out of action, or the other player beats the Harlequin player''s roll.',
                           28
                       ),
                       (
                           1,
                           7,
                           'Danse de la toile',
                           'Webway dance',
                           2,
                           'ARS',
                           'S''il est manifesté, jusqu''au début de la prochaine phase psychique, jetez un D6 lorsqu''une figurne amie à 6" du psyker perd un PV; sur 6 ce PV n''est pas perdu. Si la figurine dispose d''une aptitude similaire, vous pouvez choisir quel effet s''applique, et relancer les 1 obtenus sur le jet de dé.',
                           'If manifested, then until the start of the next Psychic phase, roll a D6 whenever a friendly model within 6" of the psyker loses a wound; on a 6 that wound is not lost. If a model already has an ability with a similar effect, you can choose which effect applies, and re-roll ls when making these rolls.',
                           27
                       ),
                       (
                           1,
                           5,
                           'Brume des rêves',
                           'Fog of dreams',
                           1,
                           'ARS',
                           'S''il est manifesté, choisissez une figurine ennemie à 12" et visible du psyker. Jusqu''au début de la prochaine phase psychique, votre adversaire doit soustraire 1 aux jets de touche de cette figurine.',
                           'If manifested, select an enemy model within 12" of and visible to the psyker. Until the start of the next Psychic phase, your opponent must subtract 1 from hit rolls for that model.',
                           26
                       ),
                       (
                           1,
                           5,
                           'L''horreur',
                           'The horror',
                           3,
                           'TYB',
                           'S''il est manifesté, choisissez une figurine ennemie visible du psyker et à 18" de celui-ci. Jusqu''au début de la prochaine phase psychique, cette figurine doit soustraire 1 à ses jets de touche et à sa caractéristique de Commandement.',
                           'If manifested, select an enemy model within 
18" of and visible to the psyker. Until the 
start of the next Psychic phase, that model must subtract 1 from their hit rolls and Leadership characteristic.',
                           31
                       ),
                       (
                           1,
                           5,
                           'Catalyseur',
                           'Catalyst',
                           2,
                           'TYB',
                           'S''il est manifesté, choisissez une figurine amie à 18" du psyker. Jusqu''au début de la prochaine phase psychique, jetez un D6 lorsqu''une figurne amie à 6" du psyker perd un PV; sur 5+ ce PV n''est pas perdu. Si la figurine dispose d''une aptitude similaire, vous pouvez choisir quel effet s''applique, et relancer les 1 obtenus sur le jet de dé.',
                           'If manifested, select a friendly model within 
18" of the psyker. Until the start of the next Psychic phase, roll a D6 each time that model loses a wound. On a 5+ that wound is not lost. If a model already has an ability with a similar effect, you can choose which effect applies, and re-roll ls when making these rolls.',
                           30
                       ),
                       (
                           1,
                           4,
                           'Domination',
                           'Dominion',
                           1,
                           'TYB',
                           'S''il est manifesté, choisissez une figurine amie à 18" du psyker avec l''aptitude Comportement instinctif. Jusqu''au début de la prochaine phase psychique, cette figurine ignore son aptitude comportement instinctif et réussit automatiquement ses test de sang froid.',
                           'If manifested, select a friendly model within 18" of the psyker that has the Instinctive Behaviour ability. Until the start of the next Psychic phase, that model ignores its Instinctive Behaviour ability and automatically passes Nerve tests.',
                           29
                       ),
                       (
                           1,
                           6,
                           'Force occulte',
                           'Might from beyond',
                           3,
                           'GCZ',
                           'S''il est manifesté, choisissez une figurine amie à 18" du psyker. Ajoutez 1 aux caractéristiques de Force et d''Attaque de cette figurine jusqu''au début de la prochaine phase psychique.',
                           'If manifested, select a friendly model within 18" of the psyker. Add 1 to the Strength and Attacks characteristics of that model until the start of the next Psychic phase.',
                           34
                       ),
                       (
                           1,
                           6,
                           'Contrôle nerveux',
                           'Mind control',
                           2,
                           'GCZ',
                           'S''il est manifesté, choisissez une figurine ennemie à 12" du psyker et jetez 3D6. Si le résultat est inférieur à la caractéristique de Commandement de la figurine, rine ne se produit. S''il est égal ou supérieur, cette figurine tire immédiatement une autre figurine ennemie de votre choix comme si c''était la phase de Tir.',
                           'If manifested, pick an enemy model within 12" of the psyker and roll 3D6. If the score is less than that model''s Leadership characteristic nothing happens. If it is equal to or greater, that model immediately shoots another enemy model of your choice as if it were the Shooting phase, 
or makes a single close combat attack against another enemy model within 1" as if it were the Fight phase, as if it were part of your kill team.',
                           33
                       ),
                       (
                           1,
                           6,
                           'Hypnose',
                           'Paralysing hypnosis',
                           1,
                           'GCZ',
                           'S''il est manifesté, choisissez une figurine ennemie visible à 18" du psyker. Jusqu''au début de la prochaine phase psychique, la cible ne peut pas tirer en état d''alerte, ne peut être choisie pour combattre tant que toutes les figurines en mesure de le faire aient combattu à la phase de combat (même si elle a chargée), et doit soustraire 1 à ses jets de touche.',
                           'If manifested; select a visible enemy model within 18" of the psyker. Until the start of
the next Psychic phase, the target cannot fire Overwatch, cannot be chosen to fight until
all other models able to do so have fought in the Fight phase (even if it charged), and must subtract 1 from its hit rolls.',
                           32
                       ),
                       (
                           1,
                           5,
                           'L''horreur',
                           'The horror',
                           3,
                           'GCH',
                           'S''il est manifesté, choisissez une figurine ennemie visible du psyker et à 18" de celui-ci. Jusqu''au début de la prochaine phase psychique, cette figurine doit soustraire 1 à ses jets de touche et à sa caractéristique de Commandement.',
                           'If manifested, select an enemy model within 
18" of and visible to the psyker. Until the 
start of the next Psychic phase, that model must subtract 1 from their hit rolls and Leadership characteristic.',
                           37
                       ),
                       (
                           1,
                           5,
                           'Catalyseur',
                           'Catalyst',
                           2,
                           'GCH',
                           'S''il est manifesté, choisissez une figurine amie à 18" du psyker. Jusqu''au début de la prochaine phase psychique, jetez un D6 lorsqu''une figurne amie à 6" du psyker perd un PV; sur 5+ ce PV n''est pas perdu. Si la figurine dispose d''une aptitude similaire, vous pouvez choisir quel effet s''applique, et relancer les 1 obtenus sur le jet de dé.',
                           'If manifested, select a friendly model within 
18" of the psyker. Until the start of the next Psychic phase, roll a D6 each time that model loses a wound. On a 5+ that wound is not lost. If a model already has an ability with a similar effect, you can choose which effect applies, and re-roll ls when making these rolls.',
                           36
                       ),
                       (
                           1,
                           5,
                           'Poing d''acier',
                           'Hammerhand',
                           0,
                           'GKC',
                           'S''il est manifesté, choisissez une figurine amie à 8" du psyker. Ajoutez 1 aux jets de blessure des armes de mêlée de cette figurine jusqu''au début de la prochaine phase psychique.',
                           'If manifested, pick a friendly model within 8" of the psyker. Add 1 to wound rolls you make for that model''s Melee weapons until the start of the next Psychic phase.',
                           38
                       ),
                       (
                           1,
                           4,
                           'Domination',
                           'Dominion',
                           1,
                           'GCH',
                           'S''il est manifesté, choisissez une figurine amie à 18" du psyker avec l''aptitude Comportement instinctif. Jusqu''au début de la prochaine phase psychique, cette figurine ignore son aptitude comportement instinctif et réussit automatiquement ses test de sang froid.',
                           'If manifested, select a friendly model within 18" of the psyker that has the Instinctive Behaviour ability. Until the start of the next Psychic phase, that model ignores its Instinctive Behaviour ability and automatically passes Nerve tests.',
                           35
                       );
INSERT OR IGNORE INTO Figurines (
                          NomFr,
                          NomEn,
                          MotClesFr,
                          MotClesEn,
                          FactionId,
                          Id
                      )
                      VALUES (
                          'Primaris Captain',
                          'Primaris Captain',
                          'IMPERIUM, COMMANDANT, INFANTERIE, PRIMARIS, CAPTAIN',
                          'IMPERIUM, COMMANDER, INFANTRY, PRIMARIS, CAPTAIN',
                          'DW',
                          'AACDW'
                      ),
                      (
                          'Primaris Chaplain',
                          'Primaris Chaplain',
                          'IMPERIUM, COMMANDANT, INFANTERIE, PRIMARIS, CHAPLAIN',
                          'IMPERIUM, COMMANDER, INFANTRY, PRIMARIS, CHAPLAIN',
                          'DW',
                          'AAHDW'
                      ),
                      (
                          'Primaris Librarian',
                          'Primaris Librarian',
                          'IMPERIUM, COMMANDANT, INFANTERIE, PRIMARIS, PSYKER, LIBRARIAN ',
                          'IMPERIUM, COMMANDER, INFANTRY, PRIMARIS, PSYKER, LIBRARIAN ',
                          'DW',
                          'AABDW'
                      );
					  
INSERT OR IGNORE INTO Declinaisons (
                             NbPsyAbjures,
                             NbPsyManifestes,
                             NbPsyConnus,
                             Commandant,
                             cout,
                             Sv,
                             PV,
                             NomFr,
                             NomEn,
                             Max,
                             M,
                             FigurineId,
                             F,
                             E,
                             Cd,
                             CT,
                             CC,
                             A,
                             Id
                         )
                         VALUES (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             6,
                             'Primaris Captain',
                             'Primaris Captain',
                             1,
                             6,
                             'AACDW',
                             4,
                             4,
                             9,
                             2,
                             2,
                             5,
                             'AACDW'
                         ),
                         (
                             0,
                             0,
                             0,
                             1,
                             0,
                             3,
                             5,
                             'Primaris Chaplain',
                             'Primaris Chaplain',
                             1,
                             6,
                             'AAHDW',
                             4,
                             4,
                             9,
                             3,
                             2,
                             4,
                             'AAHDW'
                         ),
                         (
                             1,
                             2,
                             2,
                             1,
                             0,
                             3,
                             5,
                             'Primaris Librarian',
                             'Primaris Librarian',
                             1,
                             6,
                             'AABDW',
                             4,
                             4,
                             9,
                             3,
                             3,
                             4,
                             'AABDW'
                         );

						 INSERT OR IGNORE INTO DeclinaisonSpecialite (
                                      SpecialiteId,
                                      DeclinaisonId
                                  )
                                  VALUES (
                                      'FR',
                                      'AACDW'
                                  ),
                                  (
                                      'FE',
                                      'AACDW'
                                  ),
                                  (
                                      'LE',
                                      'AACDW'
                                  ),
                                  (
                                      'LO',
                                      'AACDW'
                                  ),
                                  (
                                      'ME',
                                      'AACDW'
                                  ),
                                  (
                                      'SH',
                                      'AACDW'
                                  ),
                                  (
                                      'SE',
                                      'AACDW'
                                  ),
                                  (
                                      'ST',
                                      'AACDW'
                                  ),
                                  (
                                      'F',
                                      'AACDW'
                                  ),
                                  (
                                      'FR',
                                      'AAHDW'
                                  ),
                                  (
                                      'FE',
                                      'AAHDW'
                                  ),
                                  (
                                      'LE',
                                      'AAHDW'
                                  ),
                                  (
                                      'ME',
                                      'AAHDW'
                                  ),
                                  (
                                      'SH',
                                      'AAHDW'
                                  ),
                                  (
                                      'F',
                                      'AAHDW'
                                  ),
                                  (
                                      'FE',
                                      'AABDW'
                                  ),
                                  (
                                      'ME',
                                      'AABDW'
                                  ),
                                  (
                                      'P',
                                      'AABDW'
                                  ),
                                  (
                                      'SH',
                                      'AABDW'
                                  ),
                                  (
                                      'F',
                                      'AABDW'
                                  );

INSERT OR IGNORE INTO Tactiques (
                          Commandant,
                          Aura,
                          DeclinaisonId,
                          SpecialiteId,
                          Point,
                          NomFr,
                          NomEn,
                          Niveau,
                          FactionId,
                          DescriptionFr,
                          DescriptionEn,
                          Id
                      )
                      VALUES (
                          1,
                          1,
                          'AACDW',
                          NULL,
                          1,
                          'Rites de bataille',
                          'Rites of battle',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Tir si votre kill team inclut un Primaris Captain. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez relancer les jets de touche de 1 des figurines amies à 6".',
                          'Use this Tactic at the start of the Shooting phase if your kill team includes a PRIMARIS CAPTAIN. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can re- roll hit rolls of 1 for friendly models within 6" of this model.',
                          'AACDW'
                      ),
                      (
                          1,
                          1,
                          'AAHDW',
                          NULL,
                          1,
                          'Chef spirituel',
                          'Spiritual leader',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Mouvement si votre kill team inclut un Primaris Chaplain. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, les figurines amies à 6"peuvent utiliser la caractéristique Commandement de cette figurine à la place de la leur.',
                          'Use this Tactic at the start of the Movement phase if your kill team includes a PRIMARIS CHAPLAIN. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, friendly models within 6" of this model can use this model''s Leadership characteristic instead of their own.',
                          'AAHDW2'
                      ),
                      (
                          1,
                          1,
                          'AAHDW',
                          NULL,
                          1,
                          'Litanies de haine',
                          'Litanies of hate',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de Combat si votre kill team inclut un Primaris Chaplain. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round: Tant que cette figurine n''est pas secouée, vous pouvez relancer les jets de touche ratés en phase de Combat des figurines amies à 6".',
                          'Use this Tactic at the start of the Fight phase if your kill team includes a PRIMARIS CHAPLAIN. That model gains the following aura ability until the end of the battle round: 
As long as this model is not shaken, you can re­roll failed hit rolls in the Fight phase for friendly models within 6" of this model.',
                          'AAHDW'
                      );

					  INSERT OR IGNORE INTO DeclinaisonArme (
                                ArmeId,
                                DeclinaisonId
                            )
                            VALUES (
                                'PB',
                                'AACDW'
                            ),
                            (
                                'FBAM',
                                'AACDW'
                            ),
                            (
                                'GK',
                                'AACDW'
                            ),
                            (
                                'GF',
                                'AACDW'
                            ),
                            (
                                'GK',
                                'AAHDW'
                            ),
                            (
                                'GF',
                                'AAHDW'
                            ),
                            (
                                'PBA',
                                'AAHDW'
                            ),
                            (
                                'CA',
                                'AAHDW'
                            ),
                            (
                                'GK',
                                'AABDW'
                            ),
                            (
                                'GF',
                                'AABDW'
                            ),
                            (
                                'PB',
                                'AABDW'
                            ),
                            (
                                'FS',
                                'AABDW'
                            );

							INSERT OR IGNORE INTO Remplacement (
                             Operation,
                             MaxParTeam,
                             FigurineId,
                             Exclusion,
                             DeclinaisonId,
                             Id
                         )
                         VALUES (
                             'FBAM:FBSM',
                             0,
                             NULL,
                             NULL,
                             'AACDW',
                             241
                         ),
                         (
                             'EPE',
                             0,
                             NULL,
                             NULL,
                             'AACDW',
                             242
                         );
INSERT OR IGNORE INTO CoutNiveau (
                           Cout,
                           Niveau,
                           DeclinaisonId,
                           Id
                       )
                       VALUES (
                           81,
                           1,
                           'AAB',
                           'AAB1'
                       ),
                       (
                           101,
                           2,
                           'AAB',
                           'AAB2'
                       ),
                       (
                           121,
                           3,
                           'AAB',
                           'AAB3'
                       ),
                       (
                           146,
                           4,
                           'AAB',
                           'AAB4'
                       ),
                       (
                           81,
                           1,
                           'AABDW',
                           'AABDW1'
                       ),
                       (
                           101,
                           2,
                           'AABDW',
                           'AABDW2'
                       ),
                       (
                           121,
                           3,
                           'AABDW',
                           'AABDW3'
                       ),
                       (
                           146,
                           4,
                           'AABDW',
                           'AABDW4'
                       ),
                       (
                           76,
                           1,
                           'AAC',
                           'AAC1'
                       ),
                       (
                           96,
                           2,
                           'AAC',
                           'AAC2'
                       ),
                       (
                           116,
                           3,
                           'AAC',
                           'AAC3'
                       ),
                       (
                           141,
                           4,
                           'AAC',
                           'AAC4'
                       ),
                       (
                           76,
                           1,
                           'AACDW',
                           'AACDW1'
                       ),
                       (
                           96,
                           2,
                           'AACDW',
                           'AACDW2'
                       ),
                       (
                           116,
                           3,
                           'AACDW',
                           'AACDW3'
                       ),
                       (
                           141,
                           4,
                           'AACDW',
                           'AACDW4'
                       ),
                       (
                           63,
                           1,
                           'AAH',
                           'AAH1'
                       ),
                       (
                           78,
                           2,
                           'AAH',
                           'AAH2'
                       ),
                       (
                           93,
                           3,
                           'AAH',
                           'AAH3'
                       ),
                       (
                           118,
                           4,
                           'AAH',
                           'AAH4'
                       ),
                       (
                           63,
                           1,
                           'AAHDW',
                           'AAHDW1'
                       ),
                       (
                           78,
                           2,
                           'AAHDW',
                           'AAHDW2'
                       ),
                       (
                           93,
                           3,
                           'AAHDW',
                           'AAHDW3'
                       ),
                       (
                           118,
                           4,
                           'AAHDW',
                           'AAHDW4'
                       ),
                       (
                           46,
                           1,
                           'AAL',
                           'AAL1'
                       ),
                       (
                           61,
                           2,
                           'AAL',
                           'AAL2'
                       ),
                       (
                           76,
                           3,
                           'AAL',
                           'AAL3'
                       ),
                       (
                           101,
                           4,
                           'AAL',
                           'AAL4'
                       ),
                       (
                           10,
                           1,
                           'AMC1',
                           'AMC11'
                       ),
                       (
                           15,
                           2,
                           'AMC1',
                           'AMC12'
                       ),
                       (
                           30,
                           3,
                           'AMC1',
                           'AMC13'
                       ),
                       (
                           50,
                           4,
                           'AMC1',
                           'AMC14'
                       ),
                       (
                           25,
                           1,
                           'AMC2',
                           'AMC21'
                       ),
                       (
                           30,
                           2,
                           'AMC2',
                           'AMC22'
                       ),
                       (
                           45,
                           3,
                           'AMC2',
                           'AMC23'
                       ),
                       (
                           65,
                           4,
                           'AMC2',
                           'AMC24'
                       ),
                       (
                           10,
                           1,
                           'AMP1',
                           'AMP11'
                       ),
                       (
                           15,
                           2,
                           'AMP1',
                           'AMP12'
                       ),
                       (
                           30,
                           3,
                           'AMP1',
                           'AMP13'
                       ),
                       (
                           50,
                           4,
                           'AMP1',
                           'AMP14'
                       ),
                       (
                           15,
                           1,
                           'AMP2',
                           'AMP21'
                       ),
                       (
                           20,
                           2,
                           'AMP2',
                           'AMP22'
                       ),
                       (
                           35,
                           3,
                           'AMP2',
                           'AMP23'
                       ),
                       (
                           55,
                           4,
                           'AMP2',
                           'AMP24'
                       ),
                       (
                           25,
                           1,
                           'AMT',
                           'AMT1'
                       ),
                       (
                           30,
                           2,
                           'AMT',
                           'AMT2'
                       ),
                       (
                           45,
                           3,
                           'AMT',
                           'AMT3'
                       ),
                       (
                           65,
                           4,
                           'AMT',
                           'AMT4'
                       ),
                       (
                           45,
                           1,
                           'ARD',
                           'ARD1'
                       ),
                       (
                           60,
                           2,
                           'ARD',
                           'ARD2'
                       ),
                       (
                           75,
                           3,
                           'ARD',
                           'ARD3'
                       ),
                       (
                           100,
                           4,
                           'ARD',
                           'ARD4'
                       ),
                       (
                           65,
                           1,
                           'ARS',
                           'ARS1'
                       ),
                       (
                           80,
                           2,
                           'ARS',
                           'ARS2'
                       ),
                       (
                           95,
                           3,
                           'ARS',
                           'ARS3'
                       ),
                       (
                           120,
                           4,
                           'ARS',
                           'ARS4'
                       ),
                       (
                           50,
                           1,
                           'ART',
                           'ART1'
                       ),
                       (
                           65,
                           2,
                           'ART',
                           'ART2'
                       ),
                       (
                           80,
                           3,
                           'ART',
                           'ART3'
                       ),
                       (
                           105,
                           4,
                           'ART',
                           'ART4'
                       ),
                       (
                           55,
                           1,
                           'ASA',
                           'ASA1'
                       ),
                       (
                           70,
                           2,
                           'ASA',
                           'ASA2'
                       ),
                       (
                           85,
                           3,
                           'ASA',
                           'ASA3'
                       ),
                       (
                           110,
                           4,
                           'ASA',
                           'ASA4'
                       ),
                       (
                           55,
                           1,
                           'ASF',
                           'ASF1'
                       ),
                       (
                           70,
                           2,
                           'ASF',
                           'ASF2'
                       ),
                       (
                           85,
                           3,
                           'ASF',
                           'ASF3'
                       ),
                       (
                           110,
                           4,
                           'ASF',
                           'ASF4'
                       ),
                       (
                           20,
                           1,
                           'ASW',
                           'ASW1'
                       ),
                       (
                           25,
                           2,
                           'ASW',
                           'ASW2'
                       ),
                       (
                           40,
                           3,
                           'ASW',
                           'ASW3'
                       ),
                       (
                           60,
                           4,
                           'ASW',
                           'ASW4'
                       ),
                       (
                           50,
                           1,
                           'DGB',
                           'DGB1'
                       ),
                       (
                           65,
                           2,
                           'DGB',
                           'DGB2'
                       ),
                       (
                           80,
                           3,
                           'DGB',
                           'DGB3'
                       ),
                       (
                           105,
                           4,
                           'DGB',
                           'DGB4'
                       ),
                       (
                           80,
                           1,
                           'DGF',
                           'DGF1'
                       ),
                       (
                           100,
                           2,
                           'DGF',
                           'DGF2'
                       ),
                       (
                           120,
                           3,
                           'DGF',
                           'DGF3'
                       ),
                       (
                           145,
                           4,
                           'DGF',
                           'DGF4'
                       ),
                       (
                           45,
                           1,
                           'DGPS',
                           'DGPS1'
                       ),
                       (
                           60,
                           2,
                           'DGPS',
                           'DGPS2'
                       ),
                       (
                           75,
                           3,
                           'DGPS',
                           'DGPS3'
                       ),
                       (
                           100,
                           4,
                           'DGPS',
                           'DGPS4'
                       ),
                       (
                           45,
                           1,
                           'DGT',
                           'DGT1'
                       ),
                       (
                           60,
                           2,
                           'DGT',
                           'DGT2'
                       ),
                       (
                           75,
                           3,
                           'DGT',
                           'DGT3'
                       ),
                       (
                           100,
                           4,
                           'DGT',
                           'DGT4'
                       ),
                       (
                           56,
                           1,
                           'DRA',
                           'DRA1'
                       ),
                       (
                           71,
                           2,
                           'DRA',
                           'DRA2'
                       ),
                       (
                           86,
                           3,
                           'DRA',
                           'DRA3'
                       ),
                       (
                           111,
                           4,
                           'DRA',
                           'DRA4'
                       ),
                       (
                           30,
                           1,
                           'DRH',
                           'DRH1'
                       ),
                       (
                           35,
                           2,
                           'DRH',
                           'DRH2'
                       ),
                       (
                           50,
                           3,
                           'DRH',
                           'DRH3'
                       ),
                       (
                           70,
                           4,
                           'DRH',
                           'DRH4'
                       ),
                       (
                           48,
                           1,
                           'DRS',
                           'DRS1'
                       ),
                       (
                           63,
                           2,
                           'DRS',
                           'DRS2'
                       ),
                       (
                           78,
                           3,
                           'DRS',
                           'DRS3'
                       ),
                       (
                           103,
                           4,
                           'DRS',
                           'DRS4'
                       ),
                       (
                           125,
                           1,
                           'DWW',
                           'DWW1'
                       ),
                       (
                           145,
                           2,
                           'DWW',
                           'DWW2'
                       ),
                       (
                           165,
                           3,
                           'DWW',
                           'DWW3'
                       ),
                       (
                           190,
                           4,
                           'DWW',
                           'DWW4'
                       ),
                       (
                           18,
                           1,
                           'GCA',
                           'GCA1'
                       ),
                       (
                           23,
                           2,
                           'GCA',
                           'GCA2'
                       ),
                       (
                           38,
                           3,
                           'GCA',
                           'GCA3'
                       ),
                       (
                           58,
                           4,
                           'GCA',
                           'GCA4'
                       ),
                       (
                           131,
                           1,
                           'GCH',
                           'GCH1'
                       ),
                       (
                           151,
                           2,
                           'GCH',
                           'GCH2'
                       ),
                       (
                           171,
                           3,
                           'GCH',
                           'GCH3'
                       ),
                       (
                           196,
                           4,
                           'GCH',
                           'GCH4'
                       ),
                       (
                           28,
                           1,
                           'GCP',
                           'GCP1'
                       ),
                       (
                           33,
                           2,
                           'GCP',
                           'GCP2'
                       ),
                       (
                           48,
                           3,
                           'GCP',
                           'GCP3'
                       ),
                       (
                           68,
                           4,
                           'GCP',
                           'GCP4'
                       ),
                       (
                           30,
                           1,
                           'GCZ',
                           'GCZ1'
                       ),
                       (
                           35,
                           2,
                           'GCZ',
                           'GCZ2'
                       ),
                       (
                           50,
                           3,
                           'GCZ',
                           'GCZ3'
                       ),
                       (
                           70,
                           4,
                           'GCZ',
                           'GCZ4'
                       ),
                       (
                           108,
                           1,
                           'GKC',
                           'GKC1'
                       ),
                       (
                           128,
                           2,
                           'GKC',
                           'GKC2'
                       ),
                       (
                           148,
                           3,
                           'GKC',
                           'GKC3'
                       ),
                       (
                           173,
                           4,
                           'GKC',
                           'GKC4'
                       ),
                       (
                           30,
                           1,
                           'HAE',
                           'HAE1'
                       ),
                       (
                           35,
                           2,
                           'HAE',
                           'HAE2'
                       ),
                       (
                           50,
                           3,
                           'HAE',
                           'HAE3'
                       ),
                       (
                           70,
                           4,
                           'HAE',
                           'HAE4'
                       ),
                       (
                           65,
                           1,
                           'HAS',
                           'HAS1'
                       ),
                       (
                           80,
                           2,
                           'HAS',
                           'HAS2'
                       ),
                       (
                           95,
                           3,
                           'HAS',
                           'HAS3'
                       ),
                       (
                           120,
                           4,
                           'HAS',
                           'HAS4'
                       ),
                       (
                           130,
                           1,
                           'MED',
                           'MED1'
                       ),
                       (
                           150,
                           2,
                           'MED',
                           'MED2'
                       ),
                       (
                           170,
                           3,
                           'MED',
                           'MED3'
                       ),
                       (
                           195,
                           4,
                           'MED',
                           'MED4'
                       ),
                       (
                           28,
                           1,
                           'MET',
                           'MET1'
                       ),
                       (
                           33,
                           2,
                           'MET',
                           'MET2'
                       ),
                       (
                           48,
                           3,
                           'MET',
                           'MET3'
                       ),
                       (
                           68,
                           4,
                           'MET',
                           'MET4'
                       ),
                       (
                           86,
                           1,
                           'NEO',
                           'NEO1'
                       ),
                       (
                           106,
                           2,
                           'NEO',
                           'NEO2'
                       ),
                       (
                           126,
                           3,
                           'NEO',
                           'NEO3'
                       ),
                       (
                           151,
                           4,
                           'NEO',
                           'NEO4'
                       ),
                       (
                           44,
                           1,
                           'NEY',
                           'NEY1'
                       ),
                       (
                           59,
                           2,
                           'NEY',
                           'NEY2'
                       ),
                       (
                           74,
                           3,
                           'NEY',
                           'NEY3'
                       ),
                       (
                           99,
                           4,
                           'NEY',
                           'NEY4'
                       ),
                       (
                           20,
                           1,
                           'ORBM',
                           'ORBM1'
                       ),
                       (
                           25,
                           2,
                           'ORBM',
                           'ORBM2'
                       ),
                       (
                           40,
                           3,
                           'ORBM',
                           'ORBM3'
                       ),
                       (
                           60,
                           4,
                           'ORBM',
                           'ORBM4'
                       ),
                       (
                           20,
                           1,
                           'ORP',
                           'ORP1'
                       ),
                       (
                           25,
                           2,
                           'ORP',
                           'ORP2'
                       ),
                       (
                           40,
                           3,
                           'ORP',
                           'ORP3'
                       ),
                       (
                           60,
                           4,
                           'ORP',
                           'ORP4'
                       ),
                       (
                           62,
                           1,
                           'ORW',
                           'ORW1'
                       ),
                       (
                           82,
                           2,
                           'ORW',
                           'ORW2'
                       ),
                       (
                           102,
                           3,
                           'ORW',
                           'ORW3'
                       ),
                       (
                           127,
                           4,
                           'ORW',
                           'ORW4'
                       ),
                       (
                           23,
                           1,
                           'TAC',
                           'TAC1'
                       ),
                       (
                           28,
                           2,
                           'TAC',
                           'TAC2'
                       ),
                       (
                           43,
                           3,
                           'TAC',
                           'TAC3'
                       ),
                       (
                           63,
                           4,
                           'TAC',
                           'TAC4'
                       ),
                       (
                           18,
                           1,
                           'TAE',
                           'TAE1'
                       ),
                       (
                           23,
                           2,
                           'TAE',
                           'TAE2'
                       ),
                       (
                           38,
                           3,
                           'TAE',
                           'TAE3'
                       ),
                       (
                           58,
                           4,
                           'TAE',
                           'TAE4'
                       ),
                       (
                           81,
                           1,
                           'TSE',
                           'TSE1'
                       ),
                       (
                           101,
                           2,
                           'TSE',
                           'TSE2'
                       ),
                       (
                           121,
                           3,
                           'TSE',
                           'TSE3'
                       ),
                       (
                           146,
                           4,
                           'TSE',
                           'TSE4'
                       ),
                       (
                           40,
                           1,
                           'TSTS',
                           'TSTS1'
                       ),
                       (
                           55,
                           2,
                           'TSTS',
                           'TSTS2'
                       ),
                       (
                           70,
                           3,
                           'TSTS',
                           'TSTS3'
                       ),
                       (
                           95,
                           4,
                           'TSTS',
                           'TSTS4'
                       ),
                       (
                           131,
                           1,
                           'TYB',
                           'TYB1'
                       ),
                       (
                           151,
                           2,
                           'TYB',
                           'TYB2'
                       ),
                       (
                           171,
                           3,
                           'TYB',
                           'TYB3'
                       ),
                       (
                           196,
                           4,
                           'TYB',
                           'TYB4'
                       ),
                       (
                           50,
                           1,
                           'TYTP',
                           'TYTP1'
                       ),
                       (
                           65,
                           2,
                           'TYTP',
                           'TYTP2'
                       ),
                       (
                           80,
                           3,
                           'TYTP',
                           'TYTP3'
                       ),
                       (
                           105,
                           4,
                           'TYTP',
                           'TYTP4'
                       );
update declinaisons set Cout = (select cout from CoutNiveau where DeclinaisonId = declinaisons.Id and niveau = 1) where Commandant = 1;
		
INSERT OR IGNORE INTO Psychiques (
                           Commandant,
                           Charge,
                           NomFr,
                           NomEn,
                           De,
                           DeclinaisonId,
                           DescriptionFr,
                           DescriptionEn,
                           Id
                       )
                       VALUES (
                           1,
                           8,
                           'Zone neutre',
                           'Null zone',
                           3,
                           'AABDW',
                           'S''il est manifesté, alors jusqu''au début de la prochaine phase psychique, les figurines ennemies à 3" du psyker ne peuvent pas effectuer de sauvegardes invulnrébles et doivent diviser par deux (en arrondissant au supérieur) les résultats des tests Psychiques qu''elles effectuent.',
                           'If manifested, then until the start of the next Psychic phase, while they are within 3" of the psyker, enemy models cannot take invulnerable saves and must halve the result of any Psychic tests (rounding up) that they take.',
                           41
                       ),
                       (
                           1,
                           6,
                           'Puissance des héros',
                           'Might of heroes',
                           2,
                           'AABDW',
                           'S''il est manifesté, choisissez une figurine amie à 12" du psyker. Jusqu''au début de la prochaine phase psychique, ajoutez 1 à sa Force, son Endurance et ses attaques.',
                           'If manifested, pick a friendly model within 12" of the psyker. Until the start of the next Psychic phase, add 1 to that model''s Strength, Toughness and Attacks characteristics.',
                           40
                       ),
                       (
                           1,
                           5,
                           'Voile du temps',
                           'Veil of time',
                           1,
                           'AABDW',
                           'S''il est manifesté, choisissez une figurine amie à 18" du psyker. Jusqu''au début de la prochaine phase psychique, vous pouvez relancer ses jets de charge et d''avance, et elle peut toujours être choisie pour combattre pendant la section Marteau de Fureur de la phase de Combat, même si elle n''a pas effectué de mouvement de charge à ce round.',
                           'If manifested, pick a friendly model within 18" of the psyker. Until the start of your next Psychic phase, you can re-roll charge rolls and Advance rolls for that model, and they can always 
be chosen to fight in the Hammer of Wrath section of the Fight phase, even if they did not make a charge move that battle round. ',
                           39
                       );
					   
update ProfileArmes set ArmeId = 'GSE' where Id = 'GSEM';
update ProfileArmes set ArmeId = 'GSE' where Id = 'GSER';

INSERT OR IGNORE INTO Aptitudes (
                          NomFr,
                          NomEn,
                          FigurineId,
                          FactionId,
                          DescriptionFr,
                          DescriptionEn,
                          DeclinaisonId,
                          Id
                      )
                      VALUES (
                          'Champ réfracteur',
                          'Refractor Field',
                          NULL,
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 5+.',
                          'A Lord Commissar has a 5+ invulnerable save.',
                          'AMC2',
                          'RF1'
                      ),
                      (
                          'Champ réfracteur',
                          'Refractor Field',
                          'AMP',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 5+.',
                          'This model has a 5+ invulnerable save.',
                          NULL,
                          'RF2'
                      );
					  
update Aptitudes set DescriptionEn = 'This model has a 5+ invulnerable save.' where Id = 'RF';
update Aptitudes set DeclinaisonId='AMP2', FigurineId = NULL where Id = 'SO';
update ProfileArmes set NomFr='Pistolet radiant laser' where id = 'PRL';
INSERT OR IGNORE INTO DeclinaisonArme (  ArmeId, DeclinaisonId ) VALUES ( 'GK','AMT'   );

INSERT OR IGNORE INTO Aptitudes (
                          NomFr,
                          NomEn,
                          FigurineId,
                          FactionId,
                          DescriptionFr,
                          DescriptionEn,
                          DeclinaisonId,
                          Id
                      )
                      VALUES (
                          'Bioniques',
                          'Bionics',
                          'MERU',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 6+.',
                          'This model has a 6+ invulnerable save.',
                          NULL,
                          'BIO1'
                      ),
                      (
                          'Bioniques',
                          'Bionics',
                          'MESI',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 6+.',
                          'This model has a 6+ invulnerable save.',
                          NULL,
                          'BIO2'
                      ),
                      (
                          'Bioniques',
                          'Bionics',
                          'MESR',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 6+.',
                          'This model has a 6+ invulnerable save.',
                          NULL,
                          'BIO3'
                      ),
                      (
                          'Bioniques',
                          'Bionics',
                          'MESV',
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 6+.',
                          'This model has a 6+ invulnerable save.',
                          NULL,
                          'BIO4'
                      ),
					   (
                          'Physiologie transhumaine',
                          'Transhuman Physiology',
                          'TSE',
                          NULL,
                          'Ignorez la pénalité imposée aux jets de touche de cette figurine par 1 blessure légère.',
                          'Ignore the penalty to this model''s hit rolls from one flesh wound it has suffered.',
                          NULL,
                          'TPD5'
                      ),
                      (
                          'Mort au faux empereur',
                          'Death to the False Emperor',
                          'TSE',
                          NULL,
                          'A chaque jet de touche de 6+ pour une figurine avec cette aptitude à la phase de combat, elle peut, si elle ciblait une figurine de l''imperium, effectuer aussitôt une attaque supplémentaire contre la même figurine avec la même arme. Ces attaques bonus n''en génerent pas à leur tour.',
                          'If a model with this ability makes an attack in the Fight phase which targets an IMPERIUM model, each time you roll a hit roll of 6+ you may make an additional attack with the same weapon against the same target. These attacks cannot themselves generate any further attacks.',
                          NULL,
                          'MFE4'
                      ), 
					  (
                          'Protocole de réanimation',
                          'Reanimation Protocols',
                          'NEC',
                          NULL,
                          'Lorsqu''un test de trauma est effectué pour cette figurine, sur un jet non modifié de 6, la figurine n''est pas mise hors de combat et ne subit pas de blessure légère. A la place, elle est ramenée à 1PV restant et sans aucune blessure légère.',
                          'When an Injury roll is made for this model, on an unmodified roll of 6 the model is not taken out of action and does not suffer a flesh wound. Instead it is restored to 1 wound remaining with no flesh wounds.',
                          NULL,
                          'NEC3'
                      ),
                      (
                          'Protocole de réanimation',
                          'Reanimation Protocols',
                          'NED',
                          NULL,
                          'Lorsqu''un test de trauma est effectué pour cette figurine, sur un jet non modifié de 6, la figurine n''est pas mise hors de combat et ne subit pas de blessure légère. A la place, elle est ramenée à 1PV restant et sans aucune blessure légère.',
                          'When an Injury roll is made for this model, on an unmodified roll of 6 the model is not taken out of action and does not suffer a flesh wound. Instead it is restored to 1 wound remaining with no flesh wounds.',
                          NULL,
                          'NEC2'
                      ),
                      (
                          'Protocole de réanimation',
                          'Reanimation Protocols',
                          'NEF',
                          NULL,
                          'Lorsqu''un test de trauma est effectué pour cette figurine, sur un jet non modifié de 6, la figurine n''est pas mise hors de combat et ne subit pas de blessure légère. A la place, elle est ramenée à 1PV restant et sans aucune blessure légère.',
                          'When an Injury roll is made for this model, on an unmodified roll of 6 the model is not taken out of action and does not suffer a flesh wound. Instead it is restored to 1 wound remaining with no flesh wounds.',
                          NULL,
                          'NEC1'
                      );


update Aptitudes set FactionId = NULL, FigurineId = 'MET' where Id = 'BIO';
update ProfileArmes set TypeArmeId = 'A' where Id = 'HGL';

UPDATE Aptitudes SET FactionId = NULL, FigurineId = 'TAC' WHERE Id = 'PBS';
UPDATE Aptitudes SET FactionId = NULL, FigurineId = 'NEI' WHERE Id = 'NEC';

INSERT OR IGNORE INTO Aptitudes (
                          NomFr,
                          NomEn,
                          FigurineId,
                          FactionId,
                          DescriptionFr,
                          DescriptionEn,
                          DeclinaisonId,
                          Id
                      )
                      VALUES (
                          'Pour le bien suprême',
                          'For the Greater Good',
                          'TAP',
                          NULL,
                          'Lorsqu''une figurine ennemie déclare une charge contre une figurine de votre kill team, les figurines de votre kill team, les figurines de votre kill team avec cette aptitude à 6" d''une des cibles de la figurine qui chargent peuvent tirer en état d''alerte comme si elles étaient ciblées elles aussi. Une figurine qui agit ainsi ne peut plus tirer en état d''alerte jusqu''à la fin de la phase.',
                          'When an enemy model declares


a charge against a model from your kill team, models


from your kill team with this ability within 6" of one


of the charging model’s targets may fire Overwatch as


if they were also targeted. Once a model has done so,


they cannot fire Overwatch or Retreat for the rest of


the phase.',
                          NULL,
                          'PBSP'
                      ),
                      (
                          'Pour le bien suprême',
                          'For the Greater Good',
                          'TAF',
                          NULL,
                          'Lorsqu''une figurine ennemie déclare une charge contre une figurine de votre kill team, les figurines de votre kill team, les figurines de votre kill team avec cette aptitude à 6" d''une des cibles de la figurine qui chargent peuvent tirer en état d''alerte comme si elles étaient ciblées elles aussi. Une figurine qui agit ainsi ne peut plus tirer en état d''alerte jusqu''à la fin de la phase.',
                          'When an enemy model declares


a charge against a model from your kill team, models


from your kill team with this ability within 6" of one


of the charging model’s targets may fire Overwatch as


if they were also targeted. Once a model has done so,


they cannot fire Overwatch or Retreat for the rest of


the phase.',
                          NULL,
                          'PBSF'
                      ),
                      (
                          'Pour le bien suprême',
                          'For the Greater Good',
                          'TAB',
                          NULL,
                          'Lorsqu''une figurine ennemie déclare une charge contre une figurine de votre kill team, les figurines de votre kill team, les figurines de votre kill team avec cette aptitude à 6" d''une des cibles de la figurine qui chargent peuvent tirer en état d''alerte comme si elles étaient ciblées elles aussi. Une figurine qui agit ainsi ne peut plus tirer en état d''alerte jusqu''à la fin de la phase.',
                          'When an enemy model declares


a charge against a model from your kill team, models


from your kill team with this ability within 6" of one


of the charging model’s targets may fire Overwatch as


if they were also targeted. Once a model has done so,


they cannot fire Overwatch or Retreat for the rest of


the phase.',
                          NULL,
                          'PBSB'
                      ),
                      (
                          'Pour le bien suprême',
                          'For the Greater Good',
                          'TAD',
                          NULL,
                          'Lorsqu''une figurine ennemie déclare une charge contre une figurine de votre kill team, les figurines de votre kill team, les figurines de votre kill team avec cette aptitude à 6" d''une des cibles de la figurine qui chargent peuvent tirer en état d''alerte comme si elles étaient ciblées elles aussi. Une figurine qui agit ainsi ne peut plus tirer en état d''alerte jusqu''à la fin de la phase.',
                          'When an enemy model declares


a charge against a model from your kill team, models


from your kill team with this ability within 6" of one


of the charging model’s targets may fire Overwatch as


if they were also targeted. Once a model has done so,


they cannot fire Overwatch or Retreat for the rest of


the phase.',
                          NULL,
                          'PBSD'
                      );



COMMIT TRANSACTION;
PRAGMA foreign_keys = on;				 
