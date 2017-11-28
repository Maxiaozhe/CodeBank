/****** Object:  Table [dbo].[TableLayoutInfo]    Script Date: 2015/12/17 21:45:30 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TableLayoutInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TableLayoutInfo](
	[TableName] [nvarchar](200) NOT NULL,
	[TableDisplayName] [nvarchar](200) NULL,
	[ColumnName] [nvarchar](200) NOT NULL,
	[ColumnDisplayName] [nvarchar](200) NULL,
	[DataType] [nvarchar](100) NULL,
	[Length] [int] NULL,
	[Precision] [int] NULL,
	[Scale] [int] NULL,
	[Nullable] [bit] NOT NULL,
	[IsPrimaryKey] [bit] NOT NULL,
	[ColumnId] [int] NULL,
	[IndexId] [int] NULL,
	[Comment] [nvarchar](max) NULL,
	[Category] [nvarchar](100) NULL,
 CONSTRAINT [PK_TableLayoutInfo] PRIMARY KEY CLUSTERED 
(
	[TableName] ASC,
	[ColumnName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TableList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TableList](
	[TableName] [nvarchar](200) NOT NULL,
	[TableDisplayName] [nvarchar](200) NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_TableList] PRIMARY KEY CLUSTERED 
(
	[TableName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

declare @TableName as nvarchar(400)
declare Table_Cursor cursor
for
	select 
	t.name as Table_name
	from 
	sys.tables as t
	where
	t.type in (N'U')
	--and t.name !='TableLayoutInfo'
	order by
	t.name;

truncate table TableList;
truncate table TableLayoutInfo;

open Table_Cursor

FETCH NEXT FROM Table_Cursor 
INTO @TableName

WHILE @@FETCH_STATUS = 0
BEGIN
	
	insert into TableLayoutInfo(
		TableName,
		TableDisplayName,
		ColumnName,
		ColumnDisplayName,
		DataType,
		[Length],
		[Precision],
		Scale,
		Nullable,
		IsPrimaryKey,
		ColumnId,
		IndexId,
		Comment,
		Category
	)
	SELECT 
	T.NAME AS TableName,
	cast(TC.value as nvarchar(400)) as TableDisplayName,
	C.NAME AS ColumnName,
	cast(P.VALUE  as nvarchar(400)) AS [ColumnDisplayName],
	TP.NAME AS [DataType],
	CAST(CASE WHEN TP.NAME IN (N'NCHAR', N'NVARCHAR') AND C.MAX_LENGTH <> -1 THEN C.MAX_LENGTH/2 ELSE C.MAX_LENGTH END AS INT) AS [Length],
	CAST(C.PRECISION AS INT) AS [Precision],
	CAST(C.SCALE AS INT) AS [Scale],
	C.IS_NULLABLE AS [Nullable],
	CAST(ISNULL(CIK.INDEX_COLUMN_ID, 0) AS BIT) AS [IsPrimaryKey],
	C.COLUMN_ID AS ColumnId,
	CIK.INDEX_COLUMN_ID as IndexId,
	CAST(COMM.value as nvarchar(400)) AS Comment,
	'' as Category
	FROM
	SYS.TABLES AS T
	INNER JOIN SYS.ALL_COLUMNS AS C ON(T.OBJECT_ID = C.OBJECT_ID)
	LEFT OUTER JOIN SYS.TYPES AS TP ON (TP.USER_TYPE_ID = C.USER_TYPE_ID)
	LEFT OUTER JOIN SYS.INDEXES AS IK ON(IK.OBJECT_ID =T.OBJECT_ID AND IK.IS_PRIMARY_KEY=1)
	LEFT OUTER JOIN SYS.INDEX_COLUMNS AS CIK ON(CIK.INDEX_ID = IK.INDEX_ID AND CIK.COLUMN_ID = C.COLUMN_ID AND CIK.OBJECT_ID = C.OBJECT_ID AND CIK.IS_INCLUDED_COLUMN=0)
	LEFT OUTER JOIN SYS.FN_LISTEXTENDEDPROPERTY(N'MS_DESCRIPTION','SCHEMA','DBO','TABLE',null,null,NULL) AS TC ON(TC.objname = T.name  COLLATE JAPANESE_CI_AS)
	LEFT OUTER JOIN SYS.FN_LISTEXTENDEDPROPERTY(N'MS_DESCRIPTION','SCHEMA','DBO','TABLE',@TableName,'COLUMN',NULL) AS P 
	 ON(C.object_id=object_id(@TableName) and CAST( P.OBJNAME AS NVARCHAR(max)) = CAST(C.NAME AS NVARCHAR(max)) COLLATE JAPANESE_CI_AS) 
	LEFT OUTER JOIN SYS.FN_LISTEXTENDEDPROPERTY(N'COMMENT','SCHEMA','DBO','TABLE',@TableName,'COLUMN',NULL) AS COMM 
	 ON(C.object_id=object_id(@TableName) and CAST( COMM.OBJNAME AS NVARCHAR(max)) = CAST(C.NAME AS NVARCHAR(max)) COLLATE JAPANESE_CI_AS) 

	WHERE
	T.NAME = @TABLENAME
	ORDER BY
	T.NAME,
	C.COLUMN_ID,
	CIK.INDEX_COLUMN_ID

    FETCH NEXT FROM Table_Cursor 
    INTO @TableName
END 
CLOSE Table_Cursor;
DEALLOCATE Table_Cursor;

INSERT INTO TABLELIST
SELECT DISTINCT TABLENAME,TABLEDISPLAYNAME,'' AS COMMENT FROM TABLELAYOUTINFO

