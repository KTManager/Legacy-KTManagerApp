
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- SPECIALISTES

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
                         'ST',
                         'ST22',
                         'Cerveau crucial à la mission',
                         'Mission-critical Mastermind',
                         'Votre kill team ne peut être démoralisée si cette figurine est sur le champ de bataille.',
                         'Your kill team cannot be broken while this model is on the battlefield.',
                         'ST34'
                     ),
                     (
                         'ST',
                         'ST22',
                         'Commandant Célèbre',
                         'Famed Commander',
                         'Si cette figurine est sur le champ de bataille et n''est pas secouée, vous gagnez 1 PC supplémentaire au début du round de bataille. Il peut être dépensé seulement pour une Tactique d''Aura pour cette figurine à ce round de bataille.',
                         'If this model is on the battlefield and not shaken, gain one additional Command Point at the start of the battle round. This can only be spent on an Aura Tactic for this model in this battle round.',
                         'ST33'
                     ),
                     (
                         'ST',
                         'ST21',
                         'Maitre Tacticien',
                         'Master Tactician',
                         'Tant que cette figurine est sur le champ de bataille et n''est pas secouée, soustrayez 1 au coût en PC des tactiques que vous utilisez (jusqu''à un minimum de 1).',
                         'As long as this model is on the battletield and not shaken, substract 1 from the Command Point cost of all Tactics you use (to a minimum of 1).',
                         'ST32'
                     ),
                     (
                         'ST',
                         'ST21',
                         'Contre-stratège',
                         'Counter-strategist',
                         'Tant que cette figurine est sur le champ de bataille et n''est pas secouée, jetez un D6 chque fois qu''un adversaire utilise une Tactique. Sur 5+, vous gagnez 1 PC.',
                         'As long as this model is on the battletield and not shaken, roll a D6 each time an opponent uses a Tactic. On a 5+ you gain 1 Command Point. ',
                         'ST31'
                     ),
                     (
                         'ST',
                         'ST1',
                         'Retraite feinte',
                         'Feigned Retreat',
                         'Cette figurine peut tirer ou réagir même si elle a Battu en Retraite ou s''est repliée plus tôt pendant ce round de bataille.',
                         'This model can shoot or React even if it Fell Back or Retreated earlier in the battle round. ',
                         'ST22'
                     ),
                     (
                         'ST',
                         'ST1',
                         'Conseiller',
                         'Advisor',
                         'Tant que cette figurine est à 3" d''autres spécialistes amis, le niveau de ces autres spécialistes est considéré comme étant supérieur de 1 (jusqu''à un maximum de Niveau 4) lorsqu''il s''agit de déterminer les Tactiques que vous pouvez utiliser.',
                         'Whilst this model is within 3" of other friendly specialists, those other specialists are treated as being one level higher than they actually are (to a maximum of Level 4) for the purposes of determining what Tactics you can use.',
                         'ST21'
                     ),
                     (
                         'ST',
                         NULL,
                         'Débrouillard',
                         'Resourceful',
                         'Tant que cette figurine est sur le champ de bataille et n''est pas secouée, vous gagnez un PC supplémentaire au début du round de bataille.',
                         'As long as this model is on the battlefield and not shaken, you gain 1 additional Command Point at the beginning of the battle round.',
                         'ST1'
                     ),
                     (
                         'F',
                         'F22',
                         'Ecraseur',
                         'Crusher',
                         'Ajoutez 1 aux jets de Trauma effectués suite aux attaques de cette figurine à la phase de Combat. ',
                         'Add 1 to Injury rolls made as a result of this model''s attacks in the Fight phase. ',
                         'F34'
                     ),
                     (
                         'F',
                         'F22',
                         'Pouvoir Dévastateur',
                         'Devastating Power',
                         'Améliorez de 1 la caractéristique de Dégâts des armes de mêlée de cette figurine. ',
                         'lmprove the Damage characteristic of this model''s melee weapons by 1. ',
                         'F33'
                     ),
                     (
                         'F',
                         'F21',
                         'Déchireur',
                         'Sunderer',
                         'Améliorez de 1 la caractéristique Pénétration d''Armure des armes de mêlée de cette figurine (par exemple, une arme PAO deviendrait PA-1). ',
                         'lmprove the Armour Penetration characteristic of this model''s melee weapons by 1 (e.g. an APO weapon becomes AP-1).',
                         'F32'
                     ),
                     (
                         'F',
                         'F21',
                         'Charge Buffle',
                         'Bull Charge',
                         'Ajoutez 1 à la caractéristique d''Attaques de cette figurine à un round de bataille où elle a terminé un mouvement de charge à 1" d''une figurine ennemie.',
                         'Add 1 to this model''s Attacks characteristic in a battle round in which it ended a charge move within 1" of an enemy model.',
                         'F31'
                     ),
                     (
                         'F',
                         'F1',
                         'Frappes Brutales',
                         'Brutal strikes',
                         'Relancez les jets de blessure de 1 pour cette figurine à la phase de combat.',
                         'Re-roll wound rolls of 1 for this model in the Fight phase.',
                         'F22'
                     ),
                     (
                         'F',
                         'F1',
                         'Juggernaut',
                         'Juggernaut',
                         'Ajoutez 1 aux jets de blessure pour cette figurine à la phase de Combat à un round de bataille où elle a terminé un mouvement de charge à l" d''une figurine ennemie. ',
                         'Add 1 to wound rolls for this model in the Fight phase of a battle round in which it ended a charge move within 1" of an enemy model.',
                         'F21'
                     ),
                     (
                         'F',
                         NULL,
                         'Musculeux',
                         'Muscular',
                         'Ajoutez 1 à la caractéristique de Force de cette figurine',
                         'Add 1 to this model''s Strength characteristic. ',
                         'F1'
                     );

