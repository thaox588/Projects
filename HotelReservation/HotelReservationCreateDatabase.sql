USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='HotelReservation')
DROP DATABASE HotelReservation
GO

CREATE DATABASE HotelReservation
GO

USE HotelReservation
GO