CREATE DATABASE [NetflixAPI]
GO
USE [NetflixAPI]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/******   Tablas Administrativas    ******/
CREATE TABLE [dbo].[BranchOffices](
	[BranchOfficeId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[BusinessId] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Phone] [varchar](100) NOT NULL,
	[State] [int] NOT NULL,
PRIMARY KEY CLUSTERED
(
	[BranchOfficeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Business](
	[BusinessId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[Ruc] [varchar](11) NOT NULL,
	[BusinessName] [varchar](100) NOT NULL,
	[Logo] [varchar](max) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Phone] [varchar](100) NOT NULL,
	[Vision] [varchar](max) NULL,
	[Mision] [varchar](max) NULL,
	[State] [int] NOT NULL,
PRIMARY KEY CLUSTERED
(
	[BusinessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[DocumentTypeId] [int] NOT NULL,
	[DocumentNumber] [varchar](20) NULL,
	[Address] [varchar](max) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](255) NULL,
	[State] [int] NOT NULL,
	[AuditCreateUser] [int] NOT NULL,
	[AuditCreateDate] [datetime2](7) NOT NULL,
	[AuditUpdateUser] [int] NULL,
	[AuditUpdateDate] [datetime2](7) NULL,
	[AuditDeleteUser] [int] NULL,
	[AuditDeleteDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[ProvinceId] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[State] [int] NOT NULL,
PRIMARY KEY CLUSTERED
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuRoles](
	[MenuRolId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[MenuId] [int] NULL,
	[State] [int] NULL,
PRIMARY KEY CLUSTERED
(
	[MenuRolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[Icon] [varchar](50) NULL,
	[URL] [varchar](150) NULL,
	[FatherId] [int] NULL,
	[State] [int] NULL,
PRIMARY KEY CLUSTERED
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provinces](
	[ProvinceId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[State] [int] NOT NULL,
PRIMARY KEY CLUSTERED
(
	[ProvinceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDetails](
	[PurchaseDetailId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[AuditCreateUser] [int] NOT NULL,
	[AuditCreateDate] [datetime2](7) NOT NULL,
	[AuditUpdateUser] [int] NULL,
	[AuditUpdateDate] [datetime2](7) NULL,
	[AuditDeleteUser] [int] NULL,
	[AuditDeleteDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED
(
	[PurchaseDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchases](
	[PurchaseId] [int] IDENTITY(1,1) NOT NULL,
	[ProviderId] [int] NULL,
	[UserId] [int] NULL,
	[PurchaseDate] [datetime2](7) NULL,
	[Tax] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[State] [int] NULL,
	[AuditCreateUser] [int] NOT NULL,
	[AuditCreateDate] [datetime2](7) NOT NULL,
	[AuditUpdateUser] [int] NULL,
	[AuditUpdateDate] [datetime2](7) NULL,
	[AuditDeleteUser] [int] NULL,
	[AuditDeleteDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED
(
	[PurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
	[State] [int] NULL,
PRIMARY KEY CLUSTERED
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleDetails](
	[SaleDetailId] [int] IDENTITY(1,1) NOT NULL,
	[SaleId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[AuditCreateUser] [int] NOT NULL,
	[AuditCreateDate] [datetime2](7) NOT NULL,
	[AuditUpdateUser] [int] NULL,
	[AuditUpdateDate] [datetime2](7) NULL,
	[AuditDeleteUser] [int] NULL,
	[AuditDeleteDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED
(
	[SaleDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[SaleId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[UserId] [int] NULL,
	[SaleDate] [datetime2](7) NULL,
	[Tax] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[State] [int] NULL,
	[AuditCreateUser] [int] NOT NULL,
	[AuditCreateDate] [datetime2](7) NOT NULL,
	[AuditUpdateUser] [int] NULL,
	[AuditUpdateDate] [datetime2](7) NULL,
	[AuditDeleteUser] [int] NULL,
	[AuditDeleteDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED
(
	[SaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[UserId] [int] NULL,
	[State] [int] NULL,
	[BranchOfficeId] [int] NULL,
PRIMARY KEY CLUSTERED
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[Email] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[Birthdate] [datetime2](7) NULL,
	[Phone] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[Image] [varchar](max) NULL,
	[State] [int] NOT NULL DEFAULT ((1)),
	[AuditCreateUser] [int] NOT NULL,
	[AuditCreateDate] [datetime2](7) NOT NULL,
	[AuditUpdateUser] [int] NULL,
	[AuditUpdateDate] [datetime2](7) NULL,
	[AuditDeleteUser] [int] NULL,
	[AuditDeleteDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[BranchOffices]  WITH CHECK ADD FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Business] ([BusinessId])
GO
ALTER TABLE [dbo].[BranchOffices]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[Business]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Provinces] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Provinces] ([ProvinceId])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Provinces]
GO
ALTER TABLE [dbo].[MenuRoles]  WITH CHECK ADD  CONSTRAINT [FK_MenuRoles_Menu] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Menus] ([MenuId])
GO
ALTER TABLE [dbo].[MenuRoles] CHECK CONSTRAINT [FK_MenuRoles_Menu]
GO
ALTER TABLE [dbo].[MenuRoles]  WITH CHECK ADD  CONSTRAINT [FK_MenuRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[MenuRoles] CHECK CONSTRAINT [FK_MenuRoles_Roles]
GO
ALTER TABLE [dbo].[PurchaseDetails]  WITH CHECK ADD FOREIGN KEY([PurchaseId])
REFERENCES [dbo].[Purchases] ([PurchaseId])
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[SaleDetails]  WITH CHECK ADD FOREIGN KEY([SaleId])
REFERENCES [dbo].[Sales] ([SaleId])
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD FOREIGN KEY([BranchOfficeId])
REFERENCES [dbo].[BranchOffices] ([BranchOfficeId])
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

/*---  Tablas de Administracion de peliculas  ----*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movies](
    [MovieId] [int] IDENTITY(1,1) NOT NULL,
    [Title] [varchar](50) NULL,
    [IdCategory] [int] NULL,
    [IdDirector] [int] NULL,
    [Year] [int] NULL,
    [IdActor] [int] NULL,
    [Rating] [int] NULL,
    [Description] [varchar](max) NULL,
    [Image] [varchar](max) NULL,
    [State] [int] NULL,
    [AuditCreateUser] [int] NOT NULL,
    [AuditCreateDate] [datetime2](7) NOT NULL,
    [AuditUpdateUser] [int] NULL,
    [AuditUpdateDate] [datetime2](7) NULL,
    [AuditDeleteUser] [int] NULL,
    [AuditDeleteDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED
(
    [MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categories](
    [CategoryId] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](50) NULL,
    [State] [int] NULL,
    [AuditCreateUser] [int] NOT NULL,
    [AuditCreateDate] [datetime2](7) NOT NULL,
    [AuditUpdateUser] [int] NULL,
    [AuditUpdateDate] [datetime2](7) NULL,
    [AuditDeleteUser] [int] NULL,
    [AuditDeleteDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED
(
    [CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Directors](
    [DirectorId] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](50) NULL,
    [State] [int] NULL,
    [AuditCreateUser] [int] NOT NULL,
    [AuditCreateDate] [datetime2](7) NOT NULL,
    [AuditUpdateUser] [int] NULL,
    [AuditUpdateDate] [datetime2](7) NULL,
    [AuditDeleteUser] [int] NULL,
    [AuditDeleteDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED
(
    [DirectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Actors](
    [ActorId] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](50) NULL,
    [State] [int] NULL,
    [AuditCreateUser] [int] NOT NULL,
    [AuditCreateDate] [datetime2](7) NOT NULL,
    [AuditUpdateUser] [int] NULL,
    [AuditUpdateDate] [datetime2](7) NULL,
    [AuditDeleteUser] [int] NULL,
    [AuditDeleteDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED
(
    [ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Categories] ([CategoryId])

GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD FOREIGN KEY([IdDirector])
REFERENCES [dbo].[Directors] ([DirectorId])

GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD FOREIGN KEY([IdActor])
REFERENCES [dbo].[Actors] ([ActorId])



