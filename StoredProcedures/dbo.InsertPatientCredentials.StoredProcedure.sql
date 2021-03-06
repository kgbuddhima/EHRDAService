USE [EHRDB]
GO
/****** Object:  StoredProcedure [dbo].[InsertPatientCredentials]    Script Date: 1/31/2018 7:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- INSERT IATIENT CREDENTIALS AND ENCRYPT THE PASSWORD
CREATE PROCEDURE [dbo].[InsertPatientCredentials]
(
@PatientID INT,
@PPassword VARCHAR(20),
@PUserName VARCHAR(20)
)
AS

OPEN SYMMETRIC KEY SQLSymmetricKey  
DECRYPTION BY CERTIFICATE SelfSignedCertificate;  

INSERT INTO [dbo].[PatientCredentials]
           ([PatientID]
           ,[PPassword]
           ,[PUserName])
     VALUES
           (@PatientID
           ,EncryptByKey(Key_GUID('SQLSymmetricKey'), @PPassword)
           ,@PUserName)


GO
