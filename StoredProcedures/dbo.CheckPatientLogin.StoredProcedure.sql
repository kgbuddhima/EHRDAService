USE [EHRDB]
GO
/****** Object:  StoredProcedure [dbo].[CheckPatientLogin]    Script Date: 1/31/2018 7:41:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- check user name and password are correct
CREATE PROCEDURE [dbo].[CheckPatientLogin]
(
@PUserName VARCHAR(20),
@PPassword VARCHAR(20)
)
AS
OPEN SYMMETRIC KEY SQLSymmetricKey  
DECRYPTION BY CERTIFICATE SelfSignedCertificate; 
SELECT 
c.PatientID
FROM [dbo].[PatientCredentials] c
INNER JOIN Patient p
ON
c.PatientID=p.PatientId
WHERE
c.[PUserName]=@PUserName AND
CONVERT(varchar, DecryptByKey(c.[PPassword]))=@PPassword
AND
p.IsActive=1
GO
