DELETE FROM Tactiques
      WHERE Id IN ('DW10', 'DW9', 'DW8', 'DW7', 'DW6', 'DW5', 'AA12', 'AA11', 'AA10', 'AA9', 'AA8', 'AA7', 'AM10', 'AM9', 'AM8', 'AM7', 'AM6', 'AM5', 'ME9', 'ME8', 'ME7', 'ME6', 'ME5', 'DR5', 'DR6', 'DR7', 'DR8', 'DR9', 'DR10', 'OR7', 'OR8', 'OR9', 'OR10', 'OR11', 'OR12', 'TY7', 'TY8', 'TY9', 'TY10', 'TY11', 'TY12', 'GC7', 'GC8', 'GC9', 'GC10', 'GC11', 'GC12');


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
                          NULL,
                          1,
                          'Le mépris est mon armure',
                          'My Armour is Contempt',
                          0,
                          'DW',
                          'Utilisez cette Tactique lorsqu''une frgurine
de votre kill team subit une blessure
mortelle. )etez un D6 pour cette blessure
mortelle, et toute autre blessure mortelle
infligée à cette figurine pour le reste de
cette phase; sur 5+ cette blessure mortelle
est ignorée et est sans effet.',
                          'Use when a model from your kill team suffers a mortal wound. Roll a D6 for that mortal wound, and each other mortal
wound inflicted on this model for the rest of the phase, on a 5+ that mortal wound is ignored and has no effect.',
                          'DW10'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Implacable',
                          'Unrelenting',
                          0,
                          'DW',
                          'Utilisez cette Tactique lors de la phase
de Tir lorsque vous choisissez une figurine
de votre kill team pour tirer. Lorsque vous
efectuez les jets de touche pour les attaques
de tir de cette figurine, elle est considérée
comme ne s''étant pas déplacée lors de
la phase de Mouvement précédente.',
                          'Use in the Shooting phase when you chose a model from your kill team to shoot . When rolling to hit for this model’s
shooting attacks, it is considered not to have moved in the previous Movement phase.',
                          'DW9'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'Le couperet',
                          'The Beheading',
                          0,
                          'DW',
                          'Utilisez cette Tactique au début de la
phase de Combat. Jusquà la fin de la
phase, vous pouvez relancer les jets
de touche pour toutes les attaques
qui ciblent un Leader ennemi.',
                          'Use at the start of the Fight phase . Until the end of the phase, you may re-roll hit rolls for any attacks that target an
enemy Leader.',
                          'DW8'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Désengagement tactique',
                          'Tactical Disengagement',
                          0,
                          'DW',
                          'Utilisez cette Tactique lors de la phase de
Mouvement, lorsqu''une figurine de votre
kill team se Replie. Cette âgurine peut
se Replier jusquà 6" au lieu de jusquà 3",
et peut tirer avec ses armes lors de la phase
de Tir de ce round de Bataille même si
elle sèst Repliée.',
                          'Use ln the Movement phase when a model in your kill team Retreats . That model may Retreat up to 6'' rather than up
to 3'', and may fire its weapons on the Shooting phase of this battle round even though it Retreated.',
                          'DW7'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Mort au Xenos!',
                          'Death to the Alien!',
                          0,
                          'DW',
                          'Utilisez cette Tactique lorsque vous
choisissez une frgurine de votre kill team
pour la faire combattre lors de la phase de
Combat. Chaque fois que vous obtenez un
jet de touche de 5+ pour cette figurine iors
de cette phase, elle peut, si elle ciblait une
figurine qui nà pas Ie mot-clé Ituprnrurvr,
Cruos ou Nou Ar,rcxÉ, immédiatement
efectuer une attaque supplémentaire contre
cette même figurine en utilisant la même arme.
Ces attaques supplémentaires ne peuvent pas
en générer d''autres par la suite.',
                          'Use when you chose a model in your kill team to fight in the fight phase . Each time you make a hit roll of 5+ for that
