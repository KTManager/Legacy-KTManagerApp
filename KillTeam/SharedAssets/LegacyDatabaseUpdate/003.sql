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
                         NULL,
                         NULL,
                         'Pur et dur',
                         'Die-hard',
                         'Vous pouvez soustraire 1 aux jets de Trauma pour cette figurine.',
                         'You can subtract 1 from Injury rolls for this model.',
                         '6PUR'
                     ),
                     (
                         NULL,
                         NULL,
                         'Mortel Combat',
                         'Lethal Combat',
                         'Vous pouvez relancer les jets de blessure de 1 pour cette figurine à la phase de combat..',
                         'You can re-roll wound rolls of 1 for this model in the Fight phase.',
                         '5MOR2'
                     ),
                     (
                         NULL,
                         NULL,
                         'Mortel Tir',
                         'Lethal Shooting',
                         'Vous pouvez relancer les jets de blessure de 1 pour cette figurine lorsqu''elle effectue des attaques de tir.',
                         'You can re-roll wound rolls of 1 for this model when it makes shooting attacks.',
                         '5MOR1'
                     ),
                     (
                         NULL,
                         NULL,
                         'Compétent Combat',
                         'Skilled Fight',
                         'Vous pouvez relancer les jets de touche de 1 pour cette figurine à la phase de combat..',
                         'You can re-roll hit rolls of 1 for this model in the Fight phase.',
                         '4COMP2'
                     ),
                     (
                         NULL,
                         NULL,
                         'Compétent Tir',
                         'Skilled Shooting',
                         'Vous pouvez relancer les jets de touche de 1 pour cette figurine lorsqu''elle effectue des attaques de tir.',
                         'You can re-roll hit rolls of 1 for this model when it makes shooting attacks.',
                         '4COMP1'
                     ),
                     (
                         NULL,
                         NULL,
                         'Courageux',
                         'Courageous',
                         'Vous pouvez relancer les tests de sang froid pour cette figurine.',
                         'You can re-roll failed Nerve tests for this model.',
                         '3COU'
                     ),
                     (
                         NULL,
                         NULL,
                         'Chanceux',
                         'Lucky',
                         'Vous pouvez rlenacer les jets de sauvegarde de 1 pour cette figurine.',
                         'You can re-roll save rolls of 1 for this model.',
                         '2CHA'
                     ),
                     (
                         NULL,
                         NULL,
                         'Vif',
                         'Fleet',
                         'Ajoutez 1" à la caractéristique de mouvement de cette figurine.',
                         'Add 1" to this model’s Move characteristic.',
                         '1VIF'
                     );

Update ProfileArmes set AptitudesFr = 'Ajoutez 1 à la Force de cette arme si la cible est à la moitié de la portée ou moins.',
                         AptitudesEn = 'If the target is within half range, add 1 to this weapon’s Strength.' where Id = 'FP';
						 
Update Declinaisons set Sv = 7 where Id = 'DGP';
Update Declinaisons set NomFr='Special Weapons Guardman', NomEn='Special Weapons Guardman' where Id = 'AMW1';

INSERT OR IGNORE INTO Armes (
                      cout,
                      NomFr,
                      NomEn,
                      DescriptionAdditionnelleFr,
                      DescriptionAdditionnelleEn,
                      Id
                  )
                  VALUES (
                      2,
                      'Gantelet énergétque',
                      'Power fist',
                      NULL,
                      NULL,
                      'GEN2'
                  );

INSERT OR IGNORE  INTO ProfileArmes (
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
-                            3,
                             'Gantelet énergétique',
                             'Power fist',
                             0,
                             'x2',
                             'D3',
                             'GEN2',
                             'Soustrayez 1 du jet de touche lorsque vous attaquez avec cette arme',
                             'When attacking with this weapon, you must substract 1 from the hit roll.',
                             'GEN2'
                         );

Update Remplacement set Operation = 'EPT:EPE1|GEN2' where Id = 31;
Update Remplacement set Operation = 'EPT:EPE1' where Id = 26;
update Aptitudes set FigurineId = 'MESI' where Id = 'AUR';
Update Remplacement set Operation = 'PCU:EPO2' where Id = 120;
update TypeArmes set [Index] = 4 where Id = 'M';
update TypeArmes set [Index] = 5 where Id = 'P';
update TypeArmes set [Index] = 6 where Id = 'G';