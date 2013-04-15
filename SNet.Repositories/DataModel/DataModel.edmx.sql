
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/15/2013 14:01:30
-- Generated from EDMX file: C:\Users\antb\Documents\GitHub\SNet\SNet.Repositories\DataModel\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SNet];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AccountsTerms]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Terms] DROP CONSTRAINT [FK_AccountsTerms];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Permissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permissions];
GO
IF OBJECT_ID(N'[dbo].[AccountPermissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountPermissions];
GO
IF OBJECT_ID(N'[dbo].[Terms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Terms];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(30)  NOT NULL,
    [LastName] nvarchar(30)  NOT NULL,
    [Email] nvarchar(150)  NOT NULL,
    [EmailVerified] bit  NOT NULL,
    [Username] nvarchar(30)  NOT NULL,
    [Password] nvarchar(30)  NOT NULL,
    [BirthDate] datetime  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [LastUpdateDate] datetime  NOT NULL,
    [Timestamp] time  NOT NULL,
    [TermId] int  NULL,
    [AgreedToTermsDate] datetime  NOT NULL
);
GO

-- Creating table 'Permissions'
CREATE TABLE [dbo].[Permissions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Timestamp] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AccountPermissions'
CREATE TABLE [dbo].[AccountPermissions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AccoutId] nvarchar(max)  NOT NULL,
    [PermissionId] nvarchar(max)  NOT NULL,
    [Timestamp] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Terms'
CREATE TABLE [dbo].[Terms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Terms] nvarchar(255)  NOT NULL,
    [Timestamp] nvarchar(max)  NOT NULL,
    [AccountsId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Permissions'
ALTER TABLE [dbo].[Permissions]
ADD CONSTRAINT [PK_Permissions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AccountPermissions'
ALTER TABLE [dbo].[AccountPermissions]
ADD CONSTRAINT [PK_AccountPermissions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Terms'
ALTER TABLE [dbo].[Terms]
ADD CONSTRAINT [PK_Terms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccountsId] in table 'Terms'
ALTER TABLE [dbo].[Terms]
ADD CONSTRAINT [FK_AccountsTerms]
    FOREIGN KEY ([AccountsId])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountsTerms'
CREATE INDEX [IX_FK_AccountsTerms]
ON [dbo].[Terms]
    ([AccountsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------