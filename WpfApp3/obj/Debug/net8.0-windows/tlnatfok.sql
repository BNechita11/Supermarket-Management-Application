IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [BonuriDeCasa] (
    [IdBon] int NOT NULL IDENTITY,
    [DataEliberare] datetime2 NOT NULL,
    [Casier] nvarchar(max) NOT NULL,
    [SumaIncasata] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_BonuriDeCasa] PRIMARY KEY ([IdBon])
);
GO

CREATE TABLE [Categorii] (
    [IdCategorie] int NOT NULL IDENTITY,
    [TipCategorie] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Categorii] PRIMARY KEY ([IdCategorie])
);
GO

CREATE TABLE [Oferte] (
    [IdOferta] int NOT NULL IDENTITY,
    [MotivOferta] nvarchar(max) NOT NULL,
    [ProdusId] int NOT NULL,
    [ProcentReducere] decimal(18,2) NOT NULL,
    [DataInceput] datetime2 NOT NULL,
    [DataSfarsit] datetime2 NOT NULL,
    CONSTRAINT [PK_Oferte] PRIMARY KEY ([IdOferta])
);
GO

CREATE TABLE [Producatori] (
    [IdProducator] int NOT NULL IDENTITY,
    [Nume] nvarchar(max) NOT NULL,
    [OriginCountry] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Producatori] PRIMARY KEY ([IdProducator])
);
GO

CREATE TABLE [StocuriProduse] (
    [Id] int NOT NULL IDENTITY,
    [ProdusId] int NOT NULL,
    [Cantitate] int NOT NULL,
    [UnitateMasura] nvarchar(max) NOT NULL,
    [DataAprovizionare] datetime2 NOT NULL,
    [DataExpirare] datetime2 NOT NULL,
    [PretAchizitie] decimal(18,2) NOT NULL,
    [PretVanzare] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_StocuriProduse] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Utilizatori] (
    [Id] int NOT NULL IDENTITY,
    [NumeUtilizator] nvarchar(max) NOT NULL,
    [Parola] nvarchar(max) NOT NULL,
    [TipUtilizator] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Utilizatori] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Produse] (
    [IdProdus] int NOT NULL IDENTITY,
    [Nume] nvarchar(max) NOT NULL,
    [Barcode] nvarchar(max) NOT NULL,
    [IdCategoria] int NOT NULL,
    [IdProducator] int NOT NULL,
    [CategoriaIdCategorie] int NOT NULL,
    [ProducatorIdProducator] int NOT NULL,
    CONSTRAINT [PK_Produse] PRIMARY KEY ([IdProdus]),
    CONSTRAINT [FK_Produse_Categorii_CategoriaIdCategorie] FOREIGN KEY ([CategoriaIdCategorie]) REFERENCES [Categorii] ([IdCategorie]) ON DELETE CASCADE,
    CONSTRAINT [FK_Produse_Producatori_ProducatorIdProducator] FOREIGN KEY ([ProducatorIdProducator]) REFERENCES [Producatori] ([IdProducator]) ON DELETE CASCADE
);
GO

CREATE TABLE [ProdusVandut] (
    [IdProdusVandut] int NOT NULL IDENTITY,
    [ProdusId] int NOT NULL,
    [Cantitate] int NOT NULL,
    [Subtotal] decimal(18,2) NOT NULL,
    [BonIdBon] int NULL,
    CONSTRAINT [PK_ProdusVandut] PRIMARY KEY ([IdProdusVandut]),
    CONSTRAINT [FK_ProdusVandut_BonuriDeCasa_BonIdBon] FOREIGN KEY ([BonIdBon]) REFERENCES [BonuriDeCasa] ([IdBon]),
    CONSTRAINT [FK_ProdusVandut_Produse_ProdusId] FOREIGN KEY ([ProdusId]) REFERENCES [Produse] ([IdProdus]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Produse_CategoriaIdCategorie] ON [Produse] ([CategoriaIdCategorie]);
GO

CREATE INDEX [IX_Produse_ProducatorIdProducator] ON [Produse] ([ProducatorIdProducator]);
GO

CREATE INDEX [IX_ProdusVandut_BonIdBon] ON [ProdusVandut] ([BonIdBon]);
GO

CREATE INDEX [IX_ProdusVandut_ProdusId] ON [ProdusVandut] ([ProdusId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240514200927_InitialMakeupDB', N'8.0.4');
GO

COMMIT;
GO

