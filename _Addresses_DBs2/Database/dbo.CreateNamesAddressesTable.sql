CREATE TABLE [dbo].[NameAddressTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [DwellingNumber] VARCHAR(5) NOT NULL, 
    [Apartment] VARCHAR(2) NULL, 
    [StreetName] VARCHAR(50) NOT NULL, 
    [StreetType] VARCHAR(4) NOT NULL, 
    [Town] VARCHAR(50) NOT NULL, 
    [State] CHAR(2) NOT NULL, 
    [Zip] CHAR(5) NOT NULL
)
