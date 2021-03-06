USE [EHRDB]
GO
/****** Object:  StoredProcedure [dbo].[CheckStaffLogin]    Script Date: 1/31/2018 7:41:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- check user name and password are correct
CREATE PROCEDURE [dbo].[CheckStaffLogin]
(
@SUserName VARCHAR(20),
@SPassword VARCHAR(20)
)
AS
OPEN SYMMETRIC KEY SQLSymmetricKey  
DECRYPTION BY CERTIFICATE SelfSignedCertificate; 
SELECT 
StaffID
FROM [dbo].[StaffCredentials]
WHERE
[SUsername]=@SUserName AND
CONVERT(varchar, DecryptByKey([SPassword]))=@SPassword
GO
