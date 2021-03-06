const db_index = require('./db_executor');
(async () => {
	await db_index.crypto_query_wrapper(
		'INSERT INTO location ( idlocation, latitude, longitude, level, isHouse ) VALUES ($1, $2, $3, $4, $5)',
		[["idlocation", 1], ["latitude", 45.3132], ["longitude", 13.232], ["level", 0], ["isHouse", true]],
		{
			"__username": "PeroPeric345",
			"__table": "location",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO PERIOD ( idPeriod, startdate, enddate ) VALUES ($1, $2, $3)',
		[["idPeriod", 0], ["startdate", '2022-04-01'], ["enddate", '2022-06-01']],
		{
			"__username": "PeroPeric345",
			"__table": "period",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO SESSION (idSession, expire, info) VALUES ( $1, $2, $3)',
		[["idSession", 'afkliajhflia'], ["expire", '2013-06-01'], ["info", 'ajhfkliajhflia']],
		{
			"__username": "PeroPeric345",
			"__table": "session",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO PETTYPE (typePetName, idpettype) VALUES ( $1, $2)',
		[["typePetName", 'Ribe'], ["idpettype", 1]],
		{
			"__username": "PeroPeric345",
			"__table": "pettype",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO BREED (petBreed, idPetType) VALUES ( $1, $2)',
		[["petBreed", 'Šaran'], ["idPetType", 1]],
		{
			"__username": "PeroPeric345",
			"__table": "breed",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO CIPHER (nonce, tag, salt, idciper) VALUES ( $1, $2, $3, $4 )',
		[["nonce", '{}'], ["tag", '{}'], ["salt", '{}'], ["idciper", 'adfhasgjdfghkasjibhfa']],
		{
			"__username": "PeroPeric345",
			"__table": "cipher",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO PERSON (userName, email, password, mobileNumber, idCiper) VALUES ( $1, $2, $3, $4, $5)',
		[["userName", 'PeroPeric345'], ["email", 'blabla@gmail.com'], ["password", 'jasamZakon'], ["mobileNumber", '+095553434'], ["idCiper", 'adfhasgjdfghkasjibhfa']],
		{
			"__username": "PeroPeric345",
			"__table": "person",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO public.admin (username) VALUES ( $1)',
		[["username", 'PeroPeric345']],
		{
			"__username": "PeroPeric345",
			"__table": "public.admin",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO APPUSER (OIB, smoker, birthday, gender, name,surname, isDisable, userName ) VALUES ( $1, $2, $3, $4, $5, $6, $7, $8)',
		[["OIB", '029309818832'], ["smoker", false], ["birthday", '22.02.2000'], ["gender", 'men'], ["name", 'Pero'], ["surname", 'Peric'], ["isDisable", false], ["userName", 'PeroPeric345']],
		{
			"__username": "PeroPeric345",
			"__table": "appuser",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO DESCRIPTABLE (description, isDisabled, idDescriptable, isReported, userName) VALUES ( $1, $2, $3, $4, $5)',
		[["description", 'Some description'], ["isDisabled", false], ["idDescriptable", 0], ["isReported", false], ["userName", 'PeroPeric345']],
		{
			"__username": "PeroPeric345",
			"__table": "descriptable",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO REVIEW (grade, idDescriptable, userName) VALUES ( $1, $2, $3)',
		[["grade", 5], ["idDescriptable", 0], ["userName", 'PeroPeric345']],
		{
			"__username": "PeroPeric345",
			"__table": "review",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO ADLISTING (description, price, idAdListing, idDescriptable, userName, idLocation, idPeriod) VALUES ( $1, $2, $3, $4, $5, $6, $7)',
		[["description", 'Description12 '], ["price", 100.10], ["idAdListing", 0], ["idDescriptable", 0], ["userName", 'PeroPeric345'], ["idLocation", 1], ["idPeriod", 0]],
		{
			"__username": "PeroPeric345",
			"__table": "adlisting",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO PET (age, name, description, idDescriptable, userName, idPetType ) VALUES ( $1, $2, $3, $4, $5,$6)',
		[["age", 12], ["name", 'Puslica'], ["description", 'Traim oglas za čuvanje stare mačke potrebna koja treba cijelo vrijeme nadzor'], ["idDescriptable", 0], ["userName", 'PeroPeric345'], ["idPetType", 1]],
		{
			"__username": "PeroPeric345",
			"__table": "pet",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO MESSAGES ( idmessages, body, timestamp, idPersonFrom, idPersonTo, userName) VALUES ( $1, $2, $3, $4, $5, $6)',
		[["idmessages", 0], ["body", 'Pozdrav moj pas je spreman na lokaciji.'], ["timestamp", '2021-12-12'], ["idPersonFrom", 0], ["idPersonTo", 1], ["userName", 'PeroPeric345']],
		{
			"__username": "PeroPeric345",
			"__table": "messages",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO CARD (cardNumber, validUntil, CVV, address,cardType, userName) VALUES ( $1, $2, $3, $4, $5, $6)',
		[["cardNumber", 'hasVrijednost'], ["validUntil", 'hashvrijednost'], ["CVV", 'ajhdgfiad'], ["address", 'Ive loleRibara 21'], ["cardType", 'VISA'], ["userName", 'PeroPeric345']],
		{
			"__username": "PeroPeric345",
			"__table": "card",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO give (userName, idDescriptable) VALUES ( $1, $2)',
		[["userName", 'PeroPeric345'], ["idDescriptable", 0]],
		{
			"__username": "PeroPeric345",
			"__table": "give",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO contains (idDescriptable)VALUES($1)',
		[["idDescriptable", 0]],
		{
			"__username": "PeroPeric345",
			"__table": "contains",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO report (userName, idDescriptable) VALUES ( $1, $2)',
		[["userName", 'PeroPeric345'], ["idDescriptable", 0]],
		{
			"__username": "PeroPeric345",
			"__table": "report",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
	await db_index.crypto_query_wrapper(
		'INSERT INTO recive (userName, idmessages) VALUES ( $1, $2)',
		[["userName", 'PeroPeric345'], ["idmessages", 0]],
		{
			"__username": "PeroPeric345",
			"__table": "recive",
			"__key": "ovoSeNekakoPamti!123",
		}
	)
	
})();
