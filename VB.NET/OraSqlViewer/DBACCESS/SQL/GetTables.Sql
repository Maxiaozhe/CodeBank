SELECT 
OWNER, 
TABLE_NAME, 
DECODE(OWNER, 'SYS', 'System', 'SYSTEM', 'System', 'SYSMAN', 'System','CTXSYS', 'System','MDSYS', 'System','OLAPSYS', 'System', 'ORDSYS', 'System','OUTLN', 'System', 'WKSYS', 'System','WMSYS', 'System','XDB', 'System','ORDPLUGINS', 'System','User') AS Type 
FROM ALL_TABLES
WHERE (OWNER=:OWNER or :OWNER IS NULL) 
ORDER BY OWNER, TABLE_NAME