model during this phase, that model can, if it was targeting a model that does Not have the Imperium , Chaos or
Unaligned keyword, immediately make an additional attack against the same model using the same weapon . These
extra attacks cannot themselves generate any further attacks.',
                          'DW6'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Exécution prioritaire',
                          'Priority Execution',
                          0,
                          'DW',
                          'Utilisez cette Tactique lorsque vous
choisissez une frgurine de votre kill team
pour la faire combattre lors de la phase de
Combat. Ajoutez 1 à tous les jets de blessure
de cette figurine jusqu''à la frn de la phase.',
                          'Use when you chose a model In your kill team to fight in the fight phase . Add 1 to all wound rolls for that model until
the end of the phase.',
                          'DW5'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Guerre psychologique',
                          'Psychological Warfare',
                          0,
                          'AA',
                          'Utilisez cette tactique au début de la phase de moral. Choisissez un Reiver de votre kill team qui n''est pas secoué et qui a mis une figurine ennemie hors de combat à la phase de combat précédente. Ajoutez 1 aux tests de sang-froid faits à cette phase pour les figurines ennemies à 6" de la figurine choisie.',
                          'Use at the start of the Morale phase . Choose a REAVER from your kill team that took an enemy model out of action
in the preceding Fight phase and is not shaken. Add 1 to any Nerve tests made this phase for enemy models within 6"
of the model you chose.',
                          'AA12'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'Scan d''Auspex',
                          'Auspex Scan',
                          0,
                          'AA',
                          'Utilisez cette tactique lorsque vous choisissez une figurine Préparée pour tirer. Ignorez tous les modificateurs négatifs au jet de touche de cette figurine à cette phase.',
                          'Use when you choose a Readied model to shoot with. Ignore all negative hit modifiers for that model this phase.',
                          'AA11'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Ange de la mort',
                          'Angel of Death',
                          0,
                          'AA',
                          'Utilisez cette tactique après avoir choisi une figurine ayant chargé à ce round de bataille pour combattre. Ajoutez 1 à la caractéristique d''Attaques de cette figurine à cette phase.',
                          'Use after choosing a model that charged in this battle round to fight with. Add 1 to that model’s Attack characteristic
for this phase.',
                          'AA10'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Stratégie adaptive',
                          'Adaptive Strategy',
                          0,
                          'AA',
                          'utilisez cette tactique dès que votre kill team est démoralisée. Vous générez immédiatement D3 points de commandements.',
                          'Use as soon as your kill team is broken . You immediately generate D3 Command Points.',
                          'AA9'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'Refus de mourir',
                          'Death Denied',
                          0,
                          'AA',
                          'Utilisez cette tactique quand une de vos figurines est mise hors de combat. Cette figurine subit une blessure légère à la place.',
                          'Use when one of your models is taken out of action . That model suffers a flesh wound instead.',
                          'AA8'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Frères de bataille',
                          'Battle-Brothers',
                          0,
                          'AA',
                          'Utilisez cette tactique après avoir raté un jet de sauvegarde pour une figurine amie à 3" d''une figurine amie qui est secouée. La figurine ciblée ne subit aucun dégât, mais une figurine amie de votre choix à 3" de la figurine ciblée et qui n''est pas secouée subit un nombre de blessures mortelles égal à la caractéristique de Dégâts de l''arme utilisée pour l''attaque.',
                          'Use after failing a saving throw for a model that is within 3” of another friendly model that is not shaken. No
damage is inflicted upon the target model but one friendly model of your choice that is within 3” of the target model and
not shaken suffers a number of mortal wounds equal to the Damage characteristic of the weapon used in the attack.',
                          'AA7'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Grenadiers',
                          'Grenadiers',
                          0,
                          'AM',
                          'Utilisez cette tactique lorsque vous choisissez une figurine de votre kil lteam pour la faire tirer à la phase de tir. Vous pouvez utiliser une arme de type Grenade dont la figurine est équipée, même si une autre figurine de votre kill team a déjà utilisé une Grenade à cette phase. Vous pouvez utiliser cette tactique plusieurs fois pendant une même phase.',
                          'Use when you choose a model from your kill team to shoot in the Shooting phase . You can use a Grenade weapon
