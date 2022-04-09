CREATE TABLE LOCATION
(
  idLocation INT NOT NULL,
  latitude FLOAT NOT NULL,
  longitude FLOAT NOT NULL,
  level INT NOT NULL,
  isHouse boolean NOT NULL,
  PRIMARY KEY (idLocation)
);

CREATE TABLE SESSION
(
  idSession VARCHAR(500) NOT NULL,
  expire VARCHAR(500) NOT NULL,
  info VARCHAR(10000) NOT NULL
);

CREATE TABLE PERIOD
(
  start DATE NOT NULL,
  end DATE NOT NULL,
  idPeriod INT NOT NULL,
  PRIMARY KEY (idPeriod)
);

CREATE TABLE PETTYPE
(
  idPetType INT NOT NULL,
  typePetName VARCHAR(1000) NOT NULL,
  PRIMARY KEY (idPetType)
);

CREATE TABLE BREED
(
  petBreed VARCHAR(1000) NOT NULL,
  idPetType INT NOT NULL,
  PRIMARY KEY (idPetType),
  FOREIGN KEY (idPetType) REFERENCES PETTYPE(idPetType)
);

CREATE TABLE CIPHER
(
  nonce VARCHAR(65000) NOT NULL,
  tag VARCHAR(65000) NOT NULL,
  salt VARCHAR(65000) NOT NULL,
  idCiper VARCHAR(65000) NOT NULL,
  PRIMARY KEY (idCiper)
);

CREATE TABLE PERSON
(
  userName VARCHAR(5000) NOT NULL,
  email VARCHAR(2000) NOT NULL,
  password VARCHAR(4000) NOT NULL,
  mobileNumber VARCHAR(400) NOT NULL,
  idPerson INT NOT NULL,
  idCiper VARCHAR(65000) NOT NULL,
  PRIMARY KEY (userName),
  FOREIGN KEY (idCiper) REFERENCES CIPHER(idCiper),
  UNIQUE (idPerson)
);

CREATE TABLE ADMIN
(
  userName VARCHAR(5000) NOT NULL,
  PRIMARY KEY (userName),
  FOREIGN KEY (userName) REFERENCES PERSON(userName)
);

CREATE TABLE USER
(
  OIB VARCHAR(500) NOT NULL,
  smoker boolean NOT NULL,
  birthday VARCHAR(500) NOT NULL,
  gender VARCHAR(100) NOT NULL,
  name VARCHAR(500) NOT NULL,
  surname VARCHAR(500) NOT NULL,
  isDisable boolean NOT NULL,
  userName VARCHAR(5000) NOT NULL,
  userName VARCHAR(5000),
  PRIMARY KEY (userName),
  FOREIGN KEY (userName) REFERENCES PERSON(userName),
  FOREIGN KEY (userName) REFERENCES ADMIN(userName),
  UNIQUE (OIB)
);

CREATE TABLE DESCRIPTABLE
(
  description VARCHAR(10000) NOT NULL,
  isDisabled boolean NOT NULL,
  idDescriptable INT NOT NULL,
  isReported boolean NOT NULL,
  userName VARCHAR(5000),
  PRIMARY KEY (idDescriptable),
  FOREIGN KEY (userName) REFERENCES ADMIN(userName)
);

CREATE TABLE REVIEW
(
  grade INT NOT NULL,
  idDescriptable INT NOT NULL,
  userName VARCHAR(5000) NOT NULL,
  PRIMARY KEY (idDescriptable),
  FOREIGN KEY (idDescriptable) REFERENCES DESCRIPTABLE(idDescriptable),
  FOREIGN KEY (userName) REFERENCES USER(userName)
);

CREATE TABLE ADLISTING
(
  description VARCHAR(60000) NOT NULL,
  price FLOAT NOT NULL,
  idAdListing INT NOT NULL,
  New_Column INT NOT NULL,
  idDescriptable INT NOT NULL,
  userName VARCHAR(5000) NOT NULL,
  idLocation INT NOT NULL,
  idPeriod INT NOT NULL,
  PRIMARY KEY (idDescriptable),
  FOREIGN KEY (idDescriptable) REFERENCES DESCRIPTABLE(idDescriptable),
  FOREIGN KEY (userName) REFERENCES USER(userName),
  FOREIGN KEY (idLocation) REFERENCES LOCATION(idLocation),
  FOREIGN KEY (idPeriod) REFERENCES PERIOD(idPeriod),
  UNIQUE (idAdListing)
);

CREATE TABLE PET
(
  petId INT NOT NULL,
  age INT NOT NULL,
  name VARCHAR(1000) NOT NULL,
  description VARCHAR(10000) NOT NULL,
  idDescriptable INT NOT NULL,
  userName VARCHAR(5000) NOT NULL,
  idPetType INT NOT NULL,
  PRIMARY KEY (idDescriptable),
  FOREIGN KEY (idDescriptable) REFERENCES DESCRIPTABLE(idDescriptable),
  FOREIGN KEY (userName) REFERENCES USER(userName),
  FOREIGN KEY (idPetType) REFERENCES PETTYPE(idPetType),
  UNIQUE (petId)
);

CREATE TABLE MESSAGES
(
  idmessages INT NOT NULL,
  body VARCHAR(65000) NOT NULL,
  timestamp DATE NOT NULL,
  idPersonFrom VARCHAR(1000) NOT NULL,
  idPersonTo VARCHAR(1000) NOT NULL,
  userName VARCHAR(5000) NOT NULL,
  PRIMARY KEY (idmessages),
  FOREIGN KEY (userName) REFERENCES PERSON(userName)
);

CREATE TABLE CARD
(
  cardNumber VARCHAR(160) NOT NULL,
  validUntil VARCHAR(200) NOT NULL,
  CVV VARCHAR(30) NOT NULL,
  address VARCHAR(2000) NOT NULL,
  cardType VARCHAR(200) NOT NULL,
  userName VARCHAR(5000) NOT NULL,
  PRIMARY KEY (userName),
  FOREIGN KEY (userName) REFERENCES USER(userName)
);

CREATE TABLE give
(
  userName VARCHAR(5000) NOT NULL,
  idDescriptable INT NOT NULL,
  PRIMARY KEY (userName, idDescriptable),
  FOREIGN KEY (userName) REFERENCES USER(userName),
  FOREIGN KEY (idDescriptable) REFERENCES REVIEW(idDescriptable)
);

CREATE TABLE contains
(
  idDescriptable INT NOT NULL,
  idDescriptable INT NOT NULL,
  PRIMARY KEY (idDescriptable, idDescriptable),
  FOREIGN KEY (idDescriptable) REFERENCES ADLISTING(idDescriptable),
  FOREIGN KEY (idDescriptable) REFERENCES PET(idDescriptable)
);

CREATE TABLE report
(
  userName VARCHAR(5000) NOT NULL,
  idDescriptable INT NOT NULL,
  PRIMARY KEY (userName, idDescriptable),
  FOREIGN KEY (userName) REFERENCES USER(userName),
  FOREIGN KEY (idDescriptable) REFERENCES DESCRIPTABLE(idDescriptable)
);

CREATE TABLE recive
(
  userName VARCHAR(5000) NOT NULL,
  idmessages INT NOT NULL,
  PRIMARY KEY (userName, idmessages),
  FOREIGN KEY (userName) REFERENCES PERSON(userName),
  FOREIGN KEY (idmessages) REFERENCES MESSAGES(idmessages)
);