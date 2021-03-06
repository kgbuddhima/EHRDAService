USE [EHRDB]
GO
/****** Object:  StoredProcedure [dbo].[DeactivatePatient]    Script Date: 1/31/2018 7:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeactivatePatient]
(
@PatientId INT
)
AS
UPDATE [dbo].[Patient]
   SET 
       [IsActive] = 0
 WHERE [PatientId]=@PatientId
GO
