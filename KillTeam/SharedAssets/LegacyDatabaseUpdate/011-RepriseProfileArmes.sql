--
-- Fichier généré par SQLiteStudio v3.2.1 sur ven. nov. 9 09:25:39 2018
--
-- Encodage texte utilisé : System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

Delete from ProfileArmes;

INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('BO', NULL, NULL, 'BO', '1', '4', '1', 'BoltGun', 'Bolter', '0', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('BOL', NULL, NULL, 'BOL', '1', '5', '3', 'Heavy Bolter', 'Bolter lourd', '-1', 36, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CBO', NULL, NULL, 'CBO', '1', '4', '2', 'Bolt Carbine', 'Carabine Bolter', '0', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('COF2', 'If the target is within half range of this weapon, roll two dice













when inflicting damage with it and discard the lowest result.', 'Si la cible est à mi-portée ou moins de cette arme, jetez deux dés pour ses dégâts et défaussez le résultat le plus bas.', 'COF', 'D6', '8', '1', 'Meltagun', 'Fuseur', '-4', 12, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('COF1', NULL, NULL, 'COF', '1', '4', '1', 'Boltgun', 'Bolter', '0', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('COG2', 'If the target has a Save characteristic of 3+ or better, this













weapon has a Damage of D3.', 'Si la cible a une caractéristique de Sauvegarde de 3+ ou mieux, cette arme a un dégat de D3.', 'COG', '1', '5', '1', 'Grav-gun', 'Fusil à gravitons', '-3', 18, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('COG1', NULL, NULL, 'COG', '1', '4', '1', 'Boltgun', 'Bolter', '0', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('COL2', 'This weapon automatically hits its target.', 'Cette arme touche automatiquement sa cible', 'COL', '1', '4', 'D6', 'Flamer', 'Lance-flammes', '0', 8, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('COL1', NULL, NULL, 'COL', '1', '4', '1', 'Boltgun', 'Bolter', '0', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('COP3', 'On an unmodified hit roll of 1, the bearer is taken out of













action.', 'Sur un jet de touche non modifié de 1, le porteur est mis hors de combat une fois tous les tirs de l''arme résolus.', 'COP', '2', '8', '1', 'Plasma Gun supercharge', 'Fusil à plasma surcharge', '-3', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('COP2', NULL, NULL, 'COP', '1', '7', '1', 'Plasma Gun standard', 'Fusil à plasma standard', '-3', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('COP1', NULL, NULL, 'COP', '1', '4', '1', 'Boltgun', 'Bolter', '0', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FU', 'If the target is within half range of this weapon, roll two dice













when inflicting damage with it and discard the lowest result.', 'Si la cible est à mi-portée ou moins de cette arme, jetez deux dés pour ses dégâts et défaussez le résultat le plus bas.', 'FU', 'D6', '8', '1', 'Meltagun', 'Fuseur', '-4', 12, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FG', 'If the target has a Save characteristic of 3+ or better, this













weapon has a Damage of D3.', 'Si la cible a une caractéristique de Sauvegarde de 3+ ou mieux, cette arme a un dégat de D3.', 'FG', '1', '5', '1', 'Grav-gun', 'Fusil à gravitons', '-3', 18, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PLA2', 'On an unmodified hit roll of 1, the bearer is taken out of













action.', 'Sur un jet de touche non modifié de 1, le porteur est mis hors de combat une fois tous les tirs de l''arme résolus.', 'PLA', '2', '8', '1', 'Supercharge', 'Surcharge', '-3', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PLA1', NULL, NULL, 'PLA', '1', '7', '1', 'Standard', 'Standard', '-3', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FPA', 'If the target is within half range, add 1 to this weapon’s













Strength.', 'Ajoutez 1 à la Force de cette arme si la cible est à la moitié de la portée ou moins.', 'FPA', '1', '4', '2', 'Astartes Shotgun', 'Fusil à pompe Astartes', '0', 12, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FBO', NULL, NULL, 'FBO', '1', '4', '1', 'Bolt Rifle', 'Fusil Bolter', '-1', 30, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FBA', NULL, NULL, 'FBA', '1', '4', '2', 'Auto bolt rifle', 'Fusil Bolter Automatique', '0', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FBS', NULL, NULL, 'FBS', '1', '4', '1', 'Stalker bolt rifle', 'Fusil Bolter Stalker', '-2', 36, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SN', 'A model firing a sniper rifle does not suffer the penalty to hit













rolls for the target being at long range. If you roll a wound roll













of 6+ for this weapon, it inflicts a mortal wound in addition to













its normal damage.', 'Une figurine tirant avec un fusil de sniper ne subit pas de malus pour toucher à longue portée. Si vous obtenez un jet de blessure de 6+ avec cette arme, elle inflige une blessure mortelle en plus des dégâts normaux.', 'SN', '1', '4', '1', 'Sniper rifle', 'Fusil de sniper', '0', 36, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GF', NULL, NULL, 'GF', '1', '3', 'D6', 'Frag grenade', 'Grenade Frag', '0', 6, 'G');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GK', NULL, NULL, 'GK', 'D3', '6', '1', 'Krak grenade', 'Grenade Krak', '-1', 6, 'G');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GS', 'This weapon does not inflict any damage. If an enemy













INFANTRY model is hit by any shock grenades, it is stunned;













until the end of the next battle round that model cannot fire













Overwatch or be Readied, and your opponent must subtract 1













from hit rolls made for the model.', 'Cette arme n''inflige pas de dégâts. Si une figurine d''INFANTERIE enne mie est touchée par une grenade Shock, elle est sonnée: jusqu''à la fin du prochain round de bataille, cette figurine ne peut tirer en état d''Alerte ou être préparée, et l''adversaire doit soustraire 1 des jets de touche pour cette figurine.', 'GS', '*', '*', 'D3', 'Shock Grenade', 'Grenade Shock', '*', 6, 'G');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LF', 'This weapon automatically hits its target.', 'Cette arme touche automatiquement sa cible', 'LF', '1', '4', 'D6', 'Flamer', 'Lance-flammes', '0', 8, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LM1', NULL, NULL, 'LM', '1', '4', 'D6', 'Frag missile', 'Missile Frag', '0', 48, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LM2', NULL, NULL, 'LM', 'D6', '8', '1', 'Krak missile', 'Missile Krak', '-2', 48, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PG', 'If the target has a Save characteristic of 3+ or better, this













weapon has a Damage of D3.', 'Si la cible a une caractéristique de Sauvegarde de 3+ ou mieux, cette arme a un dégat de D3.', 'PG', '1', '5', '1', 'Grav pistol', 'Pistolet à gravitons', '-3', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PP1', NULL, NULL, 'PP', '1', '7', '1', 'Standard', 'Standard', '-3', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PP2', 'On an unmodified hit roll of 1, the bearer is taken out of













action.', 'Sur un jet de touche non modifié de 1, le porteur est mis hors de combat une fois tous les tirs de l''arme résolus.', 'PP', '2', '8', '1', 'Supercharge', 'Surcharge', '-3', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PB', NULL, NULL, 'PB', '1', '4', '1', 'Bolt pistol', 'Pistolet Bolter', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PBL', NULL, NULL, 'PBL', '1', '4', '1', 'Heavy bolt pistol', 'Pistolet Bolter lourd', '-1', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CC', 'Each time the bearer fights, it can make 1 additional













attack with this weapon.', 'Le porteur peut effectuer une attaque supplémentaire avec cette arme chaque fois qu''il combat.', 'CC', '1', 'U', '0', 'Combat knife', 'Couteau de combat', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EPE', '', '', 'EPE', '1', 'U', '0', 'Power sword', 'Epée énergétique', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EPT', 'Each time the bearer fights, it can make 1 additional













attack with this weapon.', 'Le porteur peut effectuer une attaque supplémentaire avec cette arme chaque fois qu''il combat.', 'EPT', '1', 'U', '0', 'Chainsword', 'Epée tronçonneuse', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GEN', 'When attacking with this weapon, you must substract 1 from the hit roll.', 'Soustrayez 1 du jet de touche lorsque vous attaquez avec cette arme', 'GEN', 'D3', 'x2', '0', 'Power fist', 'Gantelet énergétique', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('BLI1', NULL, NULL, 'BLI', '1', '5', '3', 'Heavy Bolter', 'Bolter lourd', '-1', 36, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('BLI2', 'This weapon automatically hits its target.', 'Cette arme touche automatiquement sa cible', 'BLI', '1', '5', 'D6', 'Heavy flamer', 'Lance-flammes lourd', '-1', 8, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('BOS', NULL, NULL, 'BOS', '1', '4', '2', 'Stalker pattern bolter', 'Bolter modèle Stalker', '-1', 30, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CFD1', 'This weapon automatically hits its target.', 'Cette arme touche automatiquement sa cible', 'CFD', '1', '6', '2D6', 'Frag round', 'Munition Frag', '-1', 8, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CFD2', 'If the target is within half range of this weapon, its






attacks are resolved with a Strength of 9 and an AP of -3.', 'Si la cible est à la moitié de la portée ou moins, les attaques sont résolues avec Force 9 et PA-3', 'CFD', '2', '7', '2', 'Shell', 'Munition Solide', '-2', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FPD1', 'You can re-roll failed wound rolls for this weapon.', 'Relancez les jets de blessure ratés de cette arme', 'FPD', '1', '4', '2', 'Cryptclearer round', 'Charge Cryptclearer', '0', 16, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FPD2', 'If the target is within half range of this weapon, its






attacks are resolved with a Damage of 2.', 'Si la cible est à la moitié de la portée ou moins, ses attaques sont résolues avec un dégat de 2.', 'FPD', '1', '4', '2', 'Xenopurge slug', 'Balle xenopurge', '-1', 16, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FPD3', 'This weapon automatically hits its target.', 'Cette arme touche automatiquement sa cible', 'FPD', '1', '3', 'D6', 'Wyrmsbreath shell', 'Munition Wyrmsbreath', '0', 7, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LXE', 'Your opponent must re-roll successful invulnerable saves






for wounds caused by this weapon.', 'L''adversaire doit relancer ses jets de sauvegarde invulnérable réussis contre cette arme.', 'LXE', '1', 'U', '0', 'Xenophase blade', 'Lame de xenophase', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MTL', 'When attacking with this weapon, you must subtract 1






from the hit roll. Each time you make a wound roll of 6+






with this weapon, that hit is resolved with a Damage of 6.', 'Soustrayez 1 du jet de touche lorsque vous attaquez avec cette arme. Chaque fois que vous obtenez un jet de blessure de 6+, la touche est résolue avec un Dégâts de 6.', 'MTL', 'D6', 'x2', '0', 'Heavy thunder hammer', 'Marteau Thunder lourd', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MAE', NULL, NULL, 'MAE', '1', '+2', '0', 'Power maul', 'Masse énergétique', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('BOST', NULL, NULL, 'BOST', '1', '4', '2', 'Storm bolter', 'Bolter Storm', '0', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EX', NULL, NULL, 'EX', 'D3', '4', '6', 'Psilencer', 'Expurgateur', '0', 24, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GAP', 'Each time you roll a hit roll of 6+ for this weapon when






targeting a PSYKER or DAEMON, the target suffers a






mortal wound instead of the normal damage.', 'Chaque fois que vous obtenez un jet de touche de 6+ avec cette arme contre un psyker ou un démon, la cible subit une blessure mortelle au lieu du dégât normal.', 'GAP', '1', '2', 'D3', 'Psyk-out grenade', 'Grenade anti-psy', '0', 6, 'G');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('INC', 'This weapon automatically hits its target.', 'Cette arme touche automatiquement sa cible', 'INC', '1', '6', 'D6', 'Incinerator', 'Incinerator', '-1', 8, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PSC', NULL, NULL, 'PSC', '1', '7', '4', 'Psycannon', 'Psycannon', '-1', 24, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SFN', 'A model armed with this weapon has a 5+ invulnerable






save against attacks made in the Fight phase. If it already






has an invulnerable save, add 1 to invulnerable saving






throws you make for it in the Fight phase instead.', 'Une figurine avec cette arme a une sauvegarde invulnérable de 5+ contre les attaques en phase de combat. Si elle en a déjà une, ajoutez 1 à ses jets de sauvegarde invulnérable en phase de combat à la place.', 'SFN', 'D3', '+2', 'U', 'Nemesis warding stave', 'Spectre de force Nemesis', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MTDN', 'When attacking with this weapon, you must subtract 1






from the hit roll.', 'Soustrayez 1 du jet de touche lorsque vous attaquez avec cette arme.', 'MTDN', '3', 'x2', 'U', 'Nemesis Daemon hammer', 'Marteau tueur de démons Nemesis', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('HFN', NULL, NULL, 'HFN', 'D3', '+1', 'U', 'Nemesis force halberd', 'Hallebarde de force Nemesis', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GLN', 'If a model is armed with two Nemesis falchions, each






time it fights it can make 1 additional attack with them.', 'Une figurine équipée de 2 glaives Nemesis peut effectuer une attaque de plus avec l''un deux chaque fois qu''elle combat.', 'GLN', 'D3', 'U', 'U', 'Pair of Nemesis falchions', 'Paire de glaives Nemesis', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EFN', NULL, NULL, 'EFN', 'D3', 'U', 'U', 'Nemesis force sword', 'Epée de force Nemesis', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FRS', NULL, NULL, 'FRS', '1', '4', '4', 'Hot-shot volley gun', 'Fusil radiant à salves', '-2', 24, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FRL', NULL, NULL, 'FRL', '1', '3', '1', 'Hot-shot lasgun', 'Fusil radiant laser', '0', 18, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PLS', NULL, NULL, 'PLS', '1', '3', '1', 'Laspistol', 'Pistolet laser', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PRL', NULL, NULL, 'PRL', '1', '3', '1', 'Hot-shot laspistol', 'Pistolet radiant laser', '-2', 6, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FLA', NULL, NULL, 'FLA', '1', '3', '1', 'Lasgun', 'Fusil laser', '0', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LGR1', NULL, NULL, 'LGR', '1', '3', 'D6', 'Frag grenade', 'Grenade Frag', '0', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LGR2', NULL, NULL, 'LGR', 'D3', '6', '1', 'Krak grenade', 'Grenade Krak', '-1', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('AQT', 'This weapon cannot be fired if the firing model



moved during the Movement phase. A model firing a



transuranic arquebus does not suffer the penalty to hit



rolls for the target being at long range. Each time you



make a wound roll of 6+ for this weapon, it inflicts a



mortal wound in addition to the normal damage.', 'Cette arme ne peut pas tirer si le tireur s''est déplacé à la phase de mouvement. Une figurine tirant avec une arquebuse transuranique ne subit pas de malus pour toucher si la cible est à longue portée. A chque jet de blessure de 6+ avec cette arme, elle inflige une blessure mortelle en plus des dégâts normaux.', 'AQT', 'D3', '7', '1', 'Transuranic arquebus', 'Arquebuse transuranique', '-2', 60, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CRA', 'Each time you make a wound roll of 6+ for this weapon,



that hit is resolved with a Damage of 3.', 'A chaque jet de blessure de 6+ pour cette arme, la touche est résolue avec un Dégat de 3', 'CRA', '1', '3', '3', 'Radium carbine', 'Carabine à radium', '0', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CPL2', 'On an unmodified hit roll of 1, the bearer is taken out of













action.', 'Sur un jet de touche non modifié de 1, le porteur est mis hors de combat une fois tous les tirs de l''arme résolus.', 'CPL', '2', '8', '2', 'Supercharge', 'Surcharge', '-3', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CPL1', NULL, NULL, 'CPL', '1', '7', '2', 'Standard', 'Standard', '-3', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EFL', NULL, NULL, 'EFL', '1', '3', '5', 'Flechette blaster', 'Eclateur à fléchettes', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ELF', NULL, NULL, 'ELF', '1', '6', '1', 'Arc rifle', 'Electrofusil', '-1', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ELP', NULL, NULL, 'ELP', '1', '6', '1', 'Arc pistol', 'Electropistolet', '-1', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FUG', 'Each time you make a wound roll of 6+ for this weapon,



that hit is resolved with an AP of -1.', 'A chaque jet de blessure de 6+ pour cette arme, la touche est résolue avec une PA de -1.', 'FUG', '1', '4', '1', 'Galvanic rifle', 'Fusil galvanique', '0', 30, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MIT', NULL, NULL, 'MIT', '1', '4', '3', 'Stubcarbine', 'Mitrailllette', '0', 18, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PIR', 'Each time you make a wound roll of 6+ for this weapon,



that hit is resolved with a Damage of 2.', 'A chaque jet de blessure de 6+ pour cette arme, la touche est résolue avec un Dégat de 2', 'PIR', '1', '3', '1', 'Radium pistol', 'Pistolet à radium', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('RPO', 'Attacks made with this weapon do not suffer the penalty



to hit rolls for the target being obscured.', 'Les attaques de cette arme ne subissent pas de malus pour toucher une figurine masquée.', 'RPO', '1', '5', '1', 'Phosphor blast pistol', 'Revolver à phosphore', '-1', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CTR', 'Each time you make a wound roll of 6+ with this



weapon, the target suffers a mortal wound instead of the



normal damage.', 'A chaque jet de blessure de 6+ pour cette arme, elle inflige une blessure mortelle à la place des dégâts normaux', 'CTR', '1', 'U', '0', 'Transonic razor', 'Couperet transsonique', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EMA', NULL, NULL, 'EMA', '1', '+2', '0', 'Arc maul', 'Electromasse', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GDO', 'A chordclaw can only be used to make one attack each



time this model fights. Each time you make a wound



roll of 6+ with this weapon, the target suffers D3 mortal



wounds instead of the normal damage.', 'Une griffe-discord ne peut effectuer qu''une seule attaque chaque fois que la figurine combat. Chaque fois que vous obtenez un jet de blessure de 6+ pour cette arme, elle inflige D3 blessures mortelles à la place des dégâts normaux.', 'GDO', 'D3', 'U', '0', 'Chordclaw', 'Griffe-discord', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LTR', 'Each time you make a wound roll of 6+ with this



weapon, the target suffers a mortal wound instead of the



normal damage.', 'A chaque jet de blessure de 6+ pour cette arme, elle inflige une blessure mortelle à la place des dégâts normaux', 'LTR', '1', '+1', '0', 'Transonic blades', 'Lames transsoniques', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MLA', 'Each hit roll of 6+ with this weapon causes 3 hits rather



than 1.', 'Chaque jet de touche de 6+ inflige 3 touches au lieu de 1', 'MLA', '1', '+2', '0', 'Taser goad', 'Matraque taser', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('AAB', 'Each time the bearer fights, it can make 1 additional
attack with this weapon.', 'Le porteur peut effectuer une attaque supplémentaire avec cette arme chaque fois qu''il combat.', 'AAB', '1', 'U', '0', 'Brutal assault weapon', 'Arme d''assaut brutale', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FUA', NULL, NULL, 'FUA', '1', '3', '1', 'Autogun', 'Fusil d''assaut', '0', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PMI', NULL, NULL, 'PMI', '1', '3', '1', 'Autopistol', 'Pistolet mitrailleur', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FP', 'If the target is within half range, add 1 to this weapon’s Strength.', 'Ajoutez 1 à la Force de cette arme si la cible est à la moitié de la portée ou moins.', 'FP', '1', '3', '2', 'Shotgun', 'Fusil à pompe', '0', 12, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GP', 'You can re-roll wound rolls of 1 for this weapon. This



weapon automatically hits its target.', 'Relancez les jets de blessure de 1 pour cette arme. Cette arme touche automatiquement sa cible.', 'GP', '1', '5', 'D6', 'Plague spewer', 'Gerbe-peste', '-1', 9, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GBU', 'You can re-roll wound rolls of 1 for this weapon.', 'Relancez les jets de blessure de 1 pour cette arme.', 'GBU', '1', '3', 'D6', 'Blight grenade', 'Grenade bubonique', '0', 6, 'G');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LPE', 'You can re-roll wound rolls of 1 for this weapon.', 'Relancez les jets de blessure de 1 pour cette arme.', 'LPE', 'D3', '6', '2', 'Blight launcher', 'Lance-peste', '-2', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('RP', 'You can re-roll wound rolls of 1 for this weapon. This



weapon automatically hits its target.', 'Relancez les jets de blessure de 1 pour cette arme. Cette arme touche automatiquement sa cible.', 'RP', '1', '4', 'D6', 'Plague belcher', 'Rote-peste', '0', 9, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('AI', NULL, NULL, 'AI', '1', 'U', '0', 'Improvised weapon', 'Arme improvisée', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CP', 'You can re-roll failed wound rolls for this weapon.', 'Relancez les jets de blessure de 1 pour cette arme.', 'CP', '1', 'U', '0', 'Plague knife', 'Couteau de la peste', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EPP', 'You can re-roll failed wound rolls for this weapon.', 'Relancez les jets de blessure de 1 pour cette arme.', 'EPP', '1', 'U', '0', 'Plaguesword', 'Epée de la peste', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FLC', 'You can re-roll failed wound rolls for this weapon. Make



D3 hit rolls each time you attack with this weapon.', 'Relancez les jets de blessure de 1 pour cette arme. Effectuez D3 jets de touche chaque fois que vous attaquez avec cette arme.', 'FLC', '1', '+2', '0', 'Flail of corruption', 'Fléau de corruption', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GHP', 'You can re-roll wound rolls of 1 for this weapon. When



attacking with this weapon, you must subtract 1 from



the hit roll.', 'Relancez les jets de blessure de 1 pour cette arme. Soustrayez 1 au jet de touche quand vous attaquez avec cette arme.', 'GHP', 'D6', 'x2', '0', 'Great plague cleaver', 'Grand hachoir de la peste', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('HP', 'You can re-roll failed wound rolls for this weapon.', 'Relancez les jets de blessure de 1 pour cette arme.', 'HP', '1', '+1', '0', 'Bubotic axe', 'Hache de la peste', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MC', 'You can re-roll wound rolls of 1 for this weapon. When



attacking with this weapon, you must subtract 1 from



the hit roll.', 'Relancez les jets de blessure de 1 pour cette arme. Soustrayez 1 au jet de touche quand vous attaquez avec cette arme.', 'MC', '3', '2', '0', 'Mace of contagion', 'Masse de contagion', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('BOI', NULL, NULL, 'BOI', '1', '4', '1', 'Inferno boltgun', 'Bolter Inferno', '-2', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CAS', NULL, NULL, 'CAS', '1', '5', '4', 'Soulreaper cannon', 'Canon Soulreaper', '-3', 24, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LFW', 'This weapon automatically hits its target.', 'Cette arme touche automatiquement sa cible', 'LFW', '1', '4', 'D6', 'Warpflamer', 'Lance-flammes warp', '-2', 8, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LFWL', 'This weapon automatically hits its target.', 'Cette arme touche automatiquement sa cible', 'LFWL', '1', '3', 'D6', 'Warpflamer', 'Lance-flammes warp', '-2', 6, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PBI', NULL, NULL, 'PBI', '1', '4', '1', 'Inferno bolt pistol', 'Pistolet Bolter Inferno', '-2', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LTZ', 'Each time the bearer fights, it can make 1 additional













attack with this weapon.', 'Chaque fois que le porteur combat, il peut effectuer une attaque supplémentaire avec cette arme.', 'LTZ', '1', 'U', '0', 'Tzaangor blades', 'Lames de Tzaangor', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SCF', NULL, NULL, 'SCF', 'D3', '+2', '0', 'Force stave', 'Sceptre de force', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CSH', 'Each time you make a wound roll of 6+ for this weapon,



that hit is resolved with an AP of -3.', 'A chaque jet de blessure de 6+ pour cette arme, la touche est résolue avec une PA de -3 au lieu de 0.', 'CSH', '1', '6', '3', 'Shuriken cannon', 'Cannon shuriken', '0', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CST', NULL, NULL, 'CST', 'D3', '6', '2', 'Starcannon', 'Cannon stellaire', '-3', 36, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CASH', 'Each time you make a wound roll of 6+ for this weapon,



that hit is resolved with an AP of -3.', 'A chaque jet de blessure de 6+ pour cette arme, la touche est résolue avec une PA de -3 au lieu de 0.', 'CASH', '1', '4', '2', 'Shuriken catapult', 'Catapulte shuriken', '0', 12, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CASA', 'Each time you make a wound roll of 6+ for this weapon,



that hit is resolved with an AP of -3.', 'A chaque jet de blessure de 6+ pour cette arme, la touche est résolue avec une PA de -3 au lieu de 0.', 'CASA', '1', '4', '2', 'Avenger Shuriken catapult', 'Catapulte shuriken Avenger', '0', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FUF', 'If the target is within half range of this weapon, roll two dice













when inflicting damage with it and discard the lowest result.', 'Si la cible est à mi-portée ou moins de cette arme, jetez deux dés pour ses dégâts et défaussez le résultat le plus bas.', 'FUF', 'D6', '8', '1', 'Fusion gun', 'Fusil à fusion', '-4', 12, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GPL', NULL, NULL, 'GPL', '1', '4', 'D6', 'Plasma grenade', 'Grenade à plasma', '-1', 6, 'G');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LAR', NULL, NULL, 'LAR', 'D6', '8', '1', 'Bright lance', 'Lance ardente', '-4', 36, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LMA1', NULL, NULL, 'LMA', '1', '4', 'D6', 'Sunburst Missile', 'Missile Sunburst', '-1', 48, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LMA2', NULL, NULL, 'LMA', 'D6', '8', '1', 'Starshot missile', 'Missile Starshot', '-2', 48, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LFR', 'A model firing a Ranger long rifle does not suffer the



penalty to hit rolls for the target being at long range.



Each time you roll a wound roll of 6+ for this weapon, it



inflicts a mortal wound in addition to any other damage.', 'Une figurine tirant avec un long fusil de ranger ne subit pas de pénalité aux jets de touche pour les cibles à longue portée. A chaque jet de blessure de 6+ pour cette arme, elle inflige une blessure mortelle en plus des dégâts normaux.', 'LFR', '1', '4', '1', 'Ranger long rifle', 'Long fusil de ranger', '0', 36, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PSH', 'Each time you make a wound roll of 6+ for this weapon,



that hit is resolved with an AP of -3.', 'A chaque jet de blessure de 6+ pour cette arme, la touche est résolue avec une PA de -3 au lieu de 0.', 'PSH', '1', '4', '1', 'Shuriken pistol', 'Pistolet shuriken', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('RLA', NULL, NULL, 'RLA', '1', '6', '4', 'Scatter laser', 'Rayonneur laser', '0', 36, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LAE', 'You can re-roll failed hit rolls for this weapon.', 'Vous pouvez relancer les jets de touche ratés pour cette arme.', 'LAE', '1', 'U', '0', 'Aeldari blade', 'Lame d''Aeldari', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LFU', 'Each time you make a wound roll of 6+ for this weapon,



the target suffers a mortal wound in addition to any



other damage.', 'A chaque jet de blessure de 6+ pour cette arme,la cible subit une blessure mortelle en plus de tout autre dégât.', 'LFU', '1', 'U', '0', 'Diresword', 'Lame funeste', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('VEN', NULL, NULL, 'VEN', '1', '1', '0', 'Power glaive', 'Vouge énergétique', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CAE', 'This weapon wounds on a 4+.', 'Cette arme blesse sur du 4+', 'CAE', '1', '*', '3', 'Splinter cannon', 'Canon éclateur', '0', 36, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('DIS', NULL, NULL, 'DIS', 'D6', '8', '1', 'Blaster', 'Disloqueur', '-4', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FEC', 'This weapon wounds on a 4+.', 'Cette arme blesse sur du 4+', 'FEC', '1', '*', '1', 'Splinter rifle', 'Fusil éclateur', '0', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LAC', 'When attacking an INFANTRY model, re-roll failed



wound rolls for this weapon.', 'Lorsque vous attaquez une figurine d''infanterie, relancez les jets de blessure ratés pour cette arme.', 'LAC', '1', '6', 'D6', 'Shredder', 'Lacérateur', '-1', 12, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LTE', NULL, NULL, 'LTE', 'D6', '8', '1', 'Dark lance', 'Lance des ténébres', '-4', 36, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LGP', 'If a model is hit by one or more phantasm grenade



launchers, subtract 1 from its Leadership characteristic



until the end of the battle round.', 'Si une figurine est touchée par au moins un lance grenade Phantasm, soustrayez 1 à sa caractéristique de commandement jusqu''à la fin du round de bataille.', 'LGP', '1', '1', 'D3', 'Phantasm grenade



launcher', 'Lance-grenades Phantasm', '0', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PDI', NULL, NULL, 'PDI', 'D6', '8', '1', 'Blast pistol', 'Pistolet disloqueur', '-4', 6, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PEC', 'This weapon wounds on a 4+.', 'Cette arme blesse sur du 4+', 'PEC', '1', '*', '1', 'Splinter pistol', 'Pistolet éclateur', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EPF', 'Each time the bearer fights, it can make 1 additional



attack with this weapon. You can re-roll failed hit rolls



for this weapon.', 'Chaque fois que le porteur combat, il peut effectuer une attaque supplémentaire avec cette arme. Vous pouvez relancer les jets de touche ratés pour cette arme.', 'EPF', '1', 'U', '0', 'Razorflails', 'Epées-fouets', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FBE', 'Each time the bearer fights, it can make 1 additional



attack with this weapon.', 'Chaque fois que le porteur combat, il peut effectuer une attaque supplémentaire avec cette arme.', 'FBE', '2', 'U', '0', 'Shardnet and impaler', 'Filet barbelé et empaleur', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GAH', '"Each time the bearer fights, it can make 1 additional attack with this weapon. You can re-roll failed wound rolls for this weapon."', 'Chaque fois que le porteur combat, il peut effectuer une attaque supplémentaire avec cette arme. Vous pouvez relancer les jets de blessure ratés pour cette arme.', 'GAH', '1', 'U', '0', 'Hydra gauntlets', 'Gantelets-hydres', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LHE', 'Each time the bearer fights, it can make 1 additional



attack with this weapon.', 'Chaque fois que le porteur combat, il peut effectuer une attaque supplémentaire avec cette arme.', 'LHE', '1', 'U', '0', 'Hekatarii blade', 'Lame d''Hekatarii', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('NEU', 'This weapon wounds on a 4+.', 'Cette arme blesse sur du 4+', 'NEU', '1', '*', '0', 'Agoniser', 'Neurocide', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('NDI', NULL, NULL, 'NDI', 'D3', '4', '1', 'Neuro disruptor', 'Neuro-disrupteur', '-3', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PFU', NULL, NULL, 'PFU', 'D6', '8', '1', 'Fusion pistol', 'Pistolet à fusion', '-4', 6, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('BHA', NULL, NULL, 'BHA', 'D3', '+1', '0', 'Harlequin’s kiss', 'Baiser d''Harlequin', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CHA', NULL, NULL, 'CHA', '1', '+2', '0', 'Harlequin’s caress', 'Caresse d''Harlequin', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EHA', NULL, NULL, 'EHA', '1', '+1', '0', 'Harlequin’s embrace', 'Etreinte d''Harlequin', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LHA', NULL, NULL, 'LHA', '1', 'U', '0', 'Harlequin’s blade', 'Lame d''Harlequin', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CTE', 'Each unmodified hit roll of 6 with this weapon causes 3 hits', 'Chaque jet de touche non modifié de 6 avec cette arme inflige 3 touches.', 'CTE', '1', '5', '2', 'Tesla carbine', 'Carabine Tesla', '0', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('DSY', 'A model firing a synaptic disintegrator does not suffer



the penalty to hit rolls for the target being at long range.



Each time you roll a wound roll of 6+ for this weapon,



the target suffers a mortal wound in addition to any



other damage.', 'Une figurine tirant avec un fusil de sniper ne subit pas de malus pour toucher à longue portée. Si vous obtenez un jet de blessure de 6+ avec cette arme, elle inflige une blessure mortelle en plus des dégâts normaux.', 'DSY', '1', '4', '1', 'Synaptic disintegrator', 'Désintégrateur synaptique', '0', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ELG', NULL, NULL, 'ELG', '1', '5', '1', 'Gauss blaster', 'Eclateur Gauss', '-2', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ECG', NULL, NULL, 'ECG', '1', '4', '1', 'Gauss flayer', 'Ecorcheur Gauss', '-1', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GDE', 'You can re-roll failed wound rolls for this weapon.', 'Relancez les jets de blessure ratés de cette arme', 'GDE', '1', 'U', '0', 'Flayer claws', 'Griffes de dépeceur', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ARK1', NULL, NULL, 'ARK', '1', '4', '2', 'Shoota', 'Fling''', '0', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ARK2', 'This weapon automatically hits its target.', 'Cette arme touche automatiquement sa cible', 'ARK', '1', '5', 'D6', 'Skorcha', 'Karbonizator', '-1', 8, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ARL1', NULL, NULL, 'ARL', '3', '8', '1', 'Rokkit launcha', 'Lance-rokettes', '-2', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ARL2', NULL, NULL, 'ARL', '1', '4', '2', 'Shoota', 'Fling''', '0', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FLI', NULL, NULL, 'FLI', '1', '4', '2', 'Shoota', 'Fling''', '0', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FLM', NULL, NULL, 'FLM', '2', '7', 'D3', 'Deffgun', 'Fling'' de la mort', '-1', 48, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FRM', NULL, NULL, 'FRM', '1', '3', 'D6', 'Stikkbomb', 'Frag à manche', '0', 6, 'G');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GRF', NULL, NULL, 'GRF', '1', '5', '3', 'Big shoota', 'Gros fling''', '0', 36, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('KAL', NULL, NULL, 'KAL', '1', '4', '1', 'Slugga', 'Kalibr''', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('KRA2', NULL, NULL, 'KRA', '1', 'U', '0', 'Melee', 'Mêlée', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('KRA1', 'This weapon automatically hits its target.', 'Cette arme touche automatiquement sa cible', 'KRA', '1', '4', 'D3', 'Ranged', 'Tir', '0', 8, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LRO', NULL, NULL, 'LRO', '3', '8', '1', 'Rokkit launcha', 'Lance-rokettes', '-2', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MKK', 'On an unmodified hit roll of 1, the bearer suffers a



mortal wound.', 'Sur un jet de touche non modifié de 1, le porteur subit une blessure mortelle.', 'MKK', 'D3', '8', '1', 'Kustom mega-blasta', 'Méga-klateur kustom', '-3', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PET', NULL, NULL, 'PET', '1', '3', '1', 'Grot blasta', 'Pétoire', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GKK', NULL, NULL, 'GKK', '2', '+2', '0', 'Big choppa', 'Gros kikoup''', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('KK', 'Each time the bearer fights, it can make 1 additional













attack with this weapon.', 'Chaque fois que le porteurl combat, il peut effectuer une attaque supplémentaire avec cette arme.', 'KK', '1', 'U', '0', 'Choppa', 'Kikoup''', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PEK', NULL, NULL, 'PEK', 'D3', 'x2', '0', 'Power klaw', 'Pince énergetik''', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CIN', NULL, NULL, 'CIN', '1', '5', '4', 'Burst cannon', 'Canon à induction', '0', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CRI', NULL, NULL, 'CRI', '1', '5', '2', 'Pulse carbine', 'Carabine à impulsions', '0', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EFU', 'If the target is within half range of this weapon, roll two dice













when inflicting damage with it and discard the lowest result.', 'Si la cible est à mi-portée ou moins de cette arme, jetez deux dés pour ses dégâts et défaussez le résultat le plus bas.', 'EFU', 'D6', '8', '1', 'Fusion blaster', 'Eclateur à fusion', '-4', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('DLA', 'Marker light', 'Designateur laser', 'DLA', '-', '-', '1', 'Markerlight', 'Designateur laser', '-', 36, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ECI1', NULL, NULL, 'ECI', '1', '6', '2', 'Close range', 'Courte portée', '-2', 5, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ECI3', NULL, NULL, 'ECI', '1', '4', '2', 'Long range', 'Longue portée', '0', 15, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ECI2', NULL, NULL, 'ECI', '1', '5', '2', 'Medium range', 'Moyenne portée', '-1', 10, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FIM', NULL, NULL, 'FIM', '1', '5', '1', 'Pulse rifle', 'Fusil à impulsions', '0', 30, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FUI2', 'If you make one or more unmodified hit rolls of 1, the



bearer suffers a mortal wound after all of this weapon’s



shots have been resolved.', 'Si vous obtenez au moins un jet de touche de 1 non modifié, le porteur subit une blessure mortelle une fois tous les tirs de son arme résolus.', 'FUI', '2', '8', 'D3', 'Supercharge', 'Surcharge', '-1', 30, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FUI1', NULL, NULL, 'FUI', '1', '7', '1', 'Standard', 'Standard', '-1', 30, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FRA', 'For each wound roll of 6+ made for this weapon, the



target model suffers a mortal wound in addition to the



normal damage.', 'A chaque jet de blessure de 6+ pour cette arme, la cible subit une blessure mortelle en plus des dégâts normaux.', 'FRA', 'D3', '6', '1', 'Rail rifle', 'Fusil-rail', '-4', 30, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GPH', 'This weapon does not inflict any damage. Your opponent



must subtract 1 from hit rolls made for INFANTRY



models that have suffered any hits from photon grenades



until the end of the battle round.', 'Cette arme n''inflige aucun dégât. Votre adversaire doit soustraire 1 aux jets de touche pour les figurines d''infanterie qui ont subi au moins une touche de grenade à photons jusqu''à la fin du round de bataille.', 'GPH', '-', '-', 'D6', 'Photon grenade', 'Grenade à photon', '-', 12, 'G');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('NMI', NULL, NULL, 'NMI', 'D3', '7', '-1', 'Missile pod', 'Nacelle de missilles', '-1', 36, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PIM', NULL, NULL, 'PIM', '1', '5', '1', 'Pulse pistol', 'Pistolet à impulsions', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SMA', 'This weapon can be fired at models that are not visible to



the bearer. If the target is not visible to the bearer, a 6 is



required for a successful hit roll, irrespective of the firing



model’s Ballistic Skill or any modifiers.', 'Cette arme peut tirer sur des cibles que le porteur ne voit pas. Si le porteur ne voit pas la cible, le jet de touche ne sera réussi que sur 6, sans tenir compte de la capacité de tir de la figurine ni d''aucun modificateur.', 'SMA', '1', '5', '4', 'Smart missile system', 'Système de missiles autodirecteurs', '0', 30, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CVE', NULL, NULL, 'CVE', 'D3', '8', 'D3', 'Venom cannon', 'Canon venin', '-2', 36, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CRM', NULL, NULL, 'CRM', '1', '5', '3', 'Deathspitter', 'Crache-mort', '-1', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CRO', 'This weapon can be fired within 1" of an enemy



model, and can target enemy models within 1" of



friendly models.', 'Cette arme peut tirer à 1" d''une figurine ennemie, et peut cibler des figurines ennemies situées à 1" de figurines amies.', 'CRO', '1', 'U', '2', 'Flesh hooks', 'Crochets', '0', 6, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('DEV', NULL, NULL, 'DEV', '1', '4', '3', 'Devourer', 'Dévoreur', '0', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('DEVT', NULL, NULL, 'DEVT', '1', '4', '3', 'Devourer', 'Dévoreur', '0', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ECO', NULL, NULL, 'ECO', '1', '4', '1', 'Fleshborer', 'Ecorcheur', '0', 12, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ETR', NULL, NULL, 'ETR', '1', '5', 'D6', 'Barbed strangler', 'Etrangleur', '-1', 36, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('POE', 'When a model fires this weapon, it makes a number of



shots equal to its Attacks characteristic.', 'Lorsqu''une figurine tire avec cette arme, elle effectue un nombre de tirs égal à sa caractéristique d''Attaques', 'POE', '1', '3', '*', 'Spinefists', 'Poings épineux', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('BEP', 'If the bearer is taken out of action in the Fight phase



before it has made its attacks in that phase, it may



immediately fight before being removed from the



battlefield.', 'Si le porteur est mis hors de combat à la phase de combat avant d''avoir effectué ses attaques à cette phase,  il peut immédiatement combattre avant d''être retiré du champ de bataille.', 'BEP', '1', 'U', '0', 'Lash whip and bonesword', 'Bioknout et épée d''os', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EPO', 'A model armed with boneswords can make 1 additional



attack with them in the Fight phase.', 'Une figurine armée d''épées d''os peut effectuer 1 attaque supplémentaire avec à la phase de combat.', 'EPO', '1', 'U', '0', 'Boneswords', 'Epées d''os', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GTR', 'You can re-roll hit rolls of 1 for this weapon. If the



bearer has more than one pair of scything talons, it can



make 1 additional attack with this weapon each time



it fights.', 'Vous pouvez relancer les jets de touche de 1 pour cette arme. Si le porteur a plus d''une paire de griffes tranchantes, il peut effectuer 1 attaque supplémentaire avec chaque fois qu''il combat.', 'GTR', '1', 'U', '0', 'Scything talons', 'Griffes tranchantes', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GAC', NULL, NULL, 'GAC', '1', 'U', '0', 'Acid maw', 'Gueule acide', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SFO', 'Each time you make a wound roll of 6+ for this weapon,



that hit is resolved with an AP of -4.', 'Chaque fois que vous effectuez un jet de blessure de 6+ pour cette arme, la touche est résolue avec une PA de -4.', 'SFO', '1', 'U', '0', 'Rending claws', 'Serres perforantes', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SPR', NULL, NULL, 'SPR', '2', 'U', '0', 'Grasping talons', 'Serres préhensiles', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CSI1', NULL, NULL, 'CSI', '1', '3', '4', 'Long-wave', 'Onde longue', '0', 24, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CSI2', NULL, NULL, 'CSI', '2', '6', '2', 'Short-wave', 'Onde courte', '-1', 12, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CHD', 'Each demolition charge can only be used once per battle.', 'Chaque charge de démolition ne peut être utilisée qu''une fois par bataille', 'CHD', 'D3', '8', 'D6', 'Demolition charge', 'Charge de démolition', '-3', 6, 'G');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LFL', 'This weapon automatically hits its target.', 'Cette arme touche automatiquement sa cible', 'LFL', '1', '3', 'D3', 'Hand flamer', 'Lance-flammes léger', '0', 6, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LTO', 'When making a shooting attack with a web weapon, you



can use either the Strength or Toughness characteristic



of the target to determine the wound roll – whichever



is lowest.', 'Lorsque vous effectuez une attaque de tir avec une arme à toile, vous pouvez utiliser la caractéristique de Force ou d''Endurance de la cible (en prenant la valeur la plus basse) pour déterminer le jet de blessure.', 'LTO', '1', '4', 'D3', 'Webber', 'Lance-toile', '0', 16, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LTL', 'When making a shooting attack with a web weapon, you



can use either the Strength or Toughness characteristic



of the target to determine the wound roll – whichever



is lowest.', 'Lorsque vous effectuez une attaque de tir avec une arme à toile, vous pouvez utiliser la caractéristique de Force ou d''Endurance de la cible (en prenant la valeur la plus basse) pour déterminer le jet de blessure.', 'LTL', '1', '3', 'D3', 'Webber', 'Lance-toile', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LMI', NULL, NULL, 'LMI', 'D3', '9', '1', 'Mining laser', 'Laser minier', '-3', 24, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CSL', 'Roll a D6 each time a model suffers damage from this



weapon; if you roll higher than the model’s remaining



number of Wounds, it is instantly taken out of action.



When attacking with this weapon, you must subtract 1



from the hit roll.', 'Jetez un D6 chaque fois qu''une figurine subit des dégâts infligés par cette arme; si le résultat est supérieur aux PV restants de la figurine, elle est aussitôt mise hors de combat. Lorsque vous attaquez avec cette arme, vous devez soustraire 1 au jet de touche.', 'CSL', '2', 'x2', '0', 'Heavy rock cutter', 'Cisaille lourde', '-4', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('DSL', NULL, NULL, 'DSL', '2', 'x2', '0', 'Heavy rock saw', 'Disqueuse lourde', '-4', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FOL', 'Roll a D6 each time a model suffers damage from this weapon; on a 2+ the model suffers a mortal wound and you can roll another D6. This time, the model suffers a mortal wound on a 3+. Keep rolling a D6, increasing the score required to cause a mortal wound by 1 each time, until the model’s wounds are reduced to 0 or the roll is failed', 'Jetez un D6 chaque fois qu''une figurine subit des dégâts infligés par cette arme; sur 2+, la figurine subit une blessure mortelle et vous pouvez jeter un autre D6. Cette fois la figurine subit une blessure mortelle sur 3+. Continuez à jeter un D6, en augmentant à chaque fois de 1 le résultat à obtenir pour infliger une blessure mortelle, jusqu’à ce que la figurine soit réduite à 0 PV, ou que le jet rate.', 'FOL', '1', 'x2', '0', 'Heavy rock drill', 'Foreuse lourde', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FME', 'If the bearer is taken out of action in the Fight phase



before it has made its attacks in that phase, it may



immediately fight before being removed from the



battlefield.', 'Si le porteur est mis hors de combat à la phase de combat avant d''avoir effectué ses attaques à cette phase,  il peut immédiatement combattre avant d''être retiré du champ de bataille.', 'FME', '1', 'U', '0', 'Metamorph whip', 'Fouet métamorphe', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GME', 'Add 1 to all hit rolls for this weapon.', 'Ajoutez 1 aux jets de touche pour cette arme.', 'GME', '1', 'U', '0', 'Metamorph talon', 'Griffe métamorphe', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MTE', 'When attacking with this weapon, you must subtract 1



from the hit roll.', 'Lorsque vous attaquez avec cette arme, vous devez soustraire 1 au jet de touche.', 'MTE', '3', 'x2', '0', 'Power hammer', 'Marteau énergétique', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PME', NULL, NULL, 'PME', '1', '+2', '0', 'Metamorph claw', 'Pince métamorphe', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PIE', NULL, NULL, 'PIE', 'D3', 'U', '0', 'Power pick', 'Pioche énergétique', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PCU', 'Each time the bearer fights, it can make 1 additional



attack with this weapon.', 'Chaque fois que le porteur combat, il peut effectuer une attaque supplémentaire avec cette arme.', 'PCU', '1', 'U', '0', 'Cultist knife', 'Poignard du cultiste', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MTI', NULL, NULL, 'MTI', '1', '4', '3', 'Heavy stubber', 'Mitrailleuse', '0', 36, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CRI2', NULL, NULL, 'CRI2', '1', '5', '2', 'Pulse carbine', 'Carabine à impulsions', '0', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CBODW', NULL, NULL, 'CBODW', '1', '4', '2', 'Bolt Carbine', 'Carabine Bolter', '0', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FBODW', NULL, NULL, 'FBODW', '1', '4', '1', 'Bolt Rifle', 'Fusil Bolter', '-1', 30, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FBADW', NULL, NULL, 'FBADW', '1', '4', '2', 'Auto bolt rifle', 'Fusil Bolter Automatique', '0', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FBSDW', NULL, NULL, 'FBSDW', '1', '4', '1', 'Stalker bolt rifle', 'Fusil Bolter Stalker', '-2', 36, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PBDW', NULL, NULL, 'PBDW', '1', '4', '1', 'Bolt pistol', 'Pistolet Bolter', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PBLDW', NULL, NULL, 'PBLDW', '1', '4', '1', 'Heavy bolt pistol', 'Pistolet Bolter lourd', '-1', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CHE1', NULL, NULL, 'CHE', '1', '3', 'D6', 'Blasting charge', 'Charge explosive', '0', 6, 'G');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EPE2', '', '', 'EPE2', '1', 'U', '0', 'Power sword', 'Epée énergétique', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EPE1', '', '', 'EPE1', '1', 'U', '0', 'Power sword', 'Epée énergétique', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EPO2', 'A model armed with boneswords can make 1 additional attack with them in the Fight phase.', 'Une figurine armée d''épées d''os peut effectuer 1 attaque supplémentaire avec à la phase de combat.', 'EPO2', '1', 'U', '0', 'Boneswords', 'Epées d''os', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GEN2', 'When attacking with this weapon, you must substract 1 from the hit roll.', 'Soustrayez 1 du jet de touche lorsque vous attaquez avec cette arme', 'GEN2', 'D3', 'x2', '0', 'Power fist', 'Gantelet énergétique', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MAE1', NULL, NULL, 'MAE1', '1', '+2', '0', 'Power maul', 'Masse énergétique', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CARO', NULL, NULL, 'CARO', '2', '4', '4', 'Rotor cannon', 'Canon rotatif', '-1', 24, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FPAR', 'If the target is within half range, add 1 to this weapon’s 
Strength.', 'Ajoutez 1 à la Force de cette arme si la cible est à la moitié de la portée ou moins.', 'FPAR', '2', '4', '2', 'Artificier shotgun', 'Fusil à pompe d''artificer', '0', 12, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FULA', NULL, NULL, 'FULA', '1', '3', '1', 'Lasgun', 'Fusil laser', '0', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GSP', 'If the target is within 1" of a terrain feature, add 1 to this weapon''s Strength and Damage characteristics. ', 'Si la cible est à 1" d''un élement de terrain, ajoutez 1 aux caractéristiques de Force et de Dégâts de cette arme.', 'GSP', '1', '3', 'D3', 'Concussion grenade', 'Grenade à surpression', '0', 6, 'G');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MAG', 'This weapon wounds on a 2+.', 'Cette arme blesse sur 2+.', 'MAG', '1', '1', '1', 'Dartmask', 'Masque à aiguilles', '-1', 9, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PFA', NULL, NULL, 'PFA', '2', '4', '1', 'Hierloom', 'Pistolet familial', '-2', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PVO', 'Each unmodified hit roll of 6 made for this weapon inflicts 3 hits on the target, instead of 1.', 'Chaque jet de touche non modifié de 6 obtenu pour cette arme inflige 3 touches à la cible au lieu d''une seule.', 'PVO', '1', '5', '1', 'Voltaic pistol', 'Pistoler voltaïque', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CRMO', NULL, NULL, 'CRMO', '1', 'U', '0', 'Monomolecular cane-rapier', 'Canne-rapière monomoléculaire', '-4', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GSC', NULL, NULL, 'GSC', '1', 'U', '0', 'Scalpel claw', 'Griffe scalpel', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LEDC', NULL, NULL, 'LEDC', '1', 'U', '0', 'Death cult ower blade', 'Lame énergétique du Death Cult', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MCU', NULL, NULL, 'MCU', '1', 'U', '0', 'Vicious bite', 'Morsure cruelle', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('BRE', 'Each hit roll of 6+ made for this weapon automatically results in a wound (do not make a wound roll for that attack).', 'Chaque jet de touche de 6+ pour cette arme inflige automatiquement une blessure (n''effectuez pas de jet de blessure pour cette attaque).', 'BRE', '1', 'U', '0', 'Spawning barb', 'Barbillon reproducteur', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GTAI', NULL, NULL, 'GTAI', '2', '+1', '0', 'Flesh ripper claws', 'Griffe tailladeuses', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GDI', 'You can re-roll failed wound rolls for this weapon.', 'Relancez les jets de blessure de 1 pour cette arme.', 'GDI', '1', 'U', '0', 'Diseased claws and fangs', 'Griffes et dents infectés', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GGCD', NULL, NULL, 'GGCD', '1', 'U', '0', 'Fanged maw and stinger', 'Gueule garnie de crocs et dard', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('HAPE', 'You can re-roll failed wound rolls for this weapon.', 'Relancez les jets de blessure de 1 pour cette arme.', 'HAPE', '2', 'U', '0', 'Plague cleaver', 'Hachoir de la peste', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('HMU', NULL, NULL, 'HMU', '2', 'U', '0', 'Hideous mutations', 'Hideuses mutations', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MMAI', NULL, NULL, 'MMAI', '1', 'U', '0', 'Mutated limbs and improvised weapons', 'Membres mutés et armes improvisées', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PROB', 'Each unmodified hit roll of 6 made with this weapon scores 2 hits.', 'Chaque jet de touche non modifié de 6 pour cette arme provoque 2 touches.', 'PROB', '1', 'U', '0', 'Bloodsucking proboscis', 'Proboscis suceur de sang', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CRAA', NULL, NULL, 'CRAA', '1', 'U', '1', 'Acid spit', 'Crachat acide', '-1', 8, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('LFV', 'This weapon automatically hits its target.', 'Cette arme touche automatiquement sa cible', 'LFV', '1', '4', 'D6', 'Belly-flamer', 'Lance-flammes ventral', '0', 8, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PS', 'Attacks made with this weapon do not suifer the penalty to hit rolls for the target being obscured.', 'Les attaques ne subissent pas de pénalité sur le jet de touche quand elles visent des cibles masquées.', 'PS', '1', '5', '1', 'Phosphor serpenta', 'Serpentine à phosphore', '-1', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('VB', 'Each time you make a wound roll of 6+ for this weapon, the target suffers a mortal wound in addition to any other damage.', 'A chaque fois que vous obtenez un jet de blessure de 6+, la cible subit une blessure mortelle en plus de tout autre dégât.', 'VB', '1', '6', '3', 'Volkite blaster', 'Eclateur volkite', '0', 24, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PSR', 'This weapon automatically hits its target. Roll to determine the Strength of this weapon after selecting its target(s). You can re-roll wound rails of 1 for this weapon.', 'Cette arme touche automatiquement sa cible. Jetez 2D6 pour déterminer la Force de cette arme après avoir selectionné la ou les cibles. Vous pouvez relancer les jets de blessure de 1 de cette arme.', 'PSR', '3', '2D6', 'D6', 'Plague sprayer', 'Lance à peste', '-3', 9, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('IP', 'You can re-roll wound rails of 1 for this weapon.', 'Vous pouvez relancer les jets de blessure de 1 de cette arme.', 'IP', 'D6', '4', '1', 'Injector pistol', 'Pistolet Injector', '-1', 3, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('HBG', 'You can re-roll wound rails of 1 for this weapon. Each wound roll of 6+ made for this weapon inflicts a mortal wound on the target in addition to any other damage.', 'Vous pouvez relancer les jets de blessure de 1 de cette arme. Chaque jet de blessure de 6+ avec cette arme inflige une blessure mortelle en plus des dégâts normaux.', 'HBG', '2', '4', 'D6', 'Hyper blight grenade', 'Grenade hyper-bubonique', '0', 6, 'G');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('B', 'You can re-roll wound rails of 1 for this weapon.', 'Vous pouvez relancer les jets de blessure de 1 de cette arme.', 'B', '1', 'U', '0', 'Balesword', 'Pestelame', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PBA', NULL, NULL, 'PBA', '1', '5', '1', 'Absolvor bolt pistol', 'Pistolet bolter Absolvor', '-1', 16, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CA', NULL, NULL, 'CA', '2', '+1', '0', 'Crozius arcanum', 'Crozius arcanum', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FS', NULL, NULL, 'FS', 'D3', 'U', '0', 'Force sword', 'Epée de force', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GSER', NULL, NULL, 'GSE', '2', '4', '1', 'Ranged', 'Tir', '-1', 24, 'R');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('GSEM', NULL, NULL, 'GSE', 'D3', '+1', '0', 'Melee', 'Mêlée', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('OA', NULL, NULL, 'OA', '2', '+1', '0', 'Omnissian axe', 'Hache de l''Omnimessie', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SA', 'Each servo-arm can only be used to make one attack each time this mode! fights. When a mode! attacks with this weapon, you must subtract 1 from the hit roll.', 'Chaque servobras ne peut effectuer qu''une attaque à chaque fois que la figurine combat. Soustrayez 1 du jet de touche quand vous attaquez avec cette arme.', 'SA', '3', 'x2', '0', 'Servo-arm', 'Servobras', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('ER', 'Attacks from this weapon that target enemies at 8" or Jess are resolved with an AP of-4 and a Damage ofD3.', 'Les attaques visant des ennemis à 8" sont résolues à PA -4 et Dégâts D3.', 'ER', '1', '6', 'D3', 'Eradication ray', 'Faisceau d''éradication', '-2', 24, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('M', NULL, NULL, 'M', '1', '4', '5', 'Macrostubber', 'Macromitraillette', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('BD', 'After a model on this mount makes its close combat attacks, you can attack with its mount. Make 1 additional attack, using this weapon profile.', 'Après que le cavalier a effectué ses attaques au corps à corps, sa monture peut attaquer. Effectuez une attaque additionnelle avec ce profil d''arme.', 'BD', '1', '4', '0', 'Disc of Tzeentch/Blades', 'Disc of Tzeentch/Lames', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SG', 'When attacking with this weapon, you must subtract 1 from the hit roll.', 'Lorsque vous attaquez avec cette arme, vous devez soustraire 1 au jet de touche.', 'SG', 'D3', 'x2', '0', 'Star glaive', 'Vouge stellaire', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SSR', 'This weapon always wounds on a roll of 2+.', 'Cette arme blesse toujours sur 2+.', 'SS', 'D3', '9', '1', 'Ranged', 'Tir', '0', 12, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SSM', 'This weapon always wounds on a roll of 2+.', 'Cette arme blesse toujours sur 2+.', 'SS', 'D3', 'U', '0', 'Melee', 'Mêlée', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('W', 'This weapon always wounds on a roll of 2+.', 'Cette arme blesse toujours sur 2+.', 'W', 'D3', 'U', '0', 'Witchblade', 'Lame sorcière', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('H', NULL, NULL, 'H', 'D3', '+1', '0', 'Huskblade', 'Lame dessicante', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('VBE', 'This weapon always wounds on a roll of 2+.', 'Cette arme blesse toujours sur 2+.', 'VBE', '1', '*', '0', 'Venom blade', 'Lame venimeuse', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('AG', 'When attacking with this weapon, you must subtract 1 from the hit roll.', 'Lorsque vous attaquez avec cette arme, vous devez soustraire 1 au jet de touche.', 'AG', '1', '+2', '0', 'Archite glaive', 'Vouge d''archite', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SP', 'This weapon always wounds on a roll of 2+.', 'Cette arme blesse toujours sur 2+.', 'SP', '1', '*', '1', 'Stringer pistol', 'Pistolet hypodermique', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('HT', 'This weapon always wounds on a roll of 4+.', 'Cette arme blesse toujours sur 4+.', 'HT', '1', '*', '0', 'Haemonculus tools', 'Outils d''Haemonculus', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('IJ', 'The bearer can only make a single attack with this weapon each time it fights. You can re-roll failed wound rolls for this weapon. Each time you roll a wound roll of 6+ for this weapon, the target suffers D3 mortal wounds in addition to any other damage.', 'Le porteur ne peut effectuer que 1 attaque avec cette arme chaque fois qu''il combat. Vous pouvez relancer les jets de blessure ratés pour cette arme. A chaque jet de blessure de 6+ obtenu pour cette arme, la cible subit D3 blessures mortelles en plus de tout autre dégât.', 'IJ', '1', 'U', '0', 'Ichor injector', 'Injecteur d''ichor', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('HGL', 'If a model is hit by this weapon, roll 2D6 - if the roll is equal to or greater than the target model''s Leadership, it suffers a mortal wound.', 'Si une figurine est touchée par cette arme, jetz 2D6 - si le résultat est égal ou supérieur au Commandement de la cible, celle-ci subit une blessure mortelle.', 'HGL', '*', '*', '1', 'Hallucinogen grenade launcher', 'Lance-grenades hallucinogènes', '*', 18, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MS', NULL, NULL, 'MS', 'D3', '+2', '0', 'Miststave', 'Sceptre de brume', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SC1', 'Each time an infantry model is slain by an attack made with this weapon, roll a D6 for each ennemy model within 2" of that model. On a roll of 4+ the model being rolled for suffers a mortal wound.', 'Chaque fois qu''une figurine d''infanterie est tuée par une attaque de cette arme, jetez un D6 pour chaque figurine ennemie à 2" de cette figurine. Sur 4+ la figurine pour laquelle le dé a été jeté subit 1 blessure mortelle.', 'SC', '1', '6', '1', 'Shrieker', 'Hurleur', '-1', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SC2', NULL, NULL, 'SC', '1', '6', '3', 'Shuriken', 'Shuriken', '0', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SOL1', NULL, NULL, 'SOL', '1', '5', '3', 'Ranged', 'Tir', '-2', 12, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SOL2', NULL, NULL, 'SOL', '1', 'U', '0', 'Melee', 'Mêlée', '-2', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('V', 'When attacking with this weapon, subtract 1 from the hit roll.', 'Lorsque vous attaquez avec cette arme, vous devez soustraire 1 au jet de touche.', 'V', '3', 'x2', '0', 'Voidscythe', 'Faux du néant', '-4', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('WC', NULL, NULL, 'WC', '2', '+2', '0', 'Warscythe', 'Fauchard', '-4', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('KS', NULL, NULL, 'KS', '1', '4', '4', 'Kustom shoota', 'Fling'' kustom', '0', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('AS', 'Each time a model with an attack squig fights, it can make 2 additional attacks with this weapon.', 'Quand une figurine avec squig d''attak combat, elle peut effectuer 2 attaques supplémentaires avec cette arme.', 'AS', '1', '4', '0', 'Attack squig', 'Squig d''attak''', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('KMS', 'On an unmodified hit roll of 1, the bearer is taken out of action.', 'Sur un jet de touche non modifié de 1, le porteur est mis hors de combat.', 'KMS', 'D3', '8', '1', 'Kustom mega-slugga', 'Méga-kalibr'' kustom', '-3', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('SAG', 'Before firing this weapon, roll once to determine the Strength of ail its shots. If the result is 11 +, do not make wound rolls - instead, each attack that hits causes D3 mortal wounds.', 'Avant de tirer avec cette arme, effectuez un jet pour déterminer la Force de tous ses tirs. Si le résultat est 11+, n''effectuez pas de jets de blessure, car chaque attaque inflige D3 blessures mortelles.', 'SAG', 'D3', '2D6', 'D6', 'Shokk attack gun', 'Kanon shokk', '-5', 60, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('US', 'This weapon always wounds on a roll of 2+.', 'Cette arme blesse toujours sur 2+.', 'US', '1', 'U', '0', '''Urty syringe', 'Pikouz''', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('E', 'A model armed with equalizers increases its Attacks characteristic by 1.', 'Une figurine armée d''égaliseurs augmente sa caractéristique d''Attaques de 1.', 'E', '1', 'U', '0', 'Equalizers', 'Egaliseurs', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('HB', NULL, NULL, 'HB', '1', '+2', '0', 'Honour blade', 'Lame de duel', '0', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('MRC', 'You can re-roll failed wound rolls for this weapon. In addition, each time you make a wound roll of 6+, that hit is resolved with an AP of -6 and Damage of 3.', 'Vous pouvez relancer les jets de blessure ratés pour cette arme. De plus, chaque fois que vous effectuez un jet de blessure de 6+, la touche est résolue avec une PA de -6 et un dégât de 3.', 'MRC', 'D3', 'U', '0', 'Monstrous rending claws', 'Serres perforantes monstrueuses', '-3', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('NP', 'This weapon always wounds on a roll of2+.', 'Cette arme blesse toujours sur 2+.', 'NP', '1', '1', '1', 'Needle pistol', 'Pistolet à aiguilles', '0', 12, 'P');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FBSM', NULL, NULL, 'FBSM', '2', '4', '1', 'Master-crafted stalker bolt rifle', 'Fusil bolter Stalker de maitre', '-2', 36, 'L');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('FBAM', NULL, NULL, 'FBAM', '2', '4', '1', 'Master-crafted auto bolt rifle', 'Fusil bolter automatique de maitre', '0', 24, 'A');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('TIC', 'This weapon always wounds on a roll of2+. Furthermore, each time you make a wound roll of 6+ with this weapon, that hit is resolved with an AP of -4 .', 'Cette arme blesse toujours sur un jet de 2+. En outre, chaque fois que vous obtenez un 6+ sur un jet de blessure avec cette arme, la touche est résolue avec une PA de -4.', 'TIC', '1', 'U', '0', 'Toxin injector claw', 'Injecteur de toxines', '-1', 'M', 'M');
INSERT INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('PAX', NULL, NULL, 'PAX', '1', '+1', '0', 'Power axe', 'Hache énergétique', '-2', 'M', 'M');

delete from Remplacement where ID = 246;
delete from Remplacement where ID = 15;
delete from Remplacement where ID = 16;
delete from Remplacement where ID = 17;
delete from Remplacement where ID = 18;
delete from Remplacement where ID = 19;

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
                             NULL,
                             246
                         ),
                         (
                             'LXE',
                             0,
                             NULL,
                             'DWS',
                             'DWV4',
                             17
                         ),
                         (
                             'EPE|MAE',
                             0,
                             'DWV',
                             'DWS',
                             NULL,
                             16
                         ),
                         (
                             'BO:COF|COP|BOS|EPE|MAE|BST',
                             0,
                             'DWV',
                             NULL,
                             NULL,
                             15
                         ),
                         (
                             'BO:CFD|BLI',
                             0,
                             NULL,
                             'DWS',
                             'DWV2',
                             19
                         ),
                         (
                             'BO:FPD|MTL',
                             0,
                             NULL,
                             'DWS',
                             'DWV1',
                             18
                         );




COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
