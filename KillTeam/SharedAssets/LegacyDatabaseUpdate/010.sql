update Declinaisons set CC = 3 where Id = 'AMS3';

update tactiques set DescriptionFr = 'Relancez un unique jet d''avance, de charge, de test psychique, de test d''abjurer le sorcier, de touche, de blessure, de sauvegarde, de trauma ou de sang froid.' where id = 'ALL5';

update Traits set Point = 15 where Id = 'G4';
update Traits set Point = 10 where Id = 'G3';

update Remplacement set DeclinaisonId = 'DWV3', FigurineId = NULL where Id = 15;
update Remplacement set DeclinaisonId = 'DWV3', FigurineId = NULL where Id = 16;
update Remplacement set DeclinaisonId = 'DWV4', FigurineId = NULL where Id = 17;
INSERT OR IGNORE INTO Remplacement (
                             Operation,
                             MaxParTeam,
                             FigurineId,
                             Exclusion,
                             DeclinaisonId,
                             Id
                         )
                         VALUES (
                             'BO:COF|COP|BOS|EPE|MAE|BST',
                             0,
                             NULL,
                             NULL,
                             'DWV4',
                             246
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
                             'PB:EPE|EPT',
                             0,
                             NULL,
                             'AAI3',
                             'AAI3',
                             243
                         );
						 
UPDATE Remplacement set Exclusion = 'AAI3' where Id = '14';

INSERT  OR IGNORE INTO Remplacement (
                             Operation,
                             MaxParTeam,
                             FigurineId,
                             Exclusion,
                             DeclinaisonId,
                             Id
                         )
                         VALUES (
                             'PBDW:EPE|EPT',
                             0,
                             NULL,
                             'DWI3',
                             'DWI3',
                             244
                         );
						 
UPDATE Remplacement set Exclusion = 'DWI3' where Id = '145';

update ProfileArmes set AptitudesEn = 'When attacking with this weapon, you must subtract 1 from the hit roll.', AptitudesFr='Lorsque vous attaquez avec cette arme, vous devez soustraire 1 au jet de touche.' where id = 188;

UPDATE Remplacement set Operation = 'FBO:EPE|EPT' where Id = '243';
UPDATE Remplacement set Operation = 'FBODW:EPE|EPT' where Id = '244';

Update remplacement  set FigurineId = NULL, DeclinaisonId = NULL where Id = '247';
Update remplacement  set FigurineId = NULL, DeclinaisonId = NULL where Id = '246';