that model is equipped with, even if another model from your kill team has already used a Grenade weapon this phase.
You can use this Tactic multiple times in the same phase.',
                          'AM10'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Piqure d''adrénaline',
                          'Adrenal Shot',
                          0,
                          'AM',
                          'Utilisez cette tactique lorsqu''une figurine de votre kill team subit une blessure mortelle. Jetez un D6 pour cette blessure mortelle, et pour tout autre blessure mortelle subie par cette figurine jusqu''à la fin de la phase; sur 5+, la blessure mortelle est ignorée et n''a aucun effet.',
                          'Use when a model from your kill team suffers a mortal wound . Roll a D6 for that mortal wound, and any other mortal
wound suffered by that model for the rest of the phase; on a 5+ the mortal wound is ignored and has no effect.',
                          'AM9'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Battez vous jusqu''à la mort',
                          'Fight to the Death! ',
                          0,
                          'AM',
                          'Utilisez cette tactique avant d''effectuer un jet de Trauma pour une figurine de votre kill team. Appliquez un modificateur de -1 au jet de trauma.',
                          'Use before an Injury roll is made for a model from your kill team. Apply a -1 modifier to the Injury roll.',
                          'AM8'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Vengeance pour Cadia!',
                          'Vengeance For Cadia!',
                          0,
                          'AM',
                          'Utilisez cette tactique lorsque vous choisissez une figurine de votre kill team pour la faire tirer, y compris en état d''alerte, si la cible est une figurine Heretic Astartes. Vous pouvez relancer les jets de touche et de blessures ratés pour votre figurine contre la figurine Heretic Astartes',
                          'Use when you choose a model from your kill team to shoot or fire Overwatch and the target is a HERETIC
ASTARTES model. You can re-roll failed hit and wound rolls for your model against that HERETIC ASTARTES model.',
                          'AM7'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Protocoles de reconnaissance',
                          'Reconnaissance Protocols',
                          0,
                          'AM',
                          'Utilisez cette tactique au début du premier round de bataille. Choisissez une figurine Militarium Tempestus de votre kill team qui est sur le champ de bataille; cette figurine peut immédiatement effectuer un mouvement normal comme s''il s''agissait de la phase de mouvement, mais au lieu de se déplacer de sa caractéristique de Mouvement, elle se déplace jusqu''à 2D6".',
                          'Use at the start of the first battle round . Choose a MILITARUM TEMPESTUS model from your kill team that is on the
battlefield; that model can immediately make a normal move as if it were the Movement phase, but instead of moving up
to their Move characteristic they move up to 2D6" instead.',
                          'AM6'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'Chef, oui chef!',
                          'Sir, Yes Sir!',
                          0,
                          'AM',
                          'Utilisez cette tactique après avoir choisi une figurine de votre kill team comme cible d''un ordre. Toutes les figurines de votre kill team (autres que le leader) à 3" de la figurine choisie sont également affectés par le même ordre. Vous ne pouvez pas utiliser cette tactique et la tactique stratégie rusée au même round de bataille.',
                          'Use after picking a model from your kill team to be affected by an order . All models from your kill team ( other than
your kill team''s Leader) within 3" of that model are also affected by the same order. You cannot use this Tactic in the
same battle round as the Cunning Strategy Tactic.',
                          'AM5'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Harmonisation transsonique',
                          'TRANSONIC ATTUNEMENT',
                          0,
                          'ME',
                          'Utilisez cette tactique à la phase de combat, lorsqu''une figurine de votre kill team équipée de lames transsoniques, d''un couperet transsonique ou d''une griffe-discord attaque. Jusqu''à la fin de la phase, ajoutez 1 aux jets de blessure de la figurine lorsqu''lle attaque avec une de ces armes. ',
                          'Use in the Fight Phase when a model from your kill team armed with Transonic blades , a Transonic razor or a
