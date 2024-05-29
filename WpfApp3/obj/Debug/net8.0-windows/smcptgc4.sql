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

CREATE TABLE [Categorii] (
    [CategorieId] int NOT NULL IDENTITY,
    [Nume] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Categorii] PRIMARY KEY ([CategorieId])
);
GO

CREATE TABLE [Producatori] (
    [ProducatorId] int NOT NULL IDENTITY,
    [Nume] nvarchar(max) NOT NULL,
    [TaraDeOrigine] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Producatori] PRIMARY KEY ([ProducatorId])
);
GO

CREATE TABLE [Utilizatori] (
    [UtilizatorId] int NOT NULL IDENTITY,
    [Nume] nvarchar(max) NOT NULL,
    [Parola] nvarchar(max) NOT NULL,
    [TipUtilizator] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Utilizatori] PRIMARY KEY ([UtilizatorId])
);
GO

CREATE TABLE [Produse] (
    [ProdusId] int NOT NULL IDENTITY,
    [Nume] nvarchar(max) NOT NULL,
    [CodDeBare] nvarchar(max) NOT NULL,
    [CategorieId] int NOT NULL,
    [ProducatorId] int NOT NULL,
    CONSTRAINT [PK_Produse] PRIMARY KEY ([ProdusId]),
    CONSTRAINT [FK_Produse_Categorii_CategorieId] FOREIGN KEY ([CategorieId]) REFERENCES [Categorii] ([CategorieId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Produse_Producatori_ProducatorId] FOREIGN KEY ([ProducatorId]) REFERENCES [Producatori] ([ProducatorId]) ON DELETE CASCADE
);
GO

CREATE TABLE [BonuriCasa] (
    [BonCasaId] int NOT NULL IDENTITY,
    [DataEliberarii] datetime2 NOT NULL,
    [CasierId] int NOT NULL,
    [SumaIncasata] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_BonuriCasa] PRIMARY KEY ([BonCasaId]),
    CONSTRAINT [FK_BonuriCasa_Utilizatori_CasierId] FOREIGN KEY ([CasierId]) REFERENCES [Utilizatori] ([UtilizatorId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ProdusVandut] (
    [IdProdusVandut] int NOT NULL IDENTITY,
    [ProdusId] int NOT NULL,
    [Cantitate] int NOT NULL,
    [Subtotal] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ProdusVandut] PRIMARY KEY ([IdProdusVandut]),
    CONSTRAINT [FK_ProdusVandut_Produse_ProdusId] FOREIGN KEY ([ProdusId]) REFERENCES [Produse] ([ProdusId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Stocuri] (
    [StocId] int NOT NULL IDENTITY,
    [ProdusId] int NOT NULL,
    [Cantitate] decimal(18,2) NOT NULL,
    [UnitateDeMasura] nvarchar(max) NOT NULL,
    [DataAprovizionarii] datetime2 NOT NULL,
    [DataExpirarii] datetime2 NOT NULL,
    [PretAchizitie] decimal(18,2) NOT NULL,
    [PretVanzare] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Stocuri] PRIMARY KEY ([StocId]),
    CONSTRAINT [FK_Stocuri_Produse_ProdusId] FOREIGN KEY ([ProdusId]) REFERENCES [Produse] ([ProdusId]) ON DELETE CASCADE
);
GO

CREATE TABLE [BonuriCasaDetalii] (
    [BonCasaDetaliuId] int NOT NULL IDENTITY,
    [BonCasaId] int NOT NULL,
    [ProdusId] int NOT NULL,
    [Cantitate] decimal(18,2) NOT NULL,
    [Subtotal] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_BonuriCasaDetalii] PRIMARY KEY ([BonCasaDetaliuId]),
    CONSTRAINT [FK_BonuriCasaDetalii_BonuriCasa_BonCasaId] FOREIGN KEY ([BonCasaId]) REFERENCES [BonuriCasa] ([BonCasaId]) ON DELETE CASCADE,
    CONSTRAINT [FK_BonuriCasaDetalii_Produse_ProdusId] FOREIGN KEY ([ProdusId]) REFERENCES [Produse] ([ProdusId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_BonuriCasa_CasierId] ON [BonuriCasa] ([CasierId]);
GO

CREATE INDEX [IX_BonuriCasaDetalii_BonCasaId] ON [BonuriCasaDetalii] ([BonCasaId]);
GO

CREATE INDEX [IX_BonuriCasaDetalii_ProdusId] ON [BonuriCasaDetalii] ([ProdusId]);
GO

CREATE INDEX [IX_Produse_CategorieId] ON [Produse] ([CategorieId]);
GO

CREATE INDEX [IX_Produse_ProducatorId] ON [Produse] ([ProducatorId]);
GO

CREATE INDEX [IX_ProdusVandut_ProdusId] ON [ProdusVandut] ([ProdusId]);
GO

CREATE INDEX [IX_Stocuri_ProdusId] ON [Stocuri] ([ProdusId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240521142645_InitialMakeupDB', N'8.0.4');
GO

COMMIT;
GO

