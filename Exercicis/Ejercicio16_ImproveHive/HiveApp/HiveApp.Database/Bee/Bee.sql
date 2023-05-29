CREATE TABLE [dbo].[bee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(0, 1),
	[Name] VARCHAR(25) NOT NULL, 
    [Recolection] DECIMAL, 
    [Time] BIGINT NULL, 
    [State] BIT NULL, 
    [Incidents] INT NULL,


)
