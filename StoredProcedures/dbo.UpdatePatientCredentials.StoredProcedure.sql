USE [EHRDB]
GO
/****** Object:  StoredProcedure [dbo].[UpdatePatientCredentials]    Script Date: 1/31/2018 7:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- UPDATE PATIENT CREDENTIALS AND ENCRYPT THE PASSWORD
CREATE PROCEDURE [dbo].[UpdatePatientCredentials]
(
@PatientID INT,
@PPassword VARCHAR(20)
)
AS
OPEN SYMMETRIC KEY SQLSymmetricKey  
DECRYPTION BY CERTIFICATE SelfSignedCertificate; 
UPDATE [dbo].[PatientCredentials]
   SET 
      [PPassword] = EncryptByKey(Key_GUID('SQLSymmetricKey'), @PPassword)
 WHERE [PatientID] = @PatientID



GO
