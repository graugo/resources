USE [master];

DECLARE @dbName NVARCHAR(MAX);
SET @dbName = N'AuctionDB'
DECLARE @killQuery NVARCHAR(MAX);
SET @killQuery = '';

SELECT @killQuery = @killQuery + 'KILL ' + CAST(session_id AS NVARCHAR(10)) + ';'
FROM sys.dm_exec_sessions WHERE database_id = DB_ID(@dbName);

IF LEN(@killQuery) > 0
	BEGIN 
		PRINT 'Killing processes using database [' + @dbName + ']'; 
		EXEC sp_executesql @killQuery;
	END 
ELSE 
	BEGIN 
		PRINT 'No processes found using database [' + @dbName + ']';
	END 

DROP DATABASE [AuctionDB];
CREATE DATABASE [AuctionDB];
USE [AuctionDB];

CREATE TABLE [Locations] (
    [LocationIdentifier] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY ([LocationIdentifier])
);
CREATE TABLE [Pokemon] (
    [PokemonIdentifier] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Weight] int NOT NULL,
    [Height] int NOT NULL,
    CONSTRAINT [PK_Pokemon] PRIMARY KEY ([PokemonIdentifier])
);
CREATE TABLE [PokemonLocation] (
    [Id] int NOT NULL IDENTITY,
    [Level] int NOT NULL,
    [MaxChance] int NOT NULL,
    [PokemonId] int NOT NULL,
    [LocationId] int NOT NULL,
    CONSTRAINT [PK_PokemonLocation] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PokemonLocation_Locations_LocationId] FOREIGN KEY ([LocationId]) REFERENCES [Locations] ([LocationIdentifier]) ON DELETE CASCADE,
    CONSTRAINT [FK_PokemonLocation_Pokemon_PokemonId] FOREIGN KEY ([PokemonId]) REFERENCES [Pokemon] ([PokemonIdentifier]) ON DELETE CASCADE
);
CREATE TABLE [Auctions] (
    [AuctionId] int NOT NULL IDENTITY,
    [AuctionName] nvarchar(max) NOT NULL,
    [EntryPrice] decimal(18,2) NOT NULL,
    [ActualPrice] decimal(18,2) NOT NULL,
    [NumberBid] int NOT NULL,
    [Created] time NOT NULL,
    [PokemonLocationId] int NOT NULL,
    [IsShiny] bit NOT NULL,
    CONSTRAINT [PK_Auctions] PRIMARY KEY ([AuctionId]),
    CONSTRAINT [FK_Auctions_PokemonLocation_PokemonLocationId] FOREIGN KEY ([PokemonLocationId]) REFERENCES [PokemonLocation] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [Historic] (
    [HistoricId] int NOT NULL IDENTITY,
    [Sold] bit NOT NULL,
    [AuctionId] int NOT NULL,
    CONSTRAINT [PK_Historic] PRIMARY KEY ([HistoricId]),
    CONSTRAINT [FK_Historic_Auctions_AuctionId] FOREIGN KEY ([AuctionId]) REFERENCES [Auctions] ([AuctionId]) ON DELETE CASCADE
);
CREATE TABLE [Transactions] (
    [Id] int NOT NULL IDENTITY,
    [OriginalValue] int NOT NULL,
    [Increment] int NOT NULL,
    [FinalValue] int NOT NULL,
    [AuctionId] int NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transactions_Auctions_AuctionId] FOREIGN KEY ([AuctionId]) REFERENCES [Auctions] ([AuctionId]) ON DELETE CASCADE
);