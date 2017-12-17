ALTER TABLE [dbo].[Category]
DROP CONSTRAINT [FK_ParentIdCategory];
GO

ALTER TABLE [dbo].[CategoryNotice]
DROP CONSTRAINT [FK_CategoryNotice_Notice], [FK_CategoryNotice_Category];
GO

DROP TABLE [dbo].[Category];
DROP TABLE [dbo].[Notice];
DROP TABLE [dbo].[CategoryNotice];
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






