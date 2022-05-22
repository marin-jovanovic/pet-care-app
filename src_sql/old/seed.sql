INSERT INTO location (
  idlocation, latitude, longitude, level, 
  isHouse
) 
VALUES 
  (1, 45.3132, 13.232, 0, true), 
  (2, 45.3132, 14.232, 2, true), 
  (3, 45.3132, 16.232, 3, true), 
  (4, 45.3132, 15.232, 0, true);
INSERT INTO SESSION (idSession, expire, info) 
VALUES 
  (
    'afkliajhflia', '2013-06-01', 'ajhfkliajhflia'
  ), 
  (
    'ahfjadfw', '2022-06-01', 'ajhfkliajhgada'
  ), 
  (
    'ahfjadfq', '2022-06-01', 'ajhfkliaadfadf'
  ), 
  (
    'ahafjadfq', '2022-06-01', 'ajhsfkliaadfadf'
  );
INSERT INTO PERIOD(idPeriod, startdate, enddate) 
VALUES 
  (0, '2022-04-01', '2022-06-01'), 
  (1, '2022-04-01', '2022-08-01'), 
  (2, '2022-04-01', '2022-07-01'), 
  (3, '2022-04-01', '2022-07-01');
INSERT INTO PETTYPE (typePetName, idpettype) 
VALUES 
  ('Ribe', 1), 
  ('Mačke', 2), 
  ('Psi', 3), 
  ('Zmije', 4), 
  ('Majmun', 5), 
  ('Glodavci', 6);
INSERT INTO BREED(petBreed, idPetType) 
VALUES 
  ('Šaran', 1), 
  ('Perzijska', 2), 
  ('Njemački ovčar', 3);
INSERT INTO CIPHER (nonce, tag, salt, idciper) 
VALUES 
  (
    'adfhasgjdfghkasjibhfa', 'adsghfausgdf', 
    'agfdgfuasdofauu', 'adfhasgjdfghkasjibhfa'
  ), 
  (
    'adfhasgjdfghkasjibhfadaa', 'adsghfausgdfada', 
    'agfdgfuasdofdfasdf', 'adfhasgjdfghkasjibhfadaa'
  ), 
  (
    'adfhasgjdfghkasjibhadfa', 'adsghfausgdadf', 
    'agfdgfuasdofauadsu', 'adfhasgjdfghkasjibhadfa'
  ), 
  (
    'adfhasgj22dfghkasjibhfa', 'adsghfaus12gdf', 
    'agfdgfuas12dofauu', 'adfhasgj22dfghkasjibhfa'
  );
INSERT INTO PERSON(
  userName, email, password, mobileNumber, 
  idCiper
) 
VALUES 
  (
    'userName', 'blabla@gmail.com', 'jasamZakon', 
    '+095553434', 'adfhasgjdfghkasjibhfa'
  ), 
  (
    'PeroPeric', 'PeroPeric@gmail.com', 
    'jasamZakon', '+0934553434', 'adfhasgjdfghkasjibhfadaa'
  ), 
  (
    'Pero', 'Pero@gmail.com', 'jasamZakon', 
    '+093455388434', 'adfhasgj22dfghkasjibhfa'
  );
INSERT INTO public.admin(username) 
VALUES 
  ('Pero'), 
  ('PeroPeric'), 
  ('userName');
INSERT INTO APPUSER (
  OIB, smoker, birthday, gender, name, 
  surname, isDisable, userName
) 
VALUES 
  (
    '029309818832', FALSE, '22.02.2000', 
    'men', 'Pero', 'Peric', FALSE, 'PeroPeric'
  ), 
  (
    '029309238832', FALSE, '25.05.2000', 
    'men', 'Pero', 'Peric', FALSE, 'Pero'
  ), 
  (
    '239309238832', FALSE, '25.05.2000', 
    'women', 'Petra', 'Peric', FALSE, 
    'userName'
  );
INSERT INTO DESCRIPTABLE (
  description, isDisabled, idDescriptable, 
  isReported, userName
) 
VALUES 
  (
    'Some description ', FALSE, 0, FALSE, 
    'PeroPeric'
  ), 
  (
    'Some description za oglase', FALSE, 
    1, FALSE, 'Pero'
  ), 
  (
    'Some description za oglase za psa', 
    FALSE, 2, FALSE, 'userName'
  );
INSERT INTO REVIEW (grade, idDescriptable, userName) 
VALUES 
  (5, 0, 'Pero'), 
  (5, 1, 'PeroPeric'), 
  (5, 2, 'Pero');
INSERT INTO ADLISTING(
  description, price, idAdListing, idDescriptable, 
  userName, idLocation, idPeriod
) 
VALUES 
  (
    'Description12 ', 100.10, 0, 0, 'userName', 
    1, 0
  ), 
  (
    'Description', 100.10, 2, 1, 'userName', 
    1, 1
  );
INSERT INTO PET (
  age, name, description, idDescriptable, 
  userName, idPetType
) 
VALUES 
  (
    12, 'Puslica', 'Traim oglas za čuvanje stare mačke potrebna koja treba cijelo vrijeme nadzor', 
    0, 'PeroPeric', 1
  ), 
  (
    12, 'Hund', 'Traim oglas za čuvanje psapotrebna koja treba cijelo vrijeme nadzor', 
    1, 'Pero', 2
  );
INSERT INTO MESSAGES(
  idmessages, body, timestamp, idPersonFrom, 
  idPersonTo, userName
) 
VALUES 
  (
    0, 'Pozdrav moj pas je spreman na lokaciji.', 
    '2021-12-12', 0, 1, 'PeroPeric'
  ), 
  (
    1, 'Pozdrav moj pas je spreman na lokaciji.', 
    '2021-12-12', 0, 1, 'PeroPeric'
  );
INSERT INTO CARD(
  cardNumber, validUntil, CVV, address, 
  cardType, userName
) 
VALUES 
  (
    'hasVrijednost', 'hashvrijednost', 
    'ajhdgfiad', 'Ive loleRibara 21', 
    'VISA', 'PeroPeric'
  ), 
  (
    'hasVrijednost', 'hashvrijednost1', 
    'ajhdgfiad', 'Ive loleRibara 26', 
    'VISA', 'Pero'
  );
INSERT INTO give(userName, idDescriptable) 
VALUES 
  ('PeroPeric', 0), 
  ('Pero', 1);
INSERT INTO contains (idDescriptable) 
VALUES 
  (1), 
  (0);
INSERT INTO report (userName, idDescriptable) 
VALUES 
  ('PeroPeric', 0), 
  ('Pero', 1);
INSERT INTO recive (userName, idmessages) 
VALUES 
  ('PeroPeric', 0), 
  ('Pero', 1);
