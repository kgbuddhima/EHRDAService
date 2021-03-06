USE [EHRDB]
GO
/****** Object:  StoredProcedure [dbo].[InsertAddressofpatient]    Script Date: 1/31/2018 7:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertAddressofpatient]
(
@PatientId INT,
@AddressL1 VARCHAR(100),
@AddressL2 VARCHAR(100),
@AddressL3 VARCHAR(100),
@PostCode VARCHAR(10),
@City VARCHAR(100),
@Country VARCHAR(100)
)
AS
INSERT INTO [dbo].[PatientAddress]
           ([PatientId]
           ,[AddressL1]
           ,[AddressL2]
           ,[AddressL3]
           ,[PostCode]
           ,[City]
           ,[Country])
     VALUES
           (@PatientId
           ,@AddressL1
           ,@AddressL2
           ,@AddressL3
           ,@PostCode
           ,@City
           ,@Country)
GO