--FACTIONS
INSERT OR IGNORE INTO Factions (
                         NomFr,
                         NomEn,
                         Id
                     )
                     VALUES (
                         'Gellerpox Infected',
                         'Gellerpox Infected',
                         'GI'
                     ),
                     (
                         'Elucidian Starstriders',
                         'Elucidian Starstriders',
                         'ES'
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
                          'ST',
                          2,
                          'CONTRE-TACTIQUE',
                          'COUNTER-TACTICS',
                          3,
                          NULL,
                          'Utilisez cette Tactique après que votre adversaire a dépensé des Points de Commandement pour utiliser une Tactique, si un Stratège niveau 3 ou plus est sur le champ de bataille et n''est pas secoué. Votre adversaire doit dépenser 1 PC supplémentaire pour utiliser cette Tactique. S''il choisit de ne pas le faire (ou s''il ne le peut pas) ses Points de Commandement lui sont rendus mais la Tactique qu''il a tenté d''utiliser n''est pa résolue et ne peut pas être utilisée à nouveau à cette phase.',
                          'Use this Tactic after your opponent has spent Command Points to use a Tactic if you have a Strategist specialist of Level 3 or higher on the battlefield that is not shaken. Your opponent must spend 1 additional Command Point to use that Tactic. If they choose not to (or they cannot), their Command Points are refunded but the Tactic they attempted to use is not resolved and cannot be attempted again this phase.',
                          'ST3'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'ST',
                          1,
                          'TACTIQUE INSPIREE',
                          'INSPIRED TACTICS',
                          2,
                          NULL,
                          'Ulisez celte Tactique, après avoir utilisé une Tactique de la section Tactiques et Points de commandement du manuel de Base de K11l Team si un Stratège niveau 2 ou plus est sur 1e champ de bataille et s''il n''est pas secoué. Vous pouvez utiliser à nouveau cette première Tactique à cette phase.',
                          'Use this Tactic after you have used a Tactic from the Command Points and Tactics section of the Kill Team Core Manual if you have a Strategist specialist of Level 2 or higher on the battlefield that is not shaken. You can use that Tactic again this phase. ',
                          'ST2'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'ST',
                          1,
                          'LEURRES',
                          'DECOYS',
                          1,
                          NULL,
                          'Utilisez cette Tactique au début du premier round de bataille, avant la phase d''Initiative, si un Stratège est sur le champ de bataille. Jetez un D3; vous pouvez retirer du champ de bataille un nombre de figurines inférieur ou égal au résultat de ce jet, et les placer à nouveau en suivant toutes les restrictions décrites par la mission ( comme être placées dans votre territoire par exemple). Vous ne pouvez utiliser cette Tactique qu''une fois par mission.',
                          'Use this Tactic at the start of the first battle round, before the initiative phase, if you have a Strategist specialist on the battlelield. Roll a D3; you can remove a number of models from your kill team from the battlefield up to the number rolled and set them up again, following any restrictions described in the mission (e.g. that they must be set up in your territory). This Tactic can only be used once per mission. ',
                          'ST1'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'F',
                          1,
                          'RAMASSAGE ET LANCER',
                          'GRAB AND THROW',
                          3,
                          NULL,
                          'Utilisez cette Tactique lorsqu''un adversaire doit effectuer un test de Chute pour une figurine à l" d''un spécialiste en Force de niveau 3 ou supérieur de votre kill team qui n''est pas secoué et n''a pas à effectuer de test de Chute. Au lieu d''effectuer le test de Chute de façon normale, chaque joueur en contrôle jette un D6 et ajoute la caractéristique de Force de sa figurine au résultat. Si votre résultat est supérieur ou égal à celui de l''adversaire, le test de Chute est raté; sinon, il est réussi.',
                          'Use this Tactic when an opponent has to take a take a Falling test for a model that is within 1" of a Strength specialist of Level 3 or higher from your kill team that is not shaken and does not have to take a Falling test. lnstead of taking the Falling test in the normal fashion, each controlling player rolls a D6 and adds their model''s Strength characteristic to the result. If your score equals or beats your opponent''s, the Falling test is failed; otherwise, it is passed. ',
                          'F3'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'F',
                          1,
                          'COUP PUISSANT',
                          'MIGHTY BLOW',
                          2,
                          NULL,
                          'Utilisez cette Tactique lorsqu''un spécialiste en Force de Niveau 2 ou supérieur de votre kill team effectue une attaque qui cible une figurine ennemie à la phase de Combat (utilisez cette Tactique avant le jet de touche). Si l''attaque touche, la séquence d''attaque se termine et l''ennemi subit 1 blessure mortelle.',
                          'Use this Tactic when a Strength specialist of Level 2 or higher from your kill team makes an attack that targets an enemy model in the Fight phase (use the Tactic before the hit roll is made). If the attack hits, the attack sequence ends and the enemy model suffers 1 mortal wound.',
                          'F2'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          'F',
                          1,
                          'ECRASEMENT DE CHAIR',
                          'BODY SLAM',
                          1,
                          NULL,
                          'Utilisez cette Tactique lorsqu''un spécialiste en Force de votre kill team termine un mouvement de charge à l" d''au moins une figurine ennemie. Jetez un D6 pour chaque figurine ennemie à l" de ce spécialiste en Force; sur 6, la figurine ennemie subit 1 blessure mortelle.',
                          'Use this Tactic when a Strength specialist from your kill team ends a charge move within 1" of any enemy models. Roll a D6 for each enemy model within l" of that Strength specialist; on a 6, that enemy model suffers 1 mortal wound.',
                          'F1'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'FRAPPES FATALES',
                          'KILLING STRIKES',
                          0,
                          'ES',
                          'Utilisez cette Tactique avant de choisir KNOSSO PROND pour la faire combattre à la phase de Combat. Jusqu''à la fin de la phase, la caractéristique de Dégâts de sa lame énergétique est de D3.',
                          'Use this Tactic before KNOSSO PROND is chosen to fight with in the Fight phase. Until the end of the phase, the Damage characteristic of her power blade is increased to D3.',
                          'ES6'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'CHAMP VOLTAGHEIST',
                          'VOLTAGHEIST FIELD',
                          0,
                          'ES',
                          'Utilisez cette Tactique avant de choisir LARSEN VAN DER GRAUSS pour le faire tirer à la phase de Tir. Au lieu de tirer normalement, il peut effectuer une des actions suivantes: ouvrir ou fermer une porte comme s''il était à 1" d''elle, détecter les pièges dans un élément de terrain (votre/vos adversaire(s) doit/doivent vous dire si l''élément de terrain a été piégé ou non), ou ignorer les pénalités à ses jets de touche avec son pistolet voltaïque à cette phase si la figurine cible est masquée.',
                          'Use this Tactic before LARSEN VAN DER GRAUSS is chosen to shoot with in the Shooting phase. He can do one of the following instead of shooting
normally: open or close a door as if he were within 1" of it, scan a terrain feature for traps (your opponent(s) must tell you if that terrain feature has been trapped or not), or ignore penalties to his hit rolls for the target model being obscured when shooting with his voltaic pistol this phase.',
                          'ES5'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'OBJECTIF PRIORITAIRE IDENTIFIE',
                          'PRIORITY OBJECTIVE IDENTIFIED',
                          0,
                          'ES',
                          'Utilisez cette Tactique à la fin de la phase de 
Mouvement si LARSEN VAN DER GRAUSS est à 3" d''un pion objectif et s''il n''est pas secoué. Jusqu''à la fin du round de bataille, ajoutez 1 à ses jets de sauvegarde et à sa caractéristique d''Attaques.',
                          'Use this Tactic at the end of the Movement phase if LARSEN VAN DER GRAUSS is within 3" of an objective marker and not shaken. Until the end of the battle round, add 1 to his saving throws and Attacks characteristic.',
                          'ES4'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'CARTOUCHE EXECUTIONER',
                          'EXECUTIONER SHELL',
                          0,
                          'ES',
                          'Utilisez cette Tactique avant de choisir le VOIDMASTER NITSCH pour le faire tirer à la phase de Tir. Faites un seul jet de touche avec son fusil à pompe d''artificier à cette phase, mais ajoutez 3 au jet; s''il est réussi, la figurine ennemie subit 1 
blessure mortelle et la séquence d''attaque prend fin.',
                          'Use this Tactic before Voidmaster Nitsch is chosen to shoot with in the Shooting phase. Only make a single hit roll with his artificer shotgun this phase, but add 3 to the result; if the hit roll is successful, the enemy model suffers 1 mortal wound and the attack sequence ends.',
                          'ES3'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'TRANSFERT VOLTAGHEIST',
                          'VOLTAGHEIST TRANSFERENCE',
                          0,
                          'ES',
                          'Utilisez cette Tactique à la phase de Mouvement avant d''effectuer un mouvement normal avec LARSEN VAN DER GRAUSS. Retirez cette figurine du champ de bataille, puis replacez-la à plus de 4" des figurines ennemies. Il ne peut plus se déplacer à cette phase.',
                          'Use this Tactic in the Movement phase before making a normal move with LARSEN VAN DER GRAUSS. Remove this mode! from the battlefield, then set it up anywhere that is more than 4" from any enemy models. He cannot move further this phase.',
                          'ES2'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'REMEDE DE COMBAT',
                          'COMBAT MEDECINE',
                          0,
                          'ES',
                          'Utilisez cette Tactique après avoir utilisé l''aptitude 
Sérum de Soin de SANISTASIA MINST (avec 
succès ou non). Vous pouvez immédiatement utiliser cette aptitude une seconde fois à cette phase, sur une figurine différente ou sur la même.',
                          'Use this Tactic after using SANISTASIA MINST''s Healing Serum ability (whether or not the ability was successful). You can immediately use that ability for a second tune this phase, either on a different model or the same model again.',
                          'ES1'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'DEFAILLANCE DE LA MACHINE',
                          'MACHINE GLITCH',
                          0,
                          'GI',
                          'Utilisez cette Tactique quand un joueur tente d''ouvrir ou fermer une porte si un GLITCHLING de votre Kill Team qui n''est pas secoué est à 1" de cette porte ou entrée. Ajoutez 3 à votre jet lorsque vous tirez au dé pour déterminer si cette porte s''ouvre (ou reste fermée) ou se ferme (ou reste ouverte).',
                          'Use this Tactic when a player attempts to open or close a door if a GLITCHLING from your Kill Team that is not shaken is within 1" of that door or doorway. Add 3 to your dice result when rolling off to determine if that door opens (or remains dosed) or if it closes (or remains open).',
                          'GI6'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'BIENFAITS MALSAINS',
                          'TWISTED BLESSINGS',
                          0,
                          'GI',
                          'Utilisez cette Tactique à la fin de la phase de Mouvement. Choisissez une figurine de NIGHTMARE HULK de votre kill team qui a une ou plusieurs blessures légères et jetez un D6; sur 4+, 1 blessure légère est retirée de cette figurine.',
                          'Use this Tactic at the end of the Movement phase. Choose a NIGHTMARE HULK model from your kill team that has one or more flesh wounds and roll a D6; on a 4+ one flesh wound is removed from that model.',
                          'GI5'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          3,
                          'INFESTATION VERMINOIDE',
                          'VERMINOID INFESTATION',
                          0,
                          'GI',
                          'Utilisez cette Tactique à la fin de la phase de 
Mouvement. Placez une figurine de MUTOID
VERMIN sur le champ de bataille, entièrement à 6" d''une figurine de GELLERPOX INFECTED de votre kill team et à plus de 6" des figurines ennemies. Cette figurine de Mutoid Vermin est ajoutée à
votre kill team jusqu''à la fin de la mission, mais est ignorée pour déterminer si votre kill team est démoralisée. A la fin de la bataille, retirez toutes les figurines ajoutées à votre kill team grâce à cette Tactique avant de déterminer qui a gagné la mission.',
                          'Use this Tactic at the end of the Movement phase. Set up a MUTOID VERMIN model on the battlefield anywhere that is wholly wilhin 6" of a GELLERPOX INFECTED model from your kill team and more than 6" from any enemy models. This MUTOID VERMIN model is added to your kill team until the end of the mission, but is ignored for the purposes of determining whether your kill team is broken. At the end of the battle, remove all models added to your kill team through this Tactic before determining who has won the mission.',
                          'GI4'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'VOMI RANCI',
                          'RANCID VOMIT',
                          0,
                          'GI',
                          'Utilisez cette Tactique au début de la phase de Tir. Choisissez une figurine de NIGHTMARE HULK de votre kill team puis choisissez une figurine ennemie à 6" et visible d''elle. Jetez trois D6; pour chaque jet de 5+, cette figurine ennemie subit 1 blessure mortelle.',
                          'Use this Tactic at the start of the Shooting phase. Choose a NIGHTMARE HULK model from your kill team and then choose an enemy model within 6" of and visible to it. Roll three D6; for each roll of 5+ that enemy model suffers 1 mortal wound.',
                          'GI3'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'GLISSEMENT GELLER',
                          'GELLERSHIFT',
                          0,
                          'GI',
                          'Utilisez cette tactique à la phase de Mouvement avant d''effectuer un mouvement normal avec un GELLERPOX MUTAN de votre kill team. Retirez cette figurine du champ de bataille, puis replacez-la à plus de 4" des figurines ennemies. Elle ne peut plus se déplacer à cette phase.',
                          'Use this Tactic in the Movement phase before making a normal move with a GELLERPOX MUTANT from your kill team. Remove that model from the battlefield, lhen set it up anywhere on the battlefield that is more than 4" from any enemy models. lt cannot move further in this phase.',
                          'GI2'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'CORRUPTION ET RUINE',
                          'CORRUPTION AND DECAY',
                          0,
                          'GI',
                          'Utilisez cette tactique au début de la phase de Combat. Choisissez une figurine ennemie à 3" d''une figurine de votre kill team. Jusqu''à la fin de la phase, soustrayez 1 à la caractéristique d''Endurance de cette figurine ennemie.',
                          'Use this Tactic at the start of the Fight phase. Choose an enemy model within 3" of a model from your kill team. Until the end of the phase, subtract 1 from that enemy model''s Toughness characteristic.',
                          'GI1'
                      ),
                      (
                          0,
                          1,
                          'ESE',
                          NULL,
                          1,
                          'AUSPICATOR MULTISPECTRAL',
                          'MULTI-SPECTRAL AUSPICATOR',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de mouvement. ELUCIA VHANE gagne l''aptitude d''aura suivante jusqu''à la fin du round de bataille: Si cette figurine n''est pas secouée, relancez les jets de touche de 1 pour les attaques des figurines d''ELUCIDIAN STARSTRIDERS amies à 6" d''elle.',
                          'Use this Tactic at the start of the Movement phase. ELUCIA VHANE gains the following aura ability until the end of the battle round: As long as this model is not shaken, re-roll hit rolls of 1 for attacks made by friendly ELUCIDIAN STARSTRIDERS models within 6" of it.',
                          'ESE1'
                      ),
                      (
                          0,
                          0,
                          'ESE',
                          NULL,
                          2,
                          'CHEVALIERE DIGILASER',
                          'DIGITAL LASER REGALIA',
                          0,
                          NULL,
                          'Utilisez cette tactique juste après avoir fait combattre ELUCIA VHANE. Effectuez un jet de touche supplémentaire contre une figurine ennemie à 1" d''elle; si ce jet réussi, la figurine ennemie subit 1 blessure mortelle et la séquence d''attaque prend fin.',
                          'Use this Tactic immediately after fighting with 
ELUCIA VHANE. Make an additional hit roll against an enemy model within l" of her; if the hit roll
is successful, the enemy model suffers 1 mortal
wound and the attack sequence ends.',
                          'ESE2'
                      ),
                      (
                          0,
                          0,
                          'GIV',
                          NULL,
                          1,
                          'BABIL DEMENTIEL',
                          'INSANE GIBBERING',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase psychique si votre kill team inclut VULGAR THRICE-CURSED. Jusqu''à la fin de la phase, soustrayez 1 aux tests psychiques effectués pour les psykers ennemis tant qu''ils sont à 18" de votre VULGAR THRICE-CURSED.',
                          'Use this Tactic at the start of the Psychic phase if your kill team includes VULGRAR THRICE-CURSED. Until the end of the phase, subtract 1 from Psychic tests taken for enemy PSYKERS whilst they are within 18" of your VULGRAR THRICE-CURSED.',
                          'GIV1'
                      ),
                      (
                          0,
                          1,
                          'GIV',
                          NULL,
                          1,
                          'SEIGNEUR DE LA RANCOEUR',
                          'LORD OF RESENTMENT',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de mouvement si votre kill team inclut VULGAR THRICE-CURSED. Cette figurine gagne l''aptitude d''aura suivante jusqu''à la fin du round de bataille: Si cette figurine n''est pas secouée, vous pouvez relancer les jets de touche de 1 pour les figurines de GELLERPOX INFECTED amies à 6" d''elle.',
                          'Use this Tactic at the start of the Movement phase if your kill team includes VULGRAR THRICE-CURSED. This model gains the following aura 
ability until the end of the battle round:
As long as this model is not shaken, you can re-roll hit rolls of 1 made for friendly GELLERPOX INFECTED models within 6" this model.',
                          'GIV2'
                      ),
                      (
                          1,
                          0,
                          NULL,
                          NULL,
                          1,
                          'DUEL D''HONNEUR',
                          'DUEL OF HONOUR',
                          0,
                          NULL,
                          'Utilisez cette tactique au début de la phase de combat. Votre commandant ne peut cibler que les commandants ennemis à cette phase, mais vous pouvez relancer les jets de touche et de blessure ratés pour les attaques de votre commandant jusqu''à la fin de la phase.',
                          'Use this Tactic at the start of the Fight phase. Your Commander can only target enemy Commanders lhis phase, but you re-roll all failed hit and wound rolls for your Commander''s attacks until the end of the phase.',
                          'COM3'
                      ),
                      (
                          1,
                          0,
                          NULL,
                          NULL,
                          1,
                          'INTERVENTION HEROIQUE',
                          'HEROIC INTERVENTION',
                          0,
                          NULL,
                          'Utilisez cette tactique à la fin de la phase de mouvement s''il y a au moins une figurine ennemie à 3" de votre commandant, et qu''il n''a pas avancé, battu en retraite ni tenté de charger à cette phase. Votre commandant peut immédiatement effectuer un mouvement d''engagement comme décrit à la phase de combat.',
                          'Use this Tactic at the end of the Movement
phase if there are any enemy models within 3" of your Commander and your Commander did not Advance, Fall Back, Retreat or make a charge attempt this phase. Your Commander can immediately make a pile-in move as described in the Fight phase.',
                          'COM2'
                      ),
                      (
                          1,
                          0,
                          NULL,
                          NULL,
                          1,
                          'ATTENTION, MONSIEUR!',
                          'LOOK OUT, SIR!',
                          0,
                          NULL,
                          'Utilisez cette tactique quand vous ratez un jet de sauvegarde pour votre Commandant et qu''il y a une figurine de votre kill team à 2" de lui (hors figurines secouées). Jetez un D6; sur 2+ les dégât est infligé à la figurine, pas au Commandant.',
                          'Use this Tactic when you fail a saving throw for your Commander if there is another model from your kill team within 2" of them (excluding shaken models). Roll a D6; on a 2+ the damage is inflicted on that model instead of your Commander.',
                          'COM1'
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
                          'Nightmare Hulk',
                          'Nightmare Hulk',
                          'CHAOS, NURGLE, INFANTERIE, NIGHTMARE HULK',
                          'CHAOS, NURGLE, INFANTERY, NIGHTMARE HULK',
                          'GI',
                          'GIN'
                      ),
                      (
                          'Gellerpox Mutant',
                          'Gellerpox Mutant',
                          'CHAOS, NURGLE, INFANTERIE, GELLERPOX MUTANT',
                          'CHAOS, NURGLE, INFANTRY, GELLERPOX MUTANT',
                          'GI',
                          'GIG'
                      ),
                      (
                          'Eyestinger Swarm',
                          'Eyestinger Swarm',
                          'CHAOS, NURGLE, NUÉE, VOL, MUTOID VERMIN EYESTINGER SWARM',
                          'CHAOS, NURGLE, SWARM, FLY, MUTOID VERMIN EYESTINGER SWARM',
                          'GI',
                          'GIE'
                      ),
                      (
                          'Glitchling',
                          'Glitchling',
                          'CHAOS, NURGLE, INFANTERIE, DAEMON, GLITCHLING',
                          'CHAOS, NURGLE, INFANTRY, DAEMON, GLITCHLING',
                          'GI',
                          'GIL'
                      ),
                      (
                          'Cursemite',
                          'Cursemite',
                          'CHAOS, NURGLE, BÊTE, MUTOID VERMIN, CURSEMITE',
                          'CHAOS, NURGLE, BEAST, MUTOID VERMIN, CURSEMITE',
                          'GI',
                          'GIC'
                      ),
                      (
                          'Sludge-grub',
                          'Sludge-grub',
                          'CHAOS, NURGLE, BÊTE, MUTOID VERMIN, SLUDGE-GRUB',
                          'CHAOS, NURGLE, BEAST, MUTOID VERMIN, SLUDGE-GRUB',
                          'GI',
                          'GIS'
                      ),
                      (
                          'Vulgrar thrice-cursed',
                          'Vulgrar thrice-cursed',
                          'CHAOS, NURGLE, COMMANDANT, INFANTERIE, TWISTED LORD, VULGRAR THRICE-CURSED',
                          'CHAOS, NURGLE, COMMANDER, INFANTRY, TWISTED LORD, VULGRAR THRICE-CURSED',
                          'GI',
                          'GIV'
                      ),
                      (
                          'Sanistasia Minst',
                          'Sanistasia Minst',
                          'IMPERIUM, INFANTERIE, REJUVENAT ADEPT, SANISTASIA MINST',
                          'IMPERIUM, INFANTRY, REJUVENAT ADEPT, SANISTASIA MINST',
                          'ES',
                          'ESS'
                      ),
                      (
                          'Larsen Van Der Grauss',
                          'Larsen Van Der Grauss',
                          'IMPERIUM, ADEPTUS MECHANICUS, MARS, INFANTERIE, TECH-PRIEST, LECTRO-MAESTER, LARSEN VAN DER GRAUSS',
                          'IMPERIUM, ADEPTUS MECHANICUS, MARS, INFANTRY, TECH-PRIEST, LECTRO-MAESTER, LARSEN VAN DER GRAUSS',
                          'ES',
                          'ESL'
                      ),
                      (
                          'Knosso Prond',
                          'Knosso Prond',
                          'IMPERIUM, ADEPTUS MINISTORUM, INFANTERIE, DEATH CULT EXECUTIONER, KNOSSO PROND',
                          'IMPERIUM, ADEPTUS MINISTORUM, INFANTRY, DEATH CULT EXECUTIONER, KNOSSO PROND',
                          'ES',
                          'ESK'
                      ),
                      (
                          'Voidsman',
                          'Voidsman',
                          'IMPERIUM, INFANTERIE, VOIDSMAN (Aximilion : IMPERIUM, BÊTE, VOIDSMAN, AXIMILLION)',
                          'IMPERIUM, INFANTRY, VOIDSMAN (Aximilion : IMPERIUM, BÊTE, VOIDSMAN, AXIMILLION)',
                          'ES',
                          'ESV'
                      ),
                      (
                          'Elucia Vhane',
                          'Elucia Vhane',
                          'IMPERIUM, ASTRA CARTOGRAPHICA, COMMANDANT, INFANTERIE, ROGUE TRADER, ELUCIA VHANE',
                          'IMPERIUM, ASTRA CARTOGRAPHICA, COMMANDER, INFANTERIE, ROGUE TRADER, ELUCIA VHANE',
                          'ES',
                          'ESE'
                      );

