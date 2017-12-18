ALTER TABLE [dbo].[Category]
DROP CONSTRAINT [FK_ParentIdCategory];
GO

ALTER TABLE [dbo].[CategoryNotice]
DROP CONSTRAINT [FK_CategoryNotice_Notice], [FK_CategoryNotice_Category];
GO

ALTER TABLE [dbo].[CategoryAttribute]
DROP CONSTRAINT [FK_CategoryAttribute_Category], [FK_CategoryAttribute_Attribute];
GO

DROP TABLE [dbo].[Category];
DROP TABLE [dbo].[Notice];
DROP TABLE [dbo].[Attribute];
DROP TABLE [dbo].[CategoryNotice];
DROP TABLE [dbo].[CategoryAttribute];
GO



------ Creating table 'Category'
CREATE TABLE [dbo].[Category] (
	[Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255) NOT NULL,
	[ParentId] bigint CONSTRAINT [FK_ParentIdCategory] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Category] ([Id])
	CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

------ Creating table 'Notice'
CREATE TABLE [dbo].[Notice] (
	[Id] bigint IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(255) NOT NULL,
	[Description] nvarchar(max) NOT NULL,
	[ImageUrl] nvarchar(max) NOT NULL,
	[Created] datetime NOT NULL,
	CONSTRAINT [PK_Notice] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

------ Creating table 'CategoryNotice'
CREATE TABLE [dbo].[CategoryNotice] (
	[NoticeId] bigint CONSTRAINT [FK_CategoryNotice_Notice] FOREIGN KEY ([NoticeId]) REFERENCES [dbo].[Notice] ([Id]) NOT NULL,
    [CategoryId] bigint CONSTRAINT [FK_CategoryNotice_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]) NOT NULL,
	CONSTRAINT [PK_CategoryNotice] PRIMARY KEY CLUSTERED ([CategoryId], [NoticeId] ASC) 
);
GO

------ Creating table 'Attribute'
CREATE TABLE [dbo].[Attribute] (
	[Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255) NOT NULL,
	[Type] tinyint NOT NULL,
	CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED ([Id] ASC) 
);
GO

------ Creating table 'CategoryAttribute'
CREATE TABLE [dbo].[CategoryAttribute] (
    [CategoryId] bigint CONSTRAINT [FK_CategoryAttribute_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]) NOT NULL,
	[AttributeId] bigint CONSTRAINT [FK_CategoryAttribute_Attribute] FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[Attribute] ([Id]) NOT NULL,
	CONSTRAINT [PK_CategoryAttribute] PRIMARY KEY CLUSTERED ([CategoryId], [AttributeId] ASC) 
);
GO




INSERT INTO [dbo].[Category] VALUES('Motoryzacja', NULL);
GO
INSERT INTO [dbo].[Category] VALUES('Motocykle', 1);
INSERT INTO [dbo].[Category] VALUES('Samochody', 1);
GO
INSERT INTO [dbo].[Category] VALUES('Osobowe', 3);
INSERT INTO [dbo].[Category] VALUES('Dostawcze', 3);
INSERT INTO [dbo].[Category] VALUES('Ciê¿arowe', 3);
INSERT INTO [dbo].[Category] VALUES('Autobusy', 3);
GO
INSERT INTO [dbo].[Category] VALUES('Choppery', 2);
INSERT INTO [dbo].[Category] VALUES('Sportowe', 2);
INSERT INTO [dbo].[Category] VALUES('Turystyczne', 2);
INSERT INTO [dbo].[Category] VALUES('Motorynki', 2);
GO

INSERT INTO [dbo].[Notice] VALUES('Opel Astra', 'Spania³y samochud ca³e te', 'https://www.wykop.pl/cdn/c3201142/comment_mbcJXppfFzKLE0sOC0ZioaRbd4cuJsGj.jpg', GETDATE());
INSERT INTO [dbo].[Notice] VALUES('Jakiœ autobus', 'Dobry, niemiecki', 'http://peterbus.pl/wp-content/uploads/sprzeda%C5%BC-autobus%C3%B3w-04.jpg', GETDATE()-2);
INSERT INTO [dbo].[Notice] VALUES('Harley Davidson Fat Boy CVO 103', 'Witam.Sprzedam ³adnego fat boya w  wersji CVO ( Custom Vehicle Operation). Zaznaczam ze jest to orgina³. Silnik 103 cale screamin eagle.', 'http://www.1199forums.com/forum/images/dto_garage/users/331/1030.jpg', GETDATE());
INSERT INTO [dbo].[Notice] VALUES('Motorower Komar', 'Motorower sprawny oplacony . Tel.503 320 337(sms gdy nie odbieram oddzwonie)', 'https://spplthumb.blob.core.windows.net/1000x901c/b7/4d/d7/komar-3-benzyna-kujawsko-pomorskie-inowroclaw-344349427.jpg', GETDATE());
GO

INSERT INTO [dbo].[CategoryNotice] VALUES(1, 4);
INSERT INTO [dbo].[CategoryNotice] VALUES(2, 7);
INSERT INTO [dbo].[CategoryNotice] VALUES(3, 8);
INSERT INTO [dbo].[CategoryNotice] VALUES(4, 11);
GO

INSERT INTO [dbo].[Attribute] VALUES('Vehicle mileage', 1);
INSERT INTO [dbo].[Attribute] VALUES('Brand', 1);
INSERT INTO [dbo].[Attribute] VALUES('Model', 1);
INSERT INTO [dbo].[Attribute] VALUES('Color', 1);
INSERT INTO [dbo].[Attribute] VALUES('Year of production', 1);
GO

INSERT INTO [dbo].[CategoryAttribute] VALUES(1, 1);
INSERT INTO [dbo].[CategoryAttribute] VALUES(1, 2);
INSERT INTO [dbo].[CategoryAttribute] VALUES(1, 3);
INSERT INTO [dbo].[CategoryAttribute] VALUES(1, 4);
INSERT INTO [dbo].[CategoryAttribute] VALUES(1, 5);
GO
