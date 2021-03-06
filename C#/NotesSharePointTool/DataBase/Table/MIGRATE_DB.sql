USE [NFSDB]
GO
/****** Object:  Table [dbo].[MIGRATE_DB]    Script Date: 2015/10/19 14:25:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MIGRATE_DB](
	[TASK_ID] [nvarchar](36) NOT NULL,
	[TASK_NAME] [nvarchar](50) NOT NULL,
	[NS_SERVER] [nvarchar](200) NULL,
	[NS_DB_TITLE] [nvarchar](200) NULL,
	[NS_FILE_NAME] [nvarchar](200) NULL,
	[NS_FILE_PATH] [nvarchar](512) NOT NULL,
	[NS_URL] [nvarchar](512) NULL,
	[REPLICA_ID] [nvarchar](32) NULL,
	[NS_TEMP_TYPE] [int] NULL,
	[SP_LIST_TYPE] [int] NULL,
	[SP_LIST_NAME] [nvarchar](128) NULL,
	[SP_DISPLAY_NAME] [nvarchar](128) NULL,
	[DESCRIPTION] [nvarchar](256) NULL,
	[SP_SITE_URL] [nvarchar](256) NULL,
	[SP_LIST_ID] [nvarchar](256) NULL,
	[SHARED_FIELDS] [nvarchar](max) NULL,
	[IS_DEFAULT_ICON] [bit] NULL,
	[SP_LIST_URL] [nvarchar](255) NULL,
	[STATE] [int] NOT NULL,
	[EXECUTE_DATE] [datetime] NULL,
	[DEL_FLAG] [bit] NOT NULL,
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
 CONSTRAINT [PK_MIGRATE_DB] PRIMARY KEY CLUSTERED 
(
	[TASK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