INSERT OR IGNORE INTO Declinaisons (
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
                             6,
                             6,
                             1,
                             'Aximillion',
                             'Aximillion',
                             1,
                             8,
                             'ESV',
                             3,
                             3,
                             5,
                             0,
                             4,
                             2,
                             'ESV4'
                         ),
                         (
                             0,
                             6,
                             5,
                             2,
                             'Voidsman Nitsch',
                             'Voidsman Nitsch',
                             1,
                             6,
                             'ESV',
                             3,
                             3,
                             8,
                             3,
                             4,
                             2,
                             'ESV3'
                         ),
                         (
                             0,
                             6,
                             5,
                             1,
                             'Voidsman Gunner',
                             'Voidsman Gunner',
                             1,
                             6,
                             'ESV',
                             3,
                             3,
                             7,
                             3,
                             4,
                             1,
                             'ESV2'
                         ),
                         (
                             0,
                             6,
                             5,
                             1,
                             'Voidsman',
                             'Voidsman',
                             3,
                             6,
                             'ESV',
                             3,
                             3,
                             7,
                             3,
                             4,
                             1,
                             'ESV1'
                         ),
                         (
                             0,
                             25,
                             5,
                             2,
                             'Knosso Prond',
                             'Knosso Prond',
                             1,
                             7,
                             'ESK',
                             4,
                             3,
                             8,
                             4,
                             3,
                             4,
                             'ESK'
                         ),
                         (
                             0,
                             22,
                             4,
                             2,
                             'Larsen Van Der Grauss',
                             'Larsen Van Der Grauss',
                             1,
                             6,
                             'ESL',
                             3,
                             3,
                             8,
                             4,
                             4,
                             2,
                             'ESL'
                         ),
                         (
                             0,
                             17,
                             5,
                             2,
                             'Sanistasia Minst',
                             'Sanistasia Minst',
                             1,
                             6,
                             'ESS',
                             3,
                             3,
                             7,
                             4,
                             4,
                             2,
                             'ESS'
                         ),
                         (
                             1,
                             0,
                             4,
                             4,
                             'Elucia Vhane',
                             'Elucia Vhane',
                             1,
                             6,
                             'ESE',
                             3,
                             3,
                             9,
                             3,
                             3,
                             3,
                             'ESE'
                         ),
                         (
                             0,
                             31,
                             6,
                             4,
                             'Nightmare hulk',
                             'Nightmare hulk',
                             2,
                             4,
                             'GIN',
                             5,
                             5,
                             7,
                             0,
                             4,
                             3,
                             'GIN1'
                         ),
                         (
                             0,
                             31,
                             6,
                             4,
                             'Gnasher-Screamer',
                             'Gnasher-Screamer',
                             1,
                             4,
                             'GIN',
                             5,
                             5,
                             8,
                             0,
                             4,
                             4,
                             'GIN2'
                         ),
                         (
                             0,
                             8,
                             6,
                             1,
                             'Gellerpox Mutant',
                             'Gellerpox Mutant',
                             3,
                             5,
                             'GIG',
                             4,
                             4,
                             6,
                             4,
                             4,
                             2,
                             'GIG'
                         ),
                         (
                             0,
                             5,
                             7,
                             1,
                             'Eyestinger Swarm',
                             'Eyestinger Swarm',
                             4,
                             10,
                             'GIE',
                             2,
                             2,
                             8,
                             0,
                             4,
                             'D3',
                             'GIE'
                         ),
                         (
                             0,
                             5,
                             6,
                             1,
                             'Glitchling',
                             'Glitchling',
                             4,
                             5,
                             'GIL',
                             2,
                             2,
                             7,
                             0,
                             4,
                             2,
                             'GIL'
                         ),
                         (
                             0,
                             4,
                             6,
                             1,
                             'Cursemite',
                             'Cursemite',
                             4,
                             8,
                             'GIC',
                             2,
                             2,
                             8,
                             0,
                             4,
                             2,
                             'GIC'
                         ),
                         (
                             0,
                             5,
                             6,
                             1,
                             'Sludge-grub',
                             'Sludge-grub',
                             4,
                             5,
                             'GIS',
                             3,
                             2,
                             8,
                             4,
                             4,
                             1,
                             'GIS'
                         ),
                         (
                             1,
                             0,
                             6,
                             5,
                             'Vulgrar Thrice-cursed',
                             'Vulgrar Thrice-cursed',
                             1,
                             4,
                             'GIV',
                             5,
                             5,
                             9,
                             6,
                             3,
                             4,
                             'GIV'
                         );

