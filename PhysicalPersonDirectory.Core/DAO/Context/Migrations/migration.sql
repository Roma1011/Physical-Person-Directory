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

CREATE TABLE [City] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_City] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Person] (
    [Id] int NOT NULL IDENTITY,
    [Pid] nvarchar(450) NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Surname] nvarchar(50) NOT NULL,
    [TypeOfPhone] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(50) NULL,
    [ImageSource] nvarchar(max) NULL,
    [Gender] nvarchar(10) NOT NULL,
    [DateOfPBirth] date NOT NULL,
    [CityId] int NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [FK_Person_City_CityId] FOREIGN KEY ([CityId]) REFERENCES [City] ([Id]) ON DELETE SET NULL
);
GO

CREATE TABLE [RelatedPersons] (
    [Id] int NOT NULL IDENTITY,
    [PersonId] int NOT NULL,
    [RelatedPersonId] int NOT NULL,
    CONSTRAINT [PK_RelatedPersons] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RelatedPersons_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_RelatedPersons_Person_RelatedPersonId] FOREIGN KEY ([RelatedPersonId]) REFERENCES [Person] ([Id]) ON DELETE NO ACTION
);
GO

CREATE UNIQUE INDEX [IX_Person_CityId] ON [Person] ([CityId]) WHERE [CityId] IS NOT NULL;
GO

CREATE UNIQUE INDEX [IX_Person_Pid] ON [Person] ([Pid]);
GO

CREATE INDEX [IX_RelatedPersons_PersonId] ON [RelatedPersons] ([PersonId]);
GO

CREATE INDEX [IX_RelatedPersons_RelatedPersonId] ON [RelatedPersons] ([RelatedPersonId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250227104055_Initial_Physical_Person_Context', N'8.0.13');
GO

COMMIT;
GO

