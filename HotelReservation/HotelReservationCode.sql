USE HotelReservation
GO


INSERT INTO Customer (FirstName, LastName, Email, PhoneNumber, Age) VALUES
	('Jake', 'Jackson', 'JJackson@gmail.com', '651-555-1234', 20),
	('Kao', 'Chang', 'KChang@hotmail.com', '651-621-9713', 24),
	('MaiNou', 'Chang', 'MChang@yahoo.com', '651-546-7891', 20),
	('Ape', 'Handsome', 'ApeHandsome@gmail.com', '612-888-9419', 25),
	('Austin', 'Kan', 'KanAustin@outlook.com', '651-946-1289', 19),
	('Neo', 'Love', 'NeoLove@gmail.com', '763-459-7899', 30)

DELETE FROM Customer
WHERE PhoneNumber = 651-555-1234
DELETE FROM Customer
WHERE PhoneNumber = 651-621-9713
DELETE FROM Customer
WHERE PhoneNumber = 651-546-7891
DELETE FROM Customer
WHERE PhoneNumber = 612-888-9419
DELETE FROM Customer
WHERE PhoneNumber = 651-946-1289
DELETE FROM Customer
WHERE PhoneNumber = 763-459-7899

UPDATE Customer SET
	--PhoneNumber = '763-459-7899'
	--PhoneNumber = '651-946-1289'
	--PhoneNumber = '612-888-9419'
	--PhoneNumber = '651-546-7891'
	--PhoneNumber = '651-621-9713'
	PhoneNumber = '651-555-1234'
WHERE CustomerId = 6
SELECT *
From Customer

DROP TABLE Reservation
DROP TABLE Billing
DROP TABLE Customer
DROP TABLE PromotionCodes
DROP TABLE RoomAddOns

INSERT INTO AddOns (AddOnsName, Price) VALUES --change
	('Food', 10),
	('Beverage', 3),
	('Alcoholic', 8),
	('Movie', 2),
	('Laundry', 5)


SELECT *
FROM AddOns

INSERT INTO Room (RateId, FloorNumber, OccupancyLimit, RoomType) VALUES
	(1, 1, 1, 'Single'),
	(2, 2, 1, 'Single'),
	(3, 3, 1, 'Single'),
	(4, 4, 2, 'Double'),
	(5, 5, 2, 'Double'),
	(6, 6, 2, 'Double'),
	(7, 7, 4, 'King'),
	(8, 8, 6, 'Double King'),
	(9, 9, 10, 'Suite'),
	(10, 10, 10, 'Suite')

SELECT *
FROM Room

DROP TABLE AddOns
DROP TABLE Room 
DROP TABLE ReservationAddOns 
DROP TABLE Reservation

INSERT INTO Amenities (AmenitiesName) VALUES --change
	('Fidge'),
	('SpaBath'),
	('Mirowave'),
	('Sofa'),
	('TV')

SELECT *
FROM Amenities

INSERT INTO AmenitiesInRoom (RoomId, AmenitiesId) VALUES
	(2, Null),
	(3, 3),
	(3, 1),
	(4, 1),
	(4, 3),
	(4, 5),
	(5, 1),
	(5, 3),
	(5, 5),
	(6, 1),
	(6, 3),
	(6, 5),
	(7, 1),
	(7, 2),
	(7, 3),
	(7, 4),
	(7, 5),
	(8, 1),
	(8, 2),
	(8, 3),
	(8, 4),
	(8, 5),
	(9, 1),
	(9, 2),
	(9, 3),
	(9, 4),
	(9, 5),
	(10, 1),
	(10, 2),
	(10, 3),
	(10, 4),
	(10, 5),
	(11, 1),
	(11, 2),
	(11, 3),
	(11, 4),
	(11, 5)

DROP TABLE AmenitiesInRoom
DROP TABLE Amenities
SELECT *
FROM AmenitiesInRoom

INSERT INTO ReservationAddOns (AddOnsId, ReservationId) VALUES
	(1, 8),
	(2, 8),
	(4, 8),
	(2, 5),
	(3, 5),
	(NULL, 10),
	(3, 3),
	(5, 7),
	(4, 7),
	(2, 3)

SELECT *
FROM ReservationAddOns

INSERT INTO Reservation (CustomerId, RoomId, PromotionCodesId, DateBegin, DateEnd) VALUES
	(2, 5, 1, '06-16-2019', '06-19-2019'),
	(5, 10, 3, '12-12-2019', '12-25-2019'),
	(2, 5, 1, '06-16-2020', '06-19-2020'),
	(3, 2, NULL, '01-02-2019', '2-01-2019'),
	(6, 7, 2, '07-16-2019', '07-17-2019'),
	(4, 3, NULL, '02-14-2019', '02-16-2019'),
	(1, 9, 1, '06-16-2019', '06-19-2019'),
	(5, 10, 3, '12-20-2019', '12-25-2019'),
	(6, 8, NULL, '08-16-2019', '08-17-2019'),
	(6, 6, NULL, '08-16-2019', '08-17-2019')

