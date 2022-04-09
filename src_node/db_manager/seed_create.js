
const create_table_location = `
CREATE TABLE IF NOT EXISTS LOCATION (
  idLocation SERIAL NOT NULL,
  latitude FLOAT NOT NULL,
  longitude FLOAT NOT NULL,
  level INT NOT NULL,
  isHouse boolean NOT NULL,
  PRIMARY KEY (idLocation)
);
`;

const create_table_session = `
CREATE TABLE IF NOT EXISTS SESSION (
  idSession VARCHAR(500) NOT NULL,
  expire VARCHAR(500) NOT NULL,
  info VARCHAR(10000) NOT NULL
);
`;

const create_table_period = `
CREATE TABLE IF NOT EXISTS PERIOD (
  startDate DATE NOT NULL,
  endDate DATE NOT NULL,
  idPeriod SERIAL NOT NULL,
  PRIMARY KEY (idPeriod)
);
`;

const create_table_pettype = `
CREATE TABLE IF NOT EXISTS PETTYPE (
  idPetType SERIAL NOT NULL,
  typePetName VARCHAR(1000) NOT NULL,
  PRIMARY KEY (idPetType)
);
`;

const create_table_breed = `
CREATE TABLE IF NOT EXISTS BREED (
  petBreed VARCHAR(1000) NOT NULL,
  idPetType SERIAL NOT NULL,
  PRIMARY KEY (idPetType),
  FOREIGN KEY (idPetType) REFERENCES PETTYPE(idPetType)
);
`;

const create_table_cipher = `
CREATE TABLE IF NOT EXISTS CIPHER (
  nonce VARCHAR(65000) NOT NULL,
  tag VARCHAR(65000) NOT NULL,
  salt VARCHAR(65000) NOT NULL,
  idCiper VARCHAR(65000) NOT NULL,
  PRIMARY KEY (idCiper)
);
`;

const create_table_person = `
CREATE TABLE IF NOT EXISTS PERSON (
  userName VARCHAR(5000) NOT NULL,
  email VARCHAR(2000) NOT NULL,
  password VARCHAR(4000) NOT NULL,
  mobileNumber VARCHAR(400) NOT NULL,
  idPerson SERIAL NOT NULL,
  idCiper VARCHAR(65000) NOT NULL,
  PRIMARY KEY (userName),
  FOREIGN KEY (idCiper) REFERENCES CIPHER(idCiper),
  UNIQUE (idPerson)
);
`;

const create_table_admin = `
CREATE TABLE IF NOT EXISTS ADMIN (
  userName VARCHAR(5000) NOT NULL,
  PRIMARY KEY (userName),
  FOREIGN KEY (userName) REFERENCES PERSON(userName)
);
`;

const create_table_appuser = `
CREATE TABLE IF NOT EXISTS APPUSER (
  OIB VARCHAR(500) NOT NULL,
  smoker boolean NOT NULL,
  birthday VARCHAR(500) NOT NULL,
  gender VARCHAR(100) NOT NULL,
  name VARCHAR(500) NOT NULL,
  surname VARCHAR(500) NOT NULL,
  isDisable boolean NOT NULL,
  userName VARCHAR(5000) NOT NULL,
  PRIMARY KEY (userName),
  FOREIGN KEY (userName) REFERENCES PERSON(userName),
  FOREIGN KEY (userName) REFERENCES ADMIN(userName),
  UNIQUE (OIB)
);
`;

const create_table_descriptable = `
CREATE TABLE IF NOT EXISTS DESCRIPTABLE (
  description VARCHAR(10000) NOT NULL,
  isDisabled boolean NOT NULL,
  idDescriptable SERIAL NOT NULL,
  isReported boolean NOT NULL,
  userName VARCHAR(5000),
  PRIMARY KEY (idDescriptable),
  FOREIGN KEY (userName) REFERENCES ADMIN(userName)
);
`;

const create_table_review = `
CREATE TABLE IF NOT EXISTS REVIEW (
  grade INT NOT NULL,
  idDescriptable SERIAL NOT NULL,
  userName VARCHAR(5000) NOT NULL,
  PRIMARY KEY (idDescriptable),
  FOREIGN KEY (idDescriptable) REFERENCES DESCRIPTABLE(idDescriptable),
  FOREIGN KEY (userName) REFERENCES APPUSER(userName)
);
`;