Chordclaw is chosen to attack . Until the end of phase, add 1 to wound rolls for attacks made by that model with any of
these weapons.',
                          'ME9'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Actuators stabilisateurs',
                          'STABILISATION ACTUATORS',
                          0,
                          'ME',
                          'Utilisez cette tactique avant d''effectuer un test de Chute pour une figurine de votre kill team. Vous pouvez relancer le dé lors de ce test, et pour les test de chute ultérieurs de cette figurine jusqu''à la fin du round de bataille.',
                          'Use before you take a Falling test for a model from your kill team. You can re-roll the dice when taking this test and
when taking any further Falling tests for that model in this battle round.',
                          'ME8'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Logiciel de ciblage',
                          'AUTO-TRACKING SOFTWARE',
                          0,
                          'ME',
                          'Utilisez cette tactique à la phase de mouvement, lorsqu''un adversaire déclare une charge contre une figurine de votre kill team. Quand cette figurine tire en Etat d''alerte à cette phase, elle touche sur 5 ou 6.',
                          'Use in the Movement phase when an opponent declares a charge against a model from your kill team. When that
model fires Overwatch this phase they successfully hit on a roll of 5 or 6.',
                          'ME7'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Conditions optimales',
                          'OPTIMAL CONDITIONS',
                          0,
                          'ME',
                          'Utilisez cette tactique au début de la phase de mouvement. AJoutez 1 aux jets de charge effectués par les figurines de votre kill team jusqu''à la fin de la phase.',
                          'Use at the start of the Movement phase . Add 1 to charge rolls made for models in your kill team until end of the
phase.',
                          'ME6'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Crâne augure',
                          'SCRYER-SKULL',
                          0,
                          'ME',
                          'Utilisez cette tactique au début de la phase de mouvement, si un adversaire a choisi la stratégie Poser des Pièges lors de la phase de reconnaissance. Choisissez un élement de terrain à 6" ou moins de votre leader. L''adversaire doit vous révéler s''il a piégé cet élement de terrain.',
                          'Use at the start of the Movement phase if an opponent picked the Plant Traps strategy in the Scouting phase .
Pick a piece of terrain within 6” of your Leader . Your opponents must reveal to you whether or not they have
booby-trapped that piece of terrain.',
                          'ME5'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Grâce ensanglantée',
                          'BLOODIES GRACE',
                          0,
                          'DR',
                          'utilisez cette tactique quand une Wytch de votre kill team doit consolider après un combat à la phase de combat. Vous pouvez déplacer la figurine jusqu''à 6" au lieu de jusqu''à 3".',
                          'Use when a WYCH from your kill team would consolidate as part of fighting in the Fight phase. You may move them up
to 6" instead of up to 3".',
                          'DR5'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Chasse depuis les ombres',
                          'HUNT FROM THE SHADOWS',
                          0,
                          'DR',
                          'Utilisez cette tactique quand une figurine de votre kill team qui est masquée est ciblée par une attaque ennemie en phase de tir. Jusuqu''à la fin de la phase, ajoutez 1 aux jets de sauvegarde de cette figurine.',
                          'Use when a model from your kill team is chosen as the target of an enemy attack in the Shooting phase and it is
obscured. Until the end of the phase, add 1 to that model''s saving throws.',
                          'DR6'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Architecte de la douleur',
                          'ARCHITECT OF PAIN',
                          0,
                          'DR',
                          'Utilisez cette tactique au début du round de bataille. Choisissez une figurine de votre kill team ayant l''aptitude la puissance par la souffrance. Jusqu''à la fin du round, cette figurine traire le round actuel comme étant supérieur de 1 à ce qu''il est pour déterminer les bonus qu''elle gagne grâce au tableau La Puissance Par La Souffrance.',
                          'Use at the start of the battle round. Choose a model from your kill team that has the Power From Pain ability. Until the