INSERT OR IGNORE INTO CoutNiveau (
                           Cout,
                           Niveau,
                           DeclinaisonId,
                           Id
                       )
                       VALUES (
                           130,
                           4,
                           'GIV',
                           8
                       ),
                       (
                           105,
                           3,
                           'GIV',
                           7
                       ),
                       (
                           85,
                           2,
                           'GIV',
                           6
                       ),
                       (
                           65,
                           1,
                           'GIV',
                           5
                       ),
                       (
                           100,
                           4,
                           'ESE',
                           4
                       ),
                       (
                           75,
                           3,
                           'ESE',
                           3
                       ),
                       (
                           60,
                           2,
                           'ESE',
                           2
                       ),
                       (
                           45,
                           1,
                           'ESE',
                           1
                       );

INSERT OR IGNORE INTO Traits (
                       Point,
                       NomFr,
                       NomEn,
                       Niveau,
                       DeclinaisonId,
                       DescriptionFr,
                       DescriptionEn,
                       Id
                   )
                   VALUES (
                       30,
                       'Maitre spécialiste',
                       'Master specialist',
                       4,
                       NULL,
                       'Au lieu de choisir pour cette figurine une seule aptitude qu''elle n''a pas déjà choisie sur l''arbre d''aptitude de sa spécialité (car elle est niveau 4), vous pouvez choisir deux aptitudes qu''elle n''a pas déjà choisies sur l''arbre d''aptitudes de sa spécialité.',
                       'Instead of choosing a single ability for this model not already chosen from their specialism''s ability tree (for being Level 4), you can choose two abilities not already chosen from their specialism''s ability tree.',
                       'G6'
                   ),
                   (
                       15,
                       'Généraliste',
                       'Generalist',
                       4,
                       NULL,
                       'Au lieu de choisir l''aptitude de niveau 4 de son arbre d''aptitude, vous pouvez choisir pour cette figurine une aptitude de niveau 1 issue d''une autre spécialité listée sur sa carte technique. Sa spéciliét ne change pas pour autant.',
                       'Instead of choosing the level 4 ability from their specialism''s ability tree, you can choose a Level 1 ability for this model from a different specialism listed on their datacard. Their specialism does not change.',
                       'G5'
                   ),
                   (
                       20,
                       'Planificateur tactique',
                       'Tactical planner',
                       0,
                       NULL,
                       'Au début du premier round de bataille, vous gagnez D3 points de commandement.',
                       'At the start of the first battle round you gain D3 Command Points.',
                       'G4'
                   ),
                   (
                       5,
                       'Héros stoïque',
                       'Stoic hero',
                       0,
                       NULL,
                       'Ignorez la pénalité aux jets de touche de cette figurine causée par 1 blessure légère qu''elle a subie.',
                       'Ignore the penality to this model''s hit rolls from one flesh wound it has suffered.',
                       'G3'
                   ),
                   (
                       10,
                       'Touché par le destin',
                       'Destined by fate',
                       0,
                       NULL,
                       'Jetez un D6 chaque fois que cette figurine subit une blessure mortelle. Sur 6, elle ne perd pas de PV.',
                       'Roll a D6 each time this model suffers a mortal wound. On a 6, that wound is not lost.',
                       'G2'
                   ),
                   (
                       5,
                       'Volonté de fer',
                       'Iron will',
                       0,
                       NULL,
                       'Cette figurine réussit automatiquement les tests de Sang-froid.',
                       'This model automatically passes Nerve tests.',
                       'G1'
                   ),
                   (
                       10,
                       'Malveillance éclairée',
                       'Twisted Brillance',
                       0,
                       'GIV',
                       'Si votre kill team est réglementaire, vous débutez la bataille avec 1 point de Commandement supplémentaire (qui peut être dépensé seulement pour utiliser une tactique Gellerpox Infected).',
                       'If your kill team is Battle-forged, you start the battle with 1 additional Command Point (this can only be spent to use a Gellerpox Infected Tactic).',
                       'GIV1'
                   ),
                   (
                       15,
                       'Marchande combattante',
                       'Trader militant',
                       0,
                       'ESE',
                       'Ajoutez 1 à la caractéristique d''attaques de cette figurine.',
                       'Add 1 to this model''s Attacks characteristic.',
                       'ESE2'
                   ),
                   (
                       10,
                       'Maitresse de flotte d''exploration',
                       'Explorator Fleetmaster',
                       0,
                       'ESE',
                       'Si votre kill team est réglementaire, vous débutez la bataille avec 1 point de Commandement supplémentaire (qui peut être dépensé seulement pour utiliser une tactique Elucidian Starstriders).',
                       'If your kill team is Battle-forged, you start the battle with 1 additional Command Point (this can only be spent to use an Elucidian Starstriders Tactic).',
                       'ESE1'
                   ),
                   (
                       15,
                       'Maitre de la vermine',
                       'Master of vermin',
                       0,
                       'GIV',
                       'Si cette figurine n''est pas secouée, vous pouvez relancer les jets de touche ratés pour les figurines de MUTOID VERMIN amies à 6" d''elle.',
                       'As long as this model is not shaken, you can re­roll failed hit rolls for friendly MUTOID VERMIN models whilst they are within 6" of it.',
                       'GIV2'
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
                          'Serviteur loyal',
                          'Loyal Retainer',
                          'ESV',
                          NULL,
                          'Ajoutez 1 à la caractéristique Commandement de cette figurine si elle est à 6" d''ELUCIA VHANE.',
                          'Add 1 to the Leadership characteristic of this model whilst it is within 6" of ELUCIA VHANE.',
                          NULL,
                          'SEL'
                      ),
                      (
                          'Serviteur spécialiste',
                          'Specialist retainer',
                          NULL,
                          NULL,
                          'Cette figurine est toujours un specialiste médic, mais cela ne compte pas dans le nombre maximum des spécialistes de votre kill team.',
                          'This model is always a Medic specialist, but this does not count towards the
maximum number of specialists in your kill team.',
                          'ESS',
                          'SESPM'
                      ),
                      (
                          'Serviteur spécialiste',
                          'Specialist retainer',
                          NULL,
                          NULL,
                          'Cette figurine est toujours un specialiste en communications, mais cela ne compte pas dans le nombre maximum des spécialistes de votre kill team.',
                          'This model is always a Comms specialist, but this does not count towards the
maximum number of specialists in your kill team.',
                          'ESL',
                          'SESPCO'
                      ),
                      (
                          'Serviteur spécialiste',
                          'Specialist retainer',
                          NULL,
                          NULL,
                          'Cette figurine est toujours un specialiste en combat, mais cela ne compte pas dans le nombre maximum des spécialistes de votre kill team.',
                          'This model is always a Combat specialist, but this does not count towards the
maximum number of specialists in your kill team.',
                          'ESK',
                          'SESPCB'
                      ),
                      (
                          'Réflexes troublants',
                          'Uncanny reflexes',
                          NULL,
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 5+.',
                          'This model has a 5+ invulnerable save.',
                          'ESK',
                          'RET'
                      ),
                      (
                          'Zélée',
                          'Zealous',
                          NULL,
                          NULL,
                          'Vous pouvez relancerles jets de touche ratés pour cette figurine lors d''un round de bataille où elle a chargé ou a été chargée par une figurine ennemie.',
                          'You can re-roll failed hit rolls for this model in a battle round in which it charged or was charged by an enemy model.',
                          'ESK',
                          'ZEL'
                      ),
                      (
                          'Dispositif Voltagheist',
                          'Voltagheist Array',
                          NULL,
                          NULL,
                          'Les figurines d''ELUCIDIAN STARSTRIDERS amies à 6" de cette figurine ont une sauvegarde invulnérable de 5+.',
                          'Friendly ELUCIDIAN 
STARSTRIDERS models that are within 6" of this model have a 5+ invulnerable save.',
                          'ESL',
                          'DVO'
                      ),
                      (
                          'Sérum de soin',
                          'Healing serum',
                          NULL,
                          NULL,
                          'A la fin de la phase de Mouvement, si cette figurine n''est pas secouée ni Préparée, et si si elle n''a pas Battu en Retraite ni tenté de charger à cette phase, choisissez une figurine d''Elucidian starstriders amie à 1" de cette figurine et ayant une ou plusieurs blessures légères. Jetez un D6; sur 4+, une blessure légère est retirée de cette figurine.',
                          'At the end of the Movement phase, as long as this model is not shaken or Readied and did not Fall Back or make a charge attempt this phase, choose a friendly ELUCIDIAN STARSTRIDERS model that has any flesh wounds and is within 1" of this model. Roll a D6; on a 4+ one flesh wound is removed from that model.',
                          'ESS',
                          'SSO'
                      ),
                      (
                          'Arme Archéotechnologique Dissimulée',
                          'Concealed Archeotech Weapon',
                          NULL,
                          NULL,
                          'Une fois par bataille, au début de la phase de Combat, Choisissez une figurine ennemie à 1" de cette figurine et jetez un dé; sur 4+, la figurine ennemie subit D3 blessures mortelles.',
                          'Once per battle, at the start of the Fight phase, pick an enemy model within 1" of this model and roll a dice; on a 4+ the enemy model suffers D3 mortal wounds.',
                          'ESE',
                          'AAD'
                      ),
                      (
                          'Générateur de Champ Disrupteur',
                          'Disruption Field Generator',
                          NULL,
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 4+.',
                          'This model has a 4+ invulnerable save.',
                          'ESE',
                          'GCD'
                      ),
                      (
                          'Affreusement résistant',
                          'Disgustingly Resilient',
                          NULL,
                          NULL,
                          'Chaque fois qu''une figurine avec cette aptitude perd un PV, jetez un D6; sur 5+, la figurine ne perd pas ce PV.',
                          'Each time a model with this


ability loses a wound, roll a D6; on a 5+ the model does


not lose that wound.',
                          'GIL',
                          'AFR4'
                      ),
                      (
                          'Affreusement résistant',
                          'Disgustingly Resilient',
                          NULL,
                          NULL,
                          'Chaque fois qu''une figurine avec cette aptitude perd un PV, jetez un D6; sur 5+, la figurine ne perd pas ce PV.',
                          'Each time a model with this


ability loses a wound, roll a D6; on a 5+ the model does


not lose that wound.',
                          'GIG',
                          'AFR3'
                      ),
                      (
                          'Affreusement résistant',
                          'Disgustingly Resilient',
                          'GIN',
                          NULL,
                          'Chaque fois qu''une figurine avec cette aptitude perd un PV, jetez un D6; sur 5+, la figurine ne perd pas ce PV.',
                          'Each time a model with this


ability loses a wound, roll a D6; on a 5+ the model does


not lose that wound.',
                          NULL,
                          'AFR2'
                      ),
                      (
                          'Affreusement résistant',
                          'Disgustingly Resilient',
                          NULL,
                          NULL,
                          'Chaque fois qu''une figurine avec cette aptitude perd un PV, jetez un D6; sur 5+, la figurine ne perd pas ce PV.',
                          'Each time a model with this


ability loses a wound, roll a D6; on a 5+ the model does


not lose that wound.',
                          'GIV',
                          'AFR5'
                      ),
                      (
                          'Visage horrible',
                          'Horrific visage',
                          'GIN',
                          NULL,
                          'Soustrayez 1 à la caractéristique de Commandement des figurines tant qu''elles sont à 6" d''une ou plusieurs figurines ennemies avec cette aptitude.',
                          'Substract 1 from the leadership characteristic of models whilst they are within 6" of any enemy models with this ability.',
                          NULL,
                          'VIH'
                      ),
                      (
                          'Masque de Gellercauste',
                          'Gellercaust Mask',
                          NULL,
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 5+. Chaque fois que vous effectuez un jet de sauvegarde non modifié de 6 pour cette figurine ) la phase de Combat, et que cette figurine n''est pas secouée, la figurine ennemie qui a effectué l''attaque subit 1 blessure mortelle une fois toutes ses attaques résolues.',
                          'This model has a 5+ invulnerable save. Each time you roll an unmodified saving throw of 6 for this model in the Fight phase, and this model is not shaken, the enemy model that made the attack suffers 1 mortal wound after it has made all of its attacks.',
                          'GIG',
                          'MGE'
                      ),
                      (
                          'Minuscules',
                          'Hatchlings',
                          NULL,
                          NULL,
                          'Ajoutez 1 aux jets de Trauma pour cette figurine. Toutefois, cette figurine ne peut jamais subir de blessures légères (tout résultat blessure légère que subit cette figurine n''a aucun effet).',
                          'Add 1 to lnjury rolls made for this model. However, this model can never suffer flesh wounds (any flesh wound result this model suffers has no effect).',
                          'GIE',
                          'MIN'
                      ),
                      (
                          'Décérébrés',
                          'Mindless',
                          NULL,
                          NULL,
                          'Les Eyestinger Swarms ne peuvent pas être spécialistes ne font pas partie d''une équipe de tir et ne gagnent pas d''expérience.',
                          'Eyestinger Swarms cannot be specialists, are not part of a tire team and cannot gain experience.',
                          'GIE',
                          'DEC'
                      ),
                      (
                          'Essaim Bourdonnant',
                          'Buzzing swarm',
                          NULL,
                          NULL,
                          'Soustrayez 1 aux jets de touche pour les attaques qui ciblent cette figurine. De plus, cette figurine réussit automatiquement les tests de Chute.',
                          'Subtract 1 from hit rolls made for attacks that target this model. In addition, this model
automatically passes Falling tests.',
                          'GIE',
                          'ESB'
                      ),
                      (
                          'Décérébrés',
                          'Mindless',
                          NULL,
                          NULL,
                          'Les Sludge-Grubs ne peuvent pas être spécialistes ne font pas partie d''une équipe de tir et ne gagnent pas d''expérience.',
                          'Sludge-Grubs cannot be specialists, are not part of a tire team and cannot gain experience.',
                          'GIS',
                          'DEC3'
                      ),
                      (
                          'Décérébrés',
                          'Mindless',
                          NULL,
                          NULL,
                          'Les Cursemites ne peuvent pas être spécialistes ne font pas partie d''une équipe de tir et ne gagnent pas d''expérience.',
                          'Cursemite cannot be specialists, are not part of a tire team and cannot gain experience.',
                          'GIC',
                          'DEC2'
                      ),
                      (
                          'Crapoussins',
                          'Squishable',
                          NULL,
                          NULL,
                          'Cette figurine bénéficie de l''aptitude Affreusement Résistant seulement contre les attaques avec une caractéristique de Dégat de 1.',
                          'This model only receives the benefit of its Disgustingly Resilient ability against attacks with a Damage characteristic of 1. ',
                          'GIL',
                          'CRA'
                      ),
                      (
                          'Armes Grippées',
                          'Weapon Glitch',
                          NULL,
                          NULL,
                          'Tant que cette figurine n''est pas secouée, soustrayez 1 aux jets de touche effectués pour les attaques avec des armes de tir qui ciblent cette figurine.',
                          'As long as this model is not shaken, subtract 1 from hit rolls made for attacks with ranged weapons that target this model.',
                          'GIL',
                          'ARG'
                      ),
                      (
                          'Démoniaque',
                          'Daemonic',
                          NULL,
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 5+.',
                          'This model has a 5+ invulnerable save.',
                          'GIL',
                          'DEM'
                      ),
                      (
                          'Vermine',
                          'Vermin',
                          NULL,
                          NULL,
                          'Ajoutez 1 aux jets de Trauma effectués pour cette figurine.',
                          'Add 1 to Injury rolls made for this rnodel.',
                          'GIC',
                          'VER'
                      ),
                      (
                          'Inscetoïdes Bondissants',
                          'Leaping lnsectoids',
                          NULL,
                          NULL,
                          'Vous pouvez relancer les jets de charge ratés pour cette figurine. De plus, chaque fois que cette figurine engage et consolide, elle peut se déplacer de jusqu''à 6".',
                          'You can re-roll failed charge rolls for lhis model. ln addition, whenever this model piles in and consolidates, it can move up to 6".',
                          'GIC',
                          'INB'
                      ),
                      (
                          'Sang caustique',
                          'Caustic Blood',
                          NULL,
                          NULL,
                          'Si cette figurine est mise hors de combat à la phase de Combat,jetez un D6;sur 6, la figurine ennemie qui a effectué l''attaque qui a mis cette figurine hors de combat subit 1 blessure mortelle une fois toutes ses attaques résolues.',
                          'If this rnodel is taken out of action in the Fight phase, roll a D6; on a 6 the enemy model that made the attack that took this model out of action suffers 1 mortal wound after it has made all of its attacks.',
                          'GIS',
                          'SGC'
                      ),
                      (
                          'Vermine',
                          'Vermin',
                          NULL,
                          NULL,
                          'Ajoutez 1 aux jets de Trauma effectués pour cette figurine.',
                          'Add 1 to Injury rolls made for this rnodel.',
                          'GIS',
                          'VER2'
                      ),
                      (
                          'Visage horrible',
                          'Horrific visage',
                          NULL,
                          NULL,
                          'Soustrayez 1 à la caractéristique de Commandement des figurines tant qu''elles sont à 6" d''une ou plusieurs figurines ennemies avec cette aptitude.',
                          'Substract 1 from the leadership characteristic of models whilst they are within 6" of any enemy models with this ability.',
                          'GIV',
                          'VIH2'
                      ),
                      (
                          'Abomination bionique',
                          'Bionic Abomination',
                          NULL,
                          NULL,
                          'Cette figurine a une sauvegarde invulnérable de 6+.',
                          'This model has a 6+ invulnerable save.',
                          'GIV',
                          'ABB'
                      );

					  INSERT OR IGNORE INTO Specialites (
                            NomFr,
                            NomEn,
                            Id
                        )
                        VALUES (
                            'Stratèges',
                            'Strategist',
                            'ST'
                        ),
                        (
                            'Force',
                            'Strength',
                            'F'
                        );


