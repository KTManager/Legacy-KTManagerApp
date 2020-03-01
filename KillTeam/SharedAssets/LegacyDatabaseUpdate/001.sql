
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table : AptitudesDetails
DROP TABLE IF EXISTS AptitudesDetails;
CREATE TABLE AptitudesDetails (Id TEXT PRIMARY KEY, AptitudesId TEXT REFERENCES Aptitudes (Id) NOT NULL, Ligne INT NOT NULL, Colonne INT NOT NULL, ContenuEn TEXT, ContenuFr TEXT, ContenuDe TEXT);
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('1', 'MSP', 0, 1, 'Ammunition', 'Munition');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('2', 'MSP', 0, 2, 'Modifier', 'Modificateur');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('3', 'MSP', 1, 1, 'Dragonfire bolt', 'Bolt Dragonfire');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('4', 'MSP', 1, 2, 'Add 1 to hit rolls for this weapon when targeting a model that is obscured.', 'Ajoutez 1 aux jets de touche de l''arme quand elle vise une figurine masquée.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('6', 'MSP', 2, 2, 'This weapon always wounds on a 2+.', 'Cette arme blesse toujours sur 2+.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('5', 'MSP', 2, 1, 'Hellfire round', 'Munition Hellfire');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('7', 'MSP', 3, 1, 'Kraken bolt', 'Bolt Kraken');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('8', 'MSP', 3, 2, 'Add 3" to the range of this weapon if it is a Pistol – or 6" otherwise – and improve the AP of the attack by 1 (e.g. an AP of 0 becomes -1), to a maximum AP of -2.', 'Ajoutez 3" à la portée de l''arme si c''est un pistolet, ou 6" pour une autre arme. De plus, améliorez d''un point la PA de l''attaque (par ex. PA0 devient -1), jusqu''à une PA maximum de -2.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('10', 'MSP', 4, 2, 'Subtract 3" from the range of this weapon if it is a Pistol – or 6" otherwise – and improve the AP of the attack by 2 (e.g. an AP of 0 becomes -2), to a maximum AP of -3.', 'Soustrayez 3" à la portée de l''arme si c''est un pistolet, ou 6" pour une autre arme.  De plus, améliorez de 2 points la PA de l''attaque (par ex. PA0 devient -2), jusqu''à une PA maximum de -3.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('9', 'MSP', 4, 1, 'Vengeance round', 'Munition vengeance');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('11', 'CMV', 0, 1, 'Order', 'Ordre');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('17', 'CMV', 6, 1, 'Fix Bayonets!', 'Baïonnettes au canon!');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('16', 'CMV', 5, 1, 'Move! Move! Move!', 'Allez! Allez! Allez!');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('15', 'CMV', 4, 1, 'Get Back in the Fight!', 'Retournez au combat!');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('14', 'CMV', 3, 1, 'Forwards, for the Emperor!', 'En avant, pour l''empereur!');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('13', 'CMV', 2, 1, 'Bring it Down!', 'Abattez-le!');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('12', 'CMV', 1, 1, 'Take Aim!', 'En joue!');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('24', 'CMV', 6, 2, 'This order can only be issued to a model within 1" of an enemy model. The ordered model immediately fights as if it were the Fight phase.', 'Cet ordre ne peut être donné qu''à une figurine à 1" d''une figurine ennemie. La figurine combat immédiatement comme en phase de combat.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('23', 'CMV', 5, 2, 'Instead of shooting this phase, the ordered model immediately makes an Advance move as if it were the Movement phase.', 'Au lieu de tirer, la figurine effectue immédiatement une Avance, comme s''il s''agissait de la phase de mouvement.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('22', 'CMV', 4, 2, 'The ordered model can shoot this phase, even if it Fell Back in the Movement phase.', 'La figurine peut tirer même si elle a battu en retraite à la phase de mouvement précédente.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('21', 'CMV', 3, 2, 'The ordered model can shoot even if it Advanced in the previous Movement phase.', 'La figurine peut tirer même si elle a avancé à la phase de mouvement précédente.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('20', 'CMV', 2, 2, 'Re-roll wound rolls of 1 for the ordered model until the end of the phase.', 'Relancez les jets de blessure de 1 de la figurine jusqu''à la fin de la phase.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('19', 'CMV', 1, 2, 'Re-roll hit rolls of 1 for the ordered model until the end of the phase', 'Relancez les jets de touche de 1 de la figurine jusqu''à la fin de la phase.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('18', 'CMV', 0, 2, ' ', ' ');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('38', 'CAN', 6, 2, 'Benediction of the Omnissiah', 'Bénédiction de l''omnimessie');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('37', 'CAN', 5, 2, 'Invocation of Machine Might', 'Invocation de la force-machine');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('36', 'CAN', 4, 2, 'Shroudpsalm', 'Psaume-linceul');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('35', 'CAN', 3, 2, 'Chant of the Remorseless Fist', 'Chant du poing impossible');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('34', 'CAN', 2, 2, 'Litany of the Electromancer', 'Litanie de l''électomancien');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('33', 'CAN', 1, 2, 'Incantation of the Iron Soul', 'Incantation de l''ame de fer');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('32', 'CAN', 0, 2, 'Canticle', 'Cantique');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('31', 'CAN', 6, 1, '6', '6');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('30', 'CAN', 5, 1, '5', '5');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('29', 'CAN', 4, 1, '4', '4');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('28', 'CAN', 3, 1, '3', '3');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('27', 'CAN', 2, 1, '2', '2');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('26', 'CAN', 1, 1, '1', '1');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('25', 'CAN', 0, 1, 'D6', 'D6');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('45', 'CAN', 6, 3, 'Re-roll hit rolls of 1 for models in your kill team in the Shooting phase.', 'Relancez les jets de touche de 1 pour les figurines de votre kill team en phase de tir.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('44', 'CAN', 5, 3, 'Add 1 to the Strength characteristic of models in your kill team.', 'Ajoutez 1 à la force des figurines de votre kill team jusqu''à la fin du round.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('43', 'CAN', 4, 3, 'When an enemy player makes a hit roll for a shooting attack that targets a model from your kill team, and that model is obscured, that hit roll suffers an additional -1 modifier.', 'Lorqu''un joueur adverse effectue un jet de touche pour une attaque de tir ciblant une figurine de votre kill team, et que celle-ci est masquée, le jet de touche subit un malus additionnel de -1.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('42', 'CAN', 3, 3, 'Re-roll hit rolls of 1 for models in your kill team in the Fight phase.', 'Relancez les jets de touche de 1 pour les figurines de votre kill team en phase de combat.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('41', 'CAN', 2, 3, 'Roll a D6 for each enemy model within 1" of any models in your kill team at the start of the Fight phase. On a 6, that enemy model suffers 1 mortal wound.', 'Jetez un D6 pour chaque figurine ennemie à 1" d''une figurine de votre kill team au début de la phase de combat. Sur 6, cet ennemi subit 1 blessure mortelle.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('40', 'CAN', 1, 3, 'You can re-roll failed Nerve tests for models in your kill team.', 'Vous pouvez relancer les tests de sang-froid pour les figurines de votre kill team.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('39', 'CAN', 0, 3, ' ', ' ');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('46', 'PSF', 0, 1, 'Battle round', 'Round');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('48', 'PSF', 0, 3, ' ', ' ');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('47', 'PSF', 0, 2, 'Bonus', 'Bonus');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('53', 'PSF', 5, 1, '5+', '5+');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('52', 'PSF', 4, 1, '4', '4');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('51', 'PSF', 3, 1, '3', '3');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('50', 'PSF', 2, 1, '2', '2');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('49', 'PSF', 1, 1, '1', '1');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('58', 'PSF', 5, 2, 'Mantle of Agony', 'Drapés de douleur');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('57', 'PSF', 4, 2, 'Emboldened by Bloodshed', 'Enhardis pour la tuerie');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('56', 'PSF', 3, 2, 'Flensing Fury', 'Enragés du dépeçage');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('55', 'PSF', 2, 2, 'Eager to Flay', 'Impatients d''égorger');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('54', 'PSF', 1, 2, 'Inured to Suffering', 'Insensibles à la souffrance');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('63', 'PSF', 5, 3, 'Subtract 1 from the Leadership characteristic of enemy models that are within 6" of any models from your kill team with this bonus.', 'Soustrayez 1 à la caractéristique de commandement des figurines ennemies à 6" de toute figurine de votre kill team ayant ce bonus.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('62', 'PSF', 4, 3, 'Re-roll failed Nerve tests for this model.', 'Relancez les tests de sang-froid ratés pour cette figurine.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('61', 'PSF', 3, 3, 'Add 1 to hit rolls for this model in the Fight phase.', 'Ajouter 1 aux jets de touche pour cette figurine à la phase de combat.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('60', 'PSF', 2, 3, 'You can re-roll the dice when determining how far this model moves when it Advances or charges.', 'Vous pouvez relancer le dé pour déterminer la distance que peut parcourir cette figurine lorsqu''elle avance ou qu''elle charge.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('59', 'PSF', 1, 3, 'Roll a D6 each time this model loses a wound; on a 6 that wound is not lost.', 'Jetez un D6 chaque fois que cette figurine perd 1PV; sur un 6 le PV n''est pas perdu.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('66', 'DC', 0, 3, ' ', ' ');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('65', 'DC', 0, 2, 'Bonus', 'Bonus');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('64', 'DC', 0, 1, 'D6', 'D6');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('72', 'DC', 6, 1, '6', '6');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('71', 'DC', 5, 1, '5', '5');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('70', 'DC', 4, 1, '4', '4');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('69', 'DC', 3, 1, '3', '3');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('68', 'DC', 2, 1, '2', '2');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('67', 'DC', 1, 1, '1', '1');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('78', 'DC', 6, 2, 'Splintermind', 'Psychopompe');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('77', 'DC', 5, 2, 'Serpentin', 'Serpentine');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('76', 'DC', 4, 2, 'Painbringer', 'Crucifiant');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('75', 'DC', 3, 2, 'Hypex', 'Hypex');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('74', 'DC', 2, 2, 'Grave Lotus', 'Lotus tumulaire');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('73', 'DC', 1, 2, 'Adrenalight', 'Métadrénaline');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('84', 'DC', 6, 3, '+2 to Leadership characteristic', '+2 à la caractéristique de Commandement');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('83', 'DC', 5, 3, '+1 to Weapon Skill characteristic (e.g. WS 3+ becomes WS 2+)', '+1 à la caractéristique de capacité de combat');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('82', 'DC', 4, 3, '+1 to Toughness characteristic', '+1 à la caractéristique d''endurance');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('81', 'DC', 3, 3, '+2 to Move characteristic', '+2 à la caractéristique de mouvement');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('80', 'DC', 2, 3, '+1 to Strength characteristic', '+1 à la caractéristique de Force');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('79', 'DC', 1, 3, '+1 to Attacks characteristic', '+1 à la caractéristique d''attaques');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('85', 'DLA', 0, 1, 'Markerlights', 'Pions');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('86', 'DLA', 0, 2, 'Benefit', 'Bénéfice');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('90', 'DLA', 4, 1, '4 or more', '4 ou plus');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('89', 'DLA', 3, 1, '3', '3');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('88', 'DLA', 2, 1, '2', '2');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('87', 'DLA', 1, 1, '1', '1');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('94', 'DLA', 4, 2, 'Add 1 to hit rolls for attacks that target this model.', 'Ajoutez 1 aux jets de touche pour les attaques qui ciblent cette figurine.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('93', 'DLA', 3, 2, 'Models attacking this model do not suffer the penalty for moving and firing Heavy weapons or Advancing and firing Assault weapons.', 'Les figurines qui attaquent cette figurine ne subissent pas de pénalité pour se déplacer et tirer avec des armes lourdes ou avance et tire avec des armes d''assaut.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('92', 'DLA', 2, 2, 'Add 1 to hit rolls for attacks that target this model if it is obscured.', 'Ajoutez 1 aux jets de touche pour les attaques qui ciblent cette figurine si elle est masquée.');
INSERT INTO AptitudesDetails (Id, AptitudesId, Ligne, Colonne, ContenuEn, ContenuFr) VALUES ('91', 'DLA', 1, 2, 'You can re-roll hit rolls of 1 for attacks that target this model.', 'Vous pouvez relancer les jets de touche de 1 pour les attaques qui ciblent cette figurine.');


INSERT OR ignore INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('CHE1', NULL, NULL, 'CHE', '1', '3', 'D6', 'Blasting charge', 'Charge explosive', '0', 6, 'G');

delete from Remplacement where Id = 42;
delete from Remplacement where Id = 46;
update Remplacement set Operation = 'BO:EPT' where Id = 45;
update ProfileArmes set NbTir = 1 where ID = 'FRA';

update tactiques set NomFr = 'ROUTINES DE CIBLAGE' where Id = 'NE3';
update Remplacement set Operation = 'FUA&PMI:(PMI|PB|LTL)&(EPT|PIE|MAE)' where Id= 127;
update Pouvoirs set DescriptionEn = ' Other friendly models within 3" of this model – as long as this model is not shaken – automatically pass Nerve tests',  DescriptionFr = 'Les autres figurines amies à 3" de cette figurine –tant qu’elle n’est pas secouée– réussissent automatiquement les tests de Sang-froid' where Id = 'L22';
update Pouvoirs set DescriptionEn = 'Once per Shooting phase, if this model is not shaken, when you pick another model from your kill team within 6" of this model to shoot, you can add 1 to hit rolls for that model in this phase', DescriptionFr = 'Une fois par phase de Tir, si cette figurine n’est pas secouée, quand vous choisissez une autre figurine de votre kill team à 6” de cette figurine pour la faire tirer, vous pouvez ajouter 1 aux jets de touche pour cette figurine à cette phase.' where Id = 'CO1';
update tactiques set DescriptionEn = 'Use this Tactic when you pick a Scout specialist from your kill team to move in the Movement phase. Increase the model’s Move characteristic by 2" this phase.', DescriptionFr = 'À utiliser quand vous choisissez un spécialiste Scout de votre kill team pour le déplacer à la phase de Mouvement. Augmentez de 2" la caractéristique de Mouvement de la figurine à cette phase.' where Id = 'SC1';

update Remplacement set Operation = 'PB&BO:(PB|BO|PP|PG)&(EPT|EPE|GEN|AUS)' where Id= 7;
INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('AAT1','M');
INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('AAT2','M');
INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('AAT3','M');
INSERT OR ignore INTO REMPLACEMENT (Id,FigurineId,MaxParTeam,Operation) VALUES('149','AAI',1,'AUS');

Update Armes set DescriptionAdditionnelleEn = 'If a model is armed with an auxiliary grenade launcher, increase the range of any Grenade weapons they have to 30". This model’s Grenade weapons are affected by the long range rule', DescriptionAdditionnelleFr = 'La portée des grenades d''une figurine équipée d''un lance-grenades auxiliaire passe à 30". Les armes de type Grenade de cette figurine sont sujettes à la règle de longue portée' where Id = 'LGA';
INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('AAI1','M');
INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('AAI2','M');
INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('AAI3','M');

INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('AMI1','M');
INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('AMI2','M');
INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('AMI3','M');

UPDATE DeclinaisonSpecialite set SpecialiteId = 'M' where DeclinaisonId = 'AMW1' and SpecialiteId = 'CO';
UPDATE DeclinaisonSpecialite set SpecialiteId = 'M' where DeclinaisonId = 'AMW2' and SpecialiteId = 'CO';

update Remplacement set Operation = 'EVO&PRL' where Id= 28;
update Remplacement set Operation = 'FRL:LF|LGR|FU|PLA|FRS' where Id= 29;

INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('HAM1','CB');
INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('HAM2','CB');
INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('HAM3','CB');

update ProfileArmes set D = '1' where Id = 'FLC';

update Remplacement set Exclusion = 'TZA' where Id= 63 or id = 62;

Update Aptitudes set DescriptionEn = 'A Heavy Weapon Platform can only move, Advance, React, shoot or fight if a friendly Guardian Defender that is not shaken is within 3" of it. If a Heavy Weapon Platform shoots, you must choose one such Guardian Defender that could still shoot its own ranged weapons in that phase: that Guardian Defender may not fire any of its own ranged weapons this phase. Heavy Weapon Platforms may not charge, may not be specialists, are not part of a fire team (pg 204) and do not gain experience. A Heavy Weapon Platform automatically passes Nerve tests.', DescriptionFr = 'Une Heavy Weapon Platform ne peut se déplace, Avancer, Réagir, tirer ou combattre que si un guardian defender qui n''est pas secoué se trouve à 3" de celle-ci. Si elle tire, vous devez choisir un Guardian Defender qui peut encore tirer avec ses propres armes de tir à cette phase : il ne pourra plus tirer avec ses propres armes à cette phase. Les Heavy Weapon Platforms ne peuvent pas charger, ne peuvent pas être des spécialistes, ne font pas partie d''une équipe de tir et ne gagne jamais d''éxperience. Une Heavy Weapon Platform réussit automatiquement ses tests de Sang-froid.' where Id = 'SEA';
Update Aptitudes set DescriptionEn = ' This model can move across other models as if they were not there, and it can climb any distance vertically (up or down) when it moves – do not measure the distance moved in this way. In addition, it never suffers falling damage, and never falls on another model. If it would, instead place this model as close as possible to the point where it would have landed. This can bring it within 1" of an enemy model', DescriptionFr = 'Cette figurine peut se déplacer à travers les autres figurines comme si elles n’étaient pas là. De plus, elle ne subit jamais des dégâts dus à une chute, et ne tombe jamais sur une autre figurine. Si elle devait le faire, placez-la aussi près que possible du point où elle aurait dû atterrir. Cela peut l’amener à 1" d’une figurine ennemie.' where Id = 'CAG';

update ProfileArmes set F = '4' where Id = 'NDI';
update ProfileArmes set AptitudesFr=NULL, AptitudesEn=NULL where Id = 'PFU';
update ProfileArmes set AptitudesEn = 'Each unmodified hit roll of 6 with this weapon causes 3 hits', AptitudesFr='Chaque jet de touche non modifié de 6 avec cette arme inflige 3 touches.' where Id = 'CTE';
update Aptitudes set DescriptionEn=' You can subtract 1 from Nerve tests for Shas’las and Shas’uis from your kill team within 3" of any other friendly models with this ability that are not shaken.', DescriptionFr='Vous pouvez soustraire 1 aux tests de Sang-froid pour les Shas’la ou Shas’ui de votre kill team à 3" de toute autre figurine amie avec cette aptitude qui n’est pas secouée.' where Id = 'UCRF';
update Aptitudes set DescriptionEn=' You can subtract 1 from Nerve tests for Pathfinders, Pathfinder Gunners and Pathfinder Shas’uis from your kill team within 3" of any other friendly models with this ability that are not shaken.', DescriptionFr='Vous pouvez soustraire 1 aux tests de Sang-froid pour les Pathfinders, Pathfinder Gunners et Pathfinder Shas’ui de votre kill team à 3" de toute autre figurine amie avec cette aptitude qui n’est pas secouée.' where Id = 'UCRP';
update Aptitudes set DescriptionEn=' You can subtract 1 from Nerve tests for Breacher Shas’las and Breacher Shas’uis from your kill team within 3" of any other friendly models with this ability that are not shaken.', DescriptionFr='Vous pouvez soustraire 1 aux tests de Sang-froid pour les Breacher Shas’la et Breacher Shas’ui de votre kill team à 3" de toute autre figurine amie avec cette aptitude qui n’est pas secouée.' where Id = 'UCRB';
update Aptitudes set DescriptionEn=' You can subtract 1 from Nerve tests for Stealth Shas’uis and Stealth Shas’vres from your kill team within 3" of any other friendly models with this ability that are not shaken.', DescriptionFr='Vous pouvez soustraire 1 aux tests de Sang-froid pour les Stealth Shas’ui et Stealth Shas’vre de votre kill team à 3" de toute autre figurine amie avec cette aptitude qui n’est pas secouée.' where Id = 'UCRX';

Update Armes set DescriptionAdditionnelleEn = 'A model with a shield generator has a 4+ invulnerable save. In addition, each time a model with a shield generator loses a wound, roll a D6; on a 5+ the model does not lose that wound.', DescriptionAdditionnelleFr = 'Une figurine avec un générateur de bouclier a une sauvegarde invulnérable de 4+. “En outre, chaque fois qu’une figurine avec générateur de bouclier perd un PV, jetez un D6; sur 5+, la figurine ne perd pas ce PV' where Id = 'GBO';

INSERT or ignore INTO Aptitudes (
                          Id,
                          DeclinaisonId,
                          DescriptionEn,
                          DescriptionFr,
                          NomEn,
                          NomFr
                      )
                      VALUES (
                          'PFS',
                          'MV7',
                          'This model does not suffer the penalty to hit rolls for moving and firing Heavy weapons',
                          'Cette figurine ne subit pas de pénalité pour se déplacer et tirer avec des armes Lourdes.',
                          'Stable Platform',
                          'Plate-forme Stable'
                      );

					  
update Remplacement set DeclinaisonId = NULL, FigurineId = 'GCC' where Id= 119;
delete from Remplacement where Id = 118;

update ProfileArmes set AptitudesFr = 'Jetez un D6 chaque fois qu''une figurine subit des dégâts infligés par cette arme; sur 2+, la figurine subit une blessure mortelle et vous pouvez jeter un autre D6. Cette fois la figurine subit une blessure mortelle sur 3+. Continuez à jeter un D6, en augmentant à chaque fois de 1 le résultat à obtenir pour infliger une blessure mortelle, jusqu’à ce que la figurine soit réduite à 0 PV, ou que le jet rate.', AptitudesEn = 'Roll a D6 each time a model suffers damage from this weapon; on a 2+ the model suffers a mortal wound and you can roll another D6. This time, the model suffers a mortal wound on a 3+. Keep rolling a D6, increasing the score required to cause a mortal wound by 1 each time, until the model’s wounds are reduced to 0 or the roll is failed' where ID = 'FOL';

/* Correction suite retour 17/10/2018 à 19:10 */
update Pouvoirs set DescriptionFr = 'Tant que cette figurine est sur le champ de bataille et n''est pas secouée, vous gagnez un PC supplémentaire au début du round de bataille.' where id = 'L1';
update Remplacement set Operation='EFN:HFN|MTDN|SFN|GLN' where id = 20;

INSERT OR ignore INTO Armes (Id, DescriptionAdditionnelleEn, DescriptionAdditionnelleFr, NomEn, NomFr, cout) VALUES ('EPE2', NULL, NULL, 'Power sword', 'Epée énergétique', 0);
INSERT OR ignore INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EPE2', '', '', 'EPE2', '1', 'U', 0, 'Power sword', 'Epée énergétique', '-3', 'M', 'M');
Update FigurineArme set ArmeId = 'EPE2' where FigurineId = 'MESI' and ArmeId = 'EPE';
update Remplacement set Operation = 'FUG:(ELP|RPO|PIR)&(EMA|EPE2|MLA)' where Id= 34;
update Remplacement set Operation = 'CRA:(ELP|RPO|PIR)&(EMA|EPE2|MLA)' where Id= 37;
update Remplacement set Operation = 'MIT&EPE2:EFL&MLA' where Id= 40;

INSERT OR ignore INTO Armes (Id, DescriptionAdditionnelleEn, DescriptionAdditionnelleFr, NomEn, NomFr, cout) VALUES ('EPE1', NULL, NULL, 'Power sword', 'Epée énergétique', 1);
INSERT OR ignore INTO ProfileArmes (Id, AptitudesEn, AptitudesFr, ArmeId, D, F, NbTir, NomEn, NomFr, PA, Portee, TypeArmeId) VALUES ('EPE1', '', '', 'EPE1', '1', 'U', 0, 'Power sword', 'Epée énergétique', '-3', 'M', 'M');
update Remplacement set Operation = 'EPT:EPE2' where Id= 26;
update Remplacement set Operation = 'EPT:EPE2|GEN' where Id= 31;

INSERT OR ignore INTO REMPLACEMENT (Id,FigurineId,MaxParTeam,Operation) VALUES('150','DWI',1,'AUS');
INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('DWI1','M');
INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('DWI2','M');
INSERT OR ignore INTO DeclinaisonSpecialite (DeclinaisonId, SpecialiteId) VALUES ('DWI3','M');

update Declinaisons set NomFr = 'Deathwatch Veteran Gunner' where id = 'DWV2';
update DeclinaisonSpecialite set SpecialiteId = 'CB' where SpecialiteId = 'CO' and DeclinaisonId='ARP';

update ProfileArmes set ArmeId = 'CP' where Id = 'CP';
delete from ProfileArmes where Id = 'CP1';

update Aptitudes set DeclinaisonId='MB3' where Id = 'MB3';
update Remplacement set Operation = 'PEC:PDI' where Id= 76;

/* Correction Post vesrion 10 */
update Remplacement set Operation = 'ECO:DEVT|POE' where Id= 102;
update Remplacement set Operation = 'BO:LF|FU|PLA|FG' where Id= 4;

/* Correction Post vesrion 11 */
delete from MembreArme where ArmeId = NULL or MembreId = NULL;
update Remplacement set Operation = 'FUA:LF|MTI' where Id= 43;


/* Correction Post vesrion 12 */
update DeclinaisonSpecialite set SpecialiteId = 'AL' where SpecialiteId = 'L' and DeclinaisonId='DWV2';

INSERT or ignore INTO Aptitudes (
                          Id,
                          FigurineId,
                          DescriptionEn,
                          DescriptionFr,
                          NomEn,
                          NomFr
                      )
                      VALUES (
                          'RFE',
                          'GEN',
                          'This model has a 5+ invulnerable save',
                          'Cette figurine a une sauvegarde invulnérable de 5+.',
                          'Lightning Reflexes',
                          'Réflexes foudroyants'
                      );

INSERT or ignore INTO Aptitudes (
                          Id,
                          FigurineId,
                          DescriptionEn,
                          DescriptionFr,
                          NomEn,
                          NomFr
                      )
                      VALUES (
                          'RFE2',
                          'GEN2',
                          'This model has a 5+ invulnerable save',
                          'Cette figurine a une sauvegarde invulnérable de 5+.',
                          'Lightning Reflexes',
                          'Réflexes foudroyants'
                      );

update ProfileArmes set NomFr = 'Onde courte', NomEn = 'Short-wave' where Id = 'CSI2';


/* Correction Post vesrion 13 */
INSERT or IGNORE INTO Armes (
                      cout,
                      NomFr,
                      NomEn,
                      DescriptionAdditionnelleFr,
                      DescriptionAdditionnelleEn,
                      Id
                  )
                  VALUES (
                      1,
                      'Epées d''os',
                      'Boneswords',
                      NULL,
                      NULL,
                      'EPO2'
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
-                            2,
                             'Epées d''os',
                             'Boneswords',
                             0,
                             'U',
                             1,
                             'EPO2',
                             'Une figurine armée d''épées d''os peut effectuer 1 attaque supplémentaire avec à la phase de combat.',
                             'A model armed with boneswords can make 1 additional attack with them in the Fight phase.',
                             'EPO2'
                         );
update Remplacement set Operation = 'EPO2' where id = 135;


/* Correction Post vesrion 13 */
INSERT OR IGNORE INTO DeclinaisonArme (
                                DeclinaisonId,
                                ArmeId
                            )
                            VALUES (
                                'ASG2',
                                'CSH'
                            );
update DeclinaisonSpecialite set SpecialiteId = 'CB' where SpecialiteId = 'CO' and DeclinaisonId='NEF';

update Armes set NomEn = 'Pair of Nemesis falchions', NomFr='Paire de glaives Nemesis' where id = 'GLN';
update ProfileArmes set NomEn = 'Pair of Nemesis falchions', NomFr='Paire de glaives Nemesis' where id = 'GLN';
update Remplacement set Operation = 'DLA&VCI' where Id = 100;
delete from Remplacement where Id = 101;


/* Correction Post vesrion 14 */
update Declinaisons set Cout = 13 where Id ='HAM2';
update Declinaisons set Cout = 13 where Id ='HAM3';
update Figurines set NomEn = 'Militarum Tempestus Scion', NomFr = 'Militarum Tempestus Scion' where ID = 'AMS';


/* Correction Post vesrion 16 */
update tactiques set DescriptionFr='Utilisez cette tactique à la fin de la phase de Mouvement. Désignez une figurine ennemie à 1" de votre leader et jetez un D6. Sur 4+ cette figurine ennemie subit 1 blessure mortelle.' where ID = 'TS5';

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
