set search_path to information_schema;
select distinct
t.table_name as "table_Name",
c.column_name as "column_Name",
udt_name as "DataType",
character_maximum_length as "Length",
numeric_precision as "NumericPrecision",
numeric_scale as "NumericScale",
case when is_nullable='NO' then false else true end as "nullable",
case when k.ordinal_position is null then false else true end as "InPrimaryKey",
c.ordinal_position as "column_id",
k.ordinal_position as "index_column_id",
'' as "display_name",
false as "is_identity"
from tables as t
inner join columns as c on(t.table_schema = c.table_schema and c.table_name=t.table_name)
left join key_column_usage as k on(c.table_schema = k.table_schema and c.table_name=k.table_name and c.column_name=k.column_name and position_in_unique_constraint is null)
where 
t.table_schema = @schema
and t.table_name = @tableName
order by
column_id;
