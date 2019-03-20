
IF EXISTS(SELECT * FROM sys.tables WHERE name='ReservationAddOns')
	DROP TABLE ReservationAddOns
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Billing')
	DROP TABLE Billing
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='AddOns')
	DROP TABLE AddOns
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='AmenitiesInRoom')
	DROP TABLE AmenitiesInRoom
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Reservation')
	DROP TABLE Reservation
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Customer')
	DROP TABLE Customer
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Amenities')
	DROP TABLE Amenities
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Room')
	DROP TABLE Room
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='PromotionCodes')
	DROP TABLE PromotionCodes
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Rate')
	DROP TABLE Rate
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Season')
	DROP TABLE Season
GO



CREATE TABLE AddOns
(
	AddOnsId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	AddOnsName NVARCHAR(50) NOT NULL,
	Price MONEY NOT NULL
)
GO


CREATE TABLE Customer
(
	CustomerId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Email NVARCHAR(100) NOT NULL,
	PhoneNumber NVARCHAR(50) NOT NULL,
	Age INT NOT NULL,
)
GO

CREATE TABLE Amenities
(
	AmenitiesId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	AmenitiesName NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE PromotionCodes
(
	PromotionCodesId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Codes INT NOT NULL,
	DateBegin DATE NOT NULL,
	DateEnd DATE NOT NULL,
	Discount DECIMAL(5,2) NOT NULL
)
GO

CREATE TABLE Season
(
	SeasonId Int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PeakSeason Money NOT NULL,
	Conference Money NOT NULL,
	DateBegin Date NOT NULL,
	DateEnd Date NOT NULL
)
GO

CREATE TABLE Rate
(
	RateId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	SeasonId INT NULL,
	RoomPrice Money NOT NULL,
	DateBegin Date NOT NULL,
	DateEnd Date NOT NULL,
	CONSTRAINT fk_Rate_Season FOREIGN KEY (SeasonId)
		REFERENCES Season(SeasonId)
)
GO


CREATE TABLE Room
(
	RoomId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	RateId INT NOT NULL,
	FloorNumber INT NOT NULL,
	OccupancyLimit INT NOT NULL,
	RoomType NVARCHAR(50) NOT NULL,
	CONSTRAINT fk_Room_Rate FOREIGN KEY (RateId)
		REFERENCES Rate(RateId)
)
GO

CREATE TABLE AmenitiesInRoom
(
	
	RoomId INT NOT NULL,
	AmenitiesId INT NULL,
	CONSTRAINT fk_AmenitiesInRoom_Room FOREIGN KEY (RoomId)
		REFERENCES Room(RoomId),
	CONSTRAINT fk_AmenitiesInRoom_Amenities FOREIGN KEY (AmenitiesId)
		REFERENCES Amenities(AmenitiesId)
)
GO

CREATE TABLE Reservation
(
	ReservationId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CustomerId INT NOT NULL,
	RoomId INT NOT NULL,
	PromotionCodesId INT NULL,
	DateBegin Date NOT NULL,
	DateEnd Date NOT NULL,
	CONSTRAINT fk_Reservation_Customer FOREIGN KEY (CustomerId)
		REFERENCES Customer(CustomerId),
	CONSTRAINT fk_Reservation_Room FOREIGN KEY (RoomId)
		REFERENCES Room(RoomId),
	CONSTRAINT fk_Reservation_PromotionCodes FOREIGN KEY (PromotionCodesId)
		REFERENCES PromotionCodes(PromotionCodesId),
)
GO

CREATE TABLE Billing 
(
	BillingId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ReservationId INT NOT NULL,
	ReservationDate Date NOT NULL,
	Paid NVARCHAR(50) NULL,
	NotPaid NVARCHAR(50) NULL,
	TaxInfo DECIMAL (5,2) NOT NULL,
	CONSTRAINT fk_Billing_Reservation FOREIGN KEY(ReservationId)
		REFERENCES Reservation(ReservationId)
)
GO 

CREATE TABLE ReservationAddOns
(
	ReservationAddOnsId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	AddOnsId INT NULL,
	ReservationId INT NOT NULL,
	CONSTRAINT fk_RoomAddOns_AddOns FOREIGN KEY (AddOnsId)
		REFERENCES AddOns(AddOnsId),
	CONSTRAINT fk_RoomAddOns_Reservation FOREIGN KEY (ReservationId)
		REFERENCES Reservation(ReservationId)
)
GO















	
	

