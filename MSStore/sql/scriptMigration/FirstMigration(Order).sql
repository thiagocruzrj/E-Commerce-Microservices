IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(max) NULL,
    [TotalPrice] decimal(18,2) NOT NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [EmailAddress] nvarchar(max) NULL,
    [AddressLine] nvarchar(max) NULL,
    [Country] nvarchar(max) NULL,
    [State] nvarchar(max) NULL,
    [ZipCode] nvarchar(max) NULL,
    [CartName] nvarchar(max) NULL,
    [CardNumber] nvarchar(max) NULL,
    [Expiration] nvarchar(max) NULL,
    [CVV] nvarchar(max) NULL,
    [PaymentMethod] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200824184030_Initial', N'3.1.7');

GO

