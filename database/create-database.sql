IF DB_ID(N'LibraryService') IS NULL
BEGIN
    CREATE DATABASE [LibraryService];
END
GO

USE [LibraryService];
GO

CREATE TABLE BookCategories (
    Id uniqueidentifier NOT NULL,
    BookId uniqueidentifier NOT NULL,
    CategoryId uniqueidentifier NOT NULL
);

