
Update ProfileArmes set AptitudesFr = 'Chaque fois que le porteur combat, il peut effectuer une attaque supplémentaire avec cette arme. Vous pouvez relancer les jets de blessure ratés pour cette arme.',
                         AptitudesEn = '"Each time the bearer fights, it can make 1 additional attack with this weapon. You can re-roll failed wound rolls for this weapon."' where Id = 'GAH';

INSERT OR IGNORE INTO Armes (
                      cout,
                      NomFr,
                      NomEn,
                      DescriptionAdditionnelleFr,
                      DescriptionAdditionnelleEn,
                      Id
                  )
                  VALUES (
                      1,
                      'Masse énergétique',
                      'Power maul',
                      NULL,
                      NULL,
                      'MAE1'
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
                             'M',
                             'M',
-                            1,
                             'Masse énergétique',
                             'Power maul',
                             0,
                             '+2',
                             1,
                             'MAE1',
                             NULL,
                             NULL,
                             'MAE1'
                         );

Update remplacement set Operation = 'FUA&PMI:(PMI|PB|LTL)&(EPT|PIE|MAE1)' where Id = 127;
update Armes set NomEn = 'Metamorph talon' where ID = 'GME';
update ProfileArmes set NomEn = 'Metamorph talon' where ID = 'GME';
update Aptitudes set DeclinaisonId = 'TSM3', FigurineId = NULL where ID = 'PTR6';
update Aptitudes set DeclinaisonId = 'TSM1', FigurineId = NULL where ID = 'TQP';

INSERT or replace INTO Aptitudes (
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
                          'Tout n''est que poussière',
                          'All is Dust',
                          NULL,
                          NULL,
                          'Ajoutez 1 aux jets de sauvegarde pour un Rubric Marine ou un Rubric Marine Gunner si l''attaque a une caractéristique de dégâts de 1. De plus, le modificateurde -1 aux jets de touche pour se déplacer et tirer avec les armes lourdes ne s''applique pas aux Rubric Marine Gunners.',
                          'Add 1 to saving throws for a Rubric Marine or Rubric Marine Gunner if the attack has a Damage characteristic of 1. In addition, the -1 modifier to hit rolls for moving and shooting Heavy weapons does not apply to Rubric Marine Gunners.',
                          'TSM2',
                          'TQP2'
                      );
					  
Update DeclinaisonSpecialite set SpecialiteId = 'CB' where SpecialiteId = 'CO' and DeclinaisonId='GCB';