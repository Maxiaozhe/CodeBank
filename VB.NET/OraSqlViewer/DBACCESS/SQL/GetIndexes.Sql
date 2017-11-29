select 
INDEX_NAME,
COLUMN_NAME
from 
all_ind_columns 
where 
(TABLE_OWNER = :OWNER) 
AND (TABLE_NAME = :TABLENAME) 
order by
INDEX_NAME,
COLUMN_NAME