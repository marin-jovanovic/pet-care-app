
const insert_into_location = `
	INSERT INTO location (
	  idlocation, latitude, longitude, level,
	  isHouse
	)
	VALUES
	  (1, 45.3132, 13.232, 0, true),
	  (2, 45.3132, 14.232, 2, true),
	  (3, 45.3132, 16.232, 3, true),
	  (4, 45.3132, 15.232, 0, true);
`;

const insert_into_session = `
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
`;

const insert_into_period = `
	INSERT INTO PERIOD(idPeriod, startdate, enddate)
	VALUES
	  (0, '2022-04-01', '2022-06-01'),
	  (1, '2022-04-01', '2022-08-01'),
	  (2, '2022-04-01', '2022-07-01'),
	  (3, '2022-04-01', '2022-07-01');
`;

const insert_into_pettype = `
	INSERT INTO PETTYPE (typePetName, idpettype)
	VALUES
	  ('Ribe', 1),
	  ('Mačke', 2),
	  ('Psi', 3),
	  ('Zmije', 4),
	  ('Majmun', 5),
	  ('Glodavci', 6);
`;

const insert_into_breed = `
	INSERT INTO BREED(petBreed, idPetType)
	VALUES
	  ('Šaran', 1),
	  ('Perzijska', 2),
	  ('Njemački ovčar', 3);
`;

const insert_into_cipher = `
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
`;

const insert_into_person = `
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
`;

const insert_into_public_admin = `
	INSERT INTO public.admin(username)
	VALUES
	  ('Pero'),
	  ('PeroPeric'),
	  ('userName');
`;

const insert_into_appuser = `
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
`;

const insert_into_descriptable = `
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
`;

const insert_into_review = `
	INSERT INTO REVIEW (grade, idDescriptable, userName)
	VALUES
	  (5, 0, 'Pero'),
	  (5, 1, 'PeroPeric'),
	  (5, 2, 'Pero');
`;

const insert_into_adlisting = `
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
`;

const insert_into_pet = `
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
`;

const insert_into_messages = `
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
`;

const insert_into_card = `
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
`;

const insert_into_give = `
	INSERT INTO give(userName, idDescriptable)
	VALUES
	  ('PeroPeric', 0),
	  ('Pero', 1);
`;

const insert_into_contains = `
	INSERT INTO contains (idDescriptable)
	VALUES
	  (1),
	  (0);
`;

const insert_into_report = `
	INSERT INTO report (userName, idDescriptable)
	VALUES
	  ('PeroPeric', 0),
	  ('Pero', 1);
`;

const insert_into_recive = `
	INSERT INTO recive (userName, idmessages)
	VALUES
	  ('PeroPeric', 0),
	  ('Pero', 1);
	
`;
module.exports = {	insert_into_location,
	insert_into_session,
	insert_into_period,
	insert_into_pettype,
	insert_into_breed,
	insert_into_cipher,
	insert_into_person,
	insert_into_public_admin,
	insert_into_appuser,
	insert_into_descriptable,
	insert_into_review,
	insert_into_adlisting,
	insert_into_pet,
	insert_into_messages,
	insert_into_card,
	insert_into_give,
	insert_into_contains,
	insert_into_report,
	insert_into_recive,
}