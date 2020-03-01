
Update MembrePouvoir set IsGeneralite = 0 where IsGeneralite IS NULL;
Update MembrePouvoir set IsMaitreSpe = 0 where IsMaitreSpe IS NULL;
Update Declinaisons set E = 4, F = 3 where Id = 'MV1';
Update Declinaisons set E = 4, F = 4 where Id = 'MB3';
Update Declinaisons set E = 4, F = 3 where Id = 'MV31';
Update Declinaisons set E = 4, F = 3 where Id = 'MV33';
Update Declinaisons set E = 4, F = 3 where Id = 'MV36';
Update Declinaisons set E = 4, F = 3 where Id = 'MV7';
Update Declinaisons set E = 4, F = 3 where Id = 'MV4';

update Armes set cout = 2 where Id = 'BEP';

update ProfileArmes set AptitudesEn = 'Attacks from this weapon that target enemies at 8" or less are resolved with an AP of-4 and a Damage of D3.' where Id = 'ER';

INSERT OR IGNORE INTO SurchargeCoutArme (
                                  Cout,
                                  ArmeId,
                                  DeclinaisonId,
                                  Id
                              )
                              VALUES (
                                  7,
                                  'EPE',
                                  'AACDW',
                                  46
                              );
