USE [cis_Full]
GO

/****** Object:  Table [dbo].[MedicalMaterial_]    Script Date: 05/14/2012 14:43:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MedicalMaterial_](
	[OID_] [uniqueidentifier] NOT NULL,
	[Code_] [varchar](10) NULL,
	[Name_] [nvarchar](100) NULL,
	[UnitOID_] [uniqueidentifier] NULL,
	[TypeOID_] [uniqueidentifier] NULL,
	[Deactivated_] [bit] NOT NULL,
	[ClinicOID_] [uniqueidentifier] NULL,
 CONSTRAINT [PK_MedicalMaterial] PRIMARY KEY CLUSTERED 
(
	[OID_] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contain Medicine and Other medical Material' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MedicalMaterial_'
GO

USE [cis_Full]
GO

/****** Object:  Table [dbo].[MedicalMaterialPackageItems_]    Script Date: 05/14/2012 14:43:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MedicalMaterialPackageItems_](
	[OID_] [uniqueidentifier] NOT NULL,
	[Code_] [varchar](50) NULL,
	[Name_] [nvarchar](150) NULL,
 CONSTRAINT [PK_MedicalMaterialPackageItems] PRIMARY KEY CLUSTERED 
(
	[OID_] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [cis_Full]
GO

/****** Object:  Table [dbo].[MedicalMaterialPackageItemsDetail_]    Script Date: 05/14/2012 14:43:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MedicalMaterialPackageItemsDetail_](
	[MedicalMaterialPackageOID_] [uniqueidentifier] NOT NULL,
	[MedicalMarterialItemOID_] [uniqueidentifier] NOT NULL,
	[UnitOID_] [uniqueidentifier] NULL,
	[Quantity_] [decimal](18, 2) NULL,
	[Note_] [nchar](10) NULL,
 CONSTRAINT [PK_MedicalMaterialPackageItemsDetail] PRIMARY KEY CLUSTERED 
(
	[MedicalMaterialPackageOID_] ASC,
	[MedicalMarterialItemOID_] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [cis_Full]
GO

/****** Object:  Table [dbo].[MedicalMaterialTransactions_]    Script Date: 05/14/2012 14:43:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MedicalMaterialTransactions_](
	[OID_] [uniqueidentifier] NOT NULL,
	[MedicalMaterialOID_] [uniqueidentifier] NULL,
	[unitOID_] [uniqueidentifier] NULL,
	[Quantity_] [int] NULL,
	[UnitPrice_] [decimal](18, 2) NULL,
	[visitOID_] [uniqueidentifier] NULL,
	[UserEntryOID_] [uniqueidentifier] NULL,
	[TransactionType_] [varchar](50) NULL,
	[supplier_] [varchar](50) NULL,
	[RefID_] [varchar](50) NULL,
	[wareHouseOID_] [uniqueidentifier] NULL,
	[ProduceDate_] [datetime] NULL,
	[Expiredate_] [datetime] NULL,
	[Note_] [nvarchar](max) NULL,
 CONSTRAINT [PK_MedicalMaterialTransactions] PRIMARY KEY CLUSTERED 
(
	[OID_] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'if sale medicine to Patient visit will be visit of Patient other wise null' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MedicalMaterialTransactions_', @level2type=N'COLUMN',@level2name=N'visitOID_'
GO

USE [cis_Full]
GO

/****** Object:  Table [dbo].[MedicalMaterialTypes_]    Script Date: 05/14/2012 14:43:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MedicalMaterialTypes_](
	[OID_] [uniqueidentifier] NOT NULL,
	[Code_] [varchar](10) NULL,
	[Name_] [nvarchar](100) NULL,
 CONSTRAINT [PK_MedicalMaterialTypes] PRIMARY KEY CLUSTERED 
(
	[OID_] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contain Madicine Type and order medical Material' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MedicalMaterialTypes_'
GO

USE [cis_Full]
GO

/****** Object:  Table [dbo].[Warehouse_]    Script Date: 05/14/2012 14:43:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Warehouse_](
	[OID_] [uniqueidentifier] NOT NULL,
	[Code_] [varchar](50) NULL,
	[Name_] [nvarchar](250) NULL,
	[PhoneNunmber_] [varchar](50) NULL,
	[managerOID_] [uniqueidentifier] NULL,
	[CityID] [uniqueidentifier] NULL,
	[ClinicOID_] [uniqueidentifier] NULL,
	[Address] [nvarchar](250) NULL,
	[Deactivated_] [bit] NOT NULL,
 CONSTRAINT [PK_warehouse] PRIMARY KEY CLUSTERED 
(
	[OID_] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[MedicalMaterial_]  WITH CHECK ADD  CONSTRAINT [FK_MedicalMaterial_Clinics] FOREIGN KEY([ClinicOID_])
REFERENCES [dbo].[Facility_] ([OID_])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[MedicalMaterial_] CHECK CONSTRAINT [FK_MedicalMaterial_Clinics]
GO

ALTER TABLE [dbo].[MedicalMaterial_]  WITH CHECK ADD  CONSTRAINT [FK_MedicalMaterial_MedicalMaterialTypes] FOREIGN KEY([TypeOID_])
REFERENCES [dbo].[MedicalMaterialTypes_] ([OID_])
GO

ALTER TABLE [dbo].[MedicalMaterial_] CHECK CONSTRAINT [FK_MedicalMaterial_MedicalMaterialTypes]
GO

ALTER TABLE [dbo].[MedicalMaterial_]  WITH CHECK ADD  CONSTRAINT [FK_MedicalMaterial_UnitConvertedValue] FOREIGN KEY([UnitOID_])
REFERENCES [dbo].[UnitConvertedValue_] ([UnitOID_])
GO

ALTER TABLE [dbo].[MedicalMaterial_] CHECK CONSTRAINT [FK_MedicalMaterial_UnitConvertedValue]
GO

ALTER TABLE [dbo].[MedicalMaterial_] ADD  CONSTRAINT [DF_MedicalMaterial_ID]  DEFAULT (newid()) FOR [OID_]
GO

ALTER TABLE [dbo].[MedicalMaterialPackageItems_] ADD  CONSTRAINT [DF_MedicalMaterialPackageItems_ID]  DEFAULT (newid()) FOR [OID_]
GO

ALTER TABLE [dbo].[MedicalMaterialPackageItemsDetail_]  WITH CHECK ADD  CONSTRAINT [FK_MedicalMaterialPackageItemsDetail_MedicalMaterial] FOREIGN KEY([MedicalMarterialItemOID_])
REFERENCES [dbo].[MedicalMaterial_] ([OID_])
GO

ALTER TABLE [dbo].[MedicalMaterialPackageItemsDetail_] CHECK CONSTRAINT [FK_MedicalMaterialPackageItemsDetail_MedicalMaterial]
GO

ALTER TABLE [dbo].[MedicalMaterialPackageItemsDetail_]  WITH CHECK ADD  CONSTRAINT [FK_MedicalMaterialPackageItemsDetail_MedicalMaterialPackageItems] FOREIGN KEY([MedicalMaterialPackageOID_])
REFERENCES [dbo].[MedicalMaterialPackageItems_] ([OID_])
GO

ALTER TABLE [dbo].[MedicalMaterialPackageItemsDetail_] CHECK CONSTRAINT [FK_MedicalMaterialPackageItemsDetail_MedicalMaterialPackageItems]
GO

ALTER TABLE [dbo].[MedicalMaterialPackageItemsDetail_]  WITH CHECK ADD  CONSTRAINT [FK_MedicalMaterialPackageItemsDetail_UnitConvertedValue] FOREIGN KEY([UnitOID_])
REFERENCES [dbo].[UnitConvertedValue_] ([UnitOID_])
GO

ALTER TABLE [dbo].[MedicalMaterialPackageItemsDetail_] CHECK CONSTRAINT [FK_MedicalMaterialPackageItemsDetail_UnitConvertedValue]
GO

ALTER TABLE [dbo].[MedicalMaterialTransactions_]  WITH CHECK ADD  CONSTRAINT [FK_MedicalMaterialTransactions_MedicalMaterial] FOREIGN KEY([MedicalMaterialOID_])
REFERENCES [dbo].[MedicalMaterial_] ([OID_])
GO

ALTER TABLE [dbo].[MedicalMaterialTransactions_] CHECK CONSTRAINT [FK_MedicalMaterialTransactions_MedicalMaterial]
GO

ALTER TABLE [dbo].[MedicalMaterialTransactions_]  WITH CHECK ADD  CONSTRAINT [FK_MedicalMaterialTransactions_PatientVisits] FOREIGN KEY([visitOID_])
REFERENCES [dbo].[Visit_] ([OID_])
GO

ALTER TABLE [dbo].[MedicalMaterialTransactions_] CHECK CONSTRAINT [FK_MedicalMaterialTransactions_PatientVisits]
GO

ALTER TABLE [dbo].[MedicalMaterialTransactions_]  WITH CHECK ADD  CONSTRAINT [FK_MedicalMaterialTransactions_UnitConvertedValue] FOREIGN KEY([unitOID_])
REFERENCES [dbo].[UnitConvertedValue_] ([UnitOID_])
GO

ALTER TABLE [dbo].[MedicalMaterialTransactions_] CHECK CONSTRAINT [FK_MedicalMaterialTransactions_UnitConvertedValue]
GO

ALTER TABLE [dbo].[MedicalMaterialTransactions_]  WITH CHECK ADD  CONSTRAINT [FK_MedicalMaterialTransactions_warehouse] FOREIGN KEY([wareHouseOID_])
REFERENCES [dbo].[Warehouse_] ([OID_])
GO

ALTER TABLE [dbo].[MedicalMaterialTransactions_] CHECK CONSTRAINT [FK_MedicalMaterialTransactions_warehouse]
GO

ALTER TABLE [dbo].[MedicalMaterialTransactions_] ADD  CONSTRAINT [DF_MedicalMaterialTransactions_ID]  DEFAULT (newid()) FOR [OID_]
GO

ALTER TABLE [dbo].[MedicalMaterialTransactions_] ADD  CONSTRAINT [DF_MedicineTransactions_IsSale]  DEFAULT ((1)) FOR [TransactionType_]
GO

ALTER TABLE [dbo].[MedicalMaterialTypes_] ADD  CONSTRAINT [DF_MedicalMaterialTypes_ID]  DEFAULT (newid()) FOR [OID_]
GO

ALTER TABLE [dbo].[Warehouse_]  WITH CHECK ADD  CONSTRAINT [FK_warehouse_Clinics] FOREIGN KEY([ClinicOID_])
REFERENCES [dbo].[Facility_] ([OID_])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Warehouse_] CHECK CONSTRAINT [FK_warehouse_Clinics]
GO

ALTER TABLE [dbo].[Warehouse_] ADD  CONSTRAINT [DF_warehouse_ID]  DEFAULT (newid()) FOR [OID_]
GO


