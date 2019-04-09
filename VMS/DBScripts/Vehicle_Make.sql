USE [Vehicles]
GO

/****** Object:  Table [dbo].[VEHICLE_MAKE]    Script Date: 9/04/2019 3:51:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VEHICLE_MAKE](
	[VMAKE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[VEHICLEMAKE_NAME] [nvarchar](200) NOT NULL,
	[IS_ACTIVE] [char](10) NULL,
	[CREATED_BY] [nvarchar](200) NULL,
	[CREATED_DATE] [date] NULL,
	[MODIFIED_BY] [nvarchar](200) NULL,
	[MODIFIED_DATE] [date] NULL,
	[DESCRIPTION] [nvarchar](100) NULL,
 CONSTRAINT [PK_VEHICLE_MAKE] PRIMARY KEY CLUSTERED 
(
	[VMAKE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


