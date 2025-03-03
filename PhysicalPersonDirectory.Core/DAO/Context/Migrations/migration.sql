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
    [PersonId] int NOT NULL,
    [RelatedPersonId] int NOT NULL,
    [RelationType] nvarchar(50) NOT NULL,
    [Id] int NOT NULL,
    CONSTRAINT [PK_RelatedPersons] PRIMARY KEY ([PersonId], [RelatedPersonId]),
    CONSTRAINT [FK_RelatedPersons_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_RelatedPersons_Person_RelatedPersonId] FOREIGN KEY ([RelatedPersonId]) REFERENCES [Person] ([Id]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[City]'))
    SET IDENTITY_INSERT [City] ON;
INSERT INTO [City] ([Id], [Name])
VALUES (1, N'თბილისი'),
(2, N'ქუთაისი'),
(3, N'ბათუმი'),
(4, N'რუსთავი'),
(5, N'გორი'),
(6, N'ზუგდიდი'),
(7, N'ფოთი'),
(8, N'თელავი'),
(9, N'ოზურგეთი'),
(10, N'ამბროლაური'),
(11, N'ახალციხე'),
(12, N'ახალქალაქი'),
(13, N'მარნეული'),
(14, N'გარდაბანი'),
(15, N'ბოლნისი'),
(16, N'დუშეთი'),
(17, N'საგარეჯო'),
(18, N'ლაგოდეხი'),
(19, N'ბორჯომი'),
(20, N'ცხინვალი'),
(21, N'ცაგერი'),
(22, N'ლენტეხი'),
(23, N'მესტია'),
(24, N'წალენჯიხა'),
(25, N'ჩხოროწყუ'),
(26, N'ხობი'),
(27, N'სენაკი'),
(28, N'მარტვილი'),
(29, N'ვანი'),
(30, N'ტყიბული'),
(31, N'ბაღდათი'),
(32, N'ხარაგაული'),
(33, N'საჩხერე'),
(34, N'ხონი'),
(35, N'ნინოწმინდა');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[City]'))
    SET IDENTITY_INSERT [City] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityId', N'DateOfPBirth', N'Gender', N'ImageSource', N'Name', N'PhoneNumber', N'Pid', N'Surname', N'TypeOfPhone') AND [object_id] = OBJECT_ID(N'[Person]'))
    SET IDENTITY_INSERT [Person] ON;
INSERT INTO [Person] ([Id], [CityId], [DateOfPBirth], [Gender], [ImageSource], [Name], [PhoneNumber], [Pid], [Surname], [TypeOfPhone])
VALUES (1, 1, '1985-11-25', N'Male', NULL, N'გიორგი', N'599123456', N'01001000001', N'აბაშიძე', N'Mobile'),
(2, 2, '1995-05-03', N'Female', NULL, N'მარიამ', N'577654321', N'01001000002', N'ბერიძე', N'Mobile'),
(3, 3, '2005-08-11', N'Male', NULL, N'ნიკოლოზ', N'2123456', N'01001000003', N'გიგაური', N'HousePhone'),
(4, 4, '1999-03-14', N'Female', NULL, N'ანა', N'322456789', N'01001000004', N'დავითაშვილი', N'OfficePhone'),
(5, 5, '1985-08-25', N'Male', NULL, N'დათო', N'555987654', N'01001000005', N'ელიზბარაშვილი', N'Mobile'),
(6, 6, '1998-02-24', N'Female', NULL, N'თეკლა', N'2323232', N'01001000006', N'ვანიშვილი', N'HousePhone'),
(7, 7, '1985-08-25', N'Male', NULL, N'ლუკა', N'344556677', N'01001000007', N'ზარანდია', N'OfficePhone'),
(8, 8, '1985-08-25', N'Female', NULL, N'ელენე', N'591112233', N'01001000008', N'თორდია', N'Mobile'),
(9, 9, '1985-08-25', N'Male', NULL, N'გიორგი', N'2667788', N'01001000009', N'კახიძე', N'HousePhone'),
(10, 10, '1985-08-25', N'Female', NULL, N'ნინო', N'355667788', N'01001000010', N'ლომიძე', N'OfficePhone');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityId', N'DateOfPBirth', N'Gender', N'ImageSource', N'Name', N'PhoneNumber', N'Pid', N'Surname', N'TypeOfPhone') AND [object_id] = OBJECT_ID(N'[Person]'))
    SET IDENTITY_INSERT [Person] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PersonId', N'RelatedPersonId', N'Id', N'RelationType') AND [object_id] = OBJECT_ID(N'[RelatedPersons]'))
    SET IDENTITY_INSERT [RelatedPersons] ON;
INSERT INTO [RelatedPersons] ([PersonId], [RelatedPersonId], [Id], [RelationType])
VALUES (1, 2, 1, N'Colleague'),
(3, 4, 2, N'Familiar'),
(5, 6, 3, N'Other'),
(7, 8, 4, N'Other'),
(9, 10, 5, N'Other');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PersonId', N'RelatedPersonId', N'Id', N'RelationType') AND [object_id] = OBJECT_ID(N'[RelatedPersons]'))
    SET IDENTITY_INSERT [RelatedPersons] OFF;
GO

CREATE UNIQUE INDEX [IX_Person_CityId] ON [Person] ([CityId]) WHERE [CityId] IS NOT NULL;
GO

CREATE UNIQUE INDEX [IX_Person_Pid] ON [Person] ([Pid]);
GO

CREATE INDEX [IX_RelatedPersons_RelatedPersonId] ON [RelatedPersons] ([RelatedPersonId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250302172749_Initial_Physical_Person_Context', N'8.0.13');
GO

COMMIT;
GO