end of the battle round, that model treats the current battle round as being 1 higher than it actually is when determining
what bonuses it gains from the Power From Pain table.',
                          'DR7'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Réactions foudroyantes',
                          'LIGHTNING-FAST REACTIONS',
                          0,
                          'DR',
                          'Utilisez cette tactique quand une figurine de votre kill team est ciblée par une attaque ennemie en phase de tir ou de combat. Vos adversaires doivent soustraire 1 aux jets de touche effectués contre cette figurine pour le reste de la phase.',
                          'Use when a model from your kill team is chosen as the target of an enemy attack in the Shooting or Fight phase. Your
opponent(s) must subtract 1 from hit rolls that target this model for the rest of the phase.',
                          'DR8'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Hyperstimulants',
                          'HYPERSTIMM',
                          0,
                          'DR',
                          'Utilisez cette tactique au début du round de bataille. Choisissez une figurine de votre kill team ayant l''aptitude drogues de combat. Jusuqu''à la fin du round, le bonus que cette figurine reçoit grâce à ses drogues de combat est doublé. A la fin du round de bataille, jetez un D6. Si le jet donne un 1, la figurine subit une blessure mortelle.',
                          'Use at the start of the battle round. Choose a model from your kill team that has the Combat Drugs ability. Until the end
of the battle round, the bonus that model receives from its Combat Drugs is doubled. At the end of the battle round, roll a
D6. If you roll a 1, the model suffers a mortal wound.',
                          'DR9'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'Rivalité meurtrière',
                          'MURDEROUS RIVALRY',
                          0,
                          'DR',
                          'Utilisez cette tactique au début de la section Marteau de Fureur de la phase de combat. La première fois que c''est à vous de choisir une figurine qui a chargé avec laquelle combattre, vous pouvez à la place choisir deux figurines de votre kill team qui ont fini leur mouvement de charge à 4" l''une de l''autre. Vous pouvez résoudre les attaques de ces figurines avant que tout autre joueur choisisse une figurine avec laquelle combattre.',
                          'Use at the start of the Hammer of Wrath section of the Fight phase. The: first time it is your turn to choose a model that
charged to fight with, you may Instead choose two models from your kill team that ended their charge moves within 4" of
each other. You may resolve both models'' attacks before any other player chooses a model to fight with.',
                          'DR10'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Grav'' solide',
                          'DEAD ‘ARD',
                          0,
                          'OR',
                          'Utilisez cette Tactique quand une figurine de
votre ki1l team subit une blessure mortelle.
|etez un D6 pour cette blessure mortelle,
et pour toute autre blessure mortelle subie
par cette figurine jusquà la fin de 1a phase;
sur 5+, la blessure mortelle est ignorée
et n''a aucun effet',
                          'Use when a model from your kill team suffers a mortal wound. Roll a D6 for that mortal wound, and each other mortal
wound suffered by that model for the rest of the phase : on a 5+ the mortal wound is ignored and has no effect.',
                          'OR7'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'On y va, on y va!',
                          '‘ERE WE GO, ‘ERE WE GO!',
                          0,
                          'OR',
                          'Utilisez cette Tactique après avoir efectué un jet de charge pour une de vos figurines.
Relancez un des dés.',
                          'Use after making a charge roll for one of your models. Re-roll one of the dice.',
                          'OR8'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Pyromane',
                          'PYROMANIAK',
                          0,
                          'OR',
                          'Utilisez cette Tactique lorsque vous
choisissez de faire tirer une figurine au
krameur. Le krameur effectue D6 attaques
à cette phase au lieu de D3 attaques.',
                          'Use when you chose a model to shoot with a burner. The burner makes D6 attacks instead of D3 this phase.',
                          'OR9'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Dakka sans discrimination',
                          'INDISCRIMINATE DAKKA',
                          0,
                          'OR',
                          'Utilisez cette tactique après avoir tiré en Etat d''alerte avec une de vos figurines. Vous pouvez immédiatement tirer de nouveau en état d''alerte.',
                          'Use after firing Overwatch with one of your models. You can immediately fire Overwatch again .',
                          'OR10'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'Waaagh!',
                          'WAAAGH!',
                          0,
                          'OR',
                          'Utilisez cette tactique lorsque c''est votre tour de vous déplacer à la phase de mouvement, et que votre leader est sur le champ de bataille sans être secoué. Jusqu''à la fin de cette phase, ajoutez 1" à la caractéristique de mouvement de toutes les figurines de votre kill team, et ajoutez 1 à tous leurs jets d''Avance et de charge.',
                          'Use when it is your turn to move in the Movement phase and your Leader is on the Battlefield and not shaken. For