SELECT *
FROM Reservation
	 

INSERT INTO Season (PeakSeason, Conference, DateBegin, DateEnd) VALUES --roomid
	(120, 80, '11-01-2019', '04-01-2020'),
	(130, 90, '11-01-2019', '04-01-2020'),
	(140, 100, '11-01-2019', '04-01-2020'),
	(150, 110, '11-01-2019', '04-01-2020'),
	(160, 120, '11-01-2019', '04-01-2020'),
	(170, 130, '11-01-2019', '04-01-2020'),
	(180, 140, '11-01-2019', '04-01-2020'),
	(190, 150, '11-01-2019', '04-01-2020'),
	(200, 160, '11-01-2019', '04-01-2020'),
	(210, 170, '11-01-2019', '04-01-2020')

DROP TABLE Season
DROP TABLE Rate
DROP TABLE Room
DROP TABLE RoomAddOns
DROP TABLE Reservation


SELECT *
FROM Season

INSERT INTO Rate (SeasonId, RoomPrice, DateBegin, DateEnd) VALUES
	(1, 60, '04-01-2019', '10-31-2019'),
	(2, 75, '04-01-2019', '10-31-2019'),
	(3, 80, '04-01-2019', '10-31-2019'),
	(4, 100, '04-01-2019', '10-31-2019'),
	(5, 100, '04-01-2019', '10-31-2019'),
	(6, 110, '04-01-2019', '10-31-2019'),
	(7, 120, '04-01-2019', '10-31-2019'),
	(8, 125, '04-01-2019', '10-31-2019'),
	(9, 125, '04-01-2019', '10-31-2019'),
	(10, 130, '04-01-2019', '10-31-2019')

SELECT *
FROM Rate

INSERT INTO PromotionCodes (Codes,DateBegin, DateEnd, Discount) VALUES --code
	(25, '06-15-2019', '6-30-2019', .25),
	(30, '07-01-2019', '8-01-2019', .30),
	(50, '12-01-2019', '1-01-2020', .50)

DROP TABLE Reservation
DROP TABLE PromotionCodes
DROP TABLE Billing
SELECT *
FROM PromotionCodes

INSERT INTO Billing (ReservationId, ReservationDate, Paid, NotPaid, TaxInfo) VALUES
	(1, '06-16-2019', NULL, 'NotPaid', 11.85),
	(2, '12-12-2019', NULL, 'NotPaid', 11.85),
	(3, '06-16-2019', 'Paid', NULL, 11.85),
	(4, '01-02-2019', 'Paid', NULL, 11.85),
	(5, '07-16-2019', 'Paid', NULL, 11.85),
	(6, '02-14-2019', NULL, 'NotPaid', 11.85),
	(7, '06-16-2019', 'Paid', NULL, 11.85),
	(8, '12-20-2019', NULL, 'NotPaid', 11.85),
	(9, '08-16-2019', 'Paid', NULL, 11.85),
	(10, '08-16-2019', NULL, 'NotPaid', 11.85)

DROP TABLE Billing
DROP TABLE RoomAddOns
SELECT *
FROM Billing

SELECT *
FROM Reservation
WHERE DateEnd < '2-25-2019'

SELECT *
FROM Reservation
WHERE CustomerId = 2

SELECT *
FROM AmenitiesInRoom
WHERE AmenitiesId Is NULL
Order BY RoomId ASC

SELECT *
FROM PromotionCodes
LEFT JOIN Reservation ON
PromotionCodes.PromotionCodesId = Reservation.PromotionCodesId

SELECT 
	COUNT(r.PromotionCodesId) as TotalPromotionUse
FROM Reservation r
LEFT JOIN PromotionCodes ON
r.PromotionCodesId = PromotionCodes.PromotionCodesId
WHERE r.PromotionCodesId = 3

SELECT PromotionCodes.PromotionCodesId
FROM PromotionCodes
INNER JOIN Reservation ON
PromotionCodes.PromotionCodesId = Reservation.PromotionCodesId
ORDER BY PromotionCodesId desc
--WHERE Reservation.DateBegin BETWEEN '6-15-2019' AND '12-01-2019'

SELECT TOP (3) *
FROM Reservation r
ORDER BY r.RoomId DESC

SELECT * 
FROM PromotionCodes  
INNER JOIN Reservation ON
PromotionCodes.PromotionCodesId = Reservation.PromotionCodesId
WHERE RoomId NOT IN  
 (SELECT RoomId as RoomId From Reservation  
  WHERE DateBegin BETWEEN '6-01-2019' AND '7-01-2019'
 )