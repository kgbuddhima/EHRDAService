USE [EHRDB]
GO
/****** Object:  StoredProcedure [dbo].[GetPatientById]    Script Date: 1/31/2018 7:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPatientById]
(
@PatientId INT
)
AS
SELECT [ID]
      ,[PatientId]
      ,[PIN]
      ,[PatientName]
      ,[NIC]
      ,[Gender]
      ,[Birthday]
      ,[JoinedDate]
      ,[UpdatedDate]
      ,[IsActive]
  FROM [dbo].[Patient]
WHERE [PatientId]=@PatientId


GO