the duration of that phase, add 1” to the Move characteristics of all models in your kill team, and add 1 to their Advance
and Charge rolls.',
                          'OR11'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'Ca l''démange de s''battre!',
                          'ITCHIN’ FOR A FIGHT!',
                          0,
                          'OR',
                          'Utilisez cette tactique lorsque vous choisissez une figurine de votre kill team pour la faire combattre à la phase de combat. Vous pouvez effectuer une attaque supplémentaire avec cette figurine pour chaque figurine ennemie à 1" ou moins d''elle.',
                          'Use when you choose a model in your kill team to fight in the fight phase . You can make one additional attack with
that model for each enemy model within 1” of it.',
                          'OR12'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Bon de prédateur',
                          'PREDATORY LEAP',
                          0,
                          'TY',
                          'Utiliser cette tactique avant d''effectuer un jet de charge pour une figurine de votre kill team. Traitez cette figurine comme si elle avait le mot-clé VOL lorsque vous résolvez son mouvement de charge.',
                          'Use before making a charge roll for a model from your kill team. Treat that model as if it could FLY when making its
charge move.',
                          'TY7'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Hérotage d''Ymgarl',
                          'LEGACY OF YMGARL',
                          0,
                          'TY',
                          'Utilisez cette tactique lorsque vous choisissez un Genestealer de votre kill team pour combattre à la phase de Combat. Relancez les jets de blessure pour cette figurine jusqu''à la fin de la phase.',
                          'Use when you choose a GENESTEALER in your kill team to fight in the Fight phase . Re-roll failed wound rolls for
that model until the end of the phase.',
                          'TY8'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Annihilation aveugle',
                          'SINGLE-MINDED ANNIHILATION',
                          0,
                          'TY',
                          'Utilisez cette tactique après qu''une figurine de votre kil lteam a tiré à la phase de tir. Vous pouvez aussitôt tirer une fois de plus avec cette figurine. Cette tactique coûte 1 Point de Commandement à utiliser, ou 2 points de commandement si elle est utilisée sur un Tyranid Warrior.',
                          'Use after a model from your kill team shoots in the Shooting phase . You can immediately shoot an additional time
with that model. This Tactic costs 1 Command Point to use, or 2 Command Points if used on a TYRANID WARRIOR .',
                          'TY9'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'Implant d''attaque',
                          'IMPLANT ATTACK',
                          0,
                          'TY',
                          'Utiliser cette tactique avant d''effectuer un jet de Trauma pour une figurine ennemie réduite à 0PV par une figurine de votre killl team à la phase de combat. Appliquez un modificateur de +2 au jet de trauma.',
                          'Use before an Injury roll is made for an enemy model that was reduced to 0 wounds by a model from your Kill Team
in the Fight phase . Apply a + 2 modifier to the Injury roll.',
                          'TY10'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'Régénération rapide',
                          'RAPID REGENERATION',
                          0,
                          'TY',
                          'Utilisez cette tactique lorsqu''une figurine de votre kill team est mise hors de combat. Jetez un D6, sur 4+ cette figurine est traitée à la place comme ayant subi une blessure légère.',
                          'Use when a model from your kill team is taken out of action . Roll a D6 . On a 4+ that model is treated as if it had
suffered a flesh wound instead .',
                          'TY11'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'Poussée d''adrénaline',
                          'ADRENALINE SURGE',
                          0,
                          'TY',
                          'Utilisez cette tactique à la fin de la phase de Combat. Choisissez une figurine de votre kill team. Cette figurine peut immédiatement combattre une fois supplémentaire.',
                          'Use at the end of the Fight phase . Pick a model from your kill team. That model can immediately fight an additional
