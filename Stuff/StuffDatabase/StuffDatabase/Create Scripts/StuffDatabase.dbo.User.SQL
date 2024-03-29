/****** Object:  Table [dbo].[User]    Script Date: 02/09/2009 17:22:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[User]    Script Date: 02/09/2009 17:22:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[UserId] [uniqueidentifier] NOT NULL,
	[EmailAddress] [nvarchar](256) NOT NULL,
	[GivenName] [nvarchar](100) NOT NULL,
	[FamilyName] [nvarchar](100) NOT NULL
) ON [PRIMARY]
END
GO
