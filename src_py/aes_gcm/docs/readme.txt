upute

##########
o pokretanju programa

Program je pisan u python-u.
Potreban je python 3.8 interpreter. 
Od nestandardnih biblioteka potrebno je imat pycryptodome.
Ulazna tocka u program je main.py.

########## 
o algoritmu

# provjera postoji li datoteka 
	Pri pokretanju programa provjerava se postoji li datoteka ("log.txt", u daljnjem tekstu LOG) u koju je predvideno da se sprema sifrat i svi potrebni podatci potrebni za provjeru glavne lozinke. 

		Ako LOG ne postoji mozemo zakljuciti da program nije nikad pokrenut na tom racunalu ili da se ne nalazi na odgovarajucem mjestu (ili je izbrisan ili premjesten). Program tada kreira novi LOG.

		Ako LOG postoji, program nastavlja s radom.

# unos glavne lozinke

	Ako je LOG napravljen u proslom koraku, program trazi da korisnik unese novu glavnu lozinku.
		Nakon unosa lozinke program provjerava je li lozinka veca od odredenog broja znakova i postoji li neki posebni znak u toj lozinci. Ove sigurnosne zahtjeve je lako nadopisati te su prethodna dva napravljena radi demonstracije.

		Program zahtjeva novu lozinku dokle god korisnik ne ispuni gore navedene zahtjeve na lozinku i dok ju ne potvrdi ponovnim unosom.

		Posto je kreiran LOG nema smisla provjeravati integritet ili dekriptirati ikakve podatke posto ih nema. Iduci korak se u ovom slucaju preskace

	Ako LOG nije napravljen u proslom koraku, program trazi korisnika lozinku koju je postavio

# dekripcija podataka, ispitivanje integriteta

	Program koristi AES GCM (iz pycryptodome biblioteke) za osiguravanje tajnosti i integriteta. To je autentificirana sifra sto znaci da uz tajnost osigurava i integritet. 

	Program cita iz LOG-a sljedece podatke: nonce, ciphertext, tag i salt.

	Program salje glavnu lozinku i salt funkciji za derivaciju kljuceva (scrypt iz pycryptodome-a).
	Ovime se dobiva kljuc (u daljnjem tekstu KLJUC) koji program koristi odsada umjesto glavne lozinke. Ovo je bitna komponenta za tajnost, ali se ovime osigurava i da se glavna lozinka pretvara na deterministicki nacin u kljuc fiksne duljine.

	Program salje KLJUC, nonce i ciphertext funkciji AES GCM koji vraca plaintext ako je KLJUC ispravan i integritet ocuvan. Plaintext je rjecnik parova ("stranica": "lozinka"). 

	Ako je sve ispravno program prelazi u iduci korak, a u slucaju da je narusen integritet ili neispravna lozinka; ispisuje se poruka o tome. Nije moguce odrediti je li narusen integritet ili je upisana neispravna lozinka ili oboje. 

	Korisniku se sada nudi izlaz iz programa, ponovna inicijalizacija LOG-a i nova glavna lozinka ili ponovni unos glavne lozinke. 

# glavni izbornik
	
	Program se sada nalazi u glavnom izborniku te nudi vise opcija. 

	Promjena glavne lozinke
		korisnik unosi trenutnu lozinku te unosi novu glavnu lozinku koja mora zadovoljiti zahtjeve koji su vec opisani.

	Prikaz lozinke za zadanu stranicu
		Korisnik unosi zeljenu stranicu te program ispisuje lozinku za tu stranicu.

	Dodavanje nove lozinke za zadanu stranicu
		Korisnik upisuje novu stranicu i lozinku za nju. Ako upise stranicu koja postoji onda se prepisuje stara lozinka.

	Ispis svih postojecih stranica
		Ovime se omogucava ispis svih postojecih stranica, ali bez lozinke.

		Ovdje su razmatrani neki sigurnosni aspekti:
			ako napadac zna glavnu lozinku onda moze na jednostavan nacin modificirati kod da se ispisuju sve stranice i lozinke te time doci do svih lozinki ako nije znao koje sve stranice su spremljen. Iz ovog razloga sam odlucio kako ovo nije dovoljno velika prijetnja da se postavi kao opcija, a dovoljno je korisno da bi korisnik imao koristi od nje. 
			Ako razmisljamo u smjeru da ako napadac vidi koje su sve stranice u LOGu onda mozemo raspravljati i o tome ima li smisla da se ovaj program pokrece iz komadne linije i da ostaje glavna lozinka vidljiva tokom upisa pa i nakon sto je svakako jos veci problem. 
			Ideja je da korisniku alat bude kompromis izmedu sigurnost i ugode koristenja. 

	Spremanje i izlaz
		Ovime program prelazi u iduci korak te nakon toga zavrsava

# sifriranje i spremanje podataka 
	glavna lozinka se salje funkciji za derivaciju kljuca. Ta funkcija generira slucajni (crypto random) salt te vraca taj isti salt i KLJUC. 
	AES GCM koristi nonce i tag (koji sam generira), salt i plaintext kako bi dobio ciphertext. Nakon sifriranja sprema se ciphertext, salt, nonce i tag u LOG. 

	program zavrsava.