time.',
                          'TY12'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Regard hypnotisant',
                          'MESMERISING BAZE',
                          0,
                          'GC',
                          'Utilisez cette tactique au début de la phase de combat. Choisissez une figurine ennemie à 1" d''une figurine de vore kill team et jet un dé. Sur 4+, soustrayez 1 à la caractéristique d''Attaques de cette figurine (jusqu''à un minimum de 1) jusqu''à la fin de la phase.',
                          'Use at the beginning of the Fight phase . Pick an enemy model within 1” of a model from your kill team and roll a
dice. On a 4+ subtract 1 from that model’s Attack characteristic (to a minimum of 1) until the end of phase.',
                          'GC7'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Crachat Acide',
                          'ACIDIC SPIT',
                          0,
                          'GC',
                          'Utilisez cette tactique au début de la phase de tir. Choisissez une figurine ennemie à 1" ou moins d''une figurine de votre kill team et jetez un dé. Sur 5+, cette figurine ennemie subit 1 blessure mortelle.',
                          'Use at the beginning of the Shooting phase. Pick an enemy model within 1” of a model from your kill team and roll a
dice. On a 5+ that enemy model suffers 1 mortal wound.',
                          'GC8'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Glande à toxines',
                          'TOXIN GLAND',
                          0,
                          'GC',
                          'Utilisez cette tactique lorsque vous choisissez un Hybrid Metamorph de votre kill team pour se battre durant la phase de combat. Ajoutez 1 aux jets de blessure pour la serre perforante ou griffe métamorphe de cette figurine jusqu''à la fin de la phase.',
                          'Use when you pick a HYBRID METAMORPH from your kill team to fight in the Fight phase . Add 1 to wound rolls for
that model’s rending claw or metamorph talon until the end of phase.',
                          'GC9'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Brandissez l''icone',
                          'RAISE THE ICON',
                          0,
                          'GC',
                          'utilisez cette tactique au début de la phase de combat. Choisissez une figurine de votre kill team équipée d''une icone du culte. Augmentez à 12" la portée de l''aptitude Icone du culte de cette figurine jusqu''à la fin de la phase.',
                          'Use at the start of the Fight phase . Pick a model from your kill team equipped with a cult icon . Increase the range of
that models Cult Icon ability to 12” until the end of the phase.',
                          'GC10'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          1,
                          'Toujours à portée de main',
                          'I LIKE TO KEEP THIS HANDY...',
                          0,
                          'GC',
                          'Utilisez cette tactique au début de la phase de tir. Choisissez une figurine de votre kill team armée d''un fusil à pompe. Le type de fusil à pompe devient Pistolet 2 jusqu''à la fin de la phase.',
                          'Use at the start of the Shooting phase . Pick a model from your kill team armed with a shotgun . Change the
shotgun’s Type to Pistol 2 until the end of phase.',
                          'GC11'
                      ),
                      (
                          0,
                          0,
                          NULL,
                          NULL,
                          2,
                          'Déflagration sismique',
                          'SEISMIC BLAST',
                          0,
                          'GC',
                          'Utilisez cette tactique lorsque vous choisissez une figurines de votre kill team pour tirer avec le profil onde courte d''un canon sismique. Si une attaque pour cette arme touche, jetez un dé pour chaque autre figurine à 2" de la figurine cible. Sur 5+, la figurine est secouée.',
                          'Use when you chose a model in your kill team to shoot with the short-wave profile of a seismic cannon . If an attack
for the weapon hits , roll a dice for each other model within 2” of the target model. On a 5+ that model is shaken .',
                          'GC12'
                      );

update traits set DescriptionEn = 'Ignore the penalty to this model''s hit rolls from flesh wounds it has suffered.', DescriptionFr ='Ignorez la pénalité aux jets de touche de cette figurine causée par les blessures légères qu''elle a subies.' where Id = 'G3';
update ProfileArmes set PA = -2 where Id = 'FRL';
update Remplacement set Operation = 'PB&BO:COL|COG|COP|COF' where Id = 6;