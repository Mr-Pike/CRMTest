CREATE TABLE Country (
	ID SMALLINT NOT NULL IDENTITY(1,1),
	ISO2 CHAR(2) NOT NULL,
	Name VARCHAR(100) NOT NULL,
	CONSTRAINT PK_COUN PRIMARY KEY (ID)
)
GO

INSERT INTO Country (ISO2, Name)
VALUES
('AF', 'Afghanistan'),
('AL', 'Albanie'),
('DZ', 'Algérie'),
('AU', 'Australie'),
('AT', 'Austriche'),
('AZ', 'Azerbaijan'),
('BE', 'Belgique'),
('BR', 'Brésil'),
('CA', 'Canada'),
('CO', 'Colombie'),
('CG', 'Congo'),
('EG', 'Egypte'),
('FI', 'Finlande'),
('FR', 'France'),
('LU', 'Luxembourg'),
('NP', 'Népal'),
('NL', 'Pays-Bas'),
('RO', 'Roumanie'),
('RU', 'Russie'),
('TN', 'Tunisie'),
('TR', 'Turquie'),
('UA', 'Ukraine'),
('GB', 'Angleterre'),
('US', 'Etats-unis')
GO

CREATE TABLE Company (
	ID BIGINT NOT NULL IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	Address_line_1 VARCHAR(255) NOT NULL,
	Address_line_2 VARCHAR(255) DEFAULT NULL,
	ZipCode VARCHAR(32) NOT NULL,
	City VARCHAR(255) NOT NULL,
	Country_ID SMALLINT DEFAULT NULL, 
	Siren VARCHAR(9) DEFAULT NULL,
	Phone VARCHAR(14) NOT NULL,
	Fax VARCHAR(14) DEFAULT NULL,
	Mail VARCHAR(255) NOT NULL,
	CONSTRAINT PK_COMP PRIMARY KEY (ID),
	CONSTRAINT FK_COMP_COUN FOREIGN KEY (Country_ID) REFERENCES COUNTRY(ID)
)
GO


CREATE TABLE Invoice (
	ID BIGINT NOT NULL IDENTITY(1,1),
	Company_ID BIGINT NOT NULL,
	Amount DECIMAL(19, 4) NOT NULL,
	Created DATETIME2 NOT NULL,
	CONSTRAINT PK_CHAR PRIMARY KEY (ID),
	CONSTRAINT FK_INVO_COMP FOREIGN KEY (Company_ID) REFERENCES COMPANY(ID)
)
GO

INSERT INTO Invoice (Company_ID, Amount, Created) 
VALUES 
(1, CAST(41.0000 AS Decimal(19, 4)), N'2017-07-01 15:02:03'),
(1, CAST(12.0000 AS Decimal(19, 4)), N'2017-07-17 15:02:03'),
(1, CAST(145.0000 AS Decimal(19, 4)), N'2017-07-19 15:02:03'),
(1, CAST(84.1200 AS Decimal(19, 4)), N'2017-07-20 15:02:03'),
(1, CAST(17.5100 AS Decimal(19, 4)), N'2017-08-22 15:02:03'),
(1, CAST(32.0700 AS Decimal(19, 4)), N'2017-08-22 15:02:03'),
(1, CAST(44.1200 AS Decimal(19, 4)), N'2017-08-23 15:02:03')
GO