INSERT OR IGNORE INTO DeclinaisonSpecialite (
                                      SpecialiteId,
                                      DeclinaisonId
                                  )
                                  VALUES (
                                      'CB',
                                      'GIV'
                                  ),
                                  (
                                      'D',
                                      'GIV'
                                  ),
                                  (
                                      'F',
                                      'GIV'
                                  ),
                                  (
                                      'V',
                                      'GIV'
                                  ),
                                  (
                                      'Z',
                                      'GIV'
                                  ),
                                  (
                                      'CB',
                                      'GIL'
                                  ),
                                  (
                                      'SC',
                                      'GIL'
                                  ),
                                  (
                                      'Z',
                                      'GIL'
                                  ),
                                  (
                                      'L',
                                      'GIG'
                                  ),
                                  (
                                      'CB',
                                      'GIG'
                                  ),
                                  (
                                      'D',
                                      'GIG'
                                  ),
                                  (
                                      'SC',
                                      'GIG'
                                  ),
                                  (
                                      'V',
                                      'GIG'
                                  ),
                                  (
                                      'Z',
                                      'GIG'
                                  ),
                                  (
                                      'CB',
                                      'GIN2'
                                  ),
                                  (
                                      'V',
                                      'GIN2'
                                  ),
                                  (
                                      'Z',
                                      'GIN2'
                                  ),
                                  (
                                      'L',
                                      'GIN2'
                                  ),
                                  (
                                      'CB',
                                      'GIN1'
                                  ),
                                  (
                                      'V',
                                      'GIN1'
                                  ),
                                  (
                                      'Z',
                                      'GIN1'
                                  ),
                                  (
                                      'CB',
                                      'ESE'
                                  ),
                                  (
                                      'SC',
                                      'ESE'
                                  ),
                                  (
                                      'ST',
                                      'ESE'
                                  ),
                                  (
                                      'V',
                                      'ESE'
                                  ),
                                  (
                                      'Z',
                                      'ESE'
                                  ),
                                  (
                                      'M',
                                      'ESS'
                                  ),
                                  (
                                      'CO',
                                      'ESL'
                                  ),
                                  (
                                      'CB',
                                      'ESK'
                                  ),
                                  (
                                      'SC',
                                      'ESV4'
                                  ),
                                  (
                                      'D',
                                      'ESV4'
                                  ),
                                  (
                                      'V',
                                      'ESV4'
                                  ),
                                  (
                                      'L',
                                      'ESV3'
                                  ),
                                  (
                                      'D',
                                      'ESV3'
                                  ),
                                  (
                                      'V',
                                      'ESV3'
                                  ),
                                  (
                                      'AL',
                                      'ESV2'
                                  ),
                                  (
                                      'D',
                                      'ESV2'
                                  ),
                                  (
                                      'V',
                                      'ESV2'
                                  ),
                                  (
                                      'D',
                                      'ESV1'
                                  ),
                                  (
                                      'V',
                                      'ESV1'
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
                      'Canon rotatif',
                      'Rotor cannon',
                      NULL,
                      NULL,
                      'CARO'
                  ),
                  (
                      0,
                      'Fusil à pompe d''artificer',
                      'Artificier shotgun',
                      NULL,
                      NULL,
                      'FPAR'
                  ),
                  (
                      0,
                      'Fusil laser',
                      'Lasgun',
                      NULL,
                      NULL,
                      'FULA'
                  ),
                  (
                      0,
                      'Grenade à surpression',
                      'Concussion grenade',
                      NULL,
                      NULL,
                      'GSP'
                  ),
                  (
                      0,
                      'Masque à aiguilles',
                      'Dartmask',
                      NULL,
                      NULL,
                      'MAG'
                  ),
                  (
                      0,
                      'Pistolet familial',
                      'Hierloom',
                      NULL,
                      NULL,
                      'PFA'
                  ),
                  (
                      0,
                      'Pistoler voltaïque',
                      'Voltaic pistol',
                      NULL,
                      NULL,
                      'PVO'
                  ),
                  (
                      0,
                      'Canne-rapière monomoléculaire',
                      'Monomolecular cane-rapier',
                      NULL,
                      NULL,
                      'CRMO'
                  ),
                  (
                      0,
                      'Griffe scalpel',
                      'Scalpel claw',
                      NULL,
                      NULL,
                      'GSC'
                  ),
                  (
                      0,
                      'Lame énergétique du Death Cult',
                      'Death cult ower blade',
                      NULL,
                      NULL,
                      'LEDC'
                  ),
                  (
                      0,
                      'Morsure cruelle',
                      'Vicious bite',
                      NULL,
                      NULL,
                      'MCU'
                  ),
                  (
                      0,
                      'Barbillon reproducteur',
                      'Spawning barb',
                      NULL,
                      NULL,
                      'BRE'
                  ),
                  (
                      0,
                      'Griffe tailladeuses',
                      'Flesh ripper claws',
                      NULL,
                      NULL,
                      'GTAI'
                  ),
                  (
                      0,
                      'Griffes et dents infectés',
                      'Diseased claws and fangs',
                      NULL,
                      NULL,
                      'GDI'
                  ),
                  (
                      0,
                      'Gueule garnie de crocs et dard',
                      'Fanged maw and stinger',
                      NULL,
                      NULL,
                      'GGCD'
                  ),
                  (
                      0,
                      'Hachoir de la peste',
                      'Plague cleaver',
                      NULL,
                      NULL,
                      'HAPE'
                  ),
                  (
                      0,
                      'Hideuses mutations',
                      'Hideous mutations',
                      NULL,
                      NULL,
                      'HMU'
                  ),
                  (
                      0,
                      'Membres mutés et armes improvisées',
                      'Mutated limbs and improvised weapons',
                      NULL,
                      NULL,
                      'MMAI'
                  ),
                  (
                      0,
                      'Proboscis suceur de sang',
                      'Bloodsucking proboscis',
                      NULL,
                      NULL,
                      'PROB'
                  ),
                  (
                      0,
                      'Crachat acide',
                      'Acid spit',
                      NULL,
                      NULL,
                      'CRAA'
                  ),
                  (
                      0,
                      'Lance-flammes ventral',
                      'Belly-flamer',
                      NULL,
                      NULL,
                      'LFV'
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
                             'L',
                             24,
-                            1,
                             'Canon rotatif',
                             'Rotor cannon',
                             4,
                             4,
                             2,
                             'CARO',
                             NULL,
                             NULL,
                             'CARO'
                         ),
                         (
                             'A',
                             12,
                             0,
                             'Fusil à pompe d''artificer',
                             'Artificier shotgun',
                             2,
                             4,
                             2,
                             'FPAR',
                             'Ajoutez 1 à la Force de cette arme si la cible est à la moitié de la portée ou moins.',
                             'If the target is within half range, add 1 to this weapon’s 
Strength.',
                             'FPAR'
                         ),
                         (
                             'R',
                             24,
                             0,
                             'Fusil laser',
                             'Lasgun',
                             1,
                             3,
                             1,
                             'FULA',
                             NULL,
                             NULL,
                             'FULA'
                         ),
                         (
                             'G',
                             6,
                             0,
                             'Grenade à surpression',
                             'Concussion grenade',
                             'D3',
                             3,
                             1,
                             'GSP',
                             'Si la cible est à 1" d''un élement de terrain, ajoutez 1 aux caractéristiques de Force et de Dégâts de cette arme.',
                             'If the target is within 1" of a terrain feature, add 1 to this weapon''s Strength and Damage characteristics. ',
                             'GSP'
                         ),
                         (
                             'P',
                             9,
-                            1,
                             'Masque à aiguilles',
                             'Dartmask',
                             1,
                             1,
                             1,
                             'MAG',
                             'Cette arme blesse sur 2+.',
                             'This weapon wounds on a 2+.',
                             'MAG'
                         ),
                         (
                             'P',
                             12,
-                            2,
                             'Pistolet familial',
                             'Hierloom',
                             1,
                             4,
                             2,
                             'PFA',
                             NULL,
                             NULL,
                             'PFA'
                         ),
                         (
                             'P',
                             12,
                             0,
                             'Pistoler voltaïque',
                             'Voltaic pistol',
                             1,
                             5,
                             1,
                             'PVO',
                             'Chaque jet de touche non modifié de 6 obtenu pour cette arme inflige 3 touches à la cible au lieu d''une seule.',
                             'Each unmodified hit roll of 6 made for this weapon inflicts 3 hits on the target, instead of 1.',
                             'PVO'
                         ),
                         (
                             'M',
                             'M',
-                            4,
                             'Canne-rapière monomoléculaire',
                             'Monomolecular cane-rapier',
                             0,
                             'U',
                             1,
                             'CRMO',
                             NULL,
                             NULL,
                             'CRMO'
                         ),
                         (
                             'M',
                             'M',
-                            1,
                             'Griffe scalpel',
                             'Scalpel claw',
                             0,
                             'U',
                             1,
                             'GSC',
                             NULL,
                             NULL,
                             'GSC'
                         ),
                         (
                             'M',
                             'M',
-                            2,
                             'Lame énergétique du Death Cult',
                             'Death cult ower blade',
                             0,
                             'U',
                             1,
                             'LEDC',
                             NULL,
                             NULL,
                             'LEDC'
                         ),
                         (
                             'M',
                             'M',
                             0,
                             'Morsure cruelle',
                             'Vicious bite',
                             0,
                             'U',
                             1,
                             'MCU',
                             NULL,
                             NULL,
                             'MCU'
                         ),
                         (
                             'M',
                             'M',
                             0,
                             'Barbillon reproducteur',
                             'Spawning barb',
                             0,
                             'U',
                             1,
                             'BRE',
                             'Chaque jet de touche de 6+ pour cette arme inflige automatiquement une blessure (n''effectuez pas de jet de blessure pour cette attaque).',
                             'Each hit roll of 6+ made for this weapon automatically results in a wound (do not make a wound roll for that attack).',
                             'BRE'
                         ),
                         (
                             'M',
                             'M',
-                            2,
                             'Griffe tailladeuses',
                             'Flesh ripper claws',
                             0,
                             '+1',
                             2,
                             'GTAI',
                             NULL,
                             NULL,
                             'GTAI'
                         ),
                         (
                             'M',
                             'M',
                             0,
                             'Griffes et dents infectés',
                             'Diseased claws and fangs',
                             0,
                             'U',
                             1,
                             'GDI',
                             'Relancez les jets de blessure de 1 pour cette arme.',
                             'You can re-roll failed wound rolls for this weapon.',
                             'GDI'
                         ),
                         (
                             'M',
                             'M',
-                            1,
                             'Gueule garnie de crocs et dard',
                             'Fanged maw and stinger',
                             0,
                             'U',
                             1,
                             'GGCD',
                             NULL,
                             NULL,
                             'GGCD'
                         ),
                         (
                             'M',
                             'M',
-                            2,
                             'Hachoir de la peste',
                             'Plague cleaver',
                             0,
                             'U',
                             2,
                             'HAPE',
                             'Relancez les jets de blessure de 1 pour cette arme.',
                             'You can re-roll failed wound rolls for this weapon.',
                             'HAPE'
                         ),
                         (
                             'M',
                             'M',
-                            2,
                             'Hideuses mutations',
                             'Hideous mutations',
                             0,
                             'U',
                             2,
                             'HMU',
                             NULL,
                             NULL,
                             'HMU'
                         ),
                         (
                             'M',
                             'M',
-                            1,
                             'Membres mutés et armes improvisées',
                             'Mutated limbs and improvised weapons',
                             0,
                             'U',
                             1,
                             'MMAI',
                             NULL,
                             NULL,
                             'MMAI'
                         ),
                         (
                             'M',
                             'M',
                             0,
                             'Proboscis suceur de sang',
                             'Bloodsucking proboscis',
                             0,
                             'U',
                             1,
                             'PROB',
                             'Chaque jet de touche non modifié de 6 pour cette arme provoque 2 touches.',
                             'Each unmodified hit roll of 6 made with this weapon scores 2 hits.',
                             'PROB'
                         ),
                         (
                             'P',
                             8,
-                            1,
                             'Crachat acide',
                             'Acid spit',
                             1,
                             'U',
                             1,
                             'CRAA',
                             NULL,
                             NULL,
                             'CRAA'
                         ),
                         (
                             'A',
                             8,
                             0,
                             'Lance-flammes ventral',
                             'Belly-flamer',
                             'D6',
                             4,
                             1,
                             'LFV',
                             'Cette arme touche automatiquement sa cible',
                             'This weapon automatically hits its target.',
                             'LFV'
                         );

