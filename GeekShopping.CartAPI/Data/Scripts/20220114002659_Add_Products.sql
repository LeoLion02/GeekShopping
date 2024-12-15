CREATE TABLE [Product] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(128) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [Description] nvarchar(500) NOT NULL,
    [CategoryName] nvarchar(max) NOT NULL,
    [ImageUrl] nvarchar(300) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
);
GO