const create_table_adlisting = `
CREATE TABLE IF NOT EXISTS ADLISTING (
  description VARCHAR(60000) NOT NULL,
  price FLOAT NOT NULL,
  idAdListing SERIAL NOT NULL,
  idDescriptable INT NOT NULL,
  userName VARCHAR(5000) NOT NULL,
  idLocation SERIAL NOT NULL,
  idPeriod SERIAL NOT NULL,
  PRIMARY KEY (idDescriptable),
  FOREIGN KEY (idDescriptable) REFERENCES DESCRIPTABLE(idDescriptable),
  FOREIGN KEY (userName) REFERENCES APPUSER(userName),
  FOREIGN KEY (idLocation) REFERENCES LOCATION(idLocation),
  FOREIGN KEY (idPeriod) REFERENCES PERIOD(idPeriod),
  UNIQUE (idAdListing)
);
`;

const create_table_pet = `
CREATE TABLE IF NOT EXISTS PET (
  petId SERIAL NOT NULL,
  age INT NOT NULL,
  name VARCHAR(1000) NOT NULL,
  description VARCHAR(10000) NOT NULL,
  idDescriptable INT NOT NULL,
  userName VARCHAR(5000) NOT NULL,
  idPetType SERIAL NOT NULL,
  PRIMARY KEY (idDescriptable),
  FOREIGN KEY (idDescriptable) REFERENCES DESCRIPTABLE(idDescriptable),
  FOREIGN KEY (userName) REFERENCES APPUSER(userName),
  FOREIGN KEY (idPetType) REFERENCES PETTYPE(idPetType),
  UNIQUE (petId)
);
`;

const create_table_messages = `
CREATE TABLE IF NOT EXISTS MESSAGES (
  idmessages SERIAL NOT NULL,
  body VARCHAR(65000) NOT NULL,
  timestamp DATE NOT NULL,
  idPersonFrom VARCHAR(1000) NOT NULL,
  idPersonTo VARCHAR(1000) NOT NULL,
  userName VARCHAR(5000) NOT NULL,
  PRIMARY KEY (idmessages),
  FOREIGN KEY (userName) REFERENCES PERSON(userName)
);
`;

const create_table_card = `
CREATE TABLE IF NOT EXISTS CARD (
  cardNumber VARCHAR(160) NOT NULL,
  validUntil VARCHAR(200) NOT NULL,
  CVV VARCHAR(30) NOT NULL,
  address VARCHAR(2000) NOT NULL,
  cardType VARCHAR(200) NOT NULL,
  userName VARCHAR(5000) NOT NULL,
  PRIMARY KEY (userName),
  FOREIGN KEY (userName) REFERENCES APPUSER(userName)
);
`;

const create_table_give = `
CREATE TABLE IF NOT EXISTS give (
  userName VARCHAR(5000) NOT NULL,
  idDescriptable SERIAL NOT NULL,
  PRIMARY KEY (userName, idDescriptable),
  FOREIGN KEY (userName) REFERENCES APPUSER(userName),
  FOREIGN KEY (idDescriptable) REFERENCES REVIEW(idDescriptable)
);
`;

const create_table_contains = `
CREATE TABLE IF NOT EXISTS contains (
  idDescriptable SERIAL NOT NULL,
  PRIMARY KEY (idDescriptable),
  FOREIGN KEY (idDescriptable) REFERENCES ADLISTING(idDescriptable),
  FOREIGN KEY (idDescriptable) REFERENCES PET(idDescriptable)
);
`;

const create_table_report = `
CREATE TABLE IF NOT EXISTS report (
  userName VARCHAR(5000) NOT NULL,
  idDescriptable SERIAL NOT NULL,
  PRIMARY KEY (userName, idDescriptable),
  FOREIGN KEY (userName) REFERENCES APPUSER(userName),
  FOREIGN KEY (idDescriptable) REFERENCES DESCRIPTABLE(idDescriptable)
);
`;

const create_table_recive = `
CREATE TABLE IF NOT EXISTS recive (
  userName VARCHAR(5000) NOT NULL,
  idmessages SERIAL NOT NULL,
  PRIMARY KEY (userName, idmessages),
  FOREIGN KEY (userName) REFERENCES PERSON(userName),
  FOREIGN KEY (idmessages) REFERENCES MESSAGES(idmessages)
);
`;
module.exports = {	create_table_location,
create_table_session,
create_table_period,
create_table_pettype,
create_table_breed,
create_table_cipher,
create_table_person,
create_table_admin,
create_table_appuser,
create_table_descriptable,
create_table_review,
create_table_adlisting,
create_table_pet,
create_table_messages,
create_table_card,
create_table_give,
create_table_contains,
create_table_report,
create_table_recive,
}