INSERT OR IGNORE INTO DeclinaisonArme (
                                ArmeId,
                                DeclinaisonId
                            )
                            VALUES (
                                'FULA',
                                'ESV1'
                            ),
                            (
                                'PLS',
                                'ESV1'
                            ),
                            (
                                'GSP',
                                'ESV1'
                            ),
                            (
                                'GSP',
                                'ESV2'
                            ),
                            (
                                'PLS',
                                'ESV2'
                            ),
                            (
                                'CARO',
                                'ESV2'
                            ),
                            (
                                'GSP',
                                'ESV3'
                            ),
                            (
                                'PLS',
                                'ESV3'
                            ),
                            (
                                'FPAR',
                                'ESV3'
                            ),
                            (
                                'GSP',
                                'ESK'
                            ),
                            (
                                'MAG',
                                'ESK'
                            ),
                            (
                                'LEDC',
                                'ESK'
                            ),
                            (
                                'GSP',
                                'ESL'
                            ),
                            (
                                'PVO',
                                'ESL'
                            ),
                            (
                                'GSP',
                                'ESS'
                            ),
                            (
                                'PLS',
                                'ESS'
                            ),
                            (
                                'GSC',
                                'ESS'
                            ),
                            (
                                'GSP',
                                'ESE'
                            ),
                            (
                                'CRMO',
                                'ESE'
                            ),
                            (
                                'PFA',
                                'ESE'
                            ),
                            (
                                'HAPE',
                                'GIN2'
                            ),
                            (
                                'HMU',
                                'GIN2'
                            ),
                            (
                                'HMU',
                                'GIN1'
                            ),
                            (
                                'GF',
                                'GIG'
                            ),
                            (
                                'MMAI',
                                'GIG'
                            ),
                            (
                                'BRE',
                                'GIE'
                            ),
                            (
                                'GDI',
                                'GIL'
                            ),
                            (
                                'PROB',
                                'GIC'
                            ),
                            (
                                'CRAA',
                                'GIS'
                            ),
                            (
                                'GGCD',
                                'GIS'
                            ),
                            (
                                'LFV',
                                'GIV'
                            ),
                            (
                                'GTAI',
                                'GIV'
                            );
							
update Armes set NomEn = 'Laspistol' where Id = 'PLS';
update ProfileArmes set NomEn = 'Laspistol' where Id = 'PLS';

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;