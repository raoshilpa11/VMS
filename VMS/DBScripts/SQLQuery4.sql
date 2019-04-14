USE [Vehicles]
GO

/****** Object:  Table [dbo].[VEHICLE_RECORDS_PROPERTIES]    Script Date: 31/03/2019 2:43:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VEHICLE_RECORDS_PROPERTIES](
	[VRP_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[VR_ID] [numeric](18, 0) NOT NULL,
	[VPM_ID] [numeric](18, 0) NOT NULL,
	[VALUE] [nvarchar](200) NOT NULL,
	[IS_ACTIVE] [char](10) NULL,
	[CREATED_BY] [nvarchar](200) NULL,
	[CREATED_DATE] [date] NULL,
	[MODIFIED_BY] [nvarchar](200) NULL,
	[MODIFIED_DATE] [date] NULL,
	[DESCRIPTION] [nvarchar](100) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[VEHICLE_RECORDS_PROPERTIES]  WITH CHECK ADD FOREIGN KEY([VPM_ID])
REFERENCES [dbo].[VEHICLE_PROPERTIES_MAPPING] ([VPM_ID])
GO

ALTER TABLE [dbo].[VEHICLE_RECORDS_PROPERTIES]  WITH CHECK ADD FOREIGN KEY([VR_ID])
REFERENCES [dbo].[VEHICLE_RECORDS] ([VR_ID])
GO

------------------


USE [Vehicles]
GO

/****** Object:  Table [dbo].[VEHICLE_RECORDS_PROPERTIES]    Script Date: 31/03/2019 2:44:24 PM ******/
DROP TABLE [dbo].[VEHICLE_RECORDS_PROPERTIES]
GO

select * from VEHICLE_PROPERTIES

select * from VEHICLE_RECORDS


----------------------------


USE [Vehicles]
GO

INSERT INTO [dbo].[VEHICLE_RECORDS_PROPERTIES]
           ([VR_ID],[VPM_ID],[VALUE],[IS_ACTIVE],[CREATED_BY],[CREATED_DATE],[DESCRIPTION])
     VALUES
           (1, 1,'Y','Shilpa', SYSDATETIME(),'Insert record for ID')
GO

INSERT INTO [dbo].[VEHICLE_RECORDS_PROPERTIES]
            ([VR_ID],[VPM_ID],[VALUE],[IS_ACTIVE],[CREATED_BY],[CREATED_DATE],[DESCRIPTION])
     VALUES
           (1, 2, '3 cylinder','Y','Shilpa', SYSDATETIME(),'Insert record for Engine')
GO

INSERT INTO [dbo].[VEHICLE_RECORDS_PROPERTIES]
            ([VR_ID],[VPM_ID],[VALUE],[IS_ACTIVE],[CREATED_BY],[CREATED_DATE],[DESCRIPTION])
     VALUES
           (1, 3, '4','Y','Shilpa', SYSDATETIME(),'Insert record for Doors')
GO



INSERT INTO [dbo].[VEHICLE_RECORDS_PROPERTIES]
            ([VR_ID],[VPM_ID],[VALUE],[IS_ACTIVE],[CREATED_BY],[CREATED_DATE],[DESCRIPTION])
     VALUES
           (1, 4, '4','Y','Shilpa', SYSDATETIME(),'Insert record for Wheels')
GO
INSERT INTO [dbo].[VEHICLE_RECORDS_PROPERTIES]
            ([VR_ID],[VPM_ID],[VALUE],[IS_ACTIVE],[CREATED_BY],[CREATED_DATE],[DESCRIPTION])
     VALUES
           (1, 5, '4 doors 4 seat SUV','Y','Shilpa', SYSDATETIME(),'Insert record for BodyType')
GO
INSERT INTO [dbo].[VEHICLE_RECORDS_PROPERTIES]
            ([VR_ID],[VPM_ID],[VALUE],[IS_ACTIVE],[CREATED_BY],[CREATED_DATE],[DESCRIPTION])
     VALUES
           (1, 6, 'Black','Y','Shilpa', SYSDATETIME(),'Insert record for Colour')
GO