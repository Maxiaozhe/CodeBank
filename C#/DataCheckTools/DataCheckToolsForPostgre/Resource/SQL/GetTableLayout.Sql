select 
t.name as table_Name,
c.name as column_Name,
tp.name as [DataType],
CAST(CASE WHEN tp.name IN (N'nchar', N'nvarchar') AND c.max_length <> -1 THEN c.max_length/2 ELSE c.max_length END AS int) AS [Length],
CAST(c.precision AS int) AS [NumericPrecision],
CAST(c.scale AS int) AS [NumericScale],
c.is_nullable as [nullable],
CAST(ISNULL(cik.index_column_id, 0) AS bit) AS [InPrimaryKey],
c.column_id as column_id,
cik.index_column_id,
p.value as [display_name],
c.is_identity as [is_identity]
from
sys.tables as t
inner join sys.all_columns as c on(t.object_id = c.object_id)
LEFT OUTER JOIN sys.types AS tp ON (tp.user_type_id = c.user_type_id)
left outer join sys.indexes as ik on(ik.object_id =t.object_id and ik.is_primary_key=1)
left outer join sys.index_columns as cik on(cik.index_id = ik.index_id and cik.column_id = c.column_id and cik.object_id = c.object_id and cik.is_included_column=0)
left outer join sys.fn_listextendedproperty(N'MS_Description','SCHEMA','dbo','TABLE',@tableName,'COLUMN',null) as p 
 on(cast( p.objname as nvarchar(max)) = cast(c.name as nvarchar(max)) collate Japanese_CI_AS) 
where
t.name = @tableName
order by
t.name,
c.column_id,
cik.index_column_id