USE [NFSDB]
GO
/****** Object:  Table [dbo].[MIGRATE_VIEW]    Script Date: 2015/10/19 14:25:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MIGRATE_VIEW](
	[TASK_ID] [nvarchar](36) NOT NULL,
	[NAME] [nvarchar](100) NOT NULL,
	[ALIASES] [nvarchar](255) NULL,
	[DISPLAY_NAME] [nvarchar](100) NOT NULL,
	[NS_VIEW_TYPE] [int] NOT NULL,
	[SP_VIEW_TYPE] [int] NULL,
	[IS_PAGED] [bit] NOT NULL,
	[ROW_LIMIT] [int] NOT NULL,
	[SHOW_CHECKED] [bit] NOT NULL,
	[NS_URL] [nvarchar](512) NULL,
	[SELECTION_FORMULA] [nvarchar](max) NULL,
	[NS_COLUMNS] [nvarchar](max) NULL,
	[COLUMNS] [nvarchar](max) NULL,
	[SORT_COLUMNS] [nvarchar](max) NULL,
	[GROUP_COLUMNS] [nvarchar](max) NULL,
	[FILTER_CONDITION] [nvarchar](max) NULL,
	[REF_FORMS] [nvarchar](max) NULL,
	[IS_DEFAULT] [bit] NULL,
	[DEFAULT_VIEW] [bit] NOT NULL,
	[IS_TARGET] [bit] NOT NULL,
	[SP_GUID] [nvarchar](36) NULL,
	[SP_URL] [nvarchar](255) NULL,
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
 CONSTRAINT [PK_MIGRATE_VIEW] PRIMARY KEY CLUSTERED 
(
	[TASK_ID] ASC,
	[NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
