USE [EHRDB]
GO
/****** Object:  StoredProcedure [dbo].[GetPatientByPIN]    Script Date: 1/31/2018 7:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetPatientByPIN]
(
@PIN VARCHAR(10)
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
WHERE [PIN]=@PIN


